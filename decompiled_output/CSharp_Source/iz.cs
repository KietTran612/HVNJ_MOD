using Cpp2IlInjected;
using Spine;
using Spine.Unity;

[Token(Token = "0x20000EC")]
public class iz : jf
{
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000ECF")]
	private km kwp;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000ED0")]
	private SkeletonAnimation kwq;

	[Token(Token = "0x6000729")]
	[Address(RVA = "0x4E62F0", Offset = "0x4E52F0", VA = "0x1804E62F0")]
	public static void cge(string nameEff, int x, int y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600072A")]
	[Address(RVA = "0x4E6510", Offset = "0x4E5510", VA = "0x1804E6510")]
	public static void cgf(lm c, int x, int y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600072B")]
	[Address(RVA = "0x4E61F0", Offset = "0x4E51F0", VA = "0x1804E61F0")]
	public iz(km obj, string nameEff)
	{
		cgg();
		kwp = obj;
		AnimationState state = (kwq = obj.luf.GetComponent<SkeletonAnimation>()).state;
		bool loop = kxv;
		int trackIndex = 0;
		TrackEntry trackEntry = state.SetAnimation(trackIndex, nameEff, loop);
		AnimationState.TrackEntryDelegate value = StandUp_Complete;
		trackEntry.Complete += value;
	}

	[Token(Token = "0x600072C")]
	[Address(RVA = "0x4E61D0", Offset = "0x4E51D0", VA = "0x1804E61D0")]
	private void StandUp_Complete(TrackEntry trackEntry)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600072D")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "4")]
	public override void cgg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600072E")]
	[Address(RVA = "0x4E6700", Offset = "0x4E5700", VA = "0x1804E6700", Slot = "5")]
	public override void close()
	{
		km km2 = kwp;
		if (km2 != null)
		{
			int isS = 0;
			km2.cky((byte)isS != 0);
		}
	}
}
