using System;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200023A")]
[AddComponentMenu("UI/Extensions/ScrollRectEx")]
public class ScrollRectEx : ScrollRect
{
	[Token(Token = "0x200023B")]
	[CompilerGenerated]
	private sealed class pv
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001CA8")]
		public PointerEventData phu;

		[Token(Token = "0x600125F")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public pv()
		{
		}

		[Token(Token = "0x6001260")]
		[Address(RVA = "0x27F010", Offset = "0x27E010", VA = "0x18027F010")]
		internal void fam(IInitializePotentialDragHandler parent)
		{
			throw new NullReferenceException();
		}
	}

	[Token(Token = "0x200023C")]
	[CompilerGenerated]
	private sealed class pw
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001CA9")]
		public PointerEventData phv;

		[Token(Token = "0x6001261")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public pw()
		{
		}

		[Token(Token = "0x6001262")]
		[Address(RVA = "0x27F070", Offset = "0x27E070", VA = "0x18027F070")]
		internal void fan(IDragHandler parent)
		{
			throw new NullReferenceException();
		}
	}

	[Token(Token = "0x200023D")]
	[CompilerGenerated]
	private sealed class pz
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001CAA")]
		public PointerEventData phw;

		[Token(Token = "0x6001263")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public pz()
		{
		}

		[Token(Token = "0x6001264")]
		[Address(RVA = "0x27F0D0", Offset = "0x27E0D0", VA = "0x18027F0D0")]
		internal void fao(IBeginDragHandler parent)
		{
			throw new NullReferenceException();
		}
	}

	[Token(Token = "0x200023E")]
	[CompilerGenerated]
	private sealed class qa
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001CAB")]
		public PointerEventData phx;

		[Token(Token = "0x6001265")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public qa()
		{
		}

		[Token(Token = "0x6001266")]
		[Address(RVA = "0x27FD50", Offset = "0x27ED50", VA = "0x18027FD50")]
		internal void fap(IEndDragHandler parent)
		{
			throw new NullReferenceException();
		}
	}

	[Token(Token = "0x200023F")]
	[CompilerGenerated]
	private sealed class qb
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001CAC")]
		public PointerEventData phy;

		[Token(Token = "0x6001267")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public qb()
		{
		}

		[Token(Token = "0x6001268")]
		[Address(RVA = "0x27FDB0", Offset = "0x27EDB0", VA = "0x18027FDB0")]
		internal void faq(IScrollHandler parent)
		{
			throw new NullReferenceException();
		}
	}

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4001CA7")]
	private bool phz;

	[Token(Token = "0x6001258")]
	[Address(RVA = "0x4C1460", Offset = "0x4C0460", VA = "0x1804C1460")]
	private void far<T>(Action<> P_0) where T : IEventSystemHandler
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001259")]
	[Address(RVA = "0x47FC60", Offset = "0x47EC60", VA = "0x18047FC60", Slot = "43")]
	public override void OnInitializePotentialDrag(PointerEventData eventData)
	{
		Action<IInitializePotentialDragHandler> action = (Action<IInitializePotentialDragHandler>)(object)(Action<T>)([Token(Token = "0x6001260")] [Address(RVA = "0x27F010", Offset = "0x27E010", VA = "0x18027F010")] (IInitializePotentialDragHandler parent) =>
		{
			throw new NullReferenceException();
		});
		far<IInitializePotentialDragHandler>((Action<>)(object)action);
		PointerEventData eventData2 = eventData;
		base.OnInitializePotentialDrag(eventData2);
	}

	[Token(Token = "0x600125A")]
	[Address(RVA = "0x47FA60", Offset = "0x47EA60", VA = "0x18047FA60", Slot = "46")]
	public override void OnDrag(PointerEventData eventData)
	{
		PointerEventData phv = eventData;
		if (!phz)
		{
			base.OnDrag(eventData);
			return;
		}
		Action<IDragHandler> action = (Action<IDragHandler>)(object)(Action<T>)([Token(Token = "0x6001262")] [Address(RVA = "0x27F070", Offset = "0x27E070", VA = "0x18027F070")] (IDragHandler parent) =>
		{
			throw new NullReferenceException();
		});
		far<IDragHandler>((Action<>)(object)action);
	}

	[Token(Token = "0x600125B")]
	[Address(RVA = "0x47F880", Offset = "0x47E880", VA = "0x18047F880", Slot = "44")]
	public override void OnBeginDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600125C")]
	[Address(RVA = "0x47FB60", Offset = "0x47EB60", VA = "0x18047FB60", Slot = "45")]
	public override void OnEndDrag(PointerEventData eventData)
	{
		PointerEventData phx = eventData;
		if (!phz)
		{
			base.OnEndDrag(eventData);
		}
		Action<IEndDragHandler> action = (Action<IEndDragHandler>)(object)(Action<T>)([Token(Token = "0x6001266")] [Address(RVA = "0x27FD50", Offset = "0x27ED50", VA = "0x18027FD50")] (IEndDragHandler parent) =>
		{
			throw new NullReferenceException();
		});
		far<IEndDragHandler>((Action<>)(object)action);
		phz = false;
	}

	[Token(Token = "0x600125D")]
	[Address(RVA = "0x47FD50", Offset = "0x47ED50", VA = "0x18047FD50", Slot = "42")]
	public override void OnScroll(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600125E")]
	[Address(RVA = "0x47F870", Offset = "0x47E870", VA = "0x18047F870")]
	public ScrollRectEx()
	{
	}
}
