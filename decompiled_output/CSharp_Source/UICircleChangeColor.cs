using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000173")]
public class UICircleChangeColor : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400189D")]
	public GameObject TargetUICircle;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400189E")]
	private Color opa;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400189F")]
	private Color opb;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40018A0")]
	private float opc;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x40018A1")]
	private float opd;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40018A2")]
	private float ope;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x40018A3")]
	private float opf = 1536.145f;

	[Token(Token = "0x6000D25")]
	[Address(RVA = "0x8799C0", Offset = "0x8789C0", VA = "0x1808799C0")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D26")]
	[Address(RVA = "0x879A60", Offset = "0x878A60", VA = "0x180879A60")]
	public void dux(float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D27")]
	[Address(RVA = "0x879B00", Offset = "0x878B00", VA = "0x180879B00")]
	public void duy(float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D28")]
	[Address(RVA = "0x879BA0", Offset = "0x878BA0", VA = "0x180879BA0")]
	private Color duz(float value, float alpha)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D29")]
	[Address(RVA = "0x879A50", Offset = "0x878A50", VA = "0x180879A50")]
	public UICircleChangeColor()
	{
	}
}
