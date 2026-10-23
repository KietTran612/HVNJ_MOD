using System;
using System.IO;
using System.Threading;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000017")]
public class t
{
	[Token(Token = "0x4000094")]
	public static int foo;

	[Token(Token = "0x4000095")]
	public static sbyte[] fop;

	[Token(Token = "0x4000096")]
	public static string foq;

	[Token(Token = "0x4000097")]
	private const int @for = 5;

	[Token(Token = "0x4000098")]
	private const int fos = 500;

	[Token(Token = "0x60000C3")]
	[Address(RVA = "0x281900", Offset = "0x280900", VA = "0x180281900")]
	public static void ww(string name, sbyte[] data)
	{
		wx(name, data);
	}

	[Token(Token = "0x60000C4")]
	[Address(RVA = "0x281910", Offset = "0x280910", VA = "0x180281910")]
	public static void wx(string filename, sbyte[] data)
	{
		int num = 0;
		string name = Thread.CurrentThread.Name;
		string mainThreadName = Main.mainThreadName;
		if (!string.Equals(name, mainThreadName))
		{
			xc(filename, data);
		}
		else
		{
			xi(filename, data);
		}
	}

	[Token(Token = "0x60000C5")]
	[Address(RVA = "0x2819D0", Offset = "0x2809D0", VA = "0x1802819D0")]
	public static sbyte[] wy(string filename)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000C6")]
	[Address(RVA = "0x281BD0", Offset = "0x280BD0", VA = "0x180281BD0")]
	public static string wz(string fileName)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000C7")]
	[Address(RVA = "0x281C90", Offset = "0x280C90", VA = "0x180281C90")]
	public static byte[] xa(sbyte[] var)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000C8")]
	[Address(RVA = "0x281D40", Offset = "0x280D40", VA = "0x180281D40")]
	public static void xb(string filename, string data)
	{
		f f2 = new f();
		f2.tf(data);
		sbyte[] data2 = f2.td();
		wx(filename, data2);
		f2.close();
	}

	[Token(Token = "0x60000C9")]
	[Address(RVA = "0x281DE0", Offset = "0x280DE0", VA = "0x180281DE0")]
	private static void xc(string filename, sbyte[] data)
	{
		foq = filename;
		fop = data;
		int num = 0;
		if (num < 500)
		{
			Thread.Sleep(5);
			num++;
		}
		if (num == 500)
		{
			string text = "TOO LONG TO SAVE RMS " + filename;
		}
		int num2 = 0;
		string text2 = foq;
		string text3 = "Cannot save RMS " + filename + " because current is saving " + text2;
	}

	[Token(Token = "0x60000CA")]
	[Address(RVA = "0x281EF0", Offset = "0x280EF0", VA = "0x180281EF0")]
	private static sbyte[] xd(string filename)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000CB")]
	[Address(RVA = "0x282050", Offset = "0x281050", VA = "0x180282050")]
	public static void xe()
	{
		switch (foo)
		{
		case 3:
			fop = xj(foq);
			break;
		case 2:
			break;
		default:
			return;
		}
		sbyte[] data = fop;
		xi(foq, data);
	}

	[Token(Token = "0x60000CC")]
	[Address(RVA = "0x282100", Offset = "0x281100", VA = "0x180282100")]
	public static int xf(string file)
	{
		return wy(file)?.Length ?? (-1);
	}

	[Token(Token = "0x60000CD")]
	[Address(RVA = "0x2821A0", Offset = "0x2811A0", VA = "0x1802821A0")]
	public static void xg(string file, int x)
	{
		sbyte[] array = new sbyte[4];
		int length = array.Length;
		array[0] = (sbyte)x;
		array[0] = (sbyte)x;
		array[0] = (sbyte)x;
		array[0] = (sbyte)x;
		wx(file, array);
	}

	[Token(Token = "0x60000CE")]
	[Address(RVA = "0x282270", Offset = "0x281270", VA = "0x180282270")]
	public static string xh()
	{
		int num = 0;
		return Application.persistentDataPath;
	}

	[Token(Token = "0x60000CF")]
	[Address(RVA = "0x282280", Offset = "0x281280", VA = "0x180282280")]
	private static void xi(string filename, sbyte[] data)
	{
		int num = 0;
		FileStream fileStream = new FileStream(Application.persistentDataPath + "/" + filename, FileMode.Create);
		byte[] array = ht.cbg(data);
		int length = data.Length;
		int offset = 0;
		fileStream.Write(array, offset, length);
		fileStream.Flush();
		fileStream.Close();
	}

	[Token(Token = "0x60000D0")]
	[Address(RVA = "0x2823B0", Offset = "0x2813B0", VA = "0x1802823B0")]
	private static sbyte[] xj(string filename)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000D1")]
	[Address(RVA = "0x2817F0", Offset = "0x2807F0", VA = "0x1802817F0")]
	public static void Delete()
	{
		//IL_003e: Expected Obj, but got I4
		int num = 0;
		int num2 = 0;
		string[] files = Directory.GetFiles(Application.persistentDataPath);
		if (num < files.Length)
		{
			string text = files[num];
			if (!text.Contains("accloging4m"))
			{
				File.Delete(text);
			}
			num++;
		}
		Debug.LogException((Exception)num);
	}

	[Token(Token = "0x60000D2")]
	[Address(RVA = "0x282500", Offset = "0x281500", VA = "0x180282500")]
	public static void xk()
	{
		//IL_0076: Expected Obj, but got I4
		int num = 0;
		int num2 = 0;
		string[] files = Directory.GetFiles(Application.persistentDataPath);
		if (num < files.Length)
		{
			string text = files[num];
			if (!text.Contains("version1") && !text.Contains("loadSetting") && !text.Contains("acc") && text != "pass" && !text.Contains("saveIPSv"))
			{
				File.Delete(text);
			}
			num++;
		}
		Debug.LogException((Exception)num);
	}

	[Token(Token = "0x60000D3")]
	[Address(RVA = "0x2826A0", Offset = "0x2816A0", VA = "0x1802826A0")]
	public static void xl(string key)
	{
		PlayerPrefs.DeleteKey(key);
	}

	[Token(Token = "0x60000D4")]
	[Address(RVA = "0x2826B0", Offset = "0x2816B0", VA = "0x1802826B0")]
	public static string xm(byte[] ba)
	{
		return BitConverter.ToString(ba).Replace("-", "");
	}

	[Token(Token = "0x60000D5")]
	[Address(RVA = "0x282740", Offset = "0x281740", VA = "0x180282740")]
	public static byte[] xn(string hex)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000D6")]
	[Address(RVA = "0x282850", Offset = "0x281850", VA = "0x180282850")]
	public static void xo(string name)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000D7")]
	[Address(RVA = "0x282890", Offset = "0x281890", VA = "0x180282890")]
	public static void xp(string str)
	{
		xo("str");
	}

	[Token(Token = "0x60000D8")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public t()
	{
	}
}
