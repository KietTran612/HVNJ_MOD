using Cpp2IlInjected;
using UnityEngine.UI;

[Token(Token = "0x20000FB")]
public class jo
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000F38")]
	public Image laq;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000F39")]
	public short lar;

	[Token(Token = "0x6000754")]
	[Address(RVA = "0x4E93F0", Offset = "0x4E83F0", VA = "0x1804E93F0")]
	public jo(Image img, short id)
	{
		laq = img;
		lar = id;
	}
}
