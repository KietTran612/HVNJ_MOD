using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000220")]
[AddComponentMenu("UI/Extensions/Primitives/UI Polygon")]
public class UIPolygon : UIPrimitiveBase
{
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001C26")]
	public bool fill = true;

	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4001C27")]
	public float thickness = 5f;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4001C28")]
	[Range(3f, 360f)]
	public int sides = 3;

	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4001C29")]
	[Range(0f, 360f)]
	public float rotation;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4001C2A")]
	[Range(0f, 1f)]
	public float[] VerticesDistances = new float[3];

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001C2B")]
	private float pfd;

	[Token(Token = "0x600119C")]
	[Address(RVA = "0x8851C0", Offset = "0x8841C0", VA = "0x1808851C0")]
	public void ewm(int _sides)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600119D")]
	[Address(RVA = "0x885270", Offset = "0x884270", VA = "0x180885270")]
	public void ewn(int _sides, float[] _VerticesDistances)
	{
		sides = _sides;
		VerticesDistances = _VerticesDistances;
		rotation = 0f;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x600119E")]
	[Address(RVA = "0x8852A0", Offset = "0x8842A0", VA = "0x1808852A0")]
	public void ewo(int _sides, float[] _VerticesDistances, float _rotation)
	{
		rotation = _rotation;
		sides = _sides;
		VerticesDistances = _VerticesDistances;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x600119F")]
	[Address(RVA = "0x884FB0", Offset = "0x883FB0", VA = "0x180884FB0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011A0")]
	[Address(RVA = "0x884A10", Offset = "0x883A10", VA = "0x180884A10", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011A1")]
	[Address(RVA = "0x885120", Offset = "0x884120", VA = "0x180885120")]
	public UIPolygon()
	{
		//IL_001b: Expected I4, but got I8
	}
}
