using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000138")]
public class lw
{
	[Token(Token = "0x4001404")]
	public static bool mwf;

	[Token(Token = "0x4001405")]
	private static string mwg;

	[Token(Token = "0x4001406")]
	private static string mwh;

	[Token(Token = "0x4001407")]
	public static int mwi;

	[Token(Token = "0x4001408")]
	public static bool mwj;

	[Token(Token = "0x4001409")]
	private static GameObject mwk;

	[Token(Token = "0x400140A")]
	private static hm mwl;

	[Token(Token = "0x400140B")]
	private static hm mwm;

	[Token(Token = "0x400140C")]
	private static bool mwn;

	[Token(Token = "0x6000A1A")]
	[Address(RVA = "0x3CEF70", Offset = "0x3CDF70", VA = "0x1803CEF70")]
	public static void dai(string title, string subtitle, int delay)
	{
		if (title != null)
		{
			mwg = title;
			mwh = subtitle;
			mwi = delay;
		}
	}

	[Token(Token = "0x6000A1B")]
	[Address(RVA = "0x3CF000", Offset = "0x3CE000", VA = "0x1803CF000")]
	public static void daj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A1C")]
	[Address(RVA = "0x3CF0F0", Offset = "0x3CE0F0", VA = "0x1803CF0F0")]
	public static void dak(string str)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A1D")]
	[Address(RVA = "0x3CF1C0", Offset = "0x3CE1C0", VA = "0x1803CF1C0")]
	private static void dal(bool isA)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A1E")]
	[Address(RVA = "0x3CF3B0", Offset = "0x3CE3B0", VA = "0x1803CF3B0")]
	public static void dan()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A1F")]
	[Address(RVA = "0x3CFB30", Offset = "0x3CEB30", VA = "0x1803CFB30")]
	public static void dao()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A20")]
	[Address(RVA = "0x3CFC70", Offset = "0x3CEC70", VA = "0x1803CFC70")]
	public static void dap()
	{
		//IL_0012: Expected Obj, but got I4
		int num = 0;
		mwg = "";
		mwh = (string)num;
		mwj = (byte)num != 0;
		mwi = num;
		mwf = (byte)num != 0;
	}

	[Token(Token = "0x6000A21")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public lw()
	{
	}
}
