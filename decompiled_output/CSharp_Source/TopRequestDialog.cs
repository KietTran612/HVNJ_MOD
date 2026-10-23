using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000A8")]
public class TopRequestDialog
{
	[Token(Token = "0x20000A9")]
	private class gm : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000756")]
		private TopRequestDialog ibx;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000757")]
		private sbyte iby;

		[Token(Token = "0x60004EB")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gm(TopRequestDialog me, sbyte index)
		{
			ibx = me;
			iby = index;
		}

		[Token(Token = "0x60004EC")]
		[Address(RVA = "0x278FD0", Offset = "0x277FD0", VA = "0x180278FD0", Slot = "4")]
		public void th()
		{
			TopRequestDialog topRequestDialog = ibx;
			sbyte index = iby;
			topRequestDialog.brx(index);
		}
	}

	[Token(Token = "0x4000746")]
	public static TopRequestDialog ibz;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000747")]
	private int ica = 175;

	[FieldOffset(Offset = "0x14")]
	[Token(Token = "0x4000748")]
	private int icb = 50;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000749")]
	private int icc = 50;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x400074A")]
	private int icd = 20;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x400074B")]
	private int ice;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400074C")]
	private string icf;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400074D")]
	private GameObject icg;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400074E")]
	private RectTransform ich;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400074F")]
	private int ici;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4000750")]
	private int icj;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000751")]
	private int ick;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4000752")]
	private bool icl;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000753")]
	private iw icm;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000754")]
	private hm icn;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000755")]
	private int ico;

	[Token(Token = "0x60004E4")]
	[Address(RVA = "0x878E30", Offset = "0x877E30", VA = "0x180878E30")]
	public static TopRequestDialog brv()
	{
		//IL_001d: Expected I4, but got I8
		//IL_0027: Expected I4, but got I8
		//IL_0031: Expected I4, but got I8
		//IL_003b: Expected I4, but got I8
		TopRequestDialog topRequestDialog = ibz;
		if (topRequestDialog == null)
		{
			TopRequestDialog topRequestDialog2 = new TopRequestDialog();
			topRequestDialog2.ica = 175;
			topRequestDialog2.icb = 50;
			topRequestDialog2.icc = 50;
			topRequestDialog2.icd = 20;
			ibz = topRequestDialog2;
		}
		return topRequestDialog;
	}

	[Token(Token = "0x60004E5")]
	[Address(RVA = "0x878EC0", Offset = "0x877EC0", VA = "0x180878EC0")]
	public void brw(string text, iw cmd)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected I4, but got Unknown
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected I4, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected I4, but got Unknown
		//IL_004c: Expected I4, but got I8
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected I4, but got Unknown
		int jtj = hw.jtj;
		jtj -= text;
		int num = icb;
		num -= text;
		ici = (ick = num - jtj);
		int jtj2 = hw.jtj;
		icf = text;
		jtj2 -= text;
		icm = cmd;
		ico = 500;
		int num2 = icb;
		num2 -= text;
		num2 -= jtj2;
		icj = num2;
		init();
		icl = true;
		hw.juo = ibz;
	}

	[Token(Token = "0x60004E6")]
	[Address(RVA = "0x879280", Offset = "0x878280", VA = "0x180879280")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004E7")]
	[Address(RVA = "0x878FD0", Offset = "0x877FD0", VA = "0x180878FD0")]
	public void brx(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004E8")]
	[Address(RVA = "0x879000", Offset = "0x878000", VA = "0x180879000")]
	public void bry()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004E9")]
	[Address(RVA = "0x8791F0", Offset = "0x8781F0", VA = "0x1808791F0")]
	public void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60004EA")]
	[Address(RVA = "0x878E00", Offset = "0x877E00", VA = "0x180878E00")]
	public TopRequestDialog()
	{
		//IL_000d: Expected I4, but got I8
		//IL_0017: Expected I4, but got I8
		//IL_0021: Expected I4, but got I8
		//IL_002b: Expected I4, but got I8
	}
}
