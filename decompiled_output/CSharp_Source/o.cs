using System;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000014")]
public class o
{
	[Token(Token = "0x600009F")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public static void vt(string text)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000A0")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public static void vu(int text)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000A1")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public static void vv(string text)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000A2")]
	[Address(RVA = "0x27AC20", Offset = "0x279C20", VA = "0x18027AC20")]
	public static void vw(string text)
	{
		Debug.Log("aaa: " + text);
	}

	[Token(Token = "0x60000A3")]
	[Address(RVA = "0x27ACA0", Offset = "0x279CA0", VA = "0x18027ACA0")]
	public static void vz(Exception e)
	{
		Debug.LogError(e);
	}

	[Token(Token = "0x60000A4")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public o()
	{
	}
}
