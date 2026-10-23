using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000089")]
public class fk : fi
{
	[Token(Token = "0x200008A")]
	private class fj : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40005A9")]
		private fk hlr;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40005AA")]
		private sbyte hls;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40005AB")]
		private int hlt;

		[Token(Token = "0x6000401")]
		[Address(RVA = "0x278390", Offset = "0x277390", VA = "0x180278390")]
		public fj(fk me, sbyte t, int index)
		{
			hlr = me;
			hls = t;
			hlt = index;
		}

		[Token(Token = "0x6000402")]
		[Address(RVA = "0x278A70", Offset = "0x277A70", VA = "0x180278A70", Slot = "4")]
		public void th()
		{
			fk fk2 = hlr;
			int index = hlt;
			sbyte b = hls;
			fk2.bne(b, index);
		}
	}

	[Token(Token = "0x400059F")]
	private static fk hlu;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40005A0")]
	private List<jl> hlv;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40005A1")]
	private int hlw;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x40005A2")]
	private int hlx;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40005A3")]
	private int hly;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x40005A4")]
	private int hlz;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40005A5")]
	private ScrollRect hma;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40005A6")]
	private GameObject hmb;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40005A7")]
	private GameObject hmc;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40005A8")]
	private sbyte hmd;

	[Token(Token = "0x60003F9")]
	[Address(RVA = "0x49F430", Offset = "0x49E430", VA = "0x18049F430")]
	public static fk bnd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003FA")]
	[Address(RVA = "0x4A10C0", Offset = "0x4A00C0", VA = "0x1804A10C0")]
	public void init(string title, sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003FB")]
	[Address(RVA = "0x4A0FC0", Offset = "0x49FFC0", VA = "0x1804A0FC0", Slot = "9")]
	public override void close()
	{
		//IL_0014: Expected Obj, but got I4
		//IL_0026: Expected Obj, but got I4
		Object.Destroy(hlf);
		int num = 0;
		hmc = (GameObject)num;
		int num2 = 0;
		mo.ddt().deq();
		hw.jul = (fi)num;
	}

	[Token(Token = "0x60003FC")]
	[Address(RVA = "0x49F4F0", Offset = "0x49E4F0", VA = "0x18049F4F0")]
	private void bne(sbyte t, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003FD")]
	[Address(RVA = "0x49F810", Offset = "0x49E810", VA = "0x18049F810")]
	public void bnf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003FE")]
	[Address(RVA = "0x4A0740", Offset = "0x49F740", VA = "0x1804A0740")]
	private int[] bng(int i)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003FF")]
	[Address(RVA = "0x4A0890", Offset = "0x49F890", VA = "0x1804A0890")]
	public void bnh(jl f)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000400")]
	[Address(RVA = "0x49F3C0", Offset = "0x49E3C0", VA = "0x18049F3C0")]
	public fk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
