using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000002")]
public class DebugCommands : ScriptableObject
{
	[Serializable]
	[Token(Token = "0x2000003")]
	public class Command
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000004")]
		public string name;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000005")]
		public DebugCommand method;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000006")]
		public string description;

		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000007")]
		public string argsDescription;

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public Command()
		{
		}
	}

	[Token(Token = "0x2000004")]
	public delegate void DebugCommand(string[] args);

	[Token(Token = "0x4000001")]
	private static DebugCommands instance;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000002")]
	private List<Command> commands = (List<Command>)(object)new List<T>();

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000003")]
	private List<string> commandHistory = (List<string>)(object)new List<T>();

	[Token(Token = "0x17000001")]
	public static DebugCommands pop
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x69A410", Offset = "0x699410", VA = "0x18069A410")]
		get
		{
			//IL_000f: Expected Obj, but got I4
			DebugCommands debugCommands = instance;
			int num = 0;
			if (debugCommands == (UnityEngine.Object)num)
			{
				instance = ScriptableObject.CreateInstance<DebugCommands>();
			}
			return instance;
		}
	}

	[Token(Token = "0x17000002")]
	public List<Command> poq
	{
		[Token(Token = "0x6000002")]
		[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080")]
		get
		{
			return commands;
		}
	}

	[Token(Token = "0x17000003")]
	public List<string> por
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x27CB90", Offset = "0x27BB90", VA = "0x18027CB90")]
		get
		{
			return commandHistory;
		}
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x69A530", Offset = "0x699530", VA = "0x18069A530")]
	public bool rc(string cmdName)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000005")]
	[Address(RVA = "0x69A620", Offset = "0x699620", VA = "0x18069A620")]
	public bool rd(string[] args)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0x69A800", Offset = "0x699800", VA = "0x18069A800")]
	public void re(string cmdName, DebugCommand method, string desc = "", string argDesc = "")
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000007")]
	[Address(RVA = "0x69A990", Offset = "0x699990", VA = "0x18069A990")]
	public void rf(string cmdName)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000008")]
	[Address(RVA = "0x69A360", Offset = "0x699360", VA = "0x18069A360")]
	public DebugCommands()
	{
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static DebugCommands()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
