using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200026E")]
[RequireComponent(typeof(Image))]
public class CooldownEffect_Image : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D7B")]
	public CooldownButton cooldown;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D7C")]
	public Text displayText;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D7D")]
	private Image pmn;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D7E")]
	private string pmo;

	[Token(Token = "0x6001389")]
	[Address(RVA = "0x698F40", Offset = "0x697F40", VA = "0x180698F40")]
	private void Start()
	{
		//IL_0010: Expected Obj, but got I4
		CooldownButton cooldownButton = cooldown;
		int num = 0;
		if (cooldownButton == (Object)num)
		{
			Debug.LogError("Missing Cooldown Button assignment");
		}
		Image component = GetComponent<Image>();
		pmn = component;
	}

	[Token(Token = "0x600138A")]
	[Address(RVA = "0x699010", Offset = "0x698010", VA = "0x180699010")]
	private void Update()
	{
		//IL_0021: Expected F4, but got I4
		//IL_005c: Expected Obj, but got I4
		CooldownButton cooldownButton = cooldown;
		Image image = pmn;
		float cooldownTimeRemaining = cooldownButton.cooldownTimeRemaining;
		float fillAmount = Mathf.Lerp(0f, 1f, cooldownTimeRemaining);
		image.fillAmount = fillAmount;
		if ((bool)displayText)
		{
			CooldownButton cooldownButton2 = cooldown;
			Text text = displayText;
			int cooldownPercentComplete = cooldownButton2.cooldownPercentComplete;
			string text2 = $"{cooldownPercentComplete}%";
			text.text = text2;
		}
	}

	[Token(Token = "0x600138B")]
	[Address(RVA = "0x698E20", Offset = "0x697E20", VA = "0x180698E20")]
	private void OnDisable()
	{
		if ((bool)displayText)
		{
			Text text = displayText;
			string text2 = pmo;
			text.text = text2;
		}
	}

	[Token(Token = "0x600138C")]
	[Address(RVA = "0x698EB0", Offset = "0x697EB0", VA = "0x180698EB0")]
	private void OnEnable()
	{
		if ((bool)displayText)
		{
			string text = displayText.text;
			pmo = text;
		}
	}

	[Token(Token = "0x600138D")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public CooldownEffect_Image()
	{
	}
}
