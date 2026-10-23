using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001DB")]
[ExecuteInEditMode]
[AddComponentMenu("UI/Effects/Extensions/SoftMaskScript")]
public class SoftMaskScript : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A74")]
	private Material oxu;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A75")]
	private Canvas oxv;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001A76")]
	private Transform oxw;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001A77")]
	private readonly Vector3[] oxx = new Vector3[4];

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001A78")]
	private readonly Vector3[] oxy;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001A79")]
	[Tooltip("The area that is to be used as the container.")]
	public RectTransform MaskArea;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001A7A")]
	[Tooltip("Texture to be used to do the soft alpha")]
	public Texture AlphaMask;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001A7B")]
	[Tooltip("At what point to apply the alpha min range 0-1")]
	[Range(0f, 1f)]
	public float CutOff;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001A7C")]
	[Tooltip("Implement a hard blend based on the Cutoff")]
	public bool HardBlend;

	[FieldOffset(Offset = "0x55")]
	[Token(Token = "0x4001A7D")]
	[Tooltip("Flip the masks alpha value")]
	public bool FlipAlphaMask;

	[FieldOffset(Offset = "0x56")]
	[Token(Token = "0x4001A7E")]
	[Tooltip("If a different Mask Scaling Rect is given, and this value is true, the area around the mask will not be clipped")]
	public bool DontClipMaskScalingRect;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001A7F")]
	private Vector2 oxz;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001A80")]
	private Vector2 oya;

	[Token(Token = "0x6000FBB")]
	[Address(RVA = "0x48BC80", Offset = "0x48AC80", VA = "0x18048BC80")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FBC")]
	[Address(RVA = "0x48BFD0", Offset = "0x48AFD0", VA = "0x18048BFD0")]
	private void Update()
	{
		//IL_0010: Expected Obj, but got I4
		Canvas canvas = oxv;
		int num = 0;
		if (canvas != (Object)num)
		{
			eki();
		}
	}

	[Token(Token = "0x6000FBD")]
	[Address(RVA = "0x48C100", Offset = "0x48B100", VA = "0x18048C100")]
	private void eki()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FBE")]
	[Address(RVA = "0x48C310", Offset = "0x48B310", VA = "0x18048C310")]
	public Rect ekj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FBF")]
	[Address(RVA = "0x48C050", Offset = "0x48B050", VA = "0x18048C050")]
	public unsafe SoftMaskScript()
	{
		//IL_003a: Expected F4, but got I4
		//IL_0035: Expected native int or pointer, but got VT
		//IL_0055: Expected F4, but got I4
		//IL_0050: Expected native int or pointer, but got VT
		Vector3[] array = new Vector3[4];
		int num = 0;
		oxy = array;
		Vector2 zero = Vector2.zero;
		int num2 = 0;
		oxz = zero;
		((Vector2*)(nint)oxz)->y = 0f;
		oya = Vector2.one;
		((Vector2*)(nint)oya)->y = 0f;
		((Behaviour)this)._002Ector();
	}
}
