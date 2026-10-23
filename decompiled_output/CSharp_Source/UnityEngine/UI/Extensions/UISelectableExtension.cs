using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200024F")]
[AddComponentMenu("UI/Extensions/UI Selectable Extension")]
[RequireComponent(typeof(Selectable))]
public class UISelectableExtension : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[Serializable]
	[Token(Token = "0x2000250")]
	public class UIButtonEvent : UnityEvent<PointerEventData.InputButton>
	{
		[Token(Token = "0x60012D7")]
		[Address(RVA = "0x275D00", Offset = "0x274D00", VA = "0x180275D00")]
		public UIButtonEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CEE")]
	[Tooltip("Event that fires when a button is initially pressed down")]
	public UIButtonEvent OnButtonPress;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CEF")]
	[Tooltip("Event that fires when a button is released")]
	public UIButtonEvent OnButtonRelease;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001CF0")]
	[Tooltip("Event that continually fires while a button is held down")]
	public UIButtonEvent OnButtonHeld;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001CF1")]
	private bool pjp;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001CF2")]
	private PointerEventData pjq;

	[Token(Token = "0x60012CE")]
	[Address(RVA = "0x429AE0", Offset = "0x428AE0", VA = "0x180429AE0", Slot = "4")]
	private void fdg(PointerEventData eventData)
	{
		//IL_0019: Expected VT, but got I4
		UIButtonEvent onButtonPress = OnButtonPress;
		if (onButtonPress != null)
		{
			PointerEventData.InputButton inputButton = eventData.button__BackingField;
			((UnityEvent<T0>)(object)onButtonPress).Invoke((T0)inputButton);
		}
		pjp = true;
		pjq = eventData;
	}

	[Token(Token = "0x60012CF")]
	[Address(RVA = "0x429B50", Offset = "0x428B50", VA = "0x180429B50", Slot = "5")]
	private void fdh(PointerEventData eventData)
	{
		//IL_0029: Expected Obj, but got I8
		//IL_0019: Expected VT, but got I4
		UIButtonEvent onButtonRelease = OnButtonRelease;
		if (onButtonRelease != null)
		{
			PointerEventData.InputButton inputButton = eventData.button__BackingField;
			((UnityEvent<T0>)(object)onButtonRelease).Invoke((T0)inputButton);
		}
		pjp = false;
		pjq = (PointerEventData)0;
	}

	[Token(Token = "0x60012D0")]
	[Address(RVA = "0x429A80", Offset = "0x428A80", VA = "0x180429A80")]
	private void Update()
	{
		//IL_0027: Expected VT, but got I4
		if (pjp)
		{
			UIButtonEvent onButtonHeld = OnButtonHeld;
			if (onButtonHeld != null)
			{
				PointerEventData.InputButton inputButton = pjq.button__BackingField;
				((UnityEvent<T0>)(object)onButtonHeld).Invoke((T0)inputButton);
			}
		}
	}

	[Token(Token = "0x60012D1")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void fdi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012D2")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void fdj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012D3")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void fdk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012D4")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void fdl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012D5")]
	[Address(RVA = "0x429A70", Offset = "0x428A70", VA = "0x180429A70")]
	private void OnDisable()
	{
		pjp = false;
	}

	[Token(Token = "0x60012D6")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UISelectableExtension()
	{
	}
}
