using Cpp2IlInjected;

[Token(Token = "0x20000F5")]
public class ji
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000EFA")]
	public bool kyg;

	[FieldOffset(Offset = "0x11")]
	[Token(Token = "0x4000EFB")]
	public bool kyh;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000EFC")]
	public hm kyi;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000EFD")]
	public float kyj;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000EFE")]
	public float kyk;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000EFF")]
	public float kyl;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000F00")]
	public float kym;

	[Token(Token = "0x4000F01")]
	public static sbyte kyn;

	[Token(Token = "0x4000F02")]
	public static sbyte kyo;

	[Token(Token = "0x4000F03")]
	public static sbyte kyp;

	[Token(Token = "0x4000F04")]
	public static sbyte kyq;

	[Token(Token = "0x4000F05")]
	public static sbyte kyr;

	[Token(Token = "0x4000F06")]
	public static sbyte kys;

	[Token(Token = "0x4000F07")]
	public static sbyte kyt;

	[Token(Token = "0x4000F08")]
	public static sbyte kyu;

	[Token(Token = "0x4000F09")]
	public static sbyte kyv;

	[Token(Token = "0x4000F0A")]
	public static sbyte kyw;

	[Token(Token = "0x4000F0B")]
	public static sbyte kyx;

	[Token(Token = "0x4000F0C")]
	public static sbyte kyy;

	[Token(Token = "0x4000F0D")]
	public static sbyte kyz;

	[Token(Token = "0x4000F0E")]
	public static sbyte kza;

	[Token(Token = "0x600074A")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public ji()
	{
	}

	[Token(Token = "0x600074B")]
	[Address(RVA = "0x4E87D0", Offset = "0x4E77D0", VA = "0x1804E87D0")]
	public ji(string flyString, float x, float y, int dx, int dy, int color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600074C")]
	[Address(RVA = "0x4E9320", Offset = "0x4E8320", VA = "0x1804E9320")]
	public void close()
	{
		//IL_0014: Expected Obj, but got I8
		kyi.close();
		kyi = (hm)0;
	}

	[Token(Token = "0x600074D")]
	[Address(RVA = "0x4E86B0", Offset = "0x4E76B0", VA = "0x1804E86B0")]
	static ji()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
