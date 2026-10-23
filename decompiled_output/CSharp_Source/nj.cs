using Cpp2IlInjected;

[Token(Token = "0x2000166")]
public class nj
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001789")]
	public string oek;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400178A")]
	public string oel;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400178B")]
	public string oem;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400178C")]
	public float oen;

	[Token(Token = "0x6000C2D")]
	[Address(RVA = "0x2D4930", Offset = "0x2D3930", VA = "0x1802D4930")]
	public nj(string type, string name, float timeStart, string type_method)
	{
		//IL_001b: Expected Obj, but got I4
		oen = timeStart;
		oel = type;
		oem = (string)0;
		oek = name;
	}
}
