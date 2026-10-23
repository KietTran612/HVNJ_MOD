using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200007D")]
public class ez : fi
{
	[Token(Token = "0x200007E")]
	private class ex : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000503")]
		private ez hfb;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000504")]
		private string hfc;

		[Token(Token = "0x60003AE")]
		[Address(RVA = "0x277B30", Offset = "0x276B30", VA = "0x180277B30")]
		public ex(ez me, string ownerName)
		{
			hfb = me;
			hfc = ownerName;
		}

		[Token(Token = "0x60003AF")]
		[Address(RVA = "0x278890", Offset = "0x277890", VA = "0x180278890", Slot = "4")]
		public void th()
		{
			ez ez2 = hfb;
			string ownerName = hfc;
			ez2.blw(ownerName);
		}
	}

	[Token(Token = "0x200007F")]
	private class ey : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000505")]
		private ez hfd;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000506")]
		private int hfe;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000507")]
		private int hff;

		[Token(Token = "0x60003B0")]
		[Address(RVA = "0x278810", Offset = "0x277810", VA = "0x180278810")]
		public ey(ez me, int t, int index)
		{
			hfd = me;
			hfe = index;
			hff = t;
		}

		[Token(Token = "0x60003B1")]
		[Address(RVA = "0x2788C0", Offset = "0x2778C0", VA = "0x1802788C0", Slot = "4")]
		public void th()
		{
			ez ez2 = hfd;
			int index = hfe;
			int type = hff;
			ez2.clickTab(type, index);
		}
	}

	[Token(Token = "0x40004F3")]
	private static ez hfg;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40004F4")]
	private GameObject hfh;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40004F5")]
	private int hfi = 200;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x40004F6")]
	private int hfj;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40004F7")]
	private int hfk;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x40004F8")]
	private int hfl = 60;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40004F9")]
	private int hfm = 20;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x40004FA")]
	private int hfn;

	[Token(Token = "0x40004FB")]
	public static short hfo;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40004FC")]
	private ip hfp;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40004FD")]
	private ScrollRect hfq;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40004FE")]
	private ScrollRect hfr;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40004FF")]
	private u hfs;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000500")]
	private GameObject hft;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000501")]
	private Image[] hfu;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000502")]
	private hm[] hfv;

	[Token(Token = "0x60003A1")]
	[Address(RVA = "0x6160E0", Offset = "0x6150E0", VA = "0x1806160E0")]
	public static ez blu()
	{
		//IL_0013: Expected I4, but got I8
		//IL_001d: Expected I4, but got I8
		//IL_0027: Expected I4, but got I8
		ez ez2 = new ez();
		ez2.hfi = 200;
		ez2.hfl = 60;
		ez2.hfm = 20;
		hfg = ez2;
		return ez2;
	}

	[Token(Token = "0x60003A2")]
	[Address(RVA = "0x615F50", Offset = "0x614F50", VA = "0x180615F50")]
	public ez()
	{
		//IL_000d: Expected I4, but got I8
		//IL_0017: Expected I4, but got I8
		//IL_0021: Expected I4, but got I8
	}

	[Token(Token = "0x60003A3")]
	[Address(RVA = "0x6178E0", Offset = "0x6168E0", VA = "0x1806178E0")]
	public void init(ip man)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003A4")]
	[Address(RVA = "0x616210", Offset = "0x615210", VA = "0x180616210")]
	private void blv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003A5")]
	[Address(RVA = "0x616AE0", Offset = "0x615AE0", VA = "0x180616AE0")]
	private void blw(string ownerName)
	{
		//IL_0022: Expected VT, but got Obj
		iq iq2 = hfp.cfq(ownerName);
		if (iq2 != null)
		{
			bool flag = ((List<T>)(object)hfp.kes).Remove((T)iq2);
			blv();
		}
	}

	[Token(Token = "0x60003A6")]
	[Address(RVA = "0x615FC0", Offset = "0x614FC0", VA = "0x180615FC0", Slot = "6")]
	public override void bcd()
	{
		u u2 = hfs;
		if (u2 != null && u2.xz())
		{
			hfs.xy();
		}
	}

	[Token(Token = "0x60003A7")]
	[Address(RVA = "0x616010", Offset = "0x615010", VA = "0x180616010", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003A8")]
	[Address(RVA = "0x6174C0", Offset = "0x6164C0", VA = "0x1806174C0")]
	private void clickTab(int type, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003A9")]
	[Address(RVA = "0x617230", Offset = "0x616230", VA = "0x180617230")]
	private void chat()
	{
		if (!string.Equals(hfs.fpr, ""))
		{
			iq iq2 = hfp.cft();
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
			string fpr = hfs.fpr;
			mo2.cah(fpr, to);
			hfs.yd("");
		}
	}

	[Token(Token = "0x60003AA")]
	[Address(RVA = "0x616B70", Offset = "0x615B70", VA = "0x180616B70")]
	public void blx(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003AB")]
	[Address(RVA = "0x6160D0", Offset = "0x6150D0", VA = "0x1806160D0", Slot = "5")]
	public override void bcj(int keyCode)
	{
		if (keyCode == -5)
		{
			chat();
		}
	}

	[Token(Token = "0x60003AC")]
	[Address(RVA = "0x617870", Offset = "0x616870", VA = "0x180617870", Slot = "9")]
	public override void close()
	{
		//IL_000f: Expected Obj, but got I8
		base.close();
		hfs = (u)0;
		Object.Destroy(hlf);
	}

	[Token(Token = "0x60003AD")]
	[Address(RVA = "0x615F10", Offset = "0x614F10", VA = "0x180615F10")]
	static ez()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
