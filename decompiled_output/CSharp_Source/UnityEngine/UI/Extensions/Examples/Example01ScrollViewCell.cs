using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000274")]
public class Example01ScrollViewCell : FancyScrollViewCell<qs>
{
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D86")]
	[SerializeField]
	private Animator animator;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D87")]
	[SerializeField]
	private Text message;

	[Token(Token = "0x4001D88")]
	private static readonly int pmr = Animator.StringToHash("scroll");

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001D89")]
	private float pms;

	[Token(Token = "0x600139B")]
	[Address(RVA = "0x69F250", Offset = "0x69E250", VA = "0x18069F250", Slot = "7")]
	public override void eni(qs itemData)
	{
		TypeCode typeCode = ((IConvertible)message).GetTypeCode();
	}

	[Token(Token = "0x600139C")]
	[Address(RVA = "0x69F290", Offset = "0x69E290", VA = "0x18069F290", Slot = "8")]
	public override void enj(float position)
	{
		//IL_002f: Expected F4, but got I4
		Animator animator = this.animator;
		pms = position;
		int stateNameHash = pmr;
		animator.Play(stateNameHash, -1, position);
		Animator animator2 = this.animator;
		int num = 0;
		animator2.speed = num;
	}

	[Token(Token = "0x600139D")]
	[Address(RVA = "0x69F1A0", Offset = "0x69E1A0", VA = "0x18069F1A0")]
	private void OnEnable()
	{
		((BaseInputModule)(object)this).Process();
	}

	[Token(Token = "0x600139E")]
	[Address(RVA = "0x69F210", Offset = "0x69E210", VA = "0x18069F210")]
	public Example01ScrollViewCell()
	{
		((FancyScrollViewCell<TData>)(object)this)._002Ector();
	}
}
