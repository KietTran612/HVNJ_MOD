using System.Collections.Generic;
using Cpp2IlInjected;
using Spine.Unity;
using UnityEngine;

[Token(Token = "0x200008C")]
public class fm : lu
{
	[Token(Token = "0x200008D")]
	private class fl : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40005BE")]
		private fm hme;

		[Token(Token = "0x600040D")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public fl(fm me)
		{
			hme = me;
		}

		[Token(Token = "0x600040E")]
		[Address(RVA = "0x278AA0", Offset = "0x277AA0", VA = "0x180278AA0", Slot = "4")]
		public void th()
		{
			((SkeletonUtilityConstraint)(object)hme).DoUpdate();
		}
	}

	[Token(Token = "0x40005AE")]
	private static fm hmf;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40005AF")]
	private GameObject hmg;

	[Token(Token = "0x40005B0")]
	private static GameObject hmh;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40005B1")]
	private GameObject[] hmi;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40005B2")]
	private GameObject[] hmj;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40005B3")]
	private hm[] hmk;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40005B4")]
	private hm[][] hml;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40005B5")]
	private sbyte hmm;

	[FieldOffset(Offset = "0x51")]
	[Token(Token = "0x40005B6")]
	private sbyte hmn;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x40005B7")]
	private int hmo;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40005B8")]
	private int hmp;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40005B9")]
	private List<List<kr>> hmq = (List<List<kr>>)(object)new List<T>();

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40005BA")]
	private List<string> hmr = (List<string>)(object)new List<T>();

	[Token(Token = "0x40005BB")]
	public static bool hms;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40005BC")]
	private int hmt;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40005BD")]
	private RectTransform[] hmu;

	[Token(Token = "0x6000406")]
	[Address(RVA = "0x4A1900", Offset = "0x4A0900", VA = "0x1804A1900")]
	public static fm bni()
	{
		fm fm2 = new fm();
		List<List<kr>> list = (List<List<kr>>)(object)new List<T>();
		fm2.hmq = list;
		List<string> list2 = (List<string>)(object)new List<T>();
		fm2.hmr = list2;
		hmf = fm2;
		return fm2;
	}

	[Token(Token = "0x6000407")]
	[Address(RVA = "0x4A23E0", Offset = "0x4A13E0", VA = "0x1804A23E0")]
	public void init(List<kr> list, string title)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000408")]
	[Address(RVA = "0x4A1A70", Offset = "0x4A0A70", VA = "0x1804A1A70", Slot = "6")]
	public override void bnj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000409")]
	[Address(RVA = "0x4A20F0", Offset = "0x4A10F0", VA = "0x1804A20F0", Slot = "7")]
	public override void bnk()
	{
		hw.juk = this;
	}

	[Token(Token = "0x600040A")]
	[Address(RVA = "0x4A2160", Offset = "0x4A1160", VA = "0x1804A2160", Slot = "9")]
	public override void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600040B")]
	[Address(RVA = "0x4A1850", Offset = "0x4A0850", VA = "0x1804A1850")]
	public fm()
	{
	}

	[Token(Token = "0x600040C")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static fm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
