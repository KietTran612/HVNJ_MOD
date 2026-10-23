using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000241")]
[RequireComponent(typeof(ScrollRect))]
[AddComponentMenu("UI/Extensions/ScrollRectLinker")]
public class ScrollRectLinker : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001CAD")]
	public bool clamp = true;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001CAE")]
	[SerializeField]
	private ScrollRect controllingScrollRect;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001CAF")]
	private ScrollRect pia;

	[Token(Token = "0x600126B")]
	[Address(RVA = "0x47FF30", Offset = "0x47EF30", VA = "0x18047FF30")]
	private void Awake()
	{
		//IL_001e: Expected Obj, but got I4
		ScrollRect component = GetComponent<ScrollRect>();
		ScrollRect scrollRect = controllingScrollRect;
		pia = component;
		int num = 0;
		if (scrollRect != (Object)num)
		{
			ScrollRect.ScrollRectEvent onValueChanged = controllingScrollRect.m_OnValueChanged;
			UnityAction<Vector2> unityAction = (UnityAction<Vector2>)(object)new UnityAction<T0>(fau);
			((UnityEvent<T0>)(object)onValueChanged).AddListener((UnityAction<>)(object)unityAction);
		}
	}

	[Token(Token = "0x600126C")]
	[Address(RVA = "0x480060", Offset = "0x47F060", VA = "0x180480060")]
	private void fau(Vector2 scrollPos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600126D")]
	[Address(RVA = "0x480050", Offset = "0x47F050", VA = "0x180480050")]
	public ScrollRectLinker()
	{
	}
}
