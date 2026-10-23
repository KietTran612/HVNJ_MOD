using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000294")]
public class TestAddingPointsList : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DE9")]
	public UILineRendererList LineRenderer;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DEA")]
	public Text XValue;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DEB")]
	public Text YValue;

	[Token(Token = "0x600141F")]
	[Address(RVA = "0x4919E0", Offset = "0x4909E0", VA = "0x1804919E0")]
	public void fjq()
	{
		//IL_0032: Expected VT, but got I4
		float num = float.Parse(XValue.text);
		string text = YValue.text;
		int num2 = 0;
		float num3 = float.Parse(text);
		LineRenderer.ewb((Vector2)num2);
	}

	[Token(Token = "0x6001420")]
	[Address(RVA = "0x491A60", Offset = "0x490A60", VA = "0x180491A60")]
	public void fjr()
	{
		//IL_0010: Expected Obj, but got I4
		UILineRendererList lineRenderer = LineRenderer;
		int num = 0;
		if (lineRenderer != (Object)num)
		{
			UILineRendererList lineRenderer2 = LineRenderer;
			if ((long)lineRenderer2.m_points != 0)
			{
				lineRenderer2.ewd();
			}
		}
	}

	[Token(Token = "0x6001421")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public TestAddingPointsList()
	{
	}
}
