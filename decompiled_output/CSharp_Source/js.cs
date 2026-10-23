using Cpp2IlInjected;

[Token(Token = "0x20000FF")]
public class js
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000FBD")]
	public short lfv;

	[FieldOffset(Offset = "0x12")]
	[Token(Token = "0x4000FBE")]
	public sbyte lfw;

	[FieldOffset(Offset = "0x13")]
	[Token(Token = "0x4000FBF")]
	public sbyte lfx;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000FC0")]
	public string lfy;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000FC1")]
	public string lfz;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000FC2")]
	public short lga;

	[FieldOffset(Offset = "0x2A")]
	[Token(Token = "0x4000FC3")]
	public short lgb;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000FC4")]
	public short lgc;

	[FieldOffset(Offset = "0x2E")]
	[Token(Token = "0x4000FC5")]
	public short lgd;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000FC6")]
	public bool lge;

	[FieldOffset(Offset = "0x31")]
	[Token(Token = "0x4000FC7")]
	public bool lgf;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000FC8")]
	public int lgg;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000FC9")]
	public int lgh;

	[Token(Token = "0x600078D")]
	[Address(RVA = "0x4EBD80", Offset = "0x4EAD80", VA = "0x1804EBD80")]
	public js(short templateID, sbyte type, sbyte gender, string name, string description, short level, short iconID, short part, bool isUpToUp)
	{
		//IL_000d: Expected Obj, but got I4
		//IL_0014: Expected Obj, but got I4
		lfy = (string)0;
		lfz = (string)0;
		lga = 0;
		lgc = 0;
		lgd = 0;
		lfv = templateID;
		lfx = gender;
		lge = false;
		lfw = type;
	}
}
