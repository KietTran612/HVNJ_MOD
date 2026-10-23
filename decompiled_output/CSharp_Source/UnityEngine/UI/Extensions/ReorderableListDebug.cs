using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001A6")]
public class ReorderableListDebug : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001998")]
	public Text DebugLabel;

	[Token(Token = "0x6000E53")]
	[Address(RVA = "0x44BF00", Offset = "0x44AF00", VA = "0x18044BF00")]
	private void Awake()
	{
		ReorderableList[] array = Object.FindObjectsOfType<ReorderableList>();
		int num = 0;
		int length = array.Length;
		if (num < length)
		{
			ReorderableList.ReorderableListHandler onElementDropped = array[num].OnElementDropped;
			UnityAction<ReorderableList.ReorderableListEventStruct> unityAction = (UnityAction<ReorderableList.ReorderableListEventStruct>)(object)new UnityAction<T0>(ecl);
			((UnityEvent<T0>)(object)onElementDropped).AddListener((UnityAction<>)(object)unityAction);
			num++;
		}
	}

	[Token(Token = "0x6000E54")]
	[Address(RVA = "0x44C050", Offset = "0x44B050", VA = "0x18044C050")]
	private void ecl(ReorderableList.ReorderableListEventStruct droppedStruct)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E55")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ReorderableListDebug()
	{
	}
}
