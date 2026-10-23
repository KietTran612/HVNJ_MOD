using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200020D")]
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("Layout/Extensions/Vertical Scroll Snap")]
public class VerticalScrollSnap : ScrollSnapBase, IEndDragHandler, IEventSystemHandler
{
	[Token(Token = "0x6001108")]
	[Address(RVA = "0x435970", Offset = "0x434970", VA = "0x180435970")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001109")]
	[Address(RVA = "0x435A00", Offset = "0x434A00", VA = "0x180435A00")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600110A")]
	[Address(RVA = "0x435D50", Offset = "0x434D50", VA = "0x180435D50")]
	private bool esd(float startingSpeed)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600110B")]
	[Address(RVA = "0x435DB0", Offset = "0x434DB0", VA = "0x180435DB0")]
	public void ese()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600110C")]
	[Address(RVA = "0x436080", Offset = "0x435080", VA = "0x180436080")]
	public void esf(GameObject GO)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600110D")]
	[Address(RVA = "0x4361B0", Offset = "0x4351B0", VA = "0x1804361B0")]
	public void esg(GameObject GO, bool WorldPositionStays)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600110E")]
	[Address(RVA = "0x4362F0", Offset = "0x4352F0", VA = "0x1804362F0")]
	public void esh(int index, out GameObject ChildRemoved)
	{
		int worldPositionStays = 0;
		esi(index, (byte)worldPositionStays != 0, out ChildRemoved);
	}

	[Token(Token = "0x600110F")]
	[Address(RVA = "0x436310", Offset = "0x435310", VA = "0x180436310")]
	public void esi(int index, bool WorldPositionStays, out GameObject ChildRemoved)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001110")]
	[Address(RVA = "0x4364C0", Offset = "0x4354C0", VA = "0x1804364C0")]
	public void esj(out GameObject[] ChildrenRemoved)
	{
		int worldPositionStays = 0;
		esk((byte)worldPositionStays != 0, out ChildrenRemoved);
	}

	[Token(Token = "0x6001111")]
	[Address(RVA = "0x4364D0", Offset = "0x4354D0", VA = "0x1804364D0")]
	public void esk(bool WorldPositionStays, out GameObject[] ChildrenRemoved)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001112")]
	[Address(RVA = "0x4366D0", Offset = "0x4356D0", VA = "0x1804366D0")]
	private void esl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001113")]
	[Address(RVA = "0x436740", Offset = "0x435740", VA = "0x180436740")]
	public void esm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001114")]
	[Address(RVA = "0x435900", Offset = "0x434900", VA = "0x180435900")]
	private void OnRectTransformDimensionsChange()
	{
		float y = pct.y;
		int num = 0;
		Vector2 zero = Vector2.zero;
		esm();
	}

	[Token(Token = "0x6001115")]
	[Address(RVA = "0x435580", Offset = "0x434580", VA = "0x180435580")]
	private void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001116")]
	[Address(RVA = "0x435690", Offset = "0x434690", VA = "0x180435690", Slot = "10")]
	public void OnEndDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001117")]
	[Address(RVA = "0x435D40", Offset = "0x434D40", VA = "0x180435D40")]
	public VerticalScrollSnap()
	{
	}
}
