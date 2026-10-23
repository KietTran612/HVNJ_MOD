using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000AB")]
public class gq : fi
{
	[Token(Token = "0x20000AC")]
	private class go : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007A9")]
		private gq iep;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40007AA")]
		private sbyte ieq;

		[Token(Token = "0x6000517")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public go(gq me, sbyte t)
		{
			iep = me;
			ieq = t;
		}

		[Token(Token = "0x6000518")]
		[Address(RVA = "0x279000", Offset = "0x278000", VA = "0x180279000", Slot = "4")]
		public void th()
		{
			gq gq2 = iep;
			sbyte b = ieq;
			gq2.bst(b);
		}
	}

	[Token(Token = "0x20000AD")]
	private class gp : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40007AB")]
		private gq ier;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40007AC")]
		private int ies;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40007AD")]
		private sbyte iet;

		[Token(Token = "0x6000519")]
		[Address(RVA = "0x278B30", Offset = "0x277B30", VA = "0x180278B30")]
		public gp(gq me, sbyte t, int index)
		{
			ier = me;
			iet = t;
			ies = index;
		}

		[Token(Token = "0x600051A")]
		[Address(RVA = "0x279030", Offset = "0x278030", VA = "0x180279030", Slot = "4")]
		public void th()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x400078C")]
	private static gq ieu;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400078D")]
	private int iev = 180;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400078E")]
	private int iew = 220;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400078F")]
	private int iex;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000790")]
	private int iey;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000791")]
	private int iez;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000792")]
	private int ifa;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000793")]
	private int ifb;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000794")]
	private int ifc;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000795")]
	private int ifd;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000796")]
	private ScrollRect ife;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000797")]
	private ScrollRect iff;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000798")]
	private hm ifg;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000799")]
	private GameObject ifh;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x400079A")]
	private GameObject ifi;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x400079B")]
	private GameObject ifj;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x400079C")]
	private Vector2 ifk;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400079D")]
	private Vector2 ifl;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x400079E")]
	private RectTransform ifm;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400079F")]
	private jr ifn;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x40007A0")]
	private jr[] ifo;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x40007A1")]
	private GameObject ifp;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x40007A2")]
	private GameObject ifq;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x40007A3")]
	private GameObject[] ifr;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x40007A4")]
	private GameObject ifs;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x40007A5")]
	private List<jr> ift;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40007A6")]
	private GameObject ifu;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40007A7")]
	private GameObject ifv;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40007A8")]
	private GameObject ifw;

	[Token(Token = "0x6000509")]
	[Address(RVA = "0x793E70", Offset = "0x792E70", VA = "0x180793E70")]
	public static gq bss()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		gq gq2 = ieu;
		if (gq2 == null)
		{
			gq gq3 = new gq();
			gq3.iev = 180;
			gq3.iew = 220;
			ieu = gq3;
		}
		return gq2;
	}

	[Token(Token = "0x600050A")]
	[Address(RVA = "0x797210", Offset = "0x796210", VA = "0x180797210")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600050B")]
	[Address(RVA = "0x793DF0", Offset = "0x792DF0", VA = "0x180793DF0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600050C")]
	[Address(RVA = "0x793F30", Offset = "0x792F30", VA = "0x180793F30")]
	private void bst(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600050D")]
	[Address(RVA = "0x794020", Offset = "0x793020", VA = "0x180794020")]
	private void bsu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600050E")]
	[Address(RVA = "0x7947F0", Offset = "0x7937F0", VA = "0x1807947F0")]
	private void bsv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600050F")]
	[Address(RVA = "0x795970", Offset = "0x794970", VA = "0x180795970")]
	private void bsw(int type, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000510")]
	[Address(RVA = "0x798140", Offset = "0x797140", VA = "0x180798140")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000511")]
	[Address(RVA = "0x795DE0", Offset = "0x794DE0", VA = "0x180795DE0")]
	private GameObject bsx(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000512")]
	[Address(RVA = "0x796000", Offset = "0x795000", VA = "0x180796000")]
	private bool bsy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000513")]
	[Address(RVA = "0x796320", Offset = "0x795320", VA = "0x180796320")]
	private void bsz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000514")]
	[Address(RVA = "0x7970F0", Offset = "0x7960F0", VA = "0x1807970F0")]
	public void bta()
	{
		//IL_001f: Expected Obj, but got I8
		Object.Destroy(ifu);
		Object.Destroy(ifv);
		ifn = (jr)0;
		bsv();
		bsz();
	}

	[Token(Token = "0x6000515")]
	[Address(RVA = "0x797180", Offset = "0x796180", VA = "0x180797180", Slot = "9")]
	public override void close()
	{
		//IL_0014: Expected Obj, but got I4
		//IL_001b: Expected Obj, but got I4
		//IL_0022: Expected Obj, but got I4
		//IL_0029: Expected Obj, but got I4
		Object.Destroy(hlf);
		int num = 0;
		ifo = (jr[])num;
		ift = (List<jr>)num;
		ifn = (jr)num;
		ifr = (GameObject[])num;
		base.close();
	}

	[Token(Token = "0x6000516")]
	[Address(RVA = "0x793D90", Offset = "0x792D90", VA = "0x180793D90")]
	public gq()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
