using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000068")]
public class ee : fi
{
	[Token(Token = "0x2000069")]
	private class ec : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000410")]
		private ee gvz;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000411")]
		private sbyte gwa;

		[Token(Token = "0x600031A")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public ec(ee me, sbyte t)
		{
			gvz = me;
			gwa = t;
		}

		[Token(Token = "0x600031B")]
		[Address(RVA = "0x278670", Offset = "0x277670", VA = "0x180278670", Slot = "4")]
		public void th()
		{
			ee ee2 = gvz;
			sbyte b = gwa;
			ee2.bjc(b);
		}
	}

	[Token(Token = "0x200006A")]
	private class ed : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000412")]
		private int gwb;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000413")]
		private ee gwc;

		[Token(Token = "0x600031C")]
		[Address(RVA = "0x2782F0", Offset = "0x2772F0", VA = "0x1802782F0")]
		public ed(ee me, int ind)
		{
			gwc = me;
			gwb = ind;
		}

		[Token(Token = "0x600031D")]
		[Address(RVA = "0x2786A0", Offset = "0x2776A0", VA = "0x1802786A0", Slot = "4")]
		public void th()
		{
			ee ee2 = gwc;
			int index = gwb;
			ee2.bjf(index);
		}
	}

	[Token(Token = "0x4000407")]
	private static ee gwd;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000408")]
	private int gwe = 220;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000409")]
	private int gwf = 200;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400040A")]
	private int gwg;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400040B")]
	private int gwh;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400040C")]
	private ScrollRect gwi;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400040D")]
	private hm gwj;

	[Token(Token = "0x400040E")]
	public static bool gwk;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400040F")]
	private GameObject gwl;

	[Token(Token = "0x600030D")]
	[Address(RVA = "0x459C90", Offset = "0x458C90", VA = "0x180459C90")]
	public static ee bjb()
	{
		//IL_0013: Expected I4, but got I8
		//IL_0020: Expected I4, but got I8
		ee ee2 = new ee();
		ee2.gwe = 220;
		ee2.gwf = 200;
		gwd = ee2;
		return ee2;
	}

	[Token(Token = "0x600030E")]
	[Address(RVA = "0x45B0C0", Offset = "0x45A0C0", VA = "0x18045B0C0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600030F")]
	[Address(RVA = "0x2FEFF0", Offset = "0x2FDFF0", VA = "0x1802FEFF0")]
	private void bjc(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000310")]
	[Address(RVA = "0x459DC0", Offset = "0x458DC0", VA = "0x180459DC0")]
	public void bjd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000311")]
	[Address(RVA = "0x459C80", Offset = "0x458C80", VA = "0x180459C80", Slot = "6")]
	public override void bcd()
	{
		bje();
	}

	[Token(Token = "0x6000312")]
	[Address(RVA = "0x45A920", Offset = "0x459920", VA = "0x18045A920")]
	public void bje()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000313")]
	[Address(RVA = "0x45AC40", Offset = "0x459C40", VA = "0x18045AC40")]
	private void bjf(int index)
	{
		mo.nsx = index;
		close();
		int num = 0;
		if ((long)mo.nex != 0)
		{
			int num2 = 0;
			mo.ddt().odd.cgd();
		}
	}

	[Token(Token = "0x6000314")]
	[Address(RVA = "0x45AD20", Offset = "0x459D20", VA = "0x18045AD20")]
	public void bjg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000315")]
	[Address(RVA = "0x459BC0", Offset = "0x458BC0", VA = "0x180459BC0", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000316")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000317")]
	[Address(RVA = "0x45B010", Offset = "0x45A010", VA = "0x18045B010", Slot = "9")]
	public override void close()
	{
		int num = 0;
		mo.ddt().deq();
		base.close();
		Object.Destroy(hlf);
	}

	[Token(Token = "0x6000318")]
	[Address(RVA = "0x459B60", Offset = "0x458B60", VA = "0x180459B60")]
	public ee()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}

	[Token(Token = "0x6000319")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static ee()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
