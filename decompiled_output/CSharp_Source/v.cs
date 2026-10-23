using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000019")]
public static class v
{
	[Token(Token = "0x60000F0")]
	[Address(RVA = "0x283E20", Offset = "0x282E20", VA = "0x180283E20")]
	private static void yk(string url)
	{
		Application.OpenURL(url);
	}

	[Token(Token = "0x60000F1")]
	[Address(RVA = "0x283E30", Offset = "0x282E30", VA = "0x180283E30")]
	private static bool yl(string url)
	{
		return true;
	}

	[Token(Token = "0x60000F2")]
	[Address(RVA = "0x283E40", Offset = "0x282E40", VA = "0x180283E40")]
	public static void ym(string url)
	{
		string text = "[UIApplicationBridge] OpenURL: " + url;
		Application.OpenURL(url);
	}

	[Token(Token = "0x60000F3")]
	[Address(RVA = "0x283E90", Offset = "0x282E90", VA = "0x180283E90")]
	public static bool yn(string url)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
