using Cpp2IlInjected;

[Token(Token = "0x20000D7")]
public class ic
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000C83")]
	public int jzy;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4000C84")]
	public int jzz;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000C85")]
	public int kaa;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000C86")]
	public int kab;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000C87")]
	public int kac;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4000C88")]
	public int kad;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000C89")]
	public float kae;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000C8A")]
	public float kaf;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000C8B")]
	public float kag;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000C8C")]
	public float kah;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000C8D")]
	public lm kai;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000C8E")]
	public int[] kaj;

	[Token(Token = "0x60006D9")]
	[Address(RVA = "0x36A190", Offset = "0x369190", VA = "0x18036A190")]
	public void cev()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006DA")]
	[Address(RVA = "0x36A590", Offset = "0x369590", VA = "0x18036A590")]
	private void cew()
	{
		//IL_0029: Expected F4, but got I4
		//IL_0030: Expected F4, but got I4
		kai.cxu();
		lm lm2 = kai;
		int num = (kaa = (kac = 0));
		kag = num;
		kae = num;
		lm2.cvl();
		lm lm3 = kai;
		if (lm3.mhv)
		{
			lm3.saveLoadPreviousSkill();
		}
	}

	[Token(Token = "0x60006DB")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void cex()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60006DC")]
	[Address(RVA = "0x36A140", Offset = "0x369140", VA = "0x18036A140")]
	public ic()
	{
		int[] array = new int[3];
		kaj = array;
		cex();
	}
}
