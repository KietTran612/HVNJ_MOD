using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001E0")]
public class CardStack2D : MonoBehaviour
{
	[Token(Token = "0x20001E1")]
	[CompilerGenerated]
	private sealed class os : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001AB1")]
		private int ozc;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001AB2")]
		private object ozd;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001AB3")]
		public CardStack2D oze;

		[Token(Token = "0x17000097")]
		private object pto
		{
			[Token(Token = "0x6000FDF")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return ozd;
			}
		}

		[Token(Token = "0x17000098")]
		private object ptp
		{
			[Token(Token = "0x6000FE1")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return ozd;
			}
		}

		[Token(Token = "0x6000FDC")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public os(int _003C_003E1__state)
		{
			eks();
			ozc = _003C_003E1__state;
		}

		[Token(Token = "0x6000FDD")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void eks()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000FDE")]
		[Address(RVA = "0x27B5A0", Offset = "0x27A5A0", VA = "0x18027B5A0", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000FE0")]
		[Address(RVA = "0x27B6C0", Offset = "0x27A6C0", VA = "0x18027B6C0", Slot = "8")]
		[DebuggerHidden]
		private void eku()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001AA7")]
	[SerializeField]
	private float cardMoveSpeed = 8f;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001AA8")]
	[SerializeField]
	private float buttonCooldownTime = 0.125f;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001AA9")]
	[SerializeField]
	private int cardZMultiplier = 32;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001AAA")]
	[SerializeField]
	private bool useDefaultUsedXPos = true;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001AAB")]
	[SerializeField]
	private int usedCardXPos = 1280;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001AAC")]
	[SerializeField]
	private Transform[] cards;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001AAD")]
	private int ozf;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001AAE")]
	private Vector3[] ozg;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001AAF")]
	private int ozh;

	[Token(Token = "0x4001AB0")]
	public static bool canUseHorizontalAxis;

	[Token(Token = "0x6000FD7")]
	[Address(RVA = "0x60C160", Offset = "0x60B160", VA = "0x18060C160")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FD8")]
	[Address(RVA = "0x60C4F0", Offset = "0x60B4F0", VA = "0x18060C4F0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FD9")]
	[Address(RVA = "0x60CA70", Offset = "0x60BA70", VA = "0x18060CA70")]
	[IteratorStateMachine(typeof(os))]
	private IEnumerator ekw()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FDA")]
	[Address(RVA = "0x60CA40", Offset = "0x60BA40", VA = "0x18060CA40")]
	public CardStack2D()
	{
		//IL_0020: Expected I4, but got I8
		//IL_0034: Expected I4, but got I8
	}
}
