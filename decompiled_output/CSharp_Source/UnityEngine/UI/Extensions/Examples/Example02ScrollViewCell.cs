using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000279")]
public class Example02ScrollViewCell : FancyScrollViewCell<qt, qu>
{
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D8F")]
	[SerializeField]
	private Animator animator;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D90")]
	[SerializeField]
	private Text message;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001D91")]
	[SerializeField]
	private Image image;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001D92")]
	[SerializeField]
	private Button button;

	[Token(Token = "0x4001D93")]
	private static readonly int pmu = Animator.StringToHash("scroll");

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001D94")]
	private float pmv;

	[Token(Token = "0x60013AB")]
	[Address(RVA = "0x69F6D0", Offset = "0x69E6D0", VA = "0x18069F6D0")]
	private void Start()
	{
		Button.ButtonClickedEvent onClick = button.m_OnClick;
		UnityAction call = fhu;
		onClick.AddListener(call);
	}

	[Token(Token = "0x60013AC")]
	[Address(RVA = "0x69F800", Offset = "0x69E800", VA = "0x18069F800", Slot = "7")]
	public override void eni(qt itemData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013AD")]
	[Address(RVA = "0x69F900", Offset = "0x69E900", VA = "0x18069F900", Slot = "8")]
	public override void enj(float position)
	{
		//IL_002f: Expected F4, but got I4
		Animator animator = this.animator;
		pmv = position;
		int stateNameHash = pmu;
		animator.Play(stateNameHash, -1, position);
		Animator animator2 = this.animator;
		int num = 0;
		animator2.speed = num;
	}

	[Token(Token = "0x60013AE")]
	[Address(RVA = "0x69F9C0", Offset = "0x69E9C0", VA = "0x18069F9C0")]
	private void fhu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013AF")]
	[Address(RVA = "0x69F6B0", Offset = "0x69E6B0", VA = "0x18069F6B0")]
	private void OnEnable()
	{
		((BaseInputModule)(object)this).Process();
	}

	[Token(Token = "0x60013B0")]
	[Address(RVA = "0x69F7C0", Offset = "0x69E7C0", VA = "0x18069F7C0")]
	public Example02ScrollViewCell()
	{
		((FancyScrollViewCell<TData, TContext>)(object)this)._002Ector();
	}
}
