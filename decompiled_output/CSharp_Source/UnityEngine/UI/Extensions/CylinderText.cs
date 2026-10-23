using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001C7")]
[RequireComponent(typeof(Text), typeof(RectTransform))]
[AddComponentMenu("UI/Effects/Extensions/Cylinder Text")]
public class CylinderText : BaseMeshEffect
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A35")]
	public float radius;

	[Token(Token = "0x6000F53")]
	[Address(RVA = "0x602610", Offset = "0x601610", VA = "0x180602610", Slot = "4")]
	protected override void Awake()
	{
		((object)this)._002Ector();
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6000F54")]
	[Address(RVA = "0x602800", Offset = "0x601800", VA = "0x180602800", Slot = "5")]
	protected override void OnEnable()
	{
		base.OnEnable();
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6000F55")]
	[Address(RVA = "0x69A130", Offset = "0x699130", VA = "0x18069A130", Slot = "20")]
	public unsafe override void ModifyMesh(VertexHelper vh)
	{
		//IL_0041: Expected VT, but got I4
		int num = 0;
		if (!IsActive())
		{
			return;
		}
		int currentVertCount = vh.currentVertCount;
		if (IsActive() && currentVertCount != 0)
		{
			int num2 = 0;
			int currentVertCount2 = vh.currentVertCount;
			if (num2 < currentVertCount2)
			{
				int num3 = 0;
				vh.PopulateUIVertex(ref *(UIVertex*)num3, num2);
				vh.SetUIVertex((UIVertex)num3, num2);
				num2++;
			}
		}
	}

	[Token(Token = "0x6000F56")]
	[Address(RVA = "0x4429E0", Offset = "0x4419E0", VA = "0x1804429E0")]
	public CylinderText()
	{
	}
}
