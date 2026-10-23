using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D1")]
[AddComponentMenu("UI/Effects/Extensions/Nicer Outline")]
public class NicerOutline : BaseMeshEffect
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A5C")]
	[SerializeField]
	private Color m_EffectColor;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001A5D")]
	[SerializeField]
	private Vector2 m_EffectDistance;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001A5E")]
	[SerializeField]
	private bool m_UseGraphicAlpha;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001A5F")]
	private List<UIVertex> oxh;

	[Token(Token = "0x1700008E")]
	public Color ptg
	{
		[Token(Token = "0x6000F86")]
		[Address(RVA = "0x447B00", Offset = "0x446B00", VA = "0x180447B00")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000F87")]
		[Address(RVA = "0x447B10", Offset = "0x446B10", VA = "0x180447B10")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x1700008F")]
	public Vector2 pth
	{
		[Token(Token = "0x6000F88")]
		[Address(RVA = "0x447BC0", Offset = "0x446BC0", VA = "0x180447BC0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000F89")]
		[Address(RVA = "0x447BE0", Offset = "0x446BE0", VA = "0x180447BE0")]
		set
		{
			//IL_001c: Expected Obj, but got I4
			float y = m_EffectDistance.y;
			Graphic graphic = base.graphic;
			int num = 0;
			if (graphic != (Object)num)
			{
				base.graphic.SetVerticesDirty();
			}
		}
	}

	[Token(Token = "0x17000090")]
	public bool pti
	{
		[Token(Token = "0x6000F8A")]
		[Address(RVA = "0x447D30", Offset = "0x446D30", VA = "0x180447D30")]
		get
		{
			return m_UseGraphicAlpha;
		}
		[Token(Token = "0x6000F8B")]
		[Address(RVA = "0x447D40", Offset = "0x446D40", VA = "0x180447D40")]
		set
		{
			//IL_0017: Expected Obj, but got I4
			m_UseGraphicAlpha = value;
			Graphic graphic = base.graphic;
			int num = 0;
			if (graphic != (Object)num)
			{
				base.graphic.SetVerticesDirty();
			}
		}
	}

	[Token(Token = "0x6000F8C")]
	[Address(RVA = "0x447DE0", Offset = "0x446DE0", VA = "0x180447DE0")]
	protected void ejq(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F8D")]
	[Address(RVA = "0x448150", Offset = "0x447150", VA = "0x180448150")]
	protected void ejr(List<UIVertex> verts, Color32 color, int start, int end, float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F8E")]
	[Address(RVA = "0x447540", Offset = "0x446540", VA = "0x180447540", Slot = "20")]
	public override void ModifyMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F8F")]
	[Address(RVA = "0x447A40", Offset = "0x446A40", VA = "0x180447A40")]
	public NicerOutline()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
