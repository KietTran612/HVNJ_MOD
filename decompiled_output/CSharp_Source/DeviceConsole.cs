using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000007")]
public class DeviceConsole : MonoBehaviour
{
	[Cpp2IlInjected.FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400000F")]
	[SerializeField]
	private GameObject uiContainer;

	[Cpp2IlInjected.FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000010")]
	[SerializeField]
	private GameObject logContainer;

	[Cpp2IlInjected.FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000011")]
	[SerializeField]
	private InputField commandInputField;

	[Cpp2IlInjected.FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000012")]
	[SerializeField]
	private bool autoFocusInputField = true;

	[Cpp2IlInjected.FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000013")]
	[SerializeField]
	private Color headerColour;

	[Cpp2IlInjected.FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000014")]
	[SerializeField]
	private string headerText;

	[Cpp2IlInjected.FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000015")]
	[SerializeField]
	private DeviceLogUI logPrefab;

	[Cpp2IlInjected.FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000016")]
	[SerializeField]
	private DeviceLogUI warningLogPrefab;

	[Cpp2IlInjected.FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000017")]
	[SerializeField]
	private DeviceLogUI errorLogPrefab;

	[Cpp2IlInjected.FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000018")]
	[SerializeField]
	private DeviceLogUI assertLogPrefab;

	[Cpp2IlInjected.FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000019")]
	[SerializeField]
	private DeviceLogUI exceptionLogPrefab;

	[Cpp2IlInjected.FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400001A")]
	[SerializeField]
	private DeviceLogUI exceptionStackTracePrefab;

	[Token(Token = "0x400001B")]
	private static int fkc;

	[Cpp2IlInjected.FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400001C")]
	private List<DeviceLogUI> fkd;

	[Cpp2IlInjected.FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400001D")]
	private int fke;

	[Cpp2IlInjected.FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x400001E")]
	private int fkf;

	[Cpp2IlInjected.FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400001F")]
	private bool fkg;

	[Cpp2IlInjected.FieldOffset(Offset = "0x91")]
	[Token(Token = "0x4000020")]
	private bool fkh;

	[Token(Token = "0x6000019")]
	[Address(RVA = "0x69AF30", Offset = "0x699F30", VA = "0x18069AF30")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600001A")]
	[Address(RVA = "0x69BB50", Offset = "0x69AB50", VA = "0x18069BB50")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600001B")]
	[Address(RVA = "0x69B650", Offset = "0x69A650", VA = "0x18069B650")]
	private void OnDestroy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600001C")]
	[Address(RVA = "0x69C0A0", Offset = "0x69B0A0", VA = "0x18069C0A0")]
	public void rm(bool visible)
	{
		//IL_001c: Expected Obj, but got I4
		uiContainer.SetActive(visible);
		InputField inputField = commandInputField;
		int num = 0;
		if (inputField != (Object)num)
		{
			commandInputField.text = "";
			if (visible)
			{
				rw();
			}
		}
	}

	[Token(Token = "0x600001D")]
	[Address(RVA = "0x69B840", Offset = "0x69A840", VA = "0x18069B840")]
	public void OnEndEdit()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600001E")]
	[Address(RVA = "0x69C170", Offset = "0x69B170", VA = "0x18069C170")]
	private void rn(string text, [Optional] DeviceLogUI prefab)
	{
		//IL_0010: Expected Obj, but got I4
		//IL_001c: Expected Obj, but got I4
		GameObject gameObject = logContainer;
		int num = 0;
		if (gameObject != (Object)num)
		{
			int num2 = 0;
			if (!(prefab != (Object)num2))
			{
			}
			rs(prefab, text);
		}
	}

	[Token(Token = "0x600001F")]
	[Address(RVA = "0x69C240", Offset = "0x69B240", VA = "0x18069C240")]
	private void ro(DebugLogs.Log log, string prefix = "")
	{
		//IL_0010: Expected Obj, but got I4
		GameObject gameObject = logContainer;
		int num = 0;
		if (gameObject != (Object)num)
		{
			LogType type = log.type;
			DeviceLogUI prefab = default;
			if (type == LogType.Error || type == LogType.Error || type == LogType.Error || type == LogType.Error || type == LogType.Assert)
			{
				prefab = errorLogPrefab;
			}
			string message = log.message;
			string text = prefix + message;
			rs(prefab, text);
			if (log.type == LogType.Exception)
			{
				DeviceLogUI prefab2 = exceptionStackTracePrefab;
				string stackTrace = log.stackTrace;
				rn(stackTrace, prefab2);
			}
		}
	}

	[Token(Token = "0x6000020")]
	[Address(RVA = "0x69C350", Offset = "0x69B350", VA = "0x18069C350")]
	private void rp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000021")]
	[Address(RVA = "0x69C440", Offset = "0x69B440", VA = "0x18069C440")]
	private void rq()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000022")]
	[Address(RVA = "0x69C520", Offset = "0x69B520", VA = "0x18069C520")]
	private void rr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000023")]
	[Address(RVA = "0x69C640", Offset = "0x69B640", VA = "0x18069C640")]
	private void rs(DeviceLogUI prefab, string text)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000024")]
	[Address(RVA = "0x69C940", Offset = "0x69B940", VA = "0x18069C940")]
	private void ru(DebugLogs.Log log)
	{
		ro(log);
	}

	[Token(Token = "0x6000025")]
	[Address(RVA = "0x69C990", Offset = "0x69B990", VA = "0x18069C990")]
	private void rv()
	{
		rr();
		rp();
	}

	[Token(Token = "0x6000026")]
	[Address(RVA = "0x69C9B0", Offset = "0x69B9B0", VA = "0x18069C9B0")]
	private void rw()
	{
		//IL_0019: Expected Obj, but got I4
		if (autoFocusInputField)
		{
			InputField inputField = commandInputField;
			int num = 0;
			if (inputField != (Object)num)
			{
				commandInputField.Select();
				commandInputField.ActivateInputField();
			}
		}
	}

	[Token(Token = "0x6000027")]
	[Address(RVA = "0x69CA60", Offset = "0x69BA60", VA = "0x18069CA60")]
	private string rx(Color32 color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000028")]
	[Address(RVA = "0x69CAF0", Offset = "0x69BAF0", VA = "0x18069CAF0")]
	private void ry(string[] args)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000029")]
	[Address(RVA = "0x69CD90", Offset = "0x69BD90", VA = "0x18069CD90")]
	private void rz(string[] args)
	{
		if (args.Length == 2)
		{
			if (string.Equals(args[1], "t") || string.Equals(args[1], "true"))
			{
				autoFocusInputField = true;
				return;
			}
			if (string.Equals(args[1], "f") || string.Equals(args[1], "false"))
			{
				autoFocusInputField = false;
				return;
			}
		}
		Debug.LogError("Please specify either t or f.");
	}

	[Token(Token = "0x600002A")]
	[Address(RVA = "0x69CF30", Offset = "0x69BF30", VA = "0x18069CF30")]
	private static void sa(string[] args)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600002B")]
	[Address(RVA = "0x69D110", Offset = "0x69C110", VA = "0x18069D110")]
	private static void sb(string[] args)
	{
		int num = 0;
		DebugLogs debugLogs = DebugLogs.pot;
		((List<T>)(object)debugLogs.logs).Clear();
		debugLogs.OnLogsCleared?.Invoke();
	}

	[Token(Token = "0x600002C")]
	[Address(RVA = "0x69D180", Offset = "0x69C180", VA = "0x18069D180")]
	private static void sd(string[] args)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600002D")]
	[Address(RVA = "0x69D2A0", Offset = "0x69C2A0", VA = "0x18069D2A0")]
	private static void se(string[] args)
	{
		//IL_001d: Expected Obj, but got I4
		int num = 0;
		int size = ((List<>)(object)DebugLogs.pot.logs)._size;
		Debug.Log($"There are {size} reported logs.");
	}

	[Token(Token = "0x600002E")]
	[Address(RVA = "0x69D370", Offset = "0x69C370", VA = "0x18069D370")]
	private static void sf(string[] args)
	{
		if (args.Length == 2)
		{
			Application.LoadLevel(args[1]);
		}
		else
		{
			Debug.LogError("Please specify a scene name.");
		}
	}

	[Token(Token = "0x600002F")]
	[Address(RVA = "0x4430C0", Offset = "0x4420C0", VA = "0x1804430C0")]
	private static void sg(string[] args)
	{
		int num = 0;
		Application.Quit();
	}

	[Token(Token = "0x6000030")]
	[Address(RVA = "0x611B60", Offset = "0x610B60", VA = "0x180611B60")]
	public DeviceConsole()
	{
	}
}
