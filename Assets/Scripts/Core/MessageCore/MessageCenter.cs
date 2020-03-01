using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MessageCallback(MessageBase messageBase);
public class MessageCenter : MonoSingleton<MessageCenter>
{
    private const int MESSAGE_COUNT_PER_FRAME = 10;

    private Dictionary<MessageType, MessageCallback> _listenerDict = new Dictionary<MessageType, MessageCallback>();
    private Queue<MessageBase> _msgList = new Queue<MessageBase>();

    private void Update()
    {
        for(int i = 0; i < MESSAGE_COUNT_PER_FRAME; i++)
        {
            if (_msgList.Count == 0)
                break;
            MessageBase msg = _msgList.Dequeue();
            _listenerDict[msg.messageType].Invoke(msg);
            if (msg.once)
            {
                _listenerDict.Remove(msg.messageType);
            }
        }
    }
    public void RegisterListner(MessageType type, MessageCallback callback)
    {
        if (!_listenerDict.ContainsKey(type))
        {
            _listenerDict.TrySafelyAdd(type, callback);
        }
        else
        {
            _listenerDict[type] += callback;
        }
    }
    public void UnRegisterListner(MessageType type, MessageCallback callback)
    {
        if (!_listenerDict.ContainsKey(type))
        {
            return;
        }
        _listenerDict[type] -= callback;
        if (_listenerDict[type] == null)
        {
            _listenerDict.TrySafelyRemove(type);
        }
    }
    public void PostMessage(MessageBase message)
    {
        if (_listenerDict.ContainsKey(message.messageType))
        {
            _msgList.Enqueue(message);
        }
    }
}
