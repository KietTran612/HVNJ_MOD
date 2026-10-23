using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000A5")]
public class gl : fi
{
	[Token(Token = "0x20000A6")]
	private class gj : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000742")]
		private gl iau;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000743")]
		private sbyte iav;

		[Token(Token = "0x60004E0")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gj(gl me, sbyte index)
		{
			iau = me;
			iav = index;
		}

		[Token(Token = "0x60004E1")]
		[Address(RVA = "0x278F70", Offset = "0x277F70", VA = "0x180278F70", Slot = "4")]
		public void th()
		{
			gl gl2 = iau;
			sbyte index = iav;
			gl2.clickTab(index);
		}
	}

	[Token(Token = "0x20000A7")]
	private class gk : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000744")]
		private gl iaw;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000745")]
		private sbyte iax;

		[Token(Token = "0x60004E2")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gk(gl me, sbyte t)
		{
			iaw = me;
			iax = t;
		}

		[Token(Token = "0x60004E3")]
		[Address(RVA = "0x278FA0", Offset = "0x277FA0", VA = "0x180278FA0", Slot = "4")]
		public void th()
		{
			gl gl2 = iaw;
			sbyte b = iax;
			gl2.brt(b);
		}
	}

	[Token(Token = "0x4000729")]
	private static gl iay;

	[Token(Token = "0x400072A")]
	public static sbyte iaz;

	[Token(Token = "0x400072B")]
	public static sbyte iba;

	[Token(Token = "0x400072C")]
	public static sbyte ibb;

	[Token(Token = "0x400072D")]
	public static sbyte ibc;

	[Token(Token = "0x400072E")]
	public static sbyte ibd;

	[Token(Token = "0x400072F")]
	public static sbyte ibe;

	[Token(Token = "0x4000730")]
	public static sbyte ibf;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000731")]
	private List<fq> ibg;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000732")]
	private int ibh = 250;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000733")]
	private int ibi = 200;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000734")]
	private int ibj;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000735")]
	private int ibk;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000736")]
	private int ibl;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000737")]
	private int ibm;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000738")]
	private int ibn;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000739")]
	private ScrollRect ibo;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400073A")]
	private sbyte ibp;

	[FieldOffset(Offset = "0x89")]
	[Token(Token = "0x400073B")]
	private sbyte ibq;

	[FieldOffset(Offset = "0x8A")]
	[Token(Token = "0x400073C")]
	private bool ibr;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400073D")]
	private RectTransform ibs;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x400073E")]
	private hm ibt;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x400073F")]
	private hm ibu;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000740")]
	private Image ibv;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000741")]
	private GameObject ibw;

	[Token(Token = "0x60004D5")]
	[Address(RVA = "0x789C60", Offset = "0x788C60", VA = "0x180789C60")]
	public static gl brr()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		gl gl2 = new gl();
		gl2.ibh = 250;
		gl2.ibi = 200;
		iay = gl2;
		return gl2;
	}

	[Token(Token = "0x60004D6")]
	[Address(RVA = "0x78CE30", Offset = "0x78BE30", VA = "0x18078CE30")]
	public void init(sbyte type, string title, List<fq> list, bool isDangKy, sbyte sizeVong)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004D7")]
	[Address(RVA = "0x789D90", Offset = "0x788D90", VA = "0x180789D90")]
	public void brs(sbyte type, string title, List<fq> list, bool isDangKy, sbyte sizeVong)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004D8")]
	[Address(RVA = "0x78CAC0", Offset = "0x78BAC0", VA = "0x18078CAC0")]
	public void clickTab(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004D9")]
	[Address(RVA = "0x789BE0", Offset = "0x788BE0", VA = "0x180789BE0", Slot = "8")]
	public override void bcf()
	{
		close();
		int num = 0;
		mo.ddt().deq();
	}

	[Token(Token = "0x60004DA")]
	[Address(RVA = "0x78AB90", Offset = "0x789B90", VA = "0x18078AB90")]
	private void brt(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004DB")]
	[Address(RVA = "0x78AC20", Offset = "0x789C20", VA = "0x18078AC20")]
	public void bru()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004DC")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004DD")]
	[Address(RVA = "0x78CDB0", Offset = "0x78BDB0", VA = "0x18078CDB0", Slot = "9")]
	public override void close()
	{
		//IL_001a: Expected Obj, but got I8
		base.close();
		Object.Destroy(hlf);
		ibw = (GameObject)0;
	}

	[Token(Token = "0x60004DE")]
	[Address(RVA = "0x789B80", Offset = "0x788B80", VA = "0x180789B80")]
	public gl()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}

	[Token(Token = "0x60004DF")]
	[Address(RVA = "0x789AD0", Offset = "0x788AD0", VA = "0x180789AD0")]
	static gl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
