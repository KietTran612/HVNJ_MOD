using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200009E")]
public class gf : fi
{
	[Token(Token = "0x200009F")]
	private class gc : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000704")]
		private gf hyi;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000705")]
		private sbyte hyj;

		[Token(Token = "0x60004BD")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gc(gf me, sbyte t)
		{
			hyi = me;
			hyj = t;
		}

		[Token(Token = "0x60004BE")]
		[Address(RVA = "0x278E90", Offset = "0x277E90", VA = "0x180278E90", Slot = "4")]
		public void th()
		{
			gf gf2 = hyi;
			sbyte b = hyj;
			gf2.brg(b);
		}
	}

	[Token(Token = "0x20000A0")]
	private class gd : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000706")]
		private gf hyk;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000707")]
		private int hyl;

		[Token(Token = "0x60004BF")]
		[Address(RVA = "0x277DC0", Offset = "0x276DC0", VA = "0x180277DC0")]
		public gd(gf me, int index)
		{
			hyk = me;
			hyl = index;
		}

		[Token(Token = "0x60004C0")]
		[Address(RVA = "0x278EC0", Offset = "0x277EC0", VA = "0x180278EC0", Slot = "4")]
		public void th()
		{
			gf gf2 = hyk;
			int index = hyl;
			gf2.bre(index);
		}
	}

	[Token(Token = "0x20000A1")]
	private class ge : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000708")]
		public gf hym;

		[Token(Token = "0x60004C1")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public ge(gf me)
		{
			hym = me;
		}

		[Token(Token = "0x60004C2")]
		[Address(RVA = "0x278EF0", Offset = "0x277EF0", VA = "0x180278EF0", Slot = "4")]
		public void th()
		{
			hym.brf();
		}
	}

	[Token(Token = "0x40006E9")]
	private static gf hyn;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40006EA")]
	private int hyo = 180;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x40006EB")]
	private int hyp = 220;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40006EC")]
	private int hyq;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x40006ED")]
	private int hyr;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40006EE")]
	private GameObject hys;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40006EF")]
	private int hyt;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x40006F0")]
	private int hyu;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40006F1")]
	private int hyv;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x40006F2")]
	private int hyw;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40006F3")]
	private int hyx;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40006F4")]
	private hm hyy;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40006F5")]
	private GameObject hyz;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x40006F6")]
	private GameObject hza;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40006F7")]
	private GameObject hzb;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x40006F8")]
	private ScrollRect hzc;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40006F9")]
	private ScrollRect hzd;

	[Token(Token = "0x40006FA")]
	public static jr[] hze;

	[Token(Token = "0x40006FB")]
	public static jr hzf;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x40006FC")]
	public iw hzg;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x40006FD")]
	private GameObject hzh;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x40006FE")]
	private GameObject hzi;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x40006FF")]
	private GameObject hzj;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000700")]
	private GameObject hzk;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000701")]
	private List<jr> hzl;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000702")]
	private GameObject hzm;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000703")]
	public hm hzn;

	[Token(Token = "0x60004AC")]
	[Address(RVA = "0x782480", Offset = "0x781480", VA = "0x180782480")]
	public static gf bqz()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		gf gf2 = hyn;
		if (gf2 == null)
		{
			gf gf3 = new gf();
			gf3.hyo = 180;
			gf3.hyp = 220;
			hyn = gf3;
		}
		return gf2;
	}

	[Token(Token = "0x60004AD")]
	[Address(RVA = "0x785020", Offset = "0x784020", VA = "0x180785020")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004AE")]
	[Address(RVA = "0x785F50", Offset = "0x784F50", VA = "0x180785F50")]
	public void onItemGem()
	{
		GC.KeepAlive("onItemGem");
		bra();
	}

	[Token(Token = "0x60004AF")]
	[Address(RVA = "0x782540", Offset = "0x781540", VA = "0x180782540")]
	public void bra()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B0")]
	[Address(RVA = "0x782DC0", Offset = "0x781DC0", VA = "0x180782DC0")]
	private void brb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B1")]
	[Address(RVA = "0x783500", Offset = "0x782500", VA = "0x180783500")]
	private void brc(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B2")]
	[Address(RVA = "0x783730", Offset = "0x782730", VA = "0x180783730")]
	private void brd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B3")]
	[Address(RVA = "0x783E00", Offset = "0x782E00", VA = "0x180783E00")]
	private void bre(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B4")]
	[Address(RVA = "0x785FA0", Offset = "0x784FA0", VA = "0x180785FA0")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B5")]
	[Address(RVA = "0x783F60", Offset = "0x782F60", VA = "0x180783F60")]
	public void brf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B6")]
	[Address(RVA = "0x782400", Offset = "0x781400", VA = "0x180782400", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B7")]
	[Address(RVA = "0x784490", Offset = "0x783490", VA = "0x180784490")]
	private void brg(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B8")]
	[Address(RVA = "0x782380", Offset = "0x781380", VA = "0x180782380", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004B9")]
	[Address(RVA = "0x784CB0", Offset = "0x783CB0", VA = "0x180784CB0")]
	private void doThaoNgoc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004BA")]
	[Address(RVA = "0x784710", Offset = "0x783710", VA = "0x180784710")]
	public void brh(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004BB")]
	[Address(RVA = "0x784BF0", Offset = "0x783BF0", VA = "0x180784BF0", Slot = "9")]
	public override void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004BC")]
	[Address(RVA = "0x782320", Offset = "0x781320", VA = "0x180782320")]
	public gf()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
