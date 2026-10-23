using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityEngine.UI;

[Token(Token = "0x200017B")]
[AddComponentMenu("UI/Extensions/Extensions Toggle", 31)]
[RequireComponent(typeof(RectTransform))]
public class ExtensionsToggle : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICanvasElement
{
	[Token(Token = "0x200017C")]
	public enum nv
	{
		[Token(Token = "0x40018C1")]
		None,
		[Token(Token = "0x40018C2")]
		Fade
	}

	[Serializable]
	[Token(Token = "0x200017D")]
	public class ToggleEvent : UnityEvent<bool>
	{
		[Token(Token = "0x6000D64")]
		[Address(RVA = "0x2756B0", Offset = "0x2746B0", VA = "0x1802756B0")]
		public ToggleEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Serializable]
	[Token(Token = "0x200017E")]
	public class ToggleEventObject : UnityEvent<ExtensionsToggle>
	{
		[Token(Token = "0x6000D65")]
		[Address(RVA = "0x275670", Offset = "0x274670", VA = "0x180275670")]
		public ToggleEventObject()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x40018B9")]
	public string UniqueID;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40018BA")]
	public nv toggleTransition = nv.Fade;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40018BB")]
	public Graphic graphic;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40018BC")]
	[SerializeField]
	private ExtensionsToggleGroup m_Group;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40018BD")]
	[Tooltip("Use this event if you only need the bool state of the toggle that was changed")]
	public ToggleEvent onValueChanged = new ToggleEvent();

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40018BE")]
	[Tooltip("Use this event if you need access to the toggle that was changed")]
	public ToggleEventObject onToggleChanged = new ToggleEventObject();

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40018BF")]
	[SerializeField]
	[FormerlySerializedAs("m_IsActive")]
	[Tooltip("Is the toggle currently on or off?")]
	private bool m_IsOn;

	[Token(Token = "0x1700001C")]
	public ExtensionsToggleGroup ppf
	{
		[Token(Token = "0x6000D50")]
		[Address(RVA = "0x24DC70", Offset = "0x24CC70", VA = "0x18024DC70")]
		get
		{
			return m_Group;
		}
		[Token(Token = "0x6000D51")]
		[Address(RVA = "0x6A23C0", Offset = "0x6A13C0", VA = "0x1806A23C0")]
		set
		{
			m_Group = value;
			dvv(value, setMemberValue: true);
			dwa(instant: true);
		}
	}

	[Token(Token = "0x1700001D")]
	public bool ppg
	{
		[Token(Token = "0x6000D5A")]
		[Address(RVA = "0x6A2770", Offset = "0x6A1770", VA = "0x1806A2770")]
		get
		{
			return m_IsOn;
		}
		[Token(Token = "0x6000D5B")]
		[Address(RVA = "0x6A2780", Offset = "0x6A1780", VA = "0x1806A2780")]
		set
		{
			dvy(value);
		}
	}

	[Token(Token = "0x6000D52")]
	[Address(RVA = "0x6A2300", Offset = "0x6A1300", VA = "0x1806A2300")]
	protected ExtensionsToggle()
	{
		//IL_0009: Expected I4, but got I8
	}

	[Token(Token = "0x6000D53")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "46")]
	public virtual void Rebuild(CanvasUpdate executing)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D54")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "47")]
	public virtual void LayoutComplete()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D55")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "48")]
	public virtual void GraphicUpdateComplete()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D56")]
	[Address(RVA = "0x6A21E0", Offset = "0x6A11E0", VA = "0x1806A21E0", Slot = "5")]
	protected override void OnEnable()
	{
		base.OnEnable();
		ExtensionsToggleGroup newGroup = m_Group;
		int setMemberValue = 0;
		dvv(newGroup, (byte)setMemberValue != 0);
		dwa(instant: true);
	}

	[Token(Token = "0x6000D57")]
	[Address(RVA = "0x6A21B0", Offset = "0x6A11B0", VA = "0x1806A21B0", Slot = "7")]
	protected override void OnDisable()
	{
		//IL_000c: Expected Obj, but got I4
		int setMemberValue = 0;
		int num = 0;
		dvv((ExtensionsToggleGroup)num, (byte)setMemberValue != 0);
		base.OnDisable();
	}

	[Token(Token = "0x6000D58")]
	[Address(RVA = "0x6A20D0", Offset = "0x6A10D0", VA = "0x1806A20D0", Slot = "13")]
	protected override void OnDidApplyAnimationProperties()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D59")]
	[Address(RVA = "0x6A23F0", Offset = "0x6A13F0", VA = "0x1806A23F0")]
	private void dvv(ExtensionsToggleGroup newGroup, bool setMemberValue)
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0026: Expected VT, but got Obj
		//IL_0074: Expected Obj, but got I4
		//IL_0035: Expected VT, but got Obj
		//IL_00d0: Expected Obj, but got I4
		//IL_0095: Expected VT, but got Obj
		//IL_00a5: Expected VT, but got Obj
		ExtensionsToggleGroup extensionsToggleGroup = m_Group;
		int num = 0;
		if (extensionsToggleGroup != (Object)num)
		{
			ExtensionsToggleGroup extensionsToggleGroup2 = m_Group;
			if (((List<T>)(object)extensionsToggleGroup2.opl).Contains((T)this))
			{
				bool flag = ((List<T>)(object)extensionsToggleGroup2.opl).Remove((T)this);
				ToggleEvent toggleEvent = onValueChanged;
				UnityAction<bool> unityAction = (UnityAction<bool>)(object)new UnityAction<T0>(extensionsToggleGroup2.dwm);
				((UnityEvent<T0>)(object)toggleEvent).RemoveListener((UnityAction<>)(object)unityAction);
			}
		}
		if (setMemberValue)
		{
			m_Group = newGroup;
		}
		ExtensionsToggleGroup extensionsToggleGroup3 = m_Group;
		int num2 = 0;
		if (extensionsToggleGroup3 != (Object)num2 && IsActive())
		{
			ExtensionsToggleGroup extensionsToggleGroup4 = m_Group;
			if (!((List<T>)(object)extensionsToggleGroup4.opl).Contains((T)this))
			{
				((List<T>)(object)extensionsToggleGroup4.opl).Add((T)this);
				ToggleEvent toggleEvent2 = onValueChanged;
				UnityAction<bool> unityAction2 = (UnityAction<bool>)(object)new UnityAction<T0>(extensionsToggleGroup4.dwm);
				((UnityEvent<T0>)(object)toggleEvent2).AddListener((UnityAction<>)(object)unityAction2);
			}
		}
		int num3 = 0;
		if (newGroup != (Object)num3 && newGroup != extensionsToggleGroup && m_IsOn && IsActive())
		{
			m_Group.dwk(this);
		}
	}

	[Token(Token = "0x6000D5C")]
	[Address(RVA = "0x6A2790", Offset = "0x6A1790", VA = "0x1806A2790")]
	private void dvy(bool value)
	{
		//IL_0023: Expected Obj, but got I4
		//IL_0093: Expected VT, but got I4
		//IL_009f: Expected VT, but got Obj
		if (m_IsOn != value)
		{
			m_IsOn = value;
			ExtensionsToggleGroup extensionsToggleGroup = m_Group;
			int num = 0;
			if (extensionsToggleGroup != (Object)num && IsActive() && (m_IsOn || (!m_Group.dwo() && !m_Group.m_AllowSwitchOff)))
			{
				ExtensionsToggleGroup extensionsToggleGroup2 = m_Group;
				m_IsOn = true;
				extensionsToggleGroup2.dwk(this);
			}
			bool instant = toggleTransition == nv.None;
			dwa(instant);
			ToggleEvent toggleEvent = onValueChanged;
			bool isOn = m_IsOn;
			((UnityEvent<T0>)(object)toggleEvent).Invoke((T0)isOn);
			((UnityEvent<T0>)(object)onToggleChanged).Invoke((T0)this);
		}
	}

	[Token(Token = "0x6000D5D")]
	[Address(RVA = "0x6A28F0", Offset = "0x6A18F0", VA = "0x1806A28F0")]
	private void dvz(bool value, bool sendCallback)
	{
		//IL_0023: Expected Obj, but got I4
		//IL_0097: Expected VT, but got I4
		//IL_00a3: Expected VT, but got Obj
		if (m_IsOn != value)
		{
			m_IsOn = value;
			ExtensionsToggleGroup extensionsToggleGroup = m_Group;
			int num = 0;
			if (extensionsToggleGroup != (Object)num && IsActive() && (m_IsOn || (!m_Group.dwo() && !m_Group.m_AllowSwitchOff)))
			{
				ExtensionsToggleGroup extensionsToggleGroup2 = m_Group;
				m_IsOn = true;
				extensionsToggleGroup2.dwk(this);
			}
			bool instant = toggleTransition == nv.None;
			dwa(instant);
			if (sendCallback)
			{
				ToggleEvent toggleEvent = onValueChanged;
				bool isOn = m_IsOn;
				((UnityEvent<T0>)(object)toggleEvent).Invoke((T0)isOn);
				((UnityEvent<T0>)(object)onToggleChanged).Invoke((T0)this);
			}
		}
	}

	[Token(Token = "0x6000D5E")]
	[Address(RVA = "0x6A2A60", Offset = "0x6A1A60", VA = "0x1806A2A60")]
	private void dwa(bool instant)
	{
		//IL_0010: Expected Obj, but got I4
		//IL_003a: Expected F4, but got I4
		Graphic graphic = this.graphic;
		int num = 0;
		bool flag = graphic == (Object)num;
		if (!flag)
		{
			Graphic graphic2 = this.graphic;
			if (m_IsOn != flag)
			{
			}
			int num2 = 0;
			if (!instant)
			{
			}
			graphic2.CrossFadeAlpha(num2, 0.1f, ignoreTimeScale: true);
		}
	}

	[Token(Token = "0x6000D5F")]
	[Address(RVA = "0x6A22F0", Offset = "0x6A12F0", VA = "0x1806A22F0", Slot = "6")]
	protected override void Start()
	{
		dwa(instant: true);
	}

	[Token(Token = "0x6000D60")]
	[Address(RVA = "0x6A2290", Offset = "0x6A1290", VA = "0x1806A2290")]
	private void dwb()
	{
		if (IsActive() && IsInteractable())
		{
			bool value = !m_IsOn;
			dvy(value);
		}
	}

	[Token(Token = "0x6000D61")]
	[Address(RVA = "0x6A2220", Offset = "0x6A1220", VA = "0x1806A2220", Slot = "49")]
	public virtual void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button__BackingField == PointerEventData.InputButton.Left && IsActive() && IsInteractable())
		{
			bool value = !m_IsOn;
			dvy(value);
		}
	}

	[Token(Token = "0x6000D62")]
	[Address(RVA = "0x6A2290", Offset = "0x6A1290", VA = "0x1806A2290", Slot = "50")]
	public virtual void OnSubmit(BaseEventData eventData)
	{
		if (IsActive() && IsInteractable())
		{
			bool value = !m_IsOn;
			dvy(value);
		}
	}

	[SpecialName]
	[Token(Token = "0x6000D63")]
	[Address(RVA = "0x602040", Offset = "0x601040", VA = "0x180602040", Slot = "42")]
	private Transform dwc()
	{
		return transform;
	}
}
