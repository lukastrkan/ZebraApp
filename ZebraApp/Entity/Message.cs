namespace ZebraApp.Entity;

public class Message<T>(MessageType type, T data)
{
    public MessageType Type { get; set; } = type;

    public T Data { get; set; } = data;
}