using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200015B")]
public class YesNoDialog : lu
{
	[Token(Token = "0x200015C")]
	private class nf : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001756")]
		private YesNoDialog ocb;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001757")]
		private int occ;

		[Token(Token = "0x6000BEE")]
		[Address(RVA = "0x277DC0", Offset = "0x276DC0", VA = "0x180277DC0")]
		public nf(YesNoDialog m, int t)
		{
			ocb = m;
			occ = t;
		}

		[Token(Token = "0x6000BEF")]
		[Address(RVA = "0x27AB30", Offset = "0x279B30", VA = "0x18027AB30", Slot = "4")]
		public void th()
		{
			YesNoDialog yesNoDialog = ocb;
			int type = occ;
			yesNoDialog.dno(type);
		}
	}

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400173C")]
	public string[] ocd;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400173D")]
	private string oce;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400173E")]
	public bool ocf;

	[FieldOffset(Offset = "0x39")]
	[Token(Token = "0x400173F")]
	public bool ocg;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001740")]
	public int och;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001741")]
	public int oci;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001742")]
	public long ocj;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001743")]
	private int ock;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001744")]
	private int ocl;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001745")]
	private int ocm;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001746")]
	private int ocn;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001747")]
	private int oco;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001748")]
	private GameObject ocp;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001749")]
	private int ocq;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x400174A")]
	private int ocr;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400174B")]
	private int ocs;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x400174C")]
	private int oct;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400174D")]
	private int ocu;

	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x400174E")]
	private int ocv;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400174F")]
	private hm ocw;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001750")]
	private hm ocx;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001751")]
	private hm ocy;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4001752")]
	private hm ocz;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4001753")]
	private RectTransform oda;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001754")]
	private RectTransform odb;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4001755")]
	private RectTransform odc;

	[Token(Token = "0x6000BE6")]
	[Address(RVA = "0x436830", Offset = "0x435830", VA = "0x180436830")]
	public YesNoDialog()
	{
		//IL_0013: Expected I4, but got I8
		//IL_001d: Expected I4, but got I8
		//IL_0027: Expected I4, but got I8
		//IL_0031: Expected I4, but got I8
		ock = 220;
		ocm = 120;
		ocn = 60;
		oco = 22;
	}

	[Token(Token = "0x6000BE7")]
	[Address(RVA = "0x436C30", Offset = "0x435C30", VA = "0x180436C30")]
	public void dnm()
	{
		//IL_0016: Expected Obj, but got I4
		//IL_0016: Expected Obj, but got I4
		//IL_0016: Expected Obj, but got I4
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		string imb = hd.imb;
		dnn(imb, (iw)num3, (iw)num2, (iw)num);
	}

	[Token(Token = "0x6000BE8")]
	[Address(RVA = "0x436AF0", Offset = "0x435AF0", VA = "0x180436AF0", Slot = "7")]
	public override void bnk()
	{
		hw.juk = this;
	}

	[Token(Token = "0x6000BE9")]
	[Address(RVA = "0x436CB0", Offset = "0x435CB0", VA = "0x180436CB0")]
	public void dnn(string info, iw left, iw center, iw right)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BEA")]
	[Address(RVA = "0x436FD0", Offset = "0x435FD0", VA = "0x180436FD0")]
	private void initUI()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BEB")]
	[Address(RVA = "0x436F70", Offset = "0x435F70", VA = "0x180436F70")]
	private void dno(int type)
	{
		close();
		if (type == 0 || type == 0 || type == 1)
		{
			mvr.cgd();
		}
	}

	[Token(Token = "0x6000BEC")]
	[Address(RVA = "0x436870", Offset = "0x435870", VA = "0x180436870", Slot = "6")]
	public override void bnj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BED")]
	[Address(RVA = "0x436B60", Offset = "0x435B60", VA = "0x180436B60", Slot = "9")]
	public override void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
