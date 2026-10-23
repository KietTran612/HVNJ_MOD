using System.Collections.Generic;
using Cpp2IlInjected;

[Token(Token = "0x2000109")]
public class kd
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40010AA")]
	public short loz;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40010AB")]
	public List<le> lpa = (List<le>)(object)new List<T>();

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40010AC")]
	public bool lpb;

	[FieldOffset(Offset = "0x22")]
	[Token(Token = "0x40010AD")]
	public short lpc;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x40010AE")]
	public short lpd;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40010AF")]
	public sbyte[] lpe;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40010B0")]
	public short[] lpf;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40010B1")]
	public sbyte[] lpg;

	[Token(Token = "0x60007C9")]
	[Address(RVA = "0x1ED130", Offset = "0x1EC130", VA = "0x1801ED130")]
	public kd(short id)
	{
		loz = id;
	}
}
