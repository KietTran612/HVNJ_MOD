using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000206")]
public class ScrollSnapScrollbarHelper : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001B8D")]
	internal oz pdj;

	[Token(Token = "0x60010CD")]
	[Address(RVA = "0x482AB0", Offset = "0x481AB0", VA = "0x180482AB0", Slot = "6")]
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (pdj != null)
		{
			oz oz2 = pdj;
		}
	}

	[Token(Token = "0x60010CE")]
	[Address(RVA = "0x482B20", Offset = "0x481B20", VA = "0x180482B20", Slot = "8")]
	public void OnDrag(PointerEventData eventData)
	{
		oz oz2 = pdj;
		throw new NullReferenceException();
	}

	[Token(Token = "0x60010CF")]
	[Address(RVA = "0x482B70", Offset = "0x481B70", VA = "0x180482B70", Slot = "7")]
	public void OnEndDrag(PointerEventData eventData)
	{
		eqv();
	}

	[Token(Token = "0x60010D0")]
	[Address(RVA = "0x482AB0", Offset = "0x481AB0", VA = "0x180482AB0", Slot = "4")]
	public void OnPointerDown(PointerEventData eventData)
	{
		if (pdj != null)
		{
			oz oz2 = pdj;
		}
	}

	[Token(Token = "0x60010D1")]
	[Address(RVA = "0x482B70", Offset = "0x481B70", VA = "0x180482B70", Slot = "5")]
	public void OnPointerUp(PointerEventData eventData)
	{
		eqv();
	}

	[Token(Token = "0x60010D2")]
	[Address(RVA = "0x482AB0", Offset = "0x481AB0", VA = "0x180482AB0")]
	private void equ()
	{
		if (pdj != null)
		{
			oz oz2 = pdj;
		}
	}

	[Token(Token = "0x60010D3")]
	[Address(RVA = "0x482B80", Offset = "0x481B80", VA = "0x180482B80")]
	private void eqv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010D4")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ScrollSnapScrollbarHelper()
	{
	}
}
