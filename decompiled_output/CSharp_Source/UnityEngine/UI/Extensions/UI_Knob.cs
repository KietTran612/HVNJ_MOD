using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001BD")]
[RequireComponent(typeof(Image))]
[AddComponentMenu("UI/Extensions/UI_Knob")]
public class UI_Knob : Selectable, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IInitializePotentialDragHandler
{
	[Token(Token = "0x20001BE")]
	public enum om
	{
		[Token(Token = "0x4001A1D")]
		CW,
		[Token(Token = "0x4001A1E")]
		CCW
	}

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4001A0C")]
	[Tooltip("Direction of rotation CW - clockwise, CCW - counterClockwise")]
	public om direction;

	[FieldOffset(Offset = "0xFC")]
	[Token(Token = "0x4001A0D")]
	[HideInInspector]
	public float knobValue;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001A0E")]
	[Tooltip("Max value of the knob, maximum RAW output value knob can reach, overrides snap step, IF set to 0 or higher than loops, max value will be set by loops")]
	public float maxValue;

	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4001A0F")]
	[Tooltip("How many rotations knob can do, if higher than max value, the latter will limit max value")]
	public int loops = 1;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4001A10")]
	[Tooltip("Clamp output value between 0 and 1, useful with loops > 1")]
	public bool clampOutput01;

	[FieldOffset(Offset = "0x109")]
	[Token(Token = "0x4001A11")]
	[Tooltip("snap to position?")]
	public bool snapToPosition;

	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4001A12")]
	[Tooltip("Number of positions to snap")]
	public int snapStepsPerLoop = 10;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4001A13")]
	[Space]
	public KnobFloatValueEvent OnValueChanged;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001A14")]
	private float owt;

	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4001A15")]
	private float owu;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4001A16")]
	private float owv;

	[FieldOffset(Offset = "0x124")]
	[Token(Token = "0x4001A17")]
	private float oww;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4001A18")]
	private Vector2 owx;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x4001A19")]
	private Quaternion owy;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x4001A1A")]
	private bool owz;

	[FieldOffset(Offset = "0x141")]
	[Token(Token = "0x4001A1B")]
	private bool oxa;

	[Token(Token = "0x6000F10")]
	[Address(RVA = "0x42CC60", Offset = "0x42BC60", VA = "0x18042CC60", Slot = "4")]
	protected override void Awake()
	{
		bool flag = GetComponentInParent<Canvas>().rootCanvas.renderMode == RenderMode.ScreenSpaceOverlay;
		oxa = flag;
	}

	[Token(Token = "0x6000F11")]
	[Address(RVA = "0x42D390", Offset = "0x42C390", VA = "0x18042D390", Slot = "33")]
	public override void OnPointerUp(PointerEventData eventData)
	{
		owz = false;
	}

	[Token(Token = "0x6000F12")]
	[Address(RVA = "0x42D380", Offset = "0x42C380", VA = "0x18042D380", Slot = "34")]
	public override void OnPointerEnter(PointerEventData eventData)
	{
		owz = true;
	}

	[Token(Token = "0x6000F13")]
	[Address(RVA = "0x42D390", Offset = "0x42C390", VA = "0x18042D390", Slot = "35")]
	public override void OnPointerExit(PointerEventData eventData)
	{
		owz = false;
	}

	[Token(Token = "0x6000F14")]
	[Address(RVA = "0x42D210", Offset = "0x42C210", VA = "0x18042D210", Slot = "32")]
	public override void OnPointerDown(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F15")]
	[Address(RVA = "0x42CCD0", Offset = "0x42BCD0", VA = "0x18042CCD0", Slot = "39")]
	public void OnDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F16")]
	[Address(RVA = "0x42D410", Offset = "0x42C410", VA = "0x18042D410")]
	private void egt(ref float knobValue)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F17")]
	[Address(RVA = "0x42D500", Offset = "0x42C500", VA = "0x18042D500")]
	private void egu(float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F18")]
	[Address(RVA = "0x42D1F0", Offset = "0x42C1F0", VA = "0x18042D1F0", Slot = "41")]
	public virtual void OnInitializePotentialDrag(PointerEventData eventData)
	{
		eventData.useDragThreshold__BackingField = false;
	}

	[Token(Token = "0x6000F19")]
	[Address(RVA = "0x42D3A0", Offset = "0x42C3A0", VA = "0x18042D3A0")]
	public UI_Knob()
	{
		//IL_0009: Expected I4, but got I8
		//IL_0013: Expected I4, but got I8
	}
}
