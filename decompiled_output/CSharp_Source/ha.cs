using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000B7")]
public class ha : fi
{
	[Token(Token = "0x20000B8")]
	private class gz : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400081C")]
		private ha ijy;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400081D")]
		private sbyte ijz;

		[Token(Token = "0x6000564")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gz(ha me, sbyte index)
		{
			ijy = me;
			ijz = index;
		}

		[Token(Token = "0x6000565")]
		[Address(RVA = "0x2792C0", Offset = "0x2782C0", VA = "0x1802792C0", Slot = "4")]
		public void th()
		{
			ha ha2 = ijy;
			sbyte index = ijz;
			ha2.buo(index);
		}
	}

	[Token(Token = "0x4000817")]
	private static ha ika;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000818")]
	private GameObject ikb;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000819")]
	private int ikc = 250;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400081A")]
	private int ikd = 190;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400081B")]
	public List<kr> ike = (List<kr>)(object)new List<T>();

	[Token(Token = "0x600055E")]
	[Address(RVA = "0x28F7C0", Offset = "0x28E7C0", VA = "0x18028F7C0")]
	public static ha bun()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		ha ha2 = ika;
		if (ha2 == null)
		{
			ha ha3 = new ha();
			ha3.ikc = 250;
			ha3.ikd = 190;
			List<kr> list = (List<kr>)(object)new List<T>();
			ha3.ike = list;
			ika = ha3;
		}
		return ha2;
	}

	[Token(Token = "0x600055F")]
	[Address(RVA = "0x28FA30", Offset = "0x28EA30", VA = "0x18028FA30")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000560")]
	[Address(RVA = "0x28F8C0", Offset = "0x28E8C0", VA = "0x18028F8C0")]
	public void buo(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000561")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000562")]
	[Address(RVA = "0x28F970", Offset = "0x28E970", VA = "0x18028F970", Slot = "9")]
	public override void close()
	{
		//IL_0020: Expected Obj, but got I8
		int num = 0;
		mo.ddt().deq();
		Object.Destroy(hlf);
		hlf = (GameObject)0;
		base.close();
	}

	[Token(Token = "0x6000563")]
	[Address(RVA = "0x28F6F0", Offset = "0x28E6F0", VA = "0x18028F6F0")]
	public ha()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
