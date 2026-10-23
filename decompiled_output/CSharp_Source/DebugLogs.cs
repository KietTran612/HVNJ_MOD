using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000005")]
public class DebugLogs : ScriptableObject
{
	[Serializable]
	[Token(Token = "0x2000006")]
	public class Log
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400000C")]
		public LogType type;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400000D")]
		public string message;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400000E")]
		public string stackTrace;

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public Log()
		{
		}
	}

	[Token(Token = "0x4000008")]
	private static DebugLogs instance;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000009")]
	public Action<Log> OnLogAdded;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400000A")]
	public Action OnLogsCleared;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400000B")]
	private List<Log> logs = (List<Log>)(object)new List<T>();

	[Token(Token = "0x17000004")]
	public static DebugLogs pot
	{
		[Token(Token = "0x600000F")]
		[Address(RVA = "0x69ABF0", Offset = "0x699BF0", VA = "0x18069ABF0")]
		get
		{
			//IL_000f: Expected Obj, but got I4
			DebugLogs debugLogs = instance;
			int num = 0;
			if (debugLogs == (UnityEngine.Object)num)
			{
				instance = ScriptableObject.CreateInstance<DebugLogs>();
			}
			return instance;
		}
	}

	[Token(Token = "0x17000005")]
	public List<Log> pou
	{
		[Token(Token = "0x6000010")]
		[Address(RVA = "0x283C00", Offset = "0x282C00", VA = "0x180283C00")]
		get
		{
			return logs;
		}
	}

	[Token(Token = "0x6000011")]
	[Address(RVA = "0x69AB10", Offset = "0x699B10", VA = "0x18069AB10")]
	private void OnEnable()
	{
		Application.logMessageReceived += rl;
	}

	[Token(Token = "0x6000012")]
	[Address(RVA = "0x69AAA0", Offset = "0x699AA0", VA = "0x18069AAA0")]
	private void OnDestroy()
	{
		Application.logMessageReceived -= rl;
	}

	[Token(Token = "0x6000013")]
	[Address(RVA = "0x69ACA0", Offset = "0x699CA0", VA = "0x18069ACA0")]
	public static DebugLogs ri()
	{
		int num = 0;
		return pot;
	}

	[Token(Token = "0x6000014")]
	[Address(RVA = "0x69ACB0", Offset = "0x699CB0", VA = "0x18069ACB0")]
	public void rj(Log log)
	{
		//IL_000c: Expected VT, but got Obj
		//IL_001e: Expected VT, but got Obj
		((List<T>)(object)logs).Add((T)log);
		((Action<T>)(object)OnLogAdded)?.Invoke((T)log);
	}

	[Token(Token = "0x6000015")]
	[Address(RVA = "0x69AD30", Offset = "0x699D30", VA = "0x18069AD30")]
	public void rk()
	{
		((List<T>)(object)logs).Clear();
		OnLogsCleared?.Invoke();
	}

	[Token(Token = "0x6000016")]
	[Address(RVA = "0x69AD90", Offset = "0x699D90", VA = "0x18069AD90")]
	private void rl(string condition, string stackTrace, LogType logType)
	{
		//IL_0042: Expected VT, but got Obj
		//IL_0057: Expected VT, but got Obj
		if (!string.IsNullOrEmpty(stackTrace))
		{
			int stringLength = stackTrace.m_stringLength;
			string text = stackTrace.Remove(stringLength, 1);
		}
		Log log = new Log();
		log.type = logType;
		log.message = condition;
		log.stackTrace = stackTrace;
		((List<T>)(object)logs).Add((T)log);
		((Action<T>)(object)OnLogAdded)?.Invoke((T)log);
	}

	[Token(Token = "0x6000017")]
	[Address(RVA = "0x69AB80", Offset = "0x699B80", VA = "0x18069AB80")]
	public DebugLogs()
	{
	}
}
