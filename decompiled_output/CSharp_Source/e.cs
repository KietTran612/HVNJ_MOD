using System;
using Cpp2IlInjected;

[Token(Token = "0x200000A")]
public class e
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000025")]
	public q fkk;

	[Token(Token = "0x4000026")]
	private const int fkl = 5;

	[Token(Token = "0x4000027")]
	private const int fkm = 500;

	[Token(Token = "0x4000028")]
	public static e fkn;

	[Token(Token = "0x4000029")]
	private static int fko;

	[Token(Token = "0x400002A")]
	private static string fkp;

	[Token(Token = "0x6000036")]
	[Address(RVA = "0x7D4E10", Offset = "0x7D3E10", VA = "0x1807D4E10")]
	public e(string filename)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000037")]
	[Address(RVA = "0x7D4F70", Offset = "0x7D3F70", VA = "0x1807D4F70")]
	public static void sh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000038")]
	[Address(RVA = "0x7D4FF0", Offset = "0x7D3FF0", VA = "0x1807D4FF0")]
	public static e si(string filename)
	{
		return sk(filename);
	}

	[Token(Token = "0x6000039")]
	[Address(RVA = "0x7D5000", Offset = "0x7D4000", VA = "0x1807D5000")]
	private static e sj(string filename)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600003A")]
	[Address(RVA = "0x7D51D0", Offset = "0x7D41D0", VA = "0x1807D51D0")]
	private static e sk(string filename)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600003B")]
	[Address(RVA = "0x7D4DA0", Offset = "0x7D3DA0", VA = "0x1807D4DA0")]
	public e(sbyte[] data)
	{
		q q2 = new q(data);
		fkk = q2;
	}

	[Token(Token = "0x600003C")]
	[Address(RVA = "0x7D5350", Offset = "0x7D4350", VA = "0x1807D5350")]
	public short sl()
	{
		return fkk.wg();
	}

	[Token(Token = "0x600003D")]
	[Address(RVA = "0x7D5370", Offset = "0x7D4370", VA = "0x1807D5370")]
	public int sm()
	{
		return fkk.wi();
	}

	[Token(Token = "0x600003E")]
	[Address(RVA = "0x7D5390", Offset = "0x7D4390", VA = "0x1807D5390")]
	public int sn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600003F")]
	[Address(RVA = "0x7D53C0", Offset = "0x7D43C0", VA = "0x1807D53C0")]
	public void so(ref sbyte[] data)
	{
		int num = fkk.wq(ref data);
	}

	[Token(Token = "0x6000040")]
	[Address(RVA = "0x618250", Offset = "0x617250", VA = "0x180618250")]
	public void close()
	{
		fkk.Close();
	}

	[Token(Token = "0x6000041")]
	[Address(RVA = "0x618250", Offset = "0x617250", VA = "0x180618250")]
	public void Close()
	{
		fkk.Close();
	}

	[Token(Token = "0x6000042")]
	[Address(RVA = "0x7D53E0", Offset = "0x7D43E0", VA = "0x1807D53E0")]
	public string sq()
	{
		return fkk.wo();
	}

	[Token(Token = "0x6000043")]
	[Address(RVA = "0x7D5400", Offset = "0x7D4400", VA = "0x1807D5400")]
	public sbyte sr()
	{
		return fkk.wb();
	}

	[Token(Token = "0x6000044")]
	[Address(RVA = "0x7D5420", Offset = "0x7D4420", VA = "0x1807D5420")]
	public long st()
	{
		return fkk.wj();
	}

	[Token(Token = "0x6000045")]
	[Address(RVA = "0x7D5440", Offset = "0x7D4440", VA = "0x1807D5440")]
	public bool su()
	{
		return fkk.wk();
	}

	[Token(Token = "0x6000046")]
	[Address(RVA = "0x7D5460", Offset = "0x7D4460", VA = "0x1807D5460")]
	public int sv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000047")]
	[Address(RVA = "0x7D5490", Offset = "0x7D4490", VA = "0x1807D5490")]
	public int sw()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000048")]
	[Address(RVA = "0x7D53C0", Offset = "0x7D43C0", VA = "0x1807D53C0")]
	public void sx(ref sbyte[] data)
	{
		int num = fkk.wq(ref data);
	}

	[Token(Token = "0x6000049")]
	[Address(RVA = "0x7D54C0", Offset = "0x7D44C0", VA = "0x1807D54C0")]
	public int sy()
	{
		return fkk.ws();
	}

	[Token(Token = "0x600004A")]
	[Address(RVA = "0x7D54E0", Offset = "0x7D44E0", VA = "0x1807D54E0")]
	internal void sz(ref sbyte[] byteData, int p, int size)
	{
		NotImplementedException ex = new NotImplementedException();
		/*Error: End of method reached without returning.*/;
	}
}
