using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001F7")]
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("Layout/Extensions/Horizontal Scroll Snap")]
public class HorizontalScrollSnap : ScrollSnapBase, IEndDragHandler, IEventSystemHandler
{
	[Token(Token = "0x600105A")]
	[Address(RVA = "0x43D360", Offset = "0x43C360", VA = "0x18043D360")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600105B")]
	[Address(RVA = "0x43D3F0", Offset = "0x43C3F0", VA = "0x18043D3F0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600105C")]
	[Address(RVA = "0x43D730", Offset = "0x43C730", VA = "0x18043D730")]
	private bool enx(float startingSpeed)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600105D")]
	[Address(RVA = "0x43D790", Offset = "0x43C790", VA = "0x18043D790")]
	public void eny()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600105E")]
	[Address(RVA = "0x43DA60", Offset = "0x43CA60", VA = "0x18043DA60")]
	public void enz(GameObject GO)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600105F")]
	[Address(RVA = "0x43DB90", Offset = "0x43CB90", VA = "0x18043DB90")]
	public void eoa(GameObject GO, bool WorldPositionStays)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001060")]
	[Address(RVA = "0x43DCD0", Offset = "0x43CCD0", VA = "0x18043DCD0")]
	public void eob(int index, out GameObject ChildRemoved)
	{
		int worldPositionStays = 0;
		eoc(index, (byte)worldPositionStays != 0, out ChildRemoved);
	}

	[Token(Token = "0x6001061")]
	[Address(RVA = "0x43DCF0", Offset = "0x43CCF0", VA = "0x18043DCF0")]
	public void eoc(int index, bool WorldPositionStays, out GameObject ChildRemoved)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001062")]
	[Address(RVA = "0x43DEA0", Offset = "0x43CEA0", VA = "0x18043DEA0")]
	public void eod(out GameObject[] ChildrenRemoved)
	{
		int worldPositionStays = 0;
		eoe((byte)worldPositionStays != 0, out ChildrenRemoved);
	}

	[Token(Token = "0x6001063")]
	[Address(RVA = "0x43DEB0", Offset = "0x43CEB0", VA = "0x18043DEB0")]
	public void eoe(bool WorldPositionStays, out GameObject[] ChildrenRemoved)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001064")]
	[Address(RVA = "0x43E0B0", Offset = "0x43D0B0", VA = "0x18043E0B0")]
	private void eof()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001065")]
	[Address(RVA = "0x43E120", Offset = "0x43D120", VA = "0x18043E120")]
	public void eog()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001066")]
	[Address(RVA = "0x43D2F0", Offset = "0x43C2F0", VA = "0x18043D2F0")]
	private void OnRectTransformDimensionsChange()
	{
		float y = pct.y;
		int num = 0;
		Vector2 zero = Vector2.zero;
		eog();
	}

	[Token(Token = "0x6001067")]
	[Address(RVA = "0x43CF70", Offset = "0x43BF70", VA = "0x18043CF70")]
	private void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001068")]
	[Address(RVA = "0x43D080", Offset = "0x43C080", VA = "0x18043D080", Slot = "10")]
	public void OnEndDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001069")]
	[Address(RVA = "0x435D40", Offset = "0x434D40", VA = "0x180435D40")]
	public HorizontalScrollSnap()
	{
	}
}
