using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000285")]
public class Example04ScrollViewCell : FancyScrollViewCell<qx, qy>
{
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DAD")]
	[SerializeField]
	private Animator animator;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001DAE")]
	[SerializeField]
	private Text message;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001DAF")]
	[SerializeField]
	private Image image;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001DB0")]
	[SerializeField]
	private Button button;

	[Token(Token = "0x4001DB1")]
	private static readonly int pnf = Animator.StringToHash("scroll");

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001DB2")]
	private float png;

	[Token(Token = "0x60013D8")]
	[Address(RVA = "0x6A0990", Offset = "0x69F990", VA = "0x1806A0990")]
	private void Start()
	{
		Button.ButtonClickedEvent onClick = button.m_OnClick;
		UnityAction call = fil;
		onClick.AddListener(call);
	}

	[Token(Token = "0x60013D9")]
	[Address(RVA = "0x6A0AC0", Offset = "0x69FAC0", VA = "0x1806A0AC0", Slot = "7")]
	public override void eni(qx itemData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013DA")]
	[Address(RVA = "0x6A0BC0", Offset = "0x69FBC0", VA = "0x1806A0BC0", Slot = "8")]
	public override void enj(float position)
	{
		//IL_002f: Expected F4, but got I4
		Animator animator = this.animator;
		png = position;
		int stateNameHash = pnf;
		animator.Play(stateNameHash, -1, position);
		Animator animator2 = this.animator;
		int num = 0;
		animator2.speed = num;
	}

	[Token(Token = "0x60013DB")]
	[Address(RVA = "0x6A0C80", Offset = "0x69FC80", VA = "0x1806A0C80")]
	private void fil()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013DC")]
	[Address(RVA = "0x69F6B0", Offset = "0x69E6B0", VA = "0x18069F6B0")]
	private void OnEnable()
	{
		((BaseInputModule)(object)this).Process();
	}

	[Token(Token = "0x60013DD")]
	[Address(RVA = "0x6A0A80", Offset = "0x69FA80", VA = "0x1806A0A80")]
	public Example04ScrollViewCell()
	{
		((FancyScrollViewCell<TData, TContext>)(object)this)._002Ector();
	}
}
