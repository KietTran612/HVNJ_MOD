using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000211")]
public static class pg
{
	[Token(Token = "0x6001132")]
	[Address(RVA = "0x27C840", Offset = "0x27B840", VA = "0x18027C840")]
	public static Menu etc(this GameObject go)
	{
		return go.GetComponent<Menu>();
	}
}
