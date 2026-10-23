using Cpp2IlInjected;

[Token(Token = "0x20000EB")]
public class iy : jl
{
	[Token(Token = "0x6000727")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public iy()
	{
	}

	[Token(Token = "0x6000728")]
	[Address(RVA = "0x4E6180", Offset = "0x4E5180", VA = "0x1804E6180")]
	public unsafe iy(int id, string name1, string name2)
	{
		//IL_000b: Expected Obj, but got I4
		int num = 0;
		FieldGetter((string)num, name1, ref *(object*)name2);
		kzt = id;
		kzu = name1;
		kzv = name2;
	}
}
