using Cpp2IlInjected;

[Token(Token = "0x2000127")]
public class le
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001204")]
	public short mck;

	[FieldOffset(Offset = "0x12")]
	[Token(Token = "0x4001205")]
	public short mcl;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4001206")]
	public short mcm;

	[FieldOffset(Offset = "0x16")]
	[Token(Token = "0x4001207")]
	public short mcn;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001208")]
	public short mco;

	[FieldOffset(Offset = "0x1A")]
	[Token(Token = "0x4001209")]
	public short mcp;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x400120A")]
	public bool mcq;

	[Token(Token = "0x6000836")]
	[Address(RVA = "0x200080", Offset = "0x1FF080", VA = "0x180200080")]
	public le(short minX, short minY, short maxX, short maxY)
	{
		mck = minX;
		mcm = maxX;
		mcn = 0;
		mcl = minY;
	}

	[Token(Token = "0x6000837")]
	[Address(RVA = "0x200010", Offset = "0x1FF010", VA = "0x180200010")]
	public le(short minX, short minY, short maxX, short maxY, short idMapFrom, short idMapTo)
	{
		mcn = 0;
		mco = 0;
		mck = minX;
		mcm = maxX;
		mcp = 0;
		mcl = minY;
	}
}
