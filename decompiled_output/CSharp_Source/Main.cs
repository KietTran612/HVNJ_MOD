using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using Facebook.Unity;
using UnityEngine;

[Token(Token = "0x200001E")]
public class Main : MonoBehaviour
{
	[Token(Token = "0x200001F")]
	[CompilerGenerated]
	private sealed class bb : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40000DE")]
		private int fqq;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40000DF")]
		private object fqr;

		[Token(Token = "0x17000014")]
		private object pox
		{
			[Token(Token = "0x6000118")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return fqr;
			}
		}

		[Token(Token = "0x17000015")]
		private object poy
		{
			[Token(Token = "0x600011A")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return fqr;
			}
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public bb(int _003C_003E1__state)
		{
			yo();
			fqq = _003C_003E1__state;
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void yo()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x275D40", Offset = "0x274D40", VA = "0x180275D40", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x276090", Offset = "0x275090", VA = "0x180276090", Slot = "8")]
		[DebuggerHidden]
		private void yq()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[Token(Token = "0x40000C9")]
	public static Main main;

	[Token(Token = "0x40000CA")]
	public static hx midlet;

	[Token(Token = "0x40000CB")]
	public static string res;

	[Token(Token = "0x40000CC")]
	public static string mainThreadName;

	[Token(Token = "0x40000CD")]
	public static bool started;

	[Token(Token = "0x40000CE")]
	public static bool isPC;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40000CF")]
	private int fqs;

	[Token(Token = "0x40000D0")]
	public const sbyte IP_JB = 3;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x40000D1")]
	private bool fqt;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40000D2")]
	private long fqu;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40000D3")]
	private long fqv;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40000D4")]
	private int fqw;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x40000D5")]
	private int fqx;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40000D6")]
	private int fqy;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x40000D7")]
	private int fqz;

	[Token(Token = "0x40000D8")]
	public static bool isPaintGUI;

	[Token(Token = "0x40000D9")]
	public static bool isMuti;

	[Token(Token = "0x40000DA")]
	public static bool isIndexMuti;

	[Token(Token = "0x40000DB")]
	public static bool isPauseGame;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40000DC")]
	private Vector2 fra;

	[Token(Token = "0x40000DD")]
	public static int a;

	[Token(Token = "0x6000101")]
	[Address(RVA = "0x4441E0", Offset = "0x4431E0", VA = "0x1804441E0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000102")]
	[Address(RVA = "0x444650", Offset = "0x443650", VA = "0x180444650")]
	private void ys()
	{
		enabled = true;
	}

	[Token(Token = "0x6000103")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	private void yt(bool isGameShown)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000104")]
	[Address(RVA = "0x444000", Offset = "0x443000", VA = "0x180444000")]
	private void OnGUI()
	{
		//IL_0021: Expected Obj, but got I4
		if (!fqt)
		{
			int num = 0;
			useGUILayout = (byte)num != 0;
			Main main = Main.main;
			int num2 = 0;
			if (main == (UnityEngine.Object)num2)
			{
				Main.main = this;
			}
			fqt = true;
			int num3 = 0;
			SDKPopup.dol().dqb();
			midlet = new hx();
		}
		int num4 = 0;
		string text = hw.cdp();
		yx();
	}

	[Token(Token = "0x6000105")]
	[Address(RVA = "0x444660", Offset = "0x443660", VA = "0x180444660")]
	public void yu()
	{
		//IL_0021: Expected Obj, but got I4
		if (!fqt)
		{
			int num = 0;
			useGUILayout = (byte)num != 0;
			Main main = Main.main;
			int num2 = 0;
			if (main == (UnityEngine.Object)num2)
			{
				Main.main = this;
			}
			fqt = true;
			int num3 = 0;
			SDKPopup.dol().dqb();
			midlet = new hx();
		}
	}

	[Token(Token = "0x6000106")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public static void yv(string path)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000107")]
	[Address(RVA = "0x4447F0", Offset = "0x4437F0", VA = "0x1804447F0")]
	public string yw()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000108")]
	[Address(RVA = "0x443C30", Offset = "0x442C30", VA = "0x180443C30")]
	private void FixedUpdate()
	{
		//IL_0011: Expected I4, but got I8
		//IL_004e: Expected I4, but got I8
		int num = 0;
		long num2 = hw.ccz();
		fqz = 0;
		int num3 = 0;
		lj lj2 = lj.cmy();
		int speedUpdate = fqy;
		int speed = fqw;
		lj2.cop(speed, speedUpdate);
		int num4 = 0;
		long num5 = hw.ccz();
		fqv = num5;
		fqw = 0;
		hx.jxc.ccg();
		hx.jxc.ccj();
	}

	[Token(Token = "0x6000109")]
	[Address(RVA = "0x444320", Offset = "0x443320", VA = "0x180444320")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600010A")]
	[Address(RVA = "0x4448F0", Offset = "0x4438F0", VA = "0x1804448F0")]
	private void yx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600010B")]
	[Address(RVA = "0x445390", Offset = "0x444390", VA = "0x180445390")]
	public static bool yy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600010C")]
	[Address(RVA = "0x443DD0", Offset = "0x442DD0", VA = "0x180443DD0")]
	private static extern short GetKeyState(int keyCode);

	[Token(Token = "0x600010D")]
	[Address(RVA = "0x443F10", Offset = "0x442F10", VA = "0x180443F10")]
	private void OnApplicationQuit()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600010E")]
	[Address(RVA = "0x443E50", Offset = "0x442E50", VA = "0x180443E50")]
	private void OnApplicationPause(bool paused)
	{
		isPauseGame = paused;
		if (!paused)
		{
			int num = 0;
			if (FB.IsInitialized)
			{
				int num2 = 0;
				FB.ActivateApp();
			}
		}
	}

	[Token(Token = "0x600010F")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public static void yz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000110")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void za()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000111")]
	[Address(RVA = "0x445450", Offset = "0x444450", VA = "0x180445450")]
	[IteratorStateMachine(typeof(bb))]
	private IEnumerator zb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000112")]
	[Address(RVA = "0x4454A0", Offset = "0x4444A0", VA = "0x1804454A0")]
	public void zc()
	{
		o.vw("checkTracking main");
	}

	[Token(Token = "0x6000113")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public Main()
	{
	}

	[Token(Token = "0x6000114")]
	[Address(RVA = "0x4445C0", Offset = "0x4435C0", VA = "0x1804445C0")]
	static Main()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
