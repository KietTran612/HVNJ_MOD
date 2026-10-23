using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000276")]
public class Example02Scene : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D8B")]
	[SerializeField]
	private Example02ScrollView scrollView;

	[Token(Token = "0x60013A1")]
	[Address(RVA = "0x69F4F0", Offset = "0x69E4F0", VA = "0x18069F4F0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013A2")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public Example02Scene()
	{
	}
}
