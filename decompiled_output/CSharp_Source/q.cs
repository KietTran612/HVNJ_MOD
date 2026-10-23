using Cpp2IlInjected;

[Token(Token = "0x2000016")]
public class q
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x400008F")]
	public sbyte[] foj;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000090")]
	private int fok;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000091")]
	private int fol;

	[Token(Token = "0x4000092")]
	private static string fom;

	[Token(Token = "0x4000093")]
	private static int fon;

	[Token(Token = "0x60000A7")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public q()
	{
	}

	[Token(Token = "0x60000A8")]
	[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
	public q(sbyte[] data)
	{
		foj = data;
	}

	[Token(Token = "0x60000A9")]
	[Address(RVA = "0x27F140", Offset = "0x27E140", VA = "0x18027F140")]
	public q(string filename)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000AA")]
	[Address(RVA = "0x27F270", Offset = "0x27E270", VA = "0x18027F270")]
	public sbyte wa()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000AB")]
	[Address(RVA = "0x27F320", Offset = "0x27E320", VA = "0x18027F320")]
	public sbyte wb()
	{
		return wa();
	}

	[Token(Token = "0x60000AC")]
	[Address(RVA = "0x27F320", Offset = "0x27E320", VA = "0x18027F320")]
	public sbyte wc()
	{
		return wa();
	}

	[Token(Token = "0x60000AD")]
	[Address(RVA = "0x27F330", Offset = "0x27E330", VA = "0x18027F330")]
	public void wd(int readlimit)
	{
		int num = fok;
		fol = num;
	}

	[Token(Token = "0x60000AE")]
	[Address(RVA = "0x27F340", Offset = "0x27E340", VA = "0x18027F340")]
	public void we()
	{
		int num = fol;
		fok = num;
	}

	[Token(Token = "0x60000AF")]
	[Address(RVA = "0x27F350", Offset = "0x27E350", VA = "0x18027F350")]
	public byte wf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000B0")]
	[Address(RVA = "0x27F3B0", Offset = "0x27E3B0", VA = "0x18027F3B0")]
	public short wg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000B1")]
	[Address(RVA = "0x27F410", Offset = "0x27E410", VA = "0x18027F410")]
	public ushort wh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000B2")]
	[Address(RVA = "0x27F490", Offset = "0x27E490", VA = "0x18027F490")]
	public int wi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000B3")]
	[Address(RVA = "0x27F4F0", Offset = "0x27E4F0", VA = "0x18027F4F0")]
	public long wj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000B4")]
	[Address(RVA = "0x27F550", Offset = "0x27E550", VA = "0x18027F550")]
	public bool wk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000B5")]
	[Address(RVA = "0x27F550", Offset = "0x27E550", VA = "0x18027F550")]
	public bool wl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000B6")]
	[Address(RVA = "0x27F570", Offset = "0x27E570", VA = "0x18027F570")]
	public string wm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000B7")]
	[Address(RVA = "0x27F770", Offset = "0x27E770", VA = "0x18027F770")]
	public string wn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000B8")]
	[Address(RVA = "0x27F970", Offset = "0x27E970", VA = "0x18027F970")]
	public string wo()
	{
		return wn();
	}

	[Token(Token = "0x60000B9")]
	[Address(RVA = "0x27F980", Offset = "0x27E980", VA = "0x18027F980")]
	public int wp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000BA")]
	[Address(RVA = "0x27F9C0", Offset = "0x27E9C0", VA = "0x18027F9C0")]
	public int wq(ref sbyte[] data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000BB")]
	[Address(RVA = "0x27FA90", Offset = "0x27EA90", VA = "0x18027FA90")]
	public void wr(ref sbyte[] data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000BC")]
	[Address(RVA = "0x27FBD0", Offset = "0x27EBD0", VA = "0x18027FBD0")]
	public int ws()
	{
		return foj.Length;
	}

	[Token(Token = "0x60000BD")]
	[Address(RVA = "0x27FBF0", Offset = "0x27EBF0", VA = "0x18027FBF0")]
	public static byte wt(sbyte var)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000BE")]
	[Address(RVA = "0x27FC00", Offset = "0x27EC00", VA = "0x18027FC00")]
	public static byte[] wu(sbyte[] var)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000BF")]
	[Address(RVA = "0x27F130", Offset = "0x27E130", VA = "0x18027F130")]
	public void Close()
	{
		//IL_0009: Expected Obj, but got I8
		foj = (sbyte[])0;
	}

	[Token(Token = "0x60000C0")]
	[Address(RVA = "0x27F130", Offset = "0x27E130", VA = "0x18027F130")]
	public void close()
	{
		//IL_0009: Expected Obj, but got I8
		foj = (sbyte[])0;
	}

	[Token(Token = "0x60000C1")]
	[Address(RVA = "0x27FCB0", Offset = "0x27ECB0", VA = "0x18027FCB0")]
	public void wv(ref sbyte[] data, int arg1, int arg2)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000C2")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static q()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
