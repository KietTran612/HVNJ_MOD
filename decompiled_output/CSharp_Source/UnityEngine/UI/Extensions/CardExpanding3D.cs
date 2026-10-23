using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001E2")]
[ExecuteInEditMode]
public class CardExpanding3D : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001AB4")]
	[SerializeField]
	private float lerpSpeed = 12f;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001AB5")]
	[SerializeField]
	private float cornerSize = 64f;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001AB6")]
	[Header("Parts")]
	public RectTransform[] cardCorners;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001AB7")]
	public RectTransform[] cardEdges;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001AB8")]
	public RectTransform cardCenter;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001AB9")]
	[Header("Card Info")]
	[Tooltip("Positions and sizes card to its current transform.")]
	public bool cardAutoSize = true;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001ABA")]
	public Vector2 cardSize;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001ABB")]
	public Vector2 cardPosition;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4001ABC")]
	[Range(1f, 96f)]
	public int cardSuperness = 4;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001ABD")]
	[Header("Page Info")]
	[Tooltip("Positions and sizes the page to the top third of the screen.")]
	public bool pageAutoSize = true;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001ABE")]
	public Vector2 pageSize;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001ABF")]
	public Vector2 pagePosition;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4001AC0")]
	[Range(1f, 96f)]
	public int pageSuperness = 96;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001AC1")]
	private int ozi;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001AC2")]
	private Vector2[] ozj = new Vector2[4];

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001AC3")]
	private Vector2[] ozk = new Vector2[4];

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001AC4")]
	private Vector2[] ozl = new Vector2[4];

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001AC5")]
	private Vector2 ozm;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001AC6")]
	private Vector2 ozn;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001AC7")]
	private int ozo;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4001AC8")]
	private RectTransform ozp;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4001AC9")]
	private Vector2 ozq;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001ACA")]
	private Vector2 ozr;

	[Token(Token = "0x6000FE2")]
	[Address(RVA = "0x60A2C0", Offset = "0x6092C0", VA = "0x18060A2C0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FE3")]
	[Address(RVA = "0x60A500", Offset = "0x609500", VA = "0x18060A500")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FE4")]
	[Address(RVA = "0x60B050", Offset = "0x60A050", VA = "0x18060B050")]
	public void ekx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FE5")]
	[Address(RVA = "0x60AFB0", Offset = "0x609FB0", VA = "0x18060AFB0")]
	public CardExpanding3D()
	{
		//IL_0026: Expected I4, but got I8
		//IL_0037: Expected I4, but got I8
	}
}
