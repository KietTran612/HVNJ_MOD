using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001E5")]
[ExecuteInEditMode]
public class ot
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001AD5")]
	private List<Vector2> ozx = (List<Vector2>)(object)new List<T>();

	[Token(Token = "0x6000FED")]
	[Address(RVA = "0x27B850", Offset = "0x27A850", VA = "0x18027B850")]
	public ot(Vector2[] points)
	{
		//IL_0019: Expected I4, but got Obj
		List<Vector2> list = (List<Vector2>)(object)new List<T>((int)points);
		ozx = list;
	}

	[Token(Token = "0x6000FEE")]
	[Address(RVA = "0x27B900", Offset = "0x27A900", VA = "0x18027B900")]
	public int[] elb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FEF")]
	[Address(RVA = "0x27B700", Offset = "0x27A700", VA = "0x18027B700")]
	private float Area()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FF0")]
	[Address(RVA = "0x27BDB0", Offset = "0x27ADB0", VA = "0x18027BDB0")]
	private bool elc(int u, int v, int w, int n, int[] V)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FF1")]
	[Address(RVA = "0x27C070", Offset = "0x27B070", VA = "0x18027C070")]
	private bool eld(Vector2 A, Vector2 B, Vector2 C, Vector2 P)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
