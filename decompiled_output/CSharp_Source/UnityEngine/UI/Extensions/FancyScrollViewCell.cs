using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001F3")]
public abstract class FancyScrollViewCell<TData, TContext> : MonoBehaviour where TContext : class
{
	[Token(Token = "0x170000A8")]
	public int pav
	{
		[Token(Token = "0x600103D")]
		[Address(RVA = "0x274B10", Offset = "0x273B10", VA = "0x180274B10")]
		[CompilerGenerated]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x600103E")]
		[Address(RVA = "0x56E3F0", Offset = "0x56D3F0", VA = "0x18056E3F0")]
		[CompilerGenerated]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000A9")]
	public virtual bool puf
	{
		[Token(Token = "0x600103F")]
		[Address(RVA = "0x56E400", Offset = "0x56D400", VA = "0x18056E400", Slot = "4")]
		get
		{
			return gameObject.activeSelf;
		}
	}

	[Token(Token = "0x170000AA")]
	protected TContext paw
	{
		[Token(Token = "0x6001040")]
		[Address(RVA = "0x27CB90", Offset = "0x27BB90", VA = "0x18027CB90")]
		[CompilerGenerated]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6001041")]
		[Address(RVA = "0x378330", Offset = "0x377330", VA = "0x180378330")]
		[CompilerGenerated]
		private set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x6001042")]
	[Address(RVA = "0x56E430", Offset = "0x56D430", VA = "0x18056E430", Slot = "5")]
	public virtual void eng(TContext context)
	{
		((BaseInputModule)this).Process();
	}

	[Token(Token = "0x6001043")]
	[Address(RVA = "0x56E460", Offset = "0x56D460", VA = "0x18056E460", Slot = "6")]
	public virtual void enh(bool visible)
	{
		gameObject.SetActive(visible);
	}

	[Token(Token = "0x6001044")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "7")]
	public virtual void eni(TData itemData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001045")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "8")]
	public virtual void enj(float position)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001046")]
	[Address(RVA = "0x56E3D0", Offset = "0x56D3D0", VA = "0x18056E3D0")]
	protected FancyScrollViewCell()
	{
	}
}
[Token(Token = "0x20001F4")]
public abstract class FancyScrollViewCell<TData> : FancyScrollViewCell<TData, ox>
{
	[Token(Token = "0x6001047")]
	[Address(RVA = "0x3B6BB0", Offset = "0x3B5BB0", VA = "0x1803B6BB0")]
	protected FancyScrollViewCell()
	{
		((BaseInputModule)(object)this).Process();
	}
}
