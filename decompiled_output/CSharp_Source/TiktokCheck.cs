using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000125")]
public class TiktokCheck : MonoBehaviour
{
	[Token(Token = "0x6000833")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000834")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public TiktokCheck()
	{
	}
}
