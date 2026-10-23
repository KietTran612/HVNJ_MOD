using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001A9")]
[AddComponentMenu("UI/Extensions/RescalePanels/RescalePanel")]
public class RescalePanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40019B2")]
	public Vector2 minSize;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40019B3")]
	public Vector2 maxSize;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40019B4")]
	private RectTransform oun;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40019B5")]
	private Transform ouo;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40019B6")]
	private Vector2 oup;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40019B7")]
	private Vector2 ouq;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40019B8")]
	private RectTransform our;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40019B9")]
	private Vector2 ous;

	[Token(Token = "0x6000E65")]
	[Address(RVA = "0x450120", Offset = "0x44F120", VA = "0x180450120")]
	private unsafe void Awake()
	{
		//IL_0053: Expected F4, but got I4
		//IL_004e: Expected native int or pointer, but got VT
		RectTransform component = transform.parent.GetComponent<RectTransform>();
		oun = component;
		Transform parent = transform.parent;
		ouo = parent;
		Vector2 sizeDelta = (our = GetComponent<RectTransform>()).sizeDelta;
		ous = sizeDelta;
		((Vector2*)(nint)ous)->y = 0f;
	}

	[Token(Token = "0x6000E66")]
	[Address(RVA = "0x450400", Offset = "0x44F400", VA = "0x180450400", Slot = "4")]
	public void OnPointerDown(PointerEventData data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E67")]
	[Address(RVA = "0x4501E0", Offset = "0x44F1E0", VA = "0x1804501E0", Slot = "5")]
	public void OnDrag(PointerEventData data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E68")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public RescalePanel()
	{
	}
}
