using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000C3")]
public class hj
{
	[Token(Token = "0x4000B14")]
	private static char[] jma;

	[Token(Token = "0x4000B15")]
	private static float[] jmb;

	[Token(Token = "0x4000B16")]
	public static Font jmc;

	[Token(Token = "0x4000B17")]
	public static Font jmd;

	[Token(Token = "0x4000B18")]
	public static Font jme;

	[Token(Token = "0x4000B19")]
	public static Font jmf;

	[Token(Token = "0x4000B1A")]
	public static Font jmg;

	[Token(Token = "0x4000B1B")]
	public static Font jmh;

	[Token(Token = "0x4000B1C")]
	public static Font jmi;

	[Token(Token = "0x4000B1D")]
	public static Font jmj;

	[Token(Token = "0x4000B1E")]
	public static Font jmk;

	[Token(Token = "0x4000B1F")]
	private static float[][] jml;

	[Token(Token = "0x60005A4")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public hj()
	{
	}

	[Token(Token = "0x60005A5")]
	[Address(RVA = "0x7DEBF0", Offset = "0x7DDBF0", VA = "0x1807DEBF0")]
	public static void bvq()
	{
		//IL_001e: Expected Obj, but got I4
		while (true)
		{
			UnityEngine.Object obj = Resources.Load("font/Roboto-Regular");
			int num = 0;
			if ((object)obj != null && (object)obj == null)
			{
				break;
			}
			jmc = (Font)num;
			UnityEngine.Object obj2 = Resources.Load("font/Roboto-Bold");
			if ((object)obj2 != null && (object)obj2 == null)
			{
				continue;
			}
			jmd = (Font)obj2;
			UnityEngine.Object obj3 = Resources.Load("font/FredokaOne-Regular");
			if ((object)obj3 != null && (object)obj3 == null)
			{
				continue;
			}
			jme = (Font)obj3;
			UnityEngine.Object obj4 = Resources.Load("font/MyriadPro-Bold");
			if ((object)obj4 != null && (object)obj4 == null)
			{
				continue;
			}
			jmf = (Font)obj4;
			UnityEngine.Object obj5 = Resources.Load("font/DOKYO_");
			if ((object)obj5 == null || (object)obj5 != null)
			{
				jmg = (Font)obj5;
				UnityEngine.Object obj6 = Resources.Load("font/UTM Alexander");
				if ((object)obj6 == null || (object)obj6 != null)
				{
					jmh = (Font)obj6;
					UnityEngine.Object obj7 = Resources.Load("font/RobotoCondensed-Bold");
					if ((object)obj7 == null || (object)obj7 != null)
					{
						jmi = (Font)obj7;
						UnityEngine.Object obj8 = Resources.Load("font/Roboto-Italic");
						if ((object)obj8 == null || (object)obj8 != null)
						{
							jmj = (Font)obj8;
							UnityEngine.Object obj9 = Resources.Load("font/UTM ALTER GOTHIC");
							if ((object)obj9 == null || (object)obj9 != null)
							{
								jmk = (Font)obj9;
								return;
							}
						}
					}
				}
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	[Token(Token = "0x60005A6")]
	[Address(RVA = "0x7DEF60", Offset = "0x7DDF60", VA = "0x1807DEF60")]
	public static int bvr(string str)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005A7")]
	[Address(RVA = "0x7DF1B0", Offset = "0x7DE1B0", VA = "0x1807DF1B0")]
	public static List<string> bvs(string src, int lineWidth)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005A8")]
	[Address(RVA = "0x7DF470", Offset = "0x7DE470", VA = "0x1807DF470")]
	public static string[] bvt(string src, int lineWidth)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005A9")]
	[Address(RVA = "0x7DF5C0", Offset = "0x7DE5C0", VA = "0x1807DF5C0")]
	public static int bvu(string str, char c)
	{
		char[] array = str.ToCharArray();
		int num = 0;
		int length = array.Length;
		if (num < length)
		{
			num++;
		}
		return num;
	}

	[Token(Token = "0x60005AA")]
	[Address(RVA = "0x7DF640", Offset = "0x7DE640", VA = "0x1807DF640")]
	public static Color bvv(int rgb)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005AB")]
	[Address(RVA = "0x7DF6A0", Offset = "0x7DE6A0", VA = "0x1807DF6A0")]
	public static Color bvw(int rgb, float alpha)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005AC")]
	[Address(RVA = "0x7DE950", Offset = "0x7DD950", VA = "0x1807DE950")]
	static hj()
	{
		//IL_003a: Expected F4, but got Obj
		//IL_0060: Expected F4, but got Obj
		//IL_008e: Expected F4, but got Obj
		//IL_00bc: Expected F4, but got Obj
		float[][] array;
		float[] array5;
		while (true)
		{
			jma = new char[197]
			{
				' ', '0', '1', '2', '3', '4', '5', '6', '7', '8',
				'9', 'a', 'A', 'à', 'À', 'ả', 'Ả', 'ã', 'Ã', 'á',
				'Á', 'ạ', 'Ạ', 'ă', 'Ă', 'ằ', 'Ằ', 'ẳ', 'Ẳ', 'ẵ',
				'Ẵ', 'ắ', 'Ắ', 'ặ', 'Ặ', 'â', 'Â', 'ầ', 'Ầ', 'ẩ',
				'Ẩ', 'ẫ', 'Ẫ', 'ấ', 'Ấ', 'ậ', 'Ậ', 'b', 'B', 'c',
				'C', 'd', 'D', 'đ', 'Đ', 'e', 'E', 'è', 'È', 'ẻ',
				'Ẻ', 'ẽ', 'Ẽ', 'é', 'É', 'ẹ', 'Ẹ', 'ê', 'Ê', 'ề',
				'Ề', 'ể', 'Ể', 'ễ', 'Ễ', 'ế', 'Ế', 'ệ', 'Ệ', 'f',
				'F', 'g', 'G', 'h', 'H', 'i', 'I', 'ì', 'Ì', 'ỉ',
				'Ỉ', 'ĩ', 'Ĩ', 'í', 'Í', 'ị', 'Ị', 'j', 'J', 'k',
				'K', 'l', 'L', 'm', 'M', 'n', 'N', 'o', 'O', 'ò',
				'Ò', 'ỏ', 'Ỏ', 'õ', 'Õ', 'ó', 'Ó', 'ọ', 'Ọ', 'ô',
				'Ô', 'ồ', 'Ồ', 'ổ', 'Ổ', 'ỗ', 'Ỗ', 'ố', 'Ố', 'ộ',
				'Ộ', 'ơ', 'Ơ', 'ờ', 'Ờ', 'ở', 'Ở', 'ỡ', 'Ỡ', 'ớ',
				'Ớ', 'ợ', 'Ợ', 'p', 'P', 'q', 'Q', 'r', 'R', 's',
				'S', 't', 'T', 'u', 'U', 'ù', 'Ù', 'ủ', 'Ủ', 'ũ',
				'Ũ', 'ú', 'Ú', 'ụ', 'Ụ', 'ư', 'Ư', 'ừ', 'Ừ', 'ử',
				'Ử', 'ữ', 'Ữ', 'ứ', 'Ứ', 'ự', 'Ự', 'v', 'V', 'w',
				'W', 'x', 'X', 'y', 'Y', 'ỳ', 'Ỳ', 'ỷ', 'Ỷ', 'ỹ',
				'Ỹ', 'ý', 'Ý', 'ỵ', 'Ỵ', 'z', 'Z'
			};
			array = new float[4][];
			float[] array2 = new float[0];
			if (array2 != null && array2 == null)
			{
				continue;
			}
			((float[])(object)array)[0] = (float)array2;
			float[] array3 = new float[197]
			{
				2f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f, 5f,
				5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f,
				5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f,
				5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f,
				5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 5f, 5.5f, 4.5f,
				5.5f, 5f, 5.5f, 5f, 5.5f, 4.5f, 5f, 4.5f, 5f, 4.5f,
				5f, 4.5f, 5f, 4.5f, 5f, 4.5f, 5f, 4.5f, 5f, 4.5f,
				5f, 4.5f, 5f, 4.5f, 5f, 4.5f, 5f, 4.5f, 5f, 3f,
				4.5f, 5f, 6f, 5f, 6f, 2.5f, 2.5f, 2.5f, 2.5f, 2.5f,
				2.5f, 2.5f, 2.5f, 2.5f, 2.5f, 2.5f, 2.5f, 2f, 5f, 4.5f,
				5.5f, 2.5f, 4.5f, 7.5f, 7.5f, 5f, 6f, 5f, 6f, 5f,
				6f, 5f, 6f, 5f, 6f, 5f, 6f, 5f, 6f, 5f,
				6f, 5f, 6f, 5f, 6f, 5f, 6f, 5f, 6f, 5f,
				6f, 5f, 6f, 5f, 6f, 5f, 6f, 5f, 6f, 5f,
				6f, 5f, 6f, 5f, 5.5f, 5f, 6f, 3f, 5.5f, 4.5f,
				5f, 3f, 5.5f, 5f, 5.5f, 5f, 5.5f, 5f, 5.5f, 5f,
				5.5f, 5f, 5.5f, 5f, 5.5f, 5f, 6f, 5f, 6f, 5f,
				6f, 5f, 6f, 5f, 6f, 5f, 6f, 4.5f, 5.5f, 6.5f,
				7.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f,
				5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5f
			};
			if (array3 != null && array3 == null)
			{
				continue;
			}
			((float[])(object)array)[1] = (float)array3;
			float[] array4 = new float[197]
			{
				2.333333f, 5.333333f, 5.333333f, 5.333333f, 5.333333f, 5.333333f, 5.333333f, 5.333333f, 5.333333f, 5.333333f,
				5.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f,
				6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f,
				6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f,
				6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5f, 6.333333f, 5.333333f, 6f, 5f,
				6f, 5.333333f, 6f, 5.333333f, 6.333333f, 5f, 5.333333f, 5f, 5.333333f, 5f,
				5.333333f, 5f, 5.333333f, 5f, 5.333333f, 5f, 5.333333f, 5f, 5.333333f, 5f,
				5.333333f, 5f, 5.333333f, 5f, 5.333333f, 5f, 5.333333f, 5f, 5.333333f, 3.333333f,
				5f, 5.333333f, 6.333333f, 5.333333f, 6.666667f, 2.333333f, 2.666667f, 2.666667f, 2.666667f, 2.666667f,
				2.666667f, 2.666667f, 2.666667f, 2.666667f, 2.666667f, 2.333333f, 2.666667f, 2.333333f, 5.333333f, 5f,
				6f, 2.333333f, 5f, 8f, 8.333333f, 5.333333f, 6.666667f, 5.333333f, 6.333333f, 5.333333f,
				6.333333f, 5.333333f, 6.333333f, 5.333333f, 6.333333f, 5.333333f, 6.333333f, 5.333333f, 6.333333f, 5.333333f,
				6.333333f, 5.333333f, 6.333333f, 5.333333f, 6.333333f, 5.333333f, 6.333333f, 5.333333f, 6.333333f, 5.333333f,
				6.333333f, 5.333333f, 6.666667f, 5.333333f, 6.666667f, 5.333333f, 6.666667f, 5.333333f, 6.666667f, 5.333333f,
				6.666667f, 5.333333f, 6.666667f, 5.333333f, 6f, 5.333333f, 6.333333f, 3.333333f, 6f, 4.666667f,
				5.666667f, 3f, 5.666667f, 5.333333f, 6f, 5.333333f, 6f, 5.333333f, 6f, 5.333333f,
				6f, 5.333333f, 6f, 5.333333f, 6f, 5.666667f, 6.666667f, 5.666667f, 6.666667f, 5.666667f,
				6.666667f, 5.666667f, 6.666667f, 5.666667f, 6.666667f, 5.666667f, 6.666667f, 4.666667f, 6f, 7f,
				8f, 4.666667f, 6f, 4.666667f, 5.666667f, 4.666667f, 5.666667f, 4.666667f, 5.666667f, 4.666667f,
				5.666667f, 4.666667f, 5.666667f, 4.666667f, 5.666667f, 4.666667f, 5.666667f
			};
			if (array4 == null || array4 != null)
			{
				((float[])(object)array)[2] = (float)array4;
				array5 = new float[197]
				{
					2.25f, 5.25f, 5.25f, 5.25f, 5.25f, 5.25f, 5.25f, 5.25f, 5.25f, 5.25f,
					5.25f, 4.75f, 6f, 4.75f, 6f, 4.75f, 6f, 4.75f, 6f, 4.75f,
					6f, 4.75f, 6f, 4.75f, 6f, 4.75f, 6f, 4.75f, 6f, 4.75f,
					6f, 4.75f, 6f, 4.75f, 6f, 4.75f, 6f, 4.75f, 6f, 4.75f,
					6f, 4.75f, 6f, 4.75f, 6f, 4.75f, 6f, 5f, 5.75f, 4.75f,
					6f, 5f, 5.75f, 5.25f, 6f, 4.75f, 5f, 4.75f, 5f, 4.75f,
					5f, 4.75f, 5f, 4.75f, 5f, 4.75f, 5f, 4.75f, 5f, 4.75f,
					5f, 4.75f, 5f, 4.75f, 5f, 4.75f, 5f, 4.75f, 5f, 3.25f,
					5f, 5.25f, 6.25f, 5f, 6.25f, 2.5f, 2.75f, 2.5f, 2.75f, 2.5f,
					2.75f, 2.5f, 2.75f, 2.5f, 2.75f, 2.5f, 2.75f, 2.25f, 5f, 4.75f,
					5.75f, 2.5f, 5f, 7.75f, 8f, 5f, 6.25f, 5f, 6.25f, 5f,
					6.25f, 5f, 6.25f, 5f, 6.25f, 5f, 6.25f, 5f, 6.25f, 5f,
					6.25f, 5f, 6.25f, 5f, 6.25f, 5f, 6.25f, 5f, 6.25f, 5f,
					6.25f, 5.25f, 6.25f, 5.25f, 6.25f, 5.25f, 6.25f, 5.25f, 6.25f, 5.25f,
					6.25f, 5.25f, 6.25f, 5f, 5.75f, 5f, 6.25f, 3.25f, 5.75f, 4.75f,
					5.5f, 3f, 5.5f, 5f, 6f, 5f, 6f, 5f, 6f, 5f,
					6f, 5f, 6f, 5f, 6f, 5.5f, 6.5f, 5.5f, 6.5f, 5.5f,
					6.5f, 5.5f, 6.5f, 5.5f, 6.5f, 5.5f, 6.5f, 4.5f, 6f, 6.5f,
					7.75f, 4.5f, 5.75f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f,
					5.5f, 4.5f, 5.5f, 4.5f, 5.5f, 4.5f, 5.5f
				};
				if (array5 == null || array5 != null)
				{
					break;
				}
			}
		}
		((float[])(object)array)[3] = (float)array5;
		jml = array;
	}
}
