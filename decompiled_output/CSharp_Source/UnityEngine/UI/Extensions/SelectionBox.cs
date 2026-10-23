using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001B2")]
[RequireComponent(typeof(Canvas))]
[AddComponentMenu("UI/Extensions/Selection Box")]
public class SelectionBox : MonoBehaviour
{
	[Token(Token = "0x20001B3")]
	public class SelectionEvent : UnityEvent<oi[]>
	{
		[Token(Token = "0x6000EC4")]
		[Address(RVA = "0x2754F0", Offset = "0x2744F0", VA = "0x1802754F0")]
		public SelectionEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40019D5")]
	public Color color;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40019D6")]
	public Sprite art;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40019D7")]
	private Vector2 ovo;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40019D8")]
	public RectTransform selectionMask;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40019D9")]
	private RectTransform ovp;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40019DA")]
	private oi[] ovq;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40019DB")]
	private MonoBehaviour[] ovr;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40019DC")]
	private oi ovs;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40019DD")]
	private oi ovt;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40019DE")]
	public SelectionEvent onSelectionChange = new SelectionEvent();

	[Token(Token = "0x6000EB3")]
	[Address(RVA = "0x4888A0", Offset = "0x4878A0", VA = "0x1804888A0")]
	private void eem()
	{
		if (gameObject.GetComponent<Canvas>().renderMode == RenderMode.ScreenSpaceOverlay)
		{
			CanvasScaler component = gameObject.GetComponent<CanvasScaler>();
			if ((bool)component && component.enabled && (!Mathf.Approximately(component.m_ScaleFactor, 1f) || component.m_UiScaleMode != CanvasScaler.ScaleMode.ConstantPixelSize))
			{
				Object.Destroy(component);
				Debug.LogWarning("SelectionBox component is on a gameObject with a Canvas Scaler component. As of now, Canvas Scalers without the default settings throw off the coordinates of the selection box. Canvas Scaler has been removed.");
			}
			return;
		}
		Exception ex = new Exception("SelectionBox component must be placed on a canvas in Screen Space Overlay mode.");
		/*Error: End of method reached without returning.*/;
	}

	[Token(Token = "0x6000EB4")]
	[Address(RVA = "0x488A70", Offset = "0x487A70", VA = "0x180488A70")]
	private void een(IEnumerable<MonoBehaviour> behaviourCollection)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EB5")]
	[Address(RVA = "0x488CA0", Offset = "0x487CA0", VA = "0x180488CA0")]
	private void eeo()
	{
		//IL_0045: Expected Obj, but got I4
		GameObject gameObject = new GameObject();
		gameObject.name = "Selection Box";
		Transform transform = gameObject.transform;
		Transform parent = base.transform;
		transform.parent = parent;
		Image image = gameObject.AddComponent<Image>();
		Transform transform2 = gameObject.transform;
		int num = 0;
		if ((object)transform2 != null)
		{
		}
		ovp = (RectTransform)num;
	}

	[Token(Token = "0x6000EB6")]
	[Address(RVA = "0x488DA0", Offset = "0x487DA0", VA = "0x180488DA0")]
	private unsafe void eep()
	{
		//IL_0050: Expected F4, but got I4
		//IL_004b: Expected native int or pointer, but got VT
		Image component = ovp.GetComponent<Image>();
		Color color = this.color;
		component.color = color;
		Sprite sprite = art;
		component.sprite = sprite;
		int num = 0;
		Vector2 zero = Vector2.zero;
		RectTransform rectTransform = ovp;
		int num2 = 0;
		ovo = zero;
		((Vector2*)(nint)ovo)->y = 0f;
		Vector2 zero2 = Vector2.zero;
		rectTransform.anchoredPosition = zero2;
		RectTransform rectTransform2 = ovp;
		int num3 = 0;
		Vector2 zero3 = Vector2.zero;
		rectTransform2.sizeDelta = zero3;
		RectTransform rectTransform3 = ovp;
		int num4 = 0;
		Vector2 zero4 = Vector2.zero;
		rectTransform3.anchorMax = zero4;
		RectTransform rectTransform4 = ovp;
		int num5 = 0;
		Vector2 zero5 = Vector2.zero;
		rectTransform4.anchorMin = zero5;
		RectTransform rectTransform5 = ovp;
		int num6 = 0;
		Vector2 zero6 = Vector2.zero;
		rectTransform5.pivot = zero6;
		GameObject gameObject = ovp.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
	}

	[Token(Token = "0x6000EB7")]
	[Address(RVA = "0x488F20", Offset = "0x487F20", VA = "0x180488F20")]
	private void eeq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EB8")]
	[Address(RVA = "0x4891C0", Offset = "0x4881C0", VA = "0x1804891C0")]
	private bool eer(Vector2 screenPoint)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EB9")]
	[Address(RVA = "0x4892A0", Offset = "0x4882A0", VA = "0x1804892A0")]
	private oi ees()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EBA")]
	[Address(RVA = "0x4895E0", Offset = "0x4885E0", VA = "0x1804895E0")]
	private void eet()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EBB")]
	[Address(RVA = "0x489850", Offset = "0x488850", VA = "0x180489850")]
	private void eeu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EBC")]
	[Address(RVA = "0x489980", Offset = "0x488980", VA = "0x180489980")]
	private void eev()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EBD")]
	[Address(RVA = "0x489AD0", Offset = "0x488AD0", VA = "0x180489AD0")]
	private Vector2 eew(oi selectable)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EBE")]
	[Address(RVA = "0x489CB0", Offset = "0x488CB0", VA = "0x180489CB0")]
	private Camera eex(RectTransform rectTransform)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EBF")]
	[Address(RVA = "0x489E60", Offset = "0x488E60", VA = "0x180489E60")]
	public oi[] eey()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EC0")]
	[Address(RVA = "0x48A020", Offset = "0x489020", VA = "0x18048A020")]
	private void eez()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EC1")]
	[Address(RVA = "0x488700", Offset = "0x487700", VA = "0x180488700")]
	private void Start()
	{
		//IL_004b: Expected Obj, but got I4
		eem();
		GameObject gameObject = new GameObject();
		gameObject.name = "Selection Box";
		Transform transform = gameObject.transform;
		Transform parent = base.transform;
		transform.parent = parent;
		Image image = gameObject.AddComponent<Image>();
		Transform transform2 = gameObject.transform;
		int num = 0;
		if ((object)transform2 != null)
		{
		}
		ovp = (RectTransform)num;
		eep();
	}

	[Token(Token = "0x6000EC2")]
	[Address(RVA = "0x488810", Offset = "0x487810", VA = "0x180488810")]
	private void Update()
	{
		eeq();
		eet();
		eez();
	}

	[Token(Token = "0x6000EC3")]
	[Address(RVA = "0x488840", Offset = "0x487840", VA = "0x180488840")]
	public SelectionBox()
	{
	}
}
