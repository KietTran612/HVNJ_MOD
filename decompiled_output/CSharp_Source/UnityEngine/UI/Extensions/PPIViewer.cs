using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000236")]
[RequireComponent(typeof(Text))]
[AddComponentMenu("UI/Extensions/PPIViewer")]
public class PPIViewer : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C9E")]
	private Text pho;

	[Token(Token = "0x6001246")]
	[Address(RVA = "0x4485B0", Offset = "0x4475B0", VA = "0x1804485B0")]
	private void Awake()
	{
		Text component = GetComponent<Text>();
		pho = component;
	}

	[Token(Token = "0x6001247")]
	[Address(RVA = "0x4485F0", Offset = "0x4475F0", VA = "0x1804485F0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001248")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public PPIViewer()
	{
	}
}
