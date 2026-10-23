using System;
using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Serializable]
[Token(Token = "0x200022F")]
public class CableCurve
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001C8E")]
	[SerializeField]
	private Vector2 m_start;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C8F")]
	[SerializeField]
	private Vector2 m_end;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C90")]
	[SerializeField]
	private float m_slack;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001C91")]
	[SerializeField]
	private int m_steps;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001C92")]
	[SerializeField]
	private bool m_regen;

	[Token(Token = "0x4001C93")]
	private static Vector2[] phm;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001C94")]
	[SerializeField]
	private Vector2[] points;

	[Token(Token = "0x170000FC")]
	public bool pww
	{
		[Token(Token = "0x600121E")]
		[Address(RVA = "0x3EF600", Offset = "0x3EE600", VA = "0x1803EF600")]
		get
		{
			return m_regen;
		}
		[Token(Token = "0x600121F")]
		[Address(RVA = "0x607D00", Offset = "0x606D00", VA = "0x180607D00")]
		set
		{
			m_regen = value;
		}
	}

	[Token(Token = "0x170000FD")]
	public Vector2 pwx
	{
		[Token(Token = "0x6001220")]
		[Address(RVA = "0x5DF530", Offset = "0x5DE530", VA = "0x1805DF530")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6001221")]
		[Address(RVA = "0x607D10", Offset = "0x606D10", VA = "0x180607D10")]
		set
		{
			m_start = value;
			m_regen = true;
		}
	}

	[Token(Token = "0x170000FE")]
	public Vector2 pwy
	{
		[Token(Token = "0x6001222")]
		[Address(RVA = "0x607D50", Offset = "0x606D50", VA = "0x180607D50")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6001223")]
		[Address(RVA = "0x607D70", Offset = "0x606D70", VA = "0x180607D70")]
		set
		{
			m_end = value;
			m_regen = true;
		}
	}

	[Token(Token = "0x170000FF")]
	public float pwz
	{
		[Token(Token = "0x6001224")]
		[Address(RVA = "0x4429F0", Offset = "0x4419F0", VA = "0x1804429F0")]
		get
		{
			return m_slack;
		}
		[Token(Token = "0x6001225")]
		[Address(RVA = "0x607DB0", Offset = "0x606DB0", VA = "0x180607DB0")]
		set
		{
			//IL_000e: Expected F4, but got I4
			m_regen = true;
			float slack = Mathf.Max(0f, value);
			m_slack = slack;
		}
	}

	[Token(Token = "0x17000100")]
	public int pxa
	{
		[Token(Token = "0x6001226")]
		[Address(RVA = "0x335C20", Offset = "0x334C20", VA = "0x180335C20")]
		get
		{
			return m_steps;
		}
		[Token(Token = "0x6001227")]
		[Address(RVA = "0x607DE0", Offset = "0x606DE0", VA = "0x180607DE0")]
		set
		{
			if (value != m_steps)
			{
				m_regen = true;
			}
			int steps = Mathf.Max(2, value);
			m_steps = steps;
		}
	}

	[Token(Token = "0x17000101")]
	public Vector2 pxb
	{
		[Token(Token = "0x6001228")]
		[Address(RVA = "0x607E10", Offset = "0x606E10", VA = "0x180607E10")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x6001229")]
	[Address(RVA = "0x607A30", Offset = "0x606A30", VA = "0x180607A30")]
	public unsafe CableCurve()
	{
		//IL_0030: Expected F4, but got I4
		//IL_002b: Expected native int or pointer, but got VT
		//IL_0055: Expected F4, but got I4
		//IL_0050: Expected native int or pointer, but got VT
		//IL_006a: Expected I4, but got I8
		Vector2[] array = phm;
		points = array;
		int num = 0;
		Vector2 up = Vector2.up;
		int num2 = 0;
		m_start = up;
		((Vector2*)(nint)m_start)->y = 0f;
		Vector2 up2 = Vector2.up;
		int num3 = 0;
		Vector2 right = Vector2.right;
		m_end = right;
		((Vector2*)(nint)m_end)->y = 0f;
		m_slack = 0.5f;
		m_steps = 20;
		m_regen = true;
	}

	[Token(Token = "0x600122A")]
	[Address(RVA = "0x607B90", Offset = "0x606B90", VA = "0x180607B90")]
	public unsafe CableCurve(Vector2[] inputPoints)
	{
		//IL_0030: Expected F4, but got VT
		//IL_002b: Expected native int or pointer, but got VT
		//IL_0053: Expected F4, but got VT
		//IL_004e: Expected native int or pointer, but got VT
		//IL_0068: Expected I4, but got I8
		points = inputPoints;
		Vector2 start = inputPoints[0];
		Vector2 vector = inputPoints[0];
		m_start = start;
		((Vector2*)(nint)m_start)->y = (float)vector;
		Vector2 end = inputPoints[1];
		Vector2 vector2 = inputPoints[1];
		m_end = end;
		((Vector2*)(nint)m_end)->y = (float)vector2;
		m_slack = 0.5f;
		m_steps = 20;
		m_regen = true;
	}

	[Token(Token = "0x600122B")]
	[Address(RVA = "0x607C30", Offset = "0x606C30", VA = "0x180607C30")]
	public CableCurve(List<Vector2> inputPoints)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600122C")]
	[Address(RVA = "0x607B10", Offset = "0x606B10", VA = "0x180607B10")]
	public unsafe CableCurve(CableCurve v)
	{
		//IL_0035: Expected native int or pointer, but got VT
		//IL_005d: Expected native int or pointer, but got VT
		Vector2[] array = v.ezv();
		points = array;
		Vector2 start = v.m_start;
		float y = v.m_start.y;
		m_start = start;
		((Vector2*)(nint)m_start)->y = y;
		Vector2 end = v.m_end;
		float y2 = v.m_end.y;
		m_end = end;
		((Vector2*)(nint)m_end)->y = y2;
		float slack = v.m_slack;
		m_slack = slack;
		int steps = v.m_steps;
		m_steps = steps;
		bool regen = v.m_regen;
		m_regen = regen;
	}

	[Token(Token = "0x600122D")]
	[Address(RVA = "0x607F70", Offset = "0x606F70", VA = "0x180607F70")]
	public Vector2[] ezv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600122E")]
	[Address(RVA = "0x607990", Offset = "0x606990", VA = "0x180607990")]
	static CableCurve()
	{
		//IL_0018: Expected VT, but got I4
		//IL_0020: Expected VT, but got I4
		Vector2[] array = new Vector2[2];
		int length = array.Length;
		int num = 0;
		array[0] = (Vector2)num;
		array[1] = (Vector2)num;
		phm = array;
	}
}
