using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DownloadTest : MonoBehaviour
{
    public string url;
    public string assetName;
    public Text text;

    private const string TEMP_PATH = @"F:/abc.jpg";
    private void Start()
    {
        MessageCenter.Instance.RegisterListner(MessageType.LoadTexture, LoadTexture);
    }

    private void OnDestroy()
    {
        MessageCenter.Instance.UnRegisterListner(MessageType.LoadTexture, LoadTexture);
    }
    public void OnClick()
    {
        HttpRequestCenter.Instance.HttpRequestGet(url, CB);
    }

    private void CB(HttpWebResponse response)
    {
        Debug.Log(response.StatusCode.ToString());
        string str = "";
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream s = response.GetResponseStream();
            MessageCenter.Instance.PostMessage(new LoadTextureMessage(s));

        }
    }
    private void LoadTexture(MessageBase messageBase)
    {
        LoadTextureMessage msg = (LoadTextureMessage)messageBase;
        StreamReader sr = new StreamReader(msg.stream);

        string str = sr.ReadToEnd();
        text.text = str;
    }

}
