using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001AB")]
[AddComponentMenu("UI/Extensions/Segmented Control/Segment")]
[RequireComponent(typeof(Selectable))]
public class Segment : UIBehaviour, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
{
	[Token(Token = "0x20001AC")]
	[CompilerGenerated]
	private sealed class og : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40019C3")]
		private int oux;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40019C4")]
		private object ouy;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40019C5")]
		public Segment ouz;

		[Token(Token = "0x17000055")]
		private object pra
		{
			[Token(Token = "0x6000E8A")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return ouy;
			}
		}

		[Token(Token = "0x17000056")]
		private object prb
		{
			[Token(Token = "0x6000E8C")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return ouy;
			}
		}

		[Token(Token = "0x6000E87")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public og(int _003C_003E1__state)
		{
			ect();
			oux = _003C_003E1__state;
		}

		[Token(Token = "0x6000E88")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void ect()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000E89")]
		[Address(RVA = "0x27B2F0", Offset = "0x27A2F0", VA = "0x18027B2F0", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000E8B")]
		[Address(RVA = "0x27B3A0", Offset = "0x27A3A0", VA = "0x18027B3A0", Slot = "8")]
		[DebuggerHidden]
		private void ecv()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40019C0")]
	internal int ova;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40019C1")]
	internal SegmentedControl ovb;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40019C2")]
	internal Sprite ovc;

	[Token(Token = "0x17000051")]
	internal bool prc
	{
		[Token(Token = "0x6000E6D")]
		[Address(RVA = "0x485D00", Offset = "0x484D00", VA = "0x180485D00")]
		get
		{
			return ova == 0;
		}
	}

	[Token(Token = "0x17000052")]
	internal bool prd
	{
		[Token(Token = "0x6000E6E")]
		[Address(RVA = "0x485D10", Offset = "0x484D10", VA = "0x180485D10")]
		get
		{
			int num = ova;
			int length = ovb.prj.Length;
			return num == length;
		}
	}

	[Token(Token = "0x17000053")]
	public bool pre
	{
		[Token(Token = "0x6000E6F")]
		[Address(RVA = "0x485D50", Offset = "0x484D50", VA = "0x180485D50")]
		get
		{
			Selectable ovi = ovb.ovi;
			Selectable component = GetComponent<Selectable>();
			return ovi == component;
		}
		[Token(Token = "0x6000E70")]
		[Address(RVA = "0x485E00", Offset = "0x484E00", VA = "0x180485E00")]
		set
		{
			edd(value);
		}
	}

	[Token(Token = "0x17000054")]
	internal Selectable prf
	{
		[Token(Token = "0x6000E71")]
		[Address(RVA = "0x485E10", Offset = "0x484E10", VA = "0x180485E10")]
		get
		{
			return GetComponent<Selectable>();
		}
	}

	[Token(Token = "0x6000E72")]
	[Address(RVA = "0x3EA200", Offset = "0x3E9200", VA = "0x1803EA200")]
	protected Segment()
	{
	}

	[Token(Token = "0x6000E73")]
	[Address(RVA = "0x485C90", Offset = "0x484C90", VA = "0x180485C90", Slot = "6")]
	protected override void Start()
	{
		int num = default;
		og og2 = new og(num);
		num = 0;
		og2.ouz = this;
		Coroutine coroutine = StartCoroutine(og2);
	}

	[Token(Token = "0x6000E74")]
	[Address(RVA = "0x485E50", Offset = "0x484E50", VA = "0x180485E50")]
	[IteratorStateMachine(typeof(og))]
	private IEnumerator edc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E75")]
	[Address(RVA = "0x485C50", Offset = "0x484C50", VA = "0x180485C50", Slot = "25")]
	public virtual void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button__BackingField == PointerEventData.InputButton.Left)
		{
			edd(value: true);
		}
	}

	[Token(Token = "0x6000E76")]
	[Address(RVA = "0x485BC0", Offset = "0x484BC0", VA = "0x180485BC0", Slot = "26")]
	public virtual void OnPointerEnter(PointerEventData eventData)
	{
		ede();
	}

	[Token(Token = "0x6000E77")]
	[Address(RVA = "0x485BC0", Offset = "0x484BC0", VA = "0x180485BC0", Slot = "27")]
	public virtual void OnPointerExit(PointerEventData eventData)
	{
		ede();
	}

	[Token(Token = "0x6000E78")]
	[Address(RVA = "0x485BC0", Offset = "0x484BC0", VA = "0x180485BC0", Slot = "28")]
	public virtual void OnPointerDown(PointerEventData eventData)
	{
		ede();
	}

	[Token(Token = "0x6000E79")]
	[Address(RVA = "0x485BC0", Offset = "0x484BC0", VA = "0x180485BC0", Slot = "29")]
	public virtual void OnPointerUp(PointerEventData eventData)
	{
		ede();
	}

	[Token(Token = "0x6000E7A")]
	[Address(RVA = "0x485BC0", Offset = "0x484BC0", VA = "0x180485BC0", Slot = "30")]
	public virtual void OnSelect(BaseEventData eventData)
	{
		ede();
	}

	[Token(Token = "0x6000E7B")]
	[Address(RVA = "0x485BC0", Offset = "0x484BC0", VA = "0x180485BC0", Slot = "31")]
	public virtual void OnDeselect(BaseEventData eventData)
	{
		ede();
	}

	[Token(Token = "0x6000E7C")]
	[Address(RVA = "0x485BD0", Offset = "0x484BD0", VA = "0x180485BD0", Slot = "5")]
	protected override void OnEnable()
	{
		((object)this)._002Ector();
		if ((bool)ovb)
		{
			ede();
		}
	}

	[Token(Token = "0x6000E7D")]
	[Address(RVA = "0x485C80", Offset = "0x484C80", VA = "0x180485C80", Slot = "32")]
	public virtual void OnSubmit(BaseEventData eventData)
	{
		edd(value: true);
	}

	[Token(Token = "0x6000E7E")]
	[Address(RVA = "0x485EC0", Offset = "0x484EC0", VA = "0x180485EC0")]
	private void edd(bool value)
	{
		//IL_00d8: Expected VT, but got I4
		//IL_0080: Expected Obj, but got I8
		Selectable ovi3;
		Selectable component3;
		do
		{
			if (value && GetComponent<Selectable>().IsActive() && GetComponent<Selectable>().IsInteractable())
			{
				Selectable ovi = ovb.ovi;
				Selectable component = GetComponent<Selectable>();
				bool flag = ovi == component;
				SegmentedControl segmentedControl = ovb;
				if (!flag)
				{
					if ((bool)segmentedControl.ovi)
					{
						Segment component2 = ovb.ovi.GetComponent<Segment>();
						ovb.ovi = (Selectable)0;
						if ((bool)component2)
						{
							int instant = 0;
							component2.edg((byte)instant != 0);
						}
					}
					SegmentedControl segmentedControl2 = ovb;
					Selectable ovi2 = prf;
					segmentedControl2.ovi = ovi2;
					int instant2 = 0;
					edg((byte)instant2 != 0);
					SegmentedControl.SegmentSelectedEvent onValueChanged = ovb.m_onValueChanged;
					int num = ova;
					((UnityEvent<T0>)(object)onValueChanged).Invoke((T0)num);
				}
				else
				{
					if (segmentedControl.m_allowSwitchingOff)
					{
						break;
					}
					ede();
				}
				return;
			}
			ovi3 = ovb.ovi;
			component3 = GetComponent<Selectable>();
		}
		while (!(ovi3 == component3));
		Deselect();
	}

	[Token(Token = "0x6000E7F")]
	[Address(RVA = "0x485B40", Offset = "0x484B40", VA = "0x180485B40")]
	private void Deselect()
	{
		//IL_000e: Expected Obj, but got I8
		//IL_0028: Expected VT, but got I4
		ovb.ovi = (Selectable)0;
		int instant = 0;
		edg((byte)instant != 0);
		((UnityEvent<T0>)(object)ovb.m_onValueChanged).Invoke((T0)(-1));
	}

	[Token(Token = "0x6000E80")]
	[Address(RVA = "0x486210", Offset = "0x485210", VA = "0x180486210")]
	private void ede()
	{
		Selectable component = GetComponent<Selectable>();
		Selectable ovi = ovb.ovi;
		if (!(component != ovi))
		{
			edg(instant: true);
		}
	}

	[Token(Token = "0x6000E81")]
	[Address(RVA = "0x4862D0", Offset = "0x4852D0", VA = "0x1804862D0")]
	internal void edf()
	{
		int instant = 0;
		edg((byte)instant != 0);
	}

	[Token(Token = "0x6000E82")]
	[Address(RVA = "0x4862E0", Offset = "0x4852E0", VA = "0x1804862E0")]
	internal void edg(bool instant)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E83")]
	[Address(RVA = "0x486A50", Offset = "0x485A50", VA = "0x180486A50")]
	private void edh(Color targetColor, bool instant)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E84")]
	[Address(RVA = "0x486BE0", Offset = "0x485BE0", VA = "0x180486BE0")]
	private void edi(Color targetColor)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E85")]
	[Address(RVA = "0x486C90", Offset = "0x485C90", VA = "0x180486C90")]
	private void edj(Sprite newSprite)
	{
		//IL_0015: Expected Obj, but got I4
		Image image = GetComponent<Selectable>().image;
		int num = 0;
		if (!(image == (Object)num))
		{
			GetComponent<Selectable>().image.overrideSprite = newSprite;
		}
	}

	[Token(Token = "0x6000E86")]
	[Address(RVA = "0x486DA0", Offset = "0x485DA0", VA = "0x180486DA0")]
	private void edk(string triggername)
	{
		//IL_0015: Expected Obj, but got I4
		Animator animator = GetComponent<Selectable>().animator;
		int num = 0;
		if (!(animator == (Object)num) && GetComponent<Selectable>().animator.isActiveAndEnabled && GetComponent<Selectable>().animator.hasBoundPlayables && !string.IsNullOrEmpty(triggername))
		{
			Animator animator2 = prf.animator;
			string normalTrigger = prf.m_AnimationTriggers.m_NormalTrigger;
			animator2.ResetTrigger(normalTrigger);
			Animator animator3 = prf.animator;
			string pressedTrigger = prf.m_AnimationTriggers.m_PressedTrigger;
			animator3.ResetTrigger(pressedTrigger);
			Animator animator4 = prf.animator;
			string highlightedTrigger = prf.m_AnimationTriggers.m_HighlightedTrigger;
			animator4.ResetTrigger(highlightedTrigger);
			Animator animator5 = prf.animator;
			string disabledTrigger = prf.m_AnimationTriggers.m_DisabledTrigger;
			animator5.ResetTrigger(disabledTrigger);
			prf.animator.SetTrigger(triggername);
		}
	}
}
