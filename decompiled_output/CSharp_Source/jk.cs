using Cpp2IlInjected;

[Token(Token = "0x20000F7")]
public class jk
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000F16")]
	public string kzi;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000F17")]
	public sbyte kzj;

	[FieldOffset(Offset = "0x19")]
	[Token(Token = "0x4000F18")]
	public sbyte kzk;

	[FieldOffset(Offset = "0x1A")]
	[Token(Token = "0x4000F19")]
	public sbyte kzl;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000F1A")]
	public short kzm;

	[FieldOffset(Offset = "0x1E")]
	[Token(Token = "0x4000F1B")]
	public short kzn;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000F1C")]
	public int kzo;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000F1D")]
	public int kzp;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000F1E")]
	public int kzq;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000F1F")]
	public int kzr;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000F20")]
	public bool kzs;

	[Token(Token = "0x600074F")]
	[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
	public jk(string friendName, sbyte type)
	{
		kzi = friendName;
		kzj = type;
	}

	[Token(Token = "0x6000750")]
	[Address(RVA = "0x4E9360", Offset = "0x4E8360", VA = "0x1804E9360")]
	public jk(string friendName, sbyte classID, short level, int hp, int hpMax, int mp, int mpMax, bool isOnline, sbyte cgender, short hair, sbyte type)
	{
		kzj = 0;
		kzo = 0;
		kzp = 0;
		kzq = 0;
		kzr = 0;
		kzs = false;
		kzl = 0;
		kzi = friendName;
		kzm = level;
		kzn = 0;
		kzk = classID;
	}
}
