using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200026F")]
[RequireComponent(typeof(SoftMaskScript))]
public class CooldownEffect_SAUIM : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D7F")]
	public CooldownButton cooldown;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D80")]
	private SoftMaskScript pmp;

	[Token(Token = "0x600138E")]
	[Address(RVA = "0x699130", Offset = "0x698130", VA = "0x180699130")]
	private void Start()
	{
		//IL_0010: Expected Obj, but got I4
		CooldownButton cooldownButton = cooldown;
		int num = 0;
		if (cooldownButton == (Object)num)
		{
			Debug.LogError("Missing Cooldown Button assignment");
		}
		SoftMaskScript component = GetComponent<SoftMaskScript>();
		pmp = component;
	}

	[Token(Token = "0x600138F")]
	[Address(RVA = "0x699200", Offset = "0x698200", VA = "0x180699200")]
	private void Update()
	{
		//IL_0021: Expected F4, but got I4
		CooldownButton cooldownButton = cooldown;
		SoftMaskScript softMaskScript = pmp;
		float cooldownTimeElapsed = cooldownButton.cooldownTimeElapsed;
		float cutOff = Mathf.Lerp(0f, 1f, cooldownTimeElapsed);
		softMaskScript.CutOff = cutOff;
	}

	[Token(Token = "0x6001390")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public CooldownEffect_SAUIM()
	{
	}
}
