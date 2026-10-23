using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000229")]
[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("UI/Extensions/Tooltip/Tooltip Trigger")]
public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[Token(Token = "0x200022A")]
	public enum pq
	{
		[Token(Token = "0x4001C76")]
		mousePosition,
		[Token(Token = "0x4001C77")]
		mousePositionAndFollow,
		[Token(Token = "0x4001C78")]
		transformPosition
	}

	[Token(Token = "0x200022B")]
	[CompilerGenerated]
	private sealed class pr : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001C79")]
		private int pgr;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001C7A")]
		private object pgs;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001C7B")]
		public TooltipTrigger pgt;

		[Token(Token = "0x170000FA")]
		private object pwt
		{
			[Token(Token = "0x6001200")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return pgs;
			}
		}

		[Token(Token = "0x170000FB")]
		private object pwu
		{
			[Token(Token = "0x6001202")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return pgs;
			}
		}

		[Token(Token = "0x60011FD")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public pr(int _003C_003E1__state)
		{
			eyk();
			pgr = _003C_003E1__state;
		}

		[Token(Token = "0x60011FE")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void eyk()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x60011FF")]
		[Address(RVA = "0x27C890", Offset = "0x27B890", VA = "0x18027C890", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6001201")]
		[Address(RVA = "0x27C960", Offset = "0x27B960", VA = "0x18027C960", Slot = "8")]
		[DebuggerHidden]
		private void eym()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C70")]
	[TextArea]
	public string text;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C71")]
	[Tooltip("Defines where the tooltip will be placed and how that placement will occur. Transform position will always be used if this element wasn't selected via mouse")]
	public pq tooltipPositioningType;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001C72")]
	private bool pgu;

	[FieldOffset(Offset = "0x25")]
	[Token(Token = "0x4001C73")]
	private bool pgv;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001C74")]
	public Vector3 offset;

	[Token(Token = "0x170000F9")]
	public bool pwv
	{
		[Token(Token = "0x60011F4")]
		[Address(RVA = "0x878BE0", Offset = "0x877BE0", VA = "0x180878BE0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x60011F3")]
	[Address(RVA = "0x878B40", Offset = "0x877B40", VA = "0x180878B40")]
	private void Start()
	{
		Canvas componentInParent = GetComponentInParent<Canvas>();
		if ((bool)componentInParent && componentInParent.renderMode == RenderMode.ScreenSpaceOverlay)
		{
			pgu = true;
		}
	}

	[Token(Token = "0x60011F5")]
	[Address(RVA = "0x878740", Offset = "0x877740", VA = "0x180878740", Slot = "4")]
	public void OnPointerEnter(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011F6")]
	[Address(RVA = "0x878C40", Offset = "0x877C40", VA = "0x180878C40")]
	[IteratorStateMachine(typeof(pr))]
	private IEnumerator eyp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011F7")]
	[Address(RVA = "0x8789E0", Offset = "0x8779E0", VA = "0x1808789E0", Slot = "6")]
	public void OnSelect(BaseEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011F8")]
	[Address(RVA = "0x8786F0", Offset = "0x8776F0", VA = "0x1808786F0", Slot = "5")]
	public void OnPointerExit(PointerEventData eventData)
	{
		pgv = false;
		int num = 0;
		ToolTip toolTip = ToolTip.pws;
		GameObject gameObject = toolTip.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
		toolTip.pgd = false;
	}

	[Token(Token = "0x60011F9")]
	[Address(RVA = "0x8786F0", Offset = "0x8776F0", VA = "0x1808786F0", Slot = "7")]
	public void OnDeselect(BaseEventData eventData)
	{
		pgv = false;
		int num = 0;
		ToolTip toolTip = ToolTip.pws;
		GameObject gameObject = toolTip.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
		toolTip.pgd = false;
	}

	[Token(Token = "0x60011FA")]
	[Address(RVA = "0x878CB0", Offset = "0x877CB0", VA = "0x180878CB0")]
	private void eyq(Vector3 position, bool shouldCanvasUpdate = false)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011FB")]
	[Address(RVA = "0x8786F0", Offset = "0x8776F0", VA = "0x1808786F0")]
	private void eyr()
	{
		pgv = false;
		int num = 0;
		ToolTip toolTip = ToolTip.pws;
		GameObject gameObject = toolTip.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
		toolTip.pgd = false;
	}

	[Token(Token = "0x60011FC")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public TooltipTrigger()
	{
	}
}
