using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000100")]
public class jt
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000FCA")]
	public short lgi;

	[FieldOffset(Offset = "0x12")]
	[Token(Token = "0x4000FCB")]
	public short lgj;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4000FCC")]
	public short lgk;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000FCD")]
	private jv lgl;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000FCE")]
	private sbyte lgm;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000FCF")]
	private hl[] lgn;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000FD0")]
	private GameObject lgo;

	[Token(Token = "0x600078E")]
	[Address(RVA = "0x4EBE00", Offset = "0x4EAE00", VA = "0x1804EBE00")]
	public void cip()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600078F")]
	[Address(RVA = "0x4EC280", Offset = "0x4EB280", VA = "0x1804EC280")]
	public void close()
	{
		Object.Destroy(lgo);
	}

	[Token(Token = "0x6000790")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public jt()
	{
	}
}
