using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200022C")]
[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("UI/Extensions/UI Window Base")]
public class UIWindowBase : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C7C")]
	private RectTransform pgw;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C7D")]
	private bool pgx;

	[Token(Token = "0x4001C7E")]
	public static bool ResetCoords;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001C7F")]
	private Vector3 pgy;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001C80")]
	private Canvas pgz;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001C81")]
	private RectTransform pha;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001C82")]
	public int KeepWindowInCanvas;

	[Token(Token = "0x6001203")]
	[Address(RVA = "0x42B600", Offset = "0x42A600", VA = "0x18042B600")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001204")]
	[Address(RVA = "0x42B6A0", Offset = "0x42A6A0", VA = "0x18042B6A0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001205")]
	[Address(RVA = "0x42B460", Offset = "0x42A460", VA = "0x18042B460", Slot = "5")]
	public void OnDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001206")]
	[Address(RVA = "0x42B3A0", Offset = "0x42A3A0", VA = "0x18042B3A0", Slot = "4")]
	public void OnBeginDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001207")]
	[Address(RVA = "0x42B5F0", Offset = "0x42A5F0", VA = "0x18042B5F0", Slot = "6")]
	public void OnEndDrag(PointerEventData eventData)
	{
		pgx = false;
	}

	[Token(Token = "0x6001208")]
	[Address(RVA = "0x42B7C0", Offset = "0x42A7C0", VA = "0x18042B7C0")]
	private void eys()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001209")]
	[Address(RVA = "0x42B850", Offset = "0x42A850", VA = "0x18042B850")]
	private Vector3 eyt(Vector3 screenPosition)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600120A")]
	[Address(RVA = "0x42B780", Offset = "0x42A780", VA = "0x18042B780")]
	public unsafe UIWindowBase()
	{
		//IL_0012: Expected native int or pointer, but got VT
		//IL_0020: Expected I4, but got I8
		float z = Vector3.zero.z;
		((Vector3*)(nint)pgy)->z = z;
		KeepWindowInCanvas = 5;
		((Behaviour)this)._002Ector();
	}

	[Token(Token = "0x600120B")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static UIWindowBase()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
