using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Token(Token = "0x2000172")]
public class ReportRadialTouch : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400189C")]
	public Text OutputField;

	[Token(Token = "0x6000D21")]
	[Address(RVA = "0x44F5E0", Offset = "0x44E5E0", VA = "0x18044F5E0", Slot = "4")]
	public void OnPointerEnter(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D22")]
	[Address(RVA = "0x44F350", Offset = "0x44E350", VA = "0x18044F350", Slot = "5")]
	public void OnPointerDown(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D23")]
	[Address(RVA = "0x44F870", Offset = "0x44E870", VA = "0x18044F870", Slot = "6")]
	public void OnPointerUp(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D24")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ReportRadialTouch()
	{
	}
}
