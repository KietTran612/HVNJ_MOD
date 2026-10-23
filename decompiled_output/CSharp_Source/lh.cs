using Cpp2IlInjected;

[Token(Token = "0x200012A")]
public class lh
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001217")]
	public int mdd;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001218")]
	public string mde;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001219")]
	public lm mdf;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400121A")]
	public string[] mdg;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400121B")]
	public sbyte[] mdh;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400121C")]
	public iq mdi;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400121D")]
	public jr mdj;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400121E")]
	public Skill mdk;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400121F")]
	public kk mdl;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001220")]
	public ko mdm;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001221")]
	public jk mdn;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001222")]
	public jr[] mdo;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001223")]
	public lh[] mdp;

	[Token(Token = "0x600084A")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public lh()
	{
	}

	[Token(Token = "0x600084B")]
	[Address(RVA = "0x200C40", Offset = "0x1FFC40", VA = "0x180200C40")]
	public lh(ko i)
	{
		mdm = i;
	}

	[Token(Token = "0x600084C")]
	[Address(RVA = "0x200B80", Offset = "0x1FFB80", VA = "0x180200B80")]
	public lh(kk i)
	{
		mdl = i;
	}

	[Token(Token = "0x600084D")]
	[Address(RVA = "0x200D10", Offset = "0x1FFD10", VA = "0x180200D10")]
	public lh(jk i)
	{
		mdn = i;
	}

	[Token(Token = "0x600084E")]
	[Address(RVA = "0x200DA0", Offset = "0x1FFDA0", VA = "0x180200DA0")]
	public lh(lh[] i)
	{
		mdp = i;
	}

	[Token(Token = "0x600084F")]
	[Address(RVA = "0x200BB0", Offset = "0x1FFBB0", VA = "0x180200BB0")]
	public lh(jr[] i)
	{
		mdo = i;
	}

	[Token(Token = "0x6000850")]
	[Address(RVA = "0x200BE0", Offset = "0x1FFBE0", VA = "0x180200BE0")]
	public lh(jr i)
	{
		mdj = i;
	}

	[Token(Token = "0x6000851")]
	[Address(RVA = "0x200D40", Offset = "0x1FFD40", VA = "0x180200D40")]
	public lh(iq i)
	{
		mdi = i;
	}

	[Token(Token = "0x6000852")]
	[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
	public lh(int i)
	{
		mdd = i;
	}

	[Token(Token = "0x6000853")]
	[Address(RVA = "0x200C10", Offset = "0x1FFC10", VA = "0x180200C10")]
	public lh(string i)
	{
		mde = i;
	}

	[Token(Token = "0x6000854")]
	[Address(RVA = "0x200CA0", Offset = "0x1FFCA0", VA = "0x180200CA0")]
	public lh(lm i)
	{
		mdf = i;
	}

	[Token(Token = "0x6000855")]
	[Address(RVA = "0x200C70", Offset = "0x1FFC70", VA = "0x180200C70")]
	public lh(string[] i)
	{
		mdg = i;
	}

	[Token(Token = "0x6000856")]
	[Address(RVA = "0x200CD0", Offset = "0x1FFCD0", VA = "0x180200CD0")]
	public lh(string[] i, sbyte[] subIcon)
	{
		mdg = i;
		mdh = subIcon;
	}
}
