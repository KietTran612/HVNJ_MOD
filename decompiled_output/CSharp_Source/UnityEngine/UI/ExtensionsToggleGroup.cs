using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI;

[Token(Token = "0x200017F")]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extensions/Extensions Toggle Group")]
public class ExtensionsToggleGroup : UIBehaviour
{
	[Serializable]
	[Token(Token = "0x2000180")]
	public class ToggleGroupEvent : UnityEvent<bool>
	{
		[Token(Token = "0x6000D75")]
		[Address(RVA = "0x2756F0", Offset = "0x2746F0", VA = "0x1802756F0")]
		public ToggleGroupEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Serializable]
	[Token(Token = "0x2000181")]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		[Token(Token = "0x40018C8")]
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		[Token(Token = "0x40018C9")]
		public static Predicate<ExtensionsToggle> _003C_003E9__18_0;

		[Token(Token = "0x40018CA")]
		public static Func<ExtensionsToggle, bool> _003C_003E9__19_0;

		[Token(Token = "0x6000D77")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public _003C_003Ec()
		{
		}

		[Token(Token = "0x6000D78")]
		[Address(RVA = "0x275A60", Offset = "0x274A60", VA = "0x180275A60")]
		internal bool dwd(ExtensionsToggle x)
		{
			return x.m_IsOn;
		}

		[Token(Token = "0x6000D79")]
		[Address(RVA = "0x275A60", Offset = "0x274A60", VA = "0x180275A60")]
		internal bool dwe(ExtensionsToggle x)
		{
			return x.m_IsOn;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40018C3")]
	[SerializeField]
	private bool m_AllowSwitchOff;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40018C4")]
	private List<ExtensionsToggle> opl = (List<ExtensionsToggle>)(object)new List<T>();

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40018C5")]
	public ToggleGroupEvent onToggleGroupChanged = new ToggleGroupEvent();

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40018C6")]
	public ToggleGroupEvent onToggleGroupToggleChanged = new ToggleGroupEvent();

	[Token(Token = "0x1700001E")]
	public bool pph
	{
		[Token(Token = "0x6000D66")]
		[Address(RVA = "0x349AD0", Offset = "0x348AD0", VA = "0x180349AD0")]
		get
		{
			return m_AllowSwitchOff;
		}
		[Token(Token = "0x6000D67")]
		[Address(RVA = "0x403610", Offset = "0x402610", VA = "0x180403610")]
		set
		{
			m_AllowSwitchOff = value;
		}
	}

	[Token(Token = "0x1700001F")]
	[field: FieldOffset(Offset = "0x38")]
	[field: Token(Token = "0x40018C7")]
	public ExtensionsToggle opm
	{
		[Token(Token = "0x6000D68")]
		[Address(RVA = "0x375280", Offset = "0x374280", VA = "0x180375280")]
		get;
		[Token(Token = "0x6000D69")]
		[Address(RVA = "0x3F8E50", Offset = "0x3F7E50", VA = "0x1803F8E50")]
		private set;
	}

	[Token(Token = "0x6000D6A")]
	[Address(RVA = "0x6A1500", Offset = "0x6A0500", VA = "0x1806A1500")]
	protected ExtensionsToggleGroup()
	{
	}

	[Token(Token = "0x6000D6B")]
	[Address(RVA = "0x6A15C0", Offset = "0x6A05C0", VA = "0x1806A15C0")]
	private void dwj(ExtensionsToggle toggle)
	{
		//IL_0009: Expected Obj, but got I4
		//IL_0018: Expected VT, but got Obj
		int num = 0;
		if (!(toggle == (Object)num) && ((List<T>)(object)opl).Contains((T)toggle))
		{
			return;
		}
		object[] array = new object[2];
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000D6C")]
	[Address(RVA = "0x6A1720", Offset = "0x6A0720", VA = "0x1806A1720")]
	public void dwk(ExtensionsToggle toggle)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D6D")]
	[Address(RVA = "0x6A19C0", Offset = "0x6A09C0", VA = "0x1806A19C0")]
	public void dwl(ExtensionsToggle toggle)
	{
		//IL_000c: Expected VT, but got Obj
		//IL_001b: Expected VT, but got Obj
		if (((List<T>)(object)opl).Contains((T)toggle))
		{
			bool flag = ((List<T>)(object)opl).Remove((T)toggle);
			ExtensionsToggle.ToggleEvent onValueChanged = toggle.onValueChanged;
			UnityAction<bool> unityAction = (UnityAction<bool>)(object)new UnityAction<T0>(dwm);
			((UnityEvent<T0>)(object)onValueChanged).RemoveListener((UnityAction<>)(object)unityAction);
		}
	}

	[Token(Token = "0x6000D6E")]
	[Address(RVA = "0x6A1AD0", Offset = "0x6A0AD0", VA = "0x1806A1AD0")]
	private void dwm(bool isOn)
	{
		//IL_000c: Expected VT, but got I4
		((UnityEvent<T0>)(object)onToggleGroupToggleChanged).Invoke((T0)isOn);
	}

	[Token(Token = "0x6000D6F")]
	[Address(RVA = "0x6A1B30", Offset = "0x6A0B30", VA = "0x1806A1B30")]
	public void dwn(ExtensionsToggle toggle)
	{
		//IL_000c: Expected VT, but got Obj
		//IL_001b: Expected VT, but got Obj
		if (!((List<T>)(object)opl).Contains((T)toggle))
		{
			((List<T>)(object)opl).Add((T)toggle);
			ExtensionsToggle.ToggleEvent onValueChanged = toggle.onValueChanged;
			UnityAction<bool> unityAction = (UnityAction<bool>)(object)new UnityAction<T0>(dwm);
			((UnityEvent<T0>)(object)onValueChanged).AddListener((UnityAction<>)(object)unityAction);
		}
	}

	[Token(Token = "0x6000D70")]
	[Address(RVA = "0x6A1C40", Offset = "0x6A0C40", VA = "0x1806A1C40")]
	public bool dwo()
	{
		//IL_002e: Expected Obj, but got VT
		//IL_0037: Expected Obj, but got I4
		List<ExtensionsToggle> list = opl;
		Predicate<ExtensionsToggle> predicate = _003C_003Ec._003C_003E9__18_0;
		if (predicate == null)
		{
			_003C_003Ec._003C_003E9__18_0 = (Predicate<ExtensionsToggle>)(object)(Predicate<T>)([Token(Token = "0x6000D78")] [Address(RVA = "0x275A60", Offset = "0x274A60", VA = "0x180275A60")] (ExtensionsToggle x) => x.m_IsOn);
		}
		ExtensionsToggle extensionsToggle = (ExtensionsToggle)((List<T>)(object)list).Find((Predicate<>)(object)predicate);
		int num = 0;
		return extensionsToggle != (Object)num;
	}

	[Token(Token = "0x6000D71")]
	[Address(RVA = "0x6A1DA0", Offset = "0x6A0DA0", VA = "0x1806A1DA0")]
	public IEnumerable<ExtensionsToggle> dwp()
	{
		List<ExtensionsToggle> list = opl;
		Func<ExtensionsToggle, bool> func = _003C_003Ec._003C_003E9__19_0;
		if (func == null)
		{
			_003C_003Ec._003C_003E9__19_0 = (Func<ExtensionsToggle, bool>)(object)(Func<T, TResult>)([Token(Token = "0x6000D79")] [Address(RVA = "0x275A60", Offset = "0x274A60", VA = "0x180275A60")] (ExtensionsToggle x) => x.m_IsOn);
		}
		return (IEnumerable<ExtensionsToggle>)Enumerable.Where<ExtensionsToggle>((IEnumerable<>)list, (Func<, >)(object)func);
	}

	[Token(Token = "0x6000D72")]
	[Address(RVA = "0x6A1EC0", Offset = "0x6A0EC0", VA = "0x1806A1EC0")]
	public void dwq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D73")]
	[Address(RVA = "0x6A1F90", Offset = "0x6A0F90", VA = "0x1806A1F90")]
	public void dwr(bool value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D74")]
	[Address(RVA = "0x6A2030", Offset = "0x6A1030", VA = "0x1806A2030")]
	public void dws(bool value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
