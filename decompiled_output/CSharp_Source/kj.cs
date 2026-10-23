using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200010F")]
public class kj
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40010F8")]
	public int lrz;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40010F9")]
	public Sprite lsa;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40010FA")]
	public long lsb;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40010FB")]
	public bool lsc;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40010FC")]
	public long lsd;

	[Token(Token = "0x60007E2")]
	[Address(RVA = "0x1EF9D0", Offset = "0x1EE9D0", VA = "0x1801EF9D0")]
	public kj()
	{
		int num = 0;
		lsd = hw.ccz();
		base._002Ector();
	}
}
