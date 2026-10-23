using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200028D")]
public class PauseMenu : SimpleMenu<PauseMenu>
{
	[Token(Token = "0x60013F8")]
	[Address(RVA = "0x448E50", Offset = "0x447E50", VA = "0x180448E50")]
	public void OnQuitPressed()
	{
		SimpleMenu<T>.Hide();
		Object.Destroy(gameObject);
		SimpleMenu<T>.Hide();
	}

	[Token(Token = "0x60013F9")]
	[Address(RVA = "0x448EE0", Offset = "0x447EE0", VA = "0x180448EE0")]
	public PauseMenu()
	{
		((SimpleMenu<T>)(object)this)._002Ector();
	}
}
