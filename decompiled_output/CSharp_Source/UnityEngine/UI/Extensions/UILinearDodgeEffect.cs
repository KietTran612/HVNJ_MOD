using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D5")]
[ExecuteInEditMode]
[AddComponentMenu("UI/Effects/Extensions/UILinearDodgeEffect")]
[RequireComponent(typeof(RectTransform))]
public class UILinearDodgeEffect : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A69")]
	private MaskableGraphic oxp;

	[Token(Token = "0x6000F9D")]
	[Address(RVA = "0x882800", Offset = "0x881800", VA = "0x180882800")]
	private void Start()
	{
		ejw();
	}

	[Token(Token = "0x6000F9E")]
	[Address(RVA = "0x882810", Offset = "0x881810", VA = "0x180882810")]
	public void ejw()
	{
		//IL_0017: Expected Obj, but got I4
		//IL_003a: Expected Obj, but got I4
		MaskableGraphic maskableGraphic = (oxp = GetComponent<MaskableGraphic>());
		int num = 0;
		if (!(maskableGraphic != (Object)num))
		{
			Debug.LogError("Please attach component to a Graphical UI component");
			return;
		}
		Material material = oxp.material;
		int num2 = 0;
		if (material == (Object)num2 || string.Equals(oxp.material.name, "Default UI Material"))
		{
			MaskableGraphic maskableGraphic2 = oxp;
			Material material2 = new Material(Shader.Find("UI Extensions/UILinearDodge"));
			maskableGraphic2.material = material2;
		}
	}

	[Token(Token = "0x6000F9F")]
	[Address(RVA = "0x882800", Offset = "0x881800", VA = "0x180882800")]
	public void OnValidate()
	{
		ejw();
	}

	[Token(Token = "0x6000FA0")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UILinearDodgeEffect()
	{
	}
}
