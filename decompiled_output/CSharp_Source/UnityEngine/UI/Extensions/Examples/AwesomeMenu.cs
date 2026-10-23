using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000289")]
public class AwesomeMenu : Menu<AwesomeMenu>
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DBD")]
	public Image Background;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DBE")]
	public Text Title;

	[Token(Token = "0x60013ED")]
	[Address(RVA = "0x600250", Offset = "0x5FF250", VA = "0x180600250")]
	public static void fiw(float awesomeness)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013EE")]
	[Address(RVA = "0x6001E0", Offset = "0x5FF1E0", VA = "0x1806001E0")]
	public static void Hide()
	{
		Menu<T>.Close();
	}

	[Token(Token = "0x60013EF")]
	[Address(RVA = "0x600210", Offset = "0x5FF210", VA = "0x180600210")]
	public AwesomeMenu()
	{
		((Menu<T>)(object)this)._002Ector();
	}
}
