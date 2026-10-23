using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001E4")]
[ExecuteInEditMode]
public class SuperellipsePoints : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001ACB")]
	public float xLimits = 1f;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001ACC")]
	public float yLimits = 1f;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001ACD")]
	[Range(1f, 96f)]
	public float superness = 4f;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001ACE")]
	private float ozs;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001ACF")]
	private float ozt;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4001AD0")]
	private float ozu;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001AD1")]
	[Space]
	[Range(1f, 32f)]
	public int levelOfDetail = 4;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001AD2")]
	private int ozv;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001AD3")]
	[Space]
	public Material material;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001AD4")]
	private List<Vector2> ozw = (List<Vector2>)(object)new List<T>();

	[Token(Token = "0x6000FE8")]
	[Address(RVA = "0x48DA60", Offset = "0x48CA60", VA = "0x18048DA60")]
	private void Start()
	{
		ekz();
		MeshRenderer component = GetComponent<MeshRenderer>();
		Material material = this.material;
		((Renderer)component).SetMaterial(material);
		float num = xLimits;
		ozs = num;
		float num2 = yLimits;
		ozt = num2;
		float num3 = superness;
		ozu = num3;
		int num4 = levelOfDetail;
		ozv = num4;
	}

	[Token(Token = "0x6000FE9")]
	[Address(RVA = "0x48DAE0", Offset = "0x48CAE0", VA = "0x18048DAE0")]
	private void Update()
	{
		int num = levelOfDetail;
		if (ozv != num)
		{
			ekz();
		}
		float num2 = xLimits;
		ozs = num2;
		float num3 = yLimits;
		ozt = num3;
		float num4 = superness;
		ozu = num4;
		int num5 = levelOfDetail;
		ozv = num5;
	}

	[Token(Token = "0x6000FEA")]
	[Address(RVA = "0x48DBD0", Offset = "0x48CBD0", VA = "0x18048DBD0")]
	private void ekz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FEB")]
	[Address(RVA = "0x48DD90", Offset = "0x48CD90", VA = "0x18048DD90")]
	private float ela(float a, float b, float x, float n)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FEC")]
	[Address(RVA = "0x48DB40", Offset = "0x48CB40", VA = "0x18048DB40")]
	public SuperellipsePoints()
	{
		//IL_002a: Expected I4, but got I8
	}
}
