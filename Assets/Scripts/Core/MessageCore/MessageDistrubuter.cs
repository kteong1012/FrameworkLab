using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageDistrubuter : MonoSingleton<MessageDistrubuter>
{
    private Queue<MessageBase> _messages = new Queue<MessageBase>();


    private void Update()
    {
        
    }
}
