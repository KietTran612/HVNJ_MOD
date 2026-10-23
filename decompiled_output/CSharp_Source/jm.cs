using Cpp2IlInjected;

[Token(Token = "0x20000F9")]
public class jm
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000F32")]
	public sbyte lak;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4000F33")]
	public int lal;

	[Token(Token = "0x6000752")]
	[Address(RVA = "0x279320", Offset = "0x278320", VA = "0x180279320")]
	public jm(sbyte t, int time)
	{
		lak = t;
		lal = time;
	}
}
