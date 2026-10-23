using Cpp2IlInjected;
using Spine;
using Spine.Unity;
using UnityEngine;

[Token(Token = "0x20000EE")]
public class jb : jf
{
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000ED5")]
	private km kwv;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000ED6")]
	private SkeletonAnimation kww;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000ED7")]
	public lm kwx;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000ED8")]
	public float kwy;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000ED9")]
	public float kwz;

	[Token(Token = "0x6000734")]
	[Address(RVA = "0x4E7080", Offset = "0x4E6080", VA = "0x1804E7080")]
	public static void cgi(string nameEff, float x, float y, lm c)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000735")]
	[Address(RVA = "0x4E7660", Offset = "0x4E6660", VA = "0x1804E7660")]
	public static void cgj(string nameEff, sbyte dir, lm c)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000736")]
	[Address(RVA = "0x4E7C20", Offset = "0x4E6C20", VA = "0x1804E7C20")]
	private static float cgk(string nameEff)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000737")]
	[Address(RVA = "0x4E7C80", Offset = "0x4E6C80", VA = "0x1804E7C80")]
	private static float cgl(string nameEff)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000738")]
	[Address(RVA = "0x4E7E70", Offset = "0x4E6E70", VA = "0x1804E7E70")]
	private static float cgm(string nameEff)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000739")]
	[Address(RVA = "0x4E6B50", Offset = "0x4E5B50", VA = "0x1804E6B50")]
	public jb(km obj, string nameEff)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600073A")]
	[Address(RVA = "0x4E6E50", Offset = "0x4E5E50", VA = "0x1804E6E50")]
	public jb(km obj, string nameEff, bool isLoop)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600073B")]
	[Address(RVA = "0x4E6B40", Offset = "0x4E5B40", VA = "0x1804E6B40")]
	private void StandUp_Complete(TrackEntry trackEntry)
	{
		kxu = true;
	}

	[Token(Token = "0x600073C")]
	[Address(RVA = "0x4E6FC0", Offset = "0x4E5FC0", VA = "0x1804E6FC0", Slot = "4")]
	public override void cgg()
	{
		//IL_0026: Expected Obj, but got I4
		if ((long)kwx != 0)
		{
			km km2 = kwv;
			if (km2 != null)
			{
				GameObject luf = km2.luf;
				int num = 0;
				if (luf != (Object)num)
				{
					km km3 = kwv;
					lm lm2 = kwx;
					float mgw = lm2.mgw;
					float mgv = lm2.mgv;
					hl.bwl(km3.luf, mgv, mgw);
				}
			}
		}
		base.cgg();
	}

	[Token(Token = "0x600073D")]
	[Address(RVA = "0x4E6700", Offset = "0x4E5700", VA = "0x1804E6700", Slot = "5")]
	public override void close()
	{
		km km2 = kwv;
		if (km2 != null)
		{
			int isS = 0;
			km2.cky((byte)isS != 0);
		}
	}

	[Token(Token = "0x600073E")]
	[Address(RVA = "0x4E7F50", Offset = "0x4E6F50", VA = "0x1804E7F50")]
	public void cgn()
	{
		//IL_001b: Expected Obj, but got I4
		km km2 = kwv;
		if (km2 != null)
		{
			GameObject luf = km2.luf;
			int num = 0;
			if (luf != (Object)num)
			{
				Object.Destroy(kwv.luf);
			}
		}
	}
}
