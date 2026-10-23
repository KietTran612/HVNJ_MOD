using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000198")]
[RequireComponent(typeof(RectTransform), typeof(Button))]
public class oe
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x400194B")]
	public RectTransform osl;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400194C")]
	public Button osm;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400194D")]
	public Text osn;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400194E")]
	public Image oso;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400194F")]
	public Image osp;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001950")]
	public GameObject osq;

	[Token(Token = "0x6000DF9")]
	[Address(RVA = "0x27AE10", Offset = "0x279E10", VA = "0x18027AE10")]
	public oe(GameObject btnObj)
	{
		osq = btnObj;
		RectTransform component = btnObj.GetComponent<RectTransform>();
		osl = component;
		Image component2 = btnObj.GetComponent<Image>();
		oso = component2;
		Button component3 = btnObj.GetComponent<Button>();
		RectTransform rectTransform = osl;
		osm = component3;
		Text component4 = rectTransform.Find("Text").GetComponent<Text>();
		RectTransform rectTransform2 = osl;
		osn = component4;
		Image component5 = rectTransform2.Find("Image").GetComponent<Image>();
		osp = component5;
	}
}
