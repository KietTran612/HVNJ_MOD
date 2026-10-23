using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200024B")]
[ExecuteInEditMode]
[AddComponentMenu("UI/Extensions/UI Line Connector")]
[RequireComponent(typeof(UILineRenderer))]
public class UILineConnector : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CD6")]
	public RectTransform[] transforms;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CD7")]
	private Vector2[] pjc;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001CD8")]
	private RectTransform pjd;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001CD9")]
	private RectTransform pje;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001CDA")]
	private UILineRenderer pjf;

	[Token(Token = "0x60012AC")]
	[Address(RVA = "0x87C9E0", Offset = "0x87B9E0", VA = "0x18087C9E0")]
	private void Awake()
	{
		RectTransform component = GetComponentInParent<RectTransform>().fbz().GetComponent<RectTransform>();
		pjd = component;
		RectTransform component2 = GetComponent<RectTransform>();
		pje = component2;
		UILineRenderer component3 = GetComponent<UILineRenderer>();
		pjf = component3;
	}

	[Token(Token = "0x60012AD")]
	[Address(RVA = "0x87CA80", Offset = "0x87BA80", VA = "0x18087CA80")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012AE")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UILineConnector()
	{
	}
}
