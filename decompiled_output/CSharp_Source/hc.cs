using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000B9")]
public class hc : fi
{
	[Token(Token = "0x20000BA")]
	private class hb : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000838")]
		private hc ikf;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000839")]
		private sbyte ikg;

		[FieldOffset(Offset = "0x19")]
		[Token(Token = "0x400083A")]
		private sbyte ikh;

		[Token(Token = "0x6000570")]
		[Address(RVA = "0x277820", Offset = "0x276820", VA = "0x180277820")]
		public hb(hc me, sbyte t, sbyte index)
		{
			ikf = me;
			ikg = t;
			ikh = index;
		}

		[Token(Token = "0x6000571")]
		[Address(RVA = "0x2792F0", Offset = "0x2782F0", VA = "0x1802792F0", Slot = "4")]
		public void th()
		{
			hc hc2 = ikf;
			sbyte index = ikh;
			sbyte b = ikg;
			hc2.buq(b, index);
		}
	}

	[Token(Token = "0x400081E")]
	private static hc iki;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400081F")]
	private int ikj = 200;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000820")]
	private int ikk = 220;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000821")]
	private int ikl;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000822")]
	private int ikm;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000823")]
	private ScrollRect ikn;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000824")]
	private ScrollRect iko;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000825")]
	private hm ikp;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000826")]
	private RectTransform ikq;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000827")]
	private sbyte ikr;

	[FieldOffset(Offset = "0x89")]
	[Token(Token = "0x4000828")]
	private sbyte iks;

	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4000829")]
	public int ikt;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400082A")]
	public int iku;

	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x400082B")]
	public int ikv;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x400082C")]
	public int ikw;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x400082D")]
	private hm ikx;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x400082E")]
	private hm iky;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x400082F")]
	public int[] ikz;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000830")]
	public int[] ila;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000831")]
	public io[] ilb;

	[Token(Token = "0x4000832")]
	public static bool ilc;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000833")]
	public short ild;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000834")]
	private Image[] ile;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000835")]
	public short ilf;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000836")]
	private Sprite[] ilg;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000837")]
	private ImageClickButton[] ilh;

	[Token(Token = "0x6000566")]
	[Address(RVA = "0x290CF0", Offset = "0x28FCF0", VA = "0x180290CF0")]
	public static hc bup()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		hc hc2 = new hc();
		hc2.ikj = 200;
		hc2.ikk = 220;
		iki = hc2;
		return hc2;
	}

	[Token(Token = "0x6000567")]
	[Address(RVA = "0x291D40", Offset = "0x290D40", VA = "0x180291D40")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000568")]
	[Address(RVA = "0x290C60", Offset = "0x28FC60", VA = "0x180290C60", Slot = "8")]
	public override void bcf()
	{
		//IL_0021: Expected Obj, but got I8
		int num = 0;
		mo.ddt().deq();
		close();
		int num2 = 0;
		mo.ddt().odd = (iw)0;
	}

	[Token(Token = "0x6000569")]
	[Address(RVA = "0x290E20", Offset = "0x28FE20", VA = "0x180290E20")]
	private void buq(sbyte t, sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600056A")]
	[Address(RVA = "0x290980", Offset = "0x28F980", VA = "0x180290980", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600056B")]
	[Address(RVA = "0x2914C0", Offset = "0x2904C0", VA = "0x1802914C0")]
	public void bur(bc message)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600056C")]
	[Address(RVA = "0x2919E0", Offset = "0x2909E0", VA = "0x1802919E0")]
	public void bus(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600056D")]
	[Address(RVA = "0x291C80", Offset = "0x290C80", VA = "0x180291C80", Slot = "9")]
	public override void close()
	{
		//IL_0009: Expected Obj, but got I8
		ikq = (RectTransform)0;
		int num = 0;
		mo.ddt().deq();
		Object.Destroy(hlf);
		base.close();
	}

	[Token(Token = "0x600056E")]
	[Address(RVA = "0x290920", Offset = "0x28F920", VA = "0x180290920")]
	public hc()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}

	[Token(Token = "0x600056F")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static hc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
