using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x2000260")]
[RequireComponent(typeof(Slider))]
public class ColorSlider : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D53")]
	public ColorPickerControl ColorPicker;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D54")]
	public qn type;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D55")]
	private Slider pls;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D56")]
	private bool plt = true;

	[Token(Token = "0x600133A")]
	[Address(RVA = "0x6117C0", Offset = "0x6107C0", VA = "0x1806117C0")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600133B")]
	[Address(RVA = "0x6119A0", Offset = "0x6109A0", VA = "0x1806119A0")]
	private void OnDestroy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600133C")]
	[Address(RVA = "0x611B70", Offset = "0x610B70", VA = "0x180611B70")]
	private void ffp(Color newColor)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600133D")]
	[Address(RVA = "0x611C10", Offset = "0x610C10", VA = "0x180611C10")]
	private void ffq(float hue, float saturation, float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600133E")]
	[Address(RVA = "0x611C80", Offset = "0x610C80", VA = "0x180611C80")]
	private void ffr(float newValue)
	{
		if (plt)
		{
			float normalizedValue = pls.normalizedValue;
			ColorPickerControl colorPicker = ColorPicker;
			qn qn2 = type;
			colorPicker.ffb(qn2, normalizedValue);
		}
		plt = true;
	}

	[Token(Token = "0x600133F")]
	[Address(RVA = "0x611B60", Offset = "0x610B60", VA = "0x180611B60")]
	public ColorSlider()
	{
	}
}
