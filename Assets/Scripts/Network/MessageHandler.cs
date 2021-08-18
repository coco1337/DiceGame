using System;
using System.Text;
using Newtonsoft.Json;

public interface IMessageHandler
{
	Action MakeAction(byte[] message);
}

public class MessageHandler<T> : IMessageHandler where T : WebPacket
{
	private Action<T> handler;

	public MessageHandler(Action<T> handler)
	{
		this.handler = handler;
	}

	public Action MakeAction(byte[] message)
	{
		var jsonString = Encoding.Default.GetString(message);
		var msg = JsonConvert.DeserializeObject<T>(jsonString);
		return () => this.handler(msg);
	}
}