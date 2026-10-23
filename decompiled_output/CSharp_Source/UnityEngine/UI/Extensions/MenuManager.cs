using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000210")]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Extensions/Menu Manager")]
public class MenuManager : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001BB4")]
	[SerializeField]
	private Menu[] menuScreens;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001BB5")]
	[SerializeField]
	private int startScreen;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001BB6")]
	private Stack<Menu> pdu = (Stack<Menu>)(object)new Stack<T>();

	[Token(Token = "0x170000C1")]
	public Menu[] puz
	{
		[Token(Token = "0x6001122")]
		[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080")]
		get
		{
			return menuScreens;
		}
		[Token(Token = "0x6001123")]
		[Address(RVA = "0x378270", Offset = "0x377270", VA = "0x180378270")]
		set
		{
			menuScreens = value;
		}
	}

	[Token(Token = "0x170000C2")]
	public int pva
	{
		[Token(Token = "0x6001124")]
		[Address(RVA = "0x335BE0", Offset = "0x334BE0", VA = "0x180335BE0")]
		get
		{
			return startScreen;
		}
		[Token(Token = "0x6001125")]
		[Address(RVA = "0x4457A0", Offset = "0x4447A0", VA = "0x1804457A0")]
		set
		{
			startScreen = value;
		}
	}

	[Token(Token = "0x170000C3")]
	[field: Token(Token = "0x4001BB7")]
	public static MenuManager pdv
	{
		[Token(Token = "0x6001126")]
		[Address(RVA = "0x4457B0", Offset = "0x4447B0", VA = "0x1804457B0")]
		get;
		[Token(Token = "0x6001127")]
		[Address(RVA = "0x4457F0", Offset = "0x4447F0", VA = "0x1804457F0")]
		set;
	}

	[Token(Token = "0x6001128")]
	[Address(RVA = "0x445520", Offset = "0x444520", VA = "0x180445520")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001129")]
	[Address(RVA = "0x4454E0", Offset = "0x4444E0", VA = "0x1804454E0")]
	private void OnDestroy()
	{
	}

	[Token(Token = "0x600112A")]
	[Address(RVA = "0x445830", Offset = "0x444830", VA = "0x180445830")]
	public GameObject esw(string MenuName)
	{
		GameObject original = esz(MenuName);
		Transform parent = transform;
		return Object.Instantiate(original, parent);
	}

	[Token(Token = "0x600112B")]
	[Address(RVA = "0x4458C0", Offset = "0x4448C0", VA = "0x1804458C0")]
	public void esx(string MenuName, out GameObject menuInstance)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600112C")]
	[Address(RVA = "0x445970", Offset = "0x444970", VA = "0x180445970")]
	public void esy(Menu menuInstance)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600112D")]
	[Address(RVA = "0x445BD0", Offset = "0x444BD0", VA = "0x180445BD0")]
	private GameObject esz(string PrefabName)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600112E")]
	[Address(RVA = "0x445D20", Offset = "0x444D20", VA = "0x180445D20")]
	public void eta(Menu menu)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600112F")]
	[Address(RVA = "0x445F70", Offset = "0x444F70", VA = "0x180445F70")]
	public void etb()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001130")]
	[Address(RVA = "0x4456A0", Offset = "0x4446A0", VA = "0x1804456A0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001131")]
	[Address(RVA = "0x445730", Offset = "0x444730", VA = "0x180445730")]
	public MenuManager()
	{
	}
}
