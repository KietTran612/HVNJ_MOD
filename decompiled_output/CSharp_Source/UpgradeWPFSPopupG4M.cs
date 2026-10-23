using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000B4")]
public class UpgradeWPFSPopupG4M : fi
{
	[Token(Token = "0x20000B5")]
	private class gx : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000812")]
		private UpgradeWPFSPopupG4M iie;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000813")]
		private int iif;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000814")]
		private sbyte iig;

		[Token(Token = "0x600055A")]
		[Address(RVA = "0x278B30", Offset = "0x277B30", VA = "0x180278B30")]
		public gx(UpgradeWPFSPopupG4M me, sbyte type, int index)
		{
			iie = me;
			iig = type;
			iif = index;
		}

		[Token(Token = "0x600055B")]
		[Address(RVA = "0x2791D0", Offset = "0x2781D0", VA = "0x1802791D0", Slot = "4")]
		public void th()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x20000B6")]
	private class gy : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000815")]
		private UpgradeWPFSPopupG4M iih;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000816")]
		private sbyte iii;

		[Token(Token = "0x600055C")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public gy(UpgradeWPFSPopupG4M me, sbyte t)
		{
			iih = me;
			iii = t;
		}

		[Token(Token = "0x600055D")]
		[Address(RVA = "0x279290", Offset = "0x278290", VA = "0x180279290", Slot = "4")]
		public void th()
		{
			UpgradeWPFSPopupG4M upgradeWPFSPopupG4M = iih;
			sbyte b = iii;
			upgradeWPFSPopupG4M.bug(b);
		}
	}

	[Token(Token = "0x40007E9")]
	private static UpgradeWPFSPopupG4M iij;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x40007EA")]
	public GameObject iik;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x40007EB")]
	public GameObject iil;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x40007EC")]
	public GameObject iim;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x40007ED")]
	public GameObject iin;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40007EE")]
	public GameObject iio;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40007EF")]
	public GameObject iip;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40007F0")]
	private int iiq;

	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x40007F1")]
	public int iir;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40007F2")]
	public int iis;

	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x40007F3")]
	public int iit;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x40007F4")]
	public int iiu;

	[FieldOffset(Offset = "0x9C")]
	[Token(Token = "0x40007F5")]
	public int iiv;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40007F6")]
	public int iiw;

	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x40007F7")]
	private int iix = 1;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x40007F8")]
	private int iiy = 5;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40007F9")]
	private List<jr> iiz;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x40007FA")]
	private List<jr> ija;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x40007FB")]
	private ScrollRectClick ijb;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x40007FC")]
	private ScrollRectClick ijc;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x40007FD")]
	private GameObject[] ijd;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x40007FE")]
	private jr ije;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x40007FF")]
	private jr ijf;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000800")]
	private sbyte[] ijg;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000801")]
	private int ijh;

	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x4000802")]
	private int iji;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000803")]
	private int ijj;

	[FieldOffset(Offset = "0xFC")]
	[Token(Token = "0x4000804")]
	private int ijk;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4000805")]
	private int ijl;

	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4000806")]
	private bool ijm;

	[FieldOffset(Offset = "0x105")]
	[Token(Token = "0x4000807")]
	private bool ijn;

	[FieldOffset(Offset = "0x106")]
	[Token(Token = "0x4000808")]
	private bool ijo;

	[FieldOffset(Offset = "0x107")]
	[Token(Token = "0x4000809")]
	private bool ijp;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x400080A")]
	private bool ijq;

	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x400080B")]
	private int ijr;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x400080C")]
	private int ijs;

	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x400080D")]
	private int ijt;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x400080E")]
	private int iju;

	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x400080F")]
	private int ijv;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4000810")]
	private GameObject ijw;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4000811")]
	private GameObject ijx;

	[Token(Token = "0x6000547")]
	[Address(RVA = "0x42ED70", Offset = "0x42DD70", VA = "0x18042ED70")]
	public static UpgradeWPFSPopupG4M btz()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000548")]
	[Address(RVA = "0x433880", Offset = "0x432880", VA = "0x180433880")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000549")]
	[Address(RVA = "0x42EEA0", Offset = "0x42DEA0", VA = "0x18042EEA0")]
	public void bua()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600054A")]
	[Address(RVA = "0x42EF10", Offset = "0x42DF10", VA = "0x18042EF10")]
	public void bub()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600054B")]
	[Address(RVA = "0x42FDF0", Offset = "0x42EDF0", VA = "0x18042FDF0")]
	public void buc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600054C")]
	[Address(RVA = "0x4311D0", Offset = "0x4301D0", VA = "0x1804311D0")]
	public void bud(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600054D")]
	[Address(RVA = "0x431780", Offset = "0x430780", VA = "0x180431780")]
	public void bue(int index)
	{
		GameObject gameObject = iim;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
		GameObject gameObject2 = hlj;
		int active2 = 0;
		gameObject2.SetActive((byte)active2 != 0);
		int num = 0;
		jr jr2 = lm.cua().miv[index];
		if (jr2 != null)
		{
			if (jr2.lfe == 9)
			{
				hw.cdt("Vũ khí thời trang đã đạt cấp tối đa.");
				return;
			}
			ije = jr2;
			jr2.lfp = index;
		}
		bum();
		buc();
	}

	[Token(Token = "0x600054E")]
	[Address(RVA = "0x4318C0", Offset = "0x4308C0", VA = "0x1804318C0")]
	public void buf()
	{
		//IL_001b: Expected Obj, but got I8
		bua();
		bum();
		bub();
		ijf = (jr)0;
		buc();
	}

	[Token(Token = "0x600054F")]
	[Address(RVA = "0x431900", Offset = "0x430900", VA = "0x180431900")]
	private void bug(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000550")]
	[Address(RVA = "0x431A60", Offset = "0x430A60", VA = "0x180431A60")]
	public void buh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000551")]
	[Address(RVA = "0x4322F0", Offset = "0x4312F0", VA = "0x1804322F0")]
	public void bui()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000552")]
	[Address(RVA = "0x432D10", Offset = "0x431D10", VA = "0x180432D10")]
	private void buj(GameObject objCell, jr item, int dUpgrade, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000553")]
	[Address(RVA = "0x433150", Offset = "0x432150", VA = "0x180433150")]
	public void buk(RectTransform rect, Sprite spr, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000554")]
	[Address(RVA = "0x433230", Offset = "0x432230", VA = "0x180433230")]
	public void bul(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000555")]
	[Address(RVA = "0x4345D0", Offset = "0x4335D0", VA = "0x1804345D0")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000556")]
	[Address(RVA = "0x433330", Offset = "0x432330", VA = "0x180433330")]
	private void bum()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000557")]
	[Address(RVA = "0x42ECF0", Offset = "0x42DCF0", VA = "0x18042ECF0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000558")]
	[Address(RVA = "0x4337E0", Offset = "0x4327E0", VA = "0x1804337E0", Slot = "9")]
	public override void close()
	{
		//IL_0014: Expected Obj, but got I4
		//IL_001b: Expected Obj, but got I4
		//IL_0022: Expected Obj, but got I4
		//IL_0029: Expected Obj, but got I4
		Object.Destroy(hlf);
		int num = 0;
		ije = (jr)num;
		ijf = (jr)num;
		ija = (List<jr>)num;
		iiz = (List<jr>)num;
		bua();
		base.close();
	}

	[Token(Token = "0x6000559")]
	[Address(RVA = "0x42EC10", Offset = "0x42DC10", VA = "0x18042EC10")]
	public UpgradeWPFSPopupG4M()
	{
		//IL_0009: Expected I4, but got I8
		//IL_0012: Expected I4, but got I8
		//IL_0034: Expected I4, but got I8
		//IL_003d: Expected I4, but got I8
		//IL_004d: Expected I4, but got I8
		sbyte[] array = new sbyte[4];
		RuntimeHelpers.InitializeArray(array, __ldtoken(_003CPrivateImplementationDetails_003E.AD95131BC0B799C0B1AF477FB14FCF26A6A9F76079E48BF090ACB7E8367BFD0E));
		ijg = array;
		ijr = -1;
		ijt = -1;
		ijv = -1;
		base._002Ector();
	}
}
