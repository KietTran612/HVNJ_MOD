using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200004A")]
public class da : fi
{
	[Token(Token = "0x200004B")]
	private class cu : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40002BF")]
		private da ghf;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40002C0")]
		private sbyte ghg;

		[Token(Token = "0x6000254")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public cu(da me, sbyte t)
		{
			ghf = me;
			ghg = t;
		}

		[Token(Token = "0x6000255")]
		[Address(RVA = "0x278070", Offset = "0x277070", VA = "0x180278070", Slot = "4")]
		public void th()
		{
			da da2 = ghf;
			sbyte b = ghg;
			da2.bex(b);
		}
	}

	[Token(Token = "0x200004C")]
	private class cv : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40002C1")]
		private da ghh;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40002C2")]
		private int ghi;

		[Token(Token = "0x6000256")]
		[Address(RVA = "0x277DC0", Offset = "0x276DC0", VA = "0x180277DC0")]
		public cv(da me, int index)
		{
			ghh = me;
			ghi = index;
		}

		[Token(Token = "0x6000257")]
		[Address(RVA = "0x2780A0", Offset = "0x2770A0", VA = "0x1802780A0", Slot = "4")]
		public void th()
		{
			da da2 = ghh;
			int index = ghi;
			da2.bfb(index);
		}
	}

	[Token(Token = "0x200004D")]
	private class cw : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40002C3")]
		private da ghj;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40002C4")]
		private int ghk;

		[Token(Token = "0x6000258")]
		[Address(RVA = "0x277DC0", Offset = "0x276DC0", VA = "0x180277DC0")]
		public cw(da me, int index)
		{
			((Array)this).Initialize();
			ghj = me;
			ghk = index;
		}

		[Token(Token = "0x6000259")]
		[Address(RVA = "0x2780D0", Offset = "0x2770D0", VA = "0x1802780D0", Slot = "4")]
		public void th()
		{
			da da2 = ghj;
			int index = ghk;
			da2.bfd(index);
		}
	}

	[Token(Token = "0x200004E")]
	private class cz : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40002C5")]
		private da ghl;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40002C6")]
		private int ghm;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40002C7")]
		private int ghn;

		[Token(Token = "0x600025A")]
		[Address(RVA = "0x278100", Offset = "0x277100", VA = "0x180278100")]
		public cz(da me, int type, int index)
		{
			ghl = me;
			ghm = type;
			ghn = index;
		}

		[Token(Token = "0x600025B")]
		[Address(RVA = "0x278150", Offset = "0x277150", VA = "0x180278150", Slot = "4")]
		public void th()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x4000287")]
	private static da gho;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000288")]
	private int ghp = 420;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000289")]
	private int ghq = 240;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400028A")]
	private int ghr;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400028B")]
	private int ghs;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400028C")]
	private float ght;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400028D")]
	private GameObject ghu;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400028E")]
	private int ghv;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x400028F")]
	private int ghw;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000290")]
	private int ghx = 180;

	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4000291")]
	private int ghy;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000292")]
	private int ghz;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000293")]
	private ScrollRect gia;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000294")]
	private hm gib;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000295")]
	private hm gic;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000296")]
	private GameObject gid;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000297")]
	private GameObject gie;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000298")]
	private GameObject gif;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000299")]
	private float gig;

	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x400029A")]
	private float gih;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400029B")]
	private float gii;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400029C")]
	private sbyte[] gij;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x400029D")]
	private List<jp> gik;

	[Token(Token = "0x400029E")]
	public static List<ke> gil;

	[Token(Token = "0x400029F")]
	public static bool gim;

	[Token(Token = "0x40002A0")]
	public static bool gin;

	[Token(Token = "0x40002A1")]
	public static bool gio;

	[Token(Token = "0x40002A2")]
	public static bool gip;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x40002A3")]
	public string[] giq;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x40002A4")]
	public string[] gir;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x40002A5")]
	private iw gis;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x40002A6")]
	private iw git;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40002A7")]
	private RectTransform giu;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40002A8")]
	private RectTransform giv;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40002A9")]
	private hm giw;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40002AA")]
	private Image gix;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40002AB")]
	private int giy;

	[FieldOffset(Offset = "0x124")]
	[Token(Token = "0x40002AC")]
	private int giz;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40002AD")]
	private GameObject gja;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40002AE")]
	private RectTransform gjb;

	[Token(Token = "0x40002AF")]
	public static int gjc;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40002B0")]
	private ScrollRect gjd;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40002B1")]
	private GameObject gje;

	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x40002B2")]
	private ScrollRect gjf;

	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40002B3")]
	private GameObject gjg;

	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40002B4")]
	private ScrollRect gjh;

	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x40002B5")]
	private GameObject gji;

	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40002B6")]
	private GameObject gjj;

	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40002B7")]
	private GameObject gjk;

	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40002B8")]
	private RectTransform gjl;

	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x40002B9")]
	private hm[] gjm;

	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x40002BA")]
	private ImageClickButton gjn;

	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x40002BB")]
	private Image[] gjo;

	[FieldOffset(Offset = "0x198")]
	[Token(Token = "0x40002BC")]
	private RectTransform[] gjp;

	[FieldOffset(Offset = "0x1A0")]
	[Token(Token = "0x40002BD")]
	private short[] gjq;

	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x40002BE")]
	private int gjr;

	[Token(Token = "0x6000233")]
	[Address(RVA = "0x5893F0", Offset = "0x5883F0", VA = "0x1805893F0")]
	public static da bew()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		//IL_002d: Expected I4, but got I8
		da da2 = new da();
		da2.ghp = 420;
		da2.ghq = 240;
		da2.ghx = 180;
		gho = da2;
		return da2;
	}

	[Token(Token = "0x6000234")]
	[Address(RVA = "0x592410", Offset = "0x591410", VA = "0x180592410")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000235")]
	[Address(RVA = "0x589520", Offset = "0x588520", VA = "0x180589520")]
	private void bex(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000236")]
	[Address(RVA = "0x589560", Offset = "0x588560", VA = "0x180589560")]
	public void bey()
	{
		//IL_0010: Expected Obj, but got I4
		GameObject gameObject = hlf;
		int num = 0;
		if (!(gameObject == (UnityEngine.Object)num))
		{
			bez();
		}
	}

	[Token(Token = "0x6000237")]
	[Address(RVA = "0x5895E0", Offset = "0x5885E0", VA = "0x1805895E0")]
	private void bez()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000238")]
	[Address(RVA = "0x589D30", Offset = "0x588D30", VA = "0x180589D30")]
	private void bfa(GameObject objCell, jr item, int dUpgrade, int dR, ImageClickButton click, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000239")]
	[Address(RVA = "0x589200", Offset = "0x588200", VA = "0x180589200", Slot = "6")]
	public override void bcd()
	{
		//IL_0037: Expected I4, but got I8
		//IL_0083: Expected I4, but got I8
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected I4, but got Unknown
		//IL_00d8: Expected F4, but got I4
		//IL_00d8: Expected F4, but got I4
		bfm();
		int num = 0;
		hw.ccx();
		int num2 = 0;
		hw.ccv();
		GameObject gameObject = gie;
		if ((long)gis == 0)
		{
			int active = 0;
			gameObject.SetActive((byte)active != 0);
		}
		ulong num3 = default;
		gameObject.SetActive((byte)num3 != 0);
		iw iw2 = gis;
		hm hm2 = gic;
		string kvh = iw2.kvh;
		hm2.bxn(kvh);
		GameObject gameObject2 = gid;
		if ((long)git == 0)
		{
			int active2 = 0;
			gameObject2.SetActive((byte)active2 != 0);
			return;
		}
		ulong num4 = default;
		gameObject2.SetActive((byte)num4 != 0);
		iw iw3 = git;
		hm hm3 = gib;
		string kvh2 = iw3.kvh;
		int num5 = 0;
		hm3.bxn(kvh2);
		while ((long)gis != 0)
		{
		}
		RectTransform rect = giu;
		int num6 = ghy;
		int num7 = 0;
		num6 -= kvh2;
		ho.byn(rect, num7, num5);
	}

	[Token(Token = "0x600023A")]
	[Address(RVA = "0x58A090", Offset = "0x589090", VA = "0x18058A090")]
	private void bfb(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600023B")]
	[Address(RVA = "0x58A4B0", Offset = "0x5894B0", VA = "0x18058A4B0")]
	private void bfc(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600023C")]
	[Address(RVA = "0x591C40", Offset = "0x590C40", VA = "0x180591C40")]
	private void createThongKe(bool isRefresh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600023D")]
	[Address(RVA = "0x590540", Offset = "0x58F540", VA = "0x180590540")]
	private void createThanhVien(bool isRefresh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600023E")]
	[Address(RVA = "0x58A950", Offset = "0x589950", VA = "0x18058A950")]
	private void bfd(int index)
	{
		mo.nsx = index;
		bfm();
		gis?.cgd();
	}

	[Token(Token = "0x600023F")]
	[Address(RVA = "0x58A9E0", Offset = "0x5899E0", VA = "0x18058A9E0")]
	public void bfe()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000240")]
	[Address(RVA = "0x58AB20", Offset = "0x589B20", VA = "0x18058AB20")]
	public void bff(string[] text)
	{
		//IL_0010: Expected Obj, but got I4
		GameObject gameObject = hlf;
		int num = 0;
		if (!(gameObject == (UnityEngine.Object)num))
		{
			bfg(isRefresh: true, text);
		}
	}

	[Token(Token = "0x6000241")]
	[Address(RVA = "0x58ABB0", Offset = "0x589BB0", VA = "0x18058ABB0")]
	public void bfg(bool isRefresh, string[] textNotClann)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000242")]
	[Address(RVA = "0x58D670", Offset = "0x58C670", VA = "0x18058D670")]
	public void bfh(sbyte type, int money)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000243")]
	[Address(RVA = "0x588360", Offset = "0x587360", VA = "0x180588360", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000244")]
	[Address(RVA = "0x58D9B0", Offset = "0x58C9B0", VA = "0x18058D9B0")]
	private void bfi()
	{
		int num = 0;
		lj.cmy().crj();
		int num2 = 0;
		hw.cdy();
	}

	[Token(Token = "0x6000245")]
	[Address(RVA = "0x58DA20", Offset = "0x58CA20", VA = "0x18058DA20")]
	private void bfj(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000246")]
	[Address(RVA = "0x58DCA0", Offset = "0x58CCA0", VA = "0x18058DCA0")]
	public void bfk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000247")]
	[Address(RVA = "0x58E210", Offset = "0x58D210", VA = "0x18058E210")]
	public ke bfl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000248")]
	[Address(RVA = "0x58E2F0", Offset = "0x58D2F0", VA = "0x18058E2F0")]
	public void bfm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000249")]
	[Address(RVA = "0x58EC30", Offset = "0x58DC30", VA = "0x18058EC30")]
	public void bfn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600024A")]
	[Address(RVA = "0x58EFE0", Offset = "0x58DFE0", VA = "0x18058EFE0")]
	public void bfo()
	{
		//IL_0036: Expected VT, but got Obj
		//IL_004d: Expected VT, but got Obj
		//IL_006d: Expected I4, but got I8
		//IL_006d: Expected I4, but got I8
		List<iw> list = (List<iw>)(object)new List<T>();
		string text = hd.irm[0];
		string imp = hd.imp;
		iw iw2 = new iw(text + ": " + imp, 140071);
		((List<T>)(object)list).Add((T)iw2);
		iw iw3 = new iw(hd.izc, this, 13);
		((List<T>)(object)list).Add((T)iw3);
		int num = 0;
		ms ms2 = ms.dkz();
		int num2 = 0;
		int num3 = 0;
		ulong num4 = default;
		ulong num5 = default;
		ms2.dla((List<>)(object)list, num3, (byte)num2 != 0, (byte)num4 != 0, (byte)num5 != 0);
	}

	[Token(Token = "0x600024B")]
	[Address(RVA = "0x58F280", Offset = "0x58E280", VA = "0x18058F280")]
	public void bfp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600024C")]
	[Address(RVA = "0x58FB50", Offset = "0x58EB50", VA = "0x18058FB50")]
	public void bfq(string mName)
	{
		//IL_0023: Expected VT, but got Obj
		//IL_0048: Expected VT, but got Obj
		//IL_005f: Expected VT, but got Obj
		//IL_0086: Expected VT, but got Obj
		//IL_00b3: Expected VT, but got Obj
		List<iw> list = (List<iw>)(object)new List<T>();
		iw iw2 = new iw(hd.irg[6], this, 26);
		int num = 0;
		((List<T>)(object)list).Add((T)iw2);
		string ink = hd.ink;
		lh p = new lh(mName);
		iw iw3 = new iw(ink, 12004, p);
		((List<T>)(object)list).Add((T)iw3);
		iw iw4 = new iw(hd.izf, this, 27);
		((List<T>)(object)list).Add((T)iw4);
		string ime = hd.ime;
		lh p2 = new lh(mName);
		iw iw5 = new iw(ime, 14020, p2);
		((List<T>)(object)list).Add((T)iw5);
		string caption = hd.irn[2];
		lh p3 = new lh(mName);
		iw iw6 = new iw(caption, 110803, p3);
		((List<T>)(object)list).Add((T)iw6);
		int num2 = 0;
		ms ms2 = ms.dkz();
		int num3 = 0;
		ms2.dla((List<>)(object)list, 3, (byte)num3 != 0, (byte)num != 0, (byte)num != 0);
	}

	[Token(Token = "0x600024D")]
	[Address(RVA = "0x58FEA0", Offset = "0x58EEA0", VA = "0x18058FEA0")]
	public void bfr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600024E")]
	[Address(RVA = "0x590080", Offset = "0x58F080", VA = "0x180590080")]
	public void bfs()
	{
		//IL_0032: Expected VT, but got Obj
		//IL_004e: Expected VT, but got Obj
		//IL_006a: Expected I4, but got I8
		//IL_006a: Expected I4, but got I8
		int size = ((List<>)(object)gil)._size;
		int num = 0;
		System.ThrowHelper.ThrowArgumentOutOfRangeException();
		List<iw> list = (List<iw>)(object)new List<T>();
		iw iw2 = new iw(hd.irk[1], this, 3);
		((List<T>)(object)list).Add((T)iw2);
		iw iw3 = new iw(hd.irk[2], this, 4);
		((List<T>)(object)list).Add((T)iw3);
		int num2 = 0;
		ms ms2 = ms.dkz();
		int num3 = 0;
		ulong num4 = default;
		ulong num5 = default;
		ms2.dla((List<>)(object)list, 3, (byte)num3 != 0, (byte)num4 != 0, (byte)num5 != 0);
	}

	[Token(Token = "0x600024F")]
	[Address(RVA = "0x590310", Offset = "0x58F310", VA = "0x180590310")]
	public void bft()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000250")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000251")]
	[Address(RVA = "0x590430", Offset = "0x58F430", VA = "0x180590430", Slot = "9")]
	public override void close()
	{
		//IL_0022: Expected Obj, but got I4
		//IL_0029: Expected Obj, but got I4
		//IL_0038: Expected Obj, but got I4
		//IL_003f: Expected Obj, but got I4
		//IL_0046: Expected Obj, but got I4
		//IL_0058: Expected Obj, but got I4
		int num = 0;
		mo.ddt().deq();
		base.close();
		GameObject obj = hlf;
		int num2 = 0;
		gik = (List<jp>)num2;
		gjm = (hm[])num2;
		UnityEngine.Object.Destroy(obj);
		int num3 = 0;
		hlf = (GameObject)num2;
		gjl = (RectTransform)num2;
		gij = (sbyte[])num2;
		mo mo2 = mo.ddt();
		int num4 = 0;
		mo2.odd = (iw)num2;
		mo.ddt().deq();
	}

	[Token(Token = "0x6000252")]
	[Address(RVA = "0x5882F0", Offset = "0x5872F0", VA = "0x1805882F0")]
	public da()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
		//IL_0027: Expected I4, but got I8
	}

	[Token(Token = "0x6000253")]
	[Address(RVA = "0x588230", Offset = "0x587230", VA = "0x180588230")]
	static da()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
