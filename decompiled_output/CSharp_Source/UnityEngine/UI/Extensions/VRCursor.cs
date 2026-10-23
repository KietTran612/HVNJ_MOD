using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000256")]
[AddComponentMenu("UI/Extensions/VR Cursor")]
public class VRCursor : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D1E")]
	public float xSens;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001D1F")]
	public float ySens;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D20")]
	private Collider pla;

	[Token(Token = "0x60012EE")]
	[Address(RVA = "0x434AE0", Offset = "0x433AE0", VA = "0x180434AE0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012EF")]
	[Address(RVA = "0x4346D0", Offset = "0x4336D0", VA = "0x1804346D0")]
	private void OnTriggerEnter(Collider other)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012F0")]
	[Address(RVA = "0x4348D0", Offset = "0x4338D0", VA = "0x1804348D0")]
	private void OnTriggerExit(Collider other)
	{
		GameObject gameObject = other.gameObject;
		string text = gameObject.name;
		MonoBehaviour.print("PointerExit " + text);
		PointerEventData pointerEventData = new PointerEventData(((BaseInputModule)VRInputModule.plb).m_EventSystem);
		ExecuteEvents.EventFunction<IPointerExitHandler> s_PointerExitHandler = ExecuteEvents.s_PointerExitHandler;
		bool flag = ExecuteEvents.Execute<IPointerExitHandler>(gameObject, (BaseEventData)pointerEventData, (ExecuteEvents.EventFunction<>)(object)s_PointerExitHandler);
		ExecuteEvents.EventFunction<IDeselectHandler> s_DeselectHandler = ExecuteEvents.s_DeselectHandler;
		bool flag2 = ExecuteEvents.Execute<IDeselectHandler>(gameObject, (BaseEventData)pointerEventData, (ExecuteEvents.EventFunction<>)(object)s_DeselectHandler);
	}

	[Token(Token = "0x60012F1")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public VRCursor()
	{
	}
}
