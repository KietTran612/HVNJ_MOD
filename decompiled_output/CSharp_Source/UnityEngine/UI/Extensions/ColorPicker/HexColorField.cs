using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x2000265")]
[RequireComponent(typeof(InputField))]
public class HexColorField : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D66")]
	public ColorPickerControl ColorPicker;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D67")]
	public bool displayAlpha;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D68")]
	private InputField plv;

	[Token(Token = "0x4001D69")]
	private const string plw = "^#?(?:[0-9a-fA-F]{3,4}){1,2}$";

	[Token(Token = "0x6001354")]
	[Address(RVA = "0x43C380", Offset = "0x43B380", VA = "0x18043C380")]
	private void Awake()
	{
		InputField.SubmitEvent onEndEdit = (plv = GetComponent<InputField>()).m_OnEndEdit;
		UnityAction<string> unityAction = (UnityAction<string>)(object)new UnityAction<T0>(fgg);
		((UnityEvent<T0>)(object)onEndEdit).AddListener((UnityAction<>)(object)unityAction);
		ColorChangedEvent onValueChanged = ColorPicker.onValueChanged;
		UnityAction<Color> unityAction2 = (UnityAction<Color>)(object)new UnityAction<T0>(fgf);
		((UnityEvent<T0>)(object)onValueChanged).AddListener((UnityAction<>)(object)unityAction2);
	}

	[Token(Token = "0x6001355")]
	[Address(RVA = "0x43C4E0", Offset = "0x43B4E0", VA = "0x18043C4E0")]
	private void OnDestroy()
	{
		InputField.OnChangeEvent onValueChanged = plv.m_OnValueChanged;
		UnityAction<string> unityAction = (UnityAction<string>)(object)new UnityAction<T0>(fgg);
		((UnityEvent<T0>)(object)onValueChanged).RemoveListener((UnityAction<>)(object)unityAction);
		ColorChangedEvent onValueChanged2 = ColorPicker.onValueChanged;
		UnityAction<Color> unityAction2 = (UnityAction<Color>)(object)new UnityAction<T0>(fgf);
		((UnityEvent<T0>)(object)onValueChanged2).RemoveListener((UnityAction<>)(object)unityAction2);
	}

	[Token(Token = "0x6001356")]
	[Address(RVA = "0x43C620", Offset = "0x43B620", VA = "0x18043C620")]
	private void fgf(Color newColor)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001357")]
	[Address(RVA = "0x43C680", Offset = "0x43B680", VA = "0x18043C680")]
	private void fgg(string newHex)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001358")]
	[Address(RVA = "0x43C750", Offset = "0x43B750", VA = "0x18043C750")]
	private string fgh(Color32 color)
	{
		//IL_0051: Expected Obj, but got I4
		//IL_0061: Expected Obj, but got I4
		//IL_0071: Expected Obj, but got I4
		int rgba;
		object[] array;
		while (true)
		{
			rgba = color.rgba;
			if (!displayAlpha)
			{
				return string.Format("#{0:X2}{1:X2}{2:X2}", "#{0:X2}{1:X2}{2:X2}{3:X2}", "#{0:X2}{1:X2}{2:X2}{3:X2}", "#{0:X2}{1:X2}{2:X2}{3:X2}");
			}
			array = new object[4];
			if (array != null && array == null)
			{
				continue;
			}
			array[0] = array;
			if (rgba != 0 && rgba == 0)
			{
				continue;
			}
			array[1] = rgba;
			if (rgba == 0 || rgba != 0)
			{
				array[2] = rgba;
				if (rgba == 0 || rgba != 0)
				{
					break;
				}
			}
		}
		array[3] = rgba;
		return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", array);
	}

	[Token(Token = "0x6001359")]
	[Address(RVA = "0x43CA10", Offset = "0x43BA10", VA = "0x18043CA10")]
	public static bool fgi(string hex, out Color32 color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600135A")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public HexColorField()
	{
	}
}
