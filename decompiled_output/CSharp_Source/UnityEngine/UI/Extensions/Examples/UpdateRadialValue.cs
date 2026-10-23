using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200028E")]
public class UpdateRadialValue : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DC0")]
	public InputField input;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DC1")]
	public RadialSlider slider;

	[Token(Token = "0x60013FA")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013FB")]
	[Address(RVA = "0x42E530", Offset = "0x42D530", VA = "0x18042E530")]
	public void fix()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013FC")]
	[Address(RVA = "0x42E590", Offset = "0x42D590", VA = "0x18042E590")]
	public void fiy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013FD")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UpdateRadialValue()
	{
	}
}
