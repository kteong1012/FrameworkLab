using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTest : MonoBehaviour
{
    public void OnClick()
    {
        MessageManager.Instance.PostMessage(new DebugMessage("测试成功!!!"));
    }
}
