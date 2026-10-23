using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000C7")]
public class hl
{
	[Token(Token = "0x4000B2B")]
	public const sbyte jms = 0;

	[Token(Token = "0x4000B2C")]
	public const sbyte jmt = 1;

	[Token(Token = "0x4000B2D")]
	public const sbyte jmu = 2;

	[Token(Token = "0x4000B2E")]
	public const sbyte jmv = 3;

	[Token(Token = "0x4000B2F")]
	public const sbyte jmw = 4;

	[Token(Token = "0x4000B30")]
	public const sbyte jmx = 5;

	[Token(Token = "0x4000B31")]
	public const sbyte jmy = 6;

	[Token(Token = "0x4000B32")]
	public const sbyte jmz = 7;

	[Token(Token = "0x4000B33")]
	public const sbyte jna = 8;

	[Token(Token = "0x4000B34")]
	public const int jnb = -21;

	[Token(Token = "0x4000B35")]
	public const int jnc = -36;

	[Token(Token = "0x4000B36")]
	public const int jnd = -30;

	[Token(Token = "0x4000B37")]
	public const int jne = -25;

	[Token(Token = "0x4000B38")]
	public const int jnf = -20;

	[Token(Token = "0x4000B39")]
	public const int jng = 10;

	[Token(Token = "0x4000B3A")]
	public const int jnh = 16;

	[Token(Token = "0x4000B3B")]
	public const int jni = 20;

	[Token(Token = "0x4000B3C")]
	public const int jnj = 30;

	[Token(Token = "0x4000B3D")]
	public const int jnk = 35;

	[Token(Token = "0x4000B3E")]
	public const int jnl = 37;

	[Token(Token = "0x4000B3F")]
	public const int jnm = 41;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000B40")]
	public GameObject jnn;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000B41")]
	public Transform jno;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000B42")]
	public Material jnp;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000B43")]
	public SpriteRenderer jnq;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000B44")]
	public float jnr;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000B45")]
	public float jns;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000B46")]
	public float jnt;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4000B47")]
	public float jnu;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000B48")]
	public float jnv;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000B49")]
	public float jnw;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000B4A")]
	public float jnx;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4000B4B")]
	public float jny;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000B4C")]
	public int jnz;

	[Token(Token = "0x4000B4D")]
	public const sbyte joa = 0;

	[Token(Token = "0x4000B4E")]
	public const sbyte job = 1;

	[Token(Token = "0x4000B4F")]
	public const sbyte joc = 2;

	[Token(Token = "0x4000B50")]
	public const sbyte jod = 3;

	[Token(Token = "0x4000B51")]
	public const sbyte joe = 4;

	[Token(Token = "0x4000B52")]
	public const sbyte jof = 5;

	[Token(Token = "0x60005B8")]
	[Address(RVA = "0x7E4FA0", Offset = "0x7E3FA0", VA = "0x1807E4FA0")]
	public void close()
	{
		Object.Destroy(jnn);
	}

	[Token(Token = "0x60005B9")]
	[Address(RVA = "0x7E20B0", Offset = "0x7E10B0", VA = "0x1807E20B0")]
	public void bwa()
	{
		jnq.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
	}

	[Token(Token = "0x60005BA")]
	[Address(RVA = "0x7E20E0", Offset = "0x7E10E0", VA = "0x1807E20E0")]
	public void bwb(Sprite spr, Material mat)
	{
		jnq.sprite = spr;
		jnp = mat;
	}

	[Token(Token = "0x60005BB")]
	[Address(RVA = "0x7E1170", Offset = "0x7E0170", VA = "0x1807E1170")]
	public hl(GameObject objBG, string name, Material mat, Sprite sprite, sbyte order, float w0)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005BC")]
	[Address(RVA = "0x7E0860", Offset = "0x7DF860", VA = "0x1807E0860")]
	public hl(GameObject objBG, GameObject obj, string name, float w0)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005BD")]
	[Address(RVA = "0x7E18F0", Offset = "0x7E08F0", VA = "0x1807E18F0")]
	public hl(GameObject objBG, string name, float w0, float h0, Sprite sprite, int order)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005BE")]
	[Address(RVA = "0x7E13A0", Offset = "0x7E03A0", VA = "0x1807E13A0")]
	public hl(GameObject objBG, string name, string path, float w0, float h0, sbyte order)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005BF")]
	[Address(RVA = "0x7E1620", Offset = "0x7E0620", VA = "0x1807E1620")]
	public hl(GameObject objBg, string name, string path, sbyte order)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005C0")]
	[Address(RVA = "0x7DF970", Offset = "0x7DE970", VA = "0x1807DF970")]
	public hl(GameObject objBg, string name, string path, sbyte order, bool isScale)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005C1")]
	[Address(RVA = "0x7E0A10", Offset = "0x7DFA10", VA = "0x1807E0A10")]
	public hl(GameObject objBg, string name, Sprite sprite, int order, bool isScale)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005C2")]
	[Address(RVA = "0x7E0DE0", Offset = "0x7DFDE0", VA = "0x1807E0DE0")]
	public hl(GameObject objBg, string name, Sprite sprite, int order, int id, bool isScale)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005C3")]
	[Address(RVA = "0x7E02B0", Offset = "0x7DF2B0", VA = "0x1807E02B0")]
	public hl(GameObject objBg, string name, Sprite sprite, object p, int order)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005C4")]
	[Address(RVA = "0x7DFCE0", Offset = "0x7DECE0", VA = "0x1807DFCE0")]
	public hl(GameObject objBG, string name, float w0, float h0, int color, int order)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005C5")]
	[Address(RVA = "0x7E2120", Offset = "0x7E1120", VA = "0x1807E2120")]
	public void bwc(Color color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005C6")]
	[Address(RVA = "0x7E2150", Offset = "0x7E1150", VA = "0x1807E2150")]
	public void bwd(float w0, float h0)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005C7")]
	[Address(RVA = "0x7E2460", Offset = "0x7E1460", VA = "0x1807E2460")]
	public float bwe()
	{
		return jnr;
	}

	[Token(Token = "0x60005C8")]
	[Address(RVA = "0x7E2530", Offset = "0x7E1530", VA = "0x1807E2530")]
	public float bwf()
	{
		return jns;
	}

	[Token(Token = "0x60005C9")]
	[Address(RVA = "0x7E1E00", Offset = "0x7E0E00", VA = "0x1807E1E00")]
	public hl(GameObject objBg, string name, Sprite sprite, sbyte order, sbyte sortLayer)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005CA")]
	[Address(RVA = "0x7E05F0", Offset = "0x7DF5F0", VA = "0x1807E05F0")]
	public hl(GameObject objBG, string name, Material mat, Sprite sprite, sbyte order)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005CB")]
	[Address(RVA = "0x7E2600", Offset = "0x7E1600", VA = "0x1807E2600")]
	private void bwg(float wTo)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005CC")]
	[Address(RVA = "0x7E2820", Offset = "0x7E1820", VA = "0x1807E2820")]
	public void bwh(float w, float h)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005CD")]
	[Address(RVA = "0x7E2A80", Offset = "0x7E1A80", VA = "0x1807E2A80")]
	private void bwi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005CE")]
	[Address(RVA = "0x7E2C70", Offset = "0x7E1C70", VA = "0x1807E2C70")]
	public static void bwj(GameObject obj, float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005CF")]
	[Address(RVA = "0x7E2DB0", Offset = "0x7E1DB0", VA = "0x1807E2DB0")]
	public void bwk(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D0")]
	[Address(RVA = "0x7E2F40", Offset = "0x7E1F40", VA = "0x1807E2F40")]
	public static void bwl(GameObject obj, float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D1")]
	[Address(RVA = "0x7E3080", Offset = "0x7E2080", VA = "0x1807E3080")]
	public static Vector3 bwm(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D2")]
	[Address(RVA = "0x7E3190", Offset = "0x7E2190", VA = "0x1807E3190")]
	public void bwn(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D3")]
	[Address(RVA = "0x7E3310", Offset = "0x7E2310", VA = "0x1807E3310")]
	public void bwo(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D4")]
	[Address(RVA = "0x7E34A0", Offset = "0x7E24A0", VA = "0x1807E34A0")]
	public void bwp(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D5")]
	[Address(RVA = "0x7E3630", Offset = "0x7E2630", VA = "0x1807E3630")]
	public void bwq(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D6")]
	[Address(RVA = "0x7E37B0", Offset = "0x7E27B0", VA = "0x1807E37B0")]
	public float bwr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D7")]
	[Address(RVA = "0x7E3870", Offset = "0x7E2870", VA = "0x1807E3870")]
	public void bws(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D8")]
	[Address(RVA = "0x7E39F0", Offset = "0x7E29F0", VA = "0x1807E39F0")]
	public void bwt(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005D9")]
	[Address(RVA = "0x7E3B60", Offset = "0x7E2B60", VA = "0x1807E3B60")]
	public void bwu(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005DA")]
	[Address(RVA = "0x7E3CD0", Offset = "0x7E2CD0", VA = "0x1807E3CD0")]
	public void bwv(Sprite sprite)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005DB")]
	[Address(RVA = "0x7E3E80", Offset = "0x7E2E80", VA = "0x1807E3E80")]
	public void bww(kj img)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005DC")]
	[Address(RVA = "0x7E4020", Offset = "0x7E3020", VA = "0x1807E4020")]
	public void bwx(bool isA)
	{
		jnn.SetActive(isA);
	}

	[Token(Token = "0x60005DD")]
	[Address(RVA = "0x7E4040", Offset = "0x7E3040", VA = "0x1807E4040")]
	public void bwy(bool isA)
	{
		//IL_0010: Expected Obj, but got I4
		SpriteRenderer spriteRenderer = jnq;
		int num = 0;
		if (spriteRenderer != (Object)num && jnq.enabled != isA)
		{
			jnq.enabled = isA;
		}
	}

	[Token(Token = "0x60005DE")]
	[Address(RVA = "0x7E40F0", Offset = "0x7E30F0", VA = "0x1807E40F0")]
	public static void bwz(GameObject obj, float wTo)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005DF")]
	[Address(RVA = "0x7E4310", Offset = "0x7E3310", VA = "0x1807E4310")]
	public static hl bxa(GameObject objFarent, hl sprRender, Sprite spr, int order, string name)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005E0")]
	[Address(RVA = "0x7E4400", Offset = "0x7E3400", VA = "0x1807E4400")]
	public static hl bxb(GameObject objFarent, hl sprRender, Sprite spr, int order, string name, sbyte layer)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005E1")]
	[Address(RVA = "0x7E4500", Offset = "0x7E3500", VA = "0x1807E4500")]
	public static hl bxc(hl sprRender, int id, sbyte transf, int order, string name)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005E2")]
	[Address(RVA = "0x7E4690", Offset = "0x7E3690", VA = "0x1807E4690")]
	public static hl bxd(GameObject objFarent, hl sprRender, float x, float y, Sprite spr, int order, string name, sbyte othor, int transf)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005E3")]
	[Address(RVA = "0x7E4860", Offset = "0x7E3860", VA = "0x1807E4860")]
	public static hl bxe(GameObject objFarent, hl sprRender, float x, float y, short id, int order, string name, sbyte othor, int transf)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005E4")]
	[Address(RVA = "0x7E4B00", Offset = "0x7E3B00", VA = "0x1807E4B00")]
	public void bxf(float ang)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005E5")]
	[Address(RVA = "0x7E4B40", Offset = "0x7E3B40", VA = "0x1807E4B40")]
	private void bxg(int transf)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005E6")]
	[Address(RVA = "0x7E4D50", Offset = "0x7E3D50", VA = "0x1807E4D50")]
	public static hl bxh(hl sprRender, int x, int y, sbyte othor)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005E7")]
	[Address(RVA = "0x7E4DF0", Offset = "0x7E3DF0", VA = "0x1807E4DF0")]
	public static void bxi(hl img)
	{
		if (img != null)
		{
			Object.Destroy(img.jnn);
		}
	}

	[Token(Token = "0x60005E8")]
	[Address(RVA = "0x7E4E50", Offset = "0x7E3E50", VA = "0x1807E4E50")]
	public static Sprite bxj(Texture2D texture, float x0, float y0, float w0, float h0)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
