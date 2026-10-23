using Cpp2IlInjected;

namespace UnityEngine.EventSystems;

[Token(Token = "0x2000178")]
[AddComponentMenu("Event/Extensions/GamePad Input Module")]
public class GamePadInputModule : BaseInputModule
{
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40018A8")]
	private float opi;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x40018A9")]
	private Vector2 opj;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x40018AA")]
	private int opk;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40018AB")]
	[SerializeField]
	private string m_HorizontalAxis = "Horizontal";

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40018AC")]
	[SerializeField]
	private string m_VerticalAxis = "Vertical";

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40018AD")]
	[SerializeField]
	private string m_SubmitButton = "Submit";

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40018AE")]
	[SerializeField]
	private string m_CancelButton = "Cancel";

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40018AF")]
	[SerializeField]
	private float m_InputActionsPerSecond = 10f;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x40018B0")]
	[SerializeField]
	private float m_RepeatDelay = 0.1f;

	[Token(Token = "0x17000016")]
	public float poz
	{
		[Token(Token = "0x6000D34")]
		[Address(RVA = "0x6A4A40", Offset = "0x6A3A40", VA = "0x1806A4A40")]
		get
		{
			return m_InputActionsPerSecond;
		}
		[Token(Token = "0x6000D35")]
		[Address(RVA = "0x6A4A50", Offset = "0x6A3A50", VA = "0x1806A4A50")]
		set
		{
			m_InputActionsPerSecond = value;
		}
	}

	[Token(Token = "0x17000017")]
	public float ppa
	{
		[Token(Token = "0x6000D36")]
		[Address(RVA = "0x6A4A60", Offset = "0x6A3A60", VA = "0x1806A4A60")]
		get
		{
			return m_RepeatDelay;
		}
		[Token(Token = "0x6000D37")]
		[Address(RVA = "0x6A4A70", Offset = "0x6A3A70", VA = "0x1806A4A70")]
		set
		{
			m_RepeatDelay = value;
		}
	}

	[Token(Token = "0x17000018")]
	public string ppb
	{
		[Token(Token = "0x6000D38")]
		[Address(RVA = "0x3EFA40", Offset = "0x3EEA40", VA = "0x1803EFA40")]
		get
		{
			return m_HorizontalAxis;
		}
		[Token(Token = "0x6000D39")]
		[Address(RVA = "0x3EFA60", Offset = "0x3EEA60", VA = "0x1803EFA60")]
		set
		{
			m_HorizontalAxis = value;
		}
	}

	[Token(Token = "0x17000019")]
	public string ppc
	{
		[Token(Token = "0x6000D3A")]
		[Address(RVA = "0x3EFA30", Offset = "0x3EEA30", VA = "0x1803EFA30")]
		get
		{
			return m_VerticalAxis;
		}
		[Token(Token = "0x6000D3B")]
		[Address(RVA = "0x378310", Offset = "0x377310", VA = "0x180378310")]
		set
		{
			m_VerticalAxis = value;
		}
	}

	[Token(Token = "0x1700001A")]
	public string ppd
	{
		[Token(Token = "0x6000D3C")]
		[Address(RVA = "0x3EFA20", Offset = "0x3EEA20", VA = "0x1803EFA20")]
		get
		{
			return m_SubmitButton;
		}
		[Token(Token = "0x6000D3D")]
		[Address(RVA = "0x3EFA50", Offset = "0x3EEA50", VA = "0x1803EFA50")]
		set
		{
			m_SubmitButton = value;
		}
	}

	[Token(Token = "0x1700001B")]
	public string ppe
	{
		[Token(Token = "0x6000D3E")]
		[Address(RVA = "0x40DE90", Offset = "0x40CE90", VA = "0x18040DE90")]
		get
		{
			return m_CancelButton;
		}
		[Token(Token = "0x6000D3F")]
		[Address(RVA = "0x40DED0", Offset = "0x40CED0", VA = "0x18040DED0")]
		set
		{
			m_CancelButton = value;
		}
	}

	[Token(Token = "0x6000D33")]
	[Address(RVA = "0x6A49A0", Offset = "0x6A39A0", VA = "0x1806A49A0")]
	protected GamePadInputModule()
	{
	}

	[Token(Token = "0x6000D40")]
	[Address(RVA = "0x6A4930", Offset = "0x6A3930", VA = "0x1806A4930", Slot = "21")]
	public override bool ShouldActivateModule()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D41")]
	[Address(RVA = "0x6A4620", Offset = "0x6A3620", VA = "0x1806A4620", Slot = "23")]
	public override void ActivateModule()
	{
		//IL_003e: Expected Obj, but got I4
		StandaloneInputModule component = GetComponent<StandaloneInputModule>();
		if ((bool)component && component.enabled)
		{
			Debug.LogError("StandAloneInputSystem should not be used with the GamePadInputModule, please remove it from the Event System in this scene or disable it when this module is in use");
		}
		((object)this)._002Ector();
		GameObject currentSelected = base.m_EventSystem.m_CurrentSelected;
		int num = 0;
		GameObject firstSelected = default;
		if (currentSelected == (Object)num)
		{
			firstSelected = base.m_EventSystem.m_FirstSelected;
		}
		EventSystem eventSystem = base.m_EventSystem;
		BaseEventData baseEventData = GetBaseEventData();
		eventSystem.SetSelectedGameObject(firstSelected, baseEventData);
	}

	[Token(Token = "0x6000D42")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290", Slot = "22")]
	public override void DeactivateModule()
	{
		((object)this)._002Ector();
	}

	[Token(Token = "0x6000D43")]
	[Address(RVA = "0x6A4790", Offset = "0x6A3790", VA = "0x1806A4790", Slot = "17")]
	public override void Process()
	{
		//IL_0015: Expected Obj, but got I4
		GameObject currentSelected = base.m_EventSystem.m_CurrentSelected;
		int num = 0;
		if (!(currentSelected == (Object)num))
		{
			BaseEventData baseEventData = GetBaseEventData();
			GameObject currentSelected2 = base.m_EventSystem.m_CurrentSelected;
			ExecuteEvents.EventFunction<IUpdateSelectedHandler> s_UpdateSelectedHandler = ExecuteEvents.s_UpdateSelectedHandler;
			bool flag = ExecuteEvents.Execute<IUpdateSelectedHandler>(currentSelected2, baseEventData, (ExecuteEvents.EventFunction<>)(object)s_UpdateSelectedHandler);
			bool used = baseEventData.used;
		}
		int num2 = 0;
		if (base.m_EventSystem.m_sendNavigationEvents && num2 == 0 && !dvp())
		{
			bool flag2 = dvn();
		}
	}

	[Token(Token = "0x6000D44")]
	[Address(RVA = "0x6A4A80", Offset = "0x6A3A80", VA = "0x1806A4A80")]
	protected bool dvn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D45")]
	[Address(RVA = "0x6A4CD0", Offset = "0x6A3CD0", VA = "0x1806A4CD0")]
	private Vector2 dvo()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D46")]
	[Address(RVA = "0x6A4D90", Offset = "0x6A3D90", VA = "0x1806A4D90")]
	protected bool dvp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D47")]
	[Address(RVA = "0x6A5070", Offset = "0x6A4070", VA = "0x1806A5070")]
	protected bool dvq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
