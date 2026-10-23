using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000195")]
[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("UI/Extensions/Dropdown List")]
public class DropDownList : MonoBehaviour
{
	[Serializable]
	[Token(Token = "0x2000196")]
	public class SelectionChangedEvent : UnityEvent<int>
	{
		[Token(Token = "0x6000DF6")]
		[Address(RVA = "0x2754B0", Offset = "0x2744B0", VA = "0x1802754B0")]
		public SelectionChangedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Token(Token = "0x2000197")]
	[CompilerGenerated]
	private sealed class od
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001948")]
		public int ors;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001949")]
		public DropDownListItem ort;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400194A")]
		public DropDownList oru;

		[Token(Token = "0x6000DF7")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public od()
		{
		}

		[Token(Token = "0x6000DF8")]
		[Address(RVA = "0x27ADC0", Offset = "0x279DC0", VA = "0x18027ADC0")]
		internal void dzr()
		{
			DropDownList dropDownList = oru;
			int indx = ors;
			dropDownList.eaa(indx);
			ort.OnSelect?.Invoke();
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001931")]
	public Color disabledTextColor;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001933")]
	public List<DropDownListItem> Items;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001934")]
	public bool OverrideHighlighted = true;

	[FieldOffset(Offset = "0x39")]
	[Token(Token = "0x4001935")]
	private bool orw;

	[FieldOffset(Offset = "0x3A")]
	[Token(Token = "0x4001936")]
	private bool orx;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001937")]
	private oe ory;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001938")]
	private RectTransform orz;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001939")]
	private RectTransform osa;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400193A")]
	private RectTransform osb;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400193B")]
	private RectTransform osc;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400193C")]
	private RectTransform osd;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400193D")]
	private RectTransform ose;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400193E")]
	private Canvas osf;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400193F")]
	private RectTransform osg;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001940")]
	private ScrollRect osh;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001941")]
	private List<oe> osi;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001942")]
	private GameObject osj;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4001943")]
	[SerializeField]
	private float _scrollBarWidth = 20f;

	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4001944")]
	private int osk = -1;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4001945")]
	[SerializeField]
	private int _itemsToDisplay;

	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x4001946")]
	public bool SelectFirstItemOnStart;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001947")]
	public SelectionChangedEvent OnSelectionChanged;

	[Token(Token = "0x17000035")]
	[field: FieldOffset(Offset = "0x28")]
	[field: Token(Token = "0x4001932")]
	public DropDownListItem orv
	{
		[Token(Token = "0x6000DE8")]
		[Address(RVA = "0x283C00", Offset = "0x282C00", VA = "0x180283C00")]
		get;
		[Token(Token = "0x6000DE9")]
		[Address(RVA = "0x3E9E40", Offset = "0x3E8E40", VA = "0x1803E9E40")]
		private set;
	}

	[Token(Token = "0x17000036")]
	public float ppz
	{
		[Token(Token = "0x6000DEA")]
		[Address(RVA = "0x69DB00", Offset = "0x69CB00", VA = "0x18069DB00")]
		get
		{
			return _scrollBarWidth;
		}
		[Token(Token = "0x6000DEB")]
		[Address(RVA = "0x69DB10", Offset = "0x69CB10", VA = "0x18069DB10")]
		set
		{
			_scrollBarWidth = value;
			eac();
		}
	}

	[Token(Token = "0x17000037")]
	public int pqa
	{
		[Token(Token = "0x6000DEC")]
		[Address(RVA = "0x24DC50", Offset = "0x24CC50", VA = "0x18024DC50")]
		get
		{
			return _itemsToDisplay;
		}
		[Token(Token = "0x6000DED")]
		[Address(RVA = "0x69DB20", Offset = "0x69CB20", VA = "0x18069DB20")]
		set
		{
			_itemsToDisplay = value;
			eac();
		}
	}

	[Token(Token = "0x6000DEE")]
	[Address(RVA = "0x69DA10", Offset = "0x69CA10", VA = "0x18069DA10")]
	public void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DEF")]
	[Address(RVA = "0x69DB30", Offset = "0x69CB30", VA = "0x18069DB30")]
	private bool dzy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DF0")]
	[Address(RVA = "0x69DFD0", Offset = "0x69CFD0", VA = "0x18069DFD0")]
	private void dzz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DF1")]
	[Address(RVA = "0x69E680", Offset = "0x69D680", VA = "0x18069E680")]
	private void eaa(int indx)
	{
		//IL_001b: Expected VT, but got I4
		if (indx != osk)
		{
			((UnityEvent<T0>)(object)OnSelectionChanged)?.Invoke((T0)indx);
		}
		osk = indx;
		ead(directClick: true);
		eab();
	}

	[Token(Token = "0x6000DF2")]
	[Address(RVA = "0x69E700", Offset = "0x69D700", VA = "0x18069E700")]
	private void eab()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DF3")]
	[Address(RVA = "0x69EA00", Offset = "0x69DA00", VA = "0x18069EA00")]
	private void eac()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DF4")]
	[Address(RVA = "0x69EEE0", Offset = "0x69DEE0", VA = "0x18069EEE0")]
	public void ead(bool directClick)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DF5")]
	[Address(RVA = "0x69DAE0", Offset = "0x69CAE0", VA = "0x18069DAE0")]
	public DropDownList()
	{
		//IL_0022: Expected I4, but got I8
	}
}
