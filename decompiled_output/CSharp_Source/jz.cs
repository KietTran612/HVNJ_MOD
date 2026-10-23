using Cpp2IlInjected;

[Token(Token = "0x2000106")]
public class jz
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000FF8")]
	public int lic = 3;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4000FF9")]
	public float lid;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000FFA")]
	public float lie;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000FFB")]
	public float lif;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000FFC")]
	public bool lig;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000FFD")]
	private hl lih;

	[Token(Token = "0x60007A6")]
	[Address(RVA = "0x4F1550", Offset = "0x4F0550", VA = "0x1804F1550")]
	public jz(float x, float y)
	{
		//IL_0009: Expected I4, but got I8
		lid = x;
		lif = y;
		lie = y;
		lig = false;
	}

	[Token(Token = "0x60007A7")]
	[Address(RVA = "0x4F15A0", Offset = "0x4F05A0", VA = "0x1804F15A0")]
	public void cja()
	{
		float num = lie;
		float num2 = lif;
		lie = num;
		if (!(num2 <= 150f))
		{
			lig = true;
		}
	}

	[Token(Token = "0x60007A8")]
	[Address(RVA = "0x4F15D0", Offset = "0x4F05D0", VA = "0x1804F15D0")]
	public void cjb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007A9")]
	[Address(RVA = "0x3CEAC0", Offset = "0x3CDAC0", VA = "0x1803CEAC0")]
	public void close()
	{
		hl.bxi(lih);
	}
}
