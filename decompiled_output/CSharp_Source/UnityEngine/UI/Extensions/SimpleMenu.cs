using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000212")]
public abstract class SimpleMenu<T> : Menu<T> where T : SimpleMenu<T>
{
	[Token(Token = "0x6001133")]
	[Address(RVA = "0x331170", Offset = "0x330170", VA = "0x180331170")]
	public static void etd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001134")]
	[Address(RVA = "0x3310E0", Offset = "0x3300E0", VA = "0x1803310E0")]
	public static void Hide()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001135")]
	[Address(RVA = "0x331140", Offset = "0x330140", VA = "0x180331140")]
	protected SimpleMenu()
	{
		((BaseInputModule)(object)this).Process();
	}
}
