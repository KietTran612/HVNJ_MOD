using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001A7")]
[RequireComponent(typeof(RectTransform), typeof(LayoutElement))]
public class ReorderableListElement : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001999")]
	[Tooltip("Can this element be dragged?")]
	public bool IsGrabbable = true;

	[FieldOffset(Offset = "0x19")]
	[Token(Token = "0x400199A")]
	[Tooltip("Can this element be transfered to another list")]
	public bool IsTransferable;

	[FieldOffset(Offset = "0x1A")]
	[Token(Token = "0x400199B")]
	[Tooltip("Can this element be dropped in space?")]
	public bool isDroppableInSpace;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400199C")]
	private readonly List<RaycastResult> otr = (List<RaycastResult>)(object)new List<T>();

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400199D")]
	private ReorderableList ots;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400199E")]
	private int ott;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400199F")]
	private RectTransform otu;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40019A0")]
	private LayoutElement otv;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40019A1")]
	private Vector2 otw;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40019A2")]
	private RectTransform otx;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40019A3")]
	private LayoutElement oty;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40019A4")]
	private int otz;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40019A5")]
	private RectTransform oua;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40019A6")]
	private LayoutElement oub;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40019A7")]
	private Vector2 ouc;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40019A8")]
	private ReorderableList oud;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40019A9")]
	private bool oue;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40019AA")]
	private RectTransform ouf;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x40019AB")]
	private ReorderableList oug;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40019AC")]
	private CanvasGroup ouh;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x40019AD")]
	internal bool oui;

	[Token(Token = "0x6000E56")]
	[Address(RVA = "0x44C3D0", Offset = "0x44B3D0", VA = "0x18044C3D0", Slot = "5")]
	public void OnBeginDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E57")]
	[Address(RVA = "0x44C8E0", Offset = "0x44B8E0", VA = "0x18044C8E0", Slot = "4")]
	public void OnDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E58")]
	[Address(RVA = "0x44DA40", Offset = "0x44CA40", VA = "0x18044DA40")]
	private void ecm(int targetIndex, Transform displaced)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E59")]
	[Address(RVA = "0x44E070", Offset = "0x44D070", VA = "0x18044E070")]
	private void ecn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E5A")]
	[Address(RVA = "0x44E470", Offset = "0x44D470", VA = "0x18044E470")]
	public void eco()
	{
		//IL_0015: Expected Obj, but got I4
		//IL_0031: Expected Obj, but got I4
		//IL_0038: Expected Obj, but got I4
		//IL_003f: Expected Obj, but got I4
		//IL_004f: Expected I4, but got I8
		Transform parent = oua.parent;
		int num = 0;
		if (parent == (Object)num)
		{
			Object.Destroy(oua.gameObject);
		}
		int num2 = 0;
		oud = (ReorderableList)num2;
		oua = (RectTransform)num2;
		oub = (LayoutElement)num2;
		otz = -1;
	}

	[Token(Token = "0x6000E5B")]
	[Address(RVA = "0x44D310", Offset = "0x44C310", VA = "0x18044D310", Slot = "6")]
	public void OnEndDrag(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E5C")]
	[Address(RVA = "0x44E550", Offset = "0x44D550", VA = "0x18044E550")]
	private void ecp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E5D")]
	[Address(RVA = "0x44E8E0", Offset = "0x44D8E0", VA = "0x18044E8E0")]
	private void ecq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E5E")]
	[Address(RVA = "0x44EB60", Offset = "0x44DB60", VA = "0x18044EB60")]
	public void ecr(ReorderableList reorderableList)
	{
		oug = reorderableList;
		RectTransform component = GetComponent<RectTransform>();
		ouf = component;
		CanvasGroup canvasGroup = gameObject.fae<CanvasGroup>();
		ouh = canvasGroup;
	}

	[Token(Token = "0x6000E5F")]
	[Address(RVA = "0x44D9C0", Offset = "0x44C9C0", VA = "0x18044D9C0")]
	public ReorderableListElement()
	{
	}
}
