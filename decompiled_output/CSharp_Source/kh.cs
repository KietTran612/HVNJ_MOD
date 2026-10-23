using Cpp2IlInjected;

[Token(Token = "0x200010D")]
public class kh
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40010E4")]
	public int lrf;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x40010E5")]
	public int lrg;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40010E6")]
	public int lrh;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x40010E7")]
	public int lri;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40010E8")]
	public int lrj;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x40010E9")]
	public int lrk;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40010EA")]
	public int lrl;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40010EB")]
	public lm lrm;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40010EC")]
	private int[] lrn;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40010ED")]
	private int[] lro;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40010EE")]
	private int[] lrp;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40010EF")]
	private hl[] lrq;

	[Token(Token = "0x60007DB")]
	[Address(RVA = "0x1EEB50", Offset = "0x1EDB50", VA = "0x1801EEB50")]
	public kh(int x, int y, lm c)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007DC")]
	[Address(RVA = "0x1EEC20", Offset = "0x1EDC20", VA = "0x1801EEC20")]
	public kh(int cx, int cy)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007DD")]
	[Address(RVA = "0x1EEDF0", Offset = "0x1EDDF0", VA = "0x1801EEDF0")]
	public void ckn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007DE")]
	[Address(RVA = "0x1EF460", Offset = "0x1EE460", VA = "0x1801EF460")]
	public void cko()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007DF")]
	[Address(RVA = "0x1EF8C0", Offset = "0x1EE8C0", VA = "0x1801EF8C0")]
	public void close()
	{
		hl[] array = lrq;
		if (array != null)
		{
			int num = 0;
			if (num < array.Length)
			{
				hl.bxi(array[num]);
				hl[] array2 = lrq;
				num++;
			}
		}
	}
}
