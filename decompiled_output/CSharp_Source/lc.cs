using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000124")]
public class lc
{
	[Token(Token = "0x40011DF")]
	public const sbyte maz = 0;

	[Token(Token = "0x40011E0")]
	public const sbyte mba = 1;

	[Token(Token = "0x40011E1")]
	public const sbyte mbb = 2;

	[Token(Token = "0x40011E2")]
	public const sbyte mbc = 3;

	[Token(Token = "0x40011E3")]
	public const sbyte mbd = 0;

	[Token(Token = "0x40011E4")]
	public const sbyte mbe = 1;

	[Token(Token = "0x40011E5")]
	public const sbyte mbf = 2;

	[Token(Token = "0x40011E6")]
	public const sbyte mbg = 3;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40011E7")]
	public string mbh;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40011E8")]
	public sbyte mbi;

	[FieldOffset(Offset = "0x19")]
	[Token(Token = "0x40011E9")]
	public sbyte mbj;

	[FieldOffset(Offset = "0x1A")]
	[Token(Token = "0x40011EA")]
	public sbyte mbk;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x40011EB")]
	public float mbl;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40011EC")]
	public float mbm;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x40011ED")]
	public float mbn;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40011EE")]
	public float mbo;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x40011EF")]
	public float mbp;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40011F0")]
	public float mbq;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40011F1")]
	public Sprite mbr;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40011F2")]
	public Sprite[] mbs;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40011F3")]
	public Image mbt;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40011F4")]
	public sbyte mbu;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40011F5")]
	public i mbv;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40011F6")]
	public bool mbw;

	[FieldOffset(Offset = "0x61")]
	[Token(Token = "0x40011F7")]
	public bool mbx;

	[FieldOffset(Offset = "0x62")]
	[Token(Token = "0x40011F8")]
	public sbyte mby;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x40011F9")]
	public int mbz;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40011FA")]
	public int mca;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x40011FB")]
	public int mcb;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40011FC")]
	public hm mcc;

	[Token(Token = "0x6000828")]
	[Address(RVA = "0x1FFAC0", Offset = "0x1FEAC0", VA = "0x1801FFAC0")]
	public lc(int colorLine, sbyte font, float x, float y)
	{
		//IL_0022: Expected F4, but got I4
		//IL_002b: Expected I4, but got I8
		mbl = x;
		mbi = font;
		mcb = colorLine;
		mbm = 0f;
		mbj = 3;
	}

	[Token(Token = "0x6000829")]
	[Address(RVA = "0x1FFE00", Offset = "0x1FEE00", VA = "0x1801FFE00")]
	public lc(string text, sbyte font, float x, float y)
	{
		//IL_001b: Expected F4, but got I4
		//IL_002b: Expected I4, but got I8
		mbl = x;
		mbh = text;
		mbm = 0f;
		mbi = font;
		mbj = 0;
	}

	[Token(Token = "0x600082A")]
	[Address(RVA = "0x1FFCB0", Offset = "0x1FECB0", VA = "0x1801FFCB0")]
	public lc(string text, sbyte font, int color, float x, float y, bool isA)
	{
		//IL_001b: Expected F4, but got I4
		//IL_0022: Expected F4, but got I4
		//IL_0039: Expected I4, but got I8
		mbh = text;
		mbz = color;
		mbl = 0f;
		mbm = 0f;
		mbw = false;
		mbi = font;
		mbj = 0;
	}

	[Token(Token = "0x600082B")]
	[Address(RVA = "0x1FFB20", Offset = "0x1FEB20", VA = "0x1801FFB20")]
	public lc(string text, sbyte font, int color, int colorBg, float x, float y, bool isA, sbyte anchor)
	{
		//IL_0030: Expected F4, but got I4
		//IL_0037: Expected F4, but got I4
		mca = 0;
		mbw = false;
		mbh = text;
		mbz = color;
		mbu = 0;
		mbl = 0f;
		mbm = 0f;
		mbi = font;
	}

	[Token(Token = "0x600082C")]
	[Address(RVA = "0x1FFE60", Offset = "0x1FEE60", VA = "0x1801FFE60")]
	public lc(string text, sbyte font, float x, float y, bool isF)
	{
		//IL_001b: Expected F4, but got I4
		//IL_0032: Expected I4, but got I8
		mbl = x;
		mbh = text;
		mbm = 0f;
		mbw = false;
		mbi = font;
		mbj = 0;
	}

	[Token(Token = "0x600082D")]
	[Address(RVA = "0x1FFD90", Offset = "0x1FED90", VA = "0x1801FFD90")]
	public lc(Sprite spr, float x, float y, float w, float h, i action)
	{
		//IL_0022: Expected F4, but got I4
		//IL_0029: Expected F4, but got I4
		//IL_0030: Expected Obj, but got I4
		//IL_0039: Expected I4, but got I8
		mbl = x;
		mbm = y;
		mbr = spr;
		mbn = 0f;
		mbo = 0f;
		mbv = (i)0;
		mbj = 2;
	}

	[Token(Token = "0x600082E")]
	[Address(RVA = "0x1FFC40", Offset = "0x1FEC40", VA = "0x1801FFC40")]
	public lc(string text, sbyte font, float x, float y, sbyte anchor)
	{
		//IL_001b: Expected F4, but got I4
		//IL_0032: Expected I4, but got I8
		mbl = x;
		mbh = text;
		mbm = 0f;
		mbu = 0;
		mbi = font;
		mbj = 0;
	}

	[Token(Token = "0x600082F")]
	[Address(RVA = "0x1FFBF0", Offset = "0x1FEBF0", VA = "0x1801FFBF0")]
	public lc(Sprite spr, float x, float y)
	{
		//IL_0024: Expected I4, but got I8
		mbl = x;
		mbm = y;
		mbr = spr;
		mbj = 1;
	}

	[Token(Token = "0x6000830")]
	[Address(RVA = "0x1FFD20", Offset = "0x1FED20", VA = "0x1801FFD20")]
	public lc(Sprite spr, float x, float y, float w, float h)
	{
		//IL_0022: Expected F4, but got I4
		//IL_0029: Expected F4, but got I4
		//IL_0032: Expected I4, but got I8
		mbl = x;
		mbm = y;
		mbr = spr;
		mbn = 0f;
		mbo = 0f;
		mbj = 1;
	}

	[Token(Token = "0x6000831")]
	[Address(RVA = "0x1FFBA0", Offset = "0x1FEBA0", VA = "0x1801FFBA0")]
	public lc(Sprite[] spr, float x, float y)
	{
		//IL_0024: Expected I4, but got I8
		mbl = x;
		mbm = y;
		mbs = spr;
		mbj = 1;
	}

	[Token(Token = "0x6000832")]
	[Address(RVA = "0x1FFED0", Offset = "0x1FEED0", VA = "0x1801FFED0")]
	public void cly(bool isChop)
	{
		//IL_001b: Expected Obj, but got I4
		if ((long)mbs != 0)
		{
			Image image = mbt;
			int num = 0;
			if (image != (Object)num)
			{
				Image image2 = mbt;
				Sprite sprite = mbs[isChop ? 1u : 0u];
				image2.sprite = sprite;
			}
		}
	}
}
