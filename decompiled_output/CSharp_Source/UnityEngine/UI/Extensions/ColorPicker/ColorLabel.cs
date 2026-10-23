using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x2000259")]
[RequireComponent(typeof(Text))]
public class ColorLabel : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D27")]
	public ColorPickerControl picker;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D28")]
	public qn type;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D29")]
	public string prefix = "R: ";

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D2A")]
	public float minValue;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001D2B")]
	public float maxValue = 255f;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001D2C")]
	public int precision;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001D2D")]
	private Text ple;

	[Token(Token = "0x60012FC")]
	[Address(RVA = "0x60E1A0", Offset = "0x60D1A0", VA = "0x18060E1A0")]
	private void Awake()
	{
		Text component = GetComponent<Text>();
		ple = component;
	}

	[Token(Token = "0x60012FD")]
	[Address(RVA = "0x60E360", Offset = "0x60D360", VA = "0x18060E360")]
	private void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012FE")]
	[Address(RVA = "0x60E1E0", Offset = "0x60D1E0", VA = "0x18060E1E0")]
	private void OnDestroy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012FF")]
	[Address(RVA = "0x60E540", Offset = "0x60D540", VA = "0x18060E540")]
	private void fed(Color color)
	{
		fef();
	}

	[Token(Token = "0x6001300")]
	[Address(RVA = "0x60E540", Offset = "0x60D540", VA = "0x18060E540")]
	private void fee(float hue, float sateration, float value)
	{
		fef();
	}

	[Token(Token = "0x6001301")]
	[Address(RVA = "0x60E550", Offset = "0x60D550", VA = "0x18060E550")]
	private void fef()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001302")]
	[Address(RVA = "0x60E780", Offset = "0x60D780", VA = "0x18060E780")]
	private string feg(float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001303")]
	[Address(RVA = "0x60E4F0", Offset = "0x60D4F0", VA = "0x18060E4F0")]
	public ColorLabel()
	{
	}
}
