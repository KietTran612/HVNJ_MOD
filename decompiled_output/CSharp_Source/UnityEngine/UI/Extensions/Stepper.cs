using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001B4")]
[AddComponentMenu("UI/Extensions/Stepper")]
[RequireComponent(typeof(RectTransform))]
public class Stepper : UIBehaviour
{
	[Serializable]
	[Token(Token = "0x20001B5")]
	public class StepperValueChangedEvent : UnityEvent<int>
	{
		[Token(Token = "0x6000EE1")]
		[Address(RVA = "0x275630", Offset = "0x274630", VA = "0x180275630")]
		public StepperValueChangedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Token(Token = "0x20001B6")]
	[CompilerGenerated]
	private sealed class oj : IEnumerator<object>, IEnumerator, IDisposable
	{
		[Cpp2IlInjected.FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40019E8")]
		private int ovu;

		[Cpp2IlInjected.FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40019E9")]
		private object ovv;

		[Cpp2IlInjected.FieldOffset(Offset = "0x20")]
		[Token(Token = "0x40019EA")]
		public Stepper ovw;

		[Token(Token = "0x1700006D")]
		private object prr
		{
			[Token(Token = "0x6000EE5")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "4")]
			[DebuggerHidden]
			get
			{
				return ovv;
			}
		}

		[Token(Token = "0x1700006E")]
		private object prs
		{
			[Token(Token = "0x6000EE7")]
			[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080", Slot = "7")]
			[DebuggerHidden]
			get
			{
				return ovv;
			}
		}

		[Token(Token = "0x6000EE2")]
		[Address(RVA = "0x200D70", Offset = "0x1FFD70", VA = "0x180200D70")]
		[DebuggerHidden]
		public oj(int _003C_003E1__state)
		{
			efa();
			ovu = _003C_003E1__state;
		}

		[Token(Token = "0x6000EE3")]
		[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
		[DebuggerHidden]
		private void efa()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000EE4")]
		[Address(RVA = "0x27B490", Offset = "0x27A490", VA = "0x18027B490", Slot = "6")]
		private bool MoveNext()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000EE6")]
		[Address(RVA = "0x27B4F0", Offset = "0x27A4F0", VA = "0x18027B4F0", Slot = "8")]
		[DebuggerHidden]
		private void efc()
		{
			NotSupportedException ex = new NotSupportedException();
			/*Error: End of method reached without returning.*/;
		}
	}

	[Cpp2IlInjected.FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40019DF")]
	private Selectable[] ovx;

	[Cpp2IlInjected.FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40019E0")]
	[SerializeField]
	[Tooltip("The current step value of the control")]
	private int _value;

	[Cpp2IlInjected.FieldOffset(Offset = "0x24")]
	[Token(Token = "0x40019E1")]
	[SerializeField]
	[Tooltip("The minimum step value allowed by the control. When reached it will disable the '-' button")]
	private int _minimum;

	[Cpp2IlInjected.FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40019E2")]
	[SerializeField]
	[Tooltip("The maximum step value allowed by the control. When reached it will disable the '+' button")]
	private int _maximum = 100;

	[Cpp2IlInjected.FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x40019E3")]
	[SerializeField]
	[Tooltip("The step increment used to increment / decrement the step value")]
	private int _step = 1;

	[Cpp2IlInjected.FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40019E4")]
	[SerializeField]
	[Tooltip("Does the step value loop around from end to end")]
	private bool _wrap;

	[Cpp2IlInjected.FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40019E5")]
	[SerializeField]
	[Tooltip("A GameObject with an Image to use as a separator between segments. Size of the RectTransform will determine the size of the separator used.\nNote, make sure to disable the separator GO so that it does not affect the scene")]
	private Graphic _separator;

	[Cpp2IlInjected.FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40019E6")]
	private float ovy;

	[Cpp2IlInjected.FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40019E7")]
	[SerializeField]
	private StepperValueChangedEvent _onValueChanged = new StepperValueChangedEvent();

	[Token(Token = "0x17000064")]
	private float prt
	{
		[Token(Token = "0x6000EC5")]
		[Address(RVA = "0x48CB20", Offset = "0x48BB20", VA = "0x18048CB20")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000065")]
	public Selectable[] pru
	{
		[Token(Token = "0x6000EC6")]
		[Address(RVA = "0x48CC70", Offset = "0x48BC70", VA = "0x18048CC70")]
		get
		{
			Selectable[] array = ovx;
			if (array == null || array.Length == 0)
			{
				Selectable[] componentsInChildren = GetComponentsInChildren<Selectable>();
				if (componentsInChildren.Length != 2)
				{
					InvalidOperationException ex = new InvalidOperationException("A stepper must have two Button children");
					/*Error: End of method reached without returning.*/;
				}
				if (!_wrap)
				{
					Selectable selectable = componentsInChildren[0];
					int minimum = _minimum;
					bool interactable = _value > minimum;
					selectable.interactable = interactable;
					Selectable selectable2 = componentsInChildren[1];
					if (_wrap)
					{
					}
					int maximum = _maximum;
					bool interactable2 = _value < maximum;
					selectable2.interactable = interactable2;
				}
				egd(componentsInChildren);
				ovx = componentsInChildren;
			}
			return array;
		}
	}

	[Token(Token = "0x17000066")]
	public int prv
	{
		[Token(Token = "0x6000EC7")]
		[Address(RVA = "0x335BE0", Offset = "0x334BE0", VA = "0x180335BE0")]
		get
		{
			return _value;
		}
		[Token(Token = "0x6000EC8")]
		[Address(RVA = "0x4457A0", Offset = "0x4447A0", VA = "0x1804457A0")]
		set
		{
			_value = value;
		}
	}

	[Token(Token = "0x17000067")]
	public int prw
	{
		[Token(Token = "0x6000EC9")]
		[Address(RVA = "0x335C20", Offset = "0x334C20", VA = "0x180335C20")]
		get
		{
			return _minimum;
		}
		[Token(Token = "0x6000ECA")]
		[Address(RVA = "0x335C80", Offset = "0x334C80", VA = "0x180335C80")]
		set
		{
			_minimum = value;
		}
	}

	[Token(Token = "0x17000068")]
	public int prx
	{
		[Token(Token = "0x6000ECB")]
		[Address(RVA = "0x333170", Offset = "0x332170", VA = "0x180333170")]
		get
		{
			return _maximum;
		}
		[Token(Token = "0x6000ECC")]
		[Address(RVA = "0x3331B0", Offset = "0x3321B0", VA = "0x1803331B0")]
		set
		{
			_maximum = value;
		}
	}

	[Token(Token = "0x17000069")]
	public int pry
	{
		[Token(Token = "0x6000ECD")]
		[Address(RVA = "0x48CDB0", Offset = "0x48BDB0", VA = "0x18048CDB0")]
		get
		{
			return _step;
		}
		[Token(Token = "0x6000ECE")]
		[Address(RVA = "0x48CDC0", Offset = "0x48BDC0", VA = "0x18048CDC0")]
		set
		{
			_step = value;
		}
	}

	[Token(Token = "0x1700006A")]
	public bool prz
	{
		[Token(Token = "0x6000ECF")]
		[Address(RVA = "0x3FCEB0", Offset = "0x3FBEB0", VA = "0x1803FCEB0")]
		get
		{
			return _wrap;
		}
		[Token(Token = "0x6000ED0")]
		[Address(RVA = "0x3FCF20", Offset = "0x3FBF20", VA = "0x1803FCF20")]
		set
		{
			_wrap = value;
		}
	}

	[Token(Token = "0x1700006B")]
	public Graphic psa
	{
		[Token(Token = "0x6000ED1")]
		[Address(RVA = "0x375280", Offset = "0x374280", VA = "0x180375280")]
		get
		{
			return _separator;
		}
		[Token(Token = "0x6000ED2")]
		[Address(RVA = "0x48CDD0", Offset = "0x48BDD0", VA = "0x18048CDD0")]
		set
		{
			_separator = value;
			ovy = 0f;
			Selectable[] sides = pru;
			egd(sides);
		}
	}

	[Token(Token = "0x1700006C")]
	public StepperValueChangedEvent psb
	{
		[Token(Token = "0x6000ED3")]
		[Address(RVA = "0x40D8C0", Offset = "0x40C8C0", VA = "0x18040D8C0")]
		get
		{
			return _onValueChanged;
		}
		[Token(Token = "0x6000ED4")]
		[Address(RVA = "0x3FECC0", Offset = "0x3FDCC0", VA = "0x1803FECC0")]
		set
		{
			_onValueChanged = value;
		}
	}

	[Token(Token = "0x6000ED5")]
	[Address(RVA = "0x48CAB0", Offset = "0x48BAB0", VA = "0x18048CAB0")]
	protected Stepper()
	{
		//IL_000a: Expected I4, but got I8
		//IL_0013: Expected I4, but got I8
	}

	[Token(Token = "0x6000ED6")]
	[Address(RVA = "0x48CA30", Offset = "0x48BA30", VA = "0x18048CA30", Slot = "6")]
	protected override void Start()
	{
		if (isActiveAndEnabled)
		{
			int num = default;
			oj oj2 = new oj(num);
			num = 0;
			oj2.ovw = this;
			Coroutine coroutine = StartCoroutine(oj2);
		}
	}

	[Token(Token = "0x6000ED7")]
	[Address(RVA = "0x48C9C0", Offset = "0x48B9C0", VA = "0x18048C9C0", Slot = "5")]
	protected override void OnEnable()
	{
		int num = default;
		oj oj2 = new oj(num);
		num = 0;
		oj2.ovw = this;
		Coroutine coroutine = StartCoroutine(oj2);
	}

	[Token(Token = "0x6000ED8")]
	[Address(RVA = "0x48CE00", Offset = "0x48BE00", VA = "0x18048CE00")]
	[IteratorStateMachine(typeof(oj))]
	private IEnumerator efv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000ED9")]
	[Address(RVA = "0x48CE70", Offset = "0x48BE70", VA = "0x18048CE70")]
	private Selectable[] efw()
	{
		Selectable[] componentsInChildren = GetComponentsInChildren<Selectable>();
		if (componentsInChildren.Length == 2)
		{
			if (!_wrap)
			{
				Selectable selectable = componentsInChildren[0];
				int minimum = _minimum;
				bool interactable = _value > minimum;
				selectable.interactable = interactable;
				Selectable selectable2 = componentsInChildren[1];
				if (_wrap)
				{
				}
				int maximum = _maximum;
				bool interactable2 = _value < maximum;
				selectable2.interactable = interactable2;
			}
			egd(componentsInChildren);
			return componentsInChildren;
		}
		InvalidOperationException ex = new InvalidOperationException("A stepper must have two Button children");
		/*Error: End of method reached without returning.*/;
	}

	[Token(Token = "0x6000EDA")]
	[Address(RVA = "0x48CFA0", Offset = "0x48BFA0", VA = "0x18048CFA0")]
	public void efx()
	{
		int step = _step;
		efz(step);
	}

	[Token(Token = "0x6000EDB")]
	[Address(RVA = "0x48CFB0", Offset = "0x48BFB0", VA = "0x18048CFB0")]
	public void efy()
	{
		int step = _step;
		efz(step);
	}

	[Token(Token = "0x6000EDC")]
	[Address(RVA = "0x48CFC0", Offset = "0x48BFC0", VA = "0x18048CFC0")]
	private void efz(int amount)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EDD")]
	[Address(RVA = "0x48D150", Offset = "0x48C150", VA = "0x18048D150")]
	private void ega(Selectable[] sides)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EDE")]
	[Address(RVA = "0x48D200", Offset = "0x48C200", VA = "0x18048D200")]
	private void egb(Selectable[] sides)
	{
		//IL_0018: Expected Obj, but got I4
		int num = 0;
		Image image = sides[num].image;
		int num2 = 0;
		if (!(image == (Object)num2))
		{
			Sprite sprite = sides[num].image.m_Sprite;
			bool leftmost = num == 0;
			Sprite sprite2 = egc(sprite, leftmost);
			StepperSide component = sides[num].GetComponent<StepperSide>();
			if ((bool)component)
			{
				component.ovz = sprite2;
			}
			sides[num].image.overrideSprite = sprite2;
		}
		num++;
	}

	[Token(Token = "0x6000EDF")]
	[Address(RVA = "0x48D3F0", Offset = "0x48C3F0", VA = "0x18048D3F0")]
	internal static Sprite egc(Sprite sprite, bool leftmost)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EE0")]
	[Address(RVA = "0x48D5A0", Offset = "0x48C5A0", VA = "0x18048D5A0")]
	public void egd([Optional] Selectable[] sides)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
