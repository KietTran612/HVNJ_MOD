using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001C0")]
[AddComponentMenu("UI/Effects/Extensions/BestFit Outline")]
public class BestFitOutline : Shadow
{
	[Token(Token = "0x6000F1B")]
	[Address(RVA = "0x600860", Offset = "0x5FF860", VA = "0x180600860")]
	protected BestFitOutline()
	{
	}

	[Token(Token = "0x6000F1C")]
	[Address(RVA = "0x600420", Offset = "0x5FF420", VA = "0x180600420", Slot = "19")]
	public override void ModifyMesh(Mesh mesh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
