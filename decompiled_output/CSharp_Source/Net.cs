using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.Networking;

[Token(Token = "0x2000012")]
internal class Net : MonoBehaviour
{
	[Token(Token = "0x2000013")]
	[CompilerGenerated]
	private sealed class n : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400008A")]
		private int foe;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400008B")]
		private object fof;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400008C")]
		public string fog;

		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400008D")]
		public hi foh;

		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400008E")]
		private UnityWebRequest foi;

		[Token(Token = "0x17000012")]
		private object pov
		{
			[Token(Token = "0x600009C")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return fof;
			}
		}

		[Token(Token = "0x17000013")]
		private object pow
		{
			[Token(Token = "0x600009E")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return fof;
			}
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public n(int _003C_003E1__state)
		{
			foe = _003C_003E1__state;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x27A980", Offset = "0x279980", VA = "0x18027A980", Slot = "5")]
		[DebuggerHidden]
		private void vj()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x27A720", Offset = "0x279720", VA = "0x18027A720", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x27AA10", Offset = "0x279A10", VA = "0x18027AA10")]
		private void vk()
		{
			//IL_0017: Expected I4, but got I8
			UnityWebRequest unityWebRequest = foi;
			foe = -1;
			if (unityWebRequest == null)
			{
			}
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x27AA60", Offset = "0x279A60", VA = "0x18027AA60", Slot = "8")]
		[DebuggerHidden]
		private void vm()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[Token(Token = "0x4000087")]
	public static WWW www;

	[Token(Token = "0x4000088")]
	public static hi h;

	[Token(Token = "0x4000089")]
	public static Net me;

	[Token(Token = "0x6000091")]
	[Address(RVA = "0x447180", Offset = "0x446180", VA = "0x180447180")]
	public static void vo()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000092")]
	[Address(RVA = "0x447330", Offset = "0x446330", VA = "0x180447330")]
	public static void vp(string link, hi h)
	{
		o.vw("connectHTTP: " + link);
		Net net = me;
		int num = default;
		n n2 = new n(num);
		num = 0;
		n2.fog = link;
		n2.foh = h;
		Coroutine coroutine = net.StartCoroutine(n2);
	}

	[Token(Token = "0x6000093")]
	[Address(RVA = "0x447140", Offset = "0x446140", VA = "0x180447140")]
	private void Start()
	{
		me = this;
	}

	[Token(Token = "0x6000094")]
	[Address(RVA = "0x447420", Offset = "0x446420", VA = "0x180447420")]
	public void vq(string web, hi h)
	{
		int num = default;
		n n2 = new n(num);
		num = 0;
		n2.fog = web;
		n2.foh = h;
		Coroutine coroutine = StartCoroutine(n2);
	}

	[Token(Token = "0x6000095")]
	[Address(RVA = "0x4474B0", Offset = "0x4464B0", VA = "0x1804474B0")]
	[IteratorStateMachine(typeof(n))]
	private IEnumerator vr(string uri, hi h)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000096")]
	[Address(RVA = "0x447530", Offset = "0x446530", VA = "0x180447530")]
	public static void vs(string url)
	{
		v.ym(url);
	}

	[Token(Token = "0x6000097")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public Net()
	{
	}
}
