using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000227")]
[AddComponentMenu("UI/Extensions/HoverTooltip")]
public class HoverTooltip : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C47")]
	public int horizontalPadding;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001C48")]
	public int verticalPadding;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C49")]
	public Text thisText;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001C4A")]
	public HorizontalLayoutGroup hlG;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001C4B")]
	public RectTransform bgImage;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001C4C")]
	private Image pfm;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001C4D")]
	private bool pfn;

	[FieldOffset(Offset = "0x41")]
	[Token(Token = "0x4001C4E")]
	private bool pfo;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001C4F")]
	private RenderMode pfp;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001C50")]
	private Camera pfq;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001C51")]
	private Vector3 pfr;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001C52")]
	private Vector3 pfs;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001C53")]
	private float pft;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4001C54")]
	private float pfu;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001C55")]
	private float pfv;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001C56")]
	private float pfw;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001C57")]
	private float pfx;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4001C58")]
	private float pfy;

	[Token(Token = "0x60011DB")]
	[Address(RVA = "0x43E210", Offset = "0x43D210", VA = "0x18043E210")]
	private void Start()
	{
		Camera component = GameObject.Find("GUICamera").GetComponent<Camera>();
		pfq = component;
		RenderMode renderMode = transform.parent.parent.GetComponent<Canvas>().renderMode;
		RectTransform rectTransform = bgImage;
		pfp = renderMode;
		Image component2 = rectTransform.GetComponent<Image>();
		pfm = component2;
		pfo = false;
		eyb();
		GameObject gameObject = transform.parent.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
	}

	[Token(Token = "0x60011DC")]
	[Address(RVA = "0x43E390", Offset = "0x43D390", VA = "0x18043E390")]
	public void ext(string text)
	{
		exz();
		thisText.text = text;
		exw();
	}

	[Token(Token = "0x60011DD")]
	[Address(RVA = "0x43E3E0", Offset = "0x43D3E0", VA = "0x18043E3E0")]
	public void exu(string[] texts)
	{
		exz();
		int num = 0;
		int length = texts.Length;
		if (num < length)
		{
			string text = texts[num];
			if (num != 0)
			{
				string text2 = "" + "\n" + text;
				num++;
				num++;
			}
			string text3 = "" + text;
			num++;
			num++;
		}
		thisText.text = "";
		exw();
	}

	[Token(Token = "0x60011DE")]
	[Address(RVA = "0x43E390", Offset = "0x43D390", VA = "0x18043E390")]
	public void exv(string text, bool test)
	{
		exz();
		thisText.text = text;
		exw();
	}

	[Token(Token = "0x60011DF")]
	[Address(RVA = "0x43E4E0", Offset = "0x43D4E0", VA = "0x18043E4E0")]
	public void exw()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011E0")]
	[Address(RVA = "0x43EBA0", Offset = "0x43DBA0", VA = "0x18043EBA0")]
	public void exx()
	{
		//IL_0012: Expected Obj, but got I4
		if (pfp == RenderMode.ScreenSpaceCamera)
		{
			int num = 0;
			if (this != (Object)num)
			{
				GameObject gameObject = transform.parent.gameObject;
				int active = 0;
				gameObject.SetActive((byte)active != 0);
				pfo = false;
				eyb();
			}
		}
	}

	[Token(Token = "0x60011E1")]
	[Address(RVA = "0x43E350", Offset = "0x43D350", VA = "0x18043E350")]
	private void Update()
	{
		exy();
		if (pfo && pfp == RenderMode.ScreenSpaceCamera)
		{
			exw();
		}
	}

	[Token(Token = "0x60011E2")]
	[Address(RVA = "0x43EC60", Offset = "0x43DC60", VA = "0x18043EC60")]
	private void exy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011E3")]
	[Address(RVA = "0x43EFA0", Offset = "0x43DFA0", VA = "0x18043EFA0")]
	private void exz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011E4")]
	[Address(RVA = "0x43F100", Offset = "0x43E100", VA = "0x18043F100")]
	public void eya()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011E5")]
	[Address(RVA = "0x43F2A0", Offset = "0x43E2A0", VA = "0x18043F2A0")]
	public void eyb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011E6")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public HoverTooltip()
	{
	}
}
