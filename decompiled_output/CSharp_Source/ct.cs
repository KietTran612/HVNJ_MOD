using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000046")]
public class ct : fi
{
	[Token(Token = "0x2000047")]
	private class cq : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400027F")]
		private ct gfz;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000280")]
		private sbyte gga;

		[Token(Token = "0x600022D")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public cq(ct me, sbyte t)
		{
			gfz = me;
			gga = t;
		}

		[Token(Token = "0x600022E")]
		[Address(RVA = "0x277F30", Offset = "0x276F30", VA = "0x180277F30", Slot = "4")]
		public void th()
		{
			ct ct2 = gfz;
			sbyte b = gga;
			ct2.beo(b);
		}
	}

	[Token(Token = "0x2000048")]
	private class cr : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000281")]
		private ct ggb;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000282")]
		private sbyte ggc;

		[Token(Token = "0x600022F")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public cr(ct me, sbyte t)
		{
			ggb = me;
			ggc = t;
		}

		[Token(Token = "0x6000230")]
		[Address(RVA = "0x277F60", Offset = "0x276F60", VA = "0x180277F60", Slot = "4")]
		public void th()
		{
			ggb.ggs.SetActive(value: true);
			ct ct2 = ggb;
			sbyte index = ggc;
			ct2.updateList(index);
		}
	}

	[Token(Token = "0x2000049")]
	private class cs : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000283")]
		private ct ggd;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000284")]
		private int gge;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000285")]
		private int ggf;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000286")]
		private bool ggg;

		[Token(Token = "0x6000231")]
		[Address(RVA = "0x277A10", Offset = "0x276A10", VA = "0x180277A10")]
		public cs(ct me, int t, int ind, bool isInfo)
		{
			ggd = me;
			ggf = ind;
			ggg = false;
			gge = t;
		}

		[Token(Token = "0x6000232")]
		[Address(RVA = "0x277FB0", Offset = "0x276FB0", VA = "0x180277FB0", Slot = "4")]
		public void th()
		{
			ct ct2 = ggd;
			if (!ggg)
			{
				int nfo = mo.nfo;
				ct2.bes(nfo);
				return;
			}
			int ggz = gge;
			ct2.ggz = (sbyte)ggz;
			ct ct3 = ggd;
			int index = ggf;
			ct3.beq(index);
		}
	}

	[Token(Token = "0x4000267")]
	private static ct ggh;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000268")]
	private int ggi = 200;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000269")]
	private int ggj = 210;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400026A")]
	private int ggk;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400026B")]
	private int ggl;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400026C")]
	private int ggm;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x400026D")]
	private float ggn;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400026E")]
	private float ggo;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400026F")]
	private hm ggp;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000270")]
	private Image ggq;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000271")]
	private Sprite[] ggr;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000272")]
	private GameObject ggs;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000273")]
	private GameObject[] ggt;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000274")]
	private GameObject[] ggu;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000275")]
	private hm[] ggv;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000276")]
	private ScrollRect ggw;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000277")]
	private List<jr> ggx;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000278")]
	private GameObject ggy;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000279")]
	private sbyte ggz;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400027A")]
	private GameObject gha;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x400027B")]
	private GameObject ghb;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x400027C")]
	private GameObject ghc;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x400027D")]
	private List<jp> ghd = (List<jp>)(object)new List<T>();

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x400027E")]
	private sbyte ghe;

	[Token(Token = "0x600021C")]
	[Address(RVA = "0x583E70", Offset = "0x582E70", VA = "0x180583E70")]
	public static ct bem()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		ct ct2 = ggh;
		if (ct2 == null)
		{
			ct ct3 = new ct();
			ct3.ggi = 200;
			ct3.ggj = 210;
			List<jp> list = (List<jp>)(object)new List<T>();
			ct3.ghd = list;
			ggh = ct3;
		}
		return ct2;
	}

	[Token(Token = "0x600021D")]
	[Address(RVA = "0x585B20", Offset = "0x584B20", VA = "0x180585B20")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600021E")]
	[Address(RVA = "0x583F70", Offset = "0x582F70", VA = "0x180583F70")]
	private void ben()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600021F")]
	[Address(RVA = "0x584390", Offset = "0x583390", VA = "0x180584390")]
	private void beo(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000220")]
	[Address(RVA = "0x587040", Offset = "0x586040", VA = "0x180587040")]
	private void updateList(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000221")]
	[Address(RVA = "0x583D80", Offset = "0x582D80", VA = "0x180583D80", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000222")]
	[Address(RVA = "0x584590", Offset = "0x583590", VA = "0x180584590")]
	private void bep(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000223")]
	[Address(RVA = "0x5848C0", Offset = "0x5838C0", VA = "0x1805848C0")]
	public void beq(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000224")]
	[Address(RVA = "0x586F20", Offset = "0x585F20", VA = "0x180586F20")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000225")]
	[Address(RVA = "0x5849D0", Offset = "0x5839D0", VA = "0x1805849D0")]
	public void ber()
	{
		//IL_0037: Expected Obj, but got I4
		int num = 0;
		Object.Destroy(ggt[num]);
		hm hm2 = ggv[num];
		if (hm2 != null)
		{
			hm2.close();
			ggv[0] = (hm)num;
		}
		jr[] nfr = mo.nfr;
		if (unchecked((nint)"{il2cpp array field local9->}") != num)
		{
			bet(num);
		}
		num++;
	}

	[Token(Token = "0x6000226")]
	[Address(RVA = "0x584B80", Offset = "0x583B80", VA = "0x180584B80")]
	private void bes(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000227")]
	[Address(RVA = "0x584F80", Offset = "0x583F80", VA = "0x180584F80")]
	private void bet(int type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000228")]
	[Address(RVA = "0x5856F0", Offset = "0x5846F0", VA = "0x1805856F0")]
	private bool beu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000229")]
	[Address(RVA = "0x5857D0", Offset = "0x5847D0", VA = "0x1805857D0")]
	public void bev()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600022A")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		((ILayoutController)this).SetLayoutHorizontal();
	}

	[Token(Token = "0x600022B")]
	[Address(RVA = "0x585A60", Offset = "0x584A60", VA = "0x180585A60", Slot = "9")]
	public override void close()
	{
		int num = 0;
		mo.ddt().deq();
		Object.Destroy(hlf);
		Object.Destroy(ggy);
		base.close();
	}

	[Token(Token = "0x600022C")]
	[Address(RVA = "0x583CD0", Offset = "0x582CD0", VA = "0x180583CD0")]
	public ct()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
