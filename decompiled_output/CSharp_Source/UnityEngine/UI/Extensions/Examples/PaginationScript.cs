using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000287")]
public class PaginationScript : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DB6")]
	public HorizontalScrollSnap hss;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DB7")]
	public int Page;

	[Token(Token = "0x60013E2")]
	[Address(RVA = "0x448DC0", Offset = "0x447DC0", VA = "0x180448DC0", Slot = "4")]
	public void OnPointerClick(PointerEventData eventData)
	{
		//IL_0010: Expected Obj, but got I4
		HorizontalScrollSnap horizontalScrollSnap = hss;
		int num = 0;
		if (horizontalScrollSnap != (Object)num)
		{
			HorizontalScrollSnap horizontalScrollSnap2 = hss;
			int page = Page;
			horizontalScrollSnap2.eqf(page);
		}
	}

	[Token(Token = "0x60013E3")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public PaginationScript()
	{
	}
}
