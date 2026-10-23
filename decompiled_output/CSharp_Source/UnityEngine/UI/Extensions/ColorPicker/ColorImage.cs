using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x2000258")]
[RequireComponent(typeof(Image))]
public class ColorImage : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D25")]
	public ColorPickerControl picker;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D26")]
	private Image pld;

	[Token(Token = "0x60012F8")]
	[Address(RVA = "0x60DFC0", Offset = "0x60CFC0", VA = "0x18060DFC0")]
	private void Awake()
	{
		Image component = GetComponent<Image>();
		pld = component;
		ColorChangedEvent onValueChanged = picker.onValueChanged;
		UnityAction<Color> unityAction = (UnityAction<Color>)(object)new UnityAction<T0>(fec);
		((UnityEvent<T0>)(object)onValueChanged).AddListener((UnityAction<>)(object)unityAction);
	}

	[Token(Token = "0x60012F9")]
	[Address(RVA = "0x60E0A0", Offset = "0x60D0A0", VA = "0x18060E0A0")]
	private void OnDestroy()
	{
		ColorChangedEvent onValueChanged = picker.onValueChanged;
		UnityAction<Color> unityAction = (UnityAction<Color>)(object)new UnityAction<T0>(fec);
		((UnityEvent<T0>)(object)onValueChanged).RemoveListener((UnityAction<>)(object)unityAction);
	}

	[Token(Token = "0x60012FA")]
	[Address(RVA = "0x60E160", Offset = "0x60D160", VA = "0x18060E160")]
	private void fec(Color newColor)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012FB")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ColorImage()
	{
	}
}
