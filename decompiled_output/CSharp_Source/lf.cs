using System.Collections.Generic;
using Cpp2IlInjected;

[Token(Token = "0x2000128")]
public class lf
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x400120B")]
	public short mcr = -1;

	[FieldOffset(Offset = "0x12")]
	[Token(Token = "0x400120C")]
	public short mcs;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x400120D")]
	public bool mct;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400120E")]
	public List<int> mcu = (List<int>)(object)new List<T>();

	[Token(Token = "0x6000838")]
	[Address(RVA = "0x2000E0", Offset = "0x1FF0E0", VA = "0x1802000E0")]
	public lf()
	{
		//IL_000d: Expected I4, but got I8
	}

	[Token(Token = "0x6000839")]
	[Address(RVA = "0x200160", Offset = "0x1FF160", VA = "0x180200160")]
	public bool clz(int id)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
