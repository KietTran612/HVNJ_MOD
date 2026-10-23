using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x2000264")]
public struct HsvColor
{
	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001D63")]
	public double H;

	[FieldOffset(Offset = "0x8")]
	[Token(Token = "0x4001D64")]
	public double S;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001D65")]
	public double V;

	[Token(Token = "0x17000127")]
	public float pyk
	{
		[Token(Token = "0x600134C")]
		[Address(RVA = "0x43F770", Offset = "0x43E770", VA = "0x18043F770")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x600134D")]
		[Address(RVA = "0x43F790", Offset = "0x43E790", VA = "0x18043F790")]
		set
		{
		}
	}

	[Token(Token = "0x17000128")]
	public float pyl
	{
		[Token(Token = "0x600134E")]
		[Address(RVA = "0x43F7B0", Offset = "0x43E7B0", VA = "0x18043F7B0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x600134F")]
		[Address(RVA = "0x43F7C0", Offset = "0x43E7C0", VA = "0x18043F7C0")]
		set
		{
		}
	}

	[Token(Token = "0x17000129")]
	public float pym
	{
		[Token(Token = "0x6001350")]
		[Address(RVA = "0x43F7D0", Offset = "0x43E7D0", VA = "0x18043F7D0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6001351")]
		[Address(RVA = "0x43F7E0", Offset = "0x43E7E0", VA = "0x18043F7E0")]
		set
		{
		}
	}

	[Token(Token = "0x6001352")]
	[Address(RVA = "0x43F760", Offset = "0x43E760", VA = "0x18043F760")]
	public HsvColor(double h, double s, double v)
	{
	}

	[Token(Token = "0x6001353")]
	[Address(RVA = "0x43F440", Offset = "0x43E440", VA = "0x18043F440", Slot = "3")]
	public override string ToString()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
