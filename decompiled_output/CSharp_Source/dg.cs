using System;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000054")]
public class dg : fi
{
	[Token(Token = "0x4000319")]
	public static dg gmv;

	[Token(Token = "0x400031A")]
	public static int gmw;

	[Token(Token = "0x400031B")]
	public static int gmx;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400031C")]
	private float gmy;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400031D")]
	private hm gmz;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400031E")]
	private Image gna;

	[Token(Token = "0x400031F")]
	public static int gnb;

	[Token(Token = "0x4000320")]
	public static int gnc;

	[Token(Token = "0x4000321")]
	public static int gnd;

	[Token(Token = "0x4000322")]
	public static int gne;

	[Token(Token = "0x4000323")]
	public static int gnf;

	[Token(Token = "0x4000324")]
	public static int gng;

	[Token(Token = "0x4000325")]
	public static int gnh;

	[Token(Token = "0x4000326")]
	public static int gni;

	[Token(Token = "0x4000327")]
	public static int gnj;

	[Token(Token = "0x4000328")]
	public static int gnk;

	[Token(Token = "0x4000329")]
	public static int gnl;

	[Token(Token = "0x400032A")]
	public static int gnm;

	[Token(Token = "0x400032B")]
	public static int gnn;

	[Token(Token = "0x400032C")]
	public static int gno;

	[Token(Token = "0x400032D")]
	public static int gnp;

	[Token(Token = "0x400032E")]
	public static int gnq;

	[Token(Token = "0x400032F")]
	public static int gnr;

	[Token(Token = "0x4000330")]
	private static bool gns;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000331")]
	private int gnt;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000332")]
	private int gnu;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000333")]
	private float gnv;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4000334")]
	private float gnw;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000335")]
	public short gnx;

	[Token(Token = "0x600027F")]
	[Address(RVA = "0x53AF40", Offset = "0x539F40", VA = "0x18053AF40")]
	public static dg bgo()
	{
		dg dg2 = gmv;
		if (dg2 == null)
		{
			gmv = new dg();
		}
		return dg2;
	}

	[Token(Token = "0x6000280")]
	[Address(RVA = "0x53AFF0", Offset = "0x539FF0", VA = "0x18053AFF0")]
	public static void bgp()
	{
		gnb = t.xf("dataVersion");
		gnc = t.xf("mapVersion");
		gnd = t.xf("skillVersion");
		gne = t.xf("itemVersion");
		gnk = t.xf("passBattleVersion");
		gnm = t.xf("verOld_MapTemplateData");
		gno = t.xf("verOld_ItemInMapTemplate");
	}

	[Token(Token = "0x6000281")]
	[Address(RVA = "0x5459E0", Offset = "0x5449E0", VA = "0x1805459E0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000282")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000283")]
	[Address(RVA = "0x53ADC0", Offset = "0x539DC0", VA = "0x18053ADC0", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000284")]
	[Address(RVA = "0x544F50", Offset = "0x543F50", VA = "0x180544F50", Slot = "9")]
	public override void close()
	{
		//IL_0010: Expected Obj, but got I4
		GameObject gameObject = hlf;
		int num = 0;
		if (!(gameObject == (UnityEngine.Object)num))
		{
			hw.juj.dmu(isA: true);
			UnityEngine.Object.Destroy(hlf);
			int num2 = 0;
			mb.dch();
			int num3 = 0;
			mb.cleanMap();
			GC.KeepAlive("closeeeeeeeeeeeeeeeeeeeeeeeeee");
			base.close();
		}
	}

	[Token(Token = "0x6000285")]
	[Address(RVA = "0x53B150", Offset = "0x53A150", VA = "0x18053B150")]
	public static void bgq(string path)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000286")]
	[Address(RVA = "0x5468D0", Offset = "0x5458D0", VA = "0x1805468D0")]
	public void onItemInMapTemplateData(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000287")]
	[Address(RVA = "0x53B280", Offset = "0x53A280", VA = "0x18053B280")]
	public void bgr(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000288")]
	[Address(RVA = "0x53B890", Offset = "0x53A890", VA = "0x18053B890")]
	private void bgs()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000289")]
	[Address(RVA = "0x545410", Offset = "0x544410", VA = "0x180545410")]
	public void downloadItem(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600028A")]
	[Address(RVA = "0x5450A0", Offset = "0x5440A0", VA = "0x1805450A0")]
	public void downloadBattlePass(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600028B")]
	[Address(RVA = "0x5457D0", Offset = "0x5447D0", VA = "0x1805457D0")]
	public void downloadSkill(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600028C")]
	[Address(RVA = "0x545610", Offset = "0x544610", VA = "0x180545610")]
	public void downloadMap(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600028D")]
	[Address(RVA = "0x545250", Offset = "0x544250", VA = "0x180545250")]
	public void downloadData(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600028E")]
	[Address(RVA = "0x53B900", Offset = "0x53A900", VA = "0x18053B900")]
	public void bgt(q d)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600028F")]
	[Address(RVA = "0x53FA60", Offset = "0x53EA60", VA = "0x18053FA60")]
	public void bgu(q d)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000290")]
	[Address(RVA = "0x5409A0", Offset = "0x53F9A0", VA = "0x1805409A0")]
	public void bgv(q d)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000291")]
	[Address(RVA = "0x5429B0", Offset = "0x5419B0", VA = "0x1805429B0")]
	public void bgw(q d)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000292")]
	[Address(RVA = "0x544AD0", Offset = "0x543AD0", VA = "0x180544AD0")]
	private void bgx(q d)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000293")]
	[Address(RVA = "0x53AD60", Offset = "0x539D60", VA = "0x18053AD60")]
	public dg()
	{
	}
}
