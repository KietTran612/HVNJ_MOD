using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000070")]
public class ek : fi
{
	[Token(Token = "0x4000438")]
	private static ek gxw;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000439")]
	private int gxx = 180;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400043A")]
	private int gxy = 210;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400043B")]
	private int gxz;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400043C")]
	private int gya;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400043D")]
	private GameObject gyb;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400043E")]
	private hm gyc;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400043F")]
	private int gyd;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4000440")]
	private int gye;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000441")]
	private int gyf;

	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4000442")]
	private int gyg;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000443")]
	private int gyh;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000444")]
	private GameObject gyi;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000445")]
	private List<jr> gyj;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000446")]
	private GameObject[] gyk;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000447")]
	private hm gyl;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000448")]
	private hm gym;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000449")]
	private ScrollRectClick gyn;

	[Token(Token = "0x400044A")]
	public static jr[] gyo;

	[Token(Token = "0x400044B")]
	public static bool gyp;

	[Token(Token = "0x400044C")]
	public static bool gyq;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x400044D")]
	private GameObject gyr;

	[Token(Token = "0x6000339")]
	[Address(RVA = "0x45F840", Offset = "0x45E840", VA = "0x18045F840")]
	public static ek bjs()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		ek ek2 = new ek();
		ek2.gxx = 180;
		ek2.gxy = 210;
		gxw = ek2;
		return ek2;
	}

	[Token(Token = "0x600033A")]
	[Address(RVA = "0x45F970", Offset = "0x45E970", VA = "0x18045F970")]
	public void bjt(bool isXu)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600033B")]
	[Address(RVA = "0x4635E0", Offset = "0x4625E0", VA = "0x1804635E0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600033C")]
	[Address(RVA = "0x4641A0", Offset = "0x4631A0", VA = "0x1804641A0")]
	public void updateList()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600033D")]
	[Address(RVA = "0x45FA70", Offset = "0x45EA70", VA = "0x18045FA70")]
	private void bju()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600033E")]
	[Address(RVA = "0x460950", Offset = "0x45F950", VA = "0x180460950")]
	private void bjv(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600033F")]
	[Address(RVA = "0x461270", Offset = "0x460270", VA = "0x180461270")]
	public bool bjw(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000340")]
	[Address(RVA = "0x45F300", Offset = "0x45E300", VA = "0x18045F300")]
	public void actUpPearlMoveOut()
	{
		//IL_0063: Expected Obj, but got I4
		//IL_006e: Expected Obj, but got I4
		//IL_0048: Expected Obj, but got I4
		GC.KeepAlive("actUpPearlMoveOut");
		int num = 0;
		jr[] array = gyo;
		if (num < array.Length)
		{
			jr[] array2 = gyo;
			if (unchecked((nint)"{il2cpp array field local4->}") != num && (gyo[num].lfn ? 1 : 0) == num)
			{
				gyo[0] = (jr)num;
			}
			num++;
		}
		int num2 = 0;
		mo mo2 = mo.ddt();
		int num3 = 0;
		mo.ddt().ode = (iw)num;
		int num4 = 0;
		mo2.odd = (iw)num;
		mo.ddt().dix();
	}

	[Token(Token = "0x6000341")]
	[Address(RVA = "0x45F7C0", Offset = "0x45E7C0", VA = "0x18045F7C0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000342")]
	[Address(RVA = "0x461670", Offset = "0x460670", VA = "0x180461670")]
	public void bjx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000343")]
	[Address(RVA = "0x462140", Offset = "0x461140", VA = "0x180462140")]
	public void bjy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000344")]
	[Address(RVA = "0x463280", Offset = "0x462280", VA = "0x180463280")]
	public bool bjz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000345")]
	[Address(RVA = "0x463410", Offset = "0x462410", VA = "0x180463410")]
	private bool bka()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000346")]
	[Address(RVA = "0x45F510", Offset = "0x45E510", VA = "0x18045F510", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000347")]
	[Address(RVA = "0x4634F0", Offset = "0x4624F0", VA = "0x1804634F0", Slot = "9")]
	public override void close()
	{
		base.close();
		int num = 0;
		mo.ddt().deq();
		((List<T>)(object)gyj).Clear();
		UnityEngine.Object.Destroy(gyr);
		UnityEngine.Object.Destroy(hlf);
	}

	[Token(Token = "0x6000348")]
	[Address(RVA = "0x45F2A0", Offset = "0x45E2A0", VA = "0x18045F2A0")]
	public ek()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}

	[Token(Token = "0x6000349")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static ek()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
