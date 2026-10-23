using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200028F")]
public class AnimateEffects : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DC2")]
	public LetterSpacing letterSpacing;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DC3")]
	private float pnk = 10f;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001DC4")]
	private float pnl;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DC5")]
	private float pnm;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001DC6")]
	public CurvedText curvedText;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001DC7")]
	private float pnn;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001DC8")]
	private float pno;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001DC9")]
	private float pnp;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001DCA")]
	public Gradient2 gradient2;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001DCB")]
	private float pnq;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001DCC")]
	private float pnr;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001DCD")]
	private float pns;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001DCE")]
	public CylinderText cylinderText;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001DCF")]
	private Transform pnt;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001DD0")]
	private Vector3 pnu;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001DD1")]
	public SoftMaskScript SAUIM;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001DD2")]
	private float pnv;

	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4001DD3")]
	private float pnw;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001DD4")]
	private float pnx;

	[Token(Token = "0x60013FE")]
	[Address(RVA = "0x5FE250", Offset = "0x5FD250", VA = "0x1805FE250")]
	private void Start()
	{
		Transform component = cylinderText.GetComponent<Transform>();
		pnt = component;
	}

	[Token(Token = "0x60013FF")]
	[Address(RVA = "0x5FE2A0", Offset = "0x5FD2A0", VA = "0x1805FE2A0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001400")]
	[Address(RVA = "0x5FE440", Offset = "0x5FD440", VA = "0x1805FE440")]
	public unsafe AnimateEffects()
	{
		//IL_006c: Expected VT, but got I4
		//IL_0077: Expected native int or pointer, but got VT
		int num = 0;
		pnl = -10f;
		pnm = 0.1f;
		pnn = 0.05f;
		pno = -0.05f;
		pnp = 0.001f;
		pnq = 1f;
		pnr = -1f;
		pns = 0.01f;
		pnu = (Vector3)num;
		((Vector3*)(nint)pnu)->y = 1f;
		pnv = 1f;
		pnx = 0.01f;
		((Behaviour)this)._002Ector();
	}
}
