using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001C5")]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Text))]
[AddComponentMenu("UI/Effects/Extensions/Curly UI Text")]
public class CUIText : CUIGraphic
{
	[Token(Token = "0x6000F48")]
	[Address(RVA = "0x607900", Offset = "0x606900", VA = "0x180607900", Slot = "21")]
	public override void ehn()
	{
		//IL_0010: Expected Obj, but got I4
		Graphic graphic = uiGraphic;
		int num = 0;
		if (graphic == (Object)num)
		{
			Text component = GetComponent<Text>();
			uiGraphic = component;
		}
		base.ehn();
	}

	[Token(Token = "0x6000F49")]
	[Address(RVA = "0x6078A0", Offset = "0x6068A0", VA = "0x1806078A0")]
	public CUIText()
	{
	}
}
