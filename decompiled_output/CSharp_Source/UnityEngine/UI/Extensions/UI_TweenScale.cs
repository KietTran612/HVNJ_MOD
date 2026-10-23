using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000253")]
[AddComponentMenu("UI/Extensions/UI Tween Scale")]
public class UI_TweenScale : MonoBehaviour
{
	[Token(Token = "0x2000254")]
	[CompilerGenerated]
	private sealed class qj : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001D19")]
		private int pks;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001D1A")]
		private object pkt;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001D1B")]
		public UI_TweenScale pku;

		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4001D1C")]
		private float pkv;

		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4001D1D")]
		private float pkw;

		[Token(Token = "0x1700011B")]
		private object pxy
		{
			[Token(Token = "0x60012EA")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return pkt;
			}
		}

		[Token(Token = "0x1700011C")]
		private object pxz
		{
			[Token(Token = "0x60012EC")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return pkt;
			}
		}

		[Token(Token = "0x60012E7")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public qj(int _003C_003E1__state)
		{
			fds();
			pks = _003C_003E1__state;
		}

		[Token(Token = "0x60012E8")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void fds()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x60012E9")]
		[Address(RVA = "0x280B60", Offset = "0x27FB60", VA = "0x180280B60", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x60012EB")]
		[Address(RVA = "0x280DB0", Offset = "0x27FDB0", VA = "0x180280DB0", Slot = "8")]
		[DebuggerHidden]
		private void fdu()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D10")]
	public AnimationCurve animCurve;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D11")]
	[Tooltip("Animation speed multiplier")]
	public float speed = 1f;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001D12")]
	[Tooltip("If true animation will loop, for best effect set animation curve to loop on start and end point")]
	public bool isLoop;

	[FieldOffset(Offset = "0x25")]
	[Token(Token = "0x4001D13")]
	[Tooltip("If true animation will start automatically, otherwise you need to call Play() method to start the animation")]
	public bool playAtAwake;

	[FieldOffset(Offset = "0x26")]
	[Token(Token = "0x4001D14")]
	[Space]
	[Space(10f)]
	[Header("Non uniform scale")]
	[Tooltip("If true component will scale by the same amount in X and Y axis, otherwise use animCurve for X scale and animCurveY for Y scale")]
	public bool isUniform = true;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D15")]
	public AnimationCurve animCurveY;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D16")]
	private Vector3 pkx;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001D17")]
	private Transform pky;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001D18")]
	private Vector3 pkz;

	[Token(Token = "0x60012E2")]
	[Address(RVA = "0x42E320", Offset = "0x42D320", VA = "0x18042E320")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012E3")]
	[Address(RVA = "0x42E480", Offset = "0x42D480", VA = "0x18042E480")]
	public void fdw()
	{
		Coroutine coroutine = StartCoroutine("Tween");
	}

	[Token(Token = "0x60012E4")]
	[Address(RVA = "0x42E3D0", Offset = "0x42D3D0", VA = "0x18042E3D0")]
	[IteratorStateMachine(typeof(qj))]
	private IEnumerator Tween()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012E5")]
	[Address(RVA = "0x42E4C0", Offset = "0x42D4C0", VA = "0x18042E4C0")]
	public void fdx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012E6")]
	[Address(RVA = "0x42E440", Offset = "0x42D440", VA = "0x18042E440")]
	public unsafe UI_TweenScale()
	{
		//IL_0024: Expected native int or pointer, but got VT
		float z = Vector3.one.z;
		((Vector3*)(nint)pkz)->z = z;
		((Behaviour)this)._002Ector();
	}
}
