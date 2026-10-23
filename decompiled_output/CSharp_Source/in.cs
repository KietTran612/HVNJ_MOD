using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000E0")]
public class @in
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000CF2")]
	public short kef;

	[FieldOffset(Offset = "0x12")]
	[Token(Token = "0x4000CF3")]
	public short keg;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000CF4")]
	public string keh;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000CF5")]
	public bool kei;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000CF6")]
	private GameObject kej;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000CF7")]
	private hl kek;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000CF8")]
	private hl kel;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000CF9")]
	private hn kem;

	[Token(Token = "0x60006FA")]
	[Address(RVA = "0x4E2440", Offset = "0x4E1440", VA = "0x1804E2440")]
	public @in(string name, short x, short y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006FB")]
	[Address(RVA = "0x4E2500", Offset = "0x4E1500", VA = "0x1804E2500")]
	public void cfi()
	{
		kei = true;
	}

	[Token(Token = "0x60006FC")]
	[Address(RVA = "0x4E2510", Offset = "0x4E1510", VA = "0x1804E2510")]
	public void cfj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006FD")]
	[Address(RVA = "0x4E2840", Offset = "0x4E1840", VA = "0x1804E2840")]
	public void close()
	{
		Object.Destroy(kej);
	}
}
