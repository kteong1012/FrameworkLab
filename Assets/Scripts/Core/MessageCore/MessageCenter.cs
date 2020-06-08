using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void MessageCallback(MessageBase messageBase);
public class MessageCenter : Singleton<MessageCenter>
{
    private Dictionary<MessageType, MessageCallback> _listenerDict = new Dictionary<MessageType, MessageCallback>();
    public Dictionary<MessageType, MessageCallback> ListenerDict => _listenerDict;

    private Queue<MessageBase> _msgList = new Queue<MessageBase>();
    public Queue<MessageBase> MsgList => _msgList;

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
