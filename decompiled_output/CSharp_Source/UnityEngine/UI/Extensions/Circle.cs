using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000230")]
public class Circle
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001C95")]
	[SerializeField]
	private float xAxis;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4001C96")]
	[SerializeField]
	private float yAxis;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C97")]
	[SerializeField]
	private int steps;

	[Token(Token = "0x17000102")]
	public float pxc
	{
		[Token(Token = "0x600122F")]
		[Address(RVA = "0x516B50", Offset = "0x515B50", VA = "0x180516B50")]
		get
		{
			return xAxis;
		}
		[Token(Token = "0x6001230")]
		[Address(RVA = "0x516BE0", Offset = "0x515BE0", VA = "0x180516BE0")]
		set
		{
			xAxis = value;
		}
	}

	[Token(Token = "0x17000103")]
	public float pxd
	{
		[Token(Token = "0x6001231")]
		[Address(RVA = "0x60D990", Offset = "0x60C990", VA = "0x18060D990")]
		get
		{
			return yAxis;
		}
		[Token(Token = "0x6001232")]
		[Address(RVA = "0x60D9A0", Offset = "0x60C9A0", VA = "0x18060D9A0")]
		set
		{
			yAxis = value;
		}
	}

	[Token(Token = "0x17000104")]
	public int pxe
	{
		[Token(Token = "0x6001233")]
		[Address(RVA = "0x274B10", Offset = "0x273B10", VA = "0x180274B10")]
		get
		{
			return steps;
		}
		[Token(Token = "0x6001234")]
		[Address(RVA = "0x56E3F0", Offset = "0x56D3F0", VA = "0x18056E3F0")]
		set
		{
			steps = value;
		}
	}

	[Token(Token = "0x6001235")]
	[Address(RVA = "0x60D8B0", Offset = "0x60C8B0", VA = "0x18060D8B0")]
	public Circle(float radius)
	{
		//IL_001d: Expected I4, but got I8
		xAxis = radius;
		yAxis = radius;
		steps = 1;
	}

	[Token(Token = "0x6001236")]
	[Address(RVA = "0x60D870", Offset = "0x60C870", VA = "0x18060D870")]
	public Circle(float radius, int steps)
	{
		xAxis = radius;
		yAxis = radius;
		this.steps = steps;
	}

	[Token(Token = "0x6001237")]
	[Address(RVA = "0x60D940", Offset = "0x60C940", VA = "0x18060D940")]
	public Circle(float xAxis, float yAxis)
	{
		//IL_001e: Expected I4, but got I8
		this.xAxis = xAxis;
		this.yAxis = yAxis;
		steps = 10;
	}

	[Token(Token = "0x6001238")]
	[Address(RVA = "0x60D8F0", Offset = "0x60C8F0", VA = "0x18060D8F0")]
	public Circle(float xAxis, float yAxis, int steps)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001239")]
	[Address(RVA = "0x60D9B0", Offset = "0x60C9B0", VA = "0x18060D9B0")]
	public Vector2 fac(float t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600123A")]
	[Address(RVA = "0x60DA20", Offset = "0x60CA20", VA = "0x18060DA20")]
	public void fad(float t, out Vector2 eval)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
