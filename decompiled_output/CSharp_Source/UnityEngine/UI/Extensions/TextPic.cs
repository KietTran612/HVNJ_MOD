using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001B8")]
[ExecuteInEditMode]
[AddComponentMenu("UI/Extensions/TextPic")]
public class TextPic : Text, IPointerClickHandler, IEventSystemHandler, IPointerExitHandler, IPointerEnterHandler, ISelectHandler
{
	[Serializable]
	[Token(Token = "0x20001B9")]
	public struct IconName
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4001A02")]
		public string name;

		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x4001A03")]
		public Sprite sprite;

		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001A04")]
		public Vector2 offset;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001A05")]
		public Vector2 scale;
	}

	[Serializable]
	[Token(Token = "0x20001BA")]
	public class HrefClickEvent : UnityEvent<string>
	{
		[Token(Token = "0x6000F0B")]
		[Address(RVA = "0x274150", Offset = "0x273150", VA = "0x180274150")]
		public HrefClickEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[Token(Token = "0x20001BB")]
	private class ol
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001A06")]
		public int owa;

		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x4001A07")]
		public int owb;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001A08")]
		public string owc;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4001A09")]
		public readonly List<Rect> owd = (List<Rect>)(object)new List<T>();

		[Token(Token = "0x6000F0C")]
		[Address(RVA = "0x27B530", Offset = "0x27A530", VA = "0x18027B530")]
		public ol()
		{
		}
	}

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40019EC")]
	private readonly List<Image> owe = (List<Image>)(object)new List<T>();

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40019ED")]
	private readonly List<GameObject> owf = (List<GameObject>)(object)new List<T>();

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40019EE")]
	private bool owg;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40019EF")]
	private Object owh = new Object();

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40019F0")]
	private readonly List<int> owi = (List<int>)(object)new List<T>();

	[Token(Token = "0x40019F1")]
	private static readonly Regex owj = new Regex("<quad name=(.+?) size=(\\d*\\.?\\d+%?) width=(\\d*\\.?\\d+%?) />", RegexOptions.Singleline);

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40019F2")]
	private string owk;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40019F3")]
	[SerializeField]
	[Tooltip("Allow click events to be received by parents, (default) blocks")]
	private bool m_ClickParents;

	[FieldOffset(Offset = "0x139")]
	[Token(Token = "0x40019F4")]
	private bool owl;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40019F5")]
	private string owm;

	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x40019F6")]
	public IconName[] inspectorIconList;

	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40019F7")]
	[Tooltip("Global scaling factor for all images")]
	public float ImageScalingFactor;

	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40019F8")]
	public string hyperlinkColor;

	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x40019F9")]
	[SerializeField]
	public Vector2 imageOffset;

	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40019FA")]
	private Button own;

	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40019FB")]
	private List<Vector2> owo;

	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40019FC")]
	private string owp;

	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x40019FD")]
	public bool isCreating_m_HrefInfos;

	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x40019FE")]
	private readonly List<ol> owq;

	[Token(Token = "0x40019FF")]
	private static readonly StringBuilder owr = new StringBuilder();

	[Token(Token = "0x4001A00")]
	private static readonly Regex ows = new Regex("<a href=([^>\\n\\s]+)>(.*?)(</a>)", RegexOptions.Singleline);

	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x4001A01")]
	[SerializeField]
	private HrefClickEvent m_OnHrefClick;

	[Token(Token = "0x17000072")]
	public bool psf
	{
		[Token(Token = "0x6000EF6")]
		[Address(RVA = "0x8754D0", Offset = "0x8744D0", VA = "0x1808754D0")]
		get
		{
			return m_ClickParents;
		}
		[Token(Token = "0x6000EF7")]
		[Address(RVA = "0x8754E0", Offset = "0x8744E0", VA = "0x1808754E0")]
		set
		{
			m_ClickParents = value;
		}
	}

	[Token(Token = "0x17000073")]
	public HrefClickEvent psg
	{
		[Token(Token = "0x6000EFD")]
		[Address(RVA = "0x876000", Offset = "0x875000", VA = "0x180876000")]
		get
		{
			return m_OnHrefClick;
		}
		[Token(Token = "0x6000EFE")]
		[Address(RVA = "0x876010", Offset = "0x875010", VA = "0x180876010")]
		set
		{
			m_OnHrefClick = value;
		}
	}

	[Token(Token = "0x6000EF8")]
	[Address(RVA = "0x8750A0", Offset = "0x8740A0", VA = "0x1808750A0", Slot = "28")]
	public override void SetVerticesDirty()
	{
		base.SetVerticesDirty();
		owl = true;
	}

	[Token(Token = "0x6000EF9")]
	[Address(RVA = "0x8750C0", Offset = "0x8740C0", VA = "0x1808750C0")]
	private new void Start()
	{
		Button component = GetComponent<Button>();
		own = component;
		string text = this.text;
		List<ol> list = owq;
		owp = text;
		((List<T>)(object)list).Clear();
		isCreating_m_HrefInfos = true;
		((object)this)._002Ector();
	}

	[Token(Token = "0x6000EFA")]
	[Address(RVA = "0x8754F0", Offset = "0x8744F0", VA = "0x1808754F0")]
	public void egm()
	{
		string text = this.text;
		List<ol> list = owq;
		owp = text;
		((List<T>)(object)list).Clear();
		isCreating_m_HrefInfos = true;
		((object)this)._002Ector();
	}

	[Token(Token = "0x6000EFB")]
	[Address(RVA = "0x875570", Offset = "0x874570", VA = "0x180875570")]
	protected void egn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EFC")]
	[Address(RVA = "0x874640", Offset = "0x873640", VA = "0x180874640", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000EFF")]
	[Address(RVA = "0x876020", Offset = "0x875020", VA = "0x180876020")]
	protected string egq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F00")]
	[Address(RVA = "0x874000", Offset = "0x873000", VA = "0x180874000", Slot = "85")]
	public void OnPointerClick(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F01")]
	[Address(RVA = "0x874270", Offset = "0x873270", VA = "0x180874270", Slot = "87")]
	public void OnPointerEnter(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F02")]
	[Address(RVA = "0x874430", Offset = "0x873430", VA = "0x180874430", Slot = "86")]
	public void OnPointerExit(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F03")]
	[Address(RVA = "0x874EE0", Offset = "0x873EE0", VA = "0x180874EE0", Slot = "88")]
	public void OnSelect(BaseEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F04")]
	[Address(RVA = "0x876C70", Offset = "0x875C70", VA = "0x180876C70")]
	public void egr(BaseEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F05")]
	[Address(RVA = "0x873C20", Offset = "0x872C20", VA = "0x180873C20")]
	private void LateUpdate()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F06")]
	[Address(RVA = "0x876E30", Offset = "0x875E30", VA = "0x180876E30")]
	private void egs()
	{
		string text = this.text;
		List<ol> list = owq;
		owp = text;
		((List<T>)(object)list).Clear();
		isCreating_m_HrefInfos = true;
	}

	[Token(Token = "0x6000F07")]
	[Address(RVA = "0x873ED0", Offset = "0x872ED0", VA = "0x180873ED0", Slot = "5")]
	protected override void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F08")]
	[Address(RVA = "0x873DB0", Offset = "0x872DB0", VA = "0x180873DB0", Slot = "7")]
	protected override void OnDisable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F09")]
	[Address(RVA = "0x875270", Offset = "0x874270", VA = "0x180875270")]
	public unsafe TextPic()
	{
		//IL_0068: Expected F4, but got I4
		//IL_0063: Expected native int or pointer, but got VT
		int num = 0;
		ImageScalingFactor = 1f;
		hyperlinkColor = "blue";
		imageOffset = Vector2.zero;
		((Vector2*)(nint)imageOffset)->y = 0f;
		owo = (List<Vector2>)(object)new List<T>();
		owp = "";
		isCreating_m_HrefInfos = true;
		owq = (List<ol>)(object)new List<T>();
		m_OnHrefClick = new HrefClickEvent();
		base._002Ector();
	}
}
