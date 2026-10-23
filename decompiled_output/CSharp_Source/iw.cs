using Cpp2IlInjected;

[Token(Token = "0x20000E9")]
public class iw
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000EAD")]
	public string kvh;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000EAE")]
	public sbyte kvi = -1;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000EAF")]
	public k kvj;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000EB0")]
	public fi kvk;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000EB1")]
	public ng kvl;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000EB2")]
	public int kvm;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4000EB3")]
	public int kvn;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000EB4")]
	public lh kvo;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000EB5")]
	public i kvp;

	[Token(Token = "0x600071D")]
	[Address(RVA = "0x4E5E70", Offset = "0x4E4E70", VA = "0x1804E5E70")]
	public iw()
	{
		//IL_000d: Expected I4, but got I8
	}

	[Token(Token = "0x600071E")]
	[Address(RVA = "0x4E5D30", Offset = "0x4E4D30", VA = "0x1804E5D30")]
	public iw(string caption, k actionL, int action, lh p)
	{
		//IL_000d: Expected I4, but got I8
		//IL_0028: Expected Obj, but got I4
		kvh = caption;
		kvj = actionL;
		kvo = (lh)0;
		kvm = action;
	}

	[Token(Token = "0x600071F")]
	[Address(RVA = "0x4E5DE0", Offset = "0x4E4DE0", VA = "0x1804E5DE0")]
	public iw(string caption, k actionL, int action)
	{
		//IL_000d: Expected I4, but got I8
		kvh = caption;
		kvm = action;
		kvj = actionL;
	}

	[Token(Token = "0x6000720")]
	[Address(RVA = "0x4E5D90", Offset = "0x4E4D90", VA = "0x1804E5D90")]
	public iw(string caption, fi actionP, int action)
	{
		//IL_000d: Expected I4, but got I8
		kvh = caption;
		kvm = action;
		kvk = actionP;
	}

	[Token(Token = "0x6000721")]
	[Address(RVA = "0x4E5F10", Offset = "0x4E4F10", VA = "0x1804E5F10")]
	public iw(string caption, ng actionS, int action, int indexAc)
	{
		//IL_000d: Expected I4, but got I8
		kvh = caption;
		kvl = actionS;
		kvn = 0;
		kvm = action;
	}

	[Token(Token = "0x6000722")]
	[Address(RVA = "0x4E5EC0", Offset = "0x4E4EC0", VA = "0x1804E5EC0")]
	public iw(string caption, int action, lh p)
	{
		//IL_000d: Expected I4, but got I8
		kvh = caption;
		kvm = action;
		kvo = p;
	}

	[Token(Token = "0x6000723")]
	[Address(RVA = "0x4E5E80", Offset = "0x4E4E80", VA = "0x1804E5E80")]
	public iw(string caption, int action)
	{
		//IL_000d: Expected I4, but got I8
		kvh = caption;
		kvm = action;
	}

	[Token(Token = "0x6000724")]
	[Address(RVA = "0x4E5E30", Offset = "0x4E4E30", VA = "0x1804E5E30")]
	public iw(string caption, i action)
	{
		//IL_000d: Expected I4, but got I8
		kvh = caption;
		kvp = action;
	}

	[Token(Token = "0x6000725")]
	[Address(RVA = "0x4E5F70", Offset = "0x4E4F70", VA = "0x1804E5F70")]
	public void cgd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
