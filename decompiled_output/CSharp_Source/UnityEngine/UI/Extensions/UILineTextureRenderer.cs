using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200021F")]
[AddComponentMenu("UI/Extensions/Primitives/UILineTextureRenderer")]
public class UILineTextureRenderer : UIPrimitiveBase
{
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001C20")]
	[SerializeField]
	private Rect m_UVRect;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4001C21")]
	[SerializeField]
	private Vector2[] m_points;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001C22")]
	public float LineThickness;

	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4001C23")]
	public bool UseMargins;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4001C24")]
	public Vector2 Margin;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4001C25")]
	public bool relativeSize;

	[Token(Token = "0x170000E0")]
	public Rect pwd
	{
		[Token(Token = "0x6001195")]
		[Address(RVA = "0x882600", Offset = "0x881600", VA = "0x180882600")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6001196")]
		[Address(RVA = "0x882610", Offset = "0x881610", VA = "0x180882610")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000E1")]
	public Vector2[] pwe
	{
		[Token(Token = "0x6001197")]
		[Address(RVA = "0x24DC70", Offset = "0x24CC70", VA = "0x18024DC70")]
		get
		{
			return m_points;
		}
		[Token(Token = "0x6001198")]
		[Address(RVA = "0x882680", Offset = "0x881680", VA = "0x180882680")]
		set
		{
			if (m_points != value)
			{
				m_points = value;
				TypeCode typeCode = ((IConvertible)this).GetTypeCode();
			}
		}
	}

	[Token(Token = "0x6001199")]
	[Address(RVA = "0x8816F0", Offset = "0x8806F0", VA = "0x1808816F0", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600119A")]
	[Address(RVA = "0x8826B0", Offset = "0x8816B0", VA = "0x1808826B0")]
	public Vector3 ewl(Vector3 point, Vector3 pivot, Vector3 angles)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600119B")]
	[Address(RVA = "0x882560", Offset = "0x881560", VA = "0x180882560")]
	public UILineTextureRenderer()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
