using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001DF")]
[RequireComponent(typeof(Rigidbody))]
public class CardPopup2D : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A9F")]
	[SerializeField]
	private float rotationSpeed = 1f;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001AA0")]
	[SerializeField]
	private float centeringSpeed = 4f;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001AA1")]
	[SerializeField]
	private bool singleScene;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001AA2")]
	private Rigidbody oyx;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001AA3")]
	private bool oyy;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001AA4")]
	private Vector3 oyz;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001AA5")]
	private bool oza;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001AA6")]
	private float ozb;

	[Token(Token = "0x6000FD2")]
	[Address(RVA = "0x60BC70", Offset = "0x60AC70", VA = "0x18060BC70")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FD3")]
	[Address(RVA = "0x60BCF0", Offset = "0x60ACF0", VA = "0x18060BCF0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FD4")]
	[Address(RVA = "0x60C100", Offset = "0x60B100", VA = "0x18060C100")]
	public void ekq()
	{
		oza = true;
	}

	[Token(Token = "0x6000FD5")]
	[Address(RVA = "0x60C110", Offset = "0x60B110", VA = "0x18060C110")]
	public unsafe void ekr(float fallRotation)
	{
		//IL_001c: Expected VT, but got I4
		//IL_0023: Expected native int or pointer, but got VT
		oyx.useGravity = true;
		oyy = true;
		int num = 0;
		oyz = (Vector3)num;
		((Vector3*)(nint)oyz)->z = fallRotation;
	}

	[Token(Token = "0x6000FD6")]
	[Address(RVA = "0x60C0E0", Offset = "0x60B0E0", VA = "0x18060C0E0")]
	public CardPopup2D()
	{
	}
}
