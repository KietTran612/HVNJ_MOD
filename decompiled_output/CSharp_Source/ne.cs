using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200015A")]
public class ne : ng
{
	[Token(Token = "0x4001734")]
	public static ne obt;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001735")]
	private GameObject obu;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001736")]
	private RectTransform obv;

	[Token(Token = "0x4001737")]
	public static int obw;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001738")]
	private hm obx;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001739")]
	private float oby;

	[Token(Token = "0x400173A")]
	public static bool obz;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x400173B")]
	private int oca;

	[Token(Token = "0x6000BE1")]
	[Address(RVA = "0x2D2EC0", Offset = "0x2D1EC0", VA = "0x1802D2EC0", Slot = "4")]
	public override void ctn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BE2")]
	[Address(RVA = "0x2D35C0", Offset = "0x2D25C0", VA = "0x1802D35C0", Slot = "6")]
	public override void ctq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BE3")]
	[Address(RVA = "0x2D2DF0", Offset = "0x2D1DF0", VA = "0x1802D2DF0")]
	private void clear()
	{
		hw.jsu.cco();
		hw.juj.checkLoginAuto();
		Object.Destroy(obu);
	}

	[Token(Token = "0x6000BE4")]
	[Address(RVA = "0x2D2D90", Offset = "0x2D1D90", VA = "0x1802D2D90")]
	public ne()
	{
	}

	[Token(Token = "0x6000BE5")]
	[Address(RVA = "0x2D2D40", Offset = "0x2D1D40", VA = "0x1802D2D40")]
	static ne()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
