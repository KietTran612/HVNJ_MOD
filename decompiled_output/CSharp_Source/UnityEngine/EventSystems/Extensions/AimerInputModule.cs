using Cpp2IlInjected;

namespace UnityEngine.EventSystems.Extensions;

[Token(Token = "0x2000179")]
[RequireComponent(typeof(EventSystem))]
[AddComponentMenu("Event/Extensions/Aimer Input Module")]
public class AimerInputModule : PointerInputModule
{
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40018B1")]
	public string activateAxis = "Submit";

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40018B2")]
	public Vector2 aimerOffset = (Vector2)0;

	[Token(Token = "0x40018B3")]
	public static GameObject objectUnderAimer;

	[Token(Token = "0x6000D48")]
	[Address(RVA = "0x5FD810", Offset = "0x5FC810", VA = "0x1805FD810")]
	protected AimerInputModule()
	{
		//IL_0014: Expected VT, but got I4
	}

	[Token(Token = "0x6000D49")]
	[Address(RVA = "0x5FD670", Offset = "0x5FC670", VA = "0x1805FD670", Slot = "23")]
	public override void ActivateModule()
	{
		//IL_0010: Expected Obj, but got I4
		StandaloneInputModule component = GetComponent<StandaloneInputModule>();
		int num = 0;
		if (component != (Object)num && component.enabled)
		{
			Debug.LogError("Aimer Input Module is incompatible with the StandAloneInputSystem, please remove it from the Event System in this scene or disable it when this module is in use");
		}
	}

	[Token(Token = "0x6000D4A")]
	[Address(RVA = "0x5FD770", Offset = "0x5FC770", VA = "0x1805FD770", Slot = "17")]
	public override void Process()
	{
		bool buttonDown = Input.GetButtonDown(activateAxis);
		bool buttonUp = Input.GetButtonUp(activateAxis);
		PointerEventData pointerEventData = dvr();
		dvs(pointerEventData, buttonDown, buttonUp);
		if (buttonUp)
		{
			RemovePointerData(pointerEventData);
		}
		ProcessMove(pointerEventData);
	}

	[Token(Token = "0x6000D4B")]
	[Address(RVA = "0x5FD860", Offset = "0x5FC860", VA = "0x1805FD860", Slot = "30")]
	protected virtual PointerEventData dvr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D4C")]
	[Address(RVA = "0x5FD9F0", Offset = "0x5FC9F0", VA = "0x1805FD9F0")]
	private void dvs(PointerEventData pointer, bool pressed, bool released)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D4D")]
	[Address(RVA = "0x5FD750", Offset = "0x5FC750", VA = "0x1805FD750", Slot = "22")]
	public override void DeactivateModule()
	{
		((object)this)._002Ector();
		ClearSelection();
	}
}
