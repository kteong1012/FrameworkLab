using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public delegate void HttpRequestCallBack(HttpWebResponse response);

public class WebRequester
{
    public string url { get; private set; }
    public IDictionary<string, string> form { get; private set; }
    private HttpRequestCallBack callBack;

    public WebRequester(string url, HttpRequestCallBack callBack)
    {
        this.url = url;
        this.callBack = callBack;
        BeginGetRequest();
    }
    public WebRequester(string url, HttpRequestCallBack callBack,Dictionary<string, string> form)
    {
        this.url = url;
        this.callBack = callBack;
        this.form = form;
        BeginPostRequest();
    }
    private void BeginGetRequest()
    {
        Debug.Log("Start Get Request: " + url);
        HttpWebRequest httpRequest = WebRequest.Create(url) as HttpWebRequest;
        httpRequest.BeginGetResponse(new AsyncCallback(ResponseCallback), httpRequest);
    }
    private void BeginPostRequest()
    {
        Debug.Log("Start Get Request: " + url);
        HttpWebRequest httpRequest = WebRequest.Create(url) as HttpWebRequest;
        httpRequest.Method = "POST";
        httpRequest.ContentType = "application/x-www-form-urlencoded";
        if (form != null && form.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var item in form)
            {
                if (i > 0)
                {
                    sb.Append("&");
                }
                sb.AppendFormat("{0}={1}", item.Key, item.Value);
            }
            byte[] formBytes = Encoding.UTF8.GetBytes(sb.ToString());
            httpRequest.ContentLength = formBytes.Length;
            using (Stream reqStream = httpRequest.GetRequestStream())
            {
                reqStream.Write(formBytes, 0, formBytes.Length);
                reqStream.Close();
            }
        }
        httpRequest.BeginGetResponse(new AsyncCallback(ResponseCallback), httpRequest);
    }


    private void ResponseCallback(IAsyncResult ar)
    {
        HttpWebRequest req = ar.AsyncState as HttpWebRequest;
        if (req == null) return;
        HttpWebResponse response = req.EndGetResponse(ar) as HttpWebResponse;
        callBack?.Invoke(response);
    }
}
public class HttpRequestCenter : Singleton<HttpRequestCenter>
{
    public void HttpRequestGet(string url, HttpRequestCallBack callBack)
    {
        new WebRequester(url, callBack);
    }
    public void HttpRequestPost(string url, HttpRequestCallBack callBack, Dictionary<string,string> form)
    {
        new WebRequester(url, callBack, form);
    }
}
