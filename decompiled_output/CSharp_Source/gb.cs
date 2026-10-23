using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000098")]
public class gb : fi
{
	[Token(Token = "0x2000099")]
	private class fw : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40006DA")]
		private gb hvq;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40006DB")]
		private sbyte hvr;

		[Token(Token = "0x60004A1")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public fw(gb me, sbyte index)
		{
			hvq = me;
			hvr = index;
		}

		[Token(Token = "0x60004A2")]
		[Address(RVA = "0x278C70", Offset = "0x277C70", VA = "0x180278C70", Slot = "4")]
		public void th()
		{
			gb gb2 = hvq;
			sbyte index = hvr;
			gb2.clickTab(index);
		}
	}

	[Token(Token = "0x200009A")]
	private class fx : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40006DC")]
		private gb hvs;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40006DD")]
		private sbyte hvt;

		[Token(Token = "0x60004A3")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public fx(gb me, sbyte t)
		{
			hvs = me;
			hvt = t;
		}

		[Token(Token = "0x60004A4")]
		[Address(RVA = "0x278CA0", Offset = "0x277CA0", VA = "0x180278CA0", Slot = "4")]
		public void th()
		{
			gb gb2 = hvs;
			sbyte b = hvt;
			gb2.bqh(b);
		}
	}

	[Token(Token = "0x200009B")]
	private class fy : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40006DE")]
		private gb hvu;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40006DF")]
		private sbyte hvv;

		[FieldOffset(Offset = "0x19")]
		[Token(Token = "0x40006E0")]
		private sbyte hvw;

		[FieldOffset(Offset = "0x1A")]
		[Token(Token = "0x40006E1")]
		private sbyte hvx;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40006E2")]
		private int hvy;

		[Token(Token = "0x60004A5")]
		[Address(RVA = "0x278CD0", Offset = "0x277CD0", VA = "0x180278CD0")]
		public fy(gb me, sbyte index, sbyte type, sbyte tab)
		{
			hvu = me;
			hvw = type;
			hvx = 0;
			hvv = index;
		}

		[Token(Token = "0x60004A6")]
		[Address(RVA = "0x278D30", Offset = "0x277D30", VA = "0x180278D30")]
		public fy(gb me, sbyte index, sbyte type, sbyte tab, int idChar)
		{
			hvx = 0;
			hvu = me;
			hvw = type;
			hvy = 0;
			hvv = index;
		}

		[Token(Token = "0x60004A7")]
		[Address(RVA = "0x278D90", Offset = "0x277D90", VA = "0x180278D90", Slot = "4")]
		public void th()
		{
			gb gb2 = hvu;
			int idChar = hvy;
			sbyte tab = hvx;
			sbyte typeIcon = hvw;
			sbyte index = hvv;
			gb2.bqj(index, typeIcon, tab, idChar);
		}
	}

	[Token(Token = "0x200009C")]
	private class fz : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40006E3")]
		private sbyte hvz;

		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x40006E4")]
		private int hwa;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40006E5")]
		private gb hwb;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40006E6")]
		public string hwc;

		[Token(Token = "0x60004A8")]
		[Address(RVA = "0x278DD0", Offset = "0x277DD0", VA = "0x180278DD0")]
		public fz(gb me, sbyte type, int ind)
		{
			hwb = me;
			hwa = ind;
			hvz = type;
		}

		[Token(Token = "0x60004A9")]
		[Address(RVA = "0x278E20", Offset = "0x277E20", VA = "0x180278E20", Slot = "4")]
		public void th()
		{
			gb gb2 = hwb;
			string name = hwc;
			int ind = hwa;
			sbyte type = hvz;
			gb2.bqp(type, ind, name);
		}
	}

	[Token(Token = "0x200009D")]
	private class ga : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40006E7")]
		private int hwd;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40006E8")]
		private gb hwe;

		[Token(Token = "0x60004AA")]
		[Address(RVA = "0x2782F0", Offset = "0x2772F0", VA = "0x1802782F0")]
		public ga(gb me, int ind)
		{
			hwe = me;
			hwd = ind;
		}

		[Token(Token = "0x60004AB")]
		[Address(RVA = "0x278E60", Offset = "0x277E60", VA = "0x180278E60", Slot = "4")]
		public void th()
		{
			gb gb2 = hwe;
			int index = hwd;
			gb2.bqs(index);
		}
	}

	[Token(Token = "0x40006A3")]
	public static gb hwf;

	[Token(Token = "0x40006A4")]
	private static sbyte hwg;

	[Token(Token = "0x40006A5")]
	private static sbyte hwh;

	[Token(Token = "0x40006A6")]
	private static sbyte hwi;

	[Token(Token = "0x40006A7")]
	private static sbyte hwj;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40006A8")]
	private float hwk;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x40006A9")]
	private float hwl = 235f;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40006AA")]
	private float hwm;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x40006AB")]
	private float hwn;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40006AC")]
	private float hwo;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x40006AD")]
	private float hwp;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40006AE")]
	private float hwq;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x40006AF")]
	private float hwr;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40006B0")]
	private float hws;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x40006B1")]
	private float hwt;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40006B2")]
	private ScrollRect hwu;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40006B3")]
	private hm hwv;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40006B4")]
	private sbyte hww;

	[Token(Token = "0x40006B5")]
	private static sbyte hwx;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x40006B6")]
	private GameObject hwy;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40006B7")]
	private GameObject hwz;

	[Token(Token = "0x40006B8")]
	public static sbyte hxa;

	[Token(Token = "0x40006B9")]
	public static sbyte hxb;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x40006BA")]
	private hm hxc;

	[Token(Token = "0x40006BB")]
	public static bool hxd;

	[Token(Token = "0x40006BC")]
	public static bool hxe;

	[Token(Token = "0x40006BD")]
	public static List<ko> hxf;

	[Token(Token = "0x40006BE")]
	public static List<ko> hxg;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40006BF")]
	public bool hxh = true;

	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x40006C0")]
	public float hxi = 150f;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x40006C1")]
	public float hxj = 250f;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x40006C2")]
	private GameObject hxk;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x40006C3")]
	private GameObject hxl;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x40006C4")]
	private GameObject hxm;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x40006C5")]
	private GameObject hxn;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x40006C6")]
	private RectTransform hxo;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x40006C7")]
	private Image hxp;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x40006C8")]
	private hm hxq;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x40006C9")]
	private hm hxr;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40006CA")]
	private ScrollRect hxs;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40006CB")]
	private GameObject hxt;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40006CC")]
	private GameObject hxu;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40006CD")]
	private GameObject hxv;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40006CE")]
	private GameObject hxw;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40006CF")]
	private GameObject hxx;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40006D0")]
	private GameObject hxy;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40006D1")]
	private Image[] hxz;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40006D2")]
	private GameObject hya;

	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x40006D3")]
	private Image[] hyb;

	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40006D4")]
	private GameObject hyc;

	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40006D5")]
	private int hyd;

	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x40006D6")]
	private GameObject hye;

	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40006D7")]
	private Image[] hyf;

	[Token(Token = "0x40006D8")]
	public static bool hyg;

	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40006D9")]
	private lm hyh;

	[Token(Token = "0x6000480")]
	[Address(RVA = "0x508850", Offset = "0x507850", VA = "0x180508850")]
	public static gb bqb()
	{
		gb gb2 = new gb();
		gb2.hwl = 235f;
		gb2.hxh = true;
		gb2.hxi = 150f;
		gb2.hxj = 250f;
		hwf = gb2;
		return gb2;
	}

	[Token(Token = "0x6000481")]
	[Address(RVA = "0x514810", Offset = "0x513810", VA = "0x180514810")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000482")]
	[Address(RVA = "0x508990", Offset = "0x507990", VA = "0x180508990")]
	public void bqc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000483")]
	[Address(RVA = "0x5142C0", Offset = "0x5132C0", VA = "0x1805142C0")]
	public void createCharTrangBi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000484")]
	[Address(RVA = "0x513F60", Offset = "0x512F60", VA = "0x180513F60")]
	private void clickTab(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000485")]
	[Address(RVA = "0x50B4F0", Offset = "0x50A4F0", VA = "0x18050B4F0")]
	private void bqd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000486")]
	[Address(RVA = "0x50C000", Offset = "0x50B000", VA = "0x18050C000")]
	public void bqe(bool isFresh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000487")]
	[Address(RVA = "0x50D0A0", Offset = "0x50C0A0", VA = "0x18050D0A0")]
	private void bqf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000488")]
	[Address(RVA = "0x50DF70", Offset = "0x50CF70", VA = "0x18050DF70")]
	private void bqg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000489")]
	[Address(RVA = "0x5087A0", Offset = "0x5077A0", VA = "0x1805087A0", Slot = "8")]
	public override void bcf()
	{
		//IL_0026: Expected Obj, but got I4
		//IL_0038: Expected Obj, but got I4
		//IL_0043: Expected Obj, but got I4
		close();
		int num = 0;
		mo.ddt().deq();
		int num2 = 0;
		mo mo2 = mo.ddt();
		int num3 = 0;
		int num4 = 0;
		mo2.odd = (iw)num3;
		mo mo3 = mo.ddt();
		int num5 = 0;
		mo3.ode = (iw)num3;
		mo.ddt().odf = (iw)num3;
	}

	[Token(Token = "0x600048A")]
	[Address(RVA = "0x50EE20", Offset = "0x50DE20", VA = "0x18050EE20")]
	private void bqh(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600048B")]
	[Address(RVA = "0x508780", Offset = "0x507780", VA = "0x180508780", Slot = "6")]
	public override void bcd()
	{
		int num = hyd;
		if (num > 0)
		{
			hyd = num;
		}
	}

	[Token(Token = "0x600048C")]
	[Address(RVA = "0x50F150", Offset = "0x50E150", VA = "0x18050F150")]
	public void bqi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600048D")]
	[Address(RVA = "0x5105E0", Offset = "0x50F5E0", VA = "0x1805105E0")]
	public void bqj(sbyte index, sbyte typeIcon, sbyte tab, int idChar)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600048E")]
	[Address(RVA = "0x5109D0", Offset = "0x50F9D0", VA = "0x1805109D0")]
	public void bqk(string name)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600048F")]
	[Address(RVA = "0x510C10", Offset = "0x50FC10", VA = "0x180510C10")]
	public void bql()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000490")]
	[Address(RVA = "0x510D00", Offset = "0x50FD00", VA = "0x180510D00")]
	public void bqm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000491")]
	[Address(RVA = "0x5110C0", Offset = "0x5100C0", VA = "0x1805110C0")]
	public void bqn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000492")]
	[Address(RVA = "0x511C90", Offset = "0x510C90", VA = "0x180511C90")]
	public static int bqo(int classId)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000493")]
	[Address(RVA = "0x511D10", Offset = "0x510D10", VA = "0x180511D10")]
	private void bqp(sbyte type, int ind, string name)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000494")]
	[Address(RVA = "0x512120", Offset = "0x511120", VA = "0x180512120")]
	public void bqq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000495")]
	[Address(RVA = "0x512600", Offset = "0x511600", VA = "0x180512600")]
	private void bqr(ko party)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000496")]
	[Address(RVA = "0x512B90", Offset = "0x511B90", VA = "0x180512B90")]
	private void bqs(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000497")]
	[Address(RVA = "0x512E80", Offset = "0x511E80", VA = "0x180512E80")]
	private void bqt(sbyte indexRow)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000498")]
	[Address(RVA = "0x512F80", Offset = "0x511F80", VA = "0x180512F80")]
	public void bqu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000499")]
	[Address(RVA = "0x5132D0", Offset = "0x5122D0", VA = "0x1805132D0")]
	public static bool bqv(lm c)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600049A")]
	[Address(RVA = "0x5133D0", Offset = "0x5123D0", VA = "0x1805133D0")]
	private void bqw(ko pt)
	{
		//IL_001c: Expected VT, but got Obj
		//IL_0049: Expected VT, but got Obj
		List<iw> list = (List<iw>)(object)new List<T>();
		iw iw2 = new iw(hd.iys, this, 4);
		int num = 0;
		((List<T>)(object)list).Add((T)iw2);
		string caption = default;
		if ((pt.lvg ? 1 : 0) != num)
		{
			iw iw3 = new iw(caption, this, 5);
		}
		caption = hd.iyu;
		iw iw4 = new iw(caption, this, 5);
		((List<T>)(object)list).Add((T)iw4);
		int num2 = 0;
		ms ms2 = ms.dkz();
		int num3 = 0;
		ms2.dla((List<>)(object)list, 3, (byte)num3 != 0, (byte)num != 0, (byte)num != 0);
	}

	[Token(Token = "0x600049B")]
	[Address(RVA = "0x507960", Offset = "0x506960", VA = "0x180507960", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600049C")]
	[Address(RVA = "0x5135F0", Offset = "0x5125F0", VA = "0x1805135F0")]
	public void bqx(lm c)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600049D")]
	[Address(RVA = "0x513D90", Offset = "0x512D90", VA = "0x180513D90")]
	public void bqy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600049E")]
	[Address(RVA = "0x5141C0", Offset = "0x5131C0", VA = "0x1805141C0", Slot = "9")]
	public override void close()
	{
		//IL_0028: Expected Obj, but got I4
		//IL_002f: Expected Obj, but got I4
		//IL_0036: Expected Obj, but got I4
		//IL_003d: Expected Obj, but got I4
		//IL_0044: Expected Obj, but got I4
		//IL_004b: Expected Obj, but got I4
		//IL_0052: Expected Obj, but got I4
		//IL_005d: Expected Obj, but got I4
		base.close();
		Object.Destroy(hlf);
		int num = 0;
		mo.ddt().deq();
		int num2 = 0;
		int num3 = 0;
		hxv = (GameObject)num2;
		hya = (GameObject)num2;
		hye = (GameObject)num2;
		hwz = (GameObject)num2;
		hxz = (Image[])num2;
		hyb = (Image[])num2;
		hyf = (Image[])num2;
		mo.ddt().odd = (iw)num2;
	}

	[Token(Token = "0x600049F")]
	[Address(RVA = "0x5078E0", Offset = "0x5068E0", VA = "0x1805078E0")]
	public gb()
	{
	}

	[Token(Token = "0x60004A0")]
	[Address(RVA = "0x507780", Offset = "0x506780", VA = "0x180507780")]
	static gb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
