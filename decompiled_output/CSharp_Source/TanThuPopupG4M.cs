using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000095")]
public class TanThuPopupG4M : fi
{
	[Token(Token = "0x2000096")]
	private class fu : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000698")]
		private TanThuPopupG4M hun;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000699")]
		private sbyte huo;

		[Token(Token = "0x6000478")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public fu(TanThuPopupG4M me, sbyte index)
		{
			hun = me;
			huo = index;
		}

		[Token(Token = "0x6000479")]
		[Address(RVA = "0x278C40", Offset = "0x277C40", VA = "0x180278C40", Slot = "4")]
		public void th()
		{
			TanThuPopupG4M tanThuPopupG4M = hun;
			sbyte index = huo;
			tanThuPopupG4M.clickTab(index);
		}
	}

	[Token(Token = "0x4000686")]
	private static TanThuPopupG4M hup;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000687")]
	private GameObject huq;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000688")]
	private GameObject hur;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000689")]
	private GameObject hus;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400068A")]
	private GameObject hut;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400068B")]
	private float huu = 262f;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x400068C")]
	private float huv = 200f;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400068D")]
	private float huw = 200f;

	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x400068E")]
	private float hux = 170f;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400068F")]
	private float huy;

	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4000690")]
	private float huz;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000691")]
	private float hva;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000692")]
	private RectTransform hvb;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000693")]
	private RectTransform hvc;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000694")]
	private hm hvd;

	[Token(Token = "0x4000695")]
	public static List<ky> hve;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000696")]
	private GameObject hvf;

	[Token(Token = "0x4000697")]
	public static bool hvg;

	[Token(Token = "0x600046F")]
	[Address(RVA = "0x48F920", Offset = "0x48E920", VA = "0x18048F920")]
	public static TanThuPopupG4M bpx()
	{
		TanThuPopupG4M tanThuPopupG4M = new TanThuPopupG4M();
		tanThuPopupG4M.huu = 262f;
		tanThuPopupG4M.huv = 200f;
		tanThuPopupG4M.huw = 200f;
		tanThuPopupG4M.hux = 170f;
		hup = tanThuPopupG4M;
		return tanThuPopupG4M;
	}

	[Token(Token = "0x6000470")]
	[Address(RVA = "0x490550", Offset = "0x48F550", VA = "0x180490550")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000471")]
	[Address(RVA = "0x48FA60", Offset = "0x48EA60", VA = "0x18048FA60")]
	public void bpy(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000472")]
	[Address(RVA = "0x48FF50", Offset = "0x48EF50", VA = "0x18048FF50")]
	public void clickTab(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000473")]
	[Address(RVA = "0x48F6C0", Offset = "0x48E6C0", VA = "0x18048F6C0", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000474")]
	[Address(RVA = "0x48FCB0", Offset = "0x48ECB0", VA = "0x18048FCB0")]
	public void bpz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000475")]
	[Address(RVA = "0x4904E0", Offset = "0x48F4E0", VA = "0x1804904E0", Slot = "9")]
	public override void close()
	{
		Object.Destroy(hur);
		base.close();
	}

	[Token(Token = "0x6000476")]
	[Address(RVA = "0x48F640", Offset = "0x48E640", VA = "0x18048F640")]
	public TanThuPopupG4M()
	{
	}

	[Token(Token = "0x6000477")]
	[Address(RVA = "0x48F5B0", Offset = "0x48E5B0", VA = "0x18048F5B0")]
	static TanThuPopupG4M()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
