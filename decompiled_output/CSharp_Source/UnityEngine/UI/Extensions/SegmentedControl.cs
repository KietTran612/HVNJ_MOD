using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001AD")]
[AddComponentMenu("UI/Extensions/Segmented Control/Segmented Control")]
[RequireComponent(typeof(RectTransform))]
public class SegmentedControl : UIBehaviour
{
	[Serializable]
	[Token(Token = "0x20001AE")]
	public class SegmentSelectedEvent : UnityEvent<int>
	{
		[Token(Token = "0x6000E9F")]
		[Address(RVA = "0x2753B0", Offset = "0x2743B0", VA = "0x1802753B0")]
		public SegmentSelectedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Token(Token = "0x20001AF")]
	[CompilerGenerated]
	private sealed class oh : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40019CD")]
		private int ovd;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40019CE")]
		private object ove;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40019CF")]
		public SegmentedControl ovf;

		[Token(Token = "0x1700005D")]
		private object prg
		{
			[Token(Token = "0x6000EA3")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return ove;
			}
		}

		[Token(Token = "0x1700005E")]
		private object prh
		{
			[Token(Token = "0x6000EA5")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return ove;
			}
		}

		[Token(Token = "0x6000EA0")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public oh(int _003C_003E1__state)
		{
			edl();
			ovd = _003C_003E1__state;
		}

		[Token(Token = "0x6000EA1")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void edl()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000EA2")]
		[Address(RVA = "0x27B3E0", Offset = "0x27A3E0", VA = "0x18027B3E0", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000EA4")]
		[Address(RVA = "0x27B450", Offset = "0x27A450", VA = "0x18027B450", Slot = "8")]
		[DebuggerHidden]
		private void edn()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40019C6")]
	private Selectable[] ovg;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40019C7")]
	[SerializeField]
	[Tooltip("A GameObject with an Image to use as a separator between segments. Size of the RectTransform will determine the size of the separator used.\nNote, make sure to disable the separator GO so that it does not affect the scene")]
	private Graphic m_separator;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40019C8")]
	private float ovh;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x40019C9")]
	[SerializeField]
	[Tooltip("When True, it allows each button to be toggled on/off")]
	private bool m_allowSwitchingOff;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40019CA")]
	[SerializeField]
	[Tooltip("The selected default for the control (zero indexed array)")]
	private int m_selectedSegmentIndex = -1;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40019CB")]
	[SerializeField]
	[Tooltip("Event to fire once the selection has been changed")]
	private SegmentSelectedEvent m_onValueChanged = new SegmentSelectedEvent();

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40019CC")]
	internal Selectable ovi;

	[Token(Token = "0x17000057")]
	protected float pri
	{
		[Token(Token = "0x6000E8D")]
		[Address(RVA = "0x487220", Offset = "0x486220", VA = "0x180487220")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000058")]
	public Selectable[] prj
	{
		[Token(Token = "0x6000E8E")]
		[Address(RVA = "0x487370", Offset = "0x486370", VA = "0x180487370")]
		get
		{
			//IL_0042: Expected Obj, but got I4
			Selectable[] array = ovg;
			if (array == null || array.Length == 0)
			{
				Selectable[] componentsInChildren = GetComponentsInChildren<Selectable>();
				int num = 0;
				int length = componentsInChildren.Length;
				if (num < length)
				{
					Segment component = componentsInChildren[num].GetComponent<Segment>();
					int num2 = 0;
					if (component != (Object)num2)
					{
						component.ova = num;
						component.ovb = this;
					}
					num++;
				}
				ovg = componentsInChildren;
			}
			return array;
		}
	}

	[Token(Token = "0x17000059")]
	public Graphic prk
	{
		[Token(Token = "0x6000E8F")]
		[Address(RVA = "0x27CB90", Offset = "0x27BB90", VA = "0x18027CB90")]
		get
		{
			return m_separator;
		}
		[Token(Token = "0x6000E90")]
		[Address(RVA = "0x4874E0", Offset = "0x4864E0", VA = "0x1804874E0")]
		set
		{
			m_separator = value;
			ovh = 0f;
			eef();
		}
	}

	[Token(Token = "0x1700005A")]
	public bool prl
	{
		[Token(Token = "0x6000E91")]
		[Address(RVA = "0x487500", Offset = "0x486500", VA = "0x180487500")]
		get
		{
			return m_allowSwitchingOff;
		}
		[Token(Token = "0x6000E92")]
		[Address(RVA = "0x487510", Offset = "0x486510", VA = "0x180487510")]
		set
		{
			m_allowSwitchingOff = value;
		}
	}

	[Token(Token = "0x1700005B")]
	public int prm
	{
		[Token(Token = "0x6000E93")]
		[Address(RVA = "0x487520", Offset = "0x486520", VA = "0x180487520")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000E94")]
		[Address(RVA = "0x487570", Offset = "0x486570", VA = "0x180487570")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x1700005C")]
	public SegmentSelectedEvent prn
	{
		[Token(Token = "0x6000E95")]
		[Address(RVA = "0x375280", Offset = "0x374280", VA = "0x180375280")]
		get
		{
			return m_onValueChanged;
		}
		[Token(Token = "0x6000E96")]
		[Address(RVA = "0x3F8E50", Offset = "0x3F7E50", VA = "0x1803F8E50")]
		set
		{
			m_onValueChanged = value;
		}
	}

	[Token(Token = "0x6000E97")]
	[Address(RVA = "0x4871B0", Offset = "0x4861B0", VA = "0x1804871B0")]
	protected SegmentedControl()
	{
		//IL_0010: Expected I4, but got I8
	}

	[Token(Token = "0x6000E98")]
	[Address(RVA = "0x487120", Offset = "0x486120", VA = "0x180487120", Slot = "6")]
	protected override void Start()
	{
		((object)this)._002Ector();
		if (isActiveAndEnabled)
		{
			int num = default;
			oh oh2 = new oh(num);
			num = 0;
			oh2.ovf = this;
			Coroutine coroutine = StartCoroutine(oh2);
		}
	}

	[Token(Token = "0x6000E99")]
	[Address(RVA = "0x4870B0", Offset = "0x4860B0", VA = "0x1804870B0", Slot = "5")]
	protected override void OnEnable()
	{
		int num = default;
		oh oh2 = new oh(num);
		num = 0;
		oh2.ovf = this;
		Coroutine coroutine = StartCoroutine(oh2);
	}

	[Token(Token = "0x6000E9A")]
	[Address(RVA = "0x487740", Offset = "0x486740", VA = "0x180487740")]
	[IteratorStateMachine(typeof(oh))]
	private IEnumerator eeb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E9B")]
	[Address(RVA = "0x4877B0", Offset = "0x4867B0", VA = "0x1804877B0")]
	private Selectable[] eec()
	{
		//IL_002c: Expected Obj, but got I4
		Selectable[] componentsInChildren = GetComponentsInChildren<Selectable>();
		int num = 0;
		int length = componentsInChildren.Length;
		if (num < length)
		{
			Segment component = componentsInChildren[num].GetComponent<Segment>();
			int num2 = 0;
			if (component != (Object)num2)
			{
				component.ova = num;
				component.ovb = this;
			}
			num++;
		}
		return componentsInChildren;
	}

	[Token(Token = "0x6000E9C")]
	[Address(RVA = "0x487910", Offset = "0x486910", VA = "0x180487910")]
	private void eed()
	{
		//IL_0030: Expected Obj, but got I4
		int num = 0;
		Selectable[] array = prj;
		if (num >= array.Length)
		{
			return;
		}
		Image image = prj[num].image;
		int num2 = 0;
		if (!(image == (Object)num2))
		{
			Sprite sprite = prj[num].image.m_Sprite;
			int length = prj.Length;
			bool rightmost = num == length;
			bool leftmost = num == 0;
			Sprite sprite2 = eee(sprite, leftmost, rightmost);
			Segment component = prj[num].GetComponent<Segment>();
			if ((bool)component)
			{
				component.ovc = sprite2;
			}
			prj[num].image.overrideSprite = sprite2;
		}
		num++;
		Selectable[] array2 = prj;
	}

	[Token(Token = "0x6000E9D")]
	[Address(RVA = "0x487B80", Offset = "0x486B80", VA = "0x180487B80")]
	internal static Sprite eee(Sprite sprite, bool leftmost, bool rightmost)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E9E")]
	[Address(RVA = "0x487D40", Offset = "0x486D40", VA = "0x180487D40")]
	public void eef()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
