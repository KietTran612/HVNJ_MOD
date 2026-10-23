using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200026D")]
public class ComboBoxChanged : MonoBehaviour
{
	[Token(Token = "0x6001384")]
	[Address(RVA = "0x6937A0", Offset = "0x6927A0", VA = "0x1806937A0")]
	public void fhj(string text)
	{
		Debug.Log("ComboBox changed [" + text + "]");
	}

	[Token(Token = "0x6001385")]
	[Address(RVA = "0x693830", Offset = "0x692830", VA = "0x180693830")]
	public void fhk(string text)
	{
		Debug.Log("AutoCompleteComboBox changed [" + text + "]");
	}

	[Token(Token = "0x6001386")]
	[Address(RVA = "0x6938C0", Offset = "0x6928C0", VA = "0x1806938C0")]
	public void fhl(string text, bool valid)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001387")]
	[Address(RVA = "0x693B40", Offset = "0x692B40", VA = "0x180693B40")]
	public void fhm(int newValue)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001388")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ComboBoxChanged()
	{
	}
}
