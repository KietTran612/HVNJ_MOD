using System.Collections.Generic;
using Cpp2IlInjected;

[Token(Token = "0x20000E3")]
public class iq
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000D08")]
	public int kfc;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000D09")]
	public string kfd;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000D0A")]
	public List<string> kfe = (List<string>)(object)new List<T>();

	[Token(Token = "0x6000710")]
	[Address(RVA = "0x4E37D0", Offset = "0x4E27D0", VA = "0x1804E37D0")]
	public iq(string ownerName, int type)
	{
		kfd = ownerName;
		kfc = type;
	}

	[Token(Token = "0x6000711")]
	[Address(RVA = "0x4E3860", Offset = "0x4E2860", VA = "0x1804E3860")]
	public iq()
	{
	}

	[Token(Token = "0x6000712")]
	[Address(RVA = "0x4E38D0", Offset = "0x4E28D0", VA = "0x1804E38D0")]
	public void cfz(string whoChat, string text)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000713")]
	[Address(RVA = "0x4E3F00", Offset = "0x4E2F00", VA = "0x1804E3F00")]
	private void clear()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000714")]
	[Address(RVA = "0x4E3C60", Offset = "0x4E2C60", VA = "0x1804E3C60")]
	public void cga(string text)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
