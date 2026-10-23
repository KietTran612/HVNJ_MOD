using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI;

[Token(Token = "0x2000182")]
[RequireComponent(typeof(InputField))]
[AddComponentMenu("UI/Extensions/Return Key Trigger")]
public class ReturnKeyTriggersButton : MonoBehaviour, ISubmitHandler, IEventSystemHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40018CB")]
	private EventSystem opn;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40018CC")]
	public Button button;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40018CD")]
	private bool opo = true;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x40018CE")]
	public float highlightDuration = 0.2f;

	[Token(Token = "0x6000D7A")]
	[Address(RVA = "0x450A30", Offset = "0x44FA30", VA = "0x180450A30")]
	private void Start()
	{
		int num = 0;
		EventSystem current = EventSystem.current;
		opn = current;
	}

	[Token(Token = "0x6000D7B")]
	[Address(RVA = "0x4509A0", Offset = "0x44F9A0", VA = "0x1804509A0")]
	private void RemoveHighlight()
	{
		Button button = this.button;
		PointerEventData pointerEventData = new PointerEventData(opn);
		TypeCode typeCode = ((IConvertible)button).GetTypeCode();
	}

	[Token(Token = "0x6000D7C")]
	[Address(RVA = "0x450890", Offset = "0x44F890", VA = "0x180450890", Slot = "4")]
	public void OnSubmit(BaseEventData eventData)
	{
		if (opo)
		{
			Button button = this.button;
			PointerEventData eventData2 = new PointerEventData(opn);
			button.OnPointerEnter(eventData2);
		}
		Button button2 = this.button;
		PointerEventData eventData3 = new PointerEventData(opn);
		button2.OnPointerClick(eventData3);
		if (opo)
		{
			float time = highlightDuration;
			Invoke("RemoveHighlight", time);
		}
	}

	[Token(Token = "0x6000D7D")]
	[Address(RVA = "0x450A90", Offset = "0x44FA90", VA = "0x180450A90")]
	public ReturnKeyTriggersButton()
	{
	}
}
