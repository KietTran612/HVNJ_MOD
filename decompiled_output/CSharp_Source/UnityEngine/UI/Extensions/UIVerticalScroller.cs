using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200020A")]
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("Layout/Extensions/Vertical Scroller")]
public class UIVerticalScroller : MonoBehaviour
{
	[Serializable]
	[Token(Token = "0x200020B")]
	public class IntEvent : UnityEvent<int>
	{
		[Token(Token = "0x6001105")]
		[Address(RVA = "0x2741D0", Offset = "0x2731D0", VA = "0x1802741D0")]
		public IntEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Token(Token = "0x200020C")]
	[CompilerGenerated]
	private sealed class pf
	{
		[Cpp2IlInjected.FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001BAF")]
		public int pdn;

		[Cpp2IlInjected.FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001BB0")]
		public UIVerticalScroller pdo;

		[Token(Token = "0x6001106")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public pf()
		{
		}

		[Token(Token = "0x6001107")]
		[Address(RVA = "0x27C7E0", Offset = "0x27B7E0", VA = "0x18027C7E0")]
		internal void erq()
		{
			//IL_001a: Expected VT, but got I4
			IntEvent onButtonClicked = pdo.OnButtonClicked;
			int num = pdn;
			((UnityEvent<T0>)(object)onButtonClicked).Invoke((T0)num);
		}
	}

	[Cpp2IlInjected.FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001B9E")]
	[Tooltip("desired ScrollRect")]
	public ScrollRect scrollRect;

	[Cpp2IlInjected.FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001B9F")]
	[Tooltip("Center display area (position of zoomed content)")]
	public RectTransform center;

	[Cpp2IlInjected.FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001BA0")]
	[Tooltip("Size / spacing of elements")]
	public RectTransform elementSize;

	[Cpp2IlInjected.FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001BA1")]
	[Tooltip("Scale = 1/ (1+distance fom center * shrinkage)")]
	public Vector2 elementShrinkage = (Vector2)1000593162;

	[Cpp2IlInjected.FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001BA2")]
	[Tooltip("Minimum element scale (furthest from center)")]
	public Vector2 minScale;

	[Cpp2IlInjected.FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001BA3")]
	[Tooltip("Select the item to be in center on start.")]
	public int startingIndex;

	[Cpp2IlInjected.FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001BA4")]
	[Tooltip("Stop scrolling past last element from inertia.")]
	public bool stopMomentumOnEnd;

	[Cpp2IlInjected.FieldOffset(Offset = "0x45")]
	[Token(Token = "0x4001BA5")]
	[Tooltip("Set Items out of center to not interactible.")]
	public bool disableUnfocused;

	[Cpp2IlInjected.FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001BA6")]
	[Tooltip("Button to go to the next page. (optional)")]
	public GameObject scrollUpButton;

	[Cpp2IlInjected.FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001BA7")]
	[Tooltip("Button to go to the previous page. (optional)")]
	public GameObject scrollDownButton;

	[Cpp2IlInjected.FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001BA8")]
	[Tooltip("Event fired when a specific item is clicked, exposes index number of item. (optional)")]
	public IntEvent OnButtonClicked;

	[Cpp2IlInjected.FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001BA9")]
	[Tooltip("Event fired when the focused item is Changed. (optional)")]
	public IntEvent OnFocusChanged;

	[Cpp2IlInjected.FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001BAA")]
	[HideInInspector]
	public GameObject[] _arrayOfElements;

	[Cpp2IlInjected.FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001BAD")]
	private float[] pdr;

	[Cpp2IlInjected.FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001BAE")]
	private float[] pds;

	[Token(Token = "0x170000BD")]
	[field: Cpp2IlInjected.FieldOffset(Offset = "0x70")]
	[field: Token(Token = "0x4001BAB")]
	public int pdp
	{
		[Token(Token = "0x60010F4")]
		[Address(RVA = "0x42A9E0", Offset = "0x4299E0", VA = "0x18042A9E0")]
		get;
		[Token(Token = "0x60010F5")]
		[Address(RVA = "0x42A9F0", Offset = "0x4299F0", VA = "0x18042A9F0")]
		private set;
	}

	[Token(Token = "0x170000BE")]
	[field: Cpp2IlInjected.FieldOffset(Offset = "0x78")]
	[field: Token(Token = "0x4001BAC")]
	public string pdq
	{
		[Token(Token = "0x60010F6")]
		[Address(RVA = "0x40DEA0", Offset = "0x40CEA0", VA = "0x18040DEA0")]
		get;
		[Token(Token = "0x60010F7")]
		[Address(RVA = "0x40DEE0", Offset = "0x40CEE0", VA = "0x18040DEE0")]
		private set;
	}

	[Token(Token = "0x170000BF")]
	[HideInInspector]
	public RectTransform puy
	{
		[Token(Token = "0x60010F8")]
		[Address(RVA = "0x42AA00", Offset = "0x429A00", VA = "0x18042AA00")]
		get
		{
			return scrollRect.m_Content;
		}
	}

	[Token(Token = "0x60010F9")]
	[Address(RVA = "0x42A930", Offset = "0x429930", VA = "0x18042A930")]
	public unsafe UIVerticalScroller()
	{
		//IL_000d: Expected VT, but got I8
		//IL_0018: Expected native int or pointer, but got VT
		//IL_002a: Expected VT, but got I8
		//IL_0035: Expected native int or pointer, but got VT
		//IL_004a: Expected I4, but got I8
		((Vector2*)(nint)elementShrinkage)->y = 0.005f;
		minScale = (Vector2)1060320051;
		((Vector2*)(nint)minScale)->y = 0.7f;
		startingIndex = -1;
		stopMomentumOnEnd = true;
		((Behaviour)this)._002Ector();
	}

	[Token(Token = "0x60010FA")]
	[Address(RVA = "0x42A960", Offset = "0x429960", VA = "0x18042A960")]
	public unsafe UIVerticalScroller(RectTransform center, RectTransform elementSize, ScrollRect scrollRect, GameObject[] arrayOfElements)
	{
		//IL_000d: Expected VT, but got I8
		//IL_0018: Expected native int or pointer, but got VT
		//IL_002a: Expected VT, but got I8
		//IL_0035: Expected native int or pointer, but got VT
		//IL_004a: Expected I4, but got I8
		//IL_006c: Expected Obj, but got I4
		((Vector2*)(nint)elementShrinkage)->y = 0.005f;
		minScale = (Vector2)1060320051;
		((Vector2*)(nint)minScale)->y = 0.7f;
		startingIndex = -1;
		stopMomentumOnEnd = true;
		((Behaviour)this)._002Ector();
		this.center = center;
		this.scrollRect = scrollRect;
		_arrayOfElements = (GameObject[])0;
		this.elementSize = elementSize;
	}

	[Token(Token = "0x60010FB")]
	[Address(RVA = "0x429DC0", Offset = "0x428DC0", VA = "0x180429DC0")]
	public void Awake()
	{
		while (true)
		{
			if (!this.scrollRect)
			{
				ScrollRect component = GetComponent<ScrollRect>();
				this.scrollRect = component;
			}
			if (!center)
			{
				Debug.LogError("Please define the RectTransform for the Center viewport of the scrollable area");
			}
			if (!elementSize)
			{
				RectTransform rectTransform = center;
				elementSize = rectTransform;
			}
			GameObject[] arrayOfElements = _arrayOfElements;
			if (arrayOfElements == null || arrayOfElements.Length == 0)
			{
				GameObject[] arrayOfElements2 = new GameObject[this.scrollRect.m_Content.childCount];
				int num = 0;
				_arrayOfElements = arrayOfElements2;
				int childCount = this.scrollRect.m_Content.childCount;
				if (num < childCount)
				{
					ScrollRect scrollRect = this.scrollRect;
					GameObject[] arrayOfElements3 = _arrayOfElements;
					GameObject gameObject = scrollRect.m_Content.GetChild(num).gameObject;
					if ((object)gameObject == null || (object)gameObject != null)
					{
						num++;
						arrayOfElements3[0] = gameObject;
						ScrollRect scrollRect2 = this.scrollRect;
						break;
					}
					continue;
				}
				break;
			}
			break;
		}
	}

	[Token(Token = "0x60010FC")]
	[Address(RVA = "0x42AA20", Offset = "0x429A20", VA = "0x18042AA20")]
	public void erw([Optional][DefaultParameterValue(-1)] int startingIndex, [Optional] GameObject[] arrayOfElements)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010FD")]
	[Address(RVA = "0x42A020", Offset = "0x429020", VA = "0x18042A020")]
	public void Start()
	{
		if ((bool)scrollUpButton)
		{
			Button.ButtonClickedEvent onClick = scrollUpButton.GetComponent<Button>().m_OnClick;
			UnityAction call = [Token(Token = "0x6001103")] [Address(RVA = "0x42B1A0", Offset = "0x42A1A0", VA = "0x18042B1A0")] () =>
			{
				throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
			};
			onClick.AddListener(call);
		}
		if ((bool)scrollDownButton)
		{
			Button.ButtonClickedEvent onClick2 = scrollDownButton.GetComponent<Button>().m_OnClick;
			UnityAction call2 = [Token(Token = "0x6001104")] [Address(RVA = "0x42B2D0", Offset = "0x42A2D0", VA = "0x18042B2D0")] () =>
			{
				throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
			};
			onClick2.AddListener(call2);
		}
		GameObject[] arrayOfElements = _arrayOfElements;
		int num = startingIndex;
		erw(num, arrayOfElements);
	}

	[Token(Token = "0x60010FE")]
	[Address(RVA = "0x42A1D0", Offset = "0x4291D0", VA = "0x18042A1D0")]
	public void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010FF")]
	[Address(RVA = "0x42AFD0", Offset = "0x429FD0", VA = "0x18042AFD0")]
	private void erx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001100")]
	[Address(RVA = "0x42B0E0", Offset = "0x42A0E0", VA = "0x18042B0E0")]
	public void ery(int element)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001101")]
	[Address(RVA = "0x42B1A0", Offset = "0x42A1A0", VA = "0x18042B1A0")]
	public void erz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001102")]
	[Address(RVA = "0x42B2D0", Offset = "0x42A2D0", VA = "0x18042B2D0")]
	public void esa()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001103")]
	[Address(RVA = "0x42B1A0", Offset = "0x42A1A0", VA = "0x18042B1A0")]
	[CompilerGenerated]
	private void esb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001104")]
	[Address(RVA = "0x42B2D0", Offset = "0x42A2D0", VA = "0x18042B2D0")]
	[CompilerGenerated]
	private void esc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
