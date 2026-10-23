using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000122")]
public class la
{
	[Token(Token = "0x40011C5")]
	public const sbyte lzw = 0;

	[Token(Token = "0x40011C6")]
	public const sbyte lzx = 1;

	[Token(Token = "0x40011C7")]
	public const sbyte lzy = 2;

	[Token(Token = "0x40011C8")]
	public const sbyte lzz = 3;

	[Token(Token = "0x40011C9")]
	public const sbyte maa = 4;

	[Token(Token = "0x40011CA")]
	public const sbyte mab = 5;

	[Token(Token = "0x40011CB")]
	public const sbyte mac = 6;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40011CC")]
	public int mad;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x40011CD")]
	public int mae;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40011CE")]
	public int maf;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40011CF")]
	public string mag;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40011D0")]
	public string mah;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40011D1")]
	public string mai;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40011D2")]
	public int maj;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x40011D3")]
	public int mak;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40011D4")]
	public RectTransform mal;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40011D5")]
	public hm mam;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40011D6")]
	public hm man;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40011D7")]
	public hm mao;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40011D8")]
	public Image maq;

	[Token(Token = "0x6000825")]
	[Address(RVA = "0x1FF9C0", Offset = "0x1FE9C0", VA = "0x1801FF9C0")]
	public la(sbyte taskId, int count, int maxCount, string name, string description, int killId, int mapId, string nameMonster)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000826")]
	[Address(RVA = "0x1FFA30", Offset = "0x1FEA30", VA = "0x1801FFA30")]
	public void clear()
	{
		//IL_0019: Expected Obj, but got I4
		//IL_0020: Expected Obj, but got I4
		//IL_0027: Expected Obj, but got I4
		//IL_002e: Expected Obj, but got I4
		//IL_0035: Expected Obj, but got I4
		Object.Destroy(mal.gameObject);
		int num = 0;
		mal = (RectTransform)num;
		mam = (hm)num;
		man = (hm)num;
		mao = (hm)num;
		maq = (Image)num;
	}
}
