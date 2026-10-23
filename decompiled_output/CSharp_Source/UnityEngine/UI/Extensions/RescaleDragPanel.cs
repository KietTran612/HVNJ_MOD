using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001A8")]
[AddComponentMenu("UI/Extensions/RescalePanels/RescaleDragPanel")]
public class RescaleDragPanel : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40019AE")]
	private Vector2 ouj;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40019AF")]
	private RectTransform ouk;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40019B0")]
	private RectTransform oul;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40019B1")]
	private Transform oum;

	[Token(Token = "0x6000E60")]
	[Address(RVA = "0x44FB00", Offset = "0x44EB00", VA = "0x18044FB00")]
	private void Awake()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0027: Expected Obj, but got I4
		Canvas componentInParent = GetComponentInParent<Canvas>();
		int num = 0;
		if (componentInParent != (Object)num)
		{
			Transform transform = componentInParent.transform;
			int num2 = 0;
			if ((object)transform != null)
			{
			}
			ouk = (RectTransform)num2;
			Transform parent = base.transform.parent;
			if ((object)parent != null)
			{
			}
			oul = (RectTransform)parent;
			Transform parent2 = base.transform.parent;
			oum = parent2;
		}
	}

	[Token(Token = "0x6000E61")]
	[Address(RVA = "0x44FF10", Offset = "0x44EF10", VA = "0x18044FF10", Slot = "4")]
	public void OnPointerDown(PointerEventData data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E62")]
	[Address(RVA = "0x44FC20", Offset = "0x44EC20", VA = "0x18044FC20", Slot = "5")]
	public void OnDrag(PointerEventData data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E63")]
	[Address(RVA = "0x44FFF0", Offset = "0x44EFF0", VA = "0x18044FFF0")]
	private Vector2 ecs(PointerEventData data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E64")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public RescaleDragPanel()
	{
	}
}
