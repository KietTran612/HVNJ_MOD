using Cpp2IlInjected;
using Spine;
using Spine.Unity;

[Token(Token = "0x20000ED")]
public class ja : jf
{
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000ED1")]
	private km kwr;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000ED2")]
	private SkeletonAnimation kws;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000ED3")]
	private lm kwt;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000ED4")]
	private string kwu;

	[Token(Token = "0x600072F")]
	[Address(RVA = "0x4E68A0", Offset = "0x4E58A0", VA = "0x1804E68A0")]
	public static void cgh(string nameEff, lm c)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000730")]
	[Address(RVA = "0x4E6740", Offset = "0x4E5740", VA = "0x1804E6740")]
	public ja(km obj, string nameEff)
	{
		//IL_005f: Expected I4, but got I8
		kwr = obj;
		kwu = nameEff;
		AnimationState state = (kws = obj.luf.GetComponent<SkeletonAnimation>()).state;
		int trackIndex = 0;
		TrackEntry trackEntry = state.SetAnimation(trackIndex, nameEff, loop: true);
		AnimationState.TrackEntryDelegate value = StandUp_Complete;
		trackEntry.Complete += value;
		kxt = 500;
	}

	[Token(Token = "0x6000731")]
	[Address(RVA = "0x4E6720", Offset = "0x4E5720", VA = "0x1804E6720")]
	private void StandUp_Complete(TrackEntry trackEntry)
	{
		lm c = kwt;
		kxu = true;
		cgh(kwu, c);
	}

	[Token(Token = "0x6000732")]
	[Address(RVA = "0x4E6850", Offset = "0x4E5850", VA = "0x1804E6850", Slot = "4")]
	public override void cgg()
	{
		lm lm2 = kwt;
		if (lm2 != null)
		{
			km km2 = kwr;
			if (km2 != null)
			{
				float mgw = lm2.mgw;
				float mgv = lm2.mgv;
				hl.bwl(km2.luf, mgv, mgw);
			}
		}
		base.cgg();
	}

	[Token(Token = "0x6000733")]
	[Address(RVA = "0x4E6700", Offset = "0x4E5700", VA = "0x1804E6700", Slot = "5")]
	public override void close()
	{
		km km2 = kwr;
		if (km2 != null)
		{
			int isS = 0;
			km2.cky((byte)isS != 0);
		}
	}
}
