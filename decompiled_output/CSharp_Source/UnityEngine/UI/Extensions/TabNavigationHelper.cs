using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000224")]
[RequireComponent(typeof(EventSystem))]
[AddComponentMenu("Event/Extensions/Tab Navigation Helper")]
public class TabNavigationHelper : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C3B")]
	private EventSystem pfi;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C3C")]
	private Selectable pfj;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001C3D")]
	private Selectable pfk;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001C3E")]
	[Tooltip("The path to take when user is tabbing through ui components.")]
	public Selectable[] NavigationPath;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001C3F")]
	[Tooltip("Use the default Unity navigation system or a manual fixed order using Navigation Path")]
	public pp NavigationMode;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001C40")]
	[Tooltip("If True, this will loop the tab order from last to first automatically")]
	public bool CircularNavigation;

	[Token(Token = "0x60011C9")]
	[Address(RVA = "0x48DDE0", Offset = "0x48CDE0", VA = "0x18048DDE0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011CA")]
	[Address(RVA = "0x48DF70", Offset = "0x48CF70", VA = "0x18048DF70")]
	public void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011CB")]
	[Address(RVA = "0x48E790", Offset = "0x48D790", VA = "0x18048E790")]
	private void exk(out Selectable next)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011CC")]
	[Address(RVA = "0x48E850", Offset = "0x48D850", VA = "0x18048E850")]
	private void exl(Selectable selectable)
	{
		//IL_0009: Expected Obj, but got I4
		//IL_001c: Expected Obj, but got I4
		int num = 0;
		if (selectable != (Object)num)
		{
			InputField component = selectable.GetComponent<InputField>();
			int num2 = 0;
			if (component != (Object)num2)
			{
				PointerEventData eventData = new PointerEventData(pfi);
				component.OnPointerClick(eventData);
			}
			EventSystem eventSystem = pfi;
			GameObject selected = selectable.gameObject;
			BaseEventData pointer = new BaseEventData(pfi);
			eventSystem.SetSelectedGameObject(selected, pointer);
		}
	}

	[Token(Token = "0x60011CD")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public TabNavigationHelper()
	{
	}
}
