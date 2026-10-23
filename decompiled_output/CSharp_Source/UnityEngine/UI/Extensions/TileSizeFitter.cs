using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000209")]
[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("Layout/Extensions/Tile Size Fitter")]
public class TileSizeFitter : UIBehaviour, ILayoutSelfController, ILayoutController
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001B9A")]
	[SerializeField]
	private Vector2 m_Border;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001B9B")]
	[SerializeField]
	private Vector2 m_TileSize;

	[NonSerialized]
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001B9C")]
	private RectTransform pdl;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001B9D")]
	private DrivenRectTransformTracker pdm;

	[Token(Token = "0x170000BA")]
	public Vector2 puv
	{
		[Token(Token = "0x60010E6")]
		[Address(RVA = "0x607D50", Offset = "0x606D50", VA = "0x180607D50")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x60010E7")]
		[Address(RVA = "0x876FD0", Offset = "0x875FD0", VA = "0x180876FD0")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000BB")]
	public Vector2 puw
	{
		[Token(Token = "0x60010E8")]
		[Address(RVA = "0x641CB0", Offset = "0x640CB0", VA = "0x180641CB0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x60010E9")]
		[Address(RVA = "0x877050", Offset = "0x876050", VA = "0x180877050")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000BC")]
	private RectTransform pux
	{
		[Token(Token = "0x60010EA")]
		[Address(RVA = "0x8770D0", Offset = "0x8760D0", VA = "0x1808770D0")]
		get
		{
			//IL_0010: Expected Obj, but got I4
			RectTransform rectTransform = pdl;
			int num = 0;
			if (rectTransform == (Object)num)
			{
				RectTransform component = GetComponent<RectTransform>();
				pdl = component;
			}
			return pdl;
		}
	}

	[Token(Token = "0x60010EB")]
	[Address(RVA = "0x876F20", Offset = "0x875F20", VA = "0x180876F20", Slot = "5")]
	protected override void OnEnable()
	{
		SetLayoutHorizontal();
		if (IsActive())
		{
			ern();
		}
	}

	[Token(Token = "0x60010EC")]
	[Address(RVA = "0x876EA0", Offset = "0x875EA0", VA = "0x180876EA0", Slot = "7")]
	protected override void OnDisable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010ED")]
	[Address(RVA = "0x876F60", Offset = "0x875F60", VA = "0x180876F60", Slot = "10")]
	protected override void OnRectTransformDimensionsChange()
	{
		ern();
	}

	[Token(Token = "0x60010EE")]
	[Address(RVA = "0x877160", Offset = "0x876160", VA = "0x180877160")]
	private void ern()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010EF")]
	[Address(RVA = "0x877460", Offset = "0x876460", VA = "0x180877460")]
	private Vector2 ero()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010F0")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "19")]
	public virtual void SetLayoutHorizontal()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010F1")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "20")]
	public virtual void SetLayoutVertical()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010F2")]
	[Address(RVA = "0x877540", Offset = "0x876540", VA = "0x180877540")]
	protected void erp()
	{
		if (IsActive())
		{
			ern();
		}
	}

	[Token(Token = "0x60010F3")]
	[Address(RVA = "0x876F70", Offset = "0x875F70", VA = "0x180876F70")]
	public unsafe TileSizeFitter()
	{
		//IL_001d: Expected F4, but got I4
		//IL_0018: Expected native int or pointer, but got VT
		//IL_0036: Expected F4, but got I4
		//IL_0031: Expected native int or pointer, but got VT
		int num = 0;
		Vector2 zero = Vector2.zero;
		int num2 = 0;
		m_Border = zero;
		((Vector2*)(nint)m_Border)->y = 0f;
		m_TileSize = Vector2.zero;
		((Vector2*)(nint)m_TileSize)->y = 0f;
		base._002Ector();
	}
}
