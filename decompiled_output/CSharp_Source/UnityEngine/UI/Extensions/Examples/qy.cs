using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000286")]
public class qy
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001DB3")]
	private int pnh = -1;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DB4")]
	public Action<Example04ScrollViewCell> pni;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DB5")]
	public Action<int> pnj;

	[Token(Token = "0x17000133")]
	public int pyu
	{
		[Token(Token = "0x60013DF")]
		[Address(RVA = "0x18F000", Offset = "0x18E000", VA = "0x18018F000")]
		get
		{
			return pnh;
		}
		[Token(Token = "0x60013E0")]
		[Address(RVA = "0x281790", Offset = "0x280790", VA = "0x180281790")]
		set
		{
			//IL_0022: Expected VT, but got I4
			if (value != pnh)
			{
				Action<int> action = pnj;
				pnh = value;
				((Action<T>)(object)action)?.Invoke((T)value);
			}
		}
	}

	[Token(Token = "0x60013E1")]
	[Address(RVA = "0x281780", Offset = "0x280780", VA = "0x180281780")]
	public qy()
	{
		//IL_0010: Expected I4, but got I8
	}
}
