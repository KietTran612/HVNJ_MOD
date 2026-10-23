using Cpp2IlInjected;

[Token(Token = "0x20000D8")]
public class ie
{
	[Token(Token = "0x4000C8F")]
	public static sbyte kak;

	[Token(Token = "0x4000C90")]
	public static sbyte kal;

	[Token(Token = "0x4000C91")]
	public static sbyte kam;

	[Token(Token = "0x4000C92")]
	public static sbyte kan;

	[Token(Token = "0x4000C93")]
	public static sbyte kao;

	[Token(Token = "0x4000C94")]
	public static sbyte kap;

	[Token(Token = "0x4000C95")]
	public static sbyte kaq;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000C96")]
	public sbyte[][] kar = new sbyte[2][];

	[Token(Token = "0x60006DD")]
	[Address(RVA = "0x36A6B0", Offset = "0x3696B0", VA = "0x18036A6B0")]
	public ie()
	{
	}

	[Token(Token = "0x60006DE")]
	[Address(RVA = "0x36A600", Offset = "0x369600", VA = "0x18036A600")]
	static ie()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
