using Cpp2IlInjected;

[Token(Token = "0x2000101")]
public class ju : lg
{
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000FD1")]
	public float lgp;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000FD2")]
	public float lgq;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000FD3")]
	public float lgr;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4000FD4")]
	public float lgs;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000FD5")]
	public float lgt;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000FD6")]
	public float lgu;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000FD7")]
	public int lgv;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000FD8")]
	public js lgw;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000FD9")]
	public sbyte lgx;

	[FieldOffset(Offset = "0x59")]
	[Token(Token = "0x4000FDA")]
	public sbyte lgy;

	[FieldOffset(Offset = "0x5A")]
	[Token(Token = "0x4000FDB")]
	public bool lgz;

	[FieldOffset(Offset = "0x5B")]
	[Token(Token = "0x4000FDC")]
	public bool lha;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000FDD")]
	public bool lhb;

	[Token(Token = "0x4000FDE")]
	public static hl lhc;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000FDF")]
	private hl lhd;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000FE0")]
	private hl lhe;

	[Token(Token = "0x6000791")]
	[Address(RVA = "0x4EC3C0", Offset = "0x4EB3C0", VA = "0x1804EC3C0")]
	public ju()
	{
		//IL_0016: Expected I4, but got I8
		lhb = true;
		base._002Ector();
		mcz = 2;
	}

	[Token(Token = "0x6000792")]
	[Address(RVA = "0x4EC2E0", Offset = "0x4EB2E0", VA = "0x1804EC2E0")]
	public ju(short itemMapID, short itemTemplateID, float x, float y, float xEnd, float yEnd)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000793")]
	[Address(RVA = "0x4EC3E0", Offset = "0x4EB3E0", VA = "0x1804EC3E0")]
	public ju(short itemMapID, short itemTemplateID, int x, int y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000794")]
	[Address(RVA = "0x4EC4A0", Offset = "0x4EB4A0", VA = "0x1804EC4A0")]
	public void ciq(float xEnd, float yEnd)
	{
		//IL_0017: Expected I4, but got I8
		lgp = xEnd;
		lgq = yEnd;
		lgx = 2;
		float num = xEnd * 0.25f;
		float num2 = yEnd * 0.25f;
		lgt = num;
		lgu = num2;
	}

	[Token(Token = "0x6000795")]
	[Address(RVA = "0x4EC4E0", Offset = "0x4EB4E0", VA = "0x1804EC4E0")]
	public void cir()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000796")]
	[Address(RVA = "0x4EC9F0", Offset = "0x4EB9F0", VA = "0x1804EC9F0")]
	public void cis()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000797")]
	[Address(RVA = "0x4ED1B0", Offset = "0x4EC1B0", VA = "0x1804ED1B0", Slot = "4")]
	public override float cit()
	{
		return lgr;
	}

	[Token(Token = "0x6000798")]
	[Address(RVA = "0x442C90", Offset = "0x441C90", VA = "0x180442C90", Slot = "5")]
	public override float ciu()
	{
		return lgs;
	}

	[Token(Token = "0x6000799")]
	[Address(RVA = "0x4ED1C0", Offset = "0x4EC1C0", VA = "0x1804ED1C0")]
	public void close()
	{
		//IL_0021: Expected Obj, but got I8
		//IL_0030: Expected Obj, but got I8
		hl hl2 = lhd;
		if (hl2 != null)
		{
			hl2.close();
			hl hl3 = lhe;
			lhd = (hl)0;
			hl3.close();
			lhe = (hl)0;
		}
	}
}
