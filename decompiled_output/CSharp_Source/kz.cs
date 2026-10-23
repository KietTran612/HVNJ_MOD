using Cpp2IlInjected;

[Token(Token = "0x2000121")]
public class kz
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40011BD")]
	public int lzo;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x40011BE")]
	public int lzp;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40011BF")]
	public short[] lzq;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40011C0")]
	public short lzr;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40011C1")]
	public string[] lzs;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40011C2")]
	public string[] lzt;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40011C3")]
	public string[] lzu;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40011C4")]
	public short lzv;

	[Token(Token = "0x6000824")]
	[Address(RVA = "0x1F8770", Offset = "0x1F7770", VA = "0x1801F8770")]
	public kz(short taskId, sbyte index, string name, string detail, string[] subNames, short[] counts, short count)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
