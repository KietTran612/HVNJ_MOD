using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200028B")]
public class MainMenu : SimpleMenu<MainMenu>
{
	[Token(Token = "0x60013F2")]
	[Address(RVA = "0x443100", Offset = "0x442100", VA = "0x180443100")]
	public void OnPlayPressed()
	{
		SimpleMenu<T>.etd();
	}

	[Token(Token = "0x60013F3")]
	[Address(RVA = "0x4430D0", Offset = "0x4420D0", VA = "0x1804430D0")]
	public void OnOptionsPressed()
	{
		SimpleMenu<T>.etd();
	}

	[Token(Token = "0x60013F4")]
	[Address(RVA = "0x4430C0", Offset = "0x4420C0", VA = "0x1804430C0", Slot = "4")]
	public override void OnBackPressed()
	{
		int num = 0;
		Application.Quit();
	}

	[Token(Token = "0x60013F5")]
	[Address(RVA = "0x443130", Offset = "0x442130", VA = "0x180443130")]
	public MainMenu()
	{
		((SimpleMenu<T>)(object)this)._002Ector();
	}
}
