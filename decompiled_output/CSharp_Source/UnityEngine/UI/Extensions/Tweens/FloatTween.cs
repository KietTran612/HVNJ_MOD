using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions.Tweens;

[Token(Token = "0x2000267")]
public struct FloatTween : qp
{
	[Token(Token = "0x2000268")]
	public class FloatTweenCallback : UnityEvent<float>
	{
		[Token(Token = "0x6001373")]
		[Address(RVA = "0x2740D0", Offset = "0x2730D0", VA = "0x1802740D0")]
		public FloatTweenCallback()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Token(Token = "0x2000269")]
	public class FloatFinishCallback : UnityEvent
	{
		[Token(Token = "0x6001374")]
		[Address(RVA = "0x2740C0", Offset = "0x2730C0", VA = "0x1802740C0")]
		public FloatFinishCallback()
		{
		}
	}

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001D6F")]
	private float pmb;

	[FieldOffset(Offset = "0x4")]
	[Token(Token = "0x4001D70")]
	private float pmc;

	[FieldOffset(Offset = "0x8")]
	[Token(Token = "0x4001D71")]
	private float pmd;

	[FieldOffset(Offset = "0xC")]
	[Token(Token = "0x4001D72")]
	private bool pme;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001D73")]
	private FloatTweenCallback pmf;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D74")]
	private FloatFinishCallback pmg;

	[Token(Token = "0x1700012B")]
	public float pyo
	{
		[Token(Token = "0x6001364")]
		[Address(RVA = "0x370C80", Offset = "0x36FC80", VA = "0x180370C80")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6001365")]
		[Address(RVA = "0x370E60", Offset = "0x36FE60", VA = "0x180370E60")]
		set
		{
			pmb = value;
		}
	}

	[Token(Token = "0x1700012C")]
	public float pyp
	{
		[Token(Token = "0x6001366")]
		[Address(RVA = "0x370C90", Offset = "0x36FC90", VA = "0x180370C90")]
		get
		{
			return pmc;
		}
		[Token(Token = "0x6001367")]
		[Address(RVA = "0x370E70", Offset = "0x36FE70", VA = "0x180370E70")]
		set
		{
			pmc = value;
		}
	}

	[Token(Token = "0x1700012D")]
	public float pyq
	{
		[Token(Token = "0x6001368")]
		[Address(RVA = "0x370CA0", Offset = "0x36FCA0", VA = "0x180370CA0", Slot = "6")]
		get
		{
			return pmd;
		}
		[Token(Token = "0x6001369")]
		[Address(RVA = "0x370E80", Offset = "0x36FE80", VA = "0x180370E80")]
		set
		{
			pmd = value;
		}
	}

	[Token(Token = "0x1700012E")]
	public bool pyr
	{
		[Token(Token = "0x600136A")]
		[Address(RVA = "0x6A2B30", Offset = "0x6A1B30", VA = "0x1806A2B30", Slot = "5")]
		get
		{
			return pme;
		}
		[Token(Token = "0x600136B")]
		[Address(RVA = "0x6A2B40", Offset = "0x6A1B40", VA = "0x1806A2B40")]
		set
		{
			pme = value;
		}
	}

	[Token(Token = "0x600136C")]
	[Address(RVA = "0x6A2B50", Offset = "0x6A1B50", VA = "0x1806A2B50", Slot = "4")]
	public void fgv(float floatPercentage)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600136D")]
	[Address(RVA = "0x6A2BC0", Offset = "0x6A1BC0", VA = "0x1806A2BC0")]
	public void fgw(UnityAction<float> callback)
	{
		FloatTweenCallback floatTweenCallback = pmf;
		if (floatTweenCallback == null)
		{
			FloatTweenCallback floatTweenCallback2 = new FloatTweenCallback();
			pmf = floatTweenCallback2;
		}
		((UnityEvent<T0>)(object)floatTweenCallback).AddListener((UnityAction<>)(object)callback);
	}

	[Token(Token = "0x600136E")]
	[Address(RVA = "0x6A2C50", Offset = "0x6A1C50", VA = "0x1806A2C50")]
	public void fgx(UnityAction callback)
	{
		FloatFinishCallback floatFinishCallback = pmg;
		if (floatFinishCallback == null)
		{
			FloatFinishCallback floatFinishCallback2 = new FloatFinishCallback();
			pmg = floatFinishCallback2;
		}
		floatFinishCallback.AddListener(callback);
	}

	[Token(Token = "0x600136F")]
	[Address(RVA = "0x6A2B30", Offset = "0x6A1B30", VA = "0x1806A2B30")]
	public bool fgy()
	{
		return pme;
	}

	[Token(Token = "0x6001370")]
	[Address(RVA = "0x370CA0", Offset = "0x36FCA0", VA = "0x180370CA0")]
	public float fgz()
	{
		return pmd;
	}

	[Token(Token = "0x6001371")]
	[Address(RVA = "0x54BBD0", Offset = "0x54ABD0", VA = "0x18054BBD0", Slot = "7")]
	public bool fha()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001372")]
	[Address(RVA = "0x6A2CD0", Offset = "0x6A1CD0", VA = "0x1806A2CD0", Slot = "8")]
	public void fhb()
	{
		pmg?.Invoke();
	}
}
