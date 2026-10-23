using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000020")]
public class MainTest : MonoBehaviour
{
	[Token(Token = "0x40000E0")]
	public static int countPlayer;

	[Token(Token = "0x40000E1")]
	public static int maxPlayer;

	[Token(Token = "0x40000E2")]
	public static List<bk> sessionTest;

	[Token(Token = "0x40000E3")]
	public static List<nt> listController;

	[Token(Token = "0x40000E4")]
	private static int frb;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40000E5")]
	private int frc;

	[Token(Token = "0x600011B")]
	[Address(RVA = "0x443300", Offset = "0x442300", VA = "0x180443300")]
	private void Start()
	{
		int num = 0;
		hd.buu();
	}

	[Token(Token = "0x600011C")]
	[Address(RVA = "0x443350", Offset = "0x442350", VA = "0x180443350")]
	private void Update()
	{
		int num = 0;
		e.sh();
	}

	[Token(Token = "0x600011D")]
	[Address(RVA = "0x443170", Offset = "0x442170", VA = "0x180443170")]
	private void FixedUpdate()
	{
		int num = 0;
		zd();
	}

	[Token(Token = "0x600011E")]
	[Address(RVA = "0x443450", Offset = "0x442450", VA = "0x180443450")]
	public static void zd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600011F")]
	[Address(RVA = "0x4431C0", Offset = "0x4421C0", VA = "0x1804431C0")]
	private void OnApplicationQuit()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000120")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public MainTest()
	{
	}

	[Token(Token = "0x6000121")]
	[Address(RVA = "0x443360", Offset = "0x442360", VA = "0x180443360")]
	static MainTest()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
