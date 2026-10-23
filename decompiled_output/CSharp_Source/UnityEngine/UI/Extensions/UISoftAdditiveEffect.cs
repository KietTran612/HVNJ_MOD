using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D8")]
[ExecuteInEditMode]
[AddComponentMenu("UI/Effects/Extensions/UISoftAdditiveEffect")]
[RequireComponent(typeof(RectTransform))]
public class UISoftAdditiveEffect : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A6C")]
	private MaskableGraphic oxs;

	[Token(Token = "0x6000FA9")]
	[Address(RVA = "0x429BC0", Offset = "0x428BC0", VA = "0x180429BC0")]
	private void Start()
	{
		ejz();
	}

	[Token(Token = "0x6000FAA")]
	[Address(RVA = "0x429BD0", Offset = "0x428BD0", VA = "0x180429BD0")]
	public void ejz()
	{
		//IL_0017: Expected Obj, but got I4
		//IL_003a: Expected Obj, but got I4
		MaskableGraphic maskableGraphic = (oxs = GetComponent<MaskableGraphic>());
		int num = 0;
		if (!(maskableGraphic != (Object)num))
		{
			Debug.LogError("Please attach component to a Graphical UI component");
			return;
		}
		Material material = oxs.material;
		int num2 = 0;
		if (material == (Object)num2 || string.Equals(oxs.material.name, "Default UI Material"))
		{
			MaskableGraphic maskableGraphic2 = oxs;
			Material material2 = new Material(Shader.Find("UI Extensions/UISoftAdditive"));
			maskableGraphic2.material = material2;
		}
	}

	[Token(Token = "0x6000FAB")]
	[Address(RVA = "0x429BC0", Offset = "0x428BC0", VA = "0x180429BC0")]
	public void OnValidate()
	{
		ejz();
	}

	[Token(Token = "0x6000FAC")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UISoftAdditiveEffect()
	{
	}
}
