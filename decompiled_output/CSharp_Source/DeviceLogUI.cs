using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000008")]
public class DeviceLogUI : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000021")]
	public Text textUI;

	[Token(Token = "0x6000032")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public DeviceLogUI()
	{
	}
}
