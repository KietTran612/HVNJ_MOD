using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200024C")]
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("UI/Extensions/UIScrollToSelection")]
public class UIScrollToSelection : MonoBehaviour
{
	[Token(Token = "0x200024D")]
	public enum qi
	{
		[Token(Token = "0x4001CE5")]
		VERTICAL,
		[Token(Token = "0x4001CE6")]
		HORIZONTAL,
		[Token(Token = "0x4001CE7")]
		BOTH
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CDB")]
	[SerializeField]
	[Header("[ Settings ]")]
	private qi scrollDirection = qi.BOTH;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001CDC")]
	[SerializeField]
	private float scrollSpeed = 10f;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CDD")]
	[SerializeField]
	[Header("[ Input ]")]
	private bool cancelScrollOnInput;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001CDE")]
	[SerializeField]
	private List<KeyCode> cancelScrollKeycodes = (List<KeyCode>)(object)new List<T>();

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001CDF")]
	[CompilerGenerated]
	private RectTransform pjg__BackingField;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001CE0")]
	[CompilerGenerated]
	private ScrollRect pjh__BackingField;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001CE1")]
	[CompilerGenerated]
	private GameObject pji__BackingField;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001CE2")]
	[CompilerGenerated]
	private RectTransform pjj__BackingField;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001CE3")]
	[CompilerGenerated]
	private bool pjk__BackingField;

	[Token(Token = "0x1700010F")]
	protected RectTransform pxq
	{
		[Token(Token = "0x60012AF")]
		[Address(RVA = "0x428E40", Offset = "0x427E40", VA = "0x180428E40")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000110")]
	protected qi pxr
	{
		[Token(Token = "0x60012B0")]
		[Address(RVA = "0x274B10", Offset = "0x273B10", VA = "0x180274B10")]
		get
		{
			return scrollDirection;
		}
	}

	[Token(Token = "0x17000111")]
	protected float pxs
	{
		[Token(Token = "0x60012B1")]
		[Address(RVA = "0x428ED0", Offset = "0x427ED0", VA = "0x180428ED0")]
		get
		{
			return scrollSpeed;
		}
	}

	[Token(Token = "0x17000112")]
	protected bool pxt
	{
		[Token(Token = "0x60012B2")]
		[Address(RVA = "0x428EE0", Offset = "0x427EE0", VA = "0x180428EE0")]
		get
		{
			return cancelScrollOnInput;
		}
	}

	[Token(Token = "0x17000113")]
	protected List<KeyCode> pxu
	{
		[Token(Token = "0x60012B3")]
		[Address(RVA = "0x283C00", Offset = "0x282C00", VA = "0x180283C00")]
		get
		{
			return cancelScrollKeycodes;
		}
	}

	[Token(Token = "0x17000114")]
	protected RectTransform pjg
	{
		[Token(Token = "0x60012B4")]
		[Address(RVA = "0x374880", Offset = "0x373880", VA = "0x180374880")]
		[CompilerGenerated]
		get
		{
			return pjg__BackingField;
		}
		[Token(Token = "0x60012B5")]
		[Address(RVA = "0x3F3230", Offset = "0x3F2230", VA = "0x1803F3230")]
		[CompilerGenerated]
		set
		{
			pjg__BackingField = value;
		}
	}

	[Token(Token = "0x17000115")]
	protected ScrollRect pjh
	{
		[Token(Token = "0x60012B6")]
		[Address(RVA = "0x375280", Offset = "0x374280", VA = "0x180375280")]
		[CompilerGenerated]
		get
		{
			return pjh__BackingField;
		}
		[Token(Token = "0x60012B7")]
		[Address(RVA = "0x3F8E50", Offset = "0x3F7E50", VA = "0x1803F8E50")]
		[CompilerGenerated]
		set
		{
			pjh__BackingField = value;
		}
	}

	[Token(Token = "0x17000116")]
	protected EventSystem pxv
	{
		[Token(Token = "0x60012B8")]
		[Address(RVA = "0x428EF0", Offset = "0x427EF0", VA = "0x180428EF0")]
		get
		{
			int num = 0;
			return EventSystem.current;
		}
	}

	[Token(Token = "0x17000117")]
	protected GameObject pji
	{
		[Token(Token = "0x60012B9")]
		[Address(RVA = "0x3746A0", Offset = "0x3736A0", VA = "0x1803746A0")]
		[CompilerGenerated]
		get
		{
			return pji__BackingField;
		}
		[Token(Token = "0x60012BA")]
		[Address(RVA = "0x374720", Offset = "0x373720", VA = "0x180374720")]
		[CompilerGenerated]
		set
		{
			pji__BackingField = value;
		}
	}

	[Token(Token = "0x17000118")]
	protected GameObject pxx
	{
		[Token(Token = "0x60012BB")]
		[Address(RVA = "0x428F40", Offset = "0x427F40", VA = "0x180428F40")]
		get
		{
			int num = 0;
			return EventSystem.current.m_CurrentSelected;
		}
	}

	[Token(Token = "0x17000119")]
	protected RectTransform pjj
	{
		[Token(Token = "0x60012BC")]
		[Address(RVA = "0x40D8C0", Offset = "0x40C8C0", VA = "0x18040D8C0")]
		[CompilerGenerated]
		get
		{
			return pjj__BackingField;
		}
		[Token(Token = "0x60012BD")]
		[Address(RVA = "0x3FECC0", Offset = "0x3FDCC0", VA = "0x1803FECC0")]
		[CompilerGenerated]
		set
		{
			pjj__BackingField = value;
		}
	}

	[Token(Token = "0x1700011A")]
	protected bool pjk
	{
		[Token(Token = "0x60012BE")]
		[Address(RVA = "0x337740", Offset = "0x336740", VA = "0x180337740")]
		[CompilerGenerated]
		get
		{
			return pjk__BackingField;
		}
		[Token(Token = "0x60012BF")]
		[Address(RVA = "0x3E94E0", Offset = "0x3E84E0", VA = "0x1803E94E0")]
		[CompilerGenerated]
		set
		{
			pjk__BackingField = value;
		}
	}

	[Token(Token = "0x60012C0")]
	[Address(RVA = "0x428C70", Offset = "0x427C70", VA = "0x180428C70", Slot = "4")]
	protected virtual void Awake()
	{
		RectTransform component = (pjh__BackingField = GetComponent<ScrollRect>()).GetComponent<RectTransform>();
		pjg__BackingField = component;
	}

	[Token(Token = "0x60012C1")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
	protected virtual void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012C2")]
	[Address(RVA = "0x428CE0", Offset = "0x427CE0", VA = "0x180428CE0", Slot = "6")]
	protected virtual void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012C3")]
	[Address(RVA = "0x428FA0", Offset = "0x427FA0", VA = "0x180428FA0")]
	private void fcz()
	{
		//IL_003b: Expected Obj, but got I4
		//IL_005d: Expected Obj, but got I4
		//IL_0078: Expected Obj, but got I4
		int num = 0;
		GameObject currentSelected = EventSystem.current.m_CurrentSelected;
		GameObject gameObject = pji__BackingField;
		if (currentSelected != gameObject)
		{
			int num2 = 0;
			GameObject currentSelected2 = EventSystem.current.m_CurrentSelected;
			int num3 = 0;
			if (currentSelected2 != (Object)num3)
			{
				int num4 = 0;
				RectTransform component = EventSystem.current.m_CurrentSelected.GetComponent<RectTransform>();
			}
			int num5 = 0;
			pjj__BackingField = (RectTransform)num5;
			int num6 = 0;
			GameObject currentSelected3 = EventSystem.current.m_CurrentSelected;
			int num7 = 0;
			if (currentSelected3 != (Object)num7)
			{
				int num8 = 0;
				Transform parent = EventSystem.current.m_CurrentSelected.transform.parent;
				Transform transform = pxq.transform;
				if (parent == transform)
				{
					pjk__BackingField = false;
				}
			}
		}
		int num9 = 0;
		GameObject currentSelected4 = EventSystem.current.m_CurrentSelected;
		pji__BackingField = currentSelected4;
	}

	[Token(Token = "0x60012C4")]
	[Address(RVA = "0x429300", Offset = "0x428300", VA = "0x180429300")]
	private void fda()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012C5")]
	[Address(RVA = "0x4293C0", Offset = "0x4283C0", VA = "0x1804293C0")]
	private void fdb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012C6")]
	[Address(RVA = "0x429620", Offset = "0x428620", VA = "0x180429620")]
	private void fdc(RectTransform selection)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012C7")]
	[Address(RVA = "0x429820", Offset = "0x428820", VA = "0x180429820")]
	private void fdd(RectTransform selection)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012C8")]
	[Address(RVA = "0x429A30", Offset = "0x428A30", VA = "0x180429A30")]
	private float fde(float position, float listAnchorPosition, float targetLength, float maskLength)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012C9")]
	[Address(RVA = "0x428DC0", Offset = "0x427DC0", VA = "0x180428DC0")]
	public UIScrollToSelection()
	{
		//IL_0009: Expected I4, but got I8
	}
}
