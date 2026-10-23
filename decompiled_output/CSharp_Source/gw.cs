using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000AE")]
public class gw : fi
{
	[Token(Token = "0x20000AF")]
	private class gr : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007DF")]
		private gw ifx;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40007E0")]
		private sbyte ify;

		[Token(Token = "0x600053D")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gr(gw me, sbyte t)
		{
			ifx = me;
			ify = t;
		}

		[Token(Token = "0x600053E")]
		[Address(RVA = "0x279060", Offset = "0x278060", VA = "0x180279060", Slot = "4")]
		public void th()
		{
			gw gw2 = ifx;
			sbyte type = ify;
			gw2.bte(type);
		}
	}

	[Token(Token = "0x20000B0")]
	private class gs : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007E1")]
		private gw ifz;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40007E2")]
		private sbyte iga;

		[Token(Token = "0x600053F")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gs(gw me, sbyte t)
		{
			ifz = me;
			iga = t;
		}

		[Token(Token = "0x6000540")]
		[Address(RVA = "0x279090", Offset = "0x278090", VA = "0x180279090", Slot = "4")]
		public void th()
		{
			gw gw2 = ifz;
			sbyte type = iga;
			gw2.clickCheck(type);
		}
	}

	[Token(Token = "0x20000B1")]
	private class gt : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007E3")]
		private gw igb;

		[Token(Token = "0x6000541")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public gt(gw me)
		{
			igb = me;
		}

		[Token(Token = "0x6000542")]
		[Address(RVA = "0x2790C0", Offset = "0x2780C0", VA = "0x1802790C0", Slot = "4")]
		public void th()
		{
			igb.btg();
		}
	}

	[Token(Token = "0x20000B2")]
	private class gu : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007E4")]
		private gw igc;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40007E5")]
		private int igd;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40007E6")]
		private sbyte ige;

		[Token(Token = "0x6000543")]
		[Address(RVA = "0x278B30", Offset = "0x277B30", VA = "0x180278B30")]
		public gu(gw me, sbyte t, int index)
		{
			igc = me;
			ige = t;
			igd = index;
		}

		[Token(Token = "0x6000544")]
		[Address(RVA = "0x2790E0", Offset = "0x2780E0", VA = "0x1802790E0", Slot = "4")]
		public void th()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x20000B3")]
	private class gv : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007E7")]
		private gw igf;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40007E8")]
		private sbyte igg;

		[Token(Token = "0x6000545")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gv(gw me, sbyte t)
		{
			igf = me;
			igg = t;
		}

		[Token(Token = "0x6000546")]
		[Address(RVA = "0x2791A0", Offset = "0x2781A0", VA = "0x1802791A0", Slot = "4")]
		public void th()
		{
			gw gw2 = igf;
			sbyte b = igg;
			gw2.btq(b);
		}
	}

	[Token(Token = "0x40007AE")]
	private static gw igh;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40007AF")]
	private int igi = 190;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x40007B0")]
	private int igj = 240;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40007B1")]
	private int igk;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x40007B2")]
	private int igl;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40007B3")]
	private GameObject igm;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40007B4")]
	private int ign;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x40007B5")]
	private int igo;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40007B6")]
	private int igp;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x40007B7")]
	private int igq;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40007B8")]
	private ScrollRectClick igr;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40007B9")]
	private ScrollRectClick igs;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40007BA")]
	private List<jr> igt;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x40007BB")]
	private GameObject igu;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40007BC")]
	private GameObject igv;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x40007BD")]
	private GameObject igw;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40007BE")]
	private GameObject igx;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x40007BF")]
	private GameObject igy;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x40007C0")]
	private hm igz;

	[Token(Token = "0x40007C1")]
	public static Sprite[] iha;

	[Token(Token = "0x40007C2")]
	public static Sprite ihb;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x40007C3")]
	public bool ihc;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x40007C4")]
	private RectTransform ihd;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x40007C5")]
	private sbyte ihe = 1;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x40007C6")]
	private GameObject ihf;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x40007C7")]
	private GameObject ihg;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x40007C8")]
	private GameObject ihh;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x40007C9")]
	private GameObject ihi;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40007CA")]
	private hm ihj;

	[Token(Token = "0x40007CB")]
	public static jr[] ihk;

	[Token(Token = "0x40007CC")]
	public static jr ihl;

	[Token(Token = "0x40007CD")]
	public static bool ihm;

	[Token(Token = "0x40007CE")]
	public static bool ihn;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40007CF")]
	private GameObject iho;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40007D0")]
	public sbyte ihp;

	[FieldOffset(Offset = "0x111")]
	[Token(Token = "0x40007D1")]
	private bool ihq;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40007D2")]
	private ImageClickButton ihr;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40007D3")]
	private hm ihs;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40007D4")]
	private sbyte iht;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40007D5")]
	private GameObject[] ihu;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40007D6")]
	private GameObject ihv;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40007D7")]
	private List<jr> ihw;

	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x40007D8")]
	private List<jp> ihx = (List<jp>)(object)new List<T>();

	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40007D9")]
	private GameObject ihy;

	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40007DA")]
	private GameObject ihz;

	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x40007DB")]
	private hm iia;

	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40007DC")]
	private GameObject iib;

	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40007DD")]
	private GameObject iic;

	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40007DE")]
	private GameObject iid;

	[Token(Token = "0x600051B")]
	[Address(RVA = "0x284630", Offset = "0x283630", VA = "0x180284630")]
	public static gw btb()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		//IL_0029: Expected I4, but got I8
		gw gw2 = new gw();
		gw2.igi = 190;
		gw2.igj = 240;
		gw2.ihe = 1;
		List<jp> list = (List<jp>)(object)new List<T>();
		gw2.ihx = list;
		igh = gw2;
		return gw2;
	}

	[Token(Token = "0x600051C")]
	[Address(RVA = "0x2847A0", Offset = "0x2837A0", VA = "0x1802847A0")]
	public static void btc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600051D")]
	[Address(RVA = "0x28CB60", Offset = "0x28BB60", VA = "0x18028CB60")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600051E")]
	[Address(RVA = "0x2849D0", Offset = "0x2839D0", VA = "0x1802849D0")]
	public void btd(sbyte per, sbyte levelShow)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600051F")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	private void bte(sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000520")]
	[Address(RVA = "0x28C7F0", Offset = "0x28B7F0", VA = "0x18028C7F0")]
	private void clickCheck(sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000521")]
	[Address(RVA = "0x284BF0", Offset = "0x283BF0", VA = "0x180284BF0")]
	public void btf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000522")]
	[Address(RVA = "0x28E710", Offset = "0x28D710", VA = "0x18028E710")]
	public void refreshList()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000523")]
	[Address(RVA = "0x28EAC0", Offset = "0x28DAC0", VA = "0x18028EAC0")]
	public void updateList()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000524")]
	[Address(RVA = "0x2842E0", Offset = "0x2832E0", VA = "0x1802842E0", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000525")]
	[Address(RVA = "0x284DD0", Offset = "0x283DD0", VA = "0x180284DD0")]
	private void btg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000526")]
	[Address(RVA = "0x285B40", Offset = "0x284B40", VA = "0x180285B40")]
	private void bth(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000527")]
	[Address(RVA = "0x285EA0", Offset = "0x284EA0", VA = "0x180285EA0")]
	private void bti(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000528")]
	[Address(RVA = "0x286110", Offset = "0x285110", VA = "0x180286110")]
	public void btj(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000529")]
	[Address(RVA = "0x28E9D0", Offset = "0x28D9D0", VA = "0x18028E9D0")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600052A")]
	[Address(RVA = "0x286210", Offset = "0x285210", VA = "0x180286210")]
	private void btk(sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600052B")]
	[Address(RVA = "0x286360", Offset = "0x285360", VA = "0x180286360")]
	private void btl(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600052C")]
	[Address(RVA = "0x286700", Offset = "0x285700", VA = "0x180286700")]
	private void btm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600052D")]
	[Address(RVA = "0x287250", Offset = "0x286250", VA = "0x180287250")]
	private void bto(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600052E")]
	[Address(RVA = "0x287AC0", Offset = "0x286AC0", VA = "0x180287AC0")]
	private void btp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600052F")]
	[Address(RVA = "0x2845B0", Offset = "0x2835B0", VA = "0x1802845B0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000530")]
	[Address(RVA = "0x289A20", Offset = "0x288A20", VA = "0x180289A20")]
	private void btq(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000531")]
	[Address(RVA = "0x289BD0", Offset = "0x288BD0", VA = "0x180289BD0")]
	public void btr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000532")]
	[Address(RVA = "0x289DF0", Offset = "0x288DF0", VA = "0x180289DF0")]
	public void bts()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000533")]
	[Address(RVA = "0x28AB40", Offset = "0x289B40", VA = "0x18028AB40")]
	public void btt()
	{
		//IL_0047: Expected Obj, but got I8
		//IL_004e: Expected Obj, but got I4
		if (ihc || ihl.lfc)
		{
			if (ihc)
			{
				Object.Destroy(ihf);
				ihj.close();
				ImageClickButton imageClickButton = ihr;
				int num = 0;
				ihj = (hm)0;
				if (imageClickButton != (Object)num)
				{
					ihr.gameObject.SetActive(value: true);
				}
			}
			int num2 = 0;
			lj lj2 = lj.cmy();
			bool isGold = ihm;
			jr[] items = ihk;
			jr item = ihl;
			lj2.cpd(item, items, isGold);
		}
		else
		{
			string ixe = hd.ixe;
			int action = default;
			iw cmdYes = new iw(hd.imy, this, action);
			action = 0;
			iw cmdNo = new iw(hd.inj, 1);
			hw.cec(ixe, cmdYes, cmdNo);
		}
	}

	[Token(Token = "0x6000534")]
	[Address(RVA = "0x28AE10", Offset = "0x289E10", VA = "0x18028AE10")]
	private bool btu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000535")]
	[Address(RVA = "0x28AF20", Offset = "0x289F20", VA = "0x18028AF20")]
	public void btv()
	{
		if (mo.diy(10) != null)
		{
			int num = 0;
			mo mo2 = mo.ddt();
			if (!ihl.cho())
			{
				int num2 = 0;
				mo mo3 = mo.ddt();
				jr item = ihl;
				mo3.updateItemInfo(3, item);
			}
		}
	}

	[Token(Token = "0x6000536")]
	[Address(RVA = "0x28B1E0", Offset = "0x28A1E0", VA = "0x18028B1E0")]
	public bool btw(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000537")]
	[Address(RVA = "0x28C390", Offset = "0x28B390", VA = "0x18028C390")]
	public void btx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000538")]
	[Address(RVA = "0x28C710", Offset = "0x28B710", VA = "0x18028C710")]
	public void bty()
	{
		//IL_0038: Expected Obj, but got I8
		//IL_003f: Expected Obj, but got I4
		if (ihc)
		{
			ihc = false;
			Object.Destroy(ihf);
			ihj.close();
			ImageClickButton imageClickButton = ihr;
			int num = 0;
			ihj = (hm)0;
			if (imageClickButton != (Object)num)
			{
				ihr.gameObject.SetActive(value: true);
			}
		}
	}

	[Token(Token = "0x6000539")]
	[Address(RVA = "0x2841C0", Offset = "0x2831C0", VA = "0x1802841C0", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600053A")]
	[Address(RVA = "0x28CAA0", Offset = "0x28BAA0", VA = "0x18028CAA0", Slot = "9")]
	public override void close()
	{
		//IL_0026: Expected Obj, but got I4
		//IL_002d: Expected Obj, but got I4
		Object.Destroy(hlf);
		Object.Destroy(iho);
		List<jp> list = ihx;
		int num = 0;
		hlf = (GameObject)num;
		iia = (hm)num;
		((List<T>)(object)list).Clear();
		ihc = false;
		base.close();
	}

	[Token(Token = "0x600053B")]
	[Address(RVA = "0x284110", Offset = "0x283110", VA = "0x180284110")]
	public gw()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
		//IL_0023: Expected I4, but got I8
	}

	[Token(Token = "0x600053C")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static gw()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
