using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200019E")]
[AddComponentMenu("UI/Extensions/Radial Slider")]
[RequireComponent(typeof(Image))]
public class RadialSlider : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
	[Serializable]
	[Token(Token = "0x200019F")]
	public class RadialSliderValueChangedEvent : UnityEvent<int>
	{
		[Token(Token = "0x6000E3E")]
		[Address(RVA = "0x2752D0", Offset = "0x2742D0", VA = "0x1802752D0")]
		public RadialSliderValueChangedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Serializable]
	[Token(Token = "0x20001A0")]
	public class RadialSliderTextValueChangedEvent : UnityEvent<string>
	{
		[Token(Token = "0x6000E3F")]
		[Address(RVA = "0x275290", Offset = "0x274290", VA = "0x180275290")]
		public RadialSliderTextValueChangedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001966")]
	private bool osv;

	[FieldOffset(Offset = "0x19")]
	[Token(Token = "0x4001967")]
	private bool osw;

	[FieldOffset(Offset = "0x1A")]
	[Token(Token = "0x4001968")]
	private bool osx;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001969")]
	private Vector2 osy;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x400196A")]
	private Vector2 osz;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x400196B")]
	private float ota;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400196C")]
	private float otb;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x400196D")]
	private float otc;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400196E")]
	private float otd;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x400196F")]
	private float ote;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001970")]
	private Camera otf;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001971")]
	private Image otg;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001972")]
	[SerializeField]
	[Tooltip("Radial Gradient Start Color")]
	private Color m_startColor;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001973")]
	[SerializeField]
	[Tooltip("Radial Gradient End Color")]
	private Color m_endColor;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001974")]
	[SerializeField]
	[Tooltip("Move slider absolute or use Lerping?\nDragging only supported with absolute")]
	private bool m_lerpToTarget;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001975")]
	[SerializeField]
	[Tooltip("Curve to apply to the Lerp\nMust be set to enable Lerp")]
	private AnimationCurve m_lerpCurve;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001976")]
	[SerializeField]
	[Tooltip("Event fired when value of control changes, outputs an INT angle value")]
	private RadialSliderValueChangedEvent _onValueChanged;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001977")]
	[SerializeField]
	[Tooltip("Event fired when value of control changes, outputs a TEXT angle value")]
	private RadialSliderTextValueChangedEvent _onTextValueChanged;

	[Token(Token = "0x17000044")]
	public float pqn
	{
		[Token(Token = "0x6000E21")]
		[Address(RVA = "0x44AFD0", Offset = "0x449FD0", VA = "0x18044AFD0")]
		get
		{
			return pqu.m_FillAmount * 360f;
		}
		[Token(Token = "0x6000E22")]
		[Address(RVA = "0x44B000", Offset = "0x44A000", VA = "0x18044B000")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000045")]
	public float pqo
	{
		[Token(Token = "0x6000E23")]
		[Address(RVA = "0x44B080", Offset = "0x44A080", VA = "0x18044B080")]
		get
		{
			return pqu.m_FillAmount;
		}
		[Token(Token = "0x6000E24")]
		[Address(RVA = "0x44B0B0", Offset = "0x44A0B0", VA = "0x18044B0B0")]
		set
		{
			if (!m_lerpToTarget)
			{
				ebz(value);
				return;
			}
			while (osx)
			{
			}
			float fillAmount = pqu.m_FillAmount;
			otb = value;
			otc = fillAmount;
			otd = 0f;
			osx = true;
		}
	}

	[Token(Token = "0x17000046")]
	public Color pqp
	{
		[Token(Token = "0x6000E25")]
		[Address(RVA = "0x44B120", Offset = "0x44A120", VA = "0x18044B120")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000E26")]
		[Address(RVA = "0x44B130", Offset = "0x44A130", VA = "0x18044B130")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000047")]
	public Color pqq
	{
		[Token(Token = "0x6000E27")]
		[Address(RVA = "0x44B140", Offset = "0x44A140", VA = "0x18044B140")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000E28")]
		[Address(RVA = "0x44B150", Offset = "0x44A150", VA = "0x18044B150")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000048")]
	public bool pqr
	{
		[Token(Token = "0x6000E29")]
		[Address(RVA = "0x44B160", Offset = "0x44A160", VA = "0x18044B160")]
		get
		{
			return m_lerpToTarget;
		}
		[Token(Token = "0x6000E2A")]
		[Address(RVA = "0x44B170", Offset = "0x44A170", VA = "0x18044B170")]
		set
		{
			m_lerpToTarget = value;
		}
	}

	[Token(Token = "0x17000049")]
	public AnimationCurve pqs
	{
		[Token(Token = "0x6000E2B")]
		[Address(RVA = "0x40DEA0", Offset = "0x40CEA0", VA = "0x18040DEA0")]
		get
		{
			return m_lerpCurve;
		}
		[Token(Token = "0x6000E2C")]
		[Address(RVA = "0x44B180", Offset = "0x44A180", VA = "0x18044B180")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x1700004A")]
	public bool pqt
	{
		[Token(Token = "0x6000E2D")]
		[Address(RVA = "0x44B210", Offset = "0x44A210", VA = "0x18044B210")]
		get
		{
			return osx;
		}
	}

	[Token(Token = "0x1700004B")]
	public Image pqu
	{
		[Token(Token = "0x6000E2E")]
		[Address(RVA = "0x44B220", Offset = "0x44A220", VA = "0x18044B220")]
		get
		{
			//IL_0010: Expected Obj, but got I4
			//IL_0054: Expected F4, but got I4
			Image image = otg;
			int num = 0;
			if (image == (Object)num)
			{
				(otg = GetComponent<Image>()).type = Image.Type.Filled;
				otg.fillMethod = Image.FillMethod.Radial360;
				otg.fillOrigin = 3;
				Image image2 = otg;
				int num2 = 0;
				image2.fillAmount = num2;
			}
			return otg;
		}
	}

	[Token(Token = "0x1700004C")]
	public RadialSliderValueChangedEvent pqv
	{
		[Token(Token = "0x6000E2F")]
		[Address(RVA = "0x40DE80", Offset = "0x40CE80", VA = "0x18040DE80")]
		get
		{
			return _onValueChanged;
		}
		[Token(Token = "0x6000E30")]
		[Address(RVA = "0x40DEC0", Offset = "0x40CEC0", VA = "0x18040DEC0")]
		set
		{
			_onValueChanged = value;
		}
	}

	[Token(Token = "0x1700004D")]
	public RadialSliderTextValueChangedEvent pqw
	{
		[Token(Token = "0x6000E31")]
		[Address(RVA = "0x44B310", Offset = "0x44A310", VA = "0x18044B310")]
		get
		{
			return _onTextValueChanged;
		}
		[Token(Token = "0x6000E32")]
		[Address(RVA = "0x44B320", Offset = "0x44A320", VA = "0x18044B320")]
		set
		{
			_onTextValueChanged = value;
		}
	}

	[Token(Token = "0x6000E33")]
	[Address(RVA = "0x44AAD0", Offset = "0x449AD0", VA = "0x18044AAD0")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E34")]
	[Address(RVA = "0x44AC90", Offset = "0x449C90", VA = "0x18044AC90")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E35")]
	[Address(RVA = "0x44B330", Offset = "0x44A330", VA = "0x18044B330")]
	private void ebx(float targetAngle)
	{
		if (!osx)
		{
			float fillAmount = pqu.m_FillAmount;
			otb = targetAngle;
			otc = fillAmount;
			otd = 0f;
			osx = true;
		}
	}

	[Token(Token = "0x6000E36")]
	[Address(RVA = "0x44B380", Offset = "0x44A380", VA = "0x18044B380")]
	private float eby()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E37")]
	[Address(RVA = "0x44B490", Offset = "0x44A490", VA = "0x18044B490")]
	private void ebz(float targetAngle)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E38")]
	[Address(RVA = "0x44B550", Offset = "0x44A550", VA = "0x18044B550")]
	private void eca()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E39")]
	[Address(RVA = "0x44AC00", Offset = "0x449C00", VA = "0x18044AC00", Slot = "4")]
	public unsafe void OnPointerEnter(PointerEventData eventData)
	{
		//IL_0021: Expected native int or pointer, but got VT
		Vector2 vector = eventData.position__BackingField;
		float y = eventData.position__BackingField.y;
		osz = vector;
		((Vector2*)(nint)osz)->y = y;
		Camera enterEventCamera = eventData.enterEventCamera;
		otf = enterEventCamera;
	}

	[Token(Token = "0x6000E3A")]
	[Address(RVA = "0x44ABB0", Offset = "0x449BB0", VA = "0x18044ABB0", Slot = "5")]
	public unsafe void OnPointerDown(PointerEventData eventData)
	{
		//IL_0021: Expected native int or pointer, but got VT
		Vector2 vector = eventData.position__BackingField;
		float y = eventData.position__BackingField.y;
		osz = vector;
		((Vector2*)(nint)osz)->y = y;
		Camera enterEventCamera = eventData.enterEventCamera;
		otf = enterEventCamera;
		osv = true;
	}

	[Token(Token = "0x6000E3B")]
	[Address(RVA = "0x44AC50", Offset = "0x449C50", VA = "0x18044AC50", Slot = "6")]
	public unsafe void OnPointerUp(PointerEventData eventData)
	{
		//IL_001b: Expected F4, but got I4
		//IL_0016: Expected native int or pointer, but got VT
		int num = 0;
		Vector2 zero = Vector2.zero;
		osz = zero;
		((Vector2*)(nint)osz)->y = 0f;
		osv = false;
	}

	[Token(Token = "0x6000E3C")]
	[Address(RVA = "0x44AB80", Offset = "0x449B80", VA = "0x18044AB80", Slot = "7")]
	public unsafe void OnDrag(PointerEventData eventData)
	{
		//IL_0021: Expected native int or pointer, but got VT
		Vector2 vector = eventData.position__BackingField;
		float y = eventData.position__BackingField.y;
		osz = vector;
		((Vector2*)(nint)osz)->y = y;
	}

	[Token(Token = "0x6000E3D")]
	[Address(RVA = "0x44AF20", Offset = "0x449F20", VA = "0x18044AF20")]
	public RadialSlider()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
