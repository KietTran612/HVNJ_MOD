using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001A4")]
public class ReorderableListContent : MonoBehaviour
{
	[Token(Token = "0x20001A5")]
	[CompilerGenerated]
	private sealed class of : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001995")]
		private int otj;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001996")]
		private object otk;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001997")]
		public ReorderableListContent otl;

		[Token(Token = "0x1700004F")]
		private object pqy
		{
			[Token(Token = "0x6000E50")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return otk;
			}
		}

		[Token(Token = "0x17000050")]
		private object pqz
		{
			[Token(Token = "0x6000E52")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return otk;
			}
		}

		[Token(Token = "0x6000E4D")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public of(int _003C_003E1__state)
		{
			ecf();
			otj = _003C_003E1__state;
		}

		[Token(Token = "0x6000E4E")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void ecf()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000E4F")]
		[Address(RVA = "0x27AF50", Offset = "0x279F50", VA = "0x18027AF50", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000E51")]
		[Address(RVA = "0x27B2B0", Offset = "0x27A2B0", VA = "0x18027B2B0", Slot = "8")]
		[DebuggerHidden]
		private void ech()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001990")]
	private List<Transform> otm;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001991")]
	private List<ReorderableListElement> otn;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001992")]
	private ReorderableListElement oto;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001993")]
	private ReorderableList otp;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001994")]
	private RectTransform otq;

	[Token(Token = "0x6000E48")]
	[Address(RVA = "0x44BC30", Offset = "0x44AC30", VA = "0x18044BC30")]
	private void OnEnable()
	{
		if ((bool)otq)
		{
			int num = default;
			of of2 = new of(num);
			num = 0;
			of2.otl = this;
			Coroutine coroutine = StartCoroutine(of2);
		}
	}

	[Token(Token = "0x6000E49")]
	[Address(RVA = "0x44BCF0", Offset = "0x44ACF0", VA = "0x18044BCF0")]
	public void OnTransformChildrenChanged()
	{
		if (isActiveAndEnabled)
		{
			int num = default;
			of of2 = new of(num);
			num = 0;
			of2.otl = this;
			Coroutine coroutine = StartCoroutine(of2);
		}
	}

	[Token(Token = "0x6000E4A")]
	[Address(RVA = "0x44BD70", Offset = "0x44AD70", VA = "0x18044BD70")]
	public void ecj(ReorderableList extList)
	{
		otp = extList;
		RectTransform component = GetComponent<RectTransform>();
		otq = component;
		List<Transform> list = (List<Transform>)(object)new List<T>();
		otm = list;
		List<ReorderableListElement> list2 = (List<ReorderableListElement>)(object)new List<T>();
		otn = list2;
		int num = default;
		of of2 = new of(num);
		num = 0;
		of2.otl = this;
		Coroutine coroutine = StartCoroutine(of2);
	}

	[Token(Token = "0x6000E4B")]
	[Address(RVA = "0x44BE90", Offset = "0x44AE90", VA = "0x18044BE90")]
	[IteratorStateMachine(typeof(of))]
	private IEnumerator eck()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E4C")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ReorderableListContent()
	{
	}
}
