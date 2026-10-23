using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000244")]
[AddComponentMenu("UI/Extensions/Selectable Scalar")]
[RequireComponent(typeof(Button))]
public class SelectableScaler : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[Token(Token = "0x2000245")]
	[CompilerGenerated]
	private sealed class qe : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001CC2")]
		private int pin;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001CC3")]
		private object pio;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001CC4")]
		public SelectableScaler pip;

		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4001CC5")]
		private float piq;

		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4001CC6")]
		private float pir;

		[Token(Token = "0x17000109")]
		private object pxj
		{
			[Token(Token = "0x6001290")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return pio;
			}
		}

		[Token(Token = "0x1700010A")]
		private object pxk
		{
			[Token(Token = "0x6001292")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return pio;
			}
		}

		[Token(Token = "0x600128D")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public qe(int _003C_003E1__state)
		{
			fbn();
			pin = _003C_003E1__state;
		}

		[Token(Token = "0x600128E")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void fbn()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x600128F")]
		[Address(RVA = "0x280020", Offset = "0x27F020", VA = "0x180280020", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001291")]
		[Address(RVA = "0x280230", Offset = "0x27F230", VA = "0x180280230", Slot = "8")]
		[DebuggerHidden]
		private void fbp()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[Token(Token = "0x2000246")]
	[CompilerGenerated]
	private sealed class qf : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001CC7")]
		private int pis;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001CC8")]
		private object pit;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001CC9")]
		public SelectableScaler piu;

		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4001CCA")]
		private float piv;

		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4001CCB")]
		private float piw;

		[Token(Token = "0x1700010B")]
		private object pxl
		{
			[Token(Token = "0x6001296")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return pit;
			}
		}

		[Token(Token = "0x1700010C")]
		private object pxm
		{
			[Token(Token = "0x6001298")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return pit;
			}
		}

		[Token(Token = "0x6001293")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public qf(int _003C_003E1__state)
		{
			fbr();
			pis = _003C_003E1__state;
		}

		[Token(Token = "0x6001294")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void fbr()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001295")]
		[Address(RVA = "0x280270", Offset = "0x27F270", VA = "0x180280270", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001297")]
		[Address(RVA = "0x2804B0", Offset = "0x27F4B0", VA = "0x1802804B0", Slot = "8")]
		[DebuggerHidden]
		private void fbt()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CBD")]
	public AnimationCurve animCurve;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CBE")]
	[Tooltip("Animation speed multiplier")]
	public float speed = 1f;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001CBF")]
	private Vector3 pix;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001CC0")]
	public Transform target;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001CC1")]
	private Selectable piy;

	[Token(Token = "0x17000108")]
	public Selectable pxn
	{
		[Token(Token = "0x6001285")]
		[Address(RVA = "0x488670", Offset = "0x487670", VA = "0x180488670")]
		get
		{
			//IL_0010: Expected Obj, but got I4
			Selectable selectable = piy;
			int num = 0;
			if (selectable == (Object)num)
			{
				Selectable component = GetComponent<Selectable>();
				piy = component;
			}
			return piy;
		}
	}

	[Token(Token = "0x6001286")]
	[Address(RVA = "0x488300", Offset = "0x487300", VA = "0x180488300")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001287")]
	[Address(RVA = "0x4883A0", Offset = "0x4873A0", VA = "0x1804883A0")]
	private void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001288")]
	[Address(RVA = "0x4883E0", Offset = "0x4873E0", VA = "0x1804883E0", Slot = "4")]
	public void OnPointerDown(PointerEventData eventData)
	{
		//IL_0010: Expected Obj, but got I4
		Selectable selectable = pxn;
		int num = 0;
		if (!(selectable != (Object)num) || pxn.m_Interactable)
		{
			StopCoroutine("ScaleOUT");
			Coroutine coroutine = StartCoroutine("ScaleIN");
		}
	}

	[Token(Token = "0x6001289")]
	[Address(RVA = "0x4884B0", Offset = "0x4874B0", VA = "0x1804884B0", Slot = "5")]
	public void OnPointerUp(PointerEventData eventData)
	{
		//IL_0010: Expected Obj, but got I4
		Selectable selectable = pxn;
		int num = 0;
		if (!(selectable != (Object)num) || pxn.m_Interactable)
		{
			StopCoroutine("ScaleIN");
			Coroutine coroutine = StartCoroutine("ScaleOUT");
		}
	}

	[Token(Token = "0x600128A")]
	[Address(RVA = "0x488580", Offset = "0x487580", VA = "0x180488580")]
	[IteratorStateMachine(typeof(qe))]
	private IEnumerator ScaleIN()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600128B")]
	[Address(RVA = "0x4885F0", Offset = "0x4875F0", VA = "0x1804885F0")]
	[IteratorStateMachine(typeof(qf))]
	private IEnumerator ScaleOUT()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600128C")]
	[Address(RVA = "0x488660", Offset = "0x487660", VA = "0x180488660")]
	public SelectableScaler()
	{
	}
}
