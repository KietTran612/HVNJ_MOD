using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200019C")]
[RequireComponent(typeof(InputField))]
[AddComponentMenu("UI/Extensions/InputFocus")]
public class InputFocus : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001963")]
	protected InputField ost;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001964")]
	public bool _ignoreNextActivation;

	[Token(Token = "0x6000E18")]
	[Address(RVA = "0x441C70", Offset = "0x440C70", VA = "0x180441C70")]
	private void Start()
	{
		InputField component = GetComponent<InputField>();
		ost = component;
	}

	[Token(Token = "0x6000E19")]
	[Address(RVA = "0x441CB0", Offset = "0x440CB0", VA = "0x180441CB0")]
	private void Update()
	{
		if (!Input.GetKeyUpInt(KeyCode.Return))
		{
			return;
		}
		InputField inputField = ost;
		if (!inputField.m_AllowInput)
		{
			if (!_ignoreNextActivation)
			{
				inputField.Select();
				ost.ActivateInputField();
			}
			else
			{
				_ignoreNextActivation = false;
			}
		}
	}

	[Token(Token = "0x6000E1A")]
	[Address(RVA = "0x441D20", Offset = "0x440D20", VA = "0x180441D20")]
	public void ebe()
	{
		bool flag = string.Equals(ost.m_Text, "");
		ost.text = "";
		if (!flag)
		{
			ost.Select();
			ost.ActivateInputField();
		}
	}

	[Token(Token = "0x6000E1B")]
	[Address(RVA = "0x441BE0", Offset = "0x440BE0", VA = "0x180441BE0")]
	public void OnEndEdit(string textString)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E1C")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public InputFocus()
	{
	}
}
