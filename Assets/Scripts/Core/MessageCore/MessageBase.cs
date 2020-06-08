using System.IO;
using UnityEngine;

public abstract class MessageBase
{
    public MessageType messageType;
    public bool once = false;
    public bool mustBeHandled = false;
}

public enum MessageType
{
    GameOver = 0,
    Debug = 1,
    LoadTexture = 2,
}

public class GameOverMessage : MessageBase
{
    public GameOverMessage()
    {
        messageType = MessageType.GameOver;
    }
}
public class DebugMessage : MessageBase
{
    public string debugStr;
    public DebugMessage(string str)
    {
        messageType = MessageType.Debug;
        debugStr = str;
    }
}
public class LoadTextureMessage : MessageBase
{
    public Stream stream;
    public LoadTextureMessage(Stream stream)
    {
        messageType = MessageType.LoadTexture;
        this.stream = stream;
    }
}