using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000248")]
public static class qh
{
	[Token(Token = "0x600129C")]
	[Address(RVA = "0x280530", Offset = "0x27F530", VA = "0x180280530")]
	public static Canvas fbz(this RectTransform rt)
	{
		//IL_0012: Expected Obj, but got I4
		//IL_002c: Expected Obj, but got I4
		Canvas component;
		while (true)
		{
			component = rt.GetComponent<Canvas>();
			int num = 0;
			int num2 = 0;
			if (!(component == (Object)num2) && num <= 50)
			{
				break;
			}
			Canvas componentInParent = rt.GetComponentInParent<Canvas>();
			int num3 = 0;
			if (componentInParent == (Object)num3)
			{
				RectTransform component2 = rt.parent.GetComponent<RectTransform>();
				num++;
				break;
			}
		}
		return component;
	}

	[Token(Token = "0x600129D")]
	[Address(RVA = "0x280670", Offset = "0x27F670", VA = "0x180280670")]
	public static Vector2 fca(this Vector2 input, Canvas canvas)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600129E")]
	[Address(RVA = "0x280790", Offset = "0x27F790", VA = "0x180280790")]
	public static Vector3 fcb(this Vector2 input, RectTransform rt)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600129F")]
	[Address(RVA = "0x280AC0", Offset = "0x27FAC0", VA = "0x180280AC0")]
	public static Camera fcc(this Canvas input)
	{
		//IL_0010: Expected Obj, but got I4
		Camera worldCamera = input.worldCamera;
		int num = 0;
		if (worldCamera == (Object)num)
		{
			int num2 = 0;
			return Camera.main;
		}
		return input.worldCamera;
	}
}
