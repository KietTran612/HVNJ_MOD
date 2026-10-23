using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200024E")]
[AddComponentMenu("UI/Extensions/UI ScrollTo Selection XY")]
[RequireComponent(typeof(ScrollRect))]
public class UIScrollToSelectionXY : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CE8")]
	public float scrollSpeed = 10f;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CE9")]
	[SerializeField]
	private RectTransform layoutListGroup;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001CEA")]
	private RectTransform pjl;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001CEB")]
	private bool pjm = true;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001CEC")]
	private RectTransform pjn;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001CED")]
	private ScrollRect pjo;

	[Token(Token = "0x60012CA")]
	[Address(RVA = "0x428750", Offset = "0x427750", VA = "0x180428750")]
	private void Start()
	{
		RectTransform component = (pjo = GetComponent<ScrollRect>()).GetComponent<RectTransform>();
		pjn = component;
	}

	[Token(Token = "0x60012CB")]
	[Address(RVA = "0x4287C0", Offset = "0x4277C0", VA = "0x1804287C0")]
	private void Update()
	{
		fdf();
	}

	[Token(Token = "0x60012CC")]
	[Address(RVA = "0x4287F0", Offset = "0x4277F0", VA = "0x1804287F0")]
	private void fdf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012CD")]
	[Address(RVA = "0x4287D0", Offset = "0x4277D0", VA = "0x1804287D0")]
	public UIScrollToSelectionXY()
	{
	}
}
