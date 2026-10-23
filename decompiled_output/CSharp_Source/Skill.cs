using Cpp2IlInjected;

[Token(Token = "0x2000118")]
public class Skill
{
	[Token(Token = "0x4001174")]
	public const sbyte lwt = 0;

	[Token(Token = "0x4001175")]
	public const sbyte lwu = 1;

	[Token(Token = "0x4001176")]
	public const sbyte lwv = 0;

	[Token(Token = "0x4001177")]
	public const sbyte lww = 1;

	[Token(Token = "0x4001178")]
	public const sbyte lwx = 2;

	[Token(Token = "0x4001179")]
	public const sbyte lwy = 3;

	[Token(Token = "0x400117A")]
	public const sbyte lwz = 4;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x400117B")]
	public kw lxa;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400117C")]
	public short lxb;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x400117D")]
	public int lxc;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400117E")]
	public int lxd;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x400117F")]
	public int lxe;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001180")]
	public long lxf;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001181")]
	public long lxg;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001182")]
	public short lxh;

	[FieldOffset(Offset = "0x3A")]
	[Token(Token = "0x4001183")]
	public short lxi;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001184")]
	public int lxj;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001185")]
	public int lxk;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001186")]
	public kt[] lxl;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001187")]
	public bool lxm;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001188")]
	public float lxn;

	[Token(Token = "0x6000800")]
	[Address(RVA = "0x48BAD0", Offset = "0x48AAD0", VA = "0x18048BAD0")]
	public bool clc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000801")]
	[Address(RVA = "0x48BB20", Offset = "0x48AB20", VA = "0x18048BB20")]
	public string cld()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000802")]
	[Address(RVA = "0x48BB80", Offset = "0x48AB80", VA = "0x18048BB80")]
	public bool cle()
	{
		int num = 0;
		long num2 = hw.ccz();
		int num3 = lxe;
		return num2 < num3;
	}

	[Token(Token = "0x6000803")]
	[Address(RVA = "0x48BBE0", Offset = "0x48ABE0", VA = "0x18048BBE0")]
	public bool clf()
	{
		int num = 0;
		long num2 = hw.ccz();
		int num3 = lxe;
		return num2 < num3;
	}

	[Token(Token = "0x6000804")]
	[Address(RVA = "0x48BC40", Offset = "0x48AC40", VA = "0x18048BC40")]
	public bool clg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000805")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000806")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public Skill()
	{
		close();
	}
}
