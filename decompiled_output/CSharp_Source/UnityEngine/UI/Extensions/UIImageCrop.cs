using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D4")]
[ExecuteInEditMode]
[AddComponentMenu("UI/Effects/Extensions/UIImageCrop")]
[RequireComponent(typeof(RectTransform))]
public class UIImageCrop : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A63")]
	private MaskableGraphic oxl;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A64")]
	private Material oxm;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001A65")]
	private int oxn;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4001A66")]
	private int oxo;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001A67")]
	public float XCrop;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001A68")]
	public float YCrop;

	[Token(Token = "0x6000F97")]
	[Address(RVA = "0x87C700", Offset = "0x87B700", VA = "0x18087C700")]
	private void Start()
	{
		ejt();
	}

	[Token(Token = "0x6000F98")]
	[Address(RVA = "0x87C710", Offset = "0x87B710", VA = "0x18087C710")]
	public void ejt()
	{
		//IL_0044: Expected Obj, but got I4
		//IL_006b: Expected Obj, but got I4
		MaskableGraphic component = GetComponent<MaskableGraphic>();
		oxl = component;
		int num = Shader.PropertyToID("_XCrop");
		oxn = num;
		int num2 = Shader.PropertyToID("_YCrop");
		MaskableGraphic maskableGraphic = oxl;
		oxo = num2;
		int num3 = 0;
		if (!(maskableGraphic != (Object)num3))
		{
			Debug.LogError("Please attach component to a Graphical UI component");
			return;
		}
		Material material = oxl.material;
		int num4 = 0;
		if (material == (Object)num4 || string.Equals(oxl.material.name, "Default UI Material"))
		{
			MaskableGraphic maskableGraphic2 = oxl;
			Material material2 = new Material(Shader.Find("UI Extensions/UI Image Crop"));
			maskableGraphic2.material = material2;
		}
		Material material3 = oxl.material;
		oxm = material3;
	}

	[Token(Token = "0x6000F99")]
	[Address(RVA = "0x87C690", Offset = "0x87B690", VA = "0x18087C690")]
	public void OnValidate()
	{
		ejt();
		float num = Mathf.Clamp01(XCrop);
		Material material = oxm;
		XCrop = num;
		int num2 = oxn;
		material.SetFloatImpl(num2, num);
		float num3 = Mathf.Clamp01(YCrop);
		Material material2 = oxm;
		YCrop = num3;
		int num4 = oxo;
		num = num3;
		material2.SetFloatImpl(num4, num);
	}

	[Token(Token = "0x6000F9A")]
	[Address(RVA = "0x87C960", Offset = "0x87B960", VA = "0x18087C960")]
	public void eju(float xcrop)
	{
		float num = Mathf.Clamp01(xcrop);
		Material material = oxm;
		XCrop = num;
		int num2 = oxn;
		material.SetFloatImpl(num2, num);
	}

	[Token(Token = "0x6000F9B")]
	[Address(RVA = "0x87C9A0", Offset = "0x87B9A0", VA = "0x18087C9A0")]
	public void ejv(float ycrop)
	{
		float num = Mathf.Clamp01(ycrop);
		Material material = oxm;
		YCrop = num;
		int num2 = oxo;
		material.SetFloatImpl(num2, num);
	}

	[Token(Token = "0x6000F9C")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UIImageCrop()
	{
	}
}
