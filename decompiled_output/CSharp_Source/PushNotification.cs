using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000015")]
public class PushNotification : MonoBehaviour
{
	[Token(Token = "0x60000A5")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60000A6")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public PushNotification()
	{
	}
}
