using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Token(Token = "0x20000C5")]
public class ScrollRectClick : ScrollRect
{
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4000B23")]
	public bool isScroll;

	[Token(Token = "0x60005B1")]
	[Address(RVA = "0x47F850", Offset = "0x47E850", VA = "0x18047F850", Slot = "44")]
	public override void OnBeginDrag(PointerEventData eventData)
	{
		isScroll = true;
		base.OnBeginDrag(eventData);
	}

	[Token(Token = "0x60005B2")]
	[Address(RVA = "0x47F860", Offset = "0x47E860", VA = "0x18047F860", Slot = "45")]
	public override void OnEndDrag(PointerEventData eventData)
	{
		isScroll = false;
		base.OnEndDrag(eventData);
	}

	[Token(Token = "0x60005B3")]
	[Address(RVA = "0x47F870", Offset = "0x47E870", VA = "0x18047F870")]
	public ScrollRectClick()
	{
	}
}
