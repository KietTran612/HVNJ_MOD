using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001DE")]
public class CardExpanding2D : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A91")]
	[SerializeField]
	private float lerpSpeed = 8f;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A92")]
	[SerializeField]
	private RectTransform buttonRect;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001A93")]
	private Vector2 oyn;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001A94")]
	private Vector2 oyo;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001A95")]
	[SerializeField]
	private Vector2 cardSize;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001A96")]
	[SerializeField]
	private Vector2 pageSize;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001A97")]
	private Vector2 oyp;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001A98")]
	private Vector2 oyq;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001A99")]
	private Vector2 oyr;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001A9A")]
	private Vector2 oys;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001A9B")]
	private Vector2 oyt;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001A9C")]
	private Vector2 oyu;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001A9D")]
	private RectTransform oyv;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001A9E")]
	private int oyw;

	[Token(Token = "0x6000FCE")]
	[Address(RVA = "0x6096E0", Offset = "0x6086E0", VA = "0x1806096E0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FCF")]
	[Address(RVA = "0x6098D0", Offset = "0x6088D0", VA = "0x1806098D0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FD0")]
	[Address(RVA = "0x60A1C0", Offset = "0x6091C0", VA = "0x18060A1C0")]
	public void ekp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FD1")]
	[Address(RVA = "0x60A040", Offset = "0x609040", VA = "0x18060A040")]
	public unsafe CardExpanding2D()
	{
		//IL_0028: Expected F4, but got I4
		//IL_0023: Expected native int or pointer, but got VT
		//IL_0044: Expected F4, but got I4
		//IL_003f: Expected native int or pointer, but got VT
		//IL_0062: Expected F4, but got I4
		//IL_005d: Expected native int or pointer, but got VT
		//IL_0080: Expected F4, but got I4
		//IL_007b: Expected native int or pointer, but got VT
		//IL_009e: Expected F4, but got I4
		//IL_0099: Expected native int or pointer, but got VT
		//IL_00bc: Expected F4, but got I4
		//IL_00b7: Expected native int or pointer, but got VT
		//IL_00da: Expected F4, but got I4
		//IL_00d5: Expected native int or pointer, but got VT
		//IL_00f8: Expected F4, but got I4
		//IL_00f3: Expected native int or pointer, but got VT
		//IL_0116: Expected F4, but got I4
		//IL_0111: Expected native int or pointer, but got VT
		//IL_0131: Expected F4, but got I4
		//IL_012c: Expected native int or pointer, but got VT
		//IL_0141: Expected I4, but got I8
		int num = 0;
		Vector2 zero = Vector2.zero;
		int num2 = 0;
		oyn = zero;
		((Vector2*)(nint)oyn)->y = 0f;
		Vector2 zero2 = Vector2.zero;
		int num3 = 0;
		oyo = zero2;
		((Vector2*)(nint)oyo)->y = 0f;
		Vector2 zero3 = Vector2.zero;
		int num4 = 0;
		cardSize = zero3;
		((Vector2*)(nint)cardSize)->y = 0f;
		Vector2 zero4 = Vector2.zero;
		int num5 = 0;
		pageSize = zero4;
		((Vector2*)(nint)pageSize)->y = 0f;
		Vector2 zero5 = Vector2.zero;
		int num6 = 0;
		oyp = zero5;
		((Vector2*)(nint)oyp)->y = 0f;
		Vector2 zero6 = Vector2.zero;
		int num7 = 0;
		oyq = zero6;
		((Vector2*)(nint)oyq)->y = 0f;
		Vector2 zero7 = Vector2.zero;
		int num8 = 0;
		oyr = zero7;
		((Vector2*)(nint)oyr)->y = 0f;
		Vector2 zero8 = Vector2.zero;
		int num9 = 0;
		oys = zero8;
		((Vector2*)(nint)oys)->y = 0f;
		Vector2 zero9 = Vector2.zero;
		int num10 = 0;
		oyt = zero9;
		((Vector2*)(nint)oyt)->y = 0f;
		oyu = Vector2.zero;
		((Vector2*)(nint)oyu)->y = 0f;
		oyw = -1;
		((Behaviour)this)._002Ector();
	}
}
