using Cpp2IlInjected;

[Token(Token = "0x200010E")]
public class ki
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40010F0")]
	public int lrr;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x40010F1")]
	public int lrs;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40010F2")]
	public int lrt;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x40010F3")]
	public int lru;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40010F4")]
	public float lrv;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x40010F5")]
	public float lrw;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40010F6")]
	public float lrx;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x40010F7")]
	public float lry;

	[Token(Token = "0x60007E0")]
	[Address(RVA = "0x1EF940", Offset = "0x1EE940", VA = "0x1801EF940")]
	public ki(float xEnd, float yEnd, int act, int dir)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007E1")]
	[Address(RVA = "0x1EF990", Offset = "0x1EE990", VA = "0x1801EF990")]
	public ki(float xEnd, float yEnd)
	{
		lrv = xEnd;
		lrw = yEnd;
	}
}
