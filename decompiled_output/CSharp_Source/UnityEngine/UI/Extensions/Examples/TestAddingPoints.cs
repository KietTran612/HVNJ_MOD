using System;
using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000293")]
public class TestAddingPoints : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DE6")]
	public UILineRenderer LineRenderer;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DE7")]
	public Text XValue;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DE8")]
	public Text YValue;

	[Token(Token = "0x600141C")]
	[Address(RVA = "0x491AF0", Offset = "0x490AF0", VA = "0x180491AF0")]
	public void fjo()
	{
		//IL_0034: Expected I4, but got Obj
		//IL_003c: Expected VT, but got Obj
		float num = float.Parse(XValue.text);
		float num2 = float.Parse(YValue.text);
		Vector2[] points = LineRenderer.m_points;
		List<Vector2> list = (List<Vector2>)(object)new List<T>((int)points);
		((List<T>)(object)list).Add((T)points);
		UILineRenderer lineRenderer = LineRenderer;
		Vector2[] value = (Vector2[])(object)((List<T>)(object)list).ToArray();
		lineRenderer.pvv = value;
	}

	[Token(Token = "0x600141D")]
	[Address(RVA = "0x491C40", Offset = "0x490C40", VA = "0x180491C40")]
	public void fjp()
	{
		int num = 0;
		UILineRenderer lineRenderer = LineRenderer;
		Vector2[] value = new Vector2[num];
		lineRenderer.pvv = value;
		TypeCode typeCode = ((IConvertible)LineRenderer).GetTypeCode();
	}

	[Token(Token = "0x600141E")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public TestAddingPoints()
	{
	}
}
