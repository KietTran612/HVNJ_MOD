using System;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200012D")]
public class ll : ng
{
	[Token(Token = "0x200012E")]
	private class lk : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001235")]
		private ll mec;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001236")]
		private sbyte med;

		[Token(Token = "0x6000936")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public lk(ll m, sbyte t)
		{
			mec = m;
			med = t;
		}

		[Token(Token = "0x6000937")]
		[Address(RVA = "0x279FF0", Offset = "0x278FF0", VA = "0x180279FF0", Slot = "4")]
		public void th()
		{
			ll ll2 = mec;
			sbyte type = med;
			ll2.ctp(type);
		}
	}

	[Token(Token = "0x4001230")]
	public static ll mee;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001231")]
	public u mef;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001232")]
	public u meg;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001233")]
	private iw meh;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001234")]
	private GameObject mei;

	[Token(Token = "0x600092E")]
	[Address(RVA = "0x244C30", Offset = "0x243C30", VA = "0x180244C30")]
	public static ll ctm()
	{
		ll ll2 = mee;
		if (ll2 == null)
		{
			mee = new ll();
		}
		return ll2;
	}

	[Token(Token = "0x600092F")]
	[Address(RVA = "0x244CA0", Offset = "0x243CA0", VA = "0x180244CA0", Slot = "4")]
	public override void ctn()
	{
		base.ctn();
		hw.jui = new ms();
		cto();
	}

	[Token(Token = "0x6000930")]
	[Address(RVA = "0x244DF0", Offset = "0x243DF0", VA = "0x180244DF0")]
	private void cto()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000931")]
	[Address(RVA = "0x2452C0", Offset = "0x2442C0", VA = "0x1802452C0")]
	private void ctp(sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000932")]
	[Address(RVA = "0x244890", Offset = "0x243890", VA = "0x180244890")]
	public ll()
	{
		//IL_0040: Expected I4, but got I8
		//IL_004f: Expected I4, but got I8
		//IL_0069: Expected I4, but got I8
		//IL_00a3: Expected I4, but got I8
		//IL_00b2: Expected I4, but got I8
		//IL_00cc: Expected I4, but got I8
		((System.TypeNames.ATypeName)(object)this)._002Ector();
		(mef = new u()).fqd = "Tai khoan";
		mef.fpt = "Tai khoan";
		mef.fow = 140;
		mef.fox = 25;
		mef.fot = true;
		mef.fpz = 3;
		(meg = new u()).fqd = "Mat khau";
		meg.fpt = "Mat khau";
		meg.fow = 140;
		meg.fox = 25;
		meg.fot = false;
		meg.fpz = 2;
		u u2 = mef;
		string nyp = nd.nyp;
		u2.yd(nyp);
		u u3 = meg;
		string nyq = nd.nyq;
		u3.yd(nyq);
		int indexAc = default;
		iw iw2 = new iw(hd.inl, this, 1000, indexAc);
		indexAc = 0;
		meh = iw2;
	}

	[Token(Token = "0x6000933")]
	[Address(RVA = "0x2452F0", Offset = "0x2442F0", VA = "0x1802452F0", Slot = "6")]
	public override void ctq()
	{
		//IL_001f: Expected Obj, but got I8
		mef.xy();
		meg.xy();
		ode = (iw)0;
	}

	[Token(Token = "0x6000934")]
	[Address(RVA = "0x245330", Offset = "0x244330", VA = "0x180245330", Slot = "8")]
	public override void ctr(short idAction, int indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000935")]
	[Address(RVA = "0x244BB0", Offset = "0x243BB0", VA = "0x180244BB0")]
	public void close()
	{
		UnityEngine.Object.Destroy(mei);
	}
}
