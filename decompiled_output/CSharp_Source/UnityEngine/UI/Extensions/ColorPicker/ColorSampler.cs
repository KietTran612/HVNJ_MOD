using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x200025F")]
public class ColorSampler : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D4C")]
	private Vector2 plo;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D4D")]
	[SerializeField]
	protected Button sampler;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D4E")]
	private RectTransform plp;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D4F")]
	[SerializeField]
	protected Outline samplerOutline;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001D50")]
	protected Texture2D plq;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001D51")]
	public ColorChangedEvent oncolorSelected = new ColorChangedEvent();

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001D52")]
	protected Color plr;

	[Token(Token = "0x6001331")]
	[Address(RVA = "0x6103A0", Offset = "0x60F3A0", VA = "0x1806103A0", Slot = "7")]
	protected virtual void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001332")]
	[Address(RVA = "0x610280", Offset = "0x60F280", VA = "0x180610280", Slot = "8")]
	protected virtual void OnDisable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001333")]
	[Address(RVA = "0x6104D0", Offset = "0x60F4D0", VA = "0x1806104D0", Slot = "9")]
	protected virtual void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001334")]
	[Address(RVA = "0x610640", Offset = "0x60F640", VA = "0x180610640", Slot = "10")]
	protected virtual void ffn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001335")]
	[Address(RVA = "0x6107D0", Offset = "0x60F7D0", VA = "0x1806107D0", Slot = "11")]
	protected virtual void ffo()
	{
		ColorChangedEvent colorChangedEvent = oncolorSelected;
		if (colorChangedEvent != null)
		{
			Color arg = plr;
			((UnityEvent<T0>)(object)colorChangedEvent).Invoke((T0)arg);
		}
		int num = 0;
		enabled = (byte)num != 0;
	}

	[Token(Token = "0x6001336")]
	[Address(RVA = "0x610370", Offset = "0x60F370", VA = "0x180610370", Slot = "4")]
	public unsafe void OnPointerDown(PointerEventData eventData)
	{
		//IL_0021: Expected native int or pointer, but got VT
		Vector2 vector = eventData.position__BackingField;
		float y = eventData.position__BackingField.y;
		plo = vector;
		((Vector2*)(nint)plo)->y = y;
	}

	[Token(Token = "0x6001337")]
	[Address(RVA = "0x610490", Offset = "0x60F490", VA = "0x180610490", Slot = "5")]
	public unsafe void OnPointerUp(PointerEventData eventData)
	{
		//IL_001b: Expected F4, but got I4
		//IL_0016: Expected native int or pointer, but got VT
		int num = 0;
		Vector2 zero = Vector2.zero;
		plo = zero;
		((Vector2*)(nint)plo)->y = 0f;
	}

	[Token(Token = "0x6001338")]
	[Address(RVA = "0x610370", Offset = "0x60F370", VA = "0x180610370", Slot = "6")]
	public unsafe void OnDrag(PointerEventData eventData)
	{
		//IL_0021: Expected native int or pointer, but got VT
		Vector2 vector = eventData.position__BackingField;
		float y = eventData.position__BackingField.y;
		plo = vector;
		((Vector2*)(nint)plo)->y = y;
	}

	[Token(Token = "0x6001339")]
	[Address(RVA = "0x6105C0", Offset = "0x60F5C0", VA = "0x1806105C0")]
	public ColorSampler()
	{
	}
}
