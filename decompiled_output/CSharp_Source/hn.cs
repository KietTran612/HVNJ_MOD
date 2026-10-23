using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000C9")]
public class hn
{
	[Token(Token = "0x4000B5D")]
	public const sbyte joq = 0;

	[Token(Token = "0x4000B5E")]
	public const sbyte jor = 1;

	[Token(Token = "0x4000B5F")]
	public const sbyte jos = 2;

	[Token(Token = "0x4000B60")]
	public const sbyte jot = 3;

	[Token(Token = "0x4000B61")]
	public const sbyte jou = 4;

	[Token(Token = "0x4000B62")]
	public const sbyte jov = 5;

	[Token(Token = "0x4000B63")]
	public const sbyte jow = 6;

	[Token(Token = "0x4000B64")]
	public const sbyte jox = 7;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000B65")]
	public GameObject joy;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000B66")]
	public TextMesh joz;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000B67")]
	public Vector3 jpa;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000B68")]
	private sbyte jpb;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000B69")]
	public float jpc;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000B6A")]
	public float jpd;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000B6B")]
	public float jpe;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4000B6C")]
	public float jpf;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000B6D")]
	public Renderer jpg;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000B6E")]
	public Renderer[] jph;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000B6F")]
	private GameObject[] jpi;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000B70")]
	private MeshRenderer[] jpj;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000B71")]
	private TextMesh[] jpk;

	[Token(Token = "0x4000B72")]
	public static int jpl;

	[Token(Token = "0x4000B73")]
	public static bool jpm;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000B74")]
	private float jpn;

	[Token(Token = "0x4000B75")]
	public static Color jpo;

	[Token(Token = "0x4000B76")]
	private static sbyte[][] jpp;

	[Token(Token = "0x4000B77")]
	private static bool[] jpq;

	[Token(Token = "0x4000B78")]
	private static float[][] jpr;

	[Token(Token = "0x4000B79")]
	private static Color[] jps;

	[Token(Token = "0x4000B7A")]
	private static Vector3[] jpt;

	[Token(Token = "0x60005F4")]
	[Address(RVA = "0x7E7E60", Offset = "0x7E6E60", VA = "0x1807E7E60")]
	public float bxt()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005F5")]
	[Address(RVA = "0x7E7F60", Offset = "0x7E6F60", VA = "0x1807E7F60")]
	public void bxu(bool isA)
	{
		if (jpg.enabled == isA)
		{
			return;
		}
		jpg.enabled = isA;
		Renderer[] array = jph;
		if (array != null)
		{
			int num = 0;
			int num2 = 0;
			if (num2 < array.Length)
			{
				array[num2].enabled = isA;
				Renderer[] array2 = jph;
				num++;
			}
		}
	}

	[Token(Token = "0x60005F6")]
	[Address(RVA = "0x7E8020", Offset = "0x7E7020", VA = "0x1807E8020")]
	public float bxv()
	{
		return jpc;
	}

	[Token(Token = "0x60005F7")]
	[Address(RVA = "0x7E80F0", Offset = "0x7E70F0", VA = "0x1807E80F0")]
	public float bxw()
	{
		return jpd;
	}

	[Token(Token = "0x60005F8")]
	[Address(RVA = "0x7E6940", Offset = "0x7E5940", VA = "0x1807E6940")]
	public hn(GameObject objBG, string text, sbyte type, string name)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005F9")]
	[Address(RVA = "0x7E81C0", Offset = "0x7E71C0", VA = "0x1807E81C0")]
	public void bxx(int type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005FA")]
	[Address(RVA = "0x7E8440", Offset = "0x7E7440", VA = "0x1807E8440")]
	public void bxy(int order)
	{
		jpg.sortingOrder = order;
		MeshRenderer[] array = jpj;
		if (array != null)
		{
			int num = 0;
			if (num < array.Length)
			{
				Renderer renderer = jph[num];
				int sortingOrder = order - 1;
				renderer.sortingOrder = sortingOrder;
				MeshRenderer[] array2 = jpj;
				num++;
			}
		}
	}

	[Token(Token = "0x60005FB")]
	[Address(RVA = "0x7E7B80", Offset = "0x7E6B80", VA = "0x1807E7B80")]
	public hn(GameObject objBG, string text, int size, int color, sbyte layer)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005FC")]
	[Address(RVA = "0x7E7840", Offset = "0x7E6840", VA = "0x1807E7840")]
	public hn(GameObject objBG, string text, int size, int color, sbyte layer, Font font)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005FD")]
	[Address(RVA = "0x7E84E0", Offset = "0x7E74E0", VA = "0x1807E84E0")]
	public void bxz(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005FE")]
	[Address(RVA = "0x7E8880", Offset = "0x7E7880", VA = "0x1807E8880")]
	public void bya(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005FF")]
	[Address(RVA = "0x7E8C30", Offset = "0x7E7C30", VA = "0x1807E8C30")]
	public void byb(string text)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000600")]
	[Address(RVA = "0x7E8D90", Offset = "0x7E7D90", VA = "0x1807E8D90")]
	public void byc(Vector3 pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000601")]
	[Address(RVA = "0x7E8DE0", Offset = "0x7E7DE0", VA = "0x1807E8DE0")]
	public void close()
	{
		Object.Destroy(joy);
	}

	[Token(Token = "0x6000602")]
	[Address(RVA = "0x7E5C40", Offset = "0x7E4C40", VA = "0x1807E5C40")]
	static hn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
