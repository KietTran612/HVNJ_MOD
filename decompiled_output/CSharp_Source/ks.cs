using Cpp2IlInjected;

[Token(Token = "0x200011A")]
public class ks
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001193")]
	public int lxy;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001194")]
	public int[] lxz = new int[3];

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001195")]
	public int[] lya = new int[3];

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001196")]
	public int[] lyb = new int[3];

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001197")]
	public int lyc;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001198")]
	public int lyd;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001199")]
	public int lye;

	[Token(Token = "0x600080A")]
	[Address(RVA = "0x1F5980", Offset = "0x1F4980", VA = "0x1801F5980")]
	public ks()
	{
	}
}
