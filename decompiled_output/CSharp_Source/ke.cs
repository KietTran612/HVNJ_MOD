using Cpp2IlInjected;

[Token(Token = "0x200010A")]
public class ke
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40010B2")]
	public int lph;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x40010B3")]
	public int lpi;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40010B4")]
	public int lpj;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40010B5")]
	public string lpk;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40010B6")]
	public bool lpl;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x40010B7")]
	public int lpm;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40010B8")]
	public int lpn;

	[Token(Token = "0x60007CA")]
	[Address(RVA = "0x1ED1B0", Offset = "0x1EC1B0", VA = "0x1801ED1B0")]
	public ke(int classId, int level, int type, string name, int pointClan, bool isOnline)
	{
		//IL_001b: Expected Obj, but got I4
		int num = gb.bqo(classId);
		lph = num;
		lpk = (string)0;
		lpm = 0;
		lpi = level;
		lpl = false;
		lpj = type;
	}
}
