using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D6")]
[ExecuteInEditMode]
[AddComponentMenu("UI/Effects/Extensions/UIMultiplyEffect")]
[RequireComponent(typeof(RectTransform))]
public class UIMultiplyEffect : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A6A")]
	private MaskableGraphic oxq;

	[Token(Token = "0x6000FA1")]
	[Address(RVA = "0x882A00", Offset = "0x881A00", VA = "0x180882A00")]
	private void Start()
	{
		ejx();
	}

	[Token(Token = "0x6000FA2")]
	[Address(RVA = "0x882A10", Offset = "0x881A10", VA = "0x180882A10")]
	public void ejx()
	{
		//IL_0017: Expected Obj, but got I4
		//IL_003a: Expected Obj, but got I4
		MaskableGraphic maskableGraphic = (oxq = GetComponent<MaskableGraphic>());
		int num = 0;
		if (!(maskableGraphic != (Object)num))
		{
			Debug.LogError("Please attach component to a Graphical UI component");
			return;
		}
		Material material = oxq.material;
		int num2 = 0;
		if (material == (Object)num2 || string.Equals(oxq.material.name, "Default UI Material"))
		{
			MaskableGraphic maskableGraphic2 = oxq;
			Material material2 = new Material(Shader.Find("UI Extensions/UIMultiply"));
			maskableGraphic2.material = material2;
		}
	}

	[Token(Token = "0x6000FA3")]
	[Address(RVA = "0x882A00", Offset = "0x881A00", VA = "0x180882A00")]
	public void OnValidate()
	{
		ejx();
	}

	[Token(Token = "0x6000FA4")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UIMultiplyEffect()
	{
	}
}
