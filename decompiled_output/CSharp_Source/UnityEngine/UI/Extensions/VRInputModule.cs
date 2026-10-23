using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000257")]
[AddComponentMenu("Event/VR Input Module")]
public class VRInputModule : BaseInputModule
{
	[Token(Token = "0x4001D21")]
	public static GameObject targetObject;

	[Token(Token = "0x4001D22")]
	private static VRInputModule plb;

	[Token(Token = "0x4001D23")]
	private static bool plc;

	[Token(Token = "0x4001D24")]
	public static Vector3 cursorPosition;

	[Token(Token = "0x60012F2")]
	[Address(RVA = "0x434E50", Offset = "0x433E50", VA = "0x180434E50", Slot = "4")]
	protected override void Awake()
	{
		plb = this;
	}

	[Token(Token = "0x60012F3")]
	[Address(RVA = "0x434E90", Offset = "0x433E90", VA = "0x180434E90", Slot = "17")]
	public override void Process()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012F4")]
	[Address(RVA = "0x434F30", Offset = "0x433F30", VA = "0x180434F30")]
	public static void fdz(GameObject obj)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012F5")]
	[Address(RVA = "0x435120", Offset = "0x434120", VA = "0x180435120")]
	public static void fea(GameObject obj)
	{
		string text = obj.name;
		MonoBehaviour.print("PointerExit " + text);
		PointerEventData pointerEventData = new PointerEventData(((BaseInputModule)plb).m_EventSystem);
		ExecuteEvents.EventFunction<IPointerExitHandler> s_PointerExitHandler = ExecuteEvents.s_PointerExitHandler;
		bool flag = ExecuteEvents.Execute<IPointerExitHandler>(obj, (BaseEventData)pointerEventData, (ExecuteEvents.EventFunction<>)(object)s_PointerExitHandler);
		ExecuteEvents.EventFunction<IDeselectHandler> s_DeselectHandler = ExecuteEvents.s_DeselectHandler;
		bool flag2 = ExecuteEvents.Execute<IDeselectHandler>(obj, (BaseEventData)pointerEventData, (ExecuteEvents.EventFunction<>)(object)s_DeselectHandler);
	}

	[Token(Token = "0x60012F6")]
	[Address(RVA = "0x435300", Offset = "0x434300", VA = "0x180435300")]
	public static void feb(GameObject obj)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60012F7")]
	[Address(RVA = "0x434F20", Offset = "0x433F20", VA = "0x180434F20")]
	public VRInputModule()
	{
	}
}
