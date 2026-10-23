using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000083")]
public class fg : fi, k
{
	[Token(Token = "0x2000084")]
	private class fd : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400055A")]
		private fg hgj;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400055B")]
		private sbyte hgk;

		[Token(Token = "0x60003D4")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public fd(fg me, sbyte index)
		{
			hgj = me;
			hgk = index;
		}

		[Token(Token = "0x60003D5")]
		[Address(RVA = "0x278970", Offset = "0x277970", VA = "0x180278970", Slot = "4")]
		public void th()
		{
			fg fg2 = hgj;
			sbyte index = hgk;
			fg2.clickTab(index);
		}
	}

	[Token(Token = "0x2000085")]
	private class fe : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400055C")]
		private int hgl;

		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x400055D")]
		private sbyte hgm;

		[FieldOffset(Offset = "0x15")]
		[Token(Token = "0x400055E")]
		private sbyte hgn;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400055F")]
		private fg hgo;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000560")]
		private @if hgp;

		[Token(Token = "0x60003D6")]
		[Address(RVA = "0x2789A0", Offset = "0x2779A0", VA = "0x1802789A0")]
		public fe(fg me, @if p, sbyte mua, sbyte type, int ind)
		{
			hgl = 0;
			hgo = me;
			hgp = p;
			hgn = mua;
			hgm = 0;
		}

		[Token(Token = "0x60003D7")]
		[Address(RVA = "0x278A00", Offset = "0x277A00", VA = "0x180278A00", Slot = "4")]
		public void th()
		{
			fg fg2 = hgo;
			int index = hgl;
			sbyte type = hgm;
			sbyte mua = hgn;
			@if p = hgp;
			fg2.bmg(p, mua, type, index);
		}
	}

	[Token(Token = "0x2000086")]
	private class ff : i
	{
		[Token(Token = "0x4000561")]
		public const sbyte hgq = 1;

		[Token(Token = "0x4000562")]
		public const sbyte hgr = 2;

		[Token(Token = "0x4000563")]
		public const sbyte hgs = 3;

		[Token(Token = "0x4000564")]
		public const sbyte hgt = 4;

		[Token(Token = "0x4000565")]
		public const sbyte hgu = 5;

		[Token(Token = "0x4000566")]
		public const sbyte hgv = 10;

		[Token(Token = "0x4000567")]
		public const sbyte hgw = 11;

		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000568")]
		private fg hgx;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000569")]
		private sbyte hgy;

		[FieldOffset(Offset = "0x19")]
		[Token(Token = "0x400056A")]
		private sbyte hgz;

		[Token(Token = "0x60003D8")]
		[Address(RVA = "0x277EB0", Offset = "0x276EB0", VA = "0x180277EB0")]
		public ff(fg me, sbyte mua, sbyte t)
		{
			hgx = me;
			hgy = t;
			hgz = mua;
		}

		[Token(Token = "0x60003D9")]
		[Address(RVA = "0x278A40", Offset = "0x277A40", VA = "0x180278A40", Slot = "4")]
		public void th()
		{
			fg fg2 = hgx;
			sbyte b = hgy;
			sbyte mua = hgz;
			fg2.bmj(mua, b);
		}
	}

	[Token(Token = "0x4000515")]
	private static fg hha;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000516")]
	private int hhb;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000517")]
	private int hhc;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000518")]
	private int hhd;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000519")]
	private int hhe;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400051A")]
	private int hhf;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x400051B")]
	private int hhg;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400051C")]
	private int hhh;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x400051D")]
	private int hhi;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400051E")]
	private int hhj;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x400051F")]
	private int hhk;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000520")]
	private int hhl;

	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4000521")]
	private int hhm;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000522")]
	private ScrollRect hhn;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000523")]
	private ScrollRect hho;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000524")]
	private ScrollRect hhp;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000525")]
	private ScrollRect hhq;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000526")]
	private short hhr;

	[FieldOffset(Offset = "0xAA")]
	[Token(Token = "0x4000527")]
	private short hhs;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000528")]
	private hm[] hht;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000529")]
	private hm[] hhu;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x400052A")]
	private hm[] hhv;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400052B")]
	private hm[] hhw;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400052C")]
	private GameObject hhx;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x400052D")]
	private hm[][] hhy;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x400052E")]
	private GameObject[] hhz;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x400052F")]
	private GameObject[] hia;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000530")]
	private hm[] hib;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000531")]
	private hm[] hic;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4000532")]
	private hm[] hid;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4000533")]
	private Image[] hie;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4000534")]
	private sbyte hif;

	[FieldOffset(Offset = "0x111")]
	[Token(Token = "0x4000535")]
	private sbyte hig;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4000536")]
	private ImageClickButton[] hih;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4000537")]
	private ImageClickButton[] hii;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4000538")]
	private hm[] hij;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x4000539")]
	private GameObject[] hik;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x400053A")]
	private GameObject[] hil;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x400053B")]
	private float him;

	[FieldOffset(Offset = "0x144")]
	[Token(Token = "0x400053C")]
	private float hin;

	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x400053D")]
	private float hio;

	[FieldOffset(Offset = "0x14C")]
	[Token(Token = "0x400053E")]
	private float hip;

	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x400053F")]
	private float hiq;

	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x4000540")]
	private hm hir;

	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x4000541")]
	private hm his;

	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x4000542")]
	private hm hit;

	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x4000543")]
	private hm hiu;

	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x4000544")]
	private hm hiv;

	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x4000545")]
	private hm[] hiw;

	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x4000546")]
	private GameObject hix;

	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x4000547")]
	private GameObject hiy;

	[FieldOffset(Offset = "0x198")]
	[Token(Token = "0x4000548")]
	private GameObject hiz;

	[FieldOffset(Offset = "0x1A0")]
	[Token(Token = "0x4000549")]
	private GameObject hja;

	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x400054A")]
	private GameObject hjb;

	[FieldOffset(Offset = "0x1B0")]
	[Token(Token = "0x400054B")]
	private bool hjc;

	[FieldOffset(Offset = "0x1B8")]
	[Token(Token = "0x400054C")]
	private RectTransform hjd;

	[FieldOffset(Offset = "0x1C0")]
	[Token(Token = "0x400054D")]
	private hm hje;

	[FieldOffset(Offset = "0x1C8")]
	[Token(Token = "0x400054E")]
	private Image hjf;

	[FieldOffset(Offset = "0x1D0")]
	[Token(Token = "0x400054F")]
	private sbyte hjg;

	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x4000550")]
	private GameObject hjh;

	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x4000551")]
	private GameObject hji;

	[FieldOffset(Offset = "0x1E8")]
	[Token(Token = "0x4000552")]
	private GameObject hjj;

	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x4000553")]
	private GameObject hjk;

	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x4000554")]
	private GameObject[][] hjl;

	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x4000555")]
	private RectTransform[][] hjm;

	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x4000556")]
	private float[][] hjn;

	[FieldOffset(Offset = "0x210")]
	[Token(Token = "0x4000557")]
	private GameObject[][][] hjo;

	[FieldOffset(Offset = "0x218")]
	[Token(Token = "0x4000558")]
	private GameObject[][][] hjp;

	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x4000559")]
	private GameObject hjq;

	[Token(Token = "0x60003BE")]
	[Address(RVA = "0x6193A0", Offset = "0x6183A0", VA = "0x1806193A0")]
	public static fg bmb()
	{
		fg fg2 = hha;
		if (fg2 == null)
		{
			hha = new fg();
		}
		return fg2;
	}

	[Token(Token = "0x60003BF")]
	[Address(RVA = "0x622740", Offset = "0x621740", VA = "0x180622740")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C0")]
	[Address(RVA = "0x619450", Offset = "0x618450", VA = "0x180619450")]
	public bool bmc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C1")]
	[Address(RVA = "0x622550", Offset = "0x621550", VA = "0x180622550")]
	public void clickTab(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C2")]
	[Address(RVA = "0x619F80", Offset = "0x618F80", VA = "0x180619F80")]
	private void bmd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C3")]
	[Address(RVA = "0x629440", Offset = "0x628440", VA = "0x180629440")]
	public void refreshList()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C4")]
	[Address(RVA = "0x61A3E0", Offset = "0x6193E0", VA = "0x18061A3E0")]
	private void bme(sbyte mua, sbyte type, ref GameObject objList, ScrollRect scroll, @if[] list)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C5")]
	[Address(RVA = "0x61CA50", Offset = "0x61BA50", VA = "0x18061CA50")]
	public void bmf(RectTransform rect, Sprite spr, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C6")]
	[Address(RVA = "0x61CB30", Offset = "0x61BB30", VA = "0x18061CB30")]
	private void bmg(@if p, sbyte mua, sbyte type, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C7")]
	[Address(RVA = "0x61EAD0", Offset = "0x61DAD0", VA = "0x18061EAD0")]
	public void bmh(bool isOk, sbyte mua)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C8")]
	[Address(RVA = "0x61F400", Offset = "0x61E400", VA = "0x18061F400")]
	public void bmi(sbyte type, sbyte index, sbyte mua)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003C9")]
	[Address(RVA = "0x619130", Offset = "0x618130", VA = "0x180619130", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003CA")]
	[Address(RVA = "0x619320", Offset = "0x618320", VA = "0x180619320", Slot = "8")]
	public override void bcf()
	{
		close();
		int num = 0;
		mo.ddt().deq();
	}

	[Token(Token = "0x60003CB")]
	[Address(RVA = "0x61FFC0", Offset = "0x61EFC0", VA = "0x18061FFC0")]
	private void bmj(sbyte mua, sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003CC")]
	[Address(RVA = "0x6208A0", Offset = "0x61F8A0", VA = "0x1806208A0")]
	private bool bmk(sbyte mua)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003CD")]
	[Address(RVA = "0x620B90", Offset = "0x61FB90", VA = "0x180620B90")]
	public void bml(sbyte mua, sbyte type, short luong)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003CE")]
	[Address(RVA = "0x6213D0", Offset = "0x6203D0", VA = "0x1806213D0")]
	public void bmm(sbyte mua, sbyte type, int luong, sbyte levelUp)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003CF")]
	[Address(RVA = "0x621BB0", Offset = "0x620BB0", VA = "0x180621BB0")]
	public void bmn(sbyte type, sbyte mua)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003D0")]
	[Address(RVA = "0x629930", Offset = "0x628930", VA = "0x180629930", Slot = "11")]
	public void ti(int idAction, lh p)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003D1")]
	[Address(RVA = "0x621F00", Offset = "0x620F00", VA = "0x180621F00")]
	public void bmo(string text)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003D2")]
	[Address(RVA = "0x622640", Offset = "0x621640", VA = "0x180622640", Slot = "9")]
	public override void close()
	{
		//IL_0009: Expected Obj, but got I4
		//IL_0010: Expected Obj, but got I4
		//IL_0017: Expected Obj, but got I4
		//IL_001e: Expected Obj, but got I4
		//IL_0025: Expected Obj, but got I4
		//IL_002c: Expected Obj, but got I4
		//IL_0033: Expected Obj, but got I4
		//IL_003a: Expected Obj, but got I4
		int num = 0;
		hjl = (GameObject[][])num;
		hht = (hm[])num;
		hhu = (hm[])num;
		hjm = (RectTransform[][])num;
		hjn = (float[][])num;
		hjo = (GameObject[][][])num;
		hjp = (GameObject[][][])num;
		hiw = (hm[])num;
		int num2 = 0;
		mo.ddt().deq();
		Object.Destroy(hlf);
		Object.Destroy(hjb);
		base.close();
	}

	[Token(Token = "0x60003D3")]
	[Address(RVA = "0x6190D0", Offset = "0x6180D0", VA = "0x1806190D0")]
	public fg()
	{
	}
}
