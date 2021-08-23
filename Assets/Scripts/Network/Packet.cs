using System;

[Serializable]
public class WebPacket
{
	public EPacketId id;
}

[Serializable]
public sealed class RollDiceReq : WebPacket
{
	
}

[Serializable]
public sealed class RollDiceRes : WebPacket
{
	
}

[Serializable]
public sealed class ChangeTurnNoti : WebPacket
{
	public int turn;
}

[Serializable]
public sealed class Build : WebPacket
{
	public string Country;
	public int Land;
	public int Building;
	public int Villa;
	public int Hotel;
}