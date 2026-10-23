using Cpp2IlInjected;

[Token(Token = "0x2000120")]
public class ky
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40011B6")]
	public sbyte lzh;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40011B7")]
	public string lzi;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40011B8")]
	public string lzj;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40011B9")]
	public short lzk;

	[FieldOffset(Offset = "0x2A")]
	[Token(Token = "0x40011BA")]
	public short lzl;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x40011BB")]
	public sbyte lzm;

	[FieldOffset(Offset = "0x2D")]
	[Token(Token = "0x40011BC")]
	public sbyte lzn;

	[Token(Token = "0x6000823")]
	[Address(RVA = "0x1F8700", Offset = "0x1F7700", VA = "0x1801F8700")]
	public unsafe ky(sbyte id, string name, string info, short npcID, short mapId, sbyte idTask, sbyte level)
	{
		//IL_000b: Expected Obj, but got I4
		int num = 0;
		FieldGetter((string)num, name, ref *(object*)info);
		lzk = 0;
		lzl = 0;
		lzm = 0;
		lzh = id;
		lzj = info;
		lzn = 0;
		lzi = name;
	}
}
