using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000295")]
public class ScrollingCalendar : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DEC")]
	public RectTransform monthsScrollingPanel;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DED")]
	public RectTransform yearsScrollingPanel;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DEE")]
	public RectTransform daysScrollingPanel;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001DEF")]
	public ScrollRect monthsScrollRect;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001DF0")]
	public ScrollRect yearsScrollRect;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001DF1")]
	public ScrollRect daysScrollRect;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001DF2")]
	public GameObject yearsButtonPrefab;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001DF3")]
	public GameObject monthsButtonPrefab;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001DF4")]
	public GameObject daysButtonPrefab;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001DF5")]
	private GameObject[] pog;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001DF6")]
	private GameObject[] poh;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001DF7")]
	private GameObject[] poi;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001DF8")]
	public RectTransform monthCenter;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001DF9")]
	public RectTransform yearsCenter;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001DFA")]
	public RectTransform daysCenter;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001DFB")]
	private UIVerticalScroller poj;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001DFC")]
	private UIVerticalScroller pok;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4001DFD")]
	private UIVerticalScroller pol;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4001DFE")]
	public InputField inputFieldDays;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001DFF")]
	public InputField inputFieldMonths;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4001E00")]
	public InputField inputFieldYears;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4001E01")]
	public Text dateText;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4001E02")]
	private int pom;

	[FieldOffset(Offset = "0xCC")]
	[Token(Token = "0x4001E03")]
	private int pon;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4001E04")]
	private int poo;

	[Token(Token = "0x6001422")]
	[Address(RVA = "0x484FC0", Offset = "0x483FC0", VA = "0x180484FC0")]
	private void fjs()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001423")]
	[Address(RVA = "0x4852E0", Offset = "0x4842E0", VA = "0x1804852E0")]
	private void fjt()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001424")]
	[Address(RVA = "0x4856C0", Offset = "0x4846C0", VA = "0x1804856C0")]
	private void fju()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001425")]
	[Address(RVA = "0x484A40", Offset = "0x483A40", VA = "0x180484A40")]
	public void Awake()
	{
		fjs();
		fjt();
		fju();
		RectTransform rectTransform = monthCenter;
		ScrollRect scrollRect = monthsScrollRect;
		GameObject[] arrayOfElements = pog;
		UIVerticalScroller uIVerticalScroller = new UIVerticalScroller(rectTransform, rectTransform, scrollRect, arrayOfElements);
		ScrollRect scrollRect2 = yearsScrollRect;
		GameObject[] arrayOfElements2 = poh;
		pok = uIVerticalScroller;
		RectTransform rectTransform2 = yearsCenter;
		UIVerticalScroller uIVerticalScroller2 = new UIVerticalScroller(rectTransform2, rectTransform2, scrollRect2, arrayOfElements2);
		RectTransform rectTransform3 = daysCenter;
		ScrollRect scrollRect3 = daysScrollRect;
		GameObject[] arrayOfElements3 = poi;
		poj = uIVerticalScroller2;
		UIVerticalScroller uIVerticalScroller3 = new UIVerticalScroller(rectTransform3, rectTransform3, scrollRect3, arrayOfElements3);
		UIVerticalScroller uIVerticalScroller4 = pok;
		pol = uIVerticalScroller3;
		uIVerticalScroller4.Start();
		poj.Start();
		pol.Start();
	}

	[Token(Token = "0x6001426")]
	[Address(RVA = "0x485940", Offset = "0x484940", VA = "0x180485940")]
	public void fjv()
	{
		int num = int.Parse(inputFieldDays.m_Text);
		InputField inputField = inputFieldMonths;
		pom = num;
		int num2 = int.Parse(inputField.m_Text);
		InputField inputField2 = inputFieldYears;
		pon = num2;
		int num3 = int.Parse(inputField2.m_Text);
		UIVerticalScroller uIVerticalScroller = pol;
		poo = num3;
		int element = pom;
		uIVerticalScroller.ery(element);
		UIVerticalScroller uIVerticalScroller2 = pok;
		int element2 = pon;
		uIVerticalScroller2.ery(element2);
		UIVerticalScroller uIVerticalScroller3 = poj;
		int element3 = poo;
		uIVerticalScroller3.ery(element3);
	}

	[Token(Token = "0x6001427")]
	[Address(RVA = "0x484BC0", Offset = "0x483BC0", VA = "0x180484BC0")]
	private void Update()
	{
		string text3;
		Text text5;
		string[] array;
		while (true)
		{
			pok.Update();
			poj.Update();
			pol.Update();
			UIVerticalScroller uIVerticalScroller = pol;
			UIVerticalScroller uIVerticalScroller2 = pok;
			string text = uIVerticalScroller.pdq__BackingField;
			string text2 = uIVerticalScroller2.pdq__BackingField;
			text3 = poj.pdq__BackingField;
			if (!text.EndsWith("1") || text != "11")
			{
			}
			if (!text.EndsWith("2") || text != "12")
			{
			}
			if (!text.EndsWith("3") || !(text != "13"))
			{
			}
			string text4 = text + "th";
			text5 = dateText;
			array = new string[5];
			if (text2 != null && array == null)
			{
				continue;
			}
			array[0] = text2;
			if (" " != null && " " == null)
			{
				continue;
			}
			array[1] = " ";
			if (text4 != null && " " == null)
			{
				continue;
			}
			array[2] = text4;
			if (" " == null || " " != null)
			{
				array[3] = " ";
				if (text3 == null || " " != null)
				{
					break;
				}
			}
		}
		array[4] = text3;
		string text6 = string.Concat(array);
		TypeCode typeCode = ((IConvertible)text5).GetTypeCode();
	}

	[Token(Token = "0x6001428")]
	[Address(RVA = "0x485A20", Offset = "0x484A20", VA = "0x180485A20")]
	public void fjw()
	{
		pol.erz();
	}

	[Token(Token = "0x6001429")]
	[Address(RVA = "0x485A50", Offset = "0x484A50", VA = "0x180485A50")]
	public void fjx()
	{
		pol.esa();
	}

	[Token(Token = "0x600142A")]
	[Address(RVA = "0x485A80", Offset = "0x484A80", VA = "0x180485A80")]
	public void fjy()
	{
		pok.erz();
	}

	[Token(Token = "0x600142B")]
	[Address(RVA = "0x485AB0", Offset = "0x484AB0", VA = "0x180485AB0")]
	public void fjz()
	{
		pok.esa();
	}

	[Token(Token = "0x600142C")]
	[Address(RVA = "0x485AE0", Offset = "0x484AE0", VA = "0x180485AE0")]
	public void fka()
	{
		poj.erz();
	}

	[Token(Token = "0x600142D")]
	[Address(RVA = "0x485B10", Offset = "0x484B10", VA = "0x180485B10")]
	public void fkb()
	{
		poj.esa();
	}

	[Token(Token = "0x600142E")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ScrollingCalendar()
	{
	}
}
