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