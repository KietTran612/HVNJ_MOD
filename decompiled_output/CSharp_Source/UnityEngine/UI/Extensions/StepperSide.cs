using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001B7")]
[RequireComponent(typeof(Selectable))]
public class StepperSide : UIBehaviour, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40019EB")]
	internal Sprite ovz;

	[Token(Token = "0x1700006F")]
	private Selectable psc
	{
		[Token(Token = "0x6000EE8")]
		[Address(RVA = "0x48C5A0", Offset = "0x48B5A0", VA = "0x18048C5A0")]
		get
		{
			return GetComponent<Selectable>();
		}
	}

	[Token(Token = "0x17000070")]
	private Stepper psd
	{
		[Token(Token = "0x6000EE9")]
		[Address(RVA = "0x48C5E0", Offset = "0x48B5E0", VA = "0x18048C5E0")]
		get
		{
			return GetComponentInParent<Stepper>();
		}
	}

	[Token(Token = "0x17000071")]
	private bool pse
	{
		[Token(Token = "0x6000EEA")]
		[Address(RVA = "0x48C620", Offset = "0x48B620", VA = "0x18048C620")]
		get
		{
			Selectable component = GetComponent<Selectable>();
			Selectable selectable = GetComponentInParent<Stepper>().pru[0];
			return component == selectable;
		}
	}

	[Token(Token = "0x6000EEB")]
	[Address(RVA = "0x3EA200", Offset = "0x3E9200", VA = "0x1803EA200")]
	protected StepperSide()
	{
	}

	[Token(Token = "0x6000EEC")]
	[Address(RVA = "0x48C520", Offset = "0x48B520", VA = "0x18048C520", Slot = "25")]
	public virtual void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button__BackingField == PointerEventData.InputButton.Left)
		{
			egh();
			int restore = 0;
			egi((byte)restore != 0);
		}
	}

	[Token(Token = "0x6000EED")]
	[Address(RVA = "0x48C570", Offset = "0x48B570", VA = "0x18048C570", Slot = "26")]
	public virtual void OnSubmit(BaseEventData eventData)
	{
		egh();
		egi(restore: true);
	}

	[Token(Token = "0x6000EEE")]
	[Address(RVA = "0x48C560", Offset = "0x48B560", VA = "0x18048C560", Slot = "27")]
	public virtual void OnPointerEnter(PointerEventData eventData)
	{
		int restore = 0;
		egi((byte)restore != 0);
	}

	[Token(Token = "0x6000EEF")]
	[Address(RVA = "0x48C510", Offset = "0x48B510", VA = "0x18048C510", Slot = "28")]
	public virtual void OnPointerExit(PointerEventData eventData)
	{
		egi(restore: true);
	}

	[Token(Token = "0x6000EF0")]
	[Address(RVA = "0x48C560", Offset = "0x48B560", VA = "0x18048C560", Slot = "29")]
	public virtual void OnPointerDown(PointerEventData eventData)
	{
		int restore = 0;
		egi((byte)restore != 0);
	}

	[Token(Token = "0x6000EF1")]
	[Address(RVA = "0x48C560", Offset = "0x48B560", VA = "0x18048C560", Slot = "30")]
	public virtual void OnPointerUp(PointerEventData eventData)
	{
		int restore = 0;
		egi((byte)restore != 0);
	}

	[Token(Token = "0x6000EF2")]
	[Address(RVA = "0x48C560", Offset = "0x48B560", VA = "0x18048C560", Slot = "31")]
	public virtual void OnSelect(BaseEventData eventData)
	{
		int restore = 0;
		egi((byte)restore != 0);
	}

	[Token(Token = "0x6000EF3")]
	[Address(RVA = "0x48C510", Offset = "0x48B510", VA = "0x18048C510", Slot = "32")]
	public virtual void OnDeselect(BaseEventData eventData)
	{
		egi(restore: true);
	}

	[Token(Token = "0x6000EF4")]
	[Address(RVA = "0x48C710", Offset = "0x48B710", VA = "0x18048C710")]
	private void egh()
	{
		if (GetComponent<Selectable>().IsActive() && GetComponent<Selectable>().IsInteractable())
		{
			if (!pse)
			{
				Stepper componentInParent = GetComponentInParent<Stepper>();
				int step = componentInParent._step;
				componentInParent.efz(step);
			}
			else
			{
				Stepper componentInParent2 = GetComponentInParent<Stepper>();
				int step2 = componentInParent2._step;
				componentInParent2.efz(step2);
			}
		}
	}

	[Token(Token = "0x6000EF5")]
	[Address(RVA = "0x48C860", Offset = "0x48B860", VA = "0x18048C860")]
	private void egi(bool restore)
	{
		Image image = GetComponent<Selectable>().image;
		if (!image)
		{
			return;
		}
		Sprite overrideSprite = image.overrideSprite;
		Sprite sprite = ovz;
		if (!(overrideSprite == sprite))
		{
			if (restore)
			{
				throw new NullReferenceException();
			}
			Sprite overrideSprite2 = image.overrideSprite;
			bool leftmost = pse;
			Sprite overrideSprite3 = Stepper.egc(overrideSprite2, leftmost);
			image.overrideSprite = overrideSprite3;
		}
	}
}
