using Cpp2IlInjected;

[Token(Token = "0x2000137")]
public class lv
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40013F9")]
	public int mvu;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x40013FA")]
	public int mvv;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40013FB")]
	public int mvw;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x40013FC")]
	public sbyte mvx;

	[Token(Token = "0x40013FD")]
	public const sbyte mvy = 2;

	[Token(Token = "0x40013FE")]
	public const sbyte mvz = 0;

	[Token(Token = "0x40013FF")]
	public const sbyte mwa = 1;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001400")]
	public int mwb;

	[Token(Token = "0x4001401")]
	public static mt mwc;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001402")]
	public bool mwd;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001403")]
	private hl mwe;

	[Token(Token = "0x6000A15")]
	[Address(RVA = "0x3CEAD0", Offset = "0x3CDAD0", VA = "0x1803CEAD0")]
	public bool daf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A16")]
	[Address(RVA = "0x3CEA80", Offset = "0x3CDA80", VA = "0x1803CEA80")]
	public lv(int x, int y)
	{
		//IL_001d: Expected I4, but got I8
		mvu = x;
		mvv = y;
		mvx = 0;
	}

	[Token(Token = "0x6000A17")]
	[Address(RVA = "0x3CECE0", Offset = "0x3CDCE0", VA = "0x1803CECE0")]
	public void dag()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A18")]
	[Address(RVA = "0x3CEF30", Offset = "0x3CDF30", VA = "0x1803CEF30")]
	public void dah()
	{
		bool flag = daf();
		hl hl2 = mwe;
		if (flag)
		{
			hl.bxi(hl2);
			return;
		}
		int isA = 0;
		hl2.bwy((byte)isA != 0);
	}

	[Token(Token = "0x6000A19")]
	[Address(RVA = "0x3CEAC0", Offset = "0x3CDAC0", VA = "0x1803CEAC0")]
	public void close()
	{
		hl.bxi(mwe);
	}
}
