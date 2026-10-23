using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000102")]
public class jv
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000FE1")]
	public int lhf;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4000FE2")]
	public int lhg = 20;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000FE3")]
	public int lhh = 30;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000FE4")]
	public Sprite[] lhi;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000FE5")]
	public List<jj> lhj = (List<jj>)(object)new List<T>();

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000FE6")]
	public int[] lhk;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000FE7")]
	public int[] lhl;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000FE8")]
	public bool lhm;

	[FieldOffset(Offset = "0x41")]
	[Token(Token = "0x4000FE9")]
	public sbyte lhn;

	[Token(Token = "0x600079A")]
	[Address(RVA = "0x4ED210", Offset = "0x4EC210", VA = "0x1804ED210")]
	public jv()
	{
		//IL_000a: Expected I4, but got I8
		//IL_0014: Expected I4, but got I8
	}

	[Token(Token = "0x600079B")]
	[Address(RVA = "0x4ED290", Offset = "0x4EC290", VA = "0x1804ED290")]
	public void civ()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
