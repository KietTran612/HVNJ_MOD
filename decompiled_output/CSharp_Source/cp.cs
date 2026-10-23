using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000044")]
public class cp : fi
{
	[Token(Token = "0x2000045")]
	private class co : i
	{
		[Token(Token = "0x4000262")]
		public static sbyte gfg;

		[Token(Token = "0x4000263")]
		public static sbyte gfh;

		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000264")]
		private cp gfi;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000265")]
		private sbyte gfj;

		[FieldOffset(Offset = "0x19")]
		[Token(Token = "0x4000266")]
		private sbyte gfk;

		[Token(Token = "0x6000219")]
		[Address(RVA = "0x277EB0", Offset = "0x276EB0", VA = "0x180277EB0")]
		public co(cp me, sbyte t, sbyte index)
		{
			gfi = me;
			gfj = index;
			gfk = t;
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0x277F00", Offset = "0x276F00", VA = "0x180277F00", Slot = "4")]
		public void th()
		{
			cp cp2 = gfi;
			sbyte index = gfj;
			sbyte type = gfk;
			cp2.bel(type, index);
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0x277E60", Offset = "0x276E60", VA = "0x180277E60")]
		static co()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x4000254")]
	public static cp gfl;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000255")]
	private float gfm;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000256")]
	private float gfn;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000257")]
	private List<iw> gfo;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000258")]
	private kk gfp;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000259")]
	private string gfq;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400025A")]
	public string gfr;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400025B")]
	public bool gfs;

	[FieldOffset(Offset = "0x81")]
	[Token(Token = "0x400025C")]
	public bool gft;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400025D")]
	public long gfu;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400025E")]
	public sbyte gfv = -1;

	[Token(Token = "0x400025F")]
	private static Sprite gfw;

	[Token(Token = "0x4000260")]
	private static Sprite gfx;

	[Token(Token = "0x4000261")]
	private static Sprite gfy;

	[Token(Token = "0x6000211")]
	[Address(RVA = "0x580860", Offset = "0x57F860", VA = "0x180580860")]
	public static cp bek()
	{
		//IL_001d: Expected I4, but got I8
		cp cp2 = gfl;
		if (cp2 == null)
		{
			cp cp3 = new cp();
			cp3.gfv = -1;
			gfl = cp3;
		}
		return cp2;
	}

	[Token(Token = "0x6000212")]
	[Address(RVA = "0x582EC0", Offset = "0x581EC0", VA = "0x180582EC0")]
	public void start(string info, string[] menu, kk npc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000213")]
	[Address(RVA = "0x580530", Offset = "0x57F530", VA = "0x180580530", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000214")]
	[Address(RVA = "0x580910", Offset = "0x57F910", VA = "0x180580910")]
	private void bel(sbyte type, sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000215")]
	[Address(RVA = "0x5804B0", Offset = "0x57F4B0", VA = "0x1805804B0", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000216")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000217")]
	[Address(RVA = "0x582DD0", Offset = "0x581DD0", VA = "0x180582DD0", Slot = "9")]
	public override void close()
	{
		//IL_0022: Expected Obj, but got I4
		int num = 0;
		mo.dex();
		GameObject gameObject = hlf;
		gfr = "";
		int num2 = 0;
		if (gameObject != (Object)num2)
		{
			Object.Destroy(hlf);
		}
		base.close();
	}

	[Token(Token = "0x6000218")]
	[Address(RVA = "0x580450", Offset = "0x57F450", VA = "0x180580450")]
	public cp()
	{
		//IL_000d: Expected I4, but got I8
	}
}
