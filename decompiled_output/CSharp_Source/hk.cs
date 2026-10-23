using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000C4")]
public class hk
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000B20")]
	public RectTransform jmm;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000B21")]
	public float jmn;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000B22")]
	public float jmo;

	[Token(Token = "0x60005AD")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public hk()
	{
	}

	[Token(Token = "0x60005AE")]
	[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
	public hk(RectTransform rect)
	{
		jmm = rect;
	}

	[Token(Token = "0x60005AF")]
	[Address(RVA = "0x7DF710", Offset = "0x7DE710", VA = "0x1807DF710")]
	public void bvx(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005B0")]
	[Address(RVA = "0x7DF8D0", Offset = "0x7DE8D0", VA = "0x1807DF8D0")]
	public void bvy(bool isA)
	{
		//IL_0010: Expected Obj, but got I4
		RectTransform rectTransform = jmm;
		int num = 0;
		if (rectTransform != (Object)num)
		{
			jmm.gameObject.SetActive(isA);
		}
	}
}
