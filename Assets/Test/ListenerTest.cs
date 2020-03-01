using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenerTest : MonoBehaviour
{
    private void OnEnable()
    {
        MessageCenter.Instance.RegisterListner(MessageType.Debug, DebugMessageCallback);
    }
    private void OnDisable()
    {
        MessageCenter.Instance.UnRegisterListner(MessageType.Debug, DebugMessageCallback);
    }

    private void DebugMessageCallback(MessageBase messageBase)
    {
        DebugMessage message = (DebugMessage)messageBase;
        Debug.Log(name + "   " + message.debugStr);
    }
}
