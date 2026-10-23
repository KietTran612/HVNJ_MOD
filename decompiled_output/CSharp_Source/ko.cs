using Cpp2IlInjected;

[Token(Token = "0x2000114")]
public class ko
{
	[Token(Token = "0x400113D")]
	public static sbyte luq;

	[Token(Token = "0x400113E")]
	public static sbyte lur;

	[Token(Token = "0x400113F")]
	public static sbyte lus;

	[Token(Token = "0x4001140")]
	public static sbyte lut;

	[Token(Token = "0x4001141")]
	public static sbyte luu;

	[Token(Token = "0x4001142")]
	public static sbyte luv;

	[Token(Token = "0x4001143")]
	public static sbyte luw;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001144")]
	public int lux;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4001145")]
	public int luy;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001146")]
	public int luz;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001147")]
	public int lva;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001148")]
	public int lvb;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001149")]
	public int lvc;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400114A")]
	public short lvd;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400114B")]
	public string lve;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400114C")]
	public string lvf;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400114D")]
	public bool lvg;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400114E")]
	public lm lvh;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400114F")]
	public int lvi;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001150")]
	public int lvj;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001151")]
	public sbyte lvk;

	[FieldOffset(Offset = "0x59")]
	[Token(Token = "0x4001152")]
	public sbyte lvl;

	[FieldOffset(Offset = "0x5A")]
	[Token(Token = "0x4001153")]
	public sbyte lvm;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001154")]
	public short lvn;

	[FieldOffset(Offset = "0x5E")]
	[Token(Token = "0x4001155")]
	public sbyte lvo;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001156")]
	public int lvp;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4001157")]
	public bool lvq;

	[Token(Token = "0x60007F4")]
	[Address(RVA = "0x1F54C0", Offset = "0x1F44C0", VA = "0x1801F54C0")]
	public ko(sbyte classId, int level, string name, int hp, int maxHP, int mp, int maxMP, int size)
	{
		ckz(classId);
		lvi = 0;
		luz = 0;
		lva = 0;
		lvb = 0;
		luy = level;
		lvc = 0;
		lve = name;
	}

	[Token(Token = "0x60007F5")]
	[Address(RVA = "0x1F52B0", Offset = "0x1F42B0", VA = "0x1801F52B0")]
	public ko(sbyte classId, int level, string name, int hp, int maxHP, int mp, int maxMP, int size, sbyte gender, short hair)
	{
		ckz(classId);
		lvi = 0;
		luz = 0;
		lva = 0;
		lvb = 0;
		lvc = 0;
		lvp = 0;
		luy = level;
		lvo = 0;
		lve = name;
	}

	[Token(Token = "0x60007F6")]
	[Address(RVA = "0x1F5540", Offset = "0x1F4540", VA = "0x1801F5540")]
	private void ckz(sbyte classId)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007F7")]
	[Address(RVA = "0x1F5340", Offset = "0x1F4340", VA = "0x1801F5340")]
	public ko(int charId, sbyte classId, string name, short zoneID, sbyte hair, sbyte gender, bool isLock)
	{
		lvg = false;
		lux = charId;
		ckz(classId);
		lvn = 0;
		lvo = 0;
		lvp = 0;
		lve = name;
		int num = 0;
		lm lm2 = lm.cua();
		if (charId != (lm.mlw ? 1 : 0))
		{
			lm lm3 = mo.djf(charId);
		}
		int num2 = 0;
		lm lm4 = (lvh = lm.cua());
		if (lm4 != null)
		{
			int num3 = lm4.cmc();
			lm lm5 = lvh;
			luz = num3;
			int mgl = lm5.mgl;
			lva = mgl;
			int mgi = lm5.mgi;
			lvb = mgi;
			int mgj = lm5.mgj;
			lvc = mgj;
			int mgh = lm5.mgh;
			luy = mgh;
		}
	}

	[Token(Token = "0x60007F8")]
	[Address(RVA = "0x1F55C0", Offset = "0x1F45C0", VA = "0x1801F55C0")]
	public static void cla()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007F9")]
	[Address(RVA = "0x1F5730", Offset = "0x1F4730", VA = "0x1801F5730")]
	public static void clb(lm cc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007FA")]
	[Address(RVA = "0x1F5830", Offset = "0x1F4830", VA = "0x1801F5830")]
	public static void clear(int charId)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60007FB")]
	[Address(RVA = "0x1F5200", Offset = "0x1F4200", VA = "0x1801F5200")]
	static ko()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
