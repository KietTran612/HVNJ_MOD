using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Tweens;

[Token(Token = "0x200026B")]
internal class qr<T> where T : struct, qp
{
	[Token(Token = "0x200026C")]
	[CompilerGenerated]
	private sealed class qq : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4001D77")]
		private int pmh;

		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4001D78")]
		private object pmi;

		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4001D79")]
		public T pmj;

		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4001D7A")]
		private float pmk;

		[Token(Token = "0x17000131")]
		private object pys
		{
			[Token(Token = "0x6001381")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
			}
		}

		[Token(Token = "0x17000132")]
		private object pyt
		{
			[Token(Token = "0x6001383")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
			}
		}

		[Token(Token = "0x600137E")]
		[Address(RVA = "0x6C78D0", Offset = "0x6C68D0", VA = "0x1806C78D0")]
		[DebuggerHidden]
		public qq(int _003C_003E1__state)
		{
			fhc();
			((qr<>.qq)(object)this).pmh = _003C_003E1__state;
		}

		[Token(Token = "0x600137F")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void fhc()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001380")]
		[Address(RVA = "0xB21B50", Offset = "0xB20B50", VA = "0x180B21B50", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001382")]
		[Address(RVA = "0xB21C50", Offset = "0xB20C50", VA = "0x180B21C50", Slot = "8")]
		[DebuggerHidden]
		private void fhe()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001D75")]
	protected MonoBehaviour pml;

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001D76")]
	protected IEnumerator pmm;

	[Token(Token = "0x600137A")]
	[Address(RVA = "0xB21C90", Offset = "0xB20C90", VA = "0x180B21C90")]
	[IteratorStateMachine(typeof(qr<>.qq))]
	private static IEnumerator fhg(T tweenInfo)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600137B")]
	[Address(RVA = "0x34A1C0", Offset = "0x3491C0", VA = "0x18034A1C0")]
	public void fhh(MonoBehaviour coroutineContainer)
	{
		((qr<>)(object)this).pml = coroutineContainer;
	}

	[Token(Token = "0x600137C")]
	[Address(RVA = "0xB21D60", Offset = "0xB20D60", VA = "0x180B21D60")]
	public void fhi(T info)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600137D")]
	[Address(RVA = "0x32E3F0", Offset = "0x32D3F0", VA = "0x18032E3F0")]
	public qr()
	{
	}
}
