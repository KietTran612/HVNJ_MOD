using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200022E")]
public static class pt
{
	[Token(Token = "0x4001C88")]
	private static readonly uint phg;

	[Token(Token = "0x4001C89")]
	private static readonly uint phh;

	[Token(Token = "0x4001C8A")]
	private static readonly uint phi;

	[Token(Token = "0x4001C8B")]
	private static readonly uint phj;

	[Token(Token = "0x4001C8C")]
	private static readonly uint phk;

	[Token(Token = "0x4001C8D")]
	private static readonly long[] phl;

	[Token(Token = "0x6001219")]
	[Address(RVA = "0x27E160", Offset = "0x27D160", VA = "0x18027E160")]
	public unsafe static byte[] ezg(byte[] inputBytes)
	{
		int length = inputBytes.Length;
		length += length;
		byte[] array = new byte[length];
		int num = ezi(inputBytes, ref *(byte[]*)array);
		if (num == 0)
		{
			length += length;
			byte[] array2 = new byte[length];
			int num2 = ezi(inputBytes, ref *(byte[]*)array2);
			num = num2;
			while (num2 == 0)
			{
			}
		}
		byte[] array3 = new byte[num];
		int dstOffset = 0;
		int srcOffset = 0;
		Buffer.BlockCopy(array, srcOffset, array3, dstOffset, num);
		return array3;
	}

	[Token(Token = "0x600121A")]
	[Address(RVA = "0x27E290", Offset = "0x27D290", VA = "0x18027E290")]
	public unsafe static byte[] ezh(byte[] inputBytes)
	{
		int length = inputBytes.Length;
		length += length;
		byte[] array = new byte[length];
		int num = ezj(inputBytes, ref *(byte[]*)array);
		if (num == 0)
		{
			length += length;
			byte[] array2 = new byte[length];
			int num2 = ezj(inputBytes, ref *(byte[]*)array2);
			num = num2;
			while (num2 == 0)
			{
			}
		}
		byte[] array3 = new byte[num];
		int dstOffset = 0;
		int srcOffset = 0;
		Buffer.BlockCopy(array, srcOffset, array3, dstOffset, num);
		return array3;
	}

	[Token(Token = "0x600121B")]
	[Address(RVA = "0x27E3C0", Offset = "0x27D3C0", VA = "0x18027E3C0")]
	public static int ezi(byte[] input, ref byte[] output)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600121C")]
	[Address(RVA = "0x27ED40", Offset = "0x27DD40", VA = "0x18027ED40")]
	public static int ezj(byte[] input, ref byte[] output)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600121D")]
	[Address(RVA = "0x27E090", Offset = "0x27D090", VA = "0x18027E090")]
	static pt()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
