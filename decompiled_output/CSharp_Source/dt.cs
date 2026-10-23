using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200005E")]
public class dt : fi
{
	[Token(Token = "0x200005F")]
	private class dq : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000393")]
		private dt gqp;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000394")]
		private int gqq;

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0x277DC0", Offset = "0x276DC0", VA = "0x180277DC0")]
		public dq(dt me, int index)
		{
			gqp = me;
			gqq = index;
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0x2784A0", Offset = "0x2774A0", VA = "0x1802784A0", Slot = "4")]
		public void th()
		{
			dt dt2 = gqp;
			int index = gqq;
			dt2.bhu(index);
		}
	}

	[Token(Token = "0x2000060")]
	private class dr : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000395")]
		private dt gqr;

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public dr(dt me)
		{
			gqr = me;
		}

		[Token(Token = "0x60002D6")]
		[Address(RVA = "0x2784D0", Offset = "0x2774D0", VA = "0x1802784D0", Slot = "4")]
		public void th()
		{
			gqr.bhv();
		}
	}

	[Token(Token = "0x2000061")]
	private class ds : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000396")]
		private dt gqs;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000397")]
		private sbyte gqt;

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public ds(dt me, sbyte t)
		{
			gqs = me;
			gqt = t;
		}

		[Token(Token = "0x60002D8")]
		[Address(RVA = "0x2784F0", Offset = "0x2774F0", VA = "0x1802784F0", Slot = "4")]
		public void th()
		{
			dt dt2 = gqs;
			sbyte b = gqt;
			dt2.bhz(b);
		}
	}

	[Token(Token = "0x400037B")]
	private static dt gqu;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400037C")]
	private int gqv = 220;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400037D")]
	private int gqw = 160;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400037E")]
	private int gqx;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400037F")]
	private int gqy;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000380")]
	private int gqz;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000381")]
	private int gra;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000382")]
	private int grb;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000383")]
	private int grc;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000384")]
	private GameObject grd;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000385")]
	private GameObject gre;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000386")]
	private GameObject grf;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000387")]
	private GameObject grg;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000388")]
	public List<jr> grh;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000389")]
	private hm gri;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x400038A")]
	private ScrollRect grj;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x400038B")]
	public jr grk;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400038C")]
	private Sprite[] grl;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x400038D")]
	private GameObject grm;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400038E")]
	private GameObject grn;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400038F")]
	private List<jr> gro;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000390")]
	private GameObject grp;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000391")]
	private GameObject grq;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000392")]
	private hm grr;

	[Token(Token = "0x60002C4")]
	[Address(RVA = "0x7CA580", Offset = "0x7C9580", VA = "0x1807CA580")]
	public static dt bhs()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		dt dt2 = gqu;
		if (dt2 == null)
		{
			dt dt3 = new dt();
			dt3.gqv = 220;
			dt3.gqw = 160;
			gqu = dt3;
		}
		return dt2;
	}

	[Token(Token = "0x60002C5")]
	[Address(RVA = "0x7CC420", Offset = "0x7CB420", VA = "0x1807CC420")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002C6")]
	[Address(RVA = "0x7CA640", Offset = "0x7C9640", VA = "0x1807CA640")]
	private void bht()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002C7")]
	[Address(RVA = "0x7CAEC0", Offset = "0x7C9EC0", VA = "0x1807CAEC0")]
	private void bhu(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002C8")]
	[Address(RVA = "0x7CAF90", Offset = "0x7C9F90", VA = "0x1807CAF90")]
	public void bhv()
	{
		GameObject gameObject = grf;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
		GameObject gameObject2 = hlj;
		int active2 = 0;
		gameObject2.SetActive((byte)active2 != 0);
		bhx();
		bhw();
	}

	[Token(Token = "0x60002C9")]
	[Address(RVA = "0x7CAFF0", Offset = "0x7C9FF0", VA = "0x1807CAFF0")]
	private void bhw()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002CA")]
	[Address(RVA = "0x7CB710", Offset = "0x7CA710", VA = "0x1807CB710")]
	private void bhx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002CB")]
	[Address(RVA = "0x7CBB70", Offset = "0x7CAB70", VA = "0x1807CBB70")]
	private void bhy(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002CC")]
	[Address(RVA = "0x7CD280", Offset = "0x7CC280", VA = "0x1807CD280")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002CD")]
	[Address(RVA = "0x7CBE70", Offset = "0x7CAE70", VA = "0x1807CBE70")]
	private void bhz(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002CE")]
	[Address(RVA = "0x7CC1C0", Offset = "0x7CB1C0", VA = "0x1807CC1C0")]
	public void bia(bc m)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002CF")]
	[Address(RVA = "0x7CA3A0", Offset = "0x7C93A0", VA = "0x1807CA3A0", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002D0")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002D1")]
	[Address(RVA = "0x7CC370", Offset = "0x7CB370", VA = "0x1807CC370", Slot = "9")]
	public override void close()
	{
		//IL_0016: Expected Obj, but got I4
		//IL_0027: Expected Obj, but got I4
		base.close();
		List<jr> list = grh;
		int num = 0;
		grk = (jr)num;
		((List<T>)(object)list)?.Clear();
		grr = (hm)num;
		Object.Destroy(hlf);
		Object.Destroy(grm);
	}

	[Token(Token = "0x60002D2")]
	[Address(RVA = "0x7CA340", Offset = "0x7C9340", VA = "0x1807CA340")]
	public dt()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
