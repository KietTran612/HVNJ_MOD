using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000163")]
public class CongDongPopup : fi
{
	[Token(Token = "0x2000164")]
	private class nh : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001782")]
		private CongDongPopup odr;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001783")]
		private sbyte ods;

		[FieldOffset(Offset = "0x19")]
		[Token(Token = "0x4001784")]
		private sbyte odt;

		[Token(Token = "0x6000C25")]
		[Address(RVA = "0x277820", Offset = "0x276820", VA = "0x180277820")]
		public nh(CongDongPopup me, sbyte type, sbyte index)
		{
			odr = me;
			ods = type;
			odt = index;
		}

		[Token(Token = "0x6000C26")]
		[Address(RVA = "0x27AB60", Offset = "0x279B60", VA = "0x18027AB60", Slot = "4")]
		public void th()
		{
			CongDongPopup congDongPopup = odr;
			sbyte index = odt;
			sbyte type = ods;
			congDongPopup.dny(type, index);
		}
	}

	[Token(Token = "0x4001776")]
	private static CongDongPopup odu;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001777")]
	private int odv = 250;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001778")]
	private int odw = 200;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001779")]
	private int odx;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400177A")]
	private int ody;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400177B")]
	private ScrollRect odz;

	[Token(Token = "0x400177C")]
	public static List<ix> oea = (List<ix>)(object)new List<T>();

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400177D")]
	private GameObject oeb;

	[Token(Token = "0x400177E")]
	private static Sprite oec;

	[Token(Token = "0x400177F")]
	private static Sprite oed;

	[Token(Token = "0x4001780")]
	private static Sprite oee;

	[Token(Token = "0x4001781")]
	public static sbyte[] oef;

	[Token(Token = "0x6000C1D")]
	[Address(RVA = "0x695040", Offset = "0x694040", VA = "0x180695040")]
	public static CongDongPopup dnv()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		CongDongPopup congDongPopup = new CongDongPopup();
		congDongPopup.odv = 250;
		congDongPopup.odw = 200;
		odu = congDongPopup;
		return congDongPopup;
	}

	[Token(Token = "0x6000C1E")]
	[Address(RVA = "0x695FE0", Offset = "0x694FE0", VA = "0x180695FE0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C1F")]
	[Address(RVA = "0x695170", Offset = "0x694170", VA = "0x180695170")]
	public void dnw()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C20")]
	[Address(RVA = "0x695DA0", Offset = "0x694DA0", VA = "0x180695DA0")]
	public bool dnx(ix p)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C21")]
	[Address(RVA = "0x695EE0", Offset = "0x694EE0", VA = "0x180695EE0")]
	public void dny(sbyte type, sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C22")]
	[Address(RVA = "0x694F50", Offset = "0x693F50", VA = "0x180694F50", Slot = "9")]
	public override void close()
	{
		//IL_0023: Expected Obj, but got I4
		//IL_0029: Expected Obj, but got I4
		base.close();
		Object.Destroy(hlf);
		((List<T>)(object)oea).Clear();
		int num = 0;
		oec = (Sprite)num;
		oed = (Sprite)num;
	}

	[Token(Token = "0x6000C23")]
	[Address(RVA = "0x694EF0", Offset = "0x693EF0", VA = "0x180694EF0")]
	public CongDongPopup()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
