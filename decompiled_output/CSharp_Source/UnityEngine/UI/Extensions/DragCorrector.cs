using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000231")]
[RequireComponent(typeof(EventSystem))]
[AddComponentMenu("UI/Extensions/DragCorrector")]
public class DragCorrector : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C98")]
	public int baseTH = 6;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001C99")]
	public int basePPI = 210;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C9A")]
	public int dragTH;

	[Token(Token = "0x600123B")]
	[Address(RVA = "0x69D880", Offset = "0x69C880", VA = "0x18069D880")]
	private void Start()
	{
		//IL_0013: Expected I4, but got VT
		int num = 0;
		float dpi = Screen.dpi;
		dragTH = (int)typeof(Object).TypeHandle;
		EventSystem component = GetComponent<EventSystem>();
		if ((bool)component)
		{
			int dragThreshold = dragTH;
			component.m_DragThreshold = dragThreshold;
		}
	}

	[Token(Token = "0x600123C")]
	[Address(RVA = "0x69D930", Offset = "0x69C930", VA = "0x18069D930")]
	public DragCorrector()
	{
		//IL_0009: Expected I4, but got I8
		//IL_0016: Expected I4, but got I8
	}
}
