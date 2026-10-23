using System;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200010C")]
public class kg
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40010D1")]
	public sbyte lqm;

	[FieldOffset(Offset = "0x11")]
	[Token(Token = "0x40010D2")]
	public sbyte lqn;

	[FieldOffset(Offset = "0x12")]
	[Token(Token = "0x40010D3")]
	public sbyte lqo;

	[FieldOffset(Offset = "0x13")]
	[Token(Token = "0x40010D4")]
	public sbyte lqp;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x40010D5")]
	public sbyte lqq;

	[FieldOffset(Offset = "0x16")]
	[Token(Token = "0x40010D6")]
	public short lqr;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40010D7")]
	public short lqs;

	[FieldOffset(Offset = "0x1A")]
	[Token(Token = "0x40010D8")]
	public short lqt;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x40010D9")]
	public int lqu;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40010DA")]
	public string lqv;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40010DB")]
	public Sprite[] lqw;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40010DC")]
	public jj[][] lqx;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40010DD")]
	public short[] lqy;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40010DE")]
	public bool lqz;

	[Token(Token = "0x40010DF")]
	public static sbyte lra;

	[Token(Token = "0x40010E0")]
	public static sbyte lrb;

	[Token(Token = "0x40010E1")]
	public static sbyte lrc;

	[Token(Token = "0x40010E2")]
	public static sbyte lrd;

	[Token(Token = "0x40010E3")]
	public static sbyte lre;

	[Token(Token = "0x60007D0")]
	[Address(RVA = "0x1EDA30", Offset = "0x1ECA30", VA = "0x1801EDA30")]
	public Sprite ckf(int index)
	{
		return lqw[index];
	}

	[Token(Token = "0x60007D1")]
	[Address(RVA = "0x1EEAA0", Offset = "0x1EDAA0", VA = "0x1801EEAA0")]
	public void clearSprite()
	{
		//IL_0046: Expected Obj, but got I4
		//IL_004d: Expected Obj, but got I4
		//IL_0054: Expected Obj, but got I4
		//IL_0033: Expected Obj, but got I4
		if ((long)lqw != 0)
		{
			GC.KeepAlive("clearSprite");
			Sprite[] array = lqw;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			if (num2 < array.Length)
			{
				array[0] = (Sprite)num3;
				num++;
				Sprite[] array2 = lqw;
			}
			lqw = (Sprite[])num3;
			lqx = (jj[][])num3;
			lqy = (short[])num3;
		}
	}

	[Token(Token = "0x60007D2")]
	[Address(RVA = "0x1EDA70", Offset = "0x1ECA70", VA = "0x1801EDA70")]
	public void ckg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007D3")]
	[Address(RVA = "0x1EDBD0", Offset = "0x1ECBD0", VA = "0x1801EDBD0")]
	public bool ckh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007D4")]
	[Address(RVA = "0x1EDC10", Offset = "0x1ECC10", VA = "0x1801EDC10")]
	public void cki(sbyte[] data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007D5")]
	[Address(RVA = "0x1EDCD0", Offset = "0x1ECCD0", VA = "0x1801EDCD0")]
	public void ckj(e dis0)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007D6")]
	[Address(RVA = "0x1EE9D0", Offset = "0x1ED9D0", VA = "0x1801EE9D0")]
	public bool ckk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007D7")]
	[Address(RVA = "0x1EE9F0", Offset = "0x1ED9F0", VA = "0x1801EE9F0")]
	public bool ckl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007D8")]
	[Address(RVA = "0x1EEA40", Offset = "0x1EDA40", VA = "0x1801EEA40")]
	public bool ckm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007D9")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public kg()
	{
	}

	[Token(Token = "0x60007DA")]
	[Address(RVA = "0x1ED9B0", Offset = "0x1EC9B0", VA = "0x1801ED9B0")]
	static kg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
