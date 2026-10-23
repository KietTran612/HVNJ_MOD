using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D2")]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Image))]
[AddComponentMenu("UI/Extensions/Raycast Mask")]
public class RaycastMask : MonoBehaviour, ICanvasRaycastFilter
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A60")]
	private Image oxi;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A61")]
	private Sprite oxj;

	[Token(Token = "0x6000F90")]
	[Address(RVA = "0x44BBE0", Offset = "0x44ABE0", VA = "0x18044BBE0")]
	private void Start()
	{
		Image component = GetComponent<Image>();
		oxi = component;
	}

	[Token(Token = "0x6000F91")]
	[Address(RVA = "0x44B600", Offset = "0x44A600", VA = "0x18044B600", Slot = "4")]
	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F92")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public RaycastMask()
	{
	}
}
