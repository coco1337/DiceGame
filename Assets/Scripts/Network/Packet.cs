using System;

[Serializable]
public class WebPacket
{
	
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