using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200019D")]
[AddComponentMenu("UI/Extensions/MultiTouchScrollRect")]
public class MultiTouchScrollRect : ScrollRect
{
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4001965")]
	private int osu = -100;

	[Token(Token = "0x6000E1D")]
	[Address(RVA = "0x4470A0", Offset = "0x4460A0", VA = "0x1804470A0", Slot = "44")]
	public override void OnBeginDrag(PointerEventData eventData)
	{
		int num = eventData.pointerId__BackingField;
		osu = num;
		base.OnBeginDrag(eventData);
	}

	[Token(Token = "0x6000E1E")]
	[Address(RVA = "0x4470D0", Offset = "0x4460D0", VA = "0x1804470D0", Slot = "46")]
	public override void OnDrag(PointerEventData eventData)
	{
		int num = eventData.pointerId__BackingField;
		if (osu == num)
		{
			base.OnDrag(eventData);
		}
	}

	[Token(Token = "0x6000E1F")]
	[Address(RVA = "0x447100", Offset = "0x446100", VA = "0x180447100", Slot = "45")]
	public override void OnEndDrag(PointerEventData eventData)
	{
		//IL_0010: Expected I4, but got I8
		osu = -100;
		base.OnEndDrag(eventData);
	}

	[Token(Token = "0x6000E20")]
	[Address(RVA = "0x447120", Offset = "0x446120", VA = "0x180447120")]
	public MultiTouchScrollRect()
	{
		//IL_0010: Expected I4, but got I8
	}
}
