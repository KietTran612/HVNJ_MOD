using Cpp2IlInjected;

[Token(Token = "0x2000165")]
public class ni : fi
{
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001785")]
	private float oeg;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001786")]
	private float oeh;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001787")]
	private float oei = 120f;

	[Token(Token = "0x4001788")]
	private static ni oej;

	[Token(Token = "0x6000C27")]
	[Address(RVA = "0x2D4090", Offset = "0x2D3090", VA = "0x1802D4090")]
	public static ni dnz()
	{
		ni ni2 = oej;
		if (ni2 == null)
		{
			ni ni3 = new ni();
			ni3.oei = 120f;
			oej = ni3;
		}
		return ni2;
	}

	[Token(Token = "0x6000C28")]
	[Address(RVA = "0x2D3F00", Offset = "0x2D2F00", VA = "0x1802D3F00")]
	public ni()
	{
	}

	[Token(Token = "0x6000C29")]
	[Address(RVA = "0x2D4140", Offset = "0x2D3140", VA = "0x1802D4140")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C2A")]
	[Address(RVA = "0x2D3F60", Offset = "0x2D2F60", VA = "0x1802D3F60", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C2B")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C2C")]
	[Address(RVA = "0x2D3FF0", Offset = "0x2D2FF0", VA = "0x1802D3FF0", Slot = "9")]
	public override void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
