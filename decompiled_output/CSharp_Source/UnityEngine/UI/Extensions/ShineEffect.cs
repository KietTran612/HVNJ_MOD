using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D9")]
public class ShineEffect : MaskableGraphic
{
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4001A6D")]
	[SerializeField]
	private float yoffset = -1f;

	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x4001A6E")]
	[SerializeField]
	private float width = 1f;

	[Token(Token = "0x17000091")]
	public float ptj
	{
		[Token(Token = "0x6000FAD")]
		[Address(RVA = "0x48AA60", Offset = "0x489A60", VA = "0x18048AA60")]
		get
		{
			return yoffset;
		}
		[Token(Token = "0x6000FAE")]
		[Address(RVA = "0x48AA70", Offset = "0x489A70", VA = "0x18048AA70")]
		set
		{
			SetVerticesDirty();
			yoffset = value;
		}
	}

	[Token(Token = "0x17000092")]
	public float ptk
	{
		[Token(Token = "0x6000FAF")]
		[Address(RVA = "0x48AAB0", Offset = "0x489AB0", VA = "0x18048AAB0")]
		get
		{
			return width;
		}
		[Token(Token = "0x6000FB0")]
		[Address(RVA = "0x48AAC0", Offset = "0x489AC0", VA = "0x18048AAC0")]
		set
		{
			SetAllDirty();
			width = value;
		}
	}

	[Token(Token = "0x6000FB1")]
	[Address(RVA = "0x48A320", Offset = "0x489320", VA = "0x18048A320", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FB2")]
	[Address(RVA = "0x48AB00", Offset = "0x489B00", VA = "0x18048AB00")]
	public void eke(VertexHelper vh)
	{
		//IL_000f: Expected Obj, but got I4
		int currentVertCount = vh.currentVertCount;
		int num = 0;
		Debug.Log(currentVertCount);
		currentVertCount -= num;
		int num2 = currentVertCount + 1;
		int num3 = 0;
		uint num4 = default;
		uint idx = num4 - 1;
		uint idx2 = num4 + 1;
		vh.AddTriangle((int)idx, (int)num4, (int)idx2);
		uint idx3 = num4 + 1;
		vh.AddTriangle((int)idx3, (int)num4, (int)num4);
		while (currentVertCount <= num2)
		{
		}
	}

	[Token(Token = "0x6000FB3")]
	[Address(RVA = "0x48AA40", Offset = "0x489A40", VA = "0x18048AA40")]
	public ShineEffect()
	{
	}
}
