using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000249")]
[AddComponentMenu("UI/Extensions/UI Highlightable Extension")]
[RequireComponent(typeof(RectTransform), typeof(Graphic))]
public class UIHighlightable : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	[Serializable]
	[Token(Token = "0x200024A")]
	public class InteractableChangedEvent : UnityEvent<bool>
	{
		[Token(Token = "0x60012AB")]
		[Address(RVA = "0x274210", Offset = "0x273210", VA = "0x180274210")]
		public InteractableChangedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CCC")]
	private Graphic piz;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CCD")]
	private bool pja;

	[FieldOffset(Offset = "0x21")]
	[Token(Token = "0x4001CCE")]
	private bool pjb;

	[FieldOffset(Offset = "0x22")]
	[Token(Token = "0x4001CCF")]
	[SerializeField]
	[Tooltip("Can this panel be interacted with or is it disabled? (does not affect child components)")]
	private bool m_Interactable;

	[FieldOffset(Offset = "0x23")]
	[Token(Token = "0x4001CD0")]
	[SerializeField]
	[Tooltip("Does the panel remain in the pressed state when clicked? (default false)")]
	private bool m_ClickToHold;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001CD1")]
	[Tooltip("The default color for the panel")]
	public Color NormalColor;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001CD2")]
	[Tooltip("The color for the panel when a mouse is over it or it is in focus")]
	public Color HighlightedColor;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001CD3")]
	[Tooltip("The color for the panel when it is clicked/held")]
	public Color PressedColor;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001CD4")]
	[Tooltip("The color for the panel when it is not interactable (see Interactable)")]
	public Color DisabledColor;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001CD5")]
	[Tooltip("Event for when the panel is enabled / disabled, to enable disabling / enabling of child or other gameobjects")]
	public InteractableChangedEvent OnInteractableChanged;

	[Token(Token = "0x1700010D")]
	public bool pxo
	{
		[Token(Token = "0x60012A0")]
		[Address(RVA = "0x87C550", Offset = "0x87B550", VA = "0x18087C550")]
		get
		{
			return m_Interactable;
		}
		[Token(Token = "0x60012A1")]
		[Address(RVA = "0x87C560", Offset = "0x87B560", VA = "0x18087C560")]
		set
		{
			//IL_003e: Expected VT, but got I4
			Graphic graphic = piz;
			m_Interactable = value;
			if (!value)
			{
			}
			if (!pja)
			{
			}
			Color highlightedColor = HighlightedColor;
			graphic.color = highlightedColor;
			InteractableChangedEvent onInteractableChanged = OnInteractableChanged;
			bool interactable = m_Interactable;
			((UnityEvent<T0>)(object)onInteractableChanged).Invoke((T0)interactable);
		}
	}

	[Token(Token = "0x1700010E")]
	public bool pxp
	{
		[Token(Token = "0x60012A2")]
		[Address(RVA = "0x87C610", Offset = "0x87B610", VA = "0x18087C610")]
		get
		{
			return m_ClickToHold;
		}
		[Token(Token = "0x60012A3")]
		[Address(RVA = "0x87C620", Offset = "0x87B620", VA = "0x18087C620")]
		set
		{
			m_ClickToHold = value;
		}
	}

	[Token(Token = "0x60012A4")]
	[Address(RVA = "0x87C330", Offset = "0x87B330", VA = "0x18087C330")]
	private void Awake()
	{
		Graphic component = GetComponent<Graphic>();
		piz = component;
	}

	[Token(Token = "0x60012A5")]
	[Address(RVA = "0x87C3D0", Offset = "0x87B3D0", VA = "0x18087C3D0", Slot = "4")]
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (m_Interactable && !pjb)
		{
			Graphic graphic = piz;
			pja = true;
			Color highlightedColor = HighlightedColor;
			graphic.color = highlightedColor;
		}
	}

	[Token(Token = "0x60012A6")]
	[Address(RVA = "0x87C420", Offset = "0x87B420", VA = "0x18087C420", Slot = "5")]
	public void OnPointerExit(PointerEventData eventData)
	{
		if (m_Interactable && !pjb)
		{
			Graphic graphic = piz;
			pja = false;
			Color normalColor = NormalColor;
			graphic.color = normalColor;
		}
	}

	[Token(Token = "0x60012A7")]
	[Address(RVA = "0x87C370", Offset = "0x87B370", VA = "0x18087C370", Slot = "6")]
	public void OnPointerDown(PointerEventData eventData)
	{
		if (m_Interactable)
		{
			Graphic graphic = piz;
			Color pressedColor = PressedColor;
			graphic.color = pressedColor;
			if (m_ClickToHold)
			{
				bool flag = !pjb;
				pjb = flag;
			}
		}
	}

	[Token(Token = "0x60012A8")]
	[Address(RVA = "0x87C470", Offset = "0x87B470", VA = "0x18087C470", Slot = "7")]
	public void OnPointerUp(PointerEventData eventData)
	{
		if (!pjb)
		{
			Graphic graphic = piz;
			if (!m_Interactable)
			{
			}
			if (!pja)
			{
			}
			Color highlightedColor = HighlightedColor;
			graphic.color = highlightedColor;
		}
	}

	[Token(Token = "0x60012A9")]
	[Address(RVA = "0x87C630", Offset = "0x87B630", VA = "0x18087C630")]
	private void fch(Graphic graphic)
	{
		if (!m_Interactable)
		{
		}
		if (!pja)
		{
		}
		Color highlightedColor = HighlightedColor;
		graphic.color = highlightedColor;
	}

	[Token(Token = "0x60012AA")]
	[Address(RVA = "0x87C4E0", Offset = "0x87B4E0", VA = "0x18087C4E0")]
	public UIHighlightable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
