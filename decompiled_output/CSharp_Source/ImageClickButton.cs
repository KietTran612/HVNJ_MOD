using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Token(Token = "0x20000C2")]
public class ImageClickButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerClickHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000AEF")]
	public int ID;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000AF0")]
	public Vector2 pos;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000AF1")]
	public i action;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000AF2")]
	public i actionDown;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000AF3")]
	public i actionUp;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000AF4")]
	public string subName;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000AF5")]
	public Image image;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000AF6")]
	public RectTransform rect;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000AF7")]
	public sbyte indexSound = -1;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000AF8")]
	public Sprite spr;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000AF9")]
	public Sprite sprClick;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000AFA")]
	public bool isClick;

	[FieldOffset(Offset = "0x71")]
	[Token(Token = "0x4000AFB")]
	public bool isUp;

	[FieldOffset(Offset = "0x72")]
	[Token(Token = "0x4000AFC")]
	public bool isHighlight;

	[FieldOffset(Offset = "0x73")]
	[Token(Token = "0x4000AFD")]
	public bool isEnter;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000AFE")]
	public bool isRun;

	[FieldOffset(Offset = "0x75")]
	[Token(Token = "0x4000AFF")]
	public bool isAbleTouchKey;

	[FieldOffset(Offset = "0x76")]
	[Token(Token = "0x4000B00")]
	public bool isMoveTest;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000B01")]
	public Color colorClick;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000B02")]
	public Color colorMain;

	[Token(Token = "0x4000B03")]
	private static Color jlz;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000B04")]
	public PointerEventData eventData;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000B05")]
	public float x;

	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4000B06")]
	public float y;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000B07")]
	public float disX;

	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x4000B08")]
	public float disY;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000B09")]
	public float xLast;

	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x4000B0A")]
	public float yLast;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000B0B")]
	public Text text;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000B0C")]
	public fi actionPopup;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000B0D")]
	public fi actionPopupDown;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000B0E")]
	public fi actionClick;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000B0F")]
	public ng actionScr;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000B10")]
	public ng actionScrDown;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000B11")]
	public short idAction;

	[FieldOffset(Offset = "0xEA")]
	[Token(Token = "0x4000B12")]
	public short idActionDown;

	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x4000B13")]
	public short indexAction;

	[Token(Token = "0x600059D")]
	[Address(RVA = "0x43F870", Offset = "0x43E870", VA = "0x18043F870", Slot = "4")]
	public void OnPointerDown(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600059E")]
	[Address(RVA = "0x43F7F0", Offset = "0x43E7F0", VA = "0x18043F7F0", Slot = "5")]
	public void OnPointerClick(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600059F")]
	[Address(RVA = "0x43FD80", Offset = "0x43ED80", VA = "0x18043FD80", Slot = "6")]
	public void OnPointerUp(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005A0")]
	[Address(RVA = "0x440150", Offset = "0x43F150", VA = "0x180440150")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005A1")]
	[Address(RVA = "0x43FD60", Offset = "0x43ED60", VA = "0x18043FD60", Slot = "7")]
	public void OnPointerEnter(PointerEventData eventData)
	{
		isEnter = true;
	}

	[Token(Token = "0x60005A2")]
	[Address(RVA = "0x43FD70", Offset = "0x43ED70", VA = "0x18043FD70", Slot = "8")]
	public void OnPointerExit(PointerEventData eventData)
	{
		isEnter = false;
	}

	[Token(Token = "0x60005A3")]
	[Address(RVA = "0x4402A0", Offset = "0x43F2A0", VA = "0x1804402A0")]
	public ImageClickButton()
	{
		//IL_000d: Expected I4, but got I8
	}
}
