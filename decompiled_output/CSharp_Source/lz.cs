using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200013C")]
public class lz
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001433")]
	public string mya;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001434")]
	public int myb;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001435")]
	public int myc = -1;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001436")]
	public int myd;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001437")]
	public int mye = 5;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001438")]
	public int myf;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4001439")]
	public int myg;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400143A")]
	public int myh;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x400143B")]
	public int myi;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400143C")]
	public int myj = 2;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400143D")]
	public RectTransform myk;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400143E")]
	public GameObject myl;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400143F")]
	public Image mym;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001440")]
	public hm myn;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001441")]
	public bool myo;

	[Token(Token = "0x6000A3E")]
	[Address(RVA = "0x3D29F0", Offset = "0x3D19F0", VA = "0x1803D29F0")]
	public lz(string s)
	{
		//IL_0010: Expected I4, but got I8
		//IL_0019: Expected I4, but got I8
		//IL_0022: Expected I4, but got I8
		//IL_0039: Expected I4, but got I8
		mya = s;
		myb = 20;
	}

	[Token(Token = "0x6000A3F")]
	[Address(RVA = "0x3D29A0", Offset = "0x3D19A0", VA = "0x1803D29A0")]
	public lz(string s, int speed)
	{
		//IL_0010: Expected I4, but got I8
		//IL_0019: Expected I4, but got I8
		//IL_0022: Expected I4, but got I8
		mya = s;
		myb = speed;
	}

	[Token(Token = "0x6000A40")]
	[Address(RVA = "0x3D2A40", Offset = "0x3D1A40", VA = "0x1803D2A40")]
	public void close()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0027: Expected Obj, but got I4
		//IL_002e: Expected Obj, but got I4
		//IL_0035: Expected Obj, but got I4
		GameObject gameObject = myl;
		int num = 0;
		if (gameObject != (Object)num)
		{
			Object.Destroy(myl);
		}
		int num2 = 0;
		myk = (RectTransform)num2;
		mym = (Image)num2;
		myn = (hm)num2;
	}
}
