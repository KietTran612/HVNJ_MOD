using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using Spine.Unity;

[Token(Token = "0x20000D6")]
public class ib
{
	[Token(Token = "0x4000C68")]
	public static List<ib> jyx;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000C69")]
	public int jyy;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4000C6A")]
	public int jyz;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000C6B")]
	public int jza;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000C6C")]
	public int jzb;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000C6D")]
	public int jzc;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000C6E")]
	public float jzd;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000C6F")]
	public float jze;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000C70")]
	public float jzf;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000C71")]
	public float jzg;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000C72")]
	public lm jzh;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000C73")]
	public ic jzi;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000C74")]
	private sbyte jzj;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4000C75")]
	public int jzk;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000C76")]
	public lg jzl;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000C77")]
	public sbyte jzm;

	[FieldOffset(Offset = "0x59")]
	[Token(Token = "0x4000C78")]
	public bool jzn;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000C79")]
	public km jzo;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000C7A")]
	private SkeletonAnimation jzp;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000C7B")]
	public bool jzq;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000C7C")]
	private float jzr;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000C7D")]
	private float jzs;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000C7E")]
	private hl jzt;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000C7F")]
	private hl jzu;

	[Token(Token = "0x4000C80")]
	private static short[][] jzv;

	[Token(Token = "0x4000C81")]
	public static sbyte[] jzw;

	[Token(Token = "0x4000C82")]
	public static int[] jzx;

	[Token(Token = "0x60006CF")]
	[Address(RVA = "0x367A70", Offset = "0x366A70", VA = "0x180367A70")]
	public ib()
	{
		//IL_000a: Expected I4, but got I8
		jyy = 100;
		base._002Ector();
	}

	[Token(Token = "0x60006D0")]
	[Address(RVA = "0x367920", Offset = "0x366920", VA = "0x180367920")]
	public ib(lm owner, ic arrp, lg focus)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006D1")]
	[Address(RVA = "0x367A80", Offset = "0x366A80", VA = "0x180367A80")]
	public ib(lm owner, int idArr, lg focus)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006D2")]
	[Address(RVA = "0x367E40", Offset = "0x366E40", VA = "0x180367E40", Slot = "4")]
	public virtual void ceq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006D3")]
	[Address(RVA = "0x368180", Offset = "0x367180", VA = "0x180368180")]
	public void cer()
	{
		//IL_0050: Expected Obj, but got I4
		//IL_0065: Expected Obj, but got I4
		//IL_0073: Expected Obj, but got I4
		//IL_0090: Expected F4, but got I4
		//IL_0097: Expected F4, but got I4
		//IL_0037: Expected Obj, but got I4
		jzq = true;
		if (!jzn)
		{
			jzn = true;
			int num = 0;
			km km2 = jzo;
			if (km2 != null)
			{
				int isS = 0;
				km2.cky((byte)isS != 0);
				jzo = (km)num;
			}
			hl.bxi(jzt);
			hl img = jzu;
			jzt = (hl)num;
			hl.bxi(img);
			lm lm2 = jzh;
			jzu = (hl)num;
			lm2.moh[0] = (ib)num;
			lm lm3 = jzh;
			jzb = num;
			jyz = num;
			jzf = num;
			jzd = num;
			lm3.cvl();
			lm lm4 = jzh;
			if ((lm4.mhv ? 1 : 0) != num)
			{
				lm4.mos = true;
				jzh.saveLoadPreviousSkill();
			}
		}
	}

	[Token(Token = "0x60006D4")]
	[Address(RVA = "0x368280", Offset = "0x367280", VA = "0x180368280", Slot = "5")]
	public virtual void ces()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006D5")]
	[Address(RVA = "0x369EE0", Offset = "0x368EE0", VA = "0x180369EE0")]
	private int cet()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006D6")]
	[Address(RVA = "0x369F90", Offset = "0x368F90", VA = "0x180369F90")]
	public static int ceu(int angle)
	{
		int num = 0;
		int length = jzx.Length;
		if (num < length)
		{
			int[] array = jzx;
			int[] array2 = jzx;
			if (angle > unchecked((nint)"{il2cpp array field local5->}"))
			{
				num++;
			}
			return num;
		}
		throw new NullReferenceException();
	}

	[Token(Token = "0x60006D7")]
	[Address(RVA = "0x36A0E0", Offset = "0x3690E0", VA = "0x18036A0E0")]
	public void close()
	{
		//IL_003f: Expected Obj, but got I8
		//IL_004e: Expected Obj, but got I8
		//IL_0024: Expected Obj, but got I8
		jzq = true;
		km km2 = jzo;
		if (km2 != null)
		{
			int isS = 0;
			km2.cky((byte)isS != 0);
			jzo = (km)0;
		}
		hl.bxi(jzt);
		hl img = jzu;
		jzt = (hl)0;
		hl.bxi(img);
		jzu = (hl)0;
	}

	[Token(Token = "0x60006D8")]
	[Address(RVA = "0x367170", Offset = "0x366170", VA = "0x180367170")]
	static ib()
	{
		//IL_0034: Expected I4, but got Obj
		//IL_0056: Expected I4, but got Obj
		//IL_0078: Expected I4, but got Obj
		//IL_00a3: Expected I4, but got Obj
		//IL_00cd: Expected I4, but got Obj
		//IL_00f7: Expected I4, but got Obj
		//IL_0121: Expected I4, but got Obj
		//IL_014b: Expected I4, but got Obj
		//IL_0175: Expected I4, but got Obj
		//IL_01a0: Expected I4, but got Obj
		//IL_01cb: Expected I4, but got Obj
		//IL_01f6: Expected I4, but got Obj
		//IL_0221: Expected I4, but got Obj
		short[][] array;
		short[] array14;
		while (true)
		{
			jyx = (List<ib>)(object)new List<T>();
			array = new short[13][];
			short[] array2 = new short[4];
			RuntimeHelpers.InitializeArray(array2, __ldtoken(_003CPrivateImplementationDetails_003E.B653E98B914854D2A96D14B61E8D7463447F97464C1E3781BEA97657ECD29326));
			if (array2 != null && array2 == null)
			{
				continue;
			}
			((short[])(object)array)[0] = (short)(int)array2;
			short[] array3 = new short[3] { 2147, 2148, 2149 };
			if (array3 != null && array3 == null)
			{
				continue;
			}
			((short[])(object)array)[1] = (short)(int)array3;
			short[] array4 = new short[4];
			RuntimeHelpers.InitializeArray(array4, __ldtoken(_003CPrivateImplementationDetails_003E._76624ED1A6F2741D79256F277C4145AC3E2C7A3165E4C3B88BD57A950D5072E7));
			if (array4 != null && array4 == null)
			{
				continue;
			}
			((short[])(object)array)[2] = (short)(int)array4;
			short[] array5 = new short[11]
			{
				2603, 175, 176, 177, 178, 179, 1329, 1534, 2011, 39,
				2693
			};
			if (array5 != null && array5 == null)
			{
				continue;
			}
			((short[])(object)array)[3] = (short)(int)array5;
			short[] array6 = new short[3] { 2450, 2451, 2452 };
			if (array6 != null && array6 == null)
			{
				continue;
			}
			((short[])(object)array)[4] = (short)(int)array6;
			short[] array7 = new short[3] { 2331, 2331, 2331 };
			if (array7 != null && array7 == null)
			{
				continue;
			}
			((short[])(object)array)[5] = (short)(int)array7;
			short[] array8 = new short[3] { 2331, 2331, 2331 };
			if (array8 != null && array8 == null)
			{
				continue;
			}
			((short[])(object)array)[6] = (short)(int)array8;
			short[] array9 = new short[3] { 2330, 2330, 2330 };
			if (array9 != null && array9 == null)
			{
				continue;
			}
			((short[])(object)array)[7] = (short)(int)array9;
			short[] array10 = new short[3] { 2329, 2329, 2329 };
			if (array10 != null && array10 == null)
			{
				continue;
			}
			((short[])(object)array)[8] = (short)(int)array10;
			short[] array11 = new short[3] { 2328, 2328, 2328 };
			if (array11 != null && array11 == null)
			{
				continue;
			}
			((short[])(object)array)[9] = (short)(int)array11;
			short[] array12 = new short[3] { 2328, 2328, 2328 };
			if (array12 != null && array12 == null)
			{
				continue;
			}
			((short[])(object)array)[10] = (short)(int)array12;
			short[] array13 = new short[3] { 2327, 2327, 2327 };
			if (array13 == null || array13 != null)
			{
				((short[])(object)array)[11] = (short)(int)array13;
				array14 = new short[3] { 2327, 2327, 2327 };
				if (array14 == null || array14 != null)
				{
					break;
				}
			}
		}
		((short[])(object)array)[12] = (short)(int)array14;
		jzv = array;
		jzw = new sbyte[25]
		{
			0, 1, 2, 1, 0, 1, 2, 1, 0, 1,
			2, 1, 0, 1, 2, 1, 0, 1, 2, 1,
			0, 1, 2, 1, 0
		};
		jzx = new int[18]
		{
			0, 15, 37, 52, 75, 105, 127, 142, 165, 195,
			217, 232, 255, 285, 307, 322, 345, 370
		};
	}
}
