using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000251")]
[AddComponentMenu("UI/Extensions/UI Infinite Scroll")]
public class UI_InfiniteScroll : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CF3")]
	[Tooltip("If false, will Init automatically, otherwise you need to call Init() method")]
	public bool InitByUser;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CF4")]
	private ScrollRect pjr;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001CF5")]
	private ContentSizeFitter pjs;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001CF6")]
	private VerticalLayoutGroup pjt;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001CF7")]
	private HorizontalLayoutGroup pju;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001CF8")]
	private GridLayoutGroup pjv;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001CF9")]
	private bool pjw;

	[FieldOffset(Offset = "0x49")]
	[Token(Token = "0x4001CFA")]
	private bool pjx;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4001CFB")]
	private float pjy;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001CFC")]
	private float pjz;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001CFD")]
	private bool pka;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001CFE")]
	private List<RectTransform> pkb;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001CFF")]
	private Vector2 pkc;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001D00")]
	private float pkd;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4001D01")]
	private int pke;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001D02")]
	private float pkf;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001D03")]
	private float pkg;

	[Token(Token = "0x60012D8")]
	[Address(RVA = "0x42BC90", Offset = "0x42AC90", VA = "0x18042BC90")]
	private void Awake()
	{
		if (!InitByUser)
		{
			fdm();
		}
	}

	[Token(Token = "0x60012D9")]
	[Address(RVA = "0x42BD40", Offset = "0x42AD40", VA = "0x18042BD40")]
	public void fdm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012DA")]
	[Address(RVA = "0x42C230", Offset = "0x42B230", VA = "0x18042C230")]
	private void fdn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012DB")]
	[Address(RVA = "0x42C540", Offset = "0x42B540", VA = "0x18042C540")]
	public void fdo(Vector2 pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012DC")]
	[Address(RVA = "0x42BCA0", Offset = "0x42ACA0", VA = "0x18042BCA0")]
	public unsafe UI_InfiniteScroll()
	{
		//IL_0028: Expected F4, but got I4
		//IL_0023: Expected native int or pointer, but got VT
		List<RectTransform> list = (List<RectTransform>)(object)new List<T>();
		int num = 0;
		pkb = list;
		pkc = Vector2.zero;
		((Vector2*)(nint)pkc)->y = 0f;
		pkd = 100f;
		((Behaviour)this)._002Ector();
	}
}
