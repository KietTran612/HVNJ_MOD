using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x200025E")]
public class ColorPickerTester : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D4A")]
	public Renderer pickerRenderer;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D4B")]
	public ColorPickerControl picker;

	[Token(Token = "0x600132D")]
	[Address(RVA = "0x610130", Offset = "0x60F130", VA = "0x180610130")]
	private void Awake()
	{
		Renderer component = GetComponent<Renderer>();
		pickerRenderer = component;
	}

	[Token(Token = "0x600132E")]
	[Address(RVA = "0x610170", Offset = "0x60F170", VA = "0x180610170")]
	private void Start()
	{
		ColorChangedEvent onValueChanged = picker.onValueChanged;
		UnityAction<Color> unityAction = (UnityAction<Color>)(object)(UnityAction<T0>)([Token(Token = "0x6001330")] [Address(RVA = "0x610230", Offset = "0x60F230", VA = "0x180610230")] (Color color) =>
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		});
		((UnityEvent<T0>)(object)onValueChanged).AddListener((UnityAction<>)(object)unityAction);
	}

	[Token(Token = "0x600132F")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ColorPickerTester()
	{
	}

	[Token(Token = "0x6001330")]
	[Address(RVA = "0x610230", Offset = "0x60F230", VA = "0x180610230")]
	[CompilerGenerated]
	private void ffm(Color color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
