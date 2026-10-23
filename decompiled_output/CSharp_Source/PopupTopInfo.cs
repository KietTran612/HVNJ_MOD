using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200014F")]
public class PopupTopInfo
{
	[Token(Token = "0x40016C9")]
	public static List<lz> nxp;

	[Token(Token = "0x40016CA")]
	public static lz nxq;

	[Token(Token = "0x40016CB")]
	public static int nxr;

	[Token(Token = "0x40016CC")]
	public static sbyte nxs;

	[Token(Token = "0x40016CD")]
	private static Vector2 nxt;

	[Token(Token = "0x40016CE")]
	private static Vector2 nxu;

	[Token(Token = "0x40016CF")]
	private static GameObject nxv;

	[Token(Token = "0x40016D0")]
	private static hm nxw;

	[Token(Token = "0x40016D1")]
	private static bool nxx;

	[Token(Token = "0x40016D2")]
	private static int nxy;

	[Token(Token = "0x40016D3")]
	private static int nxz;

	[Token(Token = "0x6000BA4")]
	[Address(RVA = "0x449250", Offset = "0x448250", VA = "0x180449250")]
	public static void dml()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BA5")]
	[Address(RVA = "0x449B10", Offset = "0x448B10", VA = "0x180449B10")]
	private static void dmm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BA6")]
	[Address(RVA = "0x449D90", Offset = "0x448D90", VA = "0x180449D90")]
	private static bool dmn(string s)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BA7")]
	[Address(RVA = "0x44A430", Offset = "0x449430", VA = "0x18044A430")]
	public static void dmo(string s, int speed, int countShow)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BA8")]
	[Address(RVA = "0x44A5A0", Offset = "0x4495A0", VA = "0x18044A5A0")]
	public static bool dmp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BA9")]
	[Address(RVA = "0x449140", Offset = "0x448140", VA = "0x180449140")]
	public static void close()
	{
		//IL_001c: Expected Obj, but got I4
		//IL_0028: Expected Obj, but got I4
		((List<T>)(object)nxp).Clear();
		Object.Destroy(nxv);
		int num = 0;
		nxv = (GameObject)num;
		nxx = (byte)num != 0;
		nxq = (lz)num;
	}

	[Token(Token = "0x6000BAA")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public PopupTopInfo()
	{
	}

	[Token(Token = "0x6000BAB")]
	[Address(RVA = "0x4490B0", Offset = "0x4480B0", VA = "0x1804490B0")]
	static PopupTopInfo()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
