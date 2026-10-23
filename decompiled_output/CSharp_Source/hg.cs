using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000BF")]
public class hg : he
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000AE5")]
	public jc jlp;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000AE6")]
	public int jlq;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000AE7")]
	public int jlr;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000AE8")]
	public float jls;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000AE9")]
	public float jlt;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000AEA")]
	private lm jlu;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000AEB")]
	public short jlv;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000AEC")]
	private long jlw;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000AED")]
	private hl jlx;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000AEE")]
	private hl jly;

	[Token(Token = "0x6000591")]
	[Address(RVA = "0x7DD220", Offset = "0x7DC220", VA = "0x1807DD220")]
	public hg()
	{
		//IL_0009: Expected I4, but got I8
		jlr = 1;
		((object)this)._002Ector();
	}

	[Token(Token = "0x6000592")]
	[Address(RVA = "0x7DD280", Offset = "0x7DC280", VA = "0x1807DD280")]
	public hg(short idEff)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000593")]
	[Address(RVA = "0x7DE0D0", Offset = "0x7DD0D0", VA = "0x1807DE0D0")]
	public static void bvk(int id, float cx, float cy, int loopCount)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000594")]
	[Address(RVA = "0x7DE2B0", Offset = "0x7DD2B0", VA = "0x1807DE2B0")]
	public static void bvl(int id, float cx, float cy, int loopCount, sbyte dir)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000595")]
	[Address(RVA = "0x7DE4A0", Offset = "0x7DD4A0", VA = "0x1807DE4A0")]
	public static void bvm(int id, lm c, int loopCount)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000596")]
	[Address(RVA = "0x7DE670", Offset = "0x7DD670", VA = "0x1807DE670")]
	public static void bvn(int id, lm c, int time)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000597")]
	[Address(RVA = "0x7DD650", Offset = "0x7DC650", VA = "0x1807DD650", Slot = "5")]
	public override void bva()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000598")]
	[Address(RVA = "0x7DD360", Offset = "0x7DC360", VA = "0x1807DD360", Slot = "4")]
	public override void buz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000599")]
	[Address(RVA = "0x7DE880", Offset = "0x7DD880", VA = "0x1807DE880", Slot = "6")]
	public override void close()
	{
		//IL_0026: Expected Obj, but got I8
		//IL_003e: Expected Obj, but got I8
		hl hl2 = jlx;
		if (hl2 != null)
		{
			Object.Destroy(hl2.jnn);
		}
		hl hl3 = jly;
		jlx = (hl)0;
		if (hl3 != null)
		{
			Object.Destroy(hl3.jnn);
		}
		jly = (hl)0;
	}

	[Token(Token = "0x600059A")]
	[Address(RVA = "0x7DE830", Offset = "0x7DD830", VA = "0x1807DE830")]
	public void bvo(bool isA)
	{
		jlx?.bwy(isA);
		jly?.bwy(isA);
	}
}
