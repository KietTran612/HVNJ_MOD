using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001AA")]
[AddComponentMenu("UI/Extensions/RescalePanels/ResizePanel")]
public class ResizePanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40019BA")]
	public Vector2 minSize;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40019BB")]
	public Vector2 maxSize;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40019BC")]
	private RectTransform @out;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40019BD")]
	private Vector2 ouu;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40019BE")]
	private Vector2 ouv;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40019BF")]
	private float ouw;

	[Token(Token = "0x6000E69")]
	[Address(RVA = "0x4504E0", Offset = "0x44F4E0", VA = "0x1804504E0")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E6A")]
	[Address(RVA = "0x4507B0", Offset = "0x44F7B0", VA = "0x1804507B0", Slot = "4")]
	public void OnPointerDown(PointerEventData data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E6B")]
	[Address(RVA = "0x450600", Offset = "0x44F600", VA = "0x180450600", Slot = "5")]
	public void OnDrag(PointerEventData data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E6C")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ResizePanel()
	{
	}
}
