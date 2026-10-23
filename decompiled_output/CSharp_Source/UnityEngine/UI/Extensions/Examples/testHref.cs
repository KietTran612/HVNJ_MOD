using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000290")]
public class testHref : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DD5")]
	public TextPic textPic;

	[Token(Token = "0x6001401")]
	[Address(RVA = "0x2828D0", Offset = "0x2818D0", VA = "0x1802828D0")]
	private void Awake()
	{
		TextPic component = GetComponent<TextPic>();
		textPic = component;
	}

	[Token(Token = "0x6001402")]
	[Address(RVA = "0x2829D0", Offset = "0x2819D0", VA = "0x1802829D0")]
	private void OnEnable()
	{
		TextPic.HrefClickEvent onHrefClick = textPic.m_OnHrefClick;
		UnityAction<string> unityAction = (UnityAction<string>)(object)new UnityAction<T0>(fiz);
		((UnityEvent<T0>)(object)onHrefClick).AddListener((UnityAction<>)(object)unityAction);
	}

	[Token(Token = "0x6001403")]
	[Address(RVA = "0x282910", Offset = "0x281910", VA = "0x180282910")]
	private void OnDisable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001404")]
	[Address(RVA = "0x282AA0", Offset = "0x281AA0", VA = "0x180282AA0")]
	private void fiz(string hrefName)
	{
		Debug.Log("Click on the " + hrefName);
	}

	[Token(Token = "0x6001405")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public testHref()
	{
	}
}
