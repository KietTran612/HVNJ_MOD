using System;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000BE")]
public class hf : he
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000AC0")]
	public int jke;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4000AC1")]
	public int jkf;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000AC2")]
	public int jkg;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000AC3")]
	public short jkh;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000AC4")]
	public float jki;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000AC5")]
	public float jkj;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000AC6")]
	public float jkk;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000AC7")]
	private int jkl;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000AC8")]
	public bool jkm;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000AC9")]
	public int jkn;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000ACA")]
	public int jko;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4000ACB")]
	public int jkp;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000ACC")]
	public lg jkq;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000ACD")]
	public @in jkr;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000ACE")]
	public bool jks;

	[FieldOffset(Offset = "0x52")]
	[Token(Token = "0x4000ACF")]
	public short jkt;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4000AD0")]
	private int jku;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000AD1")]
	public kg jkv;

	[Token(Token = "0x4000AD2")]
	public static int jkw;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000AD3")]
	private int jkx;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000AD4")]
	public jc jky;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000AD5")]
	private sbyte jkz;

	[FieldOffset(Offset = "0x71")]
	[Token(Token = "0x4000AD6")]
	public bool jla;

	[Token(Token = "0x4000AD7")]
	public static int jlb;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000AD8")]
	public int jlc;

	[Token(Token = "0x4000AD9")]
	public static int jld = (jlb = 0);

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000ADA")]
	private int jle;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4000ADB")]
	private int jlf;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000ADC")]
	private int jlg;

	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4000ADD")]
	private int jlh;

	[Token(Token = "0x4000ADE")]
	public static sbyte[] jli = new sbyte[25]
	{
		0, 1, 2, 1, 0, 1, 2, 1, 0, 1,
		2, 1, 0, 1, 2, 1, 0, 1, 2, 1,
		0, 1, 2, 1, 0
	};

	[Token(Token = "0x4000ADF")]
	public static int[] jlj = new int[16]
	{
		0, 0, 0, 7, 6, 6, 6, 2, 2, 3,
		3, 4, 5, 5, 5, 1
	};

	[Token(Token = "0x4000AE0")]
	public static int[] jlk = new int[18]
	{
		0, 15, 37, 52, 75, 105, 127, 142, 165, 195,
		217, 232, 255, 285, 307, 322, 345, 370
	};

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000AE1")]
	private hl jll;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000AE2")]
	private float jlm;

	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4000AE3")]
	private float jln;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000AE4")]
	private int jlo;

	[Token(Token = "0x6000582")]
	[Address(RVA = "0x7DC4D0", Offset = "0x7DB4D0", VA = "0x1807DC4D0")]
	public void bvb(int angle)
	{
		jke = angle;
		int num = ht.cao(angle);
		jkf = num;
		int num2 = ht.cam(angle);
		jkg = num2;
	}

	[Token(Token = "0x6000583")]
	[Address(RVA = "0x7DC560", Offset = "0x7DB560", VA = "0x1807DC560")]
	public static void bvc(float x, float y, bool isBoss, short level, kg template, int dame, int dameMp, lg c, int typeB)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000584")]
	[Address(RVA = "0x7DC6E0", Offset = "0x7DB6E0", VA = "0x1807DC6E0")]
	public static void bvd(float x, float y, bool isBoss, short level, kg template, int dame, int dameMp, lg c, int typeB, int idEff)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000585")]
	[Address(RVA = "0x7DC860", Offset = "0x7DB860", VA = "0x1807DC860")]
	public static void bve(float x, float y, @in b)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000586")]
	[Address(RVA = "0x7DB200", Offset = "0x7DA200", VA = "0x1807DB200")]
	public hf(float x, float y, bool isBoss, short levelBoss, kg template, int dame, int dameMp, lg c, int typeB, int idEff)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000587")]
	[Address(RVA = "0x7DB470", Offset = "0x7DA470", VA = "0x1807DB470")]
	public hf(float x, float y, @in b)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000588")]
	[Address(RVA = "0x7DB670", Offset = "0x7DA670", VA = "0x1807DB670", Slot = "4")]
	public override void buz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000589")]
	[Address(RVA = "0x7DC950", Offset = "0x7DB950", VA = "0x1807DC950")]
	private int bvf(int time)
	{
		int jtg = hw.jtg;
		return time;
	}

	[Token(Token = "0x600058A")]
	[Address(RVA = "0x7DC9C0", Offset = "0x7DB9C0", VA = "0x1807DC9C0")]
	public void bvg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600058B")]
	[Address(RVA = "0x7DCAA0", Offset = "0x7DBAA0", VA = "0x1807DCAA0")]
	private void bvh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600058C")]
	[Address(RVA = "0x7DCAF0", Offset = "0x7DBAF0", VA = "0x1807DCAF0")]
	private void bvi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600058D")]
	[Address(RVA = "0x7DD060", Offset = "0x7DC060", VA = "0x1807DD060")]
	public static int bvj(int angle)
	{
		int num = 0;
		int length = jlk.Length;
		if (num < length)
		{
			int[] array = jlk;
			int[] array2 = jlk;
			if (angle > unchecked((nint)"{il2cpp array field local5->}"))
			{
				num++;
			}
			return num;
		}
		throw new NullReferenceException();
	}

	[Token(Token = "0x600058E")]
	[Address(RVA = "0x7DBDF0", Offset = "0x7DADF0", VA = "0x1807DBDF0", Slot = "5")]
	public override void bva()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600058F")]
	[Address(RVA = "0x7DD1B0", Offset = "0x7DC1B0", VA = "0x1807DD1B0", Slot = "6")]
	public override void close()
	{
		hl hl2 = jll;
		if (hl2 != null)
		{
			UnityEngine.Object.Destroy(hl2.jnn);
		}
	}
}
