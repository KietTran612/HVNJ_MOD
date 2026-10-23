using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000252")]
[AddComponentMenu("UI/Extensions/UI Scrollrect Occlusion")]
public class UI_ScrollRectOcclusion : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D04")]
	public bool InitByUser;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D05")]
	private ScrollRect pkh;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D06")]
	private ContentSizeFitter pki;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D07")]
	private VerticalLayoutGroup pkj;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001D08")]
	private HorizontalLayoutGroup pkk;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001D09")]
	private GridLayoutGroup pkl;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001D0A")]
	private bool pkm;

	[FieldOffset(Offset = "0x49")]
	[Token(Token = "0x4001D0B")]
	private bool pkn;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4001D0C")]
	private float pko;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001D0D")]
	private float pkp;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001D0E")]
	private bool pkq;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001D0F")]
	private List<RectTransform> pkr = (List<RectTransform>)(object)new List<T>();

	[Token(Token = "0x60012DD")]
	[Address(RVA = "0x42D570", Offset = "0x42C570", VA = "0x18042D570")]
	private void Awake()
	{
		if (!InitByUser)
		{
			fdp();
		}
	}

	[Token(Token = "0x60012DE")]
	[Address(RVA = "0x42D5F0", Offset = "0x42C5F0", VA = "0x18042D5F0")]
	public void fdp()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_00e0: Expected Obj, but got I4
		//IL_00b8: Expected VT, but got Obj
		//IL_011b: Expected Obj, but got I4
		//IL_0156: Expected Obj, but got I4
		//IL_0191: Expected Obj, but got I4
		ScrollRect component = GetComponent<ScrollRect>();
		int num = 0;
		if (!(component != (Object)num))
		{
			Debug.LogError("UI_ScrollRectOcclusion => No ScrollRect component found");
			return;
		}
		ScrollRect.ScrollRectEvent onValueChanged = (pkh = GetComponent<ScrollRect>()).m_OnValueChanged;
		UnityAction<Vector2> unityAction = (UnityAction<Vector2>)(object)new UnityAction<T0>(fdr);
		((UnityEvent<T0>)(object)onValueChanged).AddListener((UnityAction<>)(object)unityAction);
		ScrollRect scrollRect = pkh;
		bool horizontal = scrollRect.m_Horizontal;
		int num2 = 0;
		pkn = horizontal;
		bool vertical = scrollRect.m_Vertical;
		pkm = vertical;
		int childCount = scrollRect.m_Content.childCount;
		ScrollRect scrollRect2 = pkh;
		ScrollRect scrollRect3 = default;
		if (num2 < childCount)
		{
			List<RectTransform> list = pkr;
			RectTransform component2 = scrollRect2.m_Content.GetChild(num2).GetComponent<RectTransform>();
			((List<T>)(object)list).Add((T)component2);
			scrollRect3 = pkh;
			num2++;
		}
		VerticalLayoutGroup component3 = scrollRect3.m_Content.GetComponent<VerticalLayoutGroup>();
		int num3 = 0;
		if (component3 != (Object)num3)
		{
			VerticalLayoutGroup component4 = pkh.m_Content.GetComponent<VerticalLayoutGroup>();
			pkj = component4;
		}
		HorizontalLayoutGroup component5 = pkh.m_Content.GetComponent<HorizontalLayoutGroup>();
		int num4 = 0;
		if (component5 != (Object)num4)
		{
			HorizontalLayoutGroup component6 = pkh.m_Content.GetComponent<HorizontalLayoutGroup>();
			pkk = component6;
		}
		GridLayoutGroup component7 = pkh.m_Content.GetComponent<GridLayoutGroup>();
		int num5 = 0;
		if (component7 != (Object)num5)
		{
			GridLayoutGroup component8 = pkh.m_Content.GetComponent<GridLayoutGroup>();
			pkl = component8;
		}
		ContentSizeFitter component9 = pkh.m_Content.GetComponent<ContentSizeFitter>();
		int num6 = 0;
		if (component9 != (Object)num6)
		{
			ContentSizeFitter component10 = pkh.m_Content.GetComponent<ContentSizeFitter>();
			pki = component10;
		}
	}

	[Token(Token = "0x60012DF")]
	[Address(RVA = "0x42DA60", Offset = "0x42CA60", VA = "0x18042DA60")]
	private void fdq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012E0")]
	[Address(RVA = "0x42DD20", Offset = "0x42CD20", VA = "0x18042DD20")]
	public void fdr(Vector2 pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012E1")]
	[Address(RVA = "0x42D580", Offset = "0x42C580", VA = "0x18042D580")]
	public UI_ScrollRectOcclusion()
	{
	}
}
