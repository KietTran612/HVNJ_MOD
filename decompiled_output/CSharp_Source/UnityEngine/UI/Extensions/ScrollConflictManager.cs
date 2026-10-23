using System;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000239")]
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("UI/Extensions/Scrollrect Conflict Manager")]
public class ScrollConflictManager : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CA2")]
	public ScrollRect ParentScrollRect;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CA3")]
	public ScrollSnap ParentScrollSnap;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001CA4")]
	private ScrollRect phr;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001CA5")]
	private bool phs;

	[FieldOffset(Offset = "0x31")]
	[Token(Token = "0x4001CA6")]
	private bool pht;

	[Token(Token = "0x6001253")]
	[Address(RVA = "0x47E320", Offset = "0x47D320", VA = "0x18047E320")]
	private void Awake()
	{
		do
		{
			ScrollRect scrollRect = (phr = GetComponent<ScrollRect>());
			bool flag = (pht = scrollRect.m_Vertical);
			if (!flag)
			{
				if (ParentScrollRect.m_Vertical == flag)
				{
					Debug.Log("The other scroll rect doesnt support scrolling vertically");
				}
				return;
			}
			if (scrollRect.m_Horizontal)
			{
				Debug.Log("You have added the SecondScrollRect to a scroll view that already has both directions selected");
			}
		}
		while (ParentScrollRect.m_Horizontal);
		Debug.Log("The other scroll rect doesnt support scrolling horizontally");
	}

	[Token(Token = "0x6001254")]
	[Address(RVA = "0x47E460", Offset = "0x47D460", VA = "0x18047E460", Slot = "4")]
	public unsafe void OnBeginDrag(PointerEventData eventData)
	{
		//IL_001e: Invalid comparison between F4 and VT
		//IL_0061: Expected I4, but got I8
		//IL_007a: Expected F4, but got I4
		//IL_0075: Expected native int or pointer, but got VT
		Vector2 vector = eventData.position__BackingField;
		float y = eventData.position__BackingField.y;
		if (!pht)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y) > System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector))
			{
				phs = true;
				ScrollRect scrollRect = phr;
				int num = 0;
				scrollRect.enabled = (byte)num != 0;
				ParentScrollRect.OnBeginDrag(eventData);
				ScrollSnap parentScrollSnap = ParentScrollSnap;
				int linkSteps = 0;
				parentScrollSnap.epj((byte)linkSteps != 0);
				parentScrollSnap.pch = 0;
				int num2 = 0;
				parentScrollSnap.pcg = true;
				((Vector3*)(nint)parentScrollSnap.pce)->z = num2;
				int pcf = parentScrollSnap.eoj();
				parentScrollSnap.pcf = pcf;
			}
			return;
		}
		throw new NullReferenceException();
	}

	[Token(Token = "0x6001255")]
	[Address(RVA = "0x47E630", Offset = "0x47D630", VA = "0x18047E630", Slot = "5")]
	public void OnEndDrag(PointerEventData eventData)
	{
		if (phs)
		{
			phs = false;
			phr.enabled = true;
			ParentScrollRect.OnEndDrag(eventData);
			ParentScrollSnap.OnEndDrag(eventData);
		}
	}

	[Token(Token = "0x6001256")]
	[Address(RVA = "0x47E570", Offset = "0x47D570", VA = "0x18047E570", Slot = "6")]
	public unsafe void OnDrag(PointerEventData eventData)
	{
		//IL_003e: Expected I4, but got I8
		//IL_0053: Expected F4, but got I4
		//IL_004e: Expected native int or pointer, but got VT
		if (phs)
		{
			ParentScrollRect.OnDrag(eventData);
			ScrollSnap parentScrollSnap = ParentScrollSnap;
			parentScrollSnap.pbv = false;
			if (parentScrollSnap.pcd)
			{
				int linkSteps = 0;
				parentScrollSnap.epj((byte)linkSteps != 0);
				parentScrollSnap.pch = 0;
				parentScrollSnap.pcg = true;
				int num = 0;
				((Vector3*)(nint)parentScrollSnap.pce)->z = num;
				int pcf = parentScrollSnap.eoj();
				parentScrollSnap.pcf = pcf;
				parentScrollSnap.pcd = false;
			}
		}
	}

	[Token(Token = "0x6001257")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ScrollConflictManager()
	{
	}
}
