using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000247")]
internal static class qg
{
	[Token(Token = "0x6001299")]
	[Address(RVA = "0x2804F0", Offset = "0x27F4F0", VA = "0x1802804F0")]
	public static bool fbw(ref Color currentValue, Color newValue)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600129A")]
	[Address(RVA = "0xA648D0", Offset = "0xA638D0", VA = "0x180A648D0")]
	public static bool fbx<T>(ref T currentValue, T newValue) where T : struct
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600129B")]
	[Address(RVA = "0x4B9550", Offset = "0x4B8550", VA = "0x1804B9550")]
	public static bool fby<T>(ref T currentValue, T newValue) where T : class
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
