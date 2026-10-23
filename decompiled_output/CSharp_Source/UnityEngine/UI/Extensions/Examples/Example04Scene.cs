using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000282")]
public class Example04Scene : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DA5")]
	[SerializeField]
	private Example04ScrollView scrollView;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DA6")]
	[SerializeField]
	private Button prevCellButton;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DA7")]
	[SerializeField]
	private Button nextCellButton;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001DA8")]
	[SerializeField]
	private Text selectedItemInfo;

	[Token(Token = "0x60013C7")]
	[Address(RVA = "0x6A0580", Offset = "0x69F580", VA = "0x1806A0580")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013C8")]
	[Address(RVA = "0x6A0900", Offset = "0x69F900", VA = "0x1806A0900")]
	private void fib(int index)
	{
		Text text = selectedItemInfo;
		string text2 = string.Format("Selected item info: index {0}", "Selected item info: index {0}");
		text.text = text2;
	}

	[Token(Token = "0x60013C9")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public Example04Scene()
	{
	}
}
