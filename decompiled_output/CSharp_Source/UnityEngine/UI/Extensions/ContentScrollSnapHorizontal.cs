using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001E6")]
[ExecuteInEditMode]
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("UI/Extensions/ContentSnapScrollHorizontal")]
public class ContentScrollSnapHorizontal : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
{
	[Serializable]
	[Token(Token = "0x20001E7")]
	public class StartMovementEvent : UnityEvent
	{
		[Token(Token = "0x6001019")]
		[Address(RVA = "0x2740C0", Offset = "0x2730C0", VA = "0x1802740C0")]
		public StartMovementEvent()
		{
		}
	}

	[Serializable]
	[Token(Token = "0x20001E8")]
	public class CurrentItemChangeEvent : UnityEvent<int>
	{
		[Token(Token = "0x600101A")]
		[Address(RVA = "0x273C20", Offset = "0x272C20", VA = "0x180273C20")]
		public CurrentItemChangeEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Serializable]
	[Token(Token = "0x20001E9")]
	public class FoundItemToSnapToEvent : UnityEvent<int>
	{
		[Token(Token = "0x600101B")]
		[Address(RVA = "0x274110", Offset = "0x273110", VA = "0x180274110")]
		public FoundItemToSnapToEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Serializable]
	[Token(Token = "0x20001EA")]
	public class SnappedToItemEvent : UnityEvent<int>
	{
		[Token(Token = "0x600101C")]
		[Address(RVA = "0x2755F0", Offset = "0x2745F0", VA = "0x1802755F0")]
		public SnappedToItemEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Serializable]
	[Token(Token = "0x20001EB")]
	public struct MoveInfo
	{
		[Token(Token = "0x20001EC")]
		public enum ou
		{
			[Token(Token = "0x4001AF2")]
			childIndex,
			[Token(Token = "0x4001AF3")]
			positionIndex
		}

		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4001AED")]
		[Tooltip("Child Index means the Index coresponds to the content item at that index in the hierarchy.\nPosition Index means the Index corresponds to the content item in that snap position.\nA higher Position Index in a Horizonal Scroll Snap means it would be further to the right.")]
		public ou indexType;

		[FieldOffset(Offset = "0x4")]
		[Token(Token = "0x4001AEE")]
		[Tooltip("Zero based")]
		public int index;

		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x4001AEF")]
		[Tooltip("If this is true the snap scroll will jump to the index, otherwise it will lerp there.")]
		public bool jump;

		[FieldOffset(Offset = "0xC")]
		[Token(Token = "0x4001AF0")]
		[Tooltip("If jump is false this is the time it will take to lerp to the index")]
		public float duration;

		[Token(Token = "0x600101D")]
		[Address(RVA = "0x274250", Offset = "0x273250", VA = "0x180274250")]
		public MoveInfo(ou _indexType, int _index)
		{
			indexType = _indexType;
			index = _index;
			jump = true;
			duration = 0f;
		}

		[Token(Token = "0x600101E")]
		[Address(RVA = "0x274270", Offset = "0x273270", VA = "0x180274270")]
		public MoveInfo(ou _indexType, int _index, bool _jump, float _duration)
		{
			//IL_0007: Expected F4, but got I4
			duration = 0f;
			indexType = _indexType;
			index = _index;
			jump = _jump;
		}
	}

	[Token(Token = "0x20001ED")]
	[CompilerGenerated]
	private sealed class ov : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001AF4")]
		private int ozy;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001AF5")]
		private object ozz;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001AF6")]
		public ContentScrollSnapHorizontal paa;

		[Token(Token = "0x170000A3")]
		private object ptq
		{
			[Token(Token = "0x6001022")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return ozz;
			}
		}

		[Token(Token = "0x170000A4")]
		private object ptr
		{
			[Token(Token = "0x6001024")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return ozz;
			}
		}

		[Token(Token = "0x600101F")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public ov(int _003C_003E1__state)
		{
			ele();
			ozy = _003C_003E1__state;
		}

		[Token(Token = "0x6001020")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void ele()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001021")]
		[Address(RVA = "0x27C180", Offset = "0x27B180", VA = "0x18027C180", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001023")]
		[Address(RVA = "0x27C510", Offset = "0x27B510", VA = "0x18027C510", Slot = "8")]
		[DebuggerHidden]
		private void elg()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[Token(Token = "0x20001EE")]
	[CompilerGenerated]
	private sealed class ow : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001AF7")]
		private int pab;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001AF8")]
		private object pac;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001AF9")]
		public ContentScrollSnapHorizontal pad;

		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4001AFA")]
		private Vector3 pae;

		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x4001AFB")]
		private float paf;

		[Token(Token = "0x170000A5")]
		private object ptt
		{
			[Token(Token = "0x6001028")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return pac;
			}
		}

		[Token(Token = "0x170000A6")]
		private object ptu
		{
			[Token(Token = "0x600102A")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return pac;
			}
		}

		[Token(Token = "0x6001025")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public ow(int _003C_003E1__state)
		{
			eli();
			pab = _003C_003E1__state;
		}

		[Token(Token = "0x6001026")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void eli()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001027")]
		[Address(RVA = "0x27C550", Offset = "0x27B550", VA = "0x18027C550", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001029")]
		[Address(RVA = "0x27C790", Offset = "0x27B790", VA = "0x18027C790", Slot = "8")]
		[DebuggerHidden]
		private void elk()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001AD6")]
	public bool ignoreInactiveItems;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001AD7")]
	public MoveInfo startInfo;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001AD8")]
	public GameObject prevButton;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001AD9")]
	public GameObject nextButton;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001ADA")]
	public GameObject pagination;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001ADB")]
	[Tooltip("The velocity below which the scroll rect will start to snap")]
	public int snappingVelocityThreshold;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4001ADC")]
	[Header("Paging Info")]
	[Tooltip("Should the pagination & buttons jump or lerp to the items")]
	public bool jumpToItem;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001ADD")]
	[Tooltip("The time it will take for the pagination or buttons to move between items")]
	public float lerpTime;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001ADE")]
	[SerializeField]
	[Header("Events")]
	[Tooltip("Event is triggered whenever the scroll rect starts to move, even when triggered programatically")]
	private StartMovementEvent m_StartMovementEvent;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001ADF")]
	[SerializeField]
	[Tooltip("Event is triggered whenever the closest item to the center of the scrollrect changes")]
	private CurrentItemChangeEvent m_CurrentItemChangeEvent;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001AE0")]
	[SerializeField]
	[Tooltip("Event is triggered when the ContentSnapScroll decides which item it is going to snap to. Returns the index of the closest position.")]
	private FoundItemToSnapToEvent m_FoundItemToSnapToEvent;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001AE1")]
	[SerializeField]
	[Tooltip("Event is triggered when we finally settle on an element. Returns the index of the item's position.")]
	private SnappedToItemEvent m_SnappedToItemEvent;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001AE2")]
	private ScrollRect pag;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001AE3")]
	private RectTransform pah;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001AE4")]
	private RectTransform pai;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001AE5")]
	private List<Vector3> paj;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001AE6")]
	private Vector3 pak;

	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4001AE7")]
	private float pal;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4001AE8")]
	private DrivenRectTransformTracker pam;

	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x4001AE9")]
	private float pan;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001AEA")]
	private int pao;

	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x4001AEB")]
	private bool pap;

	[FieldOffset(Offset = "0xB5")]
	[Token(Token = "0x4001AEC")]
	private bool paq;

	[Token(Token = "0x17000099")]
	public StartMovementEvent ptv
	{
		[Token(Token = "0x6000FF2")]
		[Address(RVA = "0x3EFA40", Offset = "0x3EEA40", VA = "0x1803EFA40")]
		get
		{
			return m_StartMovementEvent;
		}
		[Token(Token = "0x6000FF3")]
		[Address(RVA = "0x3EFA60", Offset = "0x3EEA60", VA = "0x1803EFA60")]
		set
		{
			m_StartMovementEvent = value;
		}
	}

	[Token(Token = "0x1700009A")]
	public CurrentItemChangeEvent ptw
	{
		[Token(Token = "0x6000FF4")]
		[Address(RVA = "0x3EFA30", Offset = "0x3EEA30", VA = "0x1803EFA30")]
		get
		{
			return m_CurrentItemChangeEvent;
		}
		[Token(Token = "0x6000FF5")]
		[Address(RVA = "0x378310", Offset = "0x377310", VA = "0x180378310")]
		set
		{
			m_CurrentItemChangeEvent = value;
		}
	}

	[Token(Token = "0x1700009B")]
	public FoundItemToSnapToEvent ptx
	{
		[Token(Token = "0x6000FF6")]
		[Address(RVA = "0x3EFA20", Offset = "0x3EEA20", VA = "0x1803EFA20")]
		get
		{
			return m_FoundItemToSnapToEvent;
		}
		[Token(Token = "0x6000FF7")]
		[Address(RVA = "0x3EFA50", Offset = "0x3EEA50", VA = "0x1803EFA50")]
		set
		{
			m_FoundItemToSnapToEvent = value;
		}
	}

	[Token(Token = "0x1700009C")]
	public SnappedToItemEvent pty
	{
		[Token(Token = "0x6000FF8")]
		[Address(RVA = "0x40DE90", Offset = "0x40CE90", VA = "0x18040DE90")]
		get
		{
			return m_SnappedToItemEvent;
		}
		[Token(Token = "0x6000FF9")]
		[Address(RVA = "0x40DED0", Offset = "0x40CED0", VA = "0x18040DED0")]
		set
		{
			m_SnappedToItemEvent = value;
		}
	}

	[Token(Token = "0x1700009D")]
	private bool ptz
	{
		[Token(Token = "0x6000FFA")]
		[Address(RVA = "0x696E50", Offset = "0x695E50", VA = "0x180696E50")]
		get
		{
			//IL_0015: Expected Obj, but got I4
			HorizontalLayoutGroup component = pai.GetComponent<HorizontalLayoutGroup>();
			int num = 0;
			return component != (Object)num;
		}
	}

	[Token(Token = "0x1700009E")]
	public bool pua
	{
		[Token(Token = "0x6000FFB")]
		[Address(RVA = "0x696EE0", Offset = "0x695EE0", VA = "0x180696EE0")]
		get
		{
			if (!pap)
			{
			}
			return true;
		}
	}

	[Token(Token = "0x1700009F")]
	public bool pub
	{
		[Token(Token = "0x6000FFC")]
		[Address(RVA = "0x696F00", Offset = "0x695F00", VA = "0x180696F00")]
		get
		{
			return pap;
		}
	}

	[Token(Token = "0x170000A0")]
	public bool puc
	{
		[Token(Token = "0x6000FFD")]
		[Address(RVA = "0x696F10", Offset = "0x695F10", VA = "0x180696F10")]
		get
		{
			return paq;
		}
	}

	[Token(Token = "0x170000A1")]
	public int pud
	{
		[Token(Token = "0x6000FFE")]
		[Address(RVA = "0x696F20", Offset = "0x695F20", VA = "0x180696F20")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000A2")]
	public int pue
	{
		[Token(Token = "0x6000FFF")]
		[Address(RVA = "0x696FD0", Offset = "0x695FD0", VA = "0x180696FD0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x6001000")]
	[Address(RVA = "0x696780", Offset = "0x695780", VA = "0x180696780")]
	private void Awake()
	{
		//IL_00d9: Expected F4, but got I4
		//IL_00ea: Expected I4, but got I8
		Transform transform = (pag = GetComponent<ScrollRect>()).transform;
		if ((object)transform == null || (object)transform != null)
		{
			pah = (RectTransform)transform;
			RectTransform content = pag.m_Content;
			GameObject gameObject = nextButton;
			pai = content;
			if ((bool)gameObject)
			{
				Button.ButtonClickedEvent onClick = nextButton.GetComponent<Button>().m_OnClick;
				UnityAction call = [Token(Token = "0x6001017")] [Address(RVA = "0x698440", Offset = "0x697440", VA = "0x180698440")] () =>
				{
					throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
				};
				onClick.AddListener(call);
			}
			if ((bool)prevButton)
			{
				Button.ButtonClickedEvent onClick2 = prevButton.GetComponent<Button>().m_OnClick;
				UnityAction call2 = [Token(Token = "0x6001018")] [Address(RVA = "0x698510", Offset = "0x697510", VA = "0x180698510")] () =>
				{
					throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
				};
				onClick2.AddListener(call2);
			}
			ema();
			if (!ptz)
			{
				emd();
			}
			emc();
			ScrollRect scrollRect = pag;
			int num = 0;
			scrollRect.horizontalNormalizedPosition = num;
			MoveInfo info = startInfo;
			pao = 0;
			eme(info);
			return;
		}
		throw new InvalidCastException();
	}

	[Token(Token = "0x6001001")]
	[Address(RVA = "0x696AC0", Offset = "0x695AC0", VA = "0x180696AC0")]
	private void OnDisable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001002")]
	[Address(RVA = "0x697040", Offset = "0x696040", VA = "0x180697040")]
	private void ema()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001003")]
	[Address(RVA = "0x6972C0", Offset = "0x6962C0", VA = "0x1806972C0")]
	private void emb()
	{
		if (!ptz)
		{
			emd();
		}
		else
		{
			emc();
		}
	}

	[Token(Token = "0x6001004")]
	[Address(RVA = "0x6972F0", Offset = "0x6962F0", VA = "0x1806972F0")]
	private void emc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001005")]
	[Address(RVA = "0x697890", Offset = "0x696890", VA = "0x180697890")]
	private void emd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001006")]
	[Address(RVA = "0x697E10", Offset = "0x696E10", VA = "0x180697E10")]
	public void eme(MoveInfo info)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001007")]
	[Address(RVA = "0x697FC0", Offset = "0x696FC0", VA = "0x180697FC0")]
	private void emf(int index, bool jump)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001008")]
	[Address(RVA = "0x698320", Offset = "0x697320", VA = "0x180698320")]
	private void emg(int index, bool jump)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001009")]
	[Address(RVA = "0x698440", Offset = "0x697440", VA = "0x180698440")]
	public void emh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600100A")]
	[Address(RVA = "0x698510", Offset = "0x697510", VA = "0x180698510")]
	public void emi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600100B")]
	[Address(RVA = "0x6985E0", Offset = "0x6975E0", VA = "0x1806985E0")]
	public void emj()
	{
		ema();
		if (!ptz)
		{
			emd();
		}
		else
		{
			emc();
		}
	}

	[Token(Token = "0x600100C")]
	[Address(RVA = "0x698620", Offset = "0x697620", VA = "0x180698620")]
	public void emk(MoveInfo info)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600100D")]
	[Address(RVA = "0x696A70", Offset = "0x695A70", VA = "0x180696A70", Slot = "4")]
	public void OnBeginDrag(PointerEventData ped)
	{
		eml();
		if (!pap && !paq)
		{
			m_StartMovementEvent.Invoke();
		}
	}

	[Token(Token = "0x600100E")]
	[Address(RVA = "0x696AD0", Offset = "0x695AD0", VA = "0x180696AD0", Slot = "5")]
	public void OnEndDrag(PointerEventData ped)
	{
		Coroutine coroutine = StartCoroutine("SlideAndLerp");
	}

	[Token(Token = "0x600100F")]
	[Address(RVA = "0x696B80", Offset = "0x695B80", VA = "0x180696B80")]
	private void Update()
	{
		//IL_002a: Expected VT, but got I4
		int num = pao;
		int num2 = pud;
		if (num == num2)
		{
			return;
		}
		CurrentItemChangeEvent currentItemChangeEvent = m_CurrentItemChangeEvent;
		int num3 = pud;
		((UnityEvent<T0>)(object)currentItemChangeEvent).Invoke((T0)num3);
		int num4 = pud;
		if ((bool)pagination)
		{
			GameObject gameObject = pagination;
			int num5 = 0;
			int childCount = gameObject.transform.childCount;
			if (num5 < childCount)
			{
				Toggle component = pagination.transform.GetChild(num5).GetComponent<Toggle>();
				bool isOn = num4 == num5;
				component.isOn = isOn;
				GameObject gameObject2 = pagination;
				num5++;
			}
		}
		int num6 = pud;
		pao = num6;
	}

	[Token(Token = "0x6001010")]
	[Address(RVA = "0x696B10", Offset = "0x695B10", VA = "0x180696B10")]
	[IteratorStateMachine(typeof(ov))]
	private IEnumerator SlideAndLerp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001011")]
	[Address(RVA = "0x696A00", Offset = "0x695A00", VA = "0x180696A00")]
	[IteratorStateMachine(typeof(ow))]
	private IEnumerator LerpToContent()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001012")]
	[Address(RVA = "0x698680", Offset = "0x697680", VA = "0x180698680")]
	private unsafe void eml()
	{
		//IL_0022: Expected F4, but got I4
		//IL_001d: Expected native int or pointer, but got VT
		ScrollRect scrollRect = pag;
		int num = 0;
		Vector2 zero = Vector2.zero;
		scrollRect.m_Velocity = zero;
		((Vector2*)(nint)scrollRect.m_Velocity)->y = 0f;
		StopCoroutine("SlideAndLerp");
		StopCoroutine("LerpToContent");
	}

	[Token(Token = "0x6001013")]
	[Address(RVA = "0x698720", Offset = "0x697720", VA = "0x180698720")]
	private void emm(int targetScreen)
	{
		if ((bool)pagination)
		{
			GameObject gameObject = pagination;
			int num = 0;
			int childCount = gameObject.transform.childCount;
			if (num < childCount)
			{
				Toggle component = pagination.transform.GetChild(num).GetComponent<Toggle>();
				bool isOn = targetScreen == num;
				component.isOn = isOn;
				GameObject gameObject2 = pagination;
				num++;
			}
		}
	}

	[Token(Token = "0x6001014")]
	[Address(RVA = "0x698840", Offset = "0x697840", VA = "0x180698840")]
	private Vector2 emn(RectTransform rt)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001015")]
	[Address(RVA = "0x6988F0", Offset = "0x6978F0", VA = "0x1806988F0")]
	private Vector3 emo(Vector3 start)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001016")]
	[Address(RVA = "0x696D20", Offset = "0x695D20", VA = "0x180696D20")]
	public ContentScrollSnapHorizontal()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001017")]
	[Address(RVA = "0x698440", Offset = "0x697440", VA = "0x180698440")]
	[CompilerGenerated]
	private void emp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001018")]
	[Address(RVA = "0x698510", Offset = "0x697510", VA = "0x180698510")]
	[CompilerGenerated]
	private void emq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
