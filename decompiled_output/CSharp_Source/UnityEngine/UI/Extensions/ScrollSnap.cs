using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001FF")]
[ExecuteInEditMode]
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("UI/Extensions/Scroll Snap")]
public class ScrollSnap : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, oz
{
	[Token(Token = "0x2000200")]
	public enum pd
	{
		[Token(Token = "0x4001B5F")]
		Horizontal,
		[Token(Token = "0x4001B60")]
		Vertical
	}

	[Token(Token = "0x2000201")]
	public delegate void PageSnapChange(int page);

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001B3E")]
	private ScrollRect pbo;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001B3F")]
	private RectTransform pbp;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001B40")]
	private Transform pbq;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001B41")]
	private int pbr;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001B42")]
	private int pbs;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001B43")]
	private Vector3[] pbt;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001B44")]
	private Vector3 pbu;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4001B45")]
	private bool pbv;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001B46")]
	private float pbw;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001B47")]
	private float pbx;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001B48")]
	private float pby;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001B49")]
	private RectTransform pbz;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001B4A")]
	private Vector2 pca;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001B4B")]
	private float pcb;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001B4C")]
	private int pcc;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001B4D")]
	private bool pcd = true;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4001B4E")]
	private Vector3 pce;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001B4F")]
	private int pcf;

	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4001B50")]
	private bool pcg;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001B51")]
	private int pch;

	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4001B52")]
	private int pci = 10;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001B53")]
	[Tooltip("Button to go to the next page. (optional)")]
	public Button NextButton;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4001B54")]
	[Tooltip("Button to go to the previous page. (optional)")]
	public Button PrevButton;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4001B55")]
	[Tooltip("Number of items visible in one page of scroll frame.")]
	[Range(1f, 100f)]
	public int ItemsVisibleAtOnce = 1;

	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x4001B56")]
	[Tooltip("Sets minimum width of list items to 1/itemsVisibleAtOnce.")]
	public bool AutoLayoutItems = true;

	[FieldOffset(Offset = "0xAD")]
	[Token(Token = "0x4001B57")]
	[Tooltip("If you wish to update scrollbar numberOfSteps to number of active children on list.")]
	public bool LinkScrolbarSteps;

	[FieldOffset(Offset = "0xAE")]
	[Token(Token = "0x4001B58")]
	[Tooltip("If you wish to update scrollrect sensitivity to size of list element.")]
	public bool LinkScrolrectScrollSensitivity;

	[FieldOffset(Offset = "0xAF")]
	[Token(Token = "0x4001B59")]
	public bool UseFastSwipe = true;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001B5A")]
	public int FastSwipeThreshold = 100;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4001B5B")]
	[CompilerGenerated]
	private PageSnapChange m_pcj;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4001B5C")]
	public pd direction;

	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x4001B5D")]
	private bool pck;

	[Token(Token = "0x14000001")]
	public event PageSnapChange pcj
	{
		[Token(Token = "0x600108A")]
		[Address(RVA = "0x483700", Offset = "0x482700", VA = "0x180483700")]
		[CompilerGenerated]
		add
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x600108B")]
		[Address(RVA = "0x4837A0", Offset = "0x4827A0", VA = "0x1804837A0")]
		[CompilerGenerated]
		remove
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x600108C")]
	[Address(RVA = "0x483210", Offset = "0x482210", VA = "0x180483210")]
	private unsafe void Start()
	{
		//IL_00f5: Expected Obj, but got I4
		//IL_013a: Expected Obj, but got I4
		pbv = false;
		ScrollRect component = gameObject.GetComponent<ScrollRect>();
		pbo = component;
		RectTransform component2 = gameObject.GetComponent<RectTransform>();
		ScrollRect scrollRect = pbo;
		pbp = component2;
		RectTransform component3 = (pbq = scrollRect.m_Content).GetComponent<RectTransform>();
		pbz = component3;
		epg();
		eph();
		int currentPage = eoj();
		epo(currentPage);
		if ((bool)NextButton)
		{
			Button.ButtonClickedEvent onClick = NextButton.GetComponent<Button>().m_OnClick;
			UnityAction call = [Token(Token = "0x600109F")] [Address(RVA = "0x4846F0", Offset = "0x4836F0", VA = "0x1804846F0")] () =>
			{
				//IL_003d: Expected F4, but got I4
				//IL_0038: Expected native int or pointer, but got VT
				eph();
				int num3 = eoj();
				int num4 = pbr;
				if (num3 < num4)
				{
					Vector3[] array = pbt;
					pbv = true;
					int num5 = eoj();
					num5++;
					((Vector3*)(nint)pbu)->z = num5;
					int currentPage2 = eoj() + 1;
					epo(currentPage2);
				}
			};
			onClick.AddListener(call);
		}
		if ((bool)PrevButton)
		{
			Button.ButtonClickedEvent onClick2 = PrevButton.GetComponent<Button>().m_OnClick;
			UnityAction call2 = [Token(Token = "0x60010A0")] [Address(RVA = "0x484790", Offset = "0x483790", VA = "0x180484790")] () =>
			{
				//IL_0030: Expected F4, but got I4
				//IL_002b: Expected native int or pointer, but got VT
				eph();
				if (eoj() > 0)
				{
					Vector3[] array = pbt;
					pbv = true;
					int num3 = eoj();
					((Vector3*)(nint)pbu)->z = num3;
					int currentPage2 = eoj() - 1;
					epo(currentPage2);
				}
			};
			onClick2.AddListener(call2);
		}
		Scrollbar horizontalScrollbar = pbo.m_HorizontalScrollbar;
		int num = 0;
		if (horizontalScrollbar != (Object)num)
		{
			ScrollRect scrollRect2 = pbo;
			if (scrollRect2.m_Horizontal)
			{
				scrollRect2.m_HorizontalScrollbar.gameObject.fae<ScrollSnapScrollbarHelper>().pdj = this;
			}
		}
		Scrollbar verticalScrollbar = pbo.m_VerticalScrollbar;
		int num2 = 0;
		if (verticalScrollbar != (Object)num2)
		{
			ScrollRect scrollRect3 = pbo;
			if (scrollRect3.m_Vertical)
			{
				scrollRect3.m_VerticalScrollbar.gameObject.fae<ScrollSnapScrollbarHelper>().pdj = this;
			}
		}
	}

	[Token(Token = "0x600108D")]
	[Address(RVA = "0x483840", Offset = "0x482840", VA = "0x180483840")]
	public void epg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600108E")]
	[Address(RVA = "0x483DA0", Offset = "0x482DA0", VA = "0x180483DA0")]
	public void eph()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600108F")]
	[Address(RVA = "0x4844A0", Offset = "0x4834A0", VA = "0x1804844A0")]
	public void epi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001090")]
	[Address(RVA = "0x484530", Offset = "0x483530", VA = "0x180484530")]
	private void epj(bool linkSteps)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001091")]
	[Address(RVA = "0x482C70", Offset = "0x481C70", VA = "0x180482C70")]
	private void LateUpdate()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001092")]
	[Address(RVA = "0x4846F0", Offset = "0x4836F0", VA = "0x1804846F0")]
	public unsafe void epk()
	{
		//IL_003d: Expected F4, but got I4
		//IL_0038: Expected native int or pointer, but got VT
		eph();
		int num = eoj();
		int num2 = pbr;
		if (num < num2)
		{
			Vector3[] array = pbt;
			pbv = true;
			int num3 = eoj();
			num3++;
			((Vector3*)(nint)pbu)->z = num3;
			int currentPage = eoj() + 1;
			epo(currentPage);
		}
	}

	[Token(Token = "0x6001093")]
	[Address(RVA = "0x484790", Offset = "0x483790", VA = "0x180484790")]
	public unsafe void epl()
	{
		//IL_0030: Expected F4, but got I4
		//IL_002b: Expected native int or pointer, but got VT
		eph();
		if (eoj() > 0)
		{
			Vector3[] array = pbt;
			pbv = true;
			int num = eoj();
			((Vector3*)(nint)pbu)->z = num;
			int currentPage = eoj() - 1;
			epo(currentPage);
		}
	}

	[Token(Token = "0x6001094")]
	[Address(RVA = "0x484830", Offset = "0x483830", VA = "0x180484830")]
	private unsafe void epm()
	{
		//IL_0034: Expected F4, but got I4
		//IL_002f: Expected native int or pointer, but got VT
		int num = pbr;
		int num2 = pcf;
		if (num2 < num)
		{
			int num3 = Mathf.Min(num, num2);
			Vector3[] array = pbt;
			pbv = true;
			((Vector3*)(nint)pbu)->z = num3;
			epo(num3);
		}
	}

	[Token(Token = "0x6001095")]
	[Address(RVA = "0x4848C0", Offset = "0x4838C0", VA = "0x1804848C0")]
	private unsafe void epn()
	{
		//IL_002d: Expected F4, but got I4
		//IL_0028: Expected native int or pointer, but got VT
		int num = pcf;
		if (num > 0)
		{
			int num2 = Mathf.Max(0, num);
			Vector3[] array = pbt;
			pbv = true;
			((Vector3*)(nint)pbu)->z = num2;
			epo(num2);
		}
	}

	[Token(Token = "0x6001096")]
	[Address(RVA = "0x483650", Offset = "0x482650", VA = "0x180483650", Slot = "9")]
	public int eoj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001097")]
	[Address(RVA = "0x483640", Offset = "0x482640", VA = "0x180483640", Slot = "8")]
	public void eoi(bool value)
	{
		pbv = value;
	}

	[Token(Token = "0x6001098")]
	[Address(RVA = "0x4835D0", Offset = "0x4825D0", VA = "0x1804835D0", Slot = "7")]
	public unsafe void eoh(int page)
	{
		//IL_0023: Expected F4, but got I4
		//IL_001e: Expected native int or pointer, but got VT
		if (page < pbr)
		{
			Vector3[] array = pbt;
			pbv = true;
			((Vector3*)(nint)pbu)->z = page;
			epo(page);
		}
	}

	[Token(Token = "0x6001099")]
	[Address(RVA = "0x484940", Offset = "0x483940", VA = "0x180484940")]
	private void epo(int currentPage)
	{
		Button nextButton = NextButton;
		pbs = currentPage;
		if ((bool)nextButton)
		{
			Button nextButton2 = NextButton;
			int num = pbr;
			bool interactable = currentPage < num;
			nextButton2.interactable = interactable;
		}
		if ((bool)PrevButton)
		{
			Button prevButton = PrevButton;
			bool interactable2 = currentPage > 0;
			prevButton.interactable = interactable2;
		}
		this.m_pcj?.Invoke(currentPage);
	}

	[Token(Token = "0x600109A")]
	[Address(RVA = "0x482EB0", Offset = "0x481EB0", VA = "0x180482EB0", Slot = "4")]
	public unsafe void OnBeginDrag(PointerEventData eventData)
	{
		//IL_0012: Expected I4, but got I8
		//IL_0027: Expected F4, but got I4
		//IL_0022: Expected native int or pointer, but got VT
		int linkSteps = 0;
		epj((byte)linkSteps != 0);
		pch = 0;
		pcg = true;
		int num = 0;
		((Vector3*)(nint)pce)->z = num;
		int num2 = eoj();
		pcf = num2;
	}

	[Token(Token = "0x600109B")]
	[Address(RVA = "0x482FC0", Offset = "0x481FC0", VA = "0x180482FC0", Slot = "5")]
	public void OnEndDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600109C")]
	[Address(RVA = "0x482F30", Offset = "0x481F30", VA = "0x180482F30", Slot = "6")]
	public unsafe void OnDrag(PointerEventData eventData)
	{
		//IL_0022: Expected I4, but got I8
		//IL_0037: Expected F4, but got I4
		//IL_0032: Expected native int or pointer, but got VT
		pbv = false;
		if (pcd)
		{
			int linkSteps = 0;
			epj((byte)linkSteps != 0);
			pch = 0;
			pcg = true;
			int num = 0;
			((Vector3*)(nint)pce)->z = num;
			int num2 = eoj();
			pcf = num2;
			pcd = false;
		}
	}

	[Token(Token = "0x600109D")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "10")]
	public void eok()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600109E")]
	[Address(RVA = "0x483590", Offset = "0x482590", VA = "0x180483590")]
	public ScrollSnap()
	{
		//IL_0011: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
		//IL_0032: Expected I4, but got I8
	}

	[Token(Token = "0x600109F")]
	[Address(RVA = "0x4846F0", Offset = "0x4836F0", VA = "0x1804846F0")]
	[CompilerGenerated]
	private unsafe void epp()
	{
		//IL_003d: Expected F4, but got I4
		//IL_0038: Expected native int or pointer, but got VT
		eph();
		int num = eoj();
		int num2 = pbr;
		if (num < num2)
		{
			Vector3[] array = pbt;
			pbv = true;
			int num3 = eoj();
			num3++;
			((Vector3*)(nint)pbu)->z = num3;
			int currentPage = eoj() + 1;
			epo(currentPage);
		}
	}

	[Token(Token = "0x60010A0")]
	[Address(RVA = "0x484790", Offset = "0x483790", VA = "0x180484790")]
	[CompilerGenerated]
	private unsafe void epq()
	{
		//IL_0030: Expected F4, but got I4
		//IL_002b: Expected native int or pointer, but got VT
		eph();
		if (eoj() > 0)
		{
			Vector3[] array = pbt;
			pbv = true;
			int num = eoj();
			((Vector3*)(nint)pbu)->z = num;
			int currentPage = eoj() - 1;
			epo(currentPage);
		}
	}
}
