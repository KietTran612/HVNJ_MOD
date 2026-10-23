using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000213")]
[AddComponentMenu("UI/Extensions/Primitives/Diamond Graph")]
public class DiamondGraph : UIPrimitiveBase
{
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001BB8")]
	[SerializeField]
	private float m_a = 1f;

	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4001BB9")]
	[SerializeField]
	private float m_b = 1f;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4001BBA")]
	[SerializeField]
	private float m_c = 1f;

	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4001BBB")]
	[SerializeField]
	private float m_d = 1f;

	[Token(Token = "0x170000C4")]
	public float pvb
	{
		[Token(Token = "0x6001136")]
		[Address(RVA = "0x6013D0", Offset = "0x6003D0", VA = "0x1806013D0")]
		get
		{
			return m_a;
		}
		[Token(Token = "0x6001137")]
		[Address(RVA = "0x69D840", Offset = "0x69C840", VA = "0x18069D840")]
		set
		{
			m_a = value;
		}
	}

	[Token(Token = "0x170000C5")]
	public float pvc
	{
		[Token(Token = "0x6001138")]
		[Address(RVA = "0x601470", Offset = "0x600470", VA = "0x180601470")]
		get
		{
			return m_b;
		}
		[Token(Token = "0x6001139")]
		[Address(RVA = "0x69D850", Offset = "0x69C850", VA = "0x18069D850")]
		set
		{
			m_b = value;
		}
	}

	[Token(Token = "0x170000C6")]
	public float pvd
	{
		[Token(Token = "0x600113A")]
		[Address(RVA = "0x69D860", Offset = "0x69C860", VA = "0x18069D860")]
		get
		{
			return m_c;
		}
		[Token(Token = "0x600113B")]
		[Address(RVA = "0x69D870", Offset = "0x69C870", VA = "0x18069D870")]
		set
		{
			m_c = value;
		}
	}

	[Token(Token = "0x170000C7")]
	public float pve
	{
		[Token(Token = "0x600113C")]
		[Address(RVA = "0x376990", Offset = "0x375990", VA = "0x180376990")]
		get
		{
			return m_d;
		}
		[Token(Token = "0x600113D")]
		[Address(RVA = "0x376CF0", Offset = "0x375CF0", VA = "0x180376CF0")]
		set
		{
			m_d = value;
		}
	}

	[Token(Token = "0x600113E")]
	[Address(RVA = "0x69D410", Offset = "0x69C410", VA = "0x18069D410", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600113F")]
	[Address(RVA = "0x69D7C0", Offset = "0x69C7C0", VA = "0x18069D7C0")]
	public DiamondGraph()
	{
	}
}
