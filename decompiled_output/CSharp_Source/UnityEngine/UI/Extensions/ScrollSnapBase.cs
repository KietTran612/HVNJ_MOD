using System;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000202")]
public class ScrollSnapBase : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, oz
{
	[Serializable]
	[Token(Token = "0x2000203")]
	public class SelectionChangeStartEvent : UnityEvent
	{
		[Token(Token = "0x60010CA")]
		[Address(RVA = "0x2740C0", Offset = "0x2730C0", VA = "0x1802740C0")]
		public SelectionChangeStartEvent()
		{
		}
	}

	[Serializable]
	[Token(Token = "0x2000204")]
	public class SelectionPageChangedEvent : UnityEvent<int>
	{
		[Token(Token = "0x60010CB")]
		[Address(RVA = "0x275530", Offset = "0x274530", VA = "0x180275530")]
		public SelectionPageChangedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Serializable]
	[Token(Token = "0x2000205")]
	public class SelectionChangeEndEvent : UnityEvent<int>
	{
		[Token(Token = "0x60010CC")]
		[Address(RVA = "0x2753F0", Offset = "0x2743F0", VA = "0x1802753F0")]
		public SelectionChangeEndEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001B61")]
	internal Rect pcl;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001B62")]
	internal RectTransform pcm;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001B63")]
	internal bool pcn;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001B64")]
	internal int pco = 1;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001B65")]
	internal float pcp;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001B66")]
	internal float pcq;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001B67")]
	private float pcr;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001B68")]
	private float pcs;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001B69")]
	internal Vector2 pct;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001B6A")]
	internal ScrollRect pcu;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001B6B")]
	internal Vector3 pcv;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4001B6C")]
	internal bool pcw;

	[FieldOffset(Offset = "0x65")]
	[Token(Token = "0x4001B6D")]
	internal bool pcx;

	[FieldOffset(Offset = "0x66")]
	[Token(Token = "0x4001B6E")]
	internal bool pcy = true;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001B6F")]
	internal Vector3 pcz;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001B70")]
	[Tooltip("The currently active page")]
	internal int pda;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001B71")]
	internal int pdb;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4001B72")]
	internal int pdc;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001B73")]
	internal bool pdd;

	[FieldOffset(Offset = "0x81")]
	[Token(Token = "0x4001B74")]
	internal bool pde;

	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4001B75")]
	internal int pdf;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001B76")]
	internal float pdg;

	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4001B77")]
	private int pdh;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001B78")]
	private int pdi;

	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4001B79")]
	[SerializeField]
	[Tooltip("The screen / page to start the control on\n*Note, this is a 0 indexed array")]
	public int StartingScreen;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001B7A")]
	[SerializeField]
	[Tooltip("The distance between two pages based on page height, by default pages are next to each other")]
	[Range(0f, 8f)]
	public float PageStep = 1f;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4001B7B")]
	[Tooltip("The gameobject that contains toggles which suggest pagination. (optional)")]
	public GameObject Pagination;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4001B7C")]
	[Tooltip("Button to go to the previous page. (optional)")]
	public GameObject PrevButton;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001B7D")]
	[Tooltip("Button to go to the next page. (optional)")]
	public GameObject NextButton;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4001B7E")]
	[Tooltip("Transition speed between pages. (optional)")]
	public float transitionSpeed = 7.5f;

	[FieldOffset(Offset = "0xBC")]
	[Token(Token = "0x4001B7F")]
	[Tooltip("Hard Swipe forces to swiping to the next / previous page (optional)")]
	public bool UseHardSwipe;

	[FieldOffset(Offset = "0xBD")]
	[Token(Token = "0x4001B80")]
	[Tooltip("Fast Swipe makes swiping page next / previous (optional)")]
	public bool UseFastSwipe;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4001B81")]
	[Tooltip("Offset for how far a swipe has to travel to initiate a page change (optional)")]
	public int FastSwipeThreshold = 100;

	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x4001B82")]
	[Tooltip("Speed at which the ScrollRect will keep scrolling before slowing down and stopping (optional)")]
	public int SwipeVelocityThreshold = 100;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4001B83")]
	[Tooltip("Use time scale instead of unscaled time (optional)")]
	public bool UseTimeScale = true;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4001B84")]
	[Tooltip("The visible bounds area, controls which items are visible/enabled. *Note Should use a RectMask. (optional)")]
	public RectTransform MaskArea;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4001B85")]
	[Tooltip("Pixel size to buffer around Mask Area. (optional)")]
	public float MaskBuffer = 1f;

	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x4001B86")]
	[Tooltip("By default the container will lerp to the start when enabled in the scene, this option overrides this and forces it to simply jump without lerping")]
	public bool JumpOnEnable;

	[FieldOffset(Offset = "0xDD")]
	[Token(Token = "0x4001B87")]
	[Tooltip("By default the container will return to the original starting page when enabled, this option overrides this behaviour and stays on the current selection")]
	public bool RestartOnEnable;

	[FieldOffset(Offset = "0xDE")]
	[Token(Token = "0x4001B88")]
	[Tooltip("(Experimental)\nBy default, child array objects will use the parent transform\nHowever you can disable this for some interesting effects")]
	public bool UseParentTransform = true;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4001B89")]
	[Tooltip("Scroll Snap children. (optional)\nEither place objects in the scene as children OR\nPrefabs in this array, NOT BOTH")]
	public GameObject[] ChildObjects;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4001B8A")]
	[SerializeField]
	[Tooltip("Event fires when a user starts to change the selection")]
	private SelectionChangeStartEvent m_OnSelectionChangeStartEvent = new SelectionChangeStartEvent();

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4001B8B")]
	[SerializeField]
	[Tooltip("Event fires as the page changes, while dragging or jumping")]
	private SelectionPageChangedEvent m_OnSelectionPageChangedEvent = new SelectionPageChangedEvent();

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4001B8C")]
	[SerializeField]
	[Tooltip("Event fires when the page settles after a user has dragged")]
	private SelectionChangeEndEvent m_OnSelectionChangeEndEvent = new SelectionChangeEndEvent();

	[Token(Token = "0x170000B0")]
	public int pul
	{
		[Token(Token = "0x60010A5")]
		[Address(RVA = "0x481170", Offset = "0x480170", VA = "0x180481170")]
		get
		{
			return pda;
		}
		[Token(Token = "0x60010A6")]
		[Address(RVA = "0x481180", Offset = "0x480180", VA = "0x180481180")]
		internal set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000B1")]
	public SelectionChangeStartEvent pum
	{
		[Token(Token = "0x60010A7")]
		[Address(RVA = "0x4813A0", Offset = "0x4803A0", VA = "0x1804813A0")]
		get
		{
			return m_OnSelectionChangeStartEvent;
		}
		[Token(Token = "0x60010A8")]
		[Address(RVA = "0x4813B0", Offset = "0x4803B0", VA = "0x1804813B0")]
		set
		{
			m_OnSelectionChangeStartEvent = value;
		}
	}

	[Token(Token = "0x170000B2")]
	public SelectionPageChangedEvent pun
	{
		[Token(Token = "0x60010A9")]
		[Address(RVA = "0x375910", Offset = "0x374910", VA = "0x180375910")]
		get
		{
			return m_OnSelectionPageChangedEvent;
		}
		[Token(Token = "0x60010AA")]
		[Address(RVA = "0x4813C0", Offset = "0x4803C0", VA = "0x1804813C0")]
		set
		{
			m_OnSelectionPageChangedEvent = value;
		}
	}

	[Token(Token = "0x170000B3")]
	public SelectionChangeEndEvent puo
	{
		[Token(Token = "0x60010AB")]
		[Address(RVA = "0x3765A0", Offset = "0x3755A0", VA = "0x1803765A0")]
		get
		{
			return m_OnSelectionChangeEndEvent;
		}
		[Token(Token = "0x60010AC")]
		[Address(RVA = "0x4813D0", Offset = "0x4803D0", VA = "0x1804813D0")]
		set
		{
			m_OnSelectionChangeEndEvent = value;
		}
	}

	[Token(Token = "0x60010AD")]
	[Address(RVA = "0x4807F0", Offset = "0x47F7F0", VA = "0x1804807F0")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010AE")]
	[Address(RVA = "0x4813E0", Offset = "0x4803E0", VA = "0x1804813E0")]
	internal void epz()
	{
		GameObject[] childObjects = ChildObjects;
		if (childObjects != null && childObjects.Length != 0)
		{
			int childCount = pcm.transform.childCount;
			eqb();
		}
		else
		{
			eqa();
		}
	}

	[Token(Token = "0x60010AF")]
	[Address(RVA = "0x4814A0", Offset = "0x4804A0", VA = "0x1804814A0")]
	internal void eqa()
	{
		while (true)
		{
			int childCount = pcm.childCount;
			GameObject[] childObjects = new GameObject[childCount];
			int num = 0;
			ChildObjects = childObjects;
			if (childCount <= 0)
			{
				break;
			}
			RectTransform rectTransform = pcm;
			GameObject[] childObjects2 = ChildObjects;
			GameObject gameObject = rectTransform.transform.GetChild(num).gameObject;
			if ((object)gameObject == null || (object)gameObject != null)
			{
				childObjects2[0] = gameObject;
				if ((bool)MaskArea && ChildObjects[num].activeSelf)
				{
					GameObject gameObject2 = ChildObjects[num];
					int active = 0;
					gameObject2.SetActive((byte)active != 0);
				}
				num++;
				break;
			}
		}
	}

	[Token(Token = "0x60010B0")]
	[Address(RVA = "0x4816A0", Offset = "0x4806A0", VA = "0x1804816A0")]
	internal void eqb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010B1")]
	[Address(RVA = "0x481A00", Offset = "0x480A00", VA = "0x180481A00")]
	internal void eqc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010B2")]
	[Address(RVA = "0x481E40", Offset = "0x480E40", VA = "0x180481E40")]
	public void eqd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010B3")]
	[Address(RVA = "0x481F00", Offset = "0x480F00", VA = "0x180481F00")]
	public void eqe()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010B4")]
	[Address(RVA = "0x481060", Offset = "0x480060", VA = "0x180481060")]
	public void eqf(int screenIndex)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010B5")]
	[Address(RVA = "0x481FC0", Offset = "0x480FC0", VA = "0x180481FC0")]
	internal int eqg(Vector3 pos)
	{
		//IL_000f: Expected I4, but got VT
		if (pcn)
		{
		}
		return (int)typeof(Math).TypeHandle;
	}

	[Token(Token = "0x60010B6")]
	[Address(RVA = "0x482080", Offset = "0x481080", VA = "0x180482080")]
	internal bool eqh(Vector3 pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010B7")]
	[Address(RVA = "0x4821C0", Offset = "0x4811C0", VA = "0x1804821C0")]
	internal void eqi(int page, ref Vector3 target)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010B8")]
	[Address(RVA = "0x4823C0", Offset = "0x4813C0", VA = "0x1804823C0")]
	internal void eqj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010B9")]
	[Address(RVA = "0x482440", Offset = "0x481440", VA = "0x180482440")]
	internal void eqk(int currentScreen)
	{
		if ((bool)Pagination)
		{
			GameObject pagination = Pagination;
			int num = 0;
			int childCount = pagination.transform.childCount;
			if (num < childCount)
			{
				Toggle component = Pagination.transform.GetChild(num).GetComponent<Toggle>();
				bool isOn = currentScreen == num;
				component.isOn = isOn;
				GameObject pagination2 = Pagination;
				num++;
			}
		}
		if (!pde)
		{
			if ((bool)PrevButton)
			{
				Button component2 = PrevButton.GetComponent<Button>();
				bool interactable = currentScreen > 0;
				component2.interactable = interactable;
			}
			if ((bool)NextButton)
			{
				Button component3 = NextButton.GetComponent<Button>();
				int childCount2 = pcm.transform.childCount;
				bool interactable2 = currentScreen < childCount2;
				component3.interactable = interactable2;
			}
		}
	}

	[Token(Token = "0x60010BA")]
	[Address(RVA = "0x4826B0", Offset = "0x4816B0", VA = "0x1804826B0")]
	private void eql(int targetScreen)
	{
		if ((bool)Pagination)
		{
			GameObject pagination = Pagination;
			int num = 0;
			int childCount = pagination.transform.childCount;
			if (num < childCount)
			{
				Toggle component = Pagination.transform.GetChild(num).GetComponent<Toggle>();
				bool isOn = targetScreen == num;
				component.isOn = isOn;
				GameObject pagination2 = Pagination;
				num++;
			}
		}
	}

	[Token(Token = "0x60010BB")]
	[Address(RVA = "0x4827E0", Offset = "0x4817E0", VA = "0x1804827E0")]
	private void eqm(int targetScreen)
	{
		if (!pde)
		{
			if ((bool)PrevButton)
			{
				Button component = PrevButton.GetComponent<Button>();
				bool interactable = targetScreen > 0;
				component.interactable = interactable;
			}
			if ((bool)NextButton)
			{
				Button component2 = NextButton.GetComponent<Button>();
				int childCount = pcm.transform.childCount;
				bool interactable2 = targetScreen < childCount;
				component2.interactable = interactable2;
			}
		}
	}

	[Token(Token = "0x60010BC")]
	[Address(RVA = "0x480D10", Offset = "0x47FD10", VA = "0x180480D10")]
	private void OnValidate()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0088: Expected Obj, but got I4
		//IL_0100: Invalid comparison between I4 and F4
		//IL_00e6: Expected I4, but got I8
		ScrollRect scrollRect = pcu;
		int num = 0;
		if (scrollRect == (Object)num)
		{
			ScrollRect component = GetComponent<ScrollRect>();
			pcu = component;
		}
		ScrollRect scrollRect2 = pcu;
		if (!scrollRect2.m_Horizontal && !scrollRect2.m_Vertical)
		{
			Debug.LogError("ScrollRect has to have a direction, please select either Horizontal OR Vertical with the appropriate control.");
		}
		ScrollRect scrollRect3 = pcu;
		if (scrollRect3.m_Horizontal && scrollRect3.m_Vertical)
		{
			Debug.LogError("ScrollRect has to be unidirectional, only use either Horizontal or Vertical on the ScrollRect, NOT both.");
		}
		RectTransform content = gameObject.GetComponent<ScrollRect>().m_Content;
		int num2 = 0;
		int num3;
		if (content != (Object)num2)
		{
			int childCount = content.childCount;
			if (childCount != 0 || (long)ChildObjects != 0)
			{
				GameObject[] childObjects = ChildObjects;
				if (childObjects != null)
				{
					num3 = childObjects.Length;
					if (num3 != 0)
					{
						goto IL_00c3;
					}
				}
				num3 = childCount;
				goto IL_00c3;
			}
		}
		goto IL_00e6;
		IL_00c3:
		int startingScreen = StartingScreen;
		if (startingScreen > num3)
		{
			StartingScreen = num3;
			startingScreen = num3;
		}
		StartingScreen = 0;
		goto IL_00e6;
		IL_00e6:
		int num4 = 0;
		MaskBuffer = 1f;
		float pageStep = PageStep;
		if (!((float)num4 <= pageStep))
		{
			PageStep = 0f;
			int num5 = 0;
		}
		PageStep = 9f;
	}

	[Token(Token = "0x60010BD")]
	[Address(RVA = "0x481130", Offset = "0x480130", VA = "0x180481130", Slot = "9")]
	public void eok()
	{
		if (!pdd)
		{
			pdd = true;
			m_OnSelectionChangeStartEvent.Invoke();
		}
	}

	[Token(Token = "0x60010BE")]
	[Address(RVA = "0x482930", Offset = "0x481930", VA = "0x180482930")]
	internal void eqn()
	{
		//IL_0015: Expected VT, but got I4
		SelectionPageChangedEvent onSelectionPageChangedEvent = m_OnSelectionPageChangedEvent;
		int num = pda;
		((UnityEvent<T0>)(object)onSelectionPageChangedEvent).Invoke((T0)num);
	}

	[Token(Token = "0x60010BF")]
	[Address(RVA = "0x482980", Offset = "0x481980", VA = "0x180482980")]
	internal void eqo()
	{
		//IL_0015: Expected VT, but got I4
		SelectionChangeEndEvent onSelectionChangeEndEvent = m_OnSelectionChangeEndEvent;
		int num = pda;
		((UnityEvent<T0>)(object)onSelectionChangeEndEvent).Invoke((T0)num);
		pcy = true;
		pdd = false;
	}

	[Token(Token = "0x60010C0")]
	[Address(RVA = "0x4829E0", Offset = "0x4819E0", VA = "0x1804829E0")]
	public Transform eqp()
	{
		RectTransform rectTransform = pcm;
		int index = pda;
		return rectTransform.GetChild(index);
	}

	[Token(Token = "0x60010C1")]
	[Address(RVA = "0x482A10", Offset = "0x481A10", VA = "0x180482A10")]
	public void eqq(out Transform returnObject)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010C2")]
	[Address(RVA = "0x480C90", Offset = "0x47FC90", VA = "0x180480C90", Slot = "4")]
	public void OnBeginDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010C3")]
	[Address(RVA = "0x480D00", Offset = "0x47FD00", VA = "0x180480D00", Slot = "5")]
	public void OnDrag(PointerEventData eventData)
	{
		pcw = false;
	}

	[Token(Token = "0x60010C4")]
	[Address(RVA = "0x482A40", Offset = "0x481A40", VA = "0x180482A40", Slot = "8")]
	private int eqr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010C5")]
	[Address(RVA = "0x481120", Offset = "0x480120", VA = "0x180481120", Slot = "7")]
	public void eoi(bool value)
	{
		pcw = value;
	}

	[Token(Token = "0x60010C6")]
	[Address(RVA = "0x481060", Offset = "0x480060", VA = "0x180481060", Slot = "6")]
	public void eoh(int page)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010C7")]
	[Address(RVA = "0x480F60", Offset = "0x47FF60", VA = "0x180480F60")]
	public ScrollSnapBase()
	{
		//IL_0009: Expected I4, but got I8
		//IL_0030: Expected I4, but got I8
		//IL_003a: Expected I4, but got I8
	}

	[Token(Token = "0x60010C8")]
	[Address(RVA = "0x481E40", Offset = "0x480E40", VA = "0x180481E40")]
	[CompilerGenerated]
	private void eqs()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010C9")]
	[Address(RVA = "0x481F00", Offset = "0x480F00", VA = "0x180481F00")]
	[CompilerGenerated]
	private void eqt()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
