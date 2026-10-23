using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001C3")]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
[AddComponentMenu("UI/Effects/Extensions/Curly UI Image")]
public class CUIImage : CUIGraphic
{
	[Token(Token = "0x4001A2D")]
	public static int SlicedImageCornerRefVertexIdx;

	[Token(Token = "0x4001A2E")]
	public static int FilledImageCornerRefVertexIdx;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001A2F")]
	[HideInInspector]
	[SerializeField]
	[Tooltip("For changing the size of the corner for tiled or sliced Image")]
	public Vector2 cornerPosRatio;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001A30")]
	[HideInInspector]
	[SerializeField]
	protected Vector2 oriCornerPosRatio;

	[Token(Token = "0x1700007C")]
	public Vector2 psp
	{
		[Token(Token = "0x6000F40")]
		[Address(RVA = "0x607810", Offset = "0x606810", VA = "0x180607810")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x1700007D")]
	public Image psq
	{
		[Token(Token = "0x6000F41")]
		[Address(RVA = "0x607830", Offset = "0x606830", VA = "0x180607830")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x6000F3F")]
	[Address(RVA = "0x607770", Offset = "0x606770", VA = "0x180607770")]
	public static int ehu(Image.Type _type)
	{
		if (_type != Image.Type.Sliced)
		{
			return FilledImageCornerRefVertexIdx;
		}
		return SlicedImageCornerRefVertexIdx;
	}

	[Token(Token = "0x6000F42")]
	[Address(RVA = "0x606D60", Offset = "0x605D60", VA = "0x180606D60", Slot = "21")]
	public override void ehn()
	{
		//IL_0010: Expected Obj, but got I4
		Graphic graphic = uiGraphic;
		int num = 0;
		if (graphic == (Object)num)
		{
			Image component = GetComponent<Image>();
			uiGraphic = component;
		}
		base.ehn();
	}

	[Token(Token = "0x6000F43")]
	[Address(RVA = "0x606DF0", Offset = "0x605DF0", VA = "0x180606DF0", Slot = "22")]
	protected override void ehq(List<UIVertex> _verts)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F44")]
	[Address(RVA = "0x606CA0", Offset = "0x605CA0", VA = "0x180606CA0")]
	public unsafe CUIImage()
	{
		//IL_001d: Expected F4, but got I4
		//IL_0018: Expected native int or pointer, but got VT
		//IL_0036: Expected F4, but got I4
		//IL_0031: Expected native int or pointer, but got VT
		int num = 0;
		Vector2 one = Vector2.one;
		int num2 = 0;
		cornerPosRatio = one;
		((Vector2*)(nint)cornerPosRatio)->y = 0f;
		oriCornerPosRatio = Vector2.one;
		((Vector2*)(nint)oriCornerPosRatio)->y = 0f;
		base._002Ector();
	}

	[Token(Token = "0x6000F45")]
	[Address(RVA = "0x606C50", Offset = "0x605C50", VA = "0x180606C50")]
	static CUIImage()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
