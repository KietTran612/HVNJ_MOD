using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x2000261")]
[ExecuteInEditMode]
[RequireComponent(typeof(RawImage))]
public class ColorSliderImage : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D57")]
	public ColorPickerControl picker;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D58")]
	public qn type;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001D59")]
	public Slider.Direction direction;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D5A")]
	private RawImage plu;

	[Token(Token = "0x17000126")]
	private RectTransform pyj
	{
		[Token(Token = "0x6001340")]
		[Address(RVA = "0x610D10", Offset = "0x60FD10", VA = "0x180610D10")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x6001341")]
	[Address(RVA = "0x610830", Offset = "0x60F830", VA = "0x180610830")]
	private void Awake()
	{
		if (!(plu = GetComponent<RawImage>()))
		{
			string text = name;
			Debug.LogWarning("Missing RawImage on object [" + text + "]");
		}
		else
		{
			ffv();
		}
	}

	[Token(Token = "0x6001342")]
	[Address(RVA = "0x610B80", Offset = "0x60FB80", VA = "0x180610B80")]
	private void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001343")]
	[Address(RVA = "0x610A00", Offset = "0x60FA00", VA = "0x180610A00")]
	private void OnDisable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001344")]
	[Address(RVA = "0x610940", Offset = "0x60F940", VA = "0x180610940")]
	private void OnDestroy()
	{
		//IL_0015: Expected Obj, but got I4
		Texture texture = plu.m_Texture;
		int num = 0;
		if (texture != (Object)num)
		{
			Object.DestroyImmediate(plu.m_Texture);
		}
	}

	[Token(Token = "0x6001345")]
	[Address(RVA = "0x610D70", Offset = "0x60FD70", VA = "0x180610D70")]
	private void fft(Color newColor)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001346")]
	[Address(RVA = "0x610D70", Offset = "0x60FD70", VA = "0x180610D70")]
	private void ffu(float hue, float saturation, float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001347")]
	[Address(RVA = "0x610DC0", Offset = "0x60FDC0", VA = "0x180610DC0")]
	private void ffv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001348")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ColorSliderImage()
	{
	}
}
