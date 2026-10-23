using System;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200016A")]
public class np : fi, k
{
	[Token(Token = "0x200016B")]
	private class nn : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40017AF")]
		private int ofp;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40017B0")]
		private np ofq;

		[Token(Token = "0x6000C4F")]
		[Address(RVA = "0x2782F0", Offset = "0x2772F0", VA = "0x1802782F0")]
		public nn(np me, int ind)
		{
			ofq = me;
			ofp = ind;
		}

		[Token(Token = "0x6000C50")]
		[Address(RVA = "0x27ABC0", Offset = "0x279BC0", VA = "0x18027ABC0", Slot = "4")]
		public void th()
		{
			np np2 = ofq;
			int index = ofp;
			np2.dok(index);
		}
	}

	[Token(Token = "0x40017A7")]
	private static np ofr;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40017A8")]
	private GameObject ofs;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40017A9")]
	private int oft = 250;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x40017AA")]
	private int ofu = 160;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40017AB")]
	private int ofv;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x40017AC")]
	private int ofw;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40017AD")]
	private string ofx;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40017AE")]
	private ScrollRect ofy;

	[Token(Token = "0x6000C47")]
	[Address(RVA = "0x2D6DF0", Offset = "0x2D5DF0", VA = "0x1802D6DF0")]
	public static np doj()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		np np2 = ofr;
		if (np2 == null)
		{
			np np3 = new np();
			np3.oft = 250;
			np3.ofu = 160;
			ofr = np3;
		}
		return np2;
	}

	[Token(Token = "0x6000C48")]
	[Address(RVA = "0x2D6EC0", Offset = "0x2D5EC0", VA = "0x1802D6EC0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C49")]
	[Address(RVA = "0x2D7310", Offset = "0x2D6310", VA = "0x1802D7310")]
	public void refreshList(bc m)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C4A")]
	[Address(RVA = "0x2D6EB0", Offset = "0x2D5EB0", VA = "0x1802D6EB0")]
	private void dok(int index)
	{
		Net.vs(ofx);
	}

	[Token(Token = "0x6000C4B")]
	[Address(RVA = "0x2D6CE0", Offset = "0x2D5CE0", VA = "0x1802D6CE0", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C4C")]
	[Address(RVA = "0x2D85D0", Offset = "0x2D75D0", VA = "0x1802D85D0", Slot = "11")]
	public void ti(int idAction, lh p)
	{
		if (idAction == 1)
		{
			GameObject gameObject = ((IClippable)this).gameObject;
		}
	}

	[Token(Token = "0x6000C4D")]
	[Address(RVA = "0x2D6D60", Offset = "0x2D5D60", VA = "0x1802D6D60", Slot = "9")]
	public override void close()
	{
		//IL_001e: Expected Obj, but got I8
		GC.KeepAlive("close");
		UnityEngine.Object.Destroy(hlf);
		hlf = (GameObject)0;
		base.close();
	}

	[Token(Token = "0x6000C4E")]
	[Address(RVA = "0x2D6C80", Offset = "0x2D5C80", VA = "0x1802D6C80")]
	public np()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
