using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x20000C8")]
public class hm
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000B53")]
	public Text jog;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000B54")]
	public float joh;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000B55")]
	public float joi;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000B56")]
	public float joj;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000B57")]
	public float jok;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000B58")]
	public float jol;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000B59")]
	public float jom;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000B5A")]
	private string jon = "";

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000B5B")]
	public RectTransform joo;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000B5C")]
	public hm[] jop;

	[Token(Token = "0x60005E9")]
	[Address(RVA = "0x7E5000", Offset = "0x7E4000", VA = "0x1807E5000")]
	public hm()
	{
	}

	[Token(Token = "0x60005EA")]
	[Address(RVA = "0x7E5B50", Offset = "0x7E4B50", VA = "0x1807E5B50")]
	public void close()
	{
		//IL_0053: Expected Obj, but got I8
		//IL_004a: Expected Obj, but got I8
		Object.Destroy(joo.gameObject);
		hm[] array = jop;
		if (array != null)
		{
			int num = 0;
			int num2 = 0;
			if (num2 < array.Length)
			{
				array[num].close();
				hm[] array2 = jop;
				num++;
				num2 = num;
			}
			jop = (hm[])0;
		}
		jog = (Text)0;
	}

	[Token(Token = "0x60005EB")]
	[Address(RVA = "0x7E5040", Offset = "0x7E4040", VA = "0x1807E5040")]
	public void bxk(float w, float h)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005EC")]
	[Address(RVA = "0x7E5120", Offset = "0x7E4120", VA = "0x1807E5120")]
	public void bxl(float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005ED")]
	[Address(RVA = "0x7E5420", Offset = "0x7E4420", VA = "0x1807E5420")]
	public string bxm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005EE")]
	[Address(RVA = "0x7E54C0", Offset = "0x7E44C0", VA = "0x1807E54C0")]
	public void bxn(string tex)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005EF")]
	[Address(RVA = "0x7E56E0", Offset = "0x7E46E0", VA = "0x1807E56E0")]
	public void bxo(string tex)
	{
		//IL_0010: Expected Obj, but got I4
		Text text = jog;
		int num = 0;
		if (!(text == (Object)num) && !string.Equals(jon, tex))
		{
			Text text2 = jog;
			jon = tex;
			text2.text = tex;
		}
	}

	[Token(Token = "0x60005F0")]
	[Address(RVA = "0x7E5790", Offset = "0x7E4790", VA = "0x1807E5790")]
	public void bxp(string tex, float w0, float h0)
	{
		//IL_0017: Expected Obj, but got I4
		Text text = jog;
		jon = tex;
		int num = 0;
		if (!(text == (Object)num))
		{
			joj = w0;
			jok = h0;
			float num2 = jok;
			jol = w0;
			Text text2 = jog;
			jom = num2;
			text2.text = tex;
		}
	}

	[Token(Token = "0x60005F1")]
	[Address(RVA = "0x7E58C0", Offset = "0x7E48C0", VA = "0x1807E58C0")]
	public void bxq(Color color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005F2")]
	[Address(RVA = "0x7E5900", Offset = "0x7E4900", VA = "0x1807E5900")]
	public void bxr(sbyte typeFont)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005F3")]
	[Address(RVA = "0x7E5A80", Offset = "0x7E4A80", VA = "0x1807E5A80")]
	public void bxs(bool isA)
	{
		joo.gameObject.SetActive(isA);
		hm[] array = jop;
		if (array != null)
		{
			int num = 0;
			if (num < array.Length)
			{
				array[num].joo.gameObject.SetActive(isA);
				hm[] array2 = jop;
				num++;
			}
		}
	}
}
