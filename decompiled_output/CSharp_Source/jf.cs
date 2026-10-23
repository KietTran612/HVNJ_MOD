using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000F2")]
public class jf
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000EEC")]
	public GameObject kxs;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000EED")]
	public int kxt;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000EEE")]
	public bool kxu;

	[FieldOffset(Offset = "0x1D")]
	[Token(Token = "0x4000EEF")]
	public bool kxv;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000EF0")]
	private ParticleSystem[] kxw;

	[Token(Token = "0x6000743")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public jf()
	{
	}

	[Token(Token = "0x6000744")]
	[Address(RVA = "0x4E8170", Offset = "0x4E7170", VA = "0x1804E8170")]
	public jf(GameObject obj, int time)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000745")]
	[Address(RVA = "0x4E8360", Offset = "0x4E7360", VA = "0x1804E8360", Slot = "4")]
	public virtual void cgg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000746")]
	[Address(RVA = "0x4E8570", Offset = "0x4E7570", VA = "0x1804E8570", Slot = "5")]
	public virtual void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
