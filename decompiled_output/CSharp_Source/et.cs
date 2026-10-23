using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000077")]
public class et : ms
{
	[Token(Token = "0x2000078")]
	private class er : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40004D2")]
		private et hcx;

		[Token(Token = "0x600038B")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public er(et me)
		{
			hcx = me;
		}

		[Token(Token = "0x600038C")]
		[Address(RVA = "0x2787A0", Offset = "0x2777A0", VA = "0x1802787A0", Slot = "4")]
		public void th()
		{
			hcx.blh();
		}
	}

	[Token(Token = "0x2000079")]
	private class es : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40004D3")]
		private et hcy;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40004D4")]
		private sbyte hcz;

		[Token(Token = "0x600038D")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public es(et me, sbyte ind)
		{
			hcy = me;
			hcz = ind;
		}

		[Token(Token = "0x600038E")]
		[Address(RVA = "0x2787C0", Offset = "0x2777C0", VA = "0x1802787C0", Slot = "4")]
		public void th()
		{
			et et2 = hcy;
			sbyte index = hcz;
			et2.bli(index);
		}
	}

	[Token(Token = "0x40004BB")]
	public static et hda;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40004BC")]
	public List<iw> hdb;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40004BD")]
	public int hdc;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x40004BE")]
	public int hdd;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40004BF")]
	public int hde;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x40004C0")]
	public int hdf;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40004C1")]
	public int hdg;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x40004C2")]
	public int hdh;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40004C3")]
	private bool hdi;

	[FieldOffset(Offset = "0x79")]
	[Token(Token = "0x40004C4")]
	private bool hdj;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40004C5")]
	private GameObject hdk;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40004C6")]
	private bool hdl;

	[Token(Token = "0x40004C7")]
	private static sbyte[][] hdm;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40004C8")]
	private RectTransform hdn;

	[Token(Token = "0x40004C9")]
	public static float hdo;

	[Token(Token = "0x40004CA")]
	public static float hdp;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x40004CB")]
	public int hdq;

	[FieldOffset(Offset = "0x9C")]
	[Token(Token = "0x40004CC")]
	public int hdr;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40004CD")]
	public int hds;

	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x40004CE")]
	public int hdt;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x40004CF")]
	private int hdu;

	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x40004D0")]
	private int hdv;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40004D1")]
	public bool[] hdw;

	[Token(Token = "0x6000381")]
	[Address(RVA = "0x6120C0", Offset = "0x6110C0", VA = "0x1806120C0")]
	public static et blf()
	{
		return hda = new et();
	}

	[Token(Token = "0x6000382")]
	[Address(RVA = "0x6121A0", Offset = "0x6111A0", VA = "0x1806121A0")]
	public void blg(List<iw> menuItems, sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000383")]
	[Address(RVA = "0x612990", Offset = "0x611990", VA = "0x180612990")]
	private void initUI(sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000384")]
	[Address(RVA = "0x612380", Offset = "0x611380", VA = "0x180612380")]
	private void blh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000385")]
	[Address(RVA = "0x6123A0", Offset = "0x6113A0", VA = "0x1806123A0")]
	private void bli(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000386")]
	[Address(RVA = "0x612470", Offset = "0x611470", VA = "0x180612470")]
	public void blj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000387")]
	[Address(RVA = "0x6125E0", Offset = "0x6115E0", VA = "0x1806125E0", Slot = "6")]
	public override void blk()
	{
		//IL_0017: Expected Obj, but got I4
		GameObject gameObject = hdk;
		hfw = false;
		int num = 0;
		if (gameObject != (Object)num)
		{
			Object.Destroy(hdk);
		}
		base.blk();
	}

	[Token(Token = "0x6000388")]
	[Address(RVA = "0x612690", Offset = "0x611690", VA = "0x180612690", Slot = "5")]
	public override void bll()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000389")]
	[Address(RVA = "0x44BC20", Offset = "0x44AC20", VA = "0x18044BC20")]
	public et()
	{
	}

	[Token(Token = "0x600038A")]
	[Address(RVA = "0x611D30", Offset = "0x610D30", VA = "0x180611D30")]
	static et()
	{
		//IL_0029: Expected I4, but got Obj
		//IL_0041: Expected I4, but got I8
		//IL_004c: Expected I4, but got I8
		//IL_0058: Expected I4, but got Obj
		//IL_007f: Expected I4, but got Obj
		//IL_00a9: Expected I4, but got Obj
		//IL_00d3: Expected I4, but got Obj
		//IL_00fd: Expected I4, but got Obj
		sbyte[][] array;
		sbyte[] array7;
		while (true)
		{
			array = new sbyte[6][];
			sbyte[] array2 = new sbyte[7] { 0, 1, 9, 8, 4, 5, 6 };
			if (array2 != null && array2 == null)
			{
				continue;
			}
			((sbyte[])(object)array)[0] = (sbyte)(int)array2;
			sbyte[] array3 = new sbyte[2];
			int length = array3.Length;
			array3[0] = 7;
			array3[0] = 9;
			if (length == 0)
			{
				continue;
			}
			((sbyte[])(object)array)[1] = (sbyte)(int)array3;
			sbyte[] array4 = new sbyte[6] { 11, 12, 13, 14, 15, 16 };
			if (array4 != null && array4 == null)
			{
				continue;
			}
			((sbyte[])(object)array)[2] = (sbyte)(int)array4;
			sbyte[] array5 = new sbyte[6] { 1, 9, 8, 4, 5, 6 };
			if (array5 != null && array5 == null)
			{
				continue;
			}
			((sbyte[])(object)array)[3] = (sbyte)(int)array5;
			sbyte[] array6 = new sbyte[3] { 16, 13, 3 };
			if (array6 == null || array6 != null)
			{
				((sbyte[])(object)array)[4] = (sbyte)(int)array6;
				array7 = new sbyte[5] { 1, 9, 4, 5, 6 };
				if (array7 == null || array7 != null)
				{
					break;
				}
			}
		}
		((sbyte[])(object)array)[5] = (sbyte)(int)array7;
		hdm = array;
	}
}
