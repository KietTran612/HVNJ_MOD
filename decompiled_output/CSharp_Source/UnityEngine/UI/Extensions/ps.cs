using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200022D")]
public class ps
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001C83")]
	public int phb = 10;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4001C84")]
	public float phc = 0.01f;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C85")]
	public float phd = -0.99f;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C86")]
	private List<Vector2> phe;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001C87")]
	private int phf;

	[Token(Token = "0x600120C")]
	[Address(RVA = "0x27C9A0", Offset = "0x27B9A0", VA = "0x18027C9A0")]
	public ps()
	{
		//IL_000a: Expected I4, but got I8
		List<Vector2> list = (List<Vector2>)(object)new List<T>();
		phe = list;
	}

	[Token(Token = "0x600120D")]
	[Address(RVA = "0x27CA30", Offset = "0x27BA30", VA = "0x18027CA30")]
	public void eyu(List<Vector2> newControlPoints)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600120E")]
	[Address(RVA = "0x27CAE0", Offset = "0x27BAE0", VA = "0x18027CAE0")]
	public void eyv(Vector2[] newControlPoints)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600120F")]
	[Address(RVA = "0x27CB90", Offset = "0x27BB90", VA = "0x18027CB90")]
	public List<Vector2> eyw()
	{
		return phe;
	}

	[Token(Token = "0x6001210")]
	[Address(RVA = "0x27CBA0", Offset = "0x27BBA0", VA = "0x18027CBA0")]
	public void eyx(List<Vector2> segmentPoints, float scale)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001211")]
	[Address(RVA = "0x27D000", Offset = "0x27C000", VA = "0x18027D000")]
	public void eyy(List<Vector2> sourcePoints, float minSqrDistance, float maxSqrDistance, float scale)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001212")]
	[Address(RVA = "0x27D420", Offset = "0x27C420", VA = "0x18027D420")]
	public Vector2 eyz(int curveIndex, float t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001213")]
	[Address(RVA = "0x27D5D0", Offset = "0x27C5D0", VA = "0x18027D5D0")]
	public List<Vector2> eza()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001214")]
	[Address(RVA = "0x27D6F0", Offset = "0x27C6F0", VA = "0x18027D6F0")]
	public List<Vector2> ezb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001215")]
	[Address(RVA = "0x27D9D0", Offset = "0x27C9D0", VA = "0x18027D9D0")]
	public List<Vector2> ezc()
	{
		//IL_0021: Expected F4, but got I4
		//IL_0038: Expected VT, but got I4
		//IL_003f: Expected VT, but got I4
		//IL_0053: Expected I4, but got I8
		//IL_0053: Expected F4, but got I4
		List<Vector2> list = (List<Vector2>)(object)new List<T>();
		int num = 0;
		if (phf > num)
		{
			List<Vector2> list2 = (List<Vector2>)(object)new List<T>();
			int num2 = 0;
			Vector2 vector = eyz(num, num2);
			Vector2 vector2 = eyz(num, 1f);
			((List<T>)(object)list2).Add((T)num);
			((List<T>)(object)list2).Add((T)num);
			int num3 = 0;
			ulong num5 = default;
			int num4 = this.eze(num, (float)num3, 1f, (List<>)(object)list2, (int)num5);
			if (num != 0)
			{
				int index = 0;
				((List<T>)(object)list2).RemoveAt(index);
			}
			((List<T>)(object)list).AddRange((IEnumerable<>)list2);
			num++;
		}
		return list;
	}

	[Token(Token = "0x6001216")]
	[Address(RVA = "0x27DBC0", Offset = "0x27CBC0", VA = "0x18027DBC0")]
	private List<Vector2> ezd(int curveIndex)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001217")]
	[Address(RVA = "0x27DCE0", Offset = "0x27CCE0", VA = "0x18027DCE0")]
	private int eze(int curveIndex, float t0, float t1, List<Vector2> pointList, int insertionIndex)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001218")]
	[Address(RVA = "0x27DFA0", Offset = "0x27CFA0", VA = "0x18027DFA0")]
	private Vector2 ezf(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
