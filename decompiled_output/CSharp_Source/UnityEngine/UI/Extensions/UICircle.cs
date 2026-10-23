using System;
using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000214")]
[AddComponentMenu("UI/Extensions/Primitives/UI Circle")]
public class UICircle : UIPrimitiveBase
{
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001BBC")]
	[Tooltip("The Arc Invert property will invert the construction of the Arc.")]
	public bool ArcInvert;

	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4001BBD")]
	[Tooltip("The Arc property is a percentage of the entire circumference of the circle.")]
	[Range(0f, 1f)]
	public float Arc;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4001BBE")]
	[Tooltip("The Arc Steps property defines the number of segments that the Arc will be divided into.")]
	[Range(0f, 1000f)]
	public int ArcSteps;

	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4001BBF")]
	[Tooltip("The Arc Rotation property permits adjusting the geometry orientation around the Z axis.")]
	[Range(0f, 360f)]
	public int ArcRotation;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4001BC0")]
	[Tooltip("The Progress property allows the primitive to be used as a progression indicator.")]
	[Range(0f, 1f)]
	public float Progress;

	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x4001BC1")]
	private float pdw;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001BC2")]
	public Color ProgressColor;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4001BC3")]
	public bool Fill;

	[FieldOffset(Offset = "0x12C")]
	[Token(Token = "0x4001BC4")]
	public float Thickness;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x4001BC5")]
	public int Padding;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x4001BC6")]
	private List<int> pdx;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x4001BC7")]
	private List<UIVertex> pdy;

	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x4001BC8")]
	private Vector2 pdz;

	[Token(Token = "0x6001140")]
	[Address(RVA = "0x879E70", Offset = "0x878E70", VA = "0x180879E70", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001141")]
	[Address(RVA = "0x87AA30", Offset = "0x879A30", VA = "0x18087AA30")]
	public void etm(float progress)
	{
		Progress = progress;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6001142")]
	[Address(RVA = "0x87AA50", Offset = "0x879A50", VA = "0x18087AA50")]
	public void etn(int steps)
	{
		ArcSteps = steps;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6001143")]
	[Address(RVA = "0x87AA70", Offset = "0x879A70", VA = "0x18087AA70")]
	public void eto(bool invert)
	{
		ArcInvert = invert;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6001144")]
	[Address(RVA = "0x87AA90", Offset = "0x879A90", VA = "0x18087AA90")]
	public void etp(int rotation)
	{
		ArcRotation = rotation;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6001145")]
	[Address(RVA = "0x87AAB0", Offset = "0x879AB0", VA = "0x18087AAB0")]
	public void etq(bool fill)
	{
		Fill = fill;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6001146")]
	[Address(RVA = "0x87AAD0", Offset = "0x879AD0", VA = "0x18087AAD0")]
	public void etr(Color color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001147")]
	[Address(RVA = "0x87AB10", Offset = "0x879B10", VA = "0x18087AB10")]
	public void ets(float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001148")]
	[Address(RVA = "0x87AB90", Offset = "0x879B90", VA = "0x18087AB90")]
	public void ett(Color color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001149")]
	[Address(RVA = "0x87ABB0", Offset = "0x879BB0", VA = "0x18087ABB0")]
	public unsafe void etu(float value)
	{
		//IL_0007: Expected native int or pointer, but got VT
		((Color*)(nint)ProgressColor)->a = value;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x600114A")]
	[Address(RVA = "0x87ABD0", Offset = "0x879BD0", VA = "0x18087ABD0")]
	public void etv(int padding)
	{
		Padding = padding;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x600114B")]
	[Address(RVA = "0x87ABF0", Offset = "0x879BF0", VA = "0x18087ABF0")]
	public void etw(int thickness)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600114C")]
	[Address(RVA = "0x87A8D0", Offset = "0x8798D0", VA = "0x18087A8D0")]
	public UICircle()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
