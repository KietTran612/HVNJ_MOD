using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200018C")]
[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("UI/Extensions/AutoComplete ComboBox")]
public class AutoCompleteComboBox : MonoBehaviour
{
	[Serializable]
	[Token(Token = "0x200018D")]
	public class SelectionChangedEvent : UnityEvent<string, bool>
	{
		[Token(Token = "0x6000DCD")]
		[Address(RVA = "0x275430", Offset = "0x274430", VA = "0x180275430")]
		public SelectionChangedEvent()
		{
			((UnityEvent<T0, T1>)(object)this)._002Ector();
		}
	}

	[Serializable]
	[Token(Token = "0x200018E")]
	public class SelectionTextChangedEvent : UnityEvent<string>
	{
		[Token(Token = "0x6000DCE")]
		[Address(RVA = "0x275570", Offset = "0x274570", VA = "0x180275570")]
		public SelectionTextChangedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Serializable]
	[Token(Token = "0x200018F")]
	public class SelectionValidityChangedEvent : UnityEvent<bool>
	{
		[Token(Token = "0x6000DCF")]
		[Address(RVA = "0x2755B0", Offset = "0x2745B0", VA = "0x1802755B0")]
		public SelectionValidityChangedEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Token(Token = "0x2000190")]
	[CompilerGenerated]
	private sealed class oa
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001915")]
		public string oqb;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001916")]
		public AutoCompleteComboBox oqc;

		[Token(Token = "0x6000DD0")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public oa()
		{
		}

		[Token(Token = "0x6000DD1")]
		[Address(RVA = "0x27AD00", Offset = "0x279D00", VA = "0x18027AD00")]
		internal void dyf()
		{
			AutoCompleteComboBox autoCompleteComboBox = oqc;
			string item = oqb;
			autoCompleteComboBox.dyu(item);
		}
	}

	[Token(Token = "0x2000191")]
	[CompilerGenerated]
	private sealed class ob
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001917")]
		public string oqd;

		[Token(Token = "0x6000DD2")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public ob()
		{
		}

		[Token(Token = "0x6000DD3")]
		[Address(RVA = "0x27AD30", Offset = "0x279D30", VA = "0x18027AD30")]
		internal bool dyg(string x)
		{
			string value = oqd;
			return x.Contains(value);
		}

		[Token(Token = "0x6000DD4")]
		[Address(RVA = "0x27AD60", Offset = "0x279D60", VA = "0x18027AD60")]
		internal bool dyh(string x)
		{
			string value = oqd;
			return x.Contains(value);
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40018F4")]
	public Color disabledTextColor;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40018F6")]
	public List<string> AvailableOptions;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40018F7")]
	private bool oqf;

	[FieldOffset(Offset = "0x39")]
	[Token(Token = "0x40018F8")]
	private bool oqg;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40018F9")]
	private InputField oqh;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40018FA")]
	private RectTransform oqi;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40018FB")]
	private RectTransform oqj;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40018FC")]
	private RectTransform oqk;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40018FD")]
	private RectTransform oql;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40018FE")]
	private RectTransform oqm;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40018FF")]
	private RectTransform oqn;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001900")]
	private RectTransform oqo;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001901")]
	private Canvas oqp;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001902")]
	private RectTransform oqq;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001903")]
	private ScrollRect oqr;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001904")]
	private List<string> oqs;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4001905")]
	private List<string> oqt;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4001906")]
	private Dictionary<string, GameObject> oqu;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001907")]
	private GameObject oqv;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4001908")]
	[CompilerGenerated]
	private string oqw__BackingField;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4001909")]
	[SerializeField]
	private float _scrollBarWidth;

	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x400190A")]
	[SerializeField]
	private int _itemsToDisplay;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400190B")]
	public bool SelectFirstItemOnStart;

	[FieldOffset(Offset = "0xC9")]
	[Token(Token = "0x400190C")]
	[SerializeField]
	[Tooltip("Change input text color based on matching items")]
	private bool _ChangeInputTextColorBasedOnMatchingItems;

	[FieldOffset(Offset = "0xCC")]
	[Token(Token = "0x400190D")]
	public Color ValidSelectionTextColor;

	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x400190E")]
	public Color MatchingItemsRemainingTextColor;

	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x400190F")]
	public Color NoItemsRemainingTextColor;

	[FieldOffset(Offset = "0xFC")]
	[Token(Token = "0x4001910")]
	public nz autocompleteSearchType;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001911")]
	private bool oqx;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4001912")]
	public SelectionTextChangedEvent OnSelectionTextChanged;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4001913")]
	public SelectionValidityChangedEvent OnSelectionValidityChanged;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001914")]
	public SelectionChangedEvent OnSelectionChanged;

	[Token(Token = "0x1700002C")]
	[field: FieldOffset(Offset = "0x28")]
	[field: Token(Token = "0x40018F5")]
	public DropDownListItem oqe
	{
		[Token(Token = "0x6000DB6")]
		[Address(RVA = "0x283C00", Offset = "0x282C00", VA = "0x180283C00")]
		get;
		[Token(Token = "0x6000DB7")]
		[Address(RVA = "0x3E9E40", Offset = "0x3E8E40", VA = "0x1803E9E40")]
		private set;
	}

	[Token(Token = "0x1700002D")]
	public string oqw
	{
		[Token(Token = "0x6000DB8")]
		[Address(RVA = "0x5FE630", Offset = "0x5FD630", VA = "0x1805FE630")]
		[CompilerGenerated]
		get
		{
			return oqw__BackingField;
		}
		[Token(Token = "0x6000DB9")]
		[Address(RVA = "0x3746F0", Offset = "0x3736F0", VA = "0x1803746F0")]
		[CompilerGenerated]
		private set
		{
			oqw__BackingField = value;
		}
	}

	[Token(Token = "0x1700002E")]
	public float ppu
	{
		[Token(Token = "0x6000DBA")]
		[Address(RVA = "0x5FE640", Offset = "0x5FD640", VA = "0x1805FE640")]
		get
		{
			return _scrollBarWidth;
		}
		[Token(Token = "0x6000DBB")]
		[Address(RVA = "0x5FE650", Offset = "0x5FD650", VA = "0x1805FE650")]
		set
		{
			_scrollBarWidth = value;
			dyv();
		}
	}

	[Token(Token = "0x1700002F")]
	public int ppv
	{
		[Token(Token = "0x6000DBC")]
		[Address(RVA = "0x5FE660", Offset = "0x5FD660", VA = "0x1805FE660")]
		get
		{
			return _itemsToDisplay;
		}
		[Token(Token = "0x6000DBD")]
		[Address(RVA = "0x5FE670", Offset = "0x5FD670", VA = "0x1805FE670")]
		set
		{
			_itemsToDisplay = value;
			dyv();
		}
	}

	[Token(Token = "0x17000030")]
	public bool ppw
	{
		[Token(Token = "0x6000DBE")]
		[Address(RVA = "0x5FE680", Offset = "0x5FD680", VA = "0x1805FE680")]
		get
		{
			return _ChangeInputTextColorBasedOnMatchingItems;
		}
		[Token(Token = "0x6000DBF")]
		[Address(RVA = "0x5FE690", Offset = "0x5FD690", VA = "0x1805FE690")]
		set
		{
			_ChangeInputTextColorBasedOnMatchingItems = value;
			if (value)
			{
				dyx();
			}
		}
	}

	[Token(Token = "0x6000DC0")]
	[Address(RVA = "0x5FE4B0", Offset = "0x5FD4B0", VA = "0x1805FE4B0")]
	public void Awake()
	{
		bool flag = dys();
	}

	[Token(Token = "0x6000DC1")]
	[Address(RVA = "0x5FE4C0", Offset = "0x5FD4C0", VA = "0x1805FE4C0")]
	public void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DC2")]
	[Address(RVA = "0x5FE6B0", Offset = "0x5FD6B0", VA = "0x1805FE6B0")]
	private bool dys()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DC3")]
	[Address(RVA = "0x5FEBC0", Offset = "0x5FDBC0", VA = "0x1805FEBC0")]
	private void dyt()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DC4")]
	[Address(RVA = "0x5FF370", Offset = "0x5FE370", VA = "0x1805FF370")]
	private void dyu(string item)
	{
		oqw__BackingField = item;
		oqh.text = item;
		RectTransform rectTransform = oqk;
		bool flag = !oqf;
		oqf = flag;
		GameObject gameObject = rectTransform.gameObject;
		bool active = oqf;
		gameObject.SetActive(active);
		if (oqf)
		{
			transform.SetAsLastSibling();
		}
	}

	[Token(Token = "0x6000DC5")]
	[Address(RVA = "0x5FF3F0", Offset = "0x5FE3F0", VA = "0x1805FF3F0")]
	private void dyv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DC6")]
	[Address(RVA = "0x5FF8B0", Offset = "0x5FE8B0", VA = "0x1805FF8B0")]
	public void dyw(string currText)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DC7")]
	[Address(RVA = "0x5FFAA0", Offset = "0x5FEAA0", VA = "0x1805FFAA0")]
	private void dyx()
	{
		if (_ChangeInputTextColorBasedOnMatchingItems)
		{
			if (oqx)
			{
				Text textComponent = oqh.m_TextComponent;
				throw new NullReferenceException();
			}
			List<string> list = oqs;
			Text textComponent2 = oqh.m_TextComponent;
			Color noItemsRemainingTextColor = NoItemsRemainingTextColor;
			textComponent2.color = noItemsRemainingTextColor;
		}
	}

	[Token(Token = "0x6000DC8")]
	[Address(RVA = "0x5FFB70", Offset = "0x5FEB70", VA = "0x1805FFB70")]
	public void dyy(bool directClick)
	{
		bool flag = !oqf;
		oqf = flag;
		GameObject gameObject = oqk.gameObject;
		bool active = oqf;
		gameObject.SetActive(active);
		if (oqf)
		{
			transform.SetAsLastSibling();
		}
	}

	[Token(Token = "0x6000DC9")]
	[Address(RVA = "0x5FFBE0", Offset = "0x5FEBE0", VA = "0x1805FFBE0")]
	private void dyz(string currText)
	{
		while (autocompleteSearchType != nz.Linq)
		{
		}
		dza(currText);
	}

	[Token(Token = "0x6000DCA")]
	[Address(RVA = "0x5FFC00", Offset = "0x5FEC00", VA = "0x1805FFC00")]
	private void dza(string currText)
	{
		//IL_006b: Expected VT, but got Obj
		//IL_006d: Expected Obj, but got VT
		//IL_0086: Expected VT, but got Obj
		//IL_0095: Expected VT, but got Obj
		//IL_00ec: Expected VT, but got Obj
		//IL_00f2: Expected Obj, but got VT
		//IL_00ff: Expected VT, but got Obj
		//IL_010c: Expected VT, but got Obj
		string oqd = currText;
		string text = currText.ToLower();
		oqd = text;
		List<string> list = oqs;
		Func<string, bool> func = (Func<string, bool>)(object)(Func<T, TResult>)([Token(Token = "0x6000DD3")] [Address(RVA = "0x27AD30", Offset = "0x279D30", VA = "0x18027AD30")] (string x) =>
		{
			string value = oqd;
			return x.Contains(value);
		});
		string[] array = Enumerable.ToArray<string>(Enumerable.Where<string>((IEnumerable<>)list, (Func<, >)(object)func));
		int num = 0;
		int length = array.Length;
		if (num < length)
		{
			Dictionary<string, GameObject> dictionary = oqu;
			string text2 = array[num];
			GameObject gameObject = (GameObject)((Dictionary<TKey, TValue>)(object)dictionary)[(TKey)text2];
			int active = 0;
			gameObject.SetActive((byte)active != 0);
			bool flag = ((List<T>)(object)oqs).Remove((T)text2);
			((List<T>)(object)oqt).Add((T)text2);
			num++;
		}
		List<string> list2 = oqt;
		Func<string, bool> func2 = (Func<string, bool>)(object)(Func<T, TResult>)([Token(Token = "0x6000DD4")] [Address(RVA = "0x27AD60", Offset = "0x279D60", VA = "0x18027AD60")] (string x) =>
		{
			string value = oqd;
			return x.Contains(value);
		});
		string[] array2 = Enumerable.ToArray<string>(Enumerable.Where<string>((IEnumerable<>)list2, (Func<, >)(object)func2));
		int length2 = array2.Length;
		if (num < length2)
		{
			Dictionary<string, GameObject> dictionary2 = oqu;
			string text3 = array2[num];
			((GameObject)((Dictionary<TKey, TValue>)(object)dictionary2)[(TKey)text3]).SetActive(value: true);
			((List<T>)(object)oqs).Add((T)text3);
			bool flag2 = ((List<T>)(object)oqt).Remove((T)text3);
			num++;
		}
	}

	[Token(Token = "0x6000DCB")]
	[Address(RVA = "0x5FFF20", Offset = "0x5FEF20", VA = "0x1805FFF20")]
	private void dzb(string currText)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DCC")]
	[Address(RVA = "0x5FE5C0", Offset = "0x5FD5C0", VA = "0x1805FE5C0")]
	public AutoCompleteComboBox()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
