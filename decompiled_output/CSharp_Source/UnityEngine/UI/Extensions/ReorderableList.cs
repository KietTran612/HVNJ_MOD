using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001A1")]
[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("UI/Extensions/Re-orderable list")]
public class ReorderableList : MonoBehaviour
{
	[Serializable]
	[Token(Token = "0x20001A2")]
	public struct ReorderableListEventStruct
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4001989")]
		public GameObject DroppedObject;

		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x400198A")]
		public int FromIndex;

		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400198B")]
		public ReorderableList FromList;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400198C")]
		public bool IsAClone;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400198D")]
		public GameObject SourceObject;

		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x400198E")]
		public int ToIndex;

		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x400198F")]
		public ReorderableList ToList;

		[Token(Token = "0x6000E46")]
		[Address(RVA = "0x275310", Offset = "0x274310", VA = "0x180275310")]
		public void Cancel()
		{
			SourceObject.GetComponent<ReorderableListElement>().oui = false;
		}
	}

	[Serializable]
	[Token(Token = "0x20001A3")]
	public class ReorderableListHandler : UnityEvent<ReorderableListEventStruct>
	{
		[Token(Token = "0x6000E47")]
		[Address(RVA = "0x275370", Offset = "0x274370", VA = "0x180275370")]
		public ReorderableListHandler()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001978")]
	[Tooltip("Child container with re-orderable items in a layout group")]
	public LayoutGroup ContentLayout;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001979")]
	[Tooltip("Parent area to draw the dragged element on top of containers. Defaults to the root Canvas")]
	public RectTransform DraggableArea;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400197A")]
	[Tooltip("Can items be dragged from the container?")]
	public bool IsDraggable = true;

	[FieldOffset(Offset = "0x29")]
	[Token(Token = "0x400197B")]
	[Tooltip("Should the draggable components be removed or cloned?")]
	public bool CloneDraggedObject;

	[FieldOffset(Offset = "0x2A")]
	[Token(Token = "0x400197C")]
	[Tooltip("Can new draggable items be dropped in to the container?")]
	public bool IsDropable = true;

	[FieldOffset(Offset = "0x2B")]
	[Token(Token = "0x400197D")]
	[Tooltip("Should dropped items displace a current item if the list is full?\n Depending on the dropped items origin list, the displaced item may be added, dropped in space or deleted.")]
	public bool IsDisplacable;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x400197E")]
	public int maxItems = int.MaxValue;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400197F")]
	[Header("UI Re-orderable Events")]
	public ReorderableListHandler OnElementDropped = new ReorderableListHandler();

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001980")]
	public ReorderableListHandler OnElementGrabbed = new ReorderableListHandler();

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001981")]
	public ReorderableListHandler OnElementRemoved = new ReorderableListHandler();

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001982")]
	public ReorderableListHandler OnElementAdded = new ReorderableListHandler();

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001983")]
	public ReorderableListHandler OnElementDisplacedFrom = new ReorderableListHandler();

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001984")]
	public ReorderableListHandler OnElementDisplacedTo = new ReorderableListHandler();

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001985")]
	public ReorderableListHandler OnElementDisplacedFromReturned = new ReorderableListHandler();

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001986")]
	public ReorderableListHandler OnElementDisplacedToReturned = new ReorderableListHandler();

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001987")]
	private RectTransform oth;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001988")]
	private ReorderableListContent oti;

	[Token(Token = "0x1700004E")]
	public RectTransform pqx
	{
		[Token(Token = "0x6000E40")]
		[Address(RVA = "0x44EF40", Offset = "0x44DF40", VA = "0x18044EF40")]
		get
		{
			//IL_0010: Expected Obj, but got I4
			RectTransform rectTransform = oth;
			int num = 0;
			if (rectTransform == (Object)num)
			{
				RectTransform component = ContentLayout.GetComponent<RectTransform>();
				oth = component;
			}
			return oth;
		}
	}

	[Token(Token = "0x6000E41")]
	[Address(RVA = "0x44EFE0", Offset = "0x44DFE0", VA = "0x18044EFE0")]
	private Canvas ecc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E42")]
	[Address(RVA = "0x44F0F0", Offset = "0x44E0F0", VA = "0x18044F0F0")]
	public void ecd()
	{
		Object.Destroy(oti);
		ReorderableListContent reorderableListContent = (oti = ContentLayout.gameObject.AddComponent<ReorderableListContent>());
		reorderableListContent.otp = this;
		RectTransform component = reorderableListContent.GetComponent<RectTransform>();
		reorderableListContent.otq = component;
		List<Transform> otm = (List<Transform>)(object)new List<T>();
		reorderableListContent.otm = otm;
		List<ReorderableListElement> otn = (List<ReorderableListElement>)(object)new List<T>();
		reorderableListContent.otn = otn;
		int num = default;
		ReorderableListContent.of of = new ReorderableListContent.of(num);
		num = 0;
		of.otl = reorderableListContent;
		Coroutine coroutine = reorderableListContent.StartCoroutine(of);
	}

	[Token(Token = "0x6000E43")]
	[Address(RVA = "0x44EBE0", Offset = "0x44DBE0", VA = "0x18044EBE0")]
	private void Start()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0023: Expected Obj, but got I4
		LayoutGroup contentLayout = ContentLayout;
		int num = 0;
		if (!(contentLayout == (Object)num))
		{
			RectTransform draggableArea = DraggableArea;
			int num2 = 0;
			if (draggableArea == (Object)num2)
			{
				RectTransform component = transform.root.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
				DraggableArea = component;
			}
			if (IsDropable && !GetComponent<Graphic>())
			{
				string text = name;
				string text2 = "You need to have a Graphic control (such as an Image) for the list [" + text + "] to be droppable";
			}
			ecd();
		}
		else
		{
			string text3 = name;
			string message = "You need to have a child LayoutGroup content set for the list: " + text3;
			GameObject context = gameObject;
			Debug.LogError(message, context);
		}
	}

	[Token(Token = "0x6000E44")]
	[Address(RVA = "0x44F2A0", Offset = "0x44E2A0", VA = "0x18044F2A0")]
	public void ece(ReorderableListEventStruct item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E45")]
	[Address(RVA = "0x44EE00", Offset = "0x44DE00", VA = "0x18044EE00")]
	public ReorderableList()
	{
		//IL_001e: Expected I4, but got I8
	}
}
