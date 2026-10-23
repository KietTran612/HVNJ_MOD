using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001C1")]
public class CUIBezierCurve : MonoBehaviour
{
	[Token(Token = "0x4001A1F")]
	public static readonly int CubicBezierCurvePtNum;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A20")]
	[SerializeField]
	protected Vector3[] controlPoints;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A21")]
	public Action OnRefresh;

	[Token(Token = "0x17000074")]
	public Vector3[] psh
	{
		[Token(Token = "0x6000F1D")]
		[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080")]
		get
		{
			return controlPoints;
		}
	}

	[Token(Token = "0x6000F1E")]
	[Address(RVA = "0x602090", Offset = "0x601090", VA = "0x180602090")]
	public void egw()
	{
		OnRefresh?.Invoke();
	}

	[Token(Token = "0x6000F1F")]
	[Address(RVA = "0x6020B0", Offset = "0x6010B0", VA = "0x1806020B0")]
	public Vector3 egx(float _time)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F20")]
	[Address(RVA = "0x602290", Offset = "0x601290", VA = "0x180602290")]
	public Vector3 egy(float _time)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F21")]
	[Address(RVA = "0x6024A0", Offset = "0x6014A0", VA = "0x1806024A0")]
	public void egz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F22")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public CUIBezierCurve()
	{
	}
}
