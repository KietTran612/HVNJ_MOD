using System.Runtime.CompilerServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001B0")]
public class ExampleSelectable : MonoBehaviour, oi
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40019D0")]
	private bool ovj;

	[FieldOffset(Offset = "0x19")]
	[Token(Token = "0x40019D1")]
	private bool ovk;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40019D2")]
	private SpriteRenderer ovl;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40019D3")]
	private Image ovm;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40019D4")]
	private Text ovn;

	[Token(Token = "0x1700005F")]
	public bool pro
	{
		[Token(Token = "0x6000EA6")]
		[Address(RVA = "0x349AD0", Offset = "0x348AD0", VA = "0x180349AD0", Slot = "4")]
		get
		{
			return ovj;
		}
		[Token(Token = "0x6000EA7")]
		[Address(RVA = "0x403610", Offset = "0x402610", VA = "0x180403610", Slot = "5")]
		set
		{
			ovj = value;
		}
	}

	[Token(Token = "0x17000060")]
	public bool prp
	{
		[Token(Token = "0x6000EA8")]
		[Address(RVA = "0x6A14E0", Offset = "0x6A04E0", VA = "0x1806A14E0", Slot = "6")]
		get
		{
			return ovk;
		}
		[Token(Token = "0x6000EA9")]
		[Address(RVA = "0x6A14F0", Offset = "0x6A04F0", VA = "0x1806A14F0", Slot = "7")]
		set
		{
			ovk = value;
		}
	}

	[Token(Token = "0x6000EAA")]
	[Address(RVA = "0x6A1220", Offset = "0x6A0220", VA = "0x1806A1220")]
	private void Start()
	{
		SpriteRenderer component = transform.GetComponent<SpriteRenderer>();
		ovl = component;
		Image component2 = transform.GetComponent<Image>();
		ovm = component2;
		Text component3 = transform.GetComponent<Text>();
		ovn = component3;
	}

	[Token(Token = "0x6000EAB")]
	[Address(RVA = "0x6A12D0", Offset = "0x6A02D0", VA = "0x1806A12D0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EAC")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ExampleSelectable()
	{
	}

	[SpecialName]
	[Token(Token = "0x6000EAD")]
	[Address(RVA = "0x602040", Offset = "0x601040", VA = "0x180602040", Slot = "8")]
	private Transform eek()
	{
		return transform;
	}
}
