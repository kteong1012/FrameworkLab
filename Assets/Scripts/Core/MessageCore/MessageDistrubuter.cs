using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageDistrubuter : MonoBehaviour
{
    private const int MESSAGE_COUNT_PER_FRAME = 15;

    private MessageCenter _messageCenter = MessageCenter.Instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        for (int i = 0; i < MESSAGE_COUNT_PER_FRAME; i++)
        {
            if (_messageCenter.MsgList.Count == 0)
                break;
            MessageBase msg = _messageCenter.MsgList.Dequeue();
            MessageCallback callback = null;
            _messageCenter.ListenerDict.TryGetValue(msg.messageType, out callback);
            try
            {
                callback?.Invoke(msg);
                if (msg.once)
                {
                    _messageCenter.ListenerDict.TrySafelyRemove(msg.messageType);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(msg.messageType.ToString() + "callback error  :" + e.Message);
                if (msg.mustBeHandled)
                {
                    _messageCenter.MsgList.Enqueue(msg);
                }
            }
        }
    }
}
