using System;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000186")]
[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("UI/Extensions/BoxSlider")]
public class BoxSlider : Selectable, IDragHandler, IEventSystemHandler, IInitializePotentialDragHandler, ICanvasElement
{
	[Token(Token = "0x2000187")]
	public enum nx
	{
		[Token(Token = "0x40018E5")]
		LeftToRight,
		[Token(Token = "0x40018E6")]
		RightToLeft,
		[Token(Token = "0x40018E7")]
		BottomToTop,
		[Token(Token = "0x40018E8")]
		TopToBottom
	}

	[Serializable]
	[Token(Token = "0x2000188")]
	public class BoxSliderEvent : UnityEvent<float, float>
	{
		[Token(Token = "0x6000DB1")]
		[Address(RVA = "0x273BA0", Offset = "0x272BA0", VA = "0x180273BA0")]
		public BoxSliderEvent()
		{
			((UnityEvent<T0, T1>)(object)this)._002Ector();
		}
	}

	[Token(Token = "0x2000189")]
	private enum ny
	{
		[Token(Token = "0x40018EA")]
		Horizontal,
		[Token(Token = "0x40018EB")]
		Vertical
	}

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x40018D9")]
	[SerializeField]
	private RectTransform m_HandleRect;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40018DA")]
	[Space]
	[SerializeField]
	private float m_MinValue;

	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x40018DB")]
	[SerializeField]
	private float m_MaxValue = 1f;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40018DC")]
	[SerializeField]
	private bool m_WholeNumbers;

	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x40018DD")]
	[SerializeField]
	private float m_ValueX = 1f;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40018DE")]
	[SerializeField]
	private float m_ValueY = 1f;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40018DF")]
	[Space]
	[SerializeField]
	private BoxSliderEvent m_OnValueChanged;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40018E0")]
	private Transform opt;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40018E1")]
	private RectTransform opu;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40018E2")]
	private Vector2 opv;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40018E3")]
	private DrivenRectTransformTracker opw;

	[Token(Token = "0x17000022")]
	public RectTransform ppk
	{
		[Token(Token = "0x6000D89")]
		[Address(RVA = "0x3765A0", Offset = "0x3755A0", VA = "0x1803765A0")]
		get
		{
			return m_HandleRect;
		}
		[Token(Token = "0x6000D8A")]
		[Address(RVA = "0x601360", Offset = "0x600360", VA = "0x180601360")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000023")]
	public float ppl
	{
		[Token(Token = "0x6000D8B")]
		[Address(RVA = "0x6013D0", Offset = "0x6003D0", VA = "0x1806013D0")]
		get
		{
			return m_MinValue;
		}
		[Token(Token = "0x6000D8C")]
		[Address(RVA = "0x6013E0", Offset = "0x6003E0", VA = "0x1806013E0")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000024")]
	public float ppm
	{
		[Token(Token = "0x6000D8D")]
		[Address(RVA = "0x601470", Offset = "0x600470", VA = "0x180601470")]
		get
		{
			return m_MaxValue;
		}
		[Token(Token = "0x6000D8E")]
		[Address(RVA = "0x601480", Offset = "0x600480", VA = "0x180601480")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000025")]
	public bool ppn
	{
		[Token(Token = "0x6000D8F")]
		[Address(RVA = "0x3765D0", Offset = "0x3755D0", VA = "0x1803765D0")]
		get
		{
			return m_WholeNumbers;
		}
		[Token(Token = "0x6000D90")]
		[Address(RVA = "0x601510", Offset = "0x600510", VA = "0x180601510")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000026")]
	public float ppo
	{
		[Token(Token = "0x6000D91")]
		[Address(RVA = "0x6015A0", Offset = "0x6005A0", VA = "0x1806015A0")]
		get
		{
			float valueX = m_ValueX;
			while (m_WholeNumbers)
			{
			}
			return valueX;
		}
		[Token(Token = "0x6000D92")]
		[Address(RVA = "0x6015C0", Offset = "0x6005C0", VA = "0x1806015C0")]
		set
		{
			dxy(value, sendCallback: true);
		}
	}

	[Token(Token = "0x17000027")]
	public float ppp
	{
		[Token(Token = "0x6000D93")]
		[Address(RVA = "0x6015D0", Offset = "0x6005D0", VA = "0x1806015D0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000D94")]
		[Address(RVA = "0x601650", Offset = "0x600650", VA = "0x180601650")]
		set
		{
			float minValue = m_MinValue;
			float maxValue = m_MaxValue;
			maxValue = Mathf.Lerp(minValue, maxValue, value);
			dxy(maxValue, sendCallback: true);
		}
	}

	[Token(Token = "0x17000028")]
	public float ppq
	{
		[Token(Token = "0x6000D95")]
		[Address(RVA = "0x601690", Offset = "0x600690", VA = "0x180601690")]
		get
		{
			float valueY = m_ValueY;
			while (m_WholeNumbers)
			{
			}
			return valueY;
		}
		[Token(Token = "0x6000D96")]
		[Address(RVA = "0x6016B0", Offset = "0x6006B0", VA = "0x1806016B0")]
		set
		{
			dya(value, sendCallback: true);
		}
	}

	[Token(Token = "0x17000029")]
	public float ppr
	{
		[Token(Token = "0x6000D97")]
		[Address(RVA = "0x6016C0", Offset = "0x6006C0", VA = "0x1806016C0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000D98")]
		[Address(RVA = "0x601740", Offset = "0x600740", VA = "0x180601740")]
		set
		{
			float minValue = m_MinValue;
			float maxValue = m_MaxValue;
			maxValue = Mathf.Lerp(minValue, maxValue, value);
			dya(maxValue, sendCallback: true);
		}
	}

	[Token(Token = "0x1700002A")]
	public BoxSliderEvent pps
	{
		[Token(Token = "0x6000D99")]
		[Address(RVA = "0x521F90", Offset = "0x520F90", VA = "0x180521F90")]
		get
		{
			return m_OnValueChanged;
		}
		[Token(Token = "0x6000D9A")]
		[Address(RVA = "0x601780", Offset = "0x600780", VA = "0x180601780")]
		set
		{
			m_OnValueChanged = value;
		}
	}

	[Token(Token = "0x1700002B")]
	private float ppt
	{
		[Token(Token = "0x6000D9B")]
		[Address(RVA = "0x601790", Offset = "0x600790", VA = "0x180601790")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x6000D9C")]
	[Address(RVA = "0x601290", Offset = "0x600290", VA = "0x180601290")]
	protected unsafe BoxSlider()
	{
		//IL_0049: Expected F4, but got I4
		//IL_0044: Expected native int or pointer, but got VT
		BoxSliderEvent onValueChanged = new BoxSliderEvent();
		int num = 0;
		m_OnValueChanged = onValueChanged;
		opv = Vector2.zero;
		((Vector2*)(nint)opv)->y = 0f;
		base._002Ector();
	}

	[Token(Token = "0x6000D9D")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "46")]
	public virtual void Rebuild(CanvasUpdate executing)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D9E")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "43")]
	public void LayoutComplete()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D9F")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "44")]
	public void GraphicUpdateComplete()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DA0")]
	[Address(RVA = "0x4B9550", Offset = "0x4B8550", VA = "0x1804B9550")]
	public static bool dxu<T>(ref T currentValue, T newValue) where T : class
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DA1")]
	[Address(RVA = "0x4B95A0", Offset = "0x4B85A0", VA = "0x1804B95A0")]
	public static bool dxv<T>(ref T currentValue, T newValue) where T : struct
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DA2")]
	[Address(RVA = "0x600F10", Offset = "0x5FFF10", VA = "0x180600F10", Slot = "5")]
	protected override void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DA3")]
	[Address(RVA = "0x600E60", Offset = "0x5FFE60", VA = "0x180600E60", Slot = "7")]
	protected override void OnDisable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DA4")]
	[Address(RVA = "0x6017C0", Offset = "0x6007C0", VA = "0x1806017C0")]
	private void dxw()
	{
		//IL_003b: Expected Obj, but got I4
		//IL_0017: Expected Obj, but got I8
		Transform parent;
		int num;
		do
		{
			if (!m_HandleRect)
			{
				opu = (RectTransform)0;
				return;
			}
			parent = (opt = m_HandleRect.transform).parent;
			num = 0;
		}
		while (!(parent != (Object)num));
		RectTransform component = opt.parent.GetComponent<RectTransform>();
		opu = component;
	}

	[Token(Token = "0x6000DA5")]
	[Address(RVA = "0x6015C0", Offset = "0x6005C0", VA = "0x1806015C0")]
	private void dxx(float input)
	{
		dxy(input, sendCallback: true);
	}

	[Token(Token = "0x6000DA6")]
	[Address(RVA = "0x6018E0", Offset = "0x6008E0", VA = "0x1806018E0")]
	private void dxy(float input, bool sendCallback)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DA7")]
	[Address(RVA = "0x6016B0", Offset = "0x6006B0", VA = "0x1806016B0")]
	private void dxz(float input)
	{
		dya(input, sendCallback: true);
	}

	[Token(Token = "0x6000DA8")]
	[Address(RVA = "0x6019C0", Offset = "0x6009C0", VA = "0x1806019C0")]
	private void dya(float input, bool sendCallback)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DA9")]
	[Address(RVA = "0x601270", Offset = "0x600270", VA = "0x180601270", Slot = "10")]
	protected override void OnRectTransformDimensionsChange()
	{
		int executing = 0;
		Rebuild((CanvasUpdate)executing);
		dyb();
	}

	[Token(Token = "0x6000DAA")]
	[Address(RVA = "0x601AA0", Offset = "0x600AA0", VA = "0x180601AA0")]
	private void dyb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DAB")]
	[Address(RVA = "0x601CE0", Offset = "0x600CE0", VA = "0x180601CE0")]
	private void dyc(PointerEventData eventData, Camera cam)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DAC")]
	[Address(RVA = "0x601FD0", Offset = "0x600FD0", VA = "0x180601FD0")]
	private bool dyd(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DAD")]
	[Address(RVA = "0x601030", Offset = "0x600030", VA = "0x180601030", Slot = "32")]
	public unsafe override void OnPointerDown(PointerEventData eventData)
	{
		//IL_004f: Expected F4, but got I4
		//IL_004a: Expected native int or pointer, but got VT
		//IL_005a: Expected Obj, but got I4
		//IL_007b: Expected VT, but got I4
		//IL_009d: Expected VT, but got I4
		//IL_00b5: Expected native int or pointer, but got VT
		int num = 0;
		if (!IsActive() || !IsInteractable() || eventData.button__BackingField != PointerEventData.InputButton.Left)
		{
			return;
		}
		base.OnPointerDown(eventData);
		int num2 = 0;
		Vector2 zero = Vector2.zero;
		RectTransform rectTransform = opu;
		opv = zero;
		((Vector2*)(nint)opv)->y = 0f;
		int num3 = 0;
		if (rectTransform != (Object)num3)
		{
			RectTransform handleRect = m_HandleRect;
			int num4 = 0;
			Camera enterEventCamera = eventData.enterEventCamera;
			if (RectTransformUtility.RectangleContainsScreenPoint(handleRect, (Vector2)num4, enterEventCamera))
			{
				RectTransform handleRect2 = m_HandleRect;
				int num5 = 0;
				Camera pressEventCamera = eventData.pressEventCamera;
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(handleRect2, (Vector2)num5, pressEventCamera, out *(Vector2*)num))
				{
				}
				float y = opv.y;
				((Vector2*)(nint)opv)->y = y;
				return;
			}
		}
		Camera pressEventCamera2 = eventData.pressEventCamera;
		dyc(eventData, pressEventCamera2);
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000DAE")]
	[Address(RVA = "0x600E90", Offset = "0x5FFE90", VA = "0x180600E90", Slot = "47")]
	public virtual void OnDrag(PointerEventData eventData)
	{
		if (IsActive() && IsInteractable() && eventData.button__BackingField == PointerEventData.InputButton.Left)
		{
			Camera pressEventCamera = eventData.pressEventCamera;
			dyc(eventData, pressEventCamera);
		}
	}

	[Token(Token = "0x6000DAF")]
	[Address(RVA = "0x42D1F0", Offset = "0x42C1F0", VA = "0x18042D1F0", Slot = "48")]
	public virtual void OnInitializePotentialDrag(PointerEventData eventData)
	{
		eventData.useDragThreshold__BackingField = false;
	}

	[SpecialName]
	[Token(Token = "0x6000DB0")]
	[Address(RVA = "0x602040", Offset = "0x601040", VA = "0x180602040", Slot = "42")]
	private Transform dye()
	{
		return transform;
	}
}
