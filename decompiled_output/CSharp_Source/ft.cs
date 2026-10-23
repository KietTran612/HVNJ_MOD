using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000092")]
public class ft : fi
{
	[Token(Token = "0x2000093")]
	private class fr : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000681")]
		private ft htf;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000682")]
		private sbyte htg;

		[Token(Token = "0x600046B")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public fr(ft me, sbyte t)
		{
			htf = me;
			htg = t;
		}

		[Token(Token = "0x600046C")]
		[Address(RVA = "0x278B00", Offset = "0x277B00", VA = "0x180278B00", Slot = "4")]
		public void th()
		{
			ft ft2 = htf;
			sbyte b = htg;
			ft2.bpf(b);
		}
	}

	[Token(Token = "0x2000094")]
	private class fs : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000683")]
		private ft hth;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000684")]
		private int hti;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000685")]
		private sbyte htj;

		[Token(Token = "0x600046D")]
		[Address(RVA = "0x278B30", Offset = "0x277B30", VA = "0x180278B30")]
		public fs(ft me, sbyte t, int index)
		{
			hth = me;
			htj = t;
			hti = index;
		}

		[Token(Token = "0x600046E")]
		[Address(RVA = "0x278B80", Offset = "0x277B80", VA = "0x180278B80", Slot = "4")]
		public void th()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x4000664")]
	private static ft htk;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000665")]
	private int htl = 180;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000666")]
	private int htm = 220;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000667")]
	private int htn;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000668")]
	private int hto;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000669")]
	private GameObject htp;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400066A")]
	private int htq;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x400066B")]
	private int htr;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400066C")]
	private int hts;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x400066D")]
	private int htt;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400066E")]
	private int htu;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400066F")]
	private hm htv;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000670")]
	private GameObject htw;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000671")]
	private GameObject htx;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000672")]
	private GameObject hty;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000673")]
	private ScrollRect htz;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000674")]
	private ScrollRect hua;

	[Token(Token = "0x4000675")]
	public static jr[] hub;

	[Token(Token = "0x4000676")]
	public static jr huc;

	[Token(Token = "0x4000677")]
	public static bool hud;

	[Token(Token = "0x4000678")]
	public static bool hue;

	[Token(Token = "0x4000679")]
	public static bool huf;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400067A")]
	public iw hug;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x400067B")]
	private GameObject huh;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400067C")]
	private List<jp> hui = (List<jp>)(object)new List<T>();

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400067D")]
	private GameObject huj;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x400067E")]
	private GameObject huk;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x400067F")]
	private List<jr> hul;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000680")]
	private GameObject hum;

	[Token(Token = "0x600044E")]
	[Address(RVA = "0x4FB2D0", Offset = "0x4FA2D0", VA = "0x1804FB2D0")]
	public static ft bpc()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		ft ft2 = new ft();
		ft2.htl = 180;
		ft2.htm = 220;
		List<jp> list = (List<jp>)(object)new List<T>();
		ft2.hui = list;
		iw iw2 = new iw(hd.ina, ft2, 4);
		ft2.hug = iw2;
		htk = ft2;
		return ft2;
	}

	[Token(Token = "0x600044F")]
	[Address(RVA = "0x4FAD20", Offset = "0x4F9D20", VA = "0x1804FAD20")]
	public ft()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
		iw iw2 = new iw(hd.ina, this, 4);
		hug = iw2;
	}

	[Token(Token = "0x6000450")]
	[Address(RVA = "0x5036F0", Offset = "0x5026F0", VA = "0x1805036F0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000451")]
	[Address(RVA = "0x4FB4D0", Offset = "0x4FA4D0", VA = "0x1804FB4D0")]
	private void bpd(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000452")]
	[Address(RVA = "0x4FB740", Offset = "0x4FA740", VA = "0x1804FB740")]
	public void bpe()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000453")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000454")]
	[Address(RVA = "0x4FB250", Offset = "0x4FA250", VA = "0x1804FB250", Slot = "8")]
	public override void bcf()
	{
		int num = 0;
		mo.ddt().deq();
		SkeletonRenderer skeletonRenderer = ((IHasSkeletonRenderer)this).SkeletonRenderer;
	}

	[Token(Token = "0x6000455")]
	[Address(RVA = "0x4FC200", Offset = "0x4FB200", VA = "0x1804FC200")]
	private void bpf(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000456")]
	[Address(RVA = "0x4FC3C0", Offset = "0x4FB3C0", VA = "0x1804FC3C0")]
	private void bpg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000457")]
	[Address(RVA = "0x4FCE40", Offset = "0x4FBE40", VA = "0x1804FCE40")]
	private void bph()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000458")]
	[Address(RVA = "0x4FE9D0", Offset = "0x4FD9D0", VA = "0x1804FE9D0")]
	public void bpi(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000459")]
	[Address(RVA = "0x504590", Offset = "0x503590", VA = "0x180504590")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600045A")]
	[Address(RVA = "0x4FEAE0", Offset = "0x4FDAE0", VA = "0x1804FEAE0")]
	private void bpj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600045B")]
	[Address(RVA = "0x4FEC80", Offset = "0x4FDC80", VA = "0x1804FEC80")]
	private void bpk(int type, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600045C")]
	[Address(RVA = "0x4FEF50", Offset = "0x4FDF50", VA = "0x1804FEF50")]
	public void bpl()
	{
		Image component = htw.GetComponent<Image>();
		Sprite sprice = ka.lmb[3];
		ho.byh(component, sprice);
	}

	[Token(Token = "0x600045D")]
	[Address(RVA = "0x4FF040", Offset = "0x4FE040", VA = "0x1804FF040")]
	public void bpm(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600045E")]
	[Address(RVA = "0x4FF720", Offset = "0x4FE720", VA = "0x1804FF720")]
	public void bpn()
	{
		//IL_00ca: Expected Obj, but got I4
		//IL_00ca: Expected Obj, but got I4
		if (huc.lfe != 0)
		{
			int num = 0;
			int num2 = 0;
			jr[] miv = lm.cua().miv;
			if (num < miv.Length)
			{
				int num3 = 0;
				jr[] miv2 = lm.cua().miv;
				num++;
			}
			jr[] array = hub;
			if (num < array.Length)
			{
				jr[] array2 = hub;
				num++;
			}
			string ixk = hd.ixk;
			iw cmdYes = new iw(hd.imy, this, 2);
			iw cmdNo = new iw(hd.inj, this, 3);
			hw.cec(ixk, cmdYes, cmdNo);
			return;
		}
		YesNoDialog jum = hw.jum;
		string ixi = hd.ixi;
		iw center = new iw(hd.imi, 1);
		int num4 = 0;
		int num5 = 0;
		jum.dnn(ixi, (iw)num5, center, (iw)num4);
		hw.jum.bnk();
		int num6 = 0;
		lj lj2 = lj.cmy();
		jr[] items = hub;
		jr jr2 = huc;
		lj2.cst(jr2, items);
		int num7 = 0;
		lj lj3 = lj.cmy();
		jr[] items2 = hub;
		jr jr3 = huc;
		lj3.csq(jr3, items2);
		throw new IndexOutOfRangeException();
	}

	[Token(Token = "0x600045F")]
	[Address(RVA = "0x4FFCF0", Offset = "0x4FECF0", VA = "0x1804FFCF0")]
	public void bpo()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000460")]
	[Address(RVA = "0x500200", Offset = "0x4FF200", VA = "0x180500200")]
	public void bpp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000461")]
	[Address(RVA = "0x5005D0", Offset = "0x4FF5D0", VA = "0x1805005D0")]
	public void bpq()
	{
		int num = 0;
		mo mo2 = mo.ddt();
		int action = default;
		iw odd = new iw(hd.ioe, this, action);
		action = 0;
		mo2.odd = odd;
		int num2 = 0;
		mo mo3 = mo.ddt();
		jr item = huc;
		mo3.updateItemInfo(3, item);
	}

	[Token(Token = "0x6000462")]
	[Address(RVA = "0x5007F0", Offset = "0x4FF7F0", VA = "0x1805007F0")]
	public void bpr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000463")]
	[Address(RVA = "0x500BC0", Offset = "0x4FFBC0", VA = "0x180500BC0")]
	private void bps()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000464")]
	[Address(RVA = "0x501490", Offset = "0x500490", VA = "0x180501490")]
	private void bpt()
	{
		//IL_001d: Expected I4, but got I8
		//IL_005f: Expected Obj, but got I8
		//IL_006c: Expected Obj, but got I8
		jr jr2;
		lm lm2;
		jr[] miv;
		do
		{
			jr2 = mo.diy(44);
			jr[] array = hub;
			int nfo = mo.nfo;
			((jr)(object)array).lew = 0;
			int num = 0;
			lm2 = lm.cua();
			miv = lm2.miv;
			int ley = jr2.ley;
		}
		while (lm2 == null);
		int num2 = 0;
		miv[0] = jr2;
		mo mo2 = mo.ddt();
		int num3 = 0;
		mo.ddt().ode = (iw)0;
		int num4 = 0;
		mo2.odd = (iw)0;
		mo.ddt().dix();
	}

	[Token(Token = "0x6000465")]
	[Address(RVA = "0x501650", Offset = "0x500650", VA = "0x180501650")]
	public void bpu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000466")]
	[Address(RVA = "0x503220", Offset = "0x502220", VA = "0x180503220")]
	public void bpv()
	{
		//IL_0014: Expected VT, but got Obj
		//IL_0028: Expected VT, but got Obj
		//IL_0048: Expected I4, but got I8
		//IL_0048: Expected I4, but got I8
		List<iw> list = (List<iw>)(object)new List<T>();
		iw iw2 = hug;
		((List<T>)(object)list).Add((T)iw2);
		iw iw3 = new iw(hd.ipi, this, 1);
		((List<T>)(object)list).Add((T)iw3);
		int num = 0;
		ms ms2 = ms.dkz();
		int num2 = 0;
		int num3 = 0;
		ulong num4 = default;
		ulong num5 = default;
		ms2.dla((List<>)(object)list, num3, (byte)num2 != 0, (byte)num4 != 0, (byte)num5 != 0);
	}

	[Token(Token = "0x6000467")]
	[Address(RVA = "0x4FAE60", Offset = "0x4F9E60", VA = "0x1804FAE60", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000468")]
	[Address(RVA = "0x5033D0", Offset = "0x5023D0", VA = "0x1805033D0")]
	private void bpw()
	{
		//IL_0033: Expected Obj, but got I4
		//IL_0075: Expected Obj, but got I4
		//IL_0081: Expected Obj, but got I4
		//IL_005c: Expected Obj, but got I4
		jr jr2;
		lm lm2;
		jr[] miv;
		do
		{
			jr2 = huc;
			int num = 0;
			lm2 = lm.cua();
			miv = lm2.miv;
			int ley = jr2.ley;
		}
		while (lm2 == null);
		miv[0] = jr2;
		int num2 = 0;
		huc = (jr)num2;
		jr[] array = hub;
		if (num2 < array.Length)
		{
			jr[] array2 = hub;
			num2++;
			array2[0] = (jr)num2;
		}
		int num3 = 0;
		mo mo2 = mo.ddt();
		int num4 = 0;
		mo.ddt().ode = (iw)num2;
		int num5 = 0;
		mo2.odd = (iw)num2;
		mo.ddt().dix();
	}

	[Token(Token = "0x6000469")]
	[Address(RVA = "0x503670", Offset = "0x502670", VA = "0x180503670", Slot = "9")]
	public override void close()
	{
		UnityEngine.Object.Destroy(huh);
		UnityEngine.Object.Destroy(hlf);
		base.close();
	}

	[Token(Token = "0x600046A")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static ft()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
