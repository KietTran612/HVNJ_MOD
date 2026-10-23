using Cpp2IlInjected;

[Token(Token = "0x2000105")]
public class jy
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000FF3")]
	public jr lhx;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000FF4")]
	public int lhy;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000FF5")]
	public int lhz;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000FF6")]
	public int lia;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000FF7")]
	public string lib;

	[Token(Token = "0x60007A4")]
	[Address(RVA = "0x4F14F0", Offset = "0x4F04F0", VA = "0x1804F14F0")]
	public unsafe jy(jr item, string seller, int price)
	{
		//IL_0016: Expected Obj, but got I4
		int num = 0;
		lib = "";
		FieldGetter((string)num, seller, ref *(object*)price);
		lhx = item;
		lhy = price;
	}

	[Token(Token = "0x60007A5")]
	[Address(RVA = "0x4F14B0", Offset = "0x4F04B0", VA = "0x1804F14B0")]
	public jy()
	{
		lib = "";
		base._002Ector();
	}
}
