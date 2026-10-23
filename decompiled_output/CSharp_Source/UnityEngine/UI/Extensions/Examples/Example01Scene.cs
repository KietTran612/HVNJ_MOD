using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000271")]
public class Example01Scene : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D82")]
	[SerializeField]
	private Example01ScrollView scrollView;

	[Token(Token = "0x6001392")]
	[Address(RVA = "0x69EFE0", Offset = "0x69DFE0", VA = "0x18069EFE0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001393")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public Example01Scene()
	{
	}
}
