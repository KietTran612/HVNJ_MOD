using System;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200006B")]
public class ef : fi
{
	[Token(Token = "0x4000414")]
	private static ef gwm;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000415")]
	private int gwn = 280;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000416")]
	private int gwo = 240;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000417")]
	private int gwp;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000418")]
	private int gwq;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000419")]
	private int gwr;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x400041A")]
	private int gws;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400041B")]
	private int gwt;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x400041C")]
	private int gwu;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400041D")]
	private GameObject gwv;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400041E")]
	private ScrollRect gww;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400041F")]
	private Sprite[] gwx;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000420")]
	private GameObject gwy;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000421")]
	private GameObject gwz;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000422")]
	private GameObject gxa;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000423")]
	private Image[] gxb;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000424")]
	private short gxc;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000425")]
	private GameObject gxd;

	[Token(Token = "0x600031E")]
	[Address(RVA = "0x45B830", Offset = "0x45A830", VA = "0x18045B830")]
	public static ef bjh()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		ef ef2 = gwm;
		if (ef2 == null)
		{
			ef ef3 = new ef();
			ef3.gwn = 280;
			ef3.gwo = 240;
			gwm = ef3;
		}
		return ef2;
	}

	[Token(Token = "0x600031F")]
	[Address(RVA = "0x45D620", Offset = "0x45C620", VA = "0x18045D620")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000320")]
	[Address(RVA = "0x45B8F0", Offset = "0x45A8F0", VA = "0x18045B8F0")]
	public void bji()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0023: Expected Obj, but got I4
		GameObject gameObject = hlf;
		int num = 0;
		if (!(gameObject == (UnityEngine.Object)num))
		{
			GameObject gameObject2 = gxd;
			int num2 = 0;
			if (gameObject2 != (UnityEngine.Object)num2)
			{
				UnityEngine.Object.Destroy(gxd);
			}
			int num3 = 0;
			gxc = (short)num3;
			bjj();
		}
	}

	[Token(Token = "0x6000321")]
	[Address(RVA = "0x45B9D0", Offset = "0x45A9D0", VA = "0x18045B9D0")]
	public void bjj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000322")]
	[Address(RVA = "0x45C750", Offset = "0x45B750", VA = "0x18045C750")]
	private void bjk(short index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000323")]
	[Address(RVA = "0x45B730", Offset = "0x45A730", VA = "0x18045B730", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000324")]
	[Address(RVA = "0x45B7B0", Offset = "0x45A7B0", VA = "0x18045B7B0", Slot = "8")]
	public override void bcf()
	{
		close();
		int num = 0;
		mo.ddt().deq();
	}

	[Token(Token = "0x6000325")]
	[Address(RVA = "0x45D580", Offset = "0x45C580", VA = "0x18045D580", Slot = "9")]
	public override void close()
	{
		//IL_0025: Expected Obj, but got I4
		//IL_002c: Expected Obj, but got I4
		base.close();
		UnityEngine.Object.Destroy(hlf);
		UnityEngine.Object.Destroy(gwz);
		int num = 0;
		hlf = (GameObject)num;
		gwx = (Sprite[])num;
		GC.KeepAlive("close");
	}

	[Token(Token = "0x6000326")]
	[Address(RVA = "0x45B6D0", Offset = "0x45A6D0", VA = "0x18045B6D0")]
	public ef()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
