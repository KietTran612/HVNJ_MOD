using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000A2")]
public class gi : fi
{
	[Token(Token = "0x20000A3")]
	private class gg : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000724")]
		private gi hzo;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000725")]
		private int hzp;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000726")]
		private sbyte hzq;

		[Token(Token = "0x60004D1")]
		[Address(RVA = "0x278B30", Offset = "0x277B30", VA = "0x180278B30")]
		public gg(gi me, sbyte t, int index)
		{
			hzo = me;
			hzq = t;
			hzp = index;
		}

		[Token(Token = "0x60004D2")]
		[Address(RVA = "0x278F10", Offset = "0x277F10", VA = "0x180278F10", Slot = "4")]
		public void th()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x20000A4")]
	private class gh : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000727")]
		private gi hzr;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000728")]
		private sbyte hzs;

		[Token(Token = "0x60004D3")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gh(gi me, sbyte t)
		{
			hzr = me;
			hzs = t;
		}

		[Token(Token = "0x60004D4")]
		[Address(RVA = "0x278F40", Offset = "0x277F40", VA = "0x180278F40", Slot = "4")]
		public void th()
		{
			gi gi2 = hzr;
			sbyte b = hzs;
			gi2.bro(b);
		}
	}

	[Token(Token = "0x4000709")]
	private static gi hzt;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400070A")]
	private int hzu = 180;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400070B")]
	private int hzv = 220;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400070C")]
	private int hzw;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400070D")]
	private int hzx;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400070E")]
	private int hzy;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x400070F")]
	private int hzz;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000710")]
	private int iaa;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000711")]
	private int iab;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000712")]
	private int iac;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000713")]
	private ScrollRect iad;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000714")]
	private ScrollRect iae;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000715")]
	private hm iaf;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000716")]
	private GameObject iag;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000717")]
	private GameObject iah;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000718")]
	private GameObject iai;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000719")]
	private Vector2 iaj;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400071A")]
	private Vector2 iak;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x400071B")]
	private RectTransform ial;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400071C")]
	private jr iam;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400071D")]
	private jr[] ian;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x400071E")]
	private GameObject iao;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x400071F")]
	private GameObject iap;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000720")]
	private GameObject iaq;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000721")]
	private GameObject iar;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000722")]
	private GameObject ias;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4000723")]
	private List<jr> iat;

	[Token(Token = "0x60004C3")]
	[Address(RVA = "0x786160", Offset = "0x785160", VA = "0x180786160")]
	public static gi bri()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		gi gi2 = hzt;
		if (gi2 == null)
		{
			gi gi3 = new gi();
			gi3.hzu = 180;
			gi3.hzv = 220;
			hzt = gi3;
		}
		return gi2;
	}

	[Token(Token = "0x60004C4")]
	[Address(RVA = "0x788A70", Offset = "0x787A70", VA = "0x180788A70")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004C5")]
	[Address(RVA = "0x786220", Offset = "0x785220", VA = "0x180786220")]
	private void brj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004C6")]
	[Address(RVA = "0x786CE0", Offset = "0x785CE0", VA = "0x180786CE0")]
	private void brk(int type, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004C7")]
	[Address(RVA = "0x787140", Offset = "0x786140", VA = "0x180787140")]
	private bool brl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004C8")]
	[Address(RVA = "0x7871A0", Offset = "0x7861A0", VA = "0x1807871A0")]
	private void brm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004C9")]
	[Address(RVA = "0x787B00", Offset = "0x786B00", VA = "0x180787B00")]
	public string brn(string name)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004CA")]
	[Address(RVA = "0x7860E0", Offset = "0x7850E0", VA = "0x1807860E0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004CB")]
	[Address(RVA = "0x787F80", Offset = "0x786F80", VA = "0x180787F80")]
	private void bro(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004CC")]
	[Address(RVA = "0x7899B0", Offset = "0x7889B0", VA = "0x1807899B0")]
	public void tinhLuyenSuccess()
	{
		//IL_0024: Expected Obj, but got I8
		GC.KeepAlive("tinhLuyenSuccess");
		hw.cdt(hd.jjm);
		GameObject obj = iap;
		iam = (jr)0;
		UnityEngine.Object.Destroy(obj);
		UnityEngine.Object.Destroy(iaq);
		brj();
		brm();
	}

	[Token(Token = "0x60004CD")]
	[Address(RVA = "0x788070", Offset = "0x787070", VA = "0x180788070")]
	private void brp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004CE")]
	[Address(RVA = "0x7887D0", Offset = "0x7877D0", VA = "0x1807887D0")]
	private GameObject brq(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004CF")]
	[Address(RVA = "0x7889F0", Offset = "0x7879F0", VA = "0x1807889F0", Slot = "9")]
	public override void close()
	{
		//IL_0014: Expected Obj, but got I4
		//IL_001b: Expected Obj, but got I4
		//IL_0022: Expected Obj, but got I4
		UnityEngine.Object.Destroy(hlf);
		int num = 0;
		ian = (jr[])num;
		iat = (List<jr>)num;
		iam = (jr)num;
		base.close();
	}

	[Token(Token = "0x60004D0")]
	[Address(RVA = "0x786080", Offset = "0x785080", VA = "0x180786080")]
	public gi()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
