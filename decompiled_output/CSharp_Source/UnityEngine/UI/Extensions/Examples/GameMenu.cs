using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200028A")]
public class GameMenu : SimpleMenu<GameMenu>
{
	[Token(Token = "0x60013F0")]
	[Address(RVA = "0x6A45B0", Offset = "0x6A35B0", VA = "0x1806A45B0", Slot = "4")]
	public override void OnBackPressed()
	{
		SimpleMenu<T>.etd();
	}

	[Token(Token = "0x60013F1")]
	[Address(RVA = "0x6A45E0", Offset = "0x6A35E0", VA = "0x1806A45E0")]
	public GameMenu()
	{
		((SimpleMenu<T>)(object)this)._002Ector();
	}
}
