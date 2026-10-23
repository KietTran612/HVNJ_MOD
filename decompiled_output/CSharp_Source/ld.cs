using System.Collections.Generic;
using Cpp2IlInjected;

[Token(Token = "0x2000126")]
public class ld
{
	[Token(Token = "0x40011FD")]
	public static int mcd;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40011FE")]
	public int mce;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x40011FF")]
	public int mcf;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001200")]
	public int mcg;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001201")]
	public short[] mch = new short[2];

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001202")]
	public short[] mci = new short[2];

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001203")]
	public List<lf>[] mcj = new List<lf>[2];

	[Token(Token = "0x6000835")]
	[Address(RVA = "0x1FFF90", Offset = "0x1FEF90", VA = "0x1801FFF90")]
	public ld()
	{
	}
}
