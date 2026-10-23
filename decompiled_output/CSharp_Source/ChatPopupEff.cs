using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000BC")]
public class ChatPopupEff : he
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000AB2")]
	public int jjq = 100;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4000AB3")]
	public int jjr;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000AB4")]
	public int jjs;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000AB5")]
	public string jjt;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000AB6")]
	private float jju;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000AB7")]
	private float jjv;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000AB8")]
	private float jjw;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000AB9")]
	public lm jjx;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000ABA")]
	public mt jjy;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000ABB")]
	private bool jjz;

	[FieldOffset(Offset = "0x49")]
	[Token(Token = "0x4000ABC")]
	private sbyte jka;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000ABD")]
	private GameObject jkb;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000ABE")]
	private RectTransform jkc;

	[Token(Token = "0x6000576")]
	[Address(RVA = "0x60CB40", Offset = "0x60BB40", VA = "0x18060CB40")]
	public static void buv(string chat, int howLong, lm c, kk npc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000577")]
	[Address(RVA = "0x60CD80", Offset = "0x60BD80", VA = "0x18060CD80")]
	public static ChatPopupEff buw(string chat, int howLong, lm c)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000578")]
	[Address(RVA = "0x60CF30", Offset = "0x60BF30", VA = "0x18060CF30")]
	public static ChatPopupEff bux(string chat, int howLong, mt mon)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000579")]
	[Address(RVA = "0x60D110", Offset = "0x60C110", VA = "0x18060D110", Slot = "4")]
	public override void buz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600057A")]
	[Address(RVA = "0x60D2E0", Offset = "0x60C2E0", VA = "0x18060D2E0", Slot = "5")]
	public override void bva()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600057B")]
	[Address(RVA = "0x60D810", Offset = "0x60C810", VA = "0x18060D810", Slot = "6")]
	public override void close()
	{
		Object.Destroy(jkb);
	}

	[Token(Token = "0x600057C")]
	[Address(RVA = "0x60CAE0", Offset = "0x60BAE0", VA = "0x18060CAE0")]
	public ChatPopupEff()
	{
		//IL_000a: Expected I4, but got I8
	}
}
