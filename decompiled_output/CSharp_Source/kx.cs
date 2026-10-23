using System;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200011F")]
public class kx : lm
{
	[FieldOffset(Offset = "0x698")]
	[Token(Token = "0x40011AE")]
	private hn lyz;

	[FieldOffset(Offset = "0x6A0")]
	[Token(Token = "0x40011AF")]
	private hn lza;

	[FieldOffset(Offset = "0x6A8")]
	[Token(Token = "0x40011B0")]
	public lm lzb;

	[FieldOffset(Offset = "0x6B0")]
	[Token(Token = "0x40011B1")]
	public bool lzc;

	[FieldOffset(Offset = "0x6B8")]
	[Token(Token = "0x40011B2")]
	public mt lzd;

	[FieldOffset(Offset = "0x6C0")]
	[Token(Token = "0x40011B3")]
	public lm lze;

	[FieldOffset(Offset = "0x6C8")]
	[Token(Token = "0x40011B4")]
	public short lzf;

	[FieldOffset(Offset = "0x6CA")]
	[Token(Token = "0x40011B5")]
	private bool lzg;

	[Token(Token = "0x6000810")]
	[Address(RVA = "0x1F5B10", Offset = "0x1F4B10", VA = "0x1801F5B10")]
	public kx()
	{
		//IL_000f: Expected I4, but got I8
		mel = 1;
	}

	[Token(Token = "0x6000811")]
	[Address(RVA = "0x1F5B70", Offset = "0x1F4B70", VA = "0x1801F5B70")]
	public void cli()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000812")]
	[Address(RVA = "0x1F6090", Offset = "0x1F5090", VA = "0x1801F6090", Slot = "18")]
	public override void clj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000813")]
	[Address(RVA = "0x1F60E0", Offset = "0x1F50E0", VA = "0x1801F60E0")]
	private void clk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000814")]
	[Address(RVA = "0x1F6790", Offset = "0x1F5790", VA = "0x1801F6790")]
	public void cll(mt m)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000815")]
	[Address(RVA = "0x1F68D0", Offset = "0x1F58D0", VA = "0x1801F68D0")]
	public void clm(lm m)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000816")]
	[Address(RVA = "0x1F6A10", Offset = "0x1F5A10", VA = "0x1801F6A10", Slot = "28")]
	public override void cln(lg obj)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000817")]
	[Address(RVA = "0x1F6A90", Offset = "0x1F5A90", VA = "0x1801F6A90", Slot = "29")]
	protected override void clo()
	{
		lzg = false;
		base.clo();
		doAttack();
	}

	[Token(Token = "0x6000818")]
	[Address(RVA = "0x1F8450", Offset = "0x1F7450", VA = "0x1801F8450")]
	private void doAttack()
	{
		//IL_00d4: Expected Obj, but got I8
		mt[] array2;
		mt mt2;
		while (true)
		{
			if ((long)lzd == 0)
			{
				if ((long)lze == 0)
				{
					return;
				}
				GC.KeepAlive("doAttack");
				kv skillPaint = mc.ncm[0];
				int sType = 0;
				cvg(skillPaint, sType);
				lm[] array = new lm[1];
				lm lm2 = lze;
				mju = array;
				if (lm2 == null || array != null)
				{
					array[0] = lm2;
					lm lm3 = mju[0];
					mjq = lm3;
					return;
				}
			}
			else
			{
				kv skillPaint2 = mc.ncm[0];
				int sType2 = 0;
				cvg(skillPaint2, sType2);
				array2 = new mt[1];
				mt2 = lzd;
				mjt = array2;
				if (mt2 == null || array2 != null)
				{
					break;
				}
			}
		}
		array2[0] = mt2;
		mt mt3 = lzd;
		mjn = mt3;
		lzd = (mt)0;
	}

	[Token(Token = "0x6000819")]
	[Address(RVA = "0x1F6BB0", Offset = "0x1F5BB0", VA = "0x1801F6BB0")]
	public void clp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600081A")]
	[Address(RVA = "0x1F6E60", Offset = "0x1F5E60", VA = "0x1801F6E60", Slot = "25")]
	public override void clq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600081B")]
	[Address(RVA = "0x1F7220", Offset = "0x1F6220", VA = "0x1801F7220", Slot = "21")]
	public override void clr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600081C")]
	[Address(RVA = "0x1F72F0", Offset = "0x1F62F0", VA = "0x1801F72F0", Slot = "20")]
	public override void cls()
	{
		if (!lzc)
		{
			cus();
		}
	}

	[Token(Token = "0x600081D")]
	[Address(RVA = "0x1F7310", Offset = "0x1F6310", VA = "0x1801F7310", Slot = "22")]
	public override void clt()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600081E")]
	[Address(RVA = "0x1F7760", Offset = "0x1F6760", VA = "0x1801F7760", Slot = "23")]
	public override void clu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600081F")]
	[Address(RVA = "0x1F7AF0", Offset = "0x1F6AF0", VA = "0x1801F7AF0", Slot = "24")]
	public override void clv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000820")]
	[Address(RVA = "0x1F8230", Offset = "0x1F7230", VA = "0x1801F8230", Slot = "16")]
	public override void clw(bool isUpdate)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000821")]
	[Address(RVA = "0x1F8360", Offset = "0x1F7360", VA = "0x1801F8360", Slot = "17")]
	public override void clx(float dx, float dy)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000822")]
	[Address(RVA = "0x1F6AC0", Offset = "0x1F5AC0", VA = "0x1801F6AC0", Slot = "27")]
	public override void close()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0054: Expected Obj, but got I4
		//IL_005c: Expected Obj, but got I4
		//IL_0064: Expected Obj, but got I4
		GameObject gameObject = mda;
		int num = 0;
		if (!(gameObject == (UnityEngine.Object)num))
		{
			mqt?.close();
			lyz?.close();
			lza?.close();
			int num2 = 0;
			lza = (hn)num2;
			lyz = (hn)num2;
			mqt = (hn)num2;
			UnityEngine.Object.Destroy(mda);
		}
	}
}
