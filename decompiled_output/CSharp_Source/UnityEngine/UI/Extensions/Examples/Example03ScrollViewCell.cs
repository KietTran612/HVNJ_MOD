using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200027F")]
public class Example03ScrollViewCell : FancyScrollViewCell<qv, qw>
{
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D9C")]
	[SerializeField]
	private Animator animator;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D9D")]
	[SerializeField]
	private Text message;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001D9E")]
	[SerializeField]
	private Image image;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001D9F")]
	[SerializeField]
	private Button button;

	[Token(Token = "0x4001DA0")]
	private static readonly int pmz = Animator.StringToHash("scroll");

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001DA1")]
	private float pna;

	[Token(Token = "0x60013BE")]
	[Address(RVA = "0x69FEC0", Offset = "0x69EEC0", VA = "0x18069FEC0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013BF")]
	[Address(RVA = "0x6A0080", Offset = "0x69F080", VA = "0x1806A0080", Slot = "7")]
	public override void eni(qv itemData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013C0")]
	[Address(RVA = "0x6A0180", Offset = "0x69F180", VA = "0x1806A0180", Slot = "8")]
	public override void enj(float position)
	{
		//IL_002f: Expected F4, but got I4
		Animator animator = this.animator;
		pna = position;
		int stateNameHash = pmz;
		animator.Play(stateNameHash, -1, position);
		Animator animator2 = this.animator;
		int num = 0;
		animator2.speed = num;
	}

	[Token(Token = "0x60013C1")]
	[Address(RVA = "0x6A0240", Offset = "0x69F240", VA = "0x1806A0240")]
	private void fhz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013C2")]
	[Address(RVA = "0x69F6B0", Offset = "0x69E6B0", VA = "0x18069F6B0")]
	private void OnEnable()
	{
		((BaseInputModule)(object)this).Process();
	}

	[Token(Token = "0x60013C3")]
	[Address(RVA = "0x6A0040", Offset = "0x69F040", VA = "0x1806A0040")]
	public Example03ScrollViewCell()
	{
		((FancyScrollViewCell<TData, TContext>)(object)this)._002Ector();
	}
}
