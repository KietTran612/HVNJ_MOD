using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200028C")]
public class OptionsMenu : SimpleMenu<OptionsMenu>
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DBF")]
	public Slider Slider;

	[Token(Token = "0x60013F6")]
	[Address(RVA = "0x448540", Offset = "0x447540", VA = "0x180448540")]
	public void OnMagicButtonPressed()
	{
		AwesomeMenu.fiw(Slider.value);
	}

	[Token(Token = "0x60013F7")]
	[Address(RVA = "0x448570", Offset = "0x447570", VA = "0x180448570")]
	public OptionsMenu()
	{
		((SimpleMenu<T>)(object)this)._002Ector();
	}
}
