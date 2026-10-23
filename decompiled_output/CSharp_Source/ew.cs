using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200007A")]
public class ew
{
	[Token(Token = "0x200007B")]
	private class eu : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40004EF")]
		private ew hdx;

		[Token(Token = "0x600039D")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public eu(ew me)
		{
			hdx = me;
		}

		[Token(Token = "0x600039E")]
		[Address(RVA = "0x2787F0", Offset = "0x2777F0", VA = "0x1802787F0", Slot = "4")]
		public void th()
		{
			hdx.blo();
		}
	}

	[Token(Token = "0x200007C")]
	private class ev : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40004F0")]
		private ew hdy;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40004F1")]
		private int hdz;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40004F2")]
		private int hea;

		[Token(Token = "0x600039F")]
		[Address(RVA = "0x278810", Offset = "0x277810", VA = "0x180278810")]
		public ev(ew me, int t, int index)
		{
			hdy = me;
			hdz = index;
			hea = t;
		}

		[Token(Token = "0x60003A0")]
		[Address(RVA = "0x278860", Offset = "0x277860", VA = "0x180278860", Slot = "4")]
		public void th()
		{
			ew ew2 = hdy;
			int index = hdz;
			int type = hea;
			ew2.clickTab(type, index);
		}
	}

	[Token(Token = "0x40004D5")]
	public static ew heb;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40004D6")]
	private GameObject hec;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40004D7")]
	private Image[] hed;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40004D8")]
	private hm[] hee;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40004D9")]
	private ip hef;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40004DA")]
	private ScrollRect heg;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40004DB")]
	private int heh = 70;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x40004DC")]
	private int hei;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40004DD")]
	private int hej = 60;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x40004DE")]
	private int hek = 20;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40004DF")]
	private int hel;

	[Token(Token = "0x40004E0")]
	public static short hem;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40004E1")]
	public u hen;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40004E2")]
	private GameObject heo;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40004E3")]
	private sbyte hep = 4;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x40004E4")]
	private Vector2 heq;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x40004E5")]
	private Vector2 her;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40004E6")]
	private RectTransform hes;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40004E7")]
	private RectTransform het;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40004E8")]
	private RectTransform heu;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40004E9")]
	private bool hev = true;

	[FieldOffset(Offset = "0x91")]
	[Token(Token = "0x40004EA")]
	private sbyte hew;

	[FieldOffset(Offset = "0x92")]
	[Token(Token = "0x40004EB")]
	private sbyte hex = 1;

	[FieldOffset(Offset = "0x93")]
	[Token(Token = "0x40004EC")]
	private sbyte hey;

	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x40004ED")]
	private sbyte hez;

	[FieldOffset(Offset = "0x95")]
	[Token(Token = "0x40004EE")]
	private sbyte hfa;

	[Token(Token = "0x600038F")]
	[Address(RVA = "0x6135C0", Offset = "0x6125C0", VA = "0x1806135C0")]
	public static ew blm()
	{
		//IL_0010: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
		//IL_0024: Expected I4, but got I8
		//IL_002d: Expected I4, but got I8
		//IL_003d: Expected I4, but got I8
		ew ew2 = new ew();
		ew2.heh = 70;
		ew2.hej = 60;
		ew2.hek = 20;
		ew2.hep = 4;
		ew2.hev = true;
		ew2.hex = 1;
		heb = ew2;
		return ew2;
	}

	[Token(Token = "0x6000390")]
	[Address(RVA = "0x615010", Offset = "0x614010", VA = "0x180615010")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000391")]
	[Address(RVA = "0x6136C0", Offset = "0x6126C0", VA = "0x1806136C0")]
	public void bln()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000392")]
	[Address(RVA = "0x613950", Offset = "0x612950", VA = "0x180613950")]
	private void blo()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000393")]
	[Address(RVA = "0x6149C0", Offset = "0x6139C0", VA = "0x1806149C0")]
	private void clickTab(int type, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000394")]
	[Address(RVA = "0x613D90", Offset = "0x612D90", VA = "0x180613D90")]
	public void blp(int indexTab)
	{
		ip ip2 = hef;
		if (ip2 != null)
		{
			if (hev)
			{
				int kev = ip2.kev;
				blq(kev);
			}
			else
			{
				int type = 0;
				clickTab(type, indexTab);
			}
		}
	}

	[Token(Token = "0x6000395")]
	[Address(RVA = "0x614730", Offset = "0x613730", VA = "0x180614730")]
	private void chat()
	{
		hen.fot = false;
		if (!string.Equals(hen.fpr, ""))
		{
			iq iq2 = hef.cft();
			int num = 0;
			if (iq2.kfc == num)
			{
				string[] irs = hd.irs;
			}
			if (iq2.kfc == 1)
			{
				string[] irt = hd.irt;
			}
			int kfc = iq2.kfc;
			if (kfc == 2)
			{
			}
			if (kfc == 3)
			{
				string[] iru = hd.iru;
			}
			string to = default;
			if (iq2.kfc == 4)
			{
				to = hd.irv[0];
			}
			int num2 = 0;
			mo mo2 = mo.ddt();
			string fpr = hen.fpr;
			mo2.cah(fpr, to);
			hen.yd("");
		}
	}

	[Token(Token = "0x6000396")]
	[Address(RVA = "0x613DC0", Offset = "0x612DC0", VA = "0x180613DC0")]
	public void blq(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000397")]
	[Address(RVA = "0x614590", Offset = "0x613590", VA = "0x180614590")]
	public void blr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000398")]
	[Address(RVA = "0x614690", Offset = "0x613690", VA = "0x180614690")]
	public void bls(int keyCode)
	{
		if (keyCode == -5)
		{
			chat();
		}
	}

	[Token(Token = "0x6000399")]
	[Address(RVA = "0x6146A0", Offset = "0x6136A0", VA = "0x1806146A0")]
	public void blt(bool isA)
	{
		//IL_0010: Expected Obj, but got I4
		GameObject gameObject = hec;
		int num = 0;
		if (gameObject != (Object)num)
		{
			hec.SetActive(isA);
		}
	}

	[Token(Token = "0x600039A")]
	[Address(RVA = "0x614FA0", Offset = "0x613FA0", VA = "0x180614FA0")]
	public void close()
	{
		//IL_0009: Expected Obj, but got I4
		//IL_0010: Expected Obj, but got I4
		//IL_0017: Expected Obj, but got I4
		int num = 0;
		hen = (u)num;
		hed = (Image[])num;
		hee = (hm[])num;
		Object.Destroy(hec);
	}

	[Token(Token = "0x600039B")]
	[Address(RVA = "0x613590", Offset = "0x612590", VA = "0x180613590")]
	public ew()
	{
		//IL_000a: Expected I4, but got I8
		//IL_0014: Expected I4, but got I8
		//IL_001e: Expected I4, but got I8
		//IL_0027: Expected I4, but got I8
		//IL_0037: Expected I4, but got I8
	}

	[Token(Token = "0x600039C")]
	[Address(RVA = "0x613550", Offset = "0x612550", VA = "0x180613550")]
	static ew()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
