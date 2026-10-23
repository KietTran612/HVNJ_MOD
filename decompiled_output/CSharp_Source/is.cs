using System;
using Cpp2IlInjected;

[Token(Token = "0x20000E5")]
public class @is
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000D28")]
	public int kgi;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000D29")]
	public string kgj;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000D2A")]
	public kw[] kgk;

	[Token(Token = "0x6000717")]
	[Address(RVA = "0x4E5AD0", Offset = "0x4E4AD0", VA = "0x1804E5AD0")]
	public kw cgc(int ID)
	{
		kw[] array = kgk;
		if (ID < array.Length)
		{
			kw kw2 = array[ID];
			if ((long)kw2.lyv == 0)
			{
				string[] lyv = hj.bvt(kw2.lyw, 200);
				kw2.lyv = lyv;
			}
			return kgk[ID];
		}
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000718")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public @is()
	{
	}
}
