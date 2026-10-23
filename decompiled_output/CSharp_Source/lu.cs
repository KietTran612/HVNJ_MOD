using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000136")]
public class lu
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40013F6")]
	public iw mvr;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40013F7")]
	public iw mvs;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40013F8")]
	public iw mvt;

	[Token(Token = "0x6000A0E")]
	[Address(RVA = "0x3CE590", Offset = "0x3CD590", VA = "0x1803CE590", Slot = "4")]
	public virtual void dac(int keyCode)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A0F")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
	public virtual void dad(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A10")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "6")]
	public virtual void bnj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A11")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "7")]
	public virtual void bnk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A12")]
	[Address(RVA = "0x3CEA40", Offset = "0x3CDA40", VA = "0x1803CEA40", Slot = "8")]
	public virtual void dae()
	{
		MonoBehaviour.print("close");
	}

	[Token(Token = "0x6000A13")]
	[Address(RVA = "0x3CE550", Offset = "0x3CD550", VA = "0x1803CE550", Slot = "9")]
	public virtual void close()
	{
		MonoBehaviour.print("close");
	}

	[Token(Token = "0x6000A14")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public lu()
	{
		bnj();
	}
}
