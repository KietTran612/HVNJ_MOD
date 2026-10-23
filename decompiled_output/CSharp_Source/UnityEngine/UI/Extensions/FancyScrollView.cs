using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001F0")]
public abstract class FancyScrollView<TData, TContext> : MonoBehaviour where TContext : class
{
	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001B00")]
	[SerializeField]
	[Range(float.Epsilon, 1f)]
	private float cellInterval;

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001B01")]
	[SerializeField]
	[Range(0f, 1f)]
	private float cellOffset;

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001B02")]
	[SerializeField]
	private bool loop;

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001B03")]
	[SerializeField]
	private GameObject cellBase;

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001B04")]
	[SerializeField]
	private Transform cellContainer;

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001B05")]
	private readonly List<FancyScrollViewCell<TData, TContext>> par;

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001B06")]
	private float pas;

	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001B07")]
	protected List<TData> pat;

	[Token(Token = "0x170000A7")]
	protected TContext pau
	{
		[Token(Token = "0x6001032")]
		[Address(RVA = "0x337730", Offset = "0x336730", VA = "0x180337730")]
		[CompilerGenerated]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6001033")]
		[Address(RVA = "0x3E96F0", Offset = "0x3E86F0", VA = "0x1803E96F0")]
		[CompilerGenerated]
		private set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x6001034")]
	[Address(RVA = "0x56E570", Offset = "0x56D570", VA = "0x18056E570")]
	protected void emu(TContext context)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001035")]
	[Address(RVA = "0x56E650", Offset = "0x56D650", VA = "0x18056E650")]
	protected void emv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001036")]
	[Address(RVA = "0x56E680", Offset = "0x56D680", VA = "0x18056E680")]
	protected void emw(float position, bool forceUpdateContents = false)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001037")]
	[Address(RVA = "0x56E960", Offset = "0x56D960", VA = "0x18056E960")]
	private void emx(FancyScrollViewCell<TData, TContext> cell, int dataIndex, bool forceUpdateContents = false)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001038")]
	[Address(RVA = "0x56EB00", Offset = "0x56DB00", VA = "0x18056EB00")]
	private FancyScrollViewCell<TData, TContext> emy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001039")]
	[Address(RVA = "0x56EC30", Offset = "0x56DC30", VA = "0x18056EC30")]
	private int emz(int index, int maxSize)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600103A")]
	[Address(RVA = "0x56E4A0", Offset = "0x56D4A0", VA = "0x18056E4A0")]
	protected FancyScrollView()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
[Token(Token = "0x20001F2")]
public abstract class FancyScrollView<TData> : FancyScrollView<TData, ox>
{
	[Token(Token = "0x600103C")]
	[Address(RVA = "0x3B6BB0", Offset = "0x3B5BB0", VA = "0x1803B6BB0")]
	protected FancyScrollView()
	{
		((BaseInputModule)(object)this).Process();
	}
}
