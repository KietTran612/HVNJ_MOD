using System;
using Cpp2IlInjected;
using UnityEngine.Events;
using UnityEngine.UI.Extensions.Tweens;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000185")]
[RequireComponent(typeof(RectTransform), typeof(LayoutElement))]
[AddComponentMenu("UI/Extensions/Accordion/Accordion Element")]
public class AccordionElement : Toggle
{
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40018D4")]
	[SerializeField]
	private float m_MinHeight = 18f;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40018D5")]
	private Accordion opp;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40018D6")]
	private RectTransform opq;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40018D7")]
	private LayoutElement opr;

	[NonSerialized]
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40018D8")]
	private readonly qr<FloatTween> ops;

	[Token(Token = "0x6000D83")]
	[Address(RVA = "0x5FCC60", Offset = "0x5FBC60", VA = "0x1805FCC60")]
	protected AccordionElement()
	{
		qr<FloatTween> qr2 = ops;
		if (qr2 == null)
		{
			qr<FloatTween> qr3 = (qr<FloatTween>)(object)new qr<T>();
			ops = qr3;
		}
		((qr<>)(object)qr2).pml = this;
	}

	[Token(Token = "0x6000D84")]
	[Address(RVA = "0x5FCAF0", Offset = "0x5FBAF0", VA = "0x1805FCAF0", Slot = "4")]
	protected override void Awake()
	{
		//IL_003b: Expected Obj, but got I4
		base.Awake();
		int num = 0;
		transition = (Transition)num;
		int num2 = (int)(toggleTransition = ToggleTransition.None);
		Accordion componentInParent = gameObject.GetComponentInParent<Accordion>();
		opp = componentInParent;
		if ((object)transform != null)
		{
		}
		opq = (RectTransform)num2;
		LayoutElement component = gameObject.GetComponent<LayoutElement>();
		ToggleEvent toggleEvent = onValueChanged;
		opr = component;
		UnityAction<bool> unityAction = (UnityAction<bool>)(object)new UnityAction<T0>(dwx);
		((UnityEvent<T0>)(object)toggleEvent).AddListener((UnityAction<>)(object)unityAction);
	}

	[Token(Token = "0x6000D85")]
	[Address(RVA = "0x5FCD00", Offset = "0x5FBD00", VA = "0x1805FCD00")]
	public void dwx(bool state)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D86")]
	[Address(RVA = "0x5FCFA0", Offset = "0x5FBFA0", VA = "0x1805FCFA0")]
	protected float dwy()
	{
		//IL_0010: Expected Obj, but got I4
		LayoutElement layoutElement = opr;
		int num = 0;
		if (!(layoutElement == (Object)num))
		{
			float preferredHeight = opr.preferredHeight;
			opr.preferredHeight = -1f;
			float preferredHeight2 = LayoutUtility.GetPreferredHeight(opq);
			opr.preferredHeight = preferredHeight;
			return preferredHeight2;
		}
		return m_MinHeight;
	}

	[Token(Token = "0x6000D87")]
	[Address(RVA = "0x5FD0C0", Offset = "0x5FC0C0", VA = "0x1805FD0C0")]
	protected void dwz(float startFloat, float targetFloat)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D88")]
	[Address(RVA = "0x5FD260", Offset = "0x5FC260", VA = "0x1805FD260")]
	protected void dxa(float height)
	{
		//IL_0010: Expected Obj, but got I4
		LayoutElement layoutElement = opr;
		int num = 0;
		if (!(layoutElement == (Object)num))
		{
			opr.preferredHeight = height;
		}
	}
}
