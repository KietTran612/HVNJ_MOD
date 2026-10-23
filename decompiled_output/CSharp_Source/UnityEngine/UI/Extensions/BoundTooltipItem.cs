using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000225")]
[AddComponentMenu("UI/Extensions/Bound Tooltip/Bound Tooltip Item")]
public class BoundTooltipItem : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C41")]
	public Text TooltipText;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C42")]
	public Vector3 ToolTipOffset;

	[Token(Token = "0x4001C43")]
	private static BoundTooltipItem pfl;

	[Token(Token = "0x170000F5")]
	public bool pwp
	{
		[Token(Token = "0x60011CE")]
		[Address(RVA = "0x600940", Offset = "0x5FF940", VA = "0x180600940")]
		get
		{
			return gameObject.activeSelf;
		}
	}

	[Token(Token = "0x170000F6")]
	public static BoundTooltipItem pwq
	{
		[Token(Token = "0x60011D2")]
		[Address(RVA = "0x600AE0", Offset = "0x5FFAE0", VA = "0x180600AE0")]
		get
		{
			//IL_000f: Expected Obj, but got I4
			BoundTooltipItem boundTooltipItem = pfl;
			int num = 0;
			if (boundTooltipItem == (Object)num)
			{
				pfl = Object.FindObjectOfType<BoundTooltipItem>();
			}
			return pfl;
		}
	}

	[Token(Token = "0x60011CF")]
	[Address(RVA = "0x600870", Offset = "0x5FF870", VA = "0x180600870")]
	private void Awake()
	{
		pfl = this;
		if (!TooltipText)
		{
			Text componentInChildren = GetComponentInChildren<Text>();
			TooltipText = componentInChildren;
		}
		GameObject gameObject = base.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
	}

	[Token(Token = "0x60011D0")]
	[Address(RVA = "0x600970", Offset = "0x5FF970", VA = "0x180600970")]
	public void exn(string text, Vector3 pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011D1")]
	[Address(RVA = "0x600AB0", Offset = "0x5FFAB0", VA = "0x180600AB0")]
	public void exo()
	{
		GameObject gameObject = base.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
	}

	[Token(Token = "0x60011D3")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public BoundTooltipItem()
	{
	}
}
