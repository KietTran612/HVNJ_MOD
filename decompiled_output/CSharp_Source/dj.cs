using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000055")]
public class dj : fi
{
	[Token(Token = "0x2000056")]
	private class dh : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000341")]
		private dj gny;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000342")]
		private sbyte gnz;

		[Token(Token = "0x60002A4")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public dh(dj me, sbyte t)
		{
			gny = me;
			gnz = t;
		}

		[Token(Token = "0x60002A5")]
		[Address(RVA = "0x2782C0", Offset = "0x2772C0", VA = "0x1802782C0", Slot = "4")]
		public void th()
		{
			dj dj2 = gny;
			sbyte b = gnz;
			dj2.bha(b);
		}
	}

	[Token(Token = "0x2000057")]
	private class di : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000343")]
		private int goa;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000344")]
		private dj gob;

		[Token(Token = "0x60002A6")]
		[Address(RVA = "0x2782F0", Offset = "0x2772F0", VA = "0x1802782F0")]
		public di(dj me, int ind)
		{
			gob = me;
			goa = ind;
		}

		[Token(Token = "0x60002A7")]
		[Address(RVA = "0x278330", Offset = "0x277330", VA = "0x180278330", Slot = "4")]
		public void th()
		{
			dj dj2 = gob;
			int index = goa;
			dj2.bhf(index);
		}
	}

	[Token(Token = "0x4000336")]
	private static dj goc;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000337")]
	private List<jk> god;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000338")]
	private int goe = 240;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000339")]
	private int gof = 200;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400033A")]
	private int gog;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x400033B")]
	private int goh;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400033C")]
	private ScrollRect goi;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400033D")]
	private iw goj;

	[Token(Token = "0x400033E")]
	public static List<jk> gok;

	[Token(Token = "0x400033F")]
	public static bool gol;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000340")]
	private GameObject gom;

	[Token(Token = "0x6000294")]
	[Address(RVA = "0x547420", Offset = "0x546420", VA = "0x180547420")]
	public static dj bgy()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		dj dj2 = new dj();
		dj2.goe = 240;
		dj2.gof = 200;
		iw iw2 = new iw(hd.inu, 11002);
		dj2.goj = iw2;
		goc = dj2;
		return dj2;
	}

	[Token(Token = "0x6000295")]
	[Address(RVA = "0x546BA0", Offset = "0x545BA0", VA = "0x180546BA0")]
	public dj()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
		iw iw2 = new iw(hd.inu, 11002);
		goj = iw2;
	}

	[Token(Token = "0x6000296")]
	[Address(RVA = "0x548EA0", Offset = "0x547EA0", VA = "0x180548EA0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000297")]
	[Address(RVA = "0x5475D0", Offset = "0x5465D0", VA = "0x1805475D0")]
	public static jk bgz(string name)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000298")]
	[Address(RVA = "0x547730", Offset = "0x546730", VA = "0x180547730")]
	private void bha(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000299")]
	[Address(RVA = "0x547830", Offset = "0x546830", VA = "0x180547830")]
	public void bhb()
	{
		ly jun = hw.jun;
		int type = 0;
		iw ok = goj;
		string ior = hd.ior;
		jun.dbd(ior, ok, type);
	}

	[Token(Token = "0x600029A")]
	[Address(RVA = "0x547900", Offset = "0x546900", VA = "0x180547900")]
	public void bhc(jk f)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600029B")]
	[Address(RVA = "0x548070", Offset = "0x547070", VA = "0x180548070")]
	public bool bhd(string strName)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600029C")]
	[Address(RVA = "0x548180", Offset = "0x547180", VA = "0x180548180")]
	public void bhe()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600029D")]
	[Address(RVA = "0x548900", Offset = "0x547900", VA = "0x180548900")]
	private void bhf(int index)
	{
		mo.nsx = index;
		bhg();
	}

	[Token(Token = "0x600029E")]
	[Address(RVA = "0x548980", Offset = "0x547980", VA = "0x180548980")]
	public void bhg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600029F")]
	[Address(RVA = "0x548CB0", Offset = "0x547CB0", VA = "0x180548CB0")]
	private void bhh(string friendName)
	{
		string izi = hd.izi;
		iw cmdYes = new iw(hd.imy, this, 1);
		iw cmdNo = new iw(hd.inj, 1);
		hw.cec(izi, cmdYes, cmdNo);
	}

	[Token(Token = "0x60002A0")]
	[Address(RVA = "0x546C90", Offset = "0x545C90", VA = "0x180546C90", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002A1")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002A2")]
	[Address(RVA = "0x548DE0", Offset = "0x547DE0", VA = "0x180548DE0", Slot = "9")]
	public override void close()
	{
		int num = 0;
		mo.ddt().deq();
		base.close();
		Object.Destroy(hlf);
		Object.Destroy(gom);
	}

	[Token(Token = "0x60002A3")]
	[Address(RVA = "0x546B10", Offset = "0x545B10", VA = "0x180546B10")]
	static dj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
