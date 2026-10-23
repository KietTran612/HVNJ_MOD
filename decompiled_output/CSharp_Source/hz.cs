using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000D3")]
public class hz : fi
{
	[Token(Token = "0x20000D4")]
	private class hy : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000C57")]
		private hz jxw;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000C58")]
		private sbyte jxx;

		[Token(Token = "0x60006C8")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public hy(hz me, sbyte t)
		{
			jxw = me;
			jxx = t;
		}

		[Token(Token = "0x60006C9")]
		[Address(RVA = "0x279E30", Offset = "0x278E30", VA = "0x180279E30", Slot = "4")]
		public void th()
		{
			hz hz2 = jxw;
			sbyte b = jxx;
			hz2.cel(b);
		}
	}

	[Token(Token = "0x4000C4D")]
	private static hz jxy;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000C4E")]
	private List<jk> jxz;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000C4F")]
	private int jya = 200;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000C50")]
	private int jyb = 200;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000C51")]
	private int jyc;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000C52")]
	private int jyd;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000C53")]
	private ScrollRect jye;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000C54")]
	private hm jyf;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000C55")]
	private GameObject jyg;

	[Token(Token = "0x4000C56")]
	public static bool jyh;

	[Token(Token = "0x60006BE")]
	[Address(RVA = "0x364E20", Offset = "0x363E20", VA = "0x180364E20")]
	public static hz cek()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		hz hz2 = new hz();
		hz2.jya = 200;
		hz2.jyb = 200;
		jxy = hz2;
		return hz2;
	}

	[Token(Token = "0x60006BF")]
	[Address(RVA = "0x3659D0", Offset = "0x3649D0", VA = "0x1803659D0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006C0")]
	[Address(RVA = "0x364D40", Offset = "0x363D40", VA = "0x180364D40", Slot = "6")]
	public override void bcd()
	{
		int num = 0;
		mo mo2 = mo.ddt();
		GameObject gameObject = jyg;
		if ((long)mo.nex == 0)
		{
			int active = 0;
			gameObject.SetActive((byte)active != 0);
			return;
		}
		gameObject.SetActive(value: true);
		hm hm2 = jyf;
		int num2 = 0;
		string kvh = mo.ddt().odd.kvh;
		hm2.bxn(kvh);
	}

	[Token(Token = "0x60006C1")]
	[Address(RVA = "0x364F50", Offset = "0x363F50", VA = "0x180364F50")]
	private void cel(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006C2")]
	[Address(RVA = "0x365060", Offset = "0x364060", VA = "0x180365060")]
	public void cem()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006C3")]
	[Address(RVA = "0x365620", Offset = "0x364620", VA = "0x180365620")]
	public void cen(string title, string str, bool withMenuShow)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006C4")]
	[Address(RVA = "0x365840", Offset = "0x364840", VA = "0x180365840")]
	public void ceo()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006C5")]
	[Address(RVA = "0x365920", Offset = "0x364920", VA = "0x180365920", Slot = "9")]
	public override void close()
	{
		base.close();
		int num = 0;
		mo.ddt().deq();
		Object.Destroy(hlf);
	}

	[Token(Token = "0x60006C6")]
	[Address(RVA = "0x364CE0", Offset = "0x363CE0", VA = "0x180364CE0")]
	public hz()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}

	[Token(Token = "0x60006C7")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static hz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
