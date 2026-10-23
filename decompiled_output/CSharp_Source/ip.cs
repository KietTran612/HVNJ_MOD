using System.Collections.Generic;
using Cpp2IlInjected;

[Token(Token = "0x20000E2")]
public class ip
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000CFF")]
	public List<iq> kes;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000D00")]
	public int ket;

	[Token(Token = "0x4000D01")]
	private static ip keu;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000D02")]
	public int kev;

	[Token(Token = "0x4000D03")]
	public static bool kew;

	[Token(Token = "0x4000D04")]
	public static bool kex;

	[Token(Token = "0x4000D05")]
	public static bool kez;

	[Token(Token = "0x4000D06")]
	public static bool kfa;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000D07")]
	public List<string> kfb = (List<string>)(object)new List<T>();

	[Token(Token = "0x60006FF")]
	[Address(RVA = "0x4E2DA0", Offset = "0x4E1DA0", VA = "0x1804E2DA0")]
	public void cfk()
	{
		//IL_002d: Expected I4, but got I8
		int num = kev;
		List<iq> list = kes;
		num = (kev = num + 1);
		int size = ((List<>)(object)list)._size;
		if (num > size)
		{
			kev = 0;
		}
	}

	[Token(Token = "0x6000700")]
	[Address(RVA = "0x4E2E00", Offset = "0x4E1E00", VA = "0x1804E2E00")]
	public void cfl()
	{
		int size = ((List<>)(object)kes)._size;
		kev = size;
	}

	[Token(Token = "0x6000701")]
	[Address(RVA = "0x335C60", Offset = "0x334C60", VA = "0x180335C60")]
	public void cfm(int index)
	{
		kev = index;
	}

	[Token(Token = "0x6000702")]
	[Address(RVA = "0x4E2E50", Offset = "0x4E1E50", VA = "0x1804E2E50")]
	public void cfn(iq t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000703")]
	[Address(RVA = "0x4E2F10", Offset = "0x4E1F10", VA = "0x1804E2F10")]
	public void cfo()
	{
		int size = ((List<>)(object)kes)._size;
		kev = size;
	}

	[Token(Token = "0x6000704")]
	[Address(RVA = "0x4E2F60", Offset = "0x4E1F60", VA = "0x1804E2F60")]
	public static ip cfp()
	{
		ip ip2 = keu;
		if (ip2 == null)
		{
			keu = new ip();
		}
		return ip2;
	}

	[Token(Token = "0x6000705")]
	[Address(RVA = "0x4E28A0", Offset = "0x4E18A0", VA = "0x1804E28A0")]
	public ip()
	{
		//IL_003b: Expected VT, but got Obj
		//IL_005f: Expected VT, but got Obj
		//IL_0083: Expected VT, but got Obj
		//IL_00a7: Expected VT, but got Obj
		List<iq> list = (kes = (List<iq>)(object)new List<T>());
		int type = default;
		iq iq2 = new iq(hd.irs[0], type);
		type = 0;
		((List<T>)(object)list).Add((T)iq2);
		List<iq> list2 = kes;
		iq iq3 = new iq(hd.irt[0], 1);
		((List<T>)(object)list2).Add((T)iq3);
		List<iq> list3 = kes;
		iq iq4 = new iq(hd.iru[0], 3);
		((List<T>)(object)list3).Add((T)iq4);
		List<iq> list4 = kes;
		iq iq5 = new iq(hd.irv[0], 4);
		((List<T>)(object)list4).Add((T)iq5);
		string ownerName = hd.irt[0];
		iq iq6 = cfq(ownerName);
		string text = hd.irt[1];
		string text2 = "c8" + text;
		iq6.cga(text2);
		string ownerName2 = hd.irv[0];
		iq iq7 = cfq(ownerName2);
		string text3 = hd.irv[1];
		string text4 = "c8" + text3;
		iq7.cga(text4);
		string ownerName3 = hd.irs[0];
		iq iq8 = cfq(ownerName3);
		string text5 = hd.irs[1];
		string text6 = "c8" + text5;
		iq8.cga(text6);
	}

	[Token(Token = "0x6000706")]
	[Address(RVA = "0x4E2FD0", Offset = "0x4E1FD0", VA = "0x1804E2FD0")]
	public iq cfq(string ownerName)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000707")]
	[Address(RVA = "0x4E30B0", Offset = "0x4E20B0", VA = "0x1804E30B0")]
	public void cfr(string ownerName, string whoChat, string text, string toChat)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000708")]
	[Address(RVA = "0x4E31A0", Offset = "0x4E21A0", VA = "0x1804E31A0")]
	public void cfs(string text)
	{
		string ownerName = hd.irs[0];
		cfq(ownerName)?.cga(text);
	}

	[Token(Token = "0x6000709")]
	[Address(RVA = "0x4E3250", Offset = "0x4E2250", VA = "0x1804E3250")]
	public iq cft()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600070A")]
	[Address(RVA = "0x4E32B0", Offset = "0x4E22B0", VA = "0x1804E32B0")]
	public iq cfu(string friendName)
	{
		//IL_0014: Expected VT, but got Obj
		iq iq2 = new iq(friendName, 2);
		((List<T>)(object)kes).Add((T)iq2);
		return iq2;
	}

	[Token(Token = "0x600070B")]
	[Address(RVA = "0x4E3350", Offset = "0x4E2350", VA = "0x1804E3350")]
	public void cfv(string nick)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600070C")]
	[Address(RVA = "0x4E3490", Offset = "0x4E2490", VA = "0x1804E3490")]
	public bool cfw(string nick)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600070D")]
	[Address(RVA = "0x4E3560", Offset = "0x4E2560", VA = "0x1804E3560")]
	public int cfx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600070E")]
	[Address(RVA = "0x4E36A0", Offset = "0x4E26A0", VA = "0x1804E36A0")]
	public void cfy(string nick)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600070F")]
	[Address(RVA = "0x4E3790", Offset = "0x4E2790", VA = "0x1804E3790")]
	public void clear()
	{
	}
}
