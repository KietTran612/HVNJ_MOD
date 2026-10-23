using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000119")]
public class SkillEffBoss : he
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001189")]
	private Vector2 lxo;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x400118A")]
	private int lxp;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x400118B")]
	private int lxq;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400118C")]
	private int lxr;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400118D")]
	private lm lxs;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400118E")]
	private GameObject lxt;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400118F")]
	private int lxu;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001190")]
	private sbyte lxv;

	[FieldOffset(Offset = "0x3D")]
	[Token(Token = "0x4001191")]
	private sbyte lxw;

	[FieldOffset(Offset = "0x3E")]
	[Token(Token = "0x4001192")]
	private bool lxx;

	[Token(Token = "0x6000807")]
	[Address(RVA = "0x48B580", Offset = "0x48A580", VA = "0x18048B580")]
	public SkillEffBoss(int x, int y, int dir, int time, sbyte skill, int idBoss, int dame, int dameMp, lm c)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000808")]
	[Address(RVA = "0x48B650", Offset = "0x48A650", VA = "0x18048B650", Slot = "4")]
	public override void buz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000809")]
	[Address(RVA = "0x48B970", Offset = "0x48A970", VA = "0x18048B970", Slot = "6")]
	public override void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
