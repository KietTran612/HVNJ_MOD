using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x2000266")]
[ExecuteInEditMode]
[RequireComponent(typeof(BoxSlider), typeof(RawImage))]
public class SVBoxSlider : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D6A")]
	public ColorPickerControl picker;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D6B")]
	private BoxSlider plx;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D6C")]
	private RawImage ply;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D6D")]
	private float plz = -1f;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001D6E")]
	private bool pma = true;

	[Token(Token = "0x1700012A")]
	public RectTransform pyn
	{
		[Token(Token = "0x600135B")]
		[Address(RVA = "0x47DEB0", Offset = "0x47CEB0", VA = "0x18047DEB0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x600135C")]
	[Address(RVA = "0x47DA50", Offset = "0x47CA50", VA = "0x18047DA50")]
	private void Awake()
	{
		BoxSlider component = GetComponent<BoxSlider>();
		plx = component;
		RawImage component2 = GetComponent<RawImage>();
		ply = component2;
		fgm();
	}

	[Token(Token = "0x600135D")]
	[Address(RVA = "0x47DD00", Offset = "0x47CD00", VA = "0x18047DD00")]
	private void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600135E")]
	[Address(RVA = "0x47DB80", Offset = "0x47CB80", VA = "0x18047DB80")]
	private void OnDisable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600135F")]
	[Address(RVA = "0x47DAC0", Offset = "0x47CAC0", VA = "0x18047DAC0")]
	private void OnDestroy()
	{
		//IL_0015: Expected Obj, but got I4
		Texture texture = ply.m_Texture;
		int num = 0;
		if (texture != (Object)num)
		{
			Object.DestroyImmediate(ply.m_Texture);
		}
	}

	[Token(Token = "0x6001360")]
	[Address(RVA = "0x47DF10", Offset = "0x47CF10", VA = "0x18047DF10")]
	private void fgk(float saturation, float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001361")]
	[Address(RVA = "0x47DF70", Offset = "0x47CF70", VA = "0x18047DF70")]
	private void fgl(float h, float s, float v)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001362")]
	[Address(RVA = "0x47E030", Offset = "0x47D030", VA = "0x18047E030")]
	private void fgm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001363")]
	[Address(RVA = "0x47DE90", Offset = "0x47CE90", VA = "0x18047DE90")]
	public SVBoxSlider()
	{
	}
}
