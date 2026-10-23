using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

[Token(Token = "0x2000174")]
public class UICircleChangeDensity : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40018A4")]
	public GameObject MultiColorObject;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40018A5")]
	public GameObject TextOutputObject;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40018A6")]
	private UICircle opg;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40018A7")]
	private Text oph;

	[Token(Token = "0x6000D2A")]
	[Address(RVA = "0x879D40", Offset = "0x878D40", VA = "0x180879D40")]
	private void Awake()
	{
		UICircle component = MultiColorObject.GetComponent<UICircle>();
		GameObject textOutputObject = TextOutputObject;
		opg = component;
		Text component2 = textOutputObject.GetComponent<Text>();
		oph = component2;
	}

	[Token(Token = "0x6000D2B")]
	[Address(RVA = "0x879DB0", Offset = "0x878DB0", VA = "0x180879DB0")]
	private void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D2C")]
	[Address(RVA = "0x879E00", Offset = "0x878E00", VA = "0x180879E00")]
	public void dva(float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D2D")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UICircleChangeDensity()
	{
	}
}
