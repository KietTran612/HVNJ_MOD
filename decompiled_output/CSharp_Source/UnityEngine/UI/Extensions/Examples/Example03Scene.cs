using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200027C")]
public class Example03Scene : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D98")]
	[SerializeField]
	private Example03ScrollView scrollView;

	[Token(Token = "0x60013B4")]
	[Address(RVA = "0x69FD00", Offset = "0x69ED00", VA = "0x18069FD00")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013B5")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public Example03Scene()
	{
	}
}
