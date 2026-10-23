using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000039")]
public class cj : fi
{
	[Token(Token = "0x200003A")]
	private class cb : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000219")]
		private cj fxu;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400021A")]
		private sbyte fxv;

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public cb(cj me, sbyte index)
		{
			fxu = me;
			fxv = index;
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0x2778A0", Offset = "0x2768A0", VA = "0x1802778A0", Slot = "4")]
		public void th()
		{
			cj cj2 = fxu;
			sbyte index = fxv;
			cj2.bcp(index);
		}
	}

	[Token(Token = "0x200003B")]
	private class cc : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400021B")]
		private cj fxw;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400021C")]
		private short fxx;

		[FieldOffset(Offset = "0x1A")]
		[Token(Token = "0x400021D")]
		private short fxy;

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0x2778D0", Offset = "0x2768D0", VA = "0x1802778D0")]
		public cc(cj me, short indexSkill, short indexPos)
		{
			fxw = me;
			fxx = indexSkill;
			fxy = indexPos;
		}

		[Token(Token = "0x60001F3")]
		[Address(RVA = "0x277920", Offset = "0x276920", VA = "0x180277920", Slot = "4")]
		public void th()
		{
			cj cj2 = fxw;
			short indexPos = fxy;
			short indexSkill = fxx;
			cj2.bcy(indexSkill, indexPos);
		}
	}

	[Token(Token = "0x200003C")]
	private class cd : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400021E")]
		private cj fxz;

		[Token(Token = "0x60001F4")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public cd(cj me)
		{
			fxz = me;
		}

		[Token(Token = "0x60001F5")]
		[Address(RVA = "0x277950", Offset = "0x276950", VA = "0x180277950", Slot = "4")]
		public void th()
		{
			fxz.bde();
		}
	}

	[Token(Token = "0x200003D")]
	private class ce : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400021F")]
		private cj fya;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000220")]
		private int fyb;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000221")]
		private float fyc;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000222")]
		private float fyd;

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0x277970", Offset = "0x276970", VA = "0x180277970")]
		public ce(cj me, int index, float x, float y)
		{
			//IL_001b: Expected F4, but got I4
			fyc = x;
			fya = me;
			fyd = 0f;
			fyb = index;
		}

		[Token(Token = "0x60001F7")]
		[Address(RVA = "0x2779D0", Offset = "0x2769D0", VA = "0x1802779D0", Slot = "4")]
		public void th()
		{
			cj cj2 = fya;
			float y = fyd;
			float x = fyc;
			int index = fyb;
			cj2.bdj(index, x, y);
		}
	}

	[Token(Token = "0x200003E")]
	private class cf : i
	{
		[Token(Token = "0x4000223")]
		public const sbyte fye = 0;

		[Token(Token = "0x4000224")]
		public const sbyte fyf = 1;

		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000225")]
		private cj fyg;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000226")]
		private int fyh;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000227")]
		private int fyi;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000228")]
		private sbyte fyj;

		[Token(Token = "0x60001F8")]
		[Address(RVA = "0x277A10", Offset = "0x276A10", VA = "0x180277A10")]
		public cf(cj me, int t, int indexTab, sbyte typeCmd)
		{
			fyg = me;
			fyi = indexTab;
			fyj = 0;
			fyh = t;
		}

		[Token(Token = "0x60001F9")]
		[Address(RVA = "0x277A60", Offset = "0x276A60", VA = "0x180277A60", Slot = "4")]
		public void th()
		{
			//IL_0021: Expected Obj, but got I4
			fyg.gdm = false;
			GameObject gde = fyg.gde;
			int num = 0;
			if (gde != (UnityEngine.Object)num)
			{
				GameObject gde2 = fyg.gde;
				int active = 0;
				gde2.SetActive((byte)active != 0);
			}
			cj cj2 = fyg;
			sbyte typeCmd = fyj;
			int indexTab = fyi;
			cj2.bdt(indexTab, typeCmd);
		}
	}

	[Token(Token = "0x200003F")]
	private class cg : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000229")]
		public cj fyk;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400022A")]
		private jr fyl;

		[Token(Token = "0x60001FA")]
		[Address(RVA = "0x277B30", Offset = "0x276B30", VA = "0x180277B30")]
		public cg(cj me, jr item)
		{
			fyk = me;
			fyl = item;
		}

		[Token(Token = "0x60001FB")]
		[Address(RVA = "0x277B70", Offset = "0x276B70", VA = "0x180277B70", Slot = "4")]
		public void th()
		{
			string fpr = hw.jun.mwz.fpr;
			if (fpr.m_stringLength != 0)
			{
				int num = int.Parse(fpr);
				if (num <= 10000)
				{
					jr item = fyl;
					fyk.bea(item, num);
				}
				else
				{
					hw.cdt("Không được vượt quá 10.000");
				}
			}
		}
	}

	[Token(Token = "0x2000040")]
	private class ci : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400022B")]
		public cj fym;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400022C")]
		private jr fyn;

		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x400022D")]
		private int fyo;

		[Token(Token = "0x60001FC")]
		[Address(RVA = "0x277CC0", Offset = "0x276CC0", VA = "0x180277CC0")]
		public ci(cj me, jr item, int number)
		{
			fym = me;
			fyn = item;
			fyo = number;
		}

		[Token(Token = "0x60001FD")]
		[Address(RVA = "0x277D10", Offset = "0x276D10", VA = "0x180277D10", Slot = "4")]
		public void th()
		{
			if (fyo > 0)
			{
				jr jr2 = fyn;
				int num = 0;
				lj lj2 = lj.cmy();
				jr jr3 = fyn;
				int number = fyo;
				int ley = jr3.ley;
				lj2.cps(ley, number);
			}
			else
			{
				hw.cdt("Nhập đúng số lượng.");
			}
		}
	}

	[Token(Token = "0x4000193")]
	private static cj fyp;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000194")]
	public float fyq;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000195")]
	public float fyr;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000196")]
	public float fys;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000197")]
	public float fyt;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000198")]
	public float fyu = 30f;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000199")]
	public float fyv;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400019A")]
	public float fyw;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x400019B")]
	public float fyx;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400019C")]
	public float fyy;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400019D")]
	private ScrollRectClick fyz;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400019E")]
	public int fza;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400019F")]
	private GameObject fzb;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x40001A0")]
	private GameObject fzc;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40001A1")]
	public float fzd;

	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x40001A2")]
	public float fze;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x40001A3")]
	public float fzf;

	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x40001A4")]
	public float fzg;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40001A5")]
	public float fzh;

	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x40001A6")]
	public sbyte fzi;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x40001A7")]
	private hm fzj;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x40001A8")]
	private hm fzk;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x40001A9")]
	public int fzl;

	[FieldOffset(Offset = "0xCC")]
	[Token(Token = "0x40001AA")]
	public int fzm = 5;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x40001AB")]
	private Image fzn;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x40001AC")]
	private RectTransform fzo;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x40001AD")]
	private hm fzp;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x40001AE")]
	private bool fzq;

	[FieldOffset(Offset = "0xE9")]
	[Token(Token = "0x40001AF")]
	private bool fzr;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x40001B0")]
	private GameObject fzs;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x40001B1")]
	private GameObject[] fzt;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40001B2")]
	private GameObject[] fzu;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40001B3")]
	private GameObject fzv;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40001B4")]
	private float fzw;

	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x40001B5")]
	private float fzx;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40001B6")]
	private float fzy;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40001B7")]
	private ScrollRect fzz;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40001B8")]
	private RectTransform gaa;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40001B9")]
	private RectTransform gab;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40001BA")]
	private RectTransform gac;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40001BB")]
	private sbyte gad;

	[FieldOffset(Offset = "0x144")]
	[Token(Token = "0x40001BC")]
	private int gae = 60;

	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x40001BD")]
	private int gaf = 25;

	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40001BE")]
	private hm gag;

	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40001BF")]
	private hm gah;

	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x40001C0")]
	private List<lc> gai = (List<lc>)(object)new List<T>();

	[FieldOffset(Offset = "0x168")]
	[Token(Token = "0x40001C1")]
	private GameObject gaj;

	[FieldOffset(Offset = "0x170")]
	[Token(Token = "0x40001C2")]
	private GameObject gak;

	[FieldOffset(Offset = "0x178")]
	[Token(Token = "0x40001C3")]
	private hm gal;

	[FieldOffset(Offset = "0x180")]
	[Token(Token = "0x40001C4")]
	private float gam;

	[FieldOffset(Offset = "0x188")]
	[Token(Token = "0x40001C5")]
	private RectTransform gao;

	[FieldOffset(Offset = "0x190")]
	[Token(Token = "0x40001C6")]
	private RectTransform gap;

	[FieldOffset(Offset = "0x198")]
	[Token(Token = "0x40001C7")]
	private GameObject[] gaq;

	[FieldOffset(Offset = "0x1A0")]
	[Token(Token = "0x40001C8")]
	private GameObject[] gar;

	[FieldOffset(Offset = "0x1A8")]
	[Token(Token = "0x40001C9")]
	private RectTransform[] gas;

	[FieldOffset(Offset = "0x1B0")]
	[Token(Token = "0x40001CA")]
	private RectTransform[] gat;

	[FieldOffset(Offset = "0x1B8")]
	[Token(Token = "0x40001CB")]
	private GameObject gau;

	[FieldOffset(Offset = "0x1C0")]
	[Token(Token = "0x40001CC")]
	private GameObject[] gav;

	[FieldOffset(Offset = "0x1C8")]
	[Token(Token = "0x40001CD")]
	private GameObject[] gaw;

	[FieldOffset(Offset = "0x1D0")]
	[Token(Token = "0x40001CE")]
	private GameObject[] gax;

	[FieldOffset(Offset = "0x1D8")]
	[Token(Token = "0x40001CF")]
	private float gay;

	[FieldOffset(Offset = "0x1DC")]
	[Token(Token = "0x40001D0")]
	private float gaz;

	[FieldOffset(Offset = "0x1E0")]
	[Token(Token = "0x40001D1")]
	private Vector2[] gba;

	[FieldOffset(Offset = "0x1E8")]
	[Token(Token = "0x40001D2")]
	private Vector2[] gbb;

	[FieldOffset(Offset = "0x1F0")]
	[Token(Token = "0x40001D3")]
	private Vector2[] gbc;

	[FieldOffset(Offset = "0x1F8")]
	[Token(Token = "0x40001D4")]
	private Vector2[] gbd;

	[FieldOffset(Offset = "0x200")]
	[Token(Token = "0x40001D5")]
	private Vector2[] gbe;

	[FieldOffset(Offset = "0x208")]
	[Token(Token = "0x40001D6")]
	private Vector2[] gbf;

	[FieldOffset(Offset = "0x210")]
	[Token(Token = "0x40001D7")]
	private sbyte gbg;

	[FieldOffset(Offset = "0x218")]
	[Token(Token = "0x40001D8")]
	private GameObject gbh;

	[FieldOffset(Offset = "0x220")]
	[Token(Token = "0x40001D9")]
	private RectTransform gbi;

	[FieldOffset(Offset = "0x228")]
	[Token(Token = "0x40001DA")]
	private RectTransform[] gbj;

	[FieldOffset(Offset = "0x230")]
	[Token(Token = "0x40001DB")]
	private int gbk = 30;

	[FieldOffset(Offset = "0x234")]
	[Token(Token = "0x40001DC")]
	private float gbl;

	[FieldOffset(Offset = "0x238")]
	[Token(Token = "0x40001DD")]
	private float gbm;

	[FieldOffset(Offset = "0x240")]
	[Token(Token = "0x40001DE")]
	private ScrollRect gbn;

	[FieldOffset(Offset = "0x248")]
	[Token(Token = "0x40001DF")]
	private hm gbo;

	[FieldOffset(Offset = "0x250")]
	[Token(Token = "0x40001E0")]
	private hm gbp;

	[FieldOffset(Offset = "0x258")]
	[Token(Token = "0x40001E1")]
	private RectTransform gbq;

	[FieldOffset(Offset = "0x260")]
	[Token(Token = "0x40001E2")]
	private RectTransform gbr;

	[FieldOffset(Offset = "0x268")]
	[Token(Token = "0x40001E3")]
	private hm gbs;

	[FieldOffset(Offset = "0x270")]
	[Token(Token = "0x40001E4")]
	private short gbt;

	[FieldOffset(Offset = "0x278")]
	[Token(Token = "0x40001E5")]
	private List<lc> gbu = (List<lc>)(object)new List<T>();

	[FieldOffset(Offset = "0x280")]
	[Token(Token = "0x40001E6")]
	private GameObject gbv;

	[Token(Token = "0x40001E7")]
	public static bool gbw;

	[FieldOffset(Offset = "0x288")]
	[Token(Token = "0x40001E8")]
	private GameObject gbx;

	[FieldOffset(Offset = "0x290")]
	[Token(Token = "0x40001E9")]
	private lc gby;

	[FieldOffset(Offset = "0x298")]
	[Token(Token = "0x40001EA")]
	private lc gbz;

	[FieldOffset(Offset = "0x2A0")]
	[Token(Token = "0x40001EB")]
	private lc gca;

	[FieldOffset(Offset = "0x2A8")]
	[Token(Token = "0x40001EC")]
	private lc gcb;

	[FieldOffset(Offset = "0x2B0")]
	[Token(Token = "0x40001ED")]
	private Image gcc;

	[Token(Token = "0x40001EE")]
	private static Vector2[] gcd;

	[FieldOffset(Offset = "0x2B8")]
	[Token(Token = "0x40001EF")]
	private GameObject gce;

	[FieldOffset(Offset = "0x2C0")]
	[Token(Token = "0x40001F0")]
	private RectTransform gcf;

	[FieldOffset(Offset = "0x2C8")]
	[Token(Token = "0x40001F1")]
	private hm gcg;

	[FieldOffset(Offset = "0x2D0")]
	[Token(Token = "0x40001F2")]
	private hm gch;

	[FieldOffset(Offset = "0x2D8")]
	[Token(Token = "0x40001F3")]
	private hm gci;

	[FieldOffset(Offset = "0x2E0")]
	[Token(Token = "0x40001F4")]
	private Image gcj;

	[FieldOffset(Offset = "0x2E8")]
	[Token(Token = "0x40001F5")]
	private Image gck;

	[FieldOffset(Offset = "0x2F0")]
	[Token(Token = "0x40001F6")]
	private GameObject gcl;

	[FieldOffset(Offset = "0x2F8")]
	[Token(Token = "0x40001F7")]
	private GameObject gcm;

	[FieldOffset(Offset = "0x300")]
	[Token(Token = "0x40001F8")]
	private Image[] gcn;

	[FieldOffset(Offset = "0x308")]
	[Token(Token = "0x40001F9")]
	private hm gco;

	[FieldOffset(Offset = "0x310")]
	[Token(Token = "0x40001FA")]
	private hm[] gcp;

	[FieldOffset(Offset = "0x318")]
	[Token(Token = "0x40001FB")]
	private hm gcq;

	[FieldOffset(Offset = "0x320")]
	[Token(Token = "0x40001FC")]
	private Sprite[] gcr;

	[FieldOffset(Offset = "0x328")]
	[Token(Token = "0x40001FD")]
	private RectTransform gcs;

	[FieldOffset(Offset = "0x330")]
	[Token(Token = "0x40001FE")]
	private hm gct;

	[FieldOffset(Offset = "0x338")]
	[Token(Token = "0x40001FF")]
	private GameObject gcu;

	[Token(Token = "0x4000200")]
	public static bool gcv;

	[FieldOffset(Offset = "0x340")]
	[Token(Token = "0x4000201")]
	private int gcw;

	[FieldOffset(Offset = "0x344")]
	[Token(Token = "0x4000202")]
	public float gcx;

	[FieldOffset(Offset = "0x348")]
	[Token(Token = "0x4000203")]
	private GameObject gcy;

	[FieldOffset(Offset = "0x350")]
	[Token(Token = "0x4000204")]
	private RectTransform gcz;

	[FieldOffset(Offset = "0x358")]
	[Token(Token = "0x4000205")]
	private RectTransform[] gda;

	[FieldOffset(Offset = "0x360")]
	[Token(Token = "0x4000206")]
	private List<jp> gdb = (List<jp>)(object)new List<T>();

	[FieldOffset(Offset = "0x368")]
	[Token(Token = "0x4000207")]
	public float gdc;

	[FieldOffset(Offset = "0x370")]
	[Token(Token = "0x4000208")]
	public List<jo> gdd = (List<jo>)(object)new List<T>();

	[FieldOffset(Offset = "0x378")]
	[Token(Token = "0x4000209")]
	private GameObject gde;

	[FieldOffset(Offset = "0x380")]
	[Token(Token = "0x400020A")]
	private GameObject gdf;

	[FieldOffset(Offset = "0x388")]
	[Token(Token = "0x400020B")]
	private ScrollRect gdg;

	[FieldOffset(Offset = "0x390")]
	[Token(Token = "0x400020C")]
	private ScrollRect gdh;

	[FieldOffset(Offset = "0x398")]
	[Token(Token = "0x400020D")]
	private float gdi = 150f;

	[FieldOffset(Offset = "0x39C")]
	[Token(Token = "0x400020E")]
	private float gdj = 180f;

	[FieldOffset(Offset = "0x3A0")]
	[Token(Token = "0x400020F")]
	private hm gdk;

	[FieldOffset(Offset = "0x3A8")]
	[Token(Token = "0x4000210")]
	private hm gdl;

	[FieldOffset(Offset = "0x3B0")]
	[Token(Token = "0x4000211")]
	private bool gdm;

	[FieldOffset(Offset = "0x3B1")]
	[Token(Token = "0x4000212")]
	private bool gdn;

	[FieldOffset(Offset = "0x3B8")]
	[Token(Token = "0x4000213")]
	private ImageClickButton gdo;

	[FieldOffset(Offset = "0x3C0")]
	[Token(Token = "0x4000214")]
	private bool gdp;

	[FieldOffset(Offset = "0x3C8")]
	[Token(Token = "0x4000215")]
	private GameObject gdq;

	[FieldOffset(Offset = "0x3D0")]
	[Token(Token = "0x4000216")]
	private GameObject gdr;

	[FieldOffset(Offset = "0x3D8")]
	[Token(Token = "0x4000217")]
	private ImageClickButton gds;

	[FieldOffset(Offset = "0x3E0")]
	[Token(Token = "0x4000218")]
	private ImageClickButton gdt;

	[Token(Token = "0x60001B1")]
	[Address(RVA = "0x309200", Offset = "0x308200", VA = "0x180309200")]
	public static cj bci()
	{
		//IL_001a: Expected I4, but got I8
		//IL_0024: Expected I4, but got I8
		//IL_002e: Expected I4, but got I8
		//IL_0045: Expected I4, but got I8
		cj cj2 = new cj();
		cj2.fyu = 30f;
		cj2.fzm = 5;
		cj2.gae = 60;
		cj2.gaf = 25;
		List<lc> list = (List<lc>)(object)new List<T>();
		cj2.gai = list;
		cj2.gbk = 30;
		List<lc> list2 = (List<lc>)(object)new List<T>();
		cj2.gbu = list2;
		List<jp> list3 = (List<jp>)(object)new List<T>();
		cj2.gdb = list3;
		List<jo> list4 = (List<jo>)(object)new List<T>();
		cj2.gdd = list4;
		cj2.gdi = 150f;
		cj2.gdj = 180f;
		fyp = cj2;
		return cj2;
	}

	[Token(Token = "0x60001B2")]
	[Address(RVA = "0x31FE60", Offset = "0x31EE60", VA = "0x18031FE60")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001B3")]
	[Address(RVA = "0x31F150", Offset = "0x31E150", VA = "0x18031F150")]
	public void ganSkill()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001B4")]
	[Address(RVA = "0x31BAE0", Offset = "0x31AAE0", VA = "0x18031BAE0")]
	private void clickButSkill(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001B5")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001B6")]
	[Address(RVA = "0x31D880", Offset = "0x31C880", VA = "0x18031D880", Slot = "9")]
	public override void close()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0068: Expected Obj, but got I4
		//IL_0071: Expected Obj, but got I4
		//IL_0097: Expected Obj, but got I4
		//IL_009f: Expected Obj, but got I4
		GameObject gameObject = hlf;
		int num = 0;
		if (!(gameObject == (UnityEngine.Object)num))
		{
			int num2 = 0;
			mo.ddt().deq();
			if (fzq)
			{
				int num3 = 0;
				mo.ddt().ddm();
				fzq = false;
			}
			hw.jun.dbg();
			int num4 = 0;
			mo mo2 = mo.ddt();
			int num5 = 0;
			mo mo3 = mo.ddt();
			int num6 = 0;
			mo3.ode = (iw)num6;
			mo2.odd = (iw)num6;
			((List<T>)(object)gdb).Clear();
			UnityEngine.Object.Destroy(hlf);
			List<jo> list = gdd;
			hlf = (GameObject)num6;
			gcl = (GameObject)num6;
			((List<T>)(object)list).Clear();
			base.close();
		}
	}

	[Token(Token = "0x60001B7")]
	[Address(RVA = "0x309440", Offset = "0x308440", VA = "0x180309440", Slot = "5")]
	public override void bcj(int keyCode)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001B8")]
	[Address(RVA = "0x309640", Offset = "0x308640", VA = "0x180309640")]
	public void bck()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_002d: Expected Obj, but got I4
		//IL_0058: Expected Obj, but got I4
		//IL_0083: Expected Obj, but got I4
		GameObject gameObject = hlf;
		int num = 0;
		if (!(gameObject == (UnityEngine.Object)num))
		{
			GameObject gameObject2 = gde;
			gdm = false;
			int num2 = 0;
			if (gameObject2 != (UnityEngine.Object)num2)
			{
				GameObject gameObject3 = gde;
				int active = 0;
				gameObject3.SetActive((byte)active != 0);
			}
			GameObject gameObject4 = gdf;
			int num3 = 0;
			if (gameObject4 != (UnityEngine.Object)num3)
			{
				GameObject gameObject5 = gdf;
				int active2 = 0;
				gameObject5.SetActive((byte)active2 != 0);
			}
			GameObject gameObject6 = fzs;
			int num4 = 0;
			if (gameObject6 != (UnityEngine.Object)num4)
			{
				UnityEngine.Object.Destroy(fzs);
				fzb.SetActive(value: true);
				gak.SetActive(value: true);
				fzc.SetActive(value: true);
			}
		}
	}

	[Token(Token = "0x60001B9")]
	[Address(RVA = "0x309810", Offset = "0x308810", VA = "0x180309810")]
	private void bcl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001BA")]
	[Address(RVA = "0x309D00", Offset = "0x308D00", VA = "0x180309D00")]
	public void bcm()
	{
		//IL_0014: Expected Obj, but got I8
		UnityEngine.Object.Destroy(fzv);
		fzv = (GameObject)0;
		bcn();
	}

	[Token(Token = "0x60001BB")]
	[Address(RVA = "0x309D80", Offset = "0x308D80", VA = "0x180309D80")]
	public void bcn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001BC")]
	[Address(RVA = "0x30AC70", Offset = "0x309C70", VA = "0x18030AC70")]
	private void bco()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001BD")]
	[Address(RVA = "0x30AEF0", Offset = "0x309EF0", VA = "0x18030AEF0")]
	public void bcp(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001BE")]
	[Address(RVA = "0x30C330", Offset = "0x30B330", VA = "0x18030C330")]
	public void bcq()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0039: Expected Obj, but got I8
		GameObject gameObject = hlf;
		int num = 0;
		if (!(gameObject == (UnityEngine.Object)num))
		{
			bcs();
			int num2 = 0;
			UnityEngine.Object.Destroy(lm.cua().mks);
			int num3 = 0;
			lm.cua().mks = (GameObject)0;
		}
	}

	[Token(Token = "0x60001BF")]
	[Address(RVA = "0x30C430", Offset = "0x30B430", VA = "0x18030C430")]
	public void bcr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001C0")]
	[Address(RVA = "0x30C6D0", Offset = "0x30B6D0", VA = "0x18030C6D0")]
	private void bcs()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_009a: Expected F4, but got I4
		//IL_009a: Expected F4, but got I4
		//IL_00e8: Expected I4, but got I8
		GameObject gameObject = gak;
		int num = 0;
		if (gameObject != (UnityEngine.Object)num)
		{
			UnityEngine.Object.Destroy(gak);
		}
		Transform transform = hlf.transform;
		float x = fzf;
		float w = fyx;
		float h = fyy;
		Sprite lkh = ka.lkh;
		int indexAction = 0;
		(gak = ho.byl(transform, x, 5f, w, h, lkh)).name = "objTrangBi";
		Transform transform2 = gak.transform;
		int num2 = 0;
		int num3 = 0;
		Sprite lkj = ka.lkj;
		GameObject gameObject2 = ho.byo(transform2, num3, num2, lkj);
		GameObject trans = gak;
		float x2 = fyx;
		float num4 = ho.cad(ka.lks);
		float y = fyy;
		x = num4;
		float num5 = ho.caf(ka.lks);
		Sprite lks = ka.lks;
		ulong num6 = default;
		ImageClickButton imageClickButton = ho.bzd(trans, x2, y, lks, this, (short)num6, (short)indexAction);
		updateTrangBi();
	}

	[Token(Token = "0x60001C1")]
	[Address(RVA = "0x328050", Offset = "0x327050", VA = "0x180328050")]
	public void updateTrangBi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001C2")]
	[Address(RVA = "0x30C9F0", Offset = "0x30B9F0", VA = "0x18030C9F0")]
	public void bct(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001C3")]
	[Address(RVA = "0x30CAA0", Offset = "0x30BAA0", VA = "0x18030CAA0")]
	public void bcu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001C4")]
	[Address(RVA = "0x30CD90", Offset = "0x30BD90", VA = "0x18030CD90")]
	private void bcv(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001C5")]
	[Address(RVA = "0x30CF30", Offset = "0x30BF30", VA = "0x18030CF30")]
	private void bcw(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001C6")]
	[Address(RVA = "0x31DAB0", Offset = "0x31CAB0", VA = "0x18031DAB0")]
	public void createCharTrangBi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001C7")]
	[Address(RVA = "0x30D2A0", Offset = "0x30C2A0", VA = "0x18030D2A0")]
	public void bcx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001C8")]
	[Address(RVA = "0x31DFB0", Offset = "0x31CFB0", VA = "0x18031DFB0")]
	private void createKyNang()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001C9")]
	[Address(RVA = "0x30D3E0", Offset = "0x30C3E0", VA = "0x18030D3E0")]
	private void bcy(short indexSkill, short indexPos)
	{
		gbt = indexPos;
		clickButSkill(indexSkill, indexPos);
	}

	[Token(Token = "0x60001CA")]
	[Address(RVA = "0x30D400", Offset = "0x30C400", VA = "0x18030D400")]
	public void bcz(int type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001CB")]
	[Address(RVA = "0x31BF00", Offset = "0x31AF00", VA = "0x18031BF00")]
	private void clickButSkill(int index, int indexPos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001CC")]
	[Address(RVA = "0x30D710", Offset = "0x30C710", VA = "0x18030D710")]
	public float bda(Skill skill, float wRect0, float yStart)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001CD")]
	[Address(RVA = "0x30DE70", Offset = "0x30CE70", VA = "0x18030DE70")]
	public float bdb(Skill skill, float wRect0, float yStart)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001CE")]
	[Address(RVA = "0x30E360", Offset = "0x30D360", VA = "0x18030E360")]
	public void bdc()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0032: Expected Obj, but got I4
		GameObject gameObject = hlf;
		int num = 0;
		if (gameObject == (UnityEngine.Object)num)
		{
			return;
		}
		bdd();
		if (fza != 3)
		{
			GameObject gameObject2 = gbx;
			int num2 = 0;
			if (gameObject2 != (UnityEngine.Object)num2)
			{
				GameObject gameObject3 = gbx.gameObject;
				int active = 0;
				gameObject3.SetActive((byte)active != 0);
			}
		}
		bdg();
	}

	[Token(Token = "0x60001CF")]
	[Address(RVA = "0x30E450", Offset = "0x30D450", VA = "0x18030E450")]
	private void bdd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001D0")]
	[Address(RVA = "0x311E90", Offset = "0x310E90", VA = "0x180311E90")]
	private void bde()
	{
		iw cmdYes = new iw(hd.imy, this, 34);
		iw cmdNo = new iw(hd.inj, this, 26);
		hw.cec("Bạn có muốn xóa tài khoản không? Nếu đồng ý, tài khoản sẽ bị xóa vĩnh viễn ?", cmdYes, cmdNo);
	}

	[Token(Token = "0x60001D1")]
	[Address(RVA = "0x321440", Offset = "0x320440", VA = "0x180321440")]
	public void refreshItemMon()
	{
		//IL_0027: Expected Obj, but got I8
		//IL_0035: Expected Obj, but got I4
		GC.KeepAlive("refreshItemMon");
		UnityEngine.Object.Destroy(gce);
		GameObject gameObject = gde;
		int num = 0;
		gce = (GameObject)0;
		gdm = false;
		if (gameObject != (UnityEngine.Object)num)
		{
			GameObject gameObject2 = gde;
			int active = 0;
			gameObject2.SetActive((byte)active != 0);
		}
		if (fza == 5)
		{
			bdi();
		}
	}

	[Token(Token = "0x60001D2")]
	[Address(RVA = "0x311FE0", Offset = "0x310FE0", VA = "0x180311FE0")]
	public static Vector2 bdf(int id)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001D3")]
	[Address(RVA = "0x312BD0", Offset = "0x311BD0", VA = "0x180312BD0")]
	public void bdg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001D4")]
	[Address(RVA = "0x313150", Offset = "0x312150", VA = "0x180313150")]
	private void bdh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001D5")]
	[Address(RVA = "0x3137C0", Offset = "0x3127C0", VA = "0x1803137C0")]
	private void bdi()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001D6")]
	[Address(RVA = "0x315540", Offset = "0x314540", VA = "0x180315540")]
	private void bdj(int index, float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001D7")]
	[Address(RVA = "0x315980", Offset = "0x314980", VA = "0x180315980")]
	public void bdk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001D8")]
	[Address(RVA = "0x315BF0", Offset = "0x314BF0", VA = "0x180315BF0")]
	private void bdl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001D9")]
	[Address(RVA = "0x316F00", Offset = "0x315F00", VA = "0x180316F00")]
	private string bdm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001DA")]
	[Address(RVA = "0x317170", Offset = "0x316170", VA = "0x180317170")]
	public void bdn(int type, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001DB")]
	[Address(RVA = "0x317500", Offset = "0x316500", VA = "0x180317500")]
	public void bdo()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001DC")]
	[Address(RVA = "0x318220", Offset = "0x317220", VA = "0x180318220")]
	private void bdp(GameObject objCell, jr item, int dUpgrade, ImageClickButton click, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001DD")]
	[Address(RVA = "0x318660", Offset = "0x317660", VA = "0x180318660")]
	public void bdq(RectTransform rect, Sprite spr, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001DE")]
	[Address(RVA = "0x318740", Offset = "0x317740", VA = "0x180318740")]
	private GameObject bdr(GameObject objCell, jr item, int dUpgrade, float w0, float per)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001DF")]
	[Address(RVA = "0x318B30", Offset = "0x317B30", VA = "0x180318B30")]
	public void bds(int indexTab, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001E0")]
	[Address(RVA = "0x319050", Offset = "0x318050", VA = "0x180319050")]
	public void bdt(int indexTab, sbyte typeCmd)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001E1")]
	[Address(RVA = "0x3223B0", Offset = "0x3213B0", VA = "0x1803223B0")]
	public void updateItemInfo()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001E2")]
	[Address(RVA = "0x3196B0", Offset = "0x3186B0", VA = "0x1803196B0")]
	public bool bdu(jr itemInfo, jw option)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001E3")]
	[Address(RVA = "0x308540", Offset = "0x307540", VA = "0x180308540", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001E4")]
	[Address(RVA = "0x31D680", Offset = "0x31C680", VA = "0x18031D680")]
	public void clickTab(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001E5")]
	[Address(RVA = "0x321520", Offset = "0x320520", VA = "0x180321520")]
	public void setLCR(int indexMenu)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001E6")]
	[Address(RVA = "0x3074F0", Offset = "0x3064F0", VA = "0x1803074F0", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001E7")]
	[Address(RVA = "0x319770", Offset = "0x318770", VA = "0x180319770")]
	public void bdv()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001E8")]
	[Address(RVA = "0x31A670", Offset = "0x319670", VA = "0x18031A670")]
	public void bdw()
	{
		gcv = (long)"{il2cpp field on {'constant10' (constant value of type Cpp2IL.Core.Analysis.ResultModels.StaticFieldsPtr)}, offset 0x18}" == 0;
		GameObject gameObject = gcu;
		bool active = gcv;
		gameObject.SetActive(active);
		int num = 0;
		lj lj2 = lj.cmy();
		bool isAuto = gcv;
		lj2.coq(isAuto);
	}

	[Token(Token = "0x60001E9")]
	[Address(RVA = "0x31A730", Offset = "0x319730", VA = "0x18031A730")]
	private void bdx()
	{
		//IL_003d: Invalid comparison between VT and I8
		string fpr = hw.jun.mwz.fpr;
		if (!fpr.Trim().Equals(""))
		{
			int num = int.Parse(fpr);
			if (num > 0)
			{
				int num2 = 0;
				if (lm.mqq != (Vector2)(object)0)
				{
					int num3 = 0;
					lm lm2 = lm.cua();
					int num4 = 0;
					lj lj2 = lj.cmy();
					int index = gcw;
					lj2.cob(index, num);
				}
			}
			hw.jun.dbg();
		}
		else
		{
			hw.cdt(hd.ivd);
		}
	}

	[Token(Token = "0x60001EA")]
	[Address(RVA = "0x31AA00", Offset = "0x319A00", VA = "0x18031AA00")]
	private void bdy()
	{
		int num = 0;
		hw.cdq();
		int num2 = 0;
		lj lj2 = lj.cmy();
		int nfo = mo.nfo;
		lj2.cog(nfo);
	}

	[Token(Token = "0x60001EB")]
	[Address(RVA = "0x31AAB0", Offset = "0x319AB0", VA = "0x18031AAB0")]
	public void bdz()
	{
		//IL_00c1: Expected I4, but got I8
		//IL_00c1: Expected I4, but got I8
		int num = 0;
		jr[] miv = lm.cua().miv;
		int nfo = mo.nfo;
		if ((long)"{il2cpp array field local3->}" == 0)
		{
			return;
		}
		int num2 = 0;
		jr[] miv2 = lm.cua().miv;
		int nfo2 = mo.nfo;
		if (!miv2[nfo2].lfc)
		{
			int num3 = 0;
			jr[] miv3 = lm.cua().miv;
			int nfo3 = mo.nfo;
			if (miv3[nfo3].lez != 1)
			{
				ly jun = hw.jun;
				int num4 = 0;
				jr[] miv4 = lm.cua().miv;
				int nfo4 = mo.nfo;
				jr item = miv4[nfo4];
				cg action = new cg(this, item);
				string inu = hd.inu;
				string ivh = hd.ivh;
				ulong num5 = default;
				ulong num6 = default;
				jun.day(action, ivh, inu, (int)num5, (byte)num6 != 0);
				hw.jun.mwz.xq();
				return;
			}
			int num7 = 0;
			jr[] miv5 = lm.cua().miv;
			int nfo5 = mo.nfo;
			jr item2 = miv5[nfo5];
			bea(item2, 1);
		}
		InfoMeObj.dat(hd.iyi);
		throw new NullReferenceException();
	}

	[Token(Token = "0x60001EC")]
	[Address(RVA = "0x31AFB0", Offset = "0x319FB0", VA = "0x18031AFB0")]
	private void bea(jr item, int number)
	{
		//IL_0065: Invalid comparison between VT and I4
		string[] array;
		while (true)
		{
			array = new string[5];
			string ivv = hd.ivv;
			if (ivv != null && array == null)
			{
				continue;
			}
			array[0] = ivv;
			string lfy = item.leu.lfy;
			if (lfy != null && array == null)
			{
				continue;
			}
			array[1] = lfy;
			if (" " != null && " " == null)
			{
				continue;
			}
			array[2] = " ";
			string inj = hd.inj;
			if (inj == null || typeof(hd).TypeHandle != (RuntimeTypeHandle)(object)0)
			{
				array[3] = inj;
				if (" ?" == null || " ?" != null)
				{
					break;
				}
			}
		}
		array[4] = " ?";
		string info = string.Concat(array);
		string imy = hd.imy;
		ci action = new ci(fyp, item, number);
		iw cmdYes = new iw(imy, action);
		iw cmdNo = new iw(hd.inj, 1);
		hw.cec(info, cmdYes, cmdNo);
	}

	[Token(Token = "0x60001ED")]
	[Address(RVA = "0x31B370", Offset = "0x31A370", VA = "0x18031B370")]
	public void beb(short number)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60001EE")]
	[Address(RVA = "0x307370", Offset = "0x306370", VA = "0x180307370")]
	public cj()
	{
		//IL_0014: Expected I4, but got I8
		//IL_001e: Expected I4, but got I8
		//IL_0028: Expected I4, but got I8
		//IL_003f: Expected I4, but got I8
	}

	[Token(Token = "0x60001EF")]
	[Address(RVA = "0x306F40", Offset = "0x305F40", VA = "0x180306F40")]
	static cj()
	{
		//IL_0020: Expected VT, but got I8
		//IL_002e: Expected VT, but got I8
		//IL_003f: Expected VT, but got I8
		//IL_004d: Expected VT, but got I8
		//IL_005e: Expected VT, but got I8
		//IL_006c: Expected VT, but got I8
		//IL_007d: Expected VT, but got I8
		//IL_008b: Expected VT, but got I8
		//IL_009c: Expected VT, but got I8
		//IL_00aa: Expected VT, but got I8
		//IL_00ba: Expected VT, but got I8
		//IL_00c2: Expected VT, but got I4
		//IL_00ca: Expected VT, but got I4
		//IL_00d8: Expected VT, but got I8
		//IL_00e0: Expected VT, but got I4
		//IL_00ee: Expected VT, but got I8
		//IL_00f6: Expected VT, but got I4
		//IL_0104: Expected VT, but got I8
		//IL_010d: Expected VT, but got I4
		//IL_011c: Expected VT, but got I8
		//IL_0125: Expected VT, but got I4
		//IL_0134: Expected VT, but got I8
		//IL_0146: Expected VT, but got I8
		//IL_0155: Expected VT, but got I8
		//IL_015e: Expected VT, but got I4
		//IL_016d: Expected VT, but got I8
		//IL_017f: Expected VT, but got I8
		//IL_018e: Expected VT, but got I8
		//IL_0197: Expected VT, but got I4
		//IL_01a6: Expected VT, but got I8
		//IL_01af: Expected VT, but got I4
		//IL_01be: Expected VT, but got I8
		//IL_01c7: Expected VT, but got I4
		//IL_01d6: Expected VT, but got I8
		//IL_01df: Expected VT, but got I4
		//IL_01ee: Expected VT, but got I8
		//IL_01f7: Expected VT, but got I4
		//IL_0206: Expected VT, but got I8
		//IL_0218: Expected VT, but got I8
		//IL_0227: Expected VT, but got I8
		//IL_0239: Expected VT, but got I8
		//IL_0248: Expected VT, but got I8
		//IL_025a: Expected VT, but got I8
		//IL_0269: Expected VT, but got I8
		//IL_027b: Expected VT, but got I8
		//IL_028a: Expected VT, but got I8
		//IL_029c: Expected VT, but got I8
		//IL_02ab: Expected VT, but got I8
		Vector2[] array = new Vector2[24];
		int length = array.Length;
		array[0] = (Vector2)3221225472L;
		array[0] = (Vector2)1096810496;
		array[1] = (Vector2)3231711232L;
		array[1] = (Vector2)1102053376;
		array[2] = (Vector2)3231711232L;
		array[2] = (Vector2)1102053376;
		array[3] = (Vector2)3221225472L;
		array[3] = (Vector2)1099431936;
		array[4] = (Vector2)3221225472L;
		array[4] = (Vector2)1102053376;
		int num = 0;
		array[5] = (Vector2)1099956224;
		array[5] = (Vector2)num;
		array[6] = (Vector2)num;
		array[6] = (Vector2)1097859072;
		array[7] = (Vector2)num;
		array[7] = (Vector2)1097859072;
		array[8] = (Vector2)num;
		array[8] = (Vector2)1097859072;
		array[9] = (Vector2)num;
		array[9] = (Vector2)1097859072;
		array[10] = (Vector2)num;
		array[10] = (Vector2)1097859072;
		array[11] = (Vector2)3235905536L;
		array[11] = (Vector2)1097859072;
		array[12] = (Vector2)num;
		array[12] = (Vector2)1097859072;
		array[13] = (Vector2)3229614080L;
		array[13] = (Vector2)1097859072;
		array[14] = (Vector2)num;
		array[14] = (Vector2)1099956224;
		array[15] = (Vector2)num;
		array[15] = (Vector2)1097859072;
		array[16] = (Vector2)num;
		array[16] = (Vector2)1097859072;
		array[17] = (Vector2)num;
		array[17] = (Vector2)1097859072;
		array[18] = (Vector2)num;
		array[18] = (Vector2)1097859072;
		array[19] = (Vector2)3231711232L;
		array[19] = (Vector2)1094713344;
		array[20] = (Vector2)3231711232L;
		array[20] = (Vector2)1099431936;
		array[21] = (Vector2)3240099840L;
		array[21] = (Vector2)1097859072;
		array[22] = (Vector2)3231711232L;
		array[22] = (Vector2)1099956224;
		array[23] = (Vector2)3235905536L;
		array[23] = (Vector2)1099956224;
		gcd = array;
	}
}
