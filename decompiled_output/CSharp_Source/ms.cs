using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200014B")]
public class ms : fa
{
	[Token(Token = "0x200014C")]
	private class mq : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001665")]
		private ms nth;

		[Token(Token = "0x6000B71")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public mq(ms me)
		{
			nth = me;
		}

		[Token(Token = "0x6000B72")]
		[Address(RVA = "0x2787A0", Offset = "0x2777A0", VA = "0x1802787A0", Slot = "4")]
		public void th()
		{
			nth.dlb();
		}
	}

	[Token(Token = "0x200014D")]
	private class mr : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001666")]
		private ms nti;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001667")]
		private sbyte ntj;

		[Token(Token = "0x6000B73")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public mr(ms me, sbyte ind)
		{
			nti = me;
			ntj = ind;
		}

		[Token(Token = "0x6000B74")]
		[Address(RVA = "0x27A610", Offset = "0x279610", VA = "0x18027A610", Slot = "4")]
		public void th()
		{
			ms ms2 = nti;
			sbyte index = ntj;
			ms2.dlc(index);
		}
	}

	[Token(Token = "0x400165A")]
	public static ms ntk;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400165B")]
	public List<iw> ntl;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400165C")]
	public int ntm;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x400165D")]
	public int ntn;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400165E")]
	public int nto;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400165F")]
	private GameObject ntp;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001660")]
	private int ntq;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001661")]
	private int ntr;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001662")]
	private RectTransform nts;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001663")]
	private int ntt;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001664")]
	public bool[] ntu;

	[Token(Token = "0x6000B68")]
	[Address(RVA = "0x62A7A0", Offset = "0x6297A0", VA = "0x18062A7A0")]
	public static ms dkz()
	{
		ms ms2 = ntk;
		if (ms2 == null)
		{
			ntk = new ms();
		}
		return ms2;
	}

	[Token(Token = "0x6000B69")]
	[Address(RVA = "0x62A810", Offset = "0x629810", VA = "0x18062A810")]
	public void dla(List<iw> menuItems, int pos, bool isNpc, bool isTask, bool isTaskPhu)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000B6A")]
	[Address(RVA = "0x62D400", Offset = "0x62C400", VA = "0x18062D400")]
	private void initUI(bool isNpc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000B6B")]
	[Address(RVA = "0x612380", Offset = "0x611380", VA = "0x180612380")]
	private void dlb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000B6C")]
	[Address(RVA = "0x62D250", Offset = "0x62C250", VA = "0x18062D250")]
	private void dlc(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000B6D")]
	[Address(RVA = "0x62A1C0", Offset = "0x6291C0", VA = "0x18062A1C0", Slot = "6")]
	public override void blk()
	{
		//IL_0017: Expected Obj, but got I4
		GameObject gameObject = ntp;
		hfw = false;
		int num = 0;
		if (gameObject != (Object)num)
		{
			Object.Destroy(ntp);
		}
		base.blk();
	}

	[Token(Token = "0x6000B6E")]
	[Address(RVA = "0x62A260", Offset = "0x629260", VA = "0x18062A260", Slot = "5")]
	public override void bll()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000B6F")]
	[Address(RVA = "0x62D380", Offset = "0x62C380", VA = "0x18062D380")]
	public void dld()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000B70")]
	[Address(RVA = "0x1F5970", Offset = "0x1F4970", VA = "0x1801F5970")]
	public ms()
	{
		((VertexHelper)(object)this)._002Ector();
	}
}
