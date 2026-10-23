using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000F0")]
public class jd
{
	[Token(Token = "0x4000EDE")]
	public const sbyte kxe = 0;

	[Token(Token = "0x4000EDF")]
	public const sbyte kxf = 1;

	[Token(Token = "0x4000EE0")]
	public const sbyte kxg = 54;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000EE1")]
	public int kxh;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000EE2")]
	public long kxi;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000EE3")]
	public int kxj;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000EE4")]
	public int kxk;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000EE5")]
	public jh kxl;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000EE6")]
	public GameObject kxm;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000EE7")]
	public RectTransform kxn;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000EE8")]
	public hm kxo;

	[Token(Token = "0x6000740")]
	[Address(RVA = "0x4E8020", Offset = "0x4E7020", VA = "0x1804E8020")]
	public jd(sbyte templateId, long timeStart, int timeLenght, int param)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000741")]
	[Address(RVA = "0x4E8100", Offset = "0x4E7100", VA = "0x1804E8100")]
	public void close()
	{
		//IL_0014: Expected Obj, but got I4
		//IL_001b: Expected Obj, but got I4
		Object.Destroy(kxm);
		int num = 0;
		kxm = (GameObject)num;
		kxo = (hm)num;
	}
}
