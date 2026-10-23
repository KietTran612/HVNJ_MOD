using Cpp2IlInjected;

[Token(Token = "0x2000021")]
public class bc
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40000E6")]
	public sbyte frd;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40000E7")]
	private q fre;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40000E8")]
	private bl frf;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40000E9")]
	public bool frg;

	[Token(Token = "0x6000122")]
	[Address(RVA = "0x439010", Offset = "0x438010", VA = "0x180439010")]
	public bc(int command)
	{
		zi();
		frd = (sbyte)command;
		bl bl2 = new bl();
		frf = bl2;
	}

	[Token(Token = "0x6000123")]
	[Address(RVA = "0x4390F0", Offset = "0x4380F0", VA = "0x1804390F0")]
	public bc()
	{
		zi();
		bl bl2 = new bl();
		frf = bl2;
	}

	[Token(Token = "0x6000124")]
	[Address(RVA = "0x439150", Offset = "0x438150", VA = "0x180439150")]
	public bc(sbyte command)
	{
		zi();
		frd = command;
		bl bl2 = new bl();
		frf = bl2;
	}

	[Token(Token = "0x6000125")]
	[Address(RVA = "0x439070", Offset = "0x438070", VA = "0x180439070")]
	public bc(sbyte command, sbyte[] data)
	{
		zi();
		frd = command;
		q q2 = new q(data);
		fre = q2;
	}

	[Token(Token = "0x6000126")]
	[Address(RVA = "0x4391C0", Offset = "0x4381C0", VA = "0x1804391C0")]
	public sbyte[] ze()
	{
		return frf.bbk();
	}

	[Token(Token = "0x6000127")]
	[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080")]
	public q zf()
	{
		return fre;
	}

	[Token(Token = "0x6000128")]
	[Address(RVA = "0x27CB90", Offset = "0x27BB90", VA = "0x18027CB90")]
	public bl zg()
	{
		return frf;
	}

	[Token(Token = "0x6000129")]
	[Address(RVA = "0x4391E0", Offset = "0x4381E0", VA = "0x1804391E0")]
	public int zh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600012A")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void zi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
