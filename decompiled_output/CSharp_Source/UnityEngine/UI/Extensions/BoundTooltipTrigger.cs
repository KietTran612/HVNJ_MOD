using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000226")]
[AddComponentMenu("UI/Extensions/Bound Tooltip/Bound Tooltip Trigger")]
public class BoundTooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C44")]
	[TextArea]
	public string text;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C45")]
	public bool useMousePosition;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001C46")]
	public Vector3 offset;

	[Token(Token = "0x60011D4")]
	[Address(RVA = "0x600BF0", Offset = "0x5FFBF0", VA = "0x180600BF0", Slot = "4")]
	public void OnPointerEnter(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011D5")]
	[Address(RVA = "0x600CD0", Offset = "0x5FFCD0", VA = "0x180600CD0", Slot = "6")]
	public void OnSelect(BaseEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011D6")]
	[Address(RVA = "0x600BB0", Offset = "0x5FFBB0", VA = "0x180600BB0", Slot = "5")]
	public void OnPointerExit(PointerEventData eventData)
	{
		int num = 0;
		GameObject gameObject = BoundTooltipItem.pwq.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
	}

	[Token(Token = "0x60011D7")]
	[Address(RVA = "0x600BB0", Offset = "0x5FFBB0", VA = "0x180600BB0", Slot = "7")]
	public void OnDeselect(BaseEventData eventData)
	{
		int num = 0;
		GameObject gameObject = BoundTooltipItem.pwq.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
	}

	[Token(Token = "0x60011D8")]
	[Address(RVA = "0x600D30", Offset = "0x5FFD30", VA = "0x180600D30")]
	private void exr(Vector3 position)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011D9")]
	[Address(RVA = "0x600BB0", Offset = "0x5FFBB0", VA = "0x180600BB0")]
	private void exs()
	{
		int num = 0;
		GameObject gameObject = BoundTooltipItem.pwq.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
	}

	[Token(Token = "0x60011DA")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public BoundTooltipTrigger()
	{
	}
}
