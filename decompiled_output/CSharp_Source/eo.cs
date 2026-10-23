using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000074")]
public class eo : fi
{
	[Token(Token = "0x4000475")]
	private static eo haf;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000476")]
	private short hag = 190;

	[FieldOffset(Offset = "0x5A")]
	[Token(Token = "0x4000477")]
	private short hah;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000478")]
	private short hai;

	[FieldOffset(Offset = "0x5E")]
	[Token(Token = "0x4000479")]
	private short haj;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400047A")]
	private short hak;

	[Token(Token = "0x400047B")]
	public static bool hal;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400047C")]
	private GameObject ham;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400047D")]
	private GameObject han;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400047E")]
	private GameObject hao;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400047F")]
	private GameObject hap;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000480")]
	private GameObject haq;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000481")]
	private sbyte har;

	[FieldOffset(Offset = "0x91")]
	[Token(Token = "0x4000482")]
	private sbyte has;

	[FieldOffset(Offset = "0x92")]
	[Token(Token = "0x4000483")]
	private sbyte hat;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000484")]
	private ScrollRect hau;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000485")]
	private bool hav;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000486")]
	private hm haw;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000487")]
	private hm hax;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000488")]
	private GameObject hay;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000489")]
	private int haz;

	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x400048A")]
	private short hba;

	[FieldOffset(Offset = "0xC6")]
	[Token(Token = "0x400048B")]
	private sbyte hbb;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400048C")]
	private GameObject hbc;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400048D")]
	private GameObject[] hbd;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x400048E")]
	private GameObject hbe;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x400048F")]
	private kp hbf;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000490")]
	private GameObject hbg;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000491")]
	private GameObject hbh;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000492")]
	private GameObject hbi;

	[Token(Token = "0x6000363")]
	[Address(RVA = "0x46A2E0", Offset = "0x4692E0", VA = "0x18046A2E0")]
	public static eo bkp()
	{
		//IL_001d: Expected I4, but got I8
		eo eo2 = haf;
		if (eo2 == null)
		{
			eo eo3 = new eo();
			eo3.hag = 190;
			haf = eo3;
		}
		return eo2;
	}

	[Token(Token = "0x6000364")]
	[Address(RVA = "0x46D120", Offset = "0x46C120", VA = "0x18046D120")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000365")]
	[Address(RVA = "0x46E390", Offset = "0x46D390", VA = "0x18046E390")]
	public void updateList()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000366")]
	[Address(RVA = "0x469E00", Offset = "0x468E00", VA = "0x180469E00", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000367")]
	[Address(RVA = "0x46A390", Offset = "0x469390", VA = "0x18046A390")]
	private void bkq(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000368")]
	[Address(RVA = "0x46A5B0", Offset = "0x4695B0", VA = "0x18046A5B0")]
	private void bkr()
	{
		//IL_0053: Expected F4, but got I4
		//IL_0053: Expected F4, but got I4
		Object.Destroy(hbg);
		kp kp2 = hbf;
		if (kp2 != null)
		{
			short lwc = kp2.lwc;
			js js2 = mc.dcm(lwc);
			kj kj2 = kc.ckb(lwc);
			Transform transform = hay.transform;
			Sprite lsa = kj2.lsa;
			int num = 0;
			int num2 = 0;
			(hbg = ho.byo(transform, num2, num, lsa)).name = "objIconItemQuyenTruc";
		}
	}

	[Token(Token = "0x6000369")]
	[Address(RVA = "0x46A740", Offset = "0x469740", VA = "0x18046A740")]
	private void bks()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600036A")]
	[Address(RVA = "0x46AC70", Offset = "0x469C70", VA = "0x18046AC70")]
	private void bkt(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600036B")]
	[Address(RVA = "0x46CE70", Offset = "0x46BE70", VA = "0x18046CE70")]
	private void clickCheck(sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600036C")]
	[Address(RVA = "0x46ADE0", Offset = "0x469DE0", VA = "0x18046ADE0")]
	private void bku()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600036D")]
	[Address(RVA = "0x46BFD0", Offset = "0x46AFD0", VA = "0x18046BFD0")]
	private bool bkv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600036E")]
	[Address(RVA = "0x46C310", Offset = "0x46B310", VA = "0x18046C310")]
	public void bkw(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600036F")]
	[Address(RVA = "0x46D0A0", Offset = "0x46C0A0", VA = "0x18046D0A0", Slot = "9")]
	public override void close()
	{
		Object.Destroy(hlf);
		Object.Destroy(hbc);
		base.close();
	}

	[Token(Token = "0x6000370")]
	[Address(RVA = "0x469DA0", Offset = "0x468DA0", VA = "0x180469DA0")]
	public eo()
	{
		//IL_000d: Expected I4, but got I8
	}
}
