using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200006C")]
public class ei : fi
{
	[Token(Token = "0x200006D")]
	private class eg : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400042C")]
		private ei gxe;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400042D")]
		private sbyte gxf;

		[Token(Token = "0x600032F")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public eg(ei me, sbyte t)
		{
			gxe = me;
			gxf = t;
		}

		[Token(Token = "0x6000330")]
		[Address(RVA = "0x278670", Offset = "0x277670", VA = "0x180278670", Slot = "4")]
		public void th()
		{
			ei ei2 = gxe;
			sbyte b = gxf;
			ei2.bjm(b);
		}
	}

	[Token(Token = "0x200006E")]
	private class eh : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400042E")]
		private ei gxg;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400042F")]
		private int gxh;

		[Token(Token = "0x6000331")]
		[Address(RVA = "0x277DC0", Offset = "0x276DC0", VA = "0x180277DC0")]
		public eh(ei me, int id)
		{
			gxg = me;
			gxh = id;
		}

		[Token(Token = "0x6000332")]
		[Address(RVA = "0x2786D0", Offset = "0x2776D0", VA = "0x1802786D0", Slot = "4")]
		public void th()
		{
			ei ei2 = gxg;
			int zoneid = gxh;
			ei2.bjo(zoneid);
		}
	}

	[Token(Token = "0x4000426")]
	public static ei gxi;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000427")]
	private int gxj = 240;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000428")]
	private int gxk = 200;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000429")]
	private int gxl;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400042A")]
	private int gxm;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400042B")]
	private ScrollRect gxn;

	[Token(Token = "0x6000327")]
	[Address(RVA = "0x45E110", Offset = "0x45D110", VA = "0x18045E110")]
	public static ei bjl()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		ei ei2 = gxi;
		if (ei2 == null)
		{
			ei ei3 = new ei();
			ei3.gxj = 240;
			ei3.gxk = 200;
			gxi = ei3;
		}
		return ei2;
	}

	[Token(Token = "0x6000328")]
	[Address(RVA = "0x45E810", Offset = "0x45D810", VA = "0x18045E810")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000329")]
	[Address(RVA = "0x2FEFF0", Offset = "0x2FDFF0", VA = "0x1802FEFF0")]
	private void bjm(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600032A")]
	[Address(RVA = "0x45E1D0", Offset = "0x45D1D0", VA = "0x18045E1D0")]
	public void bjn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600032B")]
	[Address(RVA = "0x45E720", Offset = "0x45D720", VA = "0x18045E720")]
	private void bjo(int zoneid)
	{
		int num = 0;
		lj.cmy().cqu(zoneid);
	}

	[Token(Token = "0x600032C")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600032D")]
	[Address(RVA = "0x45E750", Offset = "0x45D750", VA = "0x18045E750", Slot = "9")]
	public override void close()
	{
		int num = 0;
		mo.ddt().deq();
		base.close();
		int num2 = 0;
		mo.ddt().deq();
		Object.Destroy(hlf);
	}

	[Token(Token = "0x600032E")]
	[Address(RVA = "0x45E0B0", Offset = "0x45D0B0", VA = "0x18045E0B0")]
	public ei()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
