using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000097")]
public class fv : fi
{
	[Token(Token = "0x400069A")]
	private static fv hvh;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400069B")]
	private int hvi = 200;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400069C")]
	private int hvj = 200;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400069D")]
	private int hvk;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400069E")]
	private int hvl;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400069F")]
	private ScrollRect hvm;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40006A0")]
	private GameObject hvn;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40006A1")]
	private hm hvo;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40006A2")]
	private GameObject hvp;

	[Token(Token = "0x600047A")]
	[Address(RVA = "0x504930", Offset = "0x503930", VA = "0x180504930")]
	public static fv bqa()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		fv fv2 = hvh;
		if (fv2 == null)
		{
			fv fv3 = new fv();
			fv3.hvi = 200;
			fv3.hvj = 200;
			hvh = fv3;
		}
		return fv2;
	}

	[Token(Token = "0x600047B")]
	[Address(RVA = "0x504A70", Offset = "0x503A70", VA = "0x180504A70")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600047C")]
	[Address(RVA = "0x5048B0", Offset = "0x5038B0", VA = "0x1805048B0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600047D")]
	[Address(RVA = "0x5046E0", Offset = "0x5036E0", VA = "0x1805046E0", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600047E")]
	[Address(RVA = "0x5049F0", Offset = "0x5039F0", VA = "0x1805049F0", Slot = "9")]
	public override void close()
	{
		base.close();
		Object.Destroy(hlf);
		Object.Destroy(hvp);
	}

	[Token(Token = "0x600047F")]
	[Address(RVA = "0x504680", Offset = "0x503680", VA = "0x180504680")]
	public fv()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
