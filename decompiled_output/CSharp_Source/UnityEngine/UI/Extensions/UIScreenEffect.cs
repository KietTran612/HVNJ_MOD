using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D7")]
[ExecuteInEditMode]
[AddComponentMenu("UI/Effects/Extensions/UIScreenEffect")]
[RequireComponent(typeof(RectTransform))]
public class UIScreenEffect : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A6B")]
	private MaskableGraphic oxr;

	[Token(Token = "0x6000FA5")]
	[Address(RVA = "0x428550", Offset = "0x427550", VA = "0x180428550")]
	private void Start()
	{
		ejy();
	}

	[Token(Token = "0x6000FA6")]
	[Address(RVA = "0x428560", Offset = "0x427560", VA = "0x180428560")]
	public void ejy()
	{
		//IL_0017: Expected Obj, but got I4
		//IL_003a: Expected Obj, but got I4
		MaskableGraphic maskableGraphic = (oxr = GetComponent<MaskableGraphic>());
		int num = 0;
		if (!(maskableGraphic != (Object)num))
		{
			Debug.LogError("Please attach component to a Graphical UI component");
			return;
		}
		Material material = oxr.material;
		int num2 = 0;
		if (material == (Object)num2 || string.Equals(oxr.material.name, "Default UI Material"))
		{
			MaskableGraphic maskableGraphic2 = oxr;
			Material material2 = new Material(Shader.Find("UI Extensions/UIScreen"));
			maskableGraphic2.material = material2;
		}
	}

	[Token(Token = "0x6000FA7")]
	[Address(RVA = "0x428550", Offset = "0x427550", VA = "0x180428550")]
	public void OnValidate()
	{
		ejy();
	}

	[Token(Token = "0x6000FA8")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UIScreenEffect()
	{
	}
}
