using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D3")]
[ExecuteInEditMode]
[AddComponentMenu("UI/Effects/Extensions/UIAdditiveEffect")]
[RequireComponent(typeof(RectTransform))]
public class UIAdditiveEffect : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A62")]
	private MaskableGraphic oxk;

	[Token(Token = "0x6000F93")]
	[Address(RVA = "0x8797C0", Offset = "0x8787C0", VA = "0x1808797C0")]
	private void Start()
	{
		ejs();
	}

	[Token(Token = "0x6000F94")]
	[Address(RVA = "0x8797D0", Offset = "0x8787D0", VA = "0x1808797D0")]
	public void ejs()
	{
		//IL_0017: Expected Obj, but got I4
		//IL_003a: Expected Obj, but got I4
		MaskableGraphic maskableGraphic = (oxk = GetComponent<MaskableGraphic>());
		int num = 0;
		if (!(maskableGraphic != (Object)num))
		{
			Debug.LogError("Please attach component to a Graphical UI component");
			return;
		}
		Material material = oxk.material;
		int num2 = 0;
		if (material == (Object)num2 || string.Equals(oxk.material.name, "Default UI Material"))
		{
			MaskableGraphic maskableGraphic2 = oxk;
			Material material2 = new Material(Shader.Find("UI Extensions/UIAdditive"));
			maskableGraphic2.material = material2;
		}
	}

	[Token(Token = "0x6000F95")]
	[Address(RVA = "0x8797C0", Offset = "0x8787C0", VA = "0x1808797C0")]
	public void OnValidate()
	{
		ejs();
	}

	[Token(Token = "0x6000F96")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UIAdditiveEffect()
	{
	}
}
