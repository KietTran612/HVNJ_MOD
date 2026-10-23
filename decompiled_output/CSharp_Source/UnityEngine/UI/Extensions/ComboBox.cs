using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000192")]
[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("UI/Extensions/ComboBox")]
public class ComboBox : MonoBehaviour
{
	[Serializable]
	[Token(Token = "0x2000193")]
	public class SelectionChangedEvent : UnityEvent<string>
	{
		[Token(Token = "0x6000DE5")]
		[Address(RVA = "0x275470", Offset = "0x274470", VA = "0x180275470")]
		public SelectionChangedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Token(Token = "0x2000194")]
	[CompilerGenerated]
	private sealed class oc
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400192F")]
		public string oqy;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001930")]
		public ComboBox oqz;

		[Token(Token = "0x6000DE6")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public oc()
		{
		}

		[Token(Token = "0x6000DE7")]
		[Address(RVA = "0x27AD90", Offset = "0x279D90", VA = "0x18027AD90")]
		internal void dzc()
		{
			ComboBox comboBox = oqz;
			string item = oqy;
			comboBox.dzn(item);
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001918")]
	public Color disabledTextColor;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400191A")]
	public List<string> AvailableOptions;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400191B")]
	[SerializeField]
	private float _scrollBarWidth = 20f;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x400191C")]
	[SerializeField]
	private int _itemsToDisplay;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400191D")]
	public SelectionChangedEvent OnSelectionChanged;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400191E")]
	private bool orb;

	[FieldOffset(Offset = "0x49")]
	[Token(Token = "0x400191F")]
	private bool orc;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001920")]
	private InputField ord;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001921")]
	private RectTransform ore;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001922")]
	private RectTransform orf;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001923")]
	private RectTransform org;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001924")]
	private RectTransform orh;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001925")]
	private RectTransform ori;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001926")]
	private RectTransform orj;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001927")]
	private RectTransform ork;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001928")]
	private Canvas orl;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001929")]
	private RectTransform orm;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x400192A")]
	private ScrollRect orn;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x400192B")]
	private List<string> oro;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x400192C")]
	private Dictionary<string, GameObject> orp;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400192D")]
	private GameObject orq;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x400192E")]
	[CompilerGenerated]
	private string orr__BackingField;

	[Token(Token = "0x17000031")]
	[field: FieldOffset(Offset = "0x28")]
	[field: Token(Token = "0x4001919")]
	public DropDownListItem ora
	{
		[Token(Token = "0x6000DD5")]
		[Address(RVA = "0x283C00", Offset = "0x282C00", VA = "0x180283C00")]
		get;
		[Token(Token = "0x6000DD6")]
		[Address(RVA = "0x3E9E40", Offset = "0x3E8E40", VA = "0x1803E9E40")]
		private set;
	}

	[Token(Token = "0x17000032")]
	public string orr
	{
		[Token(Token = "0x6000DD7")]
		[Address(RVA = "0x374690", Offset = "0x373690", VA = "0x180374690")]
		[CompilerGenerated]
		get
		{
			return orr__BackingField;
		}
		[Token(Token = "0x6000DD8")]
		[Address(RVA = "0x374710", Offset = "0x373710", VA = "0x180374710")]
		[CompilerGenerated]
		private set
		{
			orr__BackingField = value;
		}
	}

	[Token(Token = "0x17000033")]
	public float ppx
	{
		[Token(Token = "0x6000DD9")]
		[Address(RVA = "0x4ED1B0", Offset = "0x4EC1B0", VA = "0x1804ED1B0")]
		get
		{
			return _scrollBarWidth;
		}
		[Token(Token = "0x6000DDA")]
		[Address(RVA = "0x693C00", Offset = "0x692C00", VA = "0x180693C00")]
		set
		{
			_scrollBarWidth = value;
			dzo();
		}
	}

	[Token(Token = "0x17000034")]
	public int ppy
	{
		[Token(Token = "0x6000DDB")]
		[Address(RVA = "0x5AFD20", Offset = "0x5AED20", VA = "0x1805AFD20")]
		get
		{
			return _itemsToDisplay;
		}
		[Token(Token = "0x6000DDC")]
		[Address(RVA = "0x693C10", Offset = "0x692C10", VA = "0x180693C10")]
		set
		{
			_itemsToDisplay = value;
			dzo();
		}
	}

	[Token(Token = "0x6000DDD")]
	[Address(RVA = "0x693BE0", Offset = "0x692BE0", VA = "0x180693BE0")]
	public void Awake()
	{
		bool flag = dzl();
	}

	[Token(Token = "0x6000DDE")]
	[Address(RVA = "0x693C20", Offset = "0x692C20", VA = "0x180693C20")]
	private bool dzl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DDF")]
	[Address(RVA = "0x6940F0", Offset = "0x6930F0", VA = "0x1806940F0")]
	private void dzm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DE0")]
	[Address(RVA = "0x6947F0", Offset = "0x6937F0", VA = "0x1806947F0")]
	private void dzn(string item)
	{
		orr__BackingField = item;
		ord.text = item;
		RectTransform rectTransform = org;
		bool flag = !orb;
		orb = flag;
		GameObject gameObject = rectTransform.gameObject;
		bool active = orb;
		gameObject.SetActive(active);
		if (orb)
		{
			transform.SetAsLastSibling();
		}
	}

	[Token(Token = "0x6000DE1")]
	[Address(RVA = "0x694870", Offset = "0x693870", VA = "0x180694870")]
	private void dzo()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DE2")]
	[Address(RVA = "0x694D30", Offset = "0x693D30", VA = "0x180694D30")]
	public void dzp(string currText)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DE3")]
	[Address(RVA = "0x694E10", Offset = "0x693E10", VA = "0x180694E10")]
	public void dzq(bool directClick)
	{
		bool flag = !orb;
		orb = flag;
		GameObject gameObject = org.gameObject;
		bool active = orb;
		gameObject.SetActive(active);
		if (orb)
		{
			transform.SetAsLastSibling();
		}
	}

	[Token(Token = "0x6000DE4")]
	[Address(RVA = "0x693BF0", Offset = "0x692BF0", VA = "0x180693BF0")]
	public ComboBox()
	{
	}
}
