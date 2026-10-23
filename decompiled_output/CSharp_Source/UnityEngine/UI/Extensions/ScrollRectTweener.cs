using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000242")]
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("UI/Extensions/ScrollRectTweener")]
public class ScrollRectTweener : MonoBehaviour, IDragHandler, IEventSystemHandler
{
	[Token(Token = "0x2000243")]
	[CompilerGenerated]
	private sealed class qd : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001CB7")]
		private int pib;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001CB8")]
		private object pic;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001CB9")]
		public float pie;

		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4001CBA")]
		public ScrollRectTweener pif;

		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4001CBB")]
		private Vector2 pig;

		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4001CBC")]
		private float pih;

		[Token(Token = "0x17000106")]
		private object pxg
		{
			[Token(Token = "0x6001282")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return pic;
			}
		}

		[Token(Token = "0x17000107")]
		private object pxi
		{
			[Token(Token = "0x6001284")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return pic;
			}
		}

		[Token(Token = "0x600127F")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public qd(int _003C_003E1__state)
		{
			fav();
			pib = _003C_003E1__state;
		}

		[Token(Token = "0x6001280")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void fav()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001281")]
		[Address(RVA = "0x27FE70", Offset = "0x27EE70", VA = "0x18027FE70", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001283")]
		[Address(RVA = "0x27FFE0", Offset = "0x27EFE0", VA = "0x18027FFE0", Slot = "8")]
		[DebuggerHidden]
		private void fax()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CB0")]
	private ScrollRect pii;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CB1")]
	private Vector2 pij;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001CB2")]
	private Vector2 pik;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001CB3")]
	private bool pil;

	[FieldOffset(Offset = "0x31")]
	[Token(Token = "0x4001CB4")]
	private bool pim;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001CB5")]
	public float moveSpeed = 5000f;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001CB6")]
	public bool disableDragWhileTweening;

	[Token(Token = "0x600126E")]
	[Address(RVA = "0x4800E0", Offset = "0x47F0E0", VA = "0x1804800E0")]
	private void Awake()
	{
		ScrollRect scrollRect = (pii = GetComponent<ScrollRect>());
		bool horizontal = scrollRect.m_Horizontal;
		pil = horizontal;
		bool vertical = scrollRect.m_Vertical;
		pim = vertical;
	}

	[Token(Token = "0x600126F")]
	[Address(RVA = "0x4801A0", Offset = "0x47F1A0", VA = "0x1804801A0")]
	public void faz(float normalizedX)
	{
		//IL_0017: Expected VT, but got I4
		ScrollRect scrollRect = pii;
		int num = 0;
		float verticalNormalizedPosition = scrollRect.verticalNormalizedPosition;
		fbd((Vector2)num);
	}

	[Token(Token = "0x6001270")]
	[Address(RVA = "0x4801F0", Offset = "0x47F1F0", VA = "0x1804801F0")]
	public void fba(float normalizedX, float duration)
	{
		//IL_0018: Expected VT, but got I4
		ScrollRect scrollRect = pii;
		int num = 0;
		float verticalNormalizedPosition = scrollRect.verticalNormalizedPosition;
		fbh((Vector2)num, duration);
	}

	[Token(Token = "0x6001271")]
	[Address(RVA = "0x480250", Offset = "0x47F250", VA = "0x180480250")]
	public void fbb(float normalizedY)
	{
		//IL_0017: Expected VT, but got I4
		ScrollRect scrollRect = pii;
		int num = 0;
		float horizontalNormalizedPosition = scrollRect.horizontalNormalizedPosition;
		fbd((Vector2)num);
	}

	[Token(Token = "0x6001272")]
	[Address(RVA = "0x4802A0", Offset = "0x47F2A0", VA = "0x1804802A0")]
	public void fbc(float normalizedY, float duration)
	{
		//IL_0018: Expected VT, but got I4
		ScrollRect scrollRect = pii;
		int num = 0;
		float horizontalNormalizedPosition = scrollRect.horizontalNormalizedPosition;
		fbh((Vector2)num, duration);
	}

	[Token(Token = "0x6001273")]
	[Address(RVA = "0x480300", Offset = "0x47F300", VA = "0x180480300")]
	public void fbd(Vector2 normalizedPos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001274")]
	[Address(RVA = "0x4803A0", Offset = "0x47F3A0", VA = "0x1804803A0")]
	private float fbe(Vector2 normalizedPos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001275")]
	[Address(RVA = "0x480430", Offset = "0x47F430", VA = "0x180480430")]
	private Vector2 fbf(Vector2 normalizedPos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001276")]
	[Address(RVA = "0x4804F0", Offset = "0x47F4F0", VA = "0x1804804F0")]
	private Vector2 fbg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001277")]
	[Address(RVA = "0x480540", Offset = "0x47F540", VA = "0x180480540")]
	public unsafe void fbh(Vector2 normalizedPos, float duration)
	{
		//IL_001f: Expected VT, but got F4
		//IL_0026: Expected native int or pointer, but got VT
		float horizontalNormalizedPosition = pii.horizontalNormalizedPosition;
		float verticalNormalizedPosition = pii.verticalNormalizedPosition;
		pij = (Vector2)horizontalNormalizedPosition;
		((Vector2*)(nint)pij)->y = verticalNormalizedPosition;
		if (disableDragWhileTweening)
		{
			pii.m_Horizontal = false;
			pii.m_Vertical = false;
		}
		StopAllCoroutines();
		int num = default;
		qd qd2 = new qd(num);
		num = 0;
		qd2.pie = duration;
		qd2.pif = this;
		Coroutine coroutine = StartCoroutine(qd2);
	}

	[Token(Token = "0x6001278")]
	[Address(RVA = "0x480650", Offset = "0x47F650", VA = "0x180480650")]
	[IteratorStateMachine(typeof(qd))]
	private IEnumerator fbi(float duration)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001279")]
	[Address(RVA = "0x4806D0", Offset = "0x47F6D0", VA = "0x1804806D0")]
	public Vector2 fbj(float currentTime, Vector2 startValue, Vector2 changeInValue, float duration)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600127A")]
	[Address(RVA = "0x480140", Offset = "0x47F140", VA = "0x180480140", Slot = "4")]
	public void OnDrag(PointerEventData eventData)
	{
		if (!disableDragWhileTweening)
		{
			StopAllCoroutines();
			if (disableDragWhileTweening)
			{
				ScrollRect scrollRect = pii;
				bool horizontal = pil;
				scrollRect.m_Horizontal = horizontal;
				ScrollRect scrollRect2 = pii;
				bool vertical = pim;
				scrollRect2.m_Vertical = vertical;
			}
		}
	}

	[Token(Token = "0x600127B")]
	[Address(RVA = "0x480740", Offset = "0x47F740", VA = "0x180480740")]
	private void fbk()
	{
		StopAllCoroutines();
		if (disableDragWhileTweening)
		{
			ScrollRect scrollRect = pii;
			bool horizontal = pil;
			scrollRect.m_Horizontal = horizontal;
			ScrollRect scrollRect2 = pii;
			bool vertical = pim;
			scrollRect2.m_Vertical = vertical;
		}
	}

	[Token(Token = "0x600127C")]
	[Address(RVA = "0x480790", Offset = "0x47F790", VA = "0x180480790")]
	private void fbl()
	{
		pii.m_Horizontal = false;
		pii.m_Vertical = false;
	}

	[Token(Token = "0x600127D")]
	[Address(RVA = "0x4807C0", Offset = "0x47F7C0", VA = "0x1804807C0")]
	private void fbm()
	{
		ScrollRect scrollRect = pii;
		bool horizontal = pil;
		scrollRect.m_Horizontal = horizontal;
		ScrollRect scrollRect2 = pii;
		bool vertical = pim;
		scrollRect2.m_Vertical = vertical;
	}

	[Token(Token = "0x600127E")]
	[Address(RVA = "0x480190", Offset = "0x47F190", VA = "0x180480190")]
	public ScrollRectTweener()
	{
	}
}
