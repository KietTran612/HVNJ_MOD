using System;
using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000062")]
public class dz : fi
{
	[Token(Token = "0x2000063")]
	private class du : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40003C2")]
		private dz grs;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40003C3")]
		private sbyte grt;

		[Token(Token = "0x60002F1")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public du(dz me, sbyte t)
		{
			grs = me;
			grt = t;
		}

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0x278520", Offset = "0x277520", VA = "0x180278520", Slot = "4")]
		public void th()
		{
			dz dz2 = grs;
			sbyte type = grt;
			dz2.clickCheck(type);
		}
	}

	[Token(Token = "0x2000064")]
	private class dv : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40003C4")]
		private dz gru;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40003C5")]
		private int grv;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x40003C6")]
		private sbyte grw;

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0x278550", Offset = "0x277550", VA = "0x180278550")]
		public dv(dz me, sbyte t, int index)
		{
			gru = me;
			grv = index;
			grw = t;
		}

		[Token(Token = "0x60002F4")]
		[Address(RVA = "0x2785A0", Offset = "0x2775A0", VA = "0x1802785A0", Slot = "4")]
		public void th()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x2000065")]
	private class dw : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40003C7")]
		public dz grx;

		[Token(Token = "0x60002F5")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public dw(dz me)
		{
			grx = me;
		}

		[Token(Token = "0x60002F6")]
		[Address(RVA = "0x278600", Offset = "0x277600", VA = "0x180278600", Slot = "4")]
		public void th()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x4000398")]
	private static dz gry;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000399")]
	private int grz = 190;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400039A")]
	private int gsa = 240;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400039B")]
	private int gsb;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x400039C")]
	private int gsc;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400039D")]
	private int gsd;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x400039E")]
	private int gse;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400039F")]
	private int gsf;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x40003A0")]
	private int gsg;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x40003A1")]
	private GameObject gsh;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x40003A2")]
	private GameObject gsi;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x40003A3")]
	private GameObject gsj;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x40003A4")]
	private GameObject gsk;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x40003A5")]
	private GameObject gsl;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x40003A6")]
	private GameObject gsm;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x40003A7")]
	private ScrollRect gsn;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x40003A8")]
	private ScrollRect gso;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x40003A9")]
	private ScrollRect gsp;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x40003AA")]
	private hm gsq;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x40003AB")]
	private int gsr;

	[FieldOffset(Offset = "0xCC")]
	[Token(Token = "0x40003AC")]
	private int gss;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x40003AD")]
	private bool gst;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x40003AE")]
	private GameObject gsu;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x40003AF")]
	private GameObject[] gsv;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x40003B0")]
	private List<jr> gsw;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x40003B1")]
	private GameObject gsx;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x40003B2")]
	private GameObject gsy;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x40003B3")]
	private GameObject gsz;

	[Token(Token = "0x40003B4")]
	public static jr gta;

	[Token(Token = "0x40003B5")]
	public static jr gtb;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x40003B6")]
	public sbyte gtc;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x40003B7")]
	private GameObject gtd;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x40003B8")]
	private GameObject gte;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x40003B9")]
	private hm gtf;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x40003BA")]
	private GameObject gtg;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x40003BB")]
	private GameObject gth;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x40003BC")]
	private GameObject gti;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x40003BD")]
	private hm gtj;

	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x40003BE")]
	private GameObject gtk;

	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x40003BF")]
	private List<jr> gtl;

	[FieldOffset(Offset = "0x158")]
	[Token(Token = "0x40003C0")]
	private GameObject gtm;

	[FieldOffset(Offset = "0x160")]
	[Token(Token = "0x40003C1")]
	private List<jr> gtn;

	[Token(Token = "0x60002D9")]
	[Address(RVA = "0x7CD9A0", Offset = "0x7CC9A0", VA = "0x1807CD9A0")]
	public static dz bib()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		dz dz2 = gry;
		if (dz2 == null)
		{
			dz dz3 = new dz();
			dz3.grz = 190;
			dz3.gsa = 240;
			gry = dz3;
		}
		return dz2;
	}

	[Token(Token = "0x60002DA")]
	[Address(RVA = "0x7D2AA0", Offset = "0x7D1AA0", VA = "0x1807D2AA0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002DB")]
	[Address(RVA = "0x7D2660", Offset = "0x7D1660", VA = "0x1807D2660")]
	private void clickCheck(sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002DC")]
	[Address(RVA = "0x7CDA60", Offset = "0x7CCA60", VA = "0x1807CDA60")]
	private bool bic()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002DD")]
	[Address(RVA = "0x7CDB60", Offset = "0x7CCB60", VA = "0x1807CDB60")]
	public void bid()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002DE")]
	[Address(RVA = "0x7D4240", Offset = "0x7D3240", VA = "0x1807D4240")]
	public void updateList()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002DF")]
	[Address(RVA = "0x7CDE80", Offset = "0x7CCE80", VA = "0x1807CDE80")]
	public int bie()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E0")]
	[Address(RVA = "0x7CE000", Offset = "0x7CD000", VA = "0x1807CE000")]
	private void bif()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E1")]
	[Address(RVA = "0x7CEDF0", Offset = "0x7CDDF0", VA = "0x1807CEDF0")]
	private void big(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E2")]
	[Address(RVA = "0x7CEFA0", Offset = "0x7CDFA0", VA = "0x1807CEFA0")]
	private void bih()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E3")]
	[Address(RVA = "0x7CF560", Offset = "0x7CE560", VA = "0x1807CF560")]
	private void bii(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E4")]
	[Address(RVA = "0x7D4160", Offset = "0x7D3160", VA = "0x1807D4160")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E5")]
	[Address(RVA = "0x7CF710", Offset = "0x7CE710", VA = "0x1807CF710")]
	public void bij()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E6")]
	[Address(RVA = "0x7CF960", Offset = "0x7CE960", VA = "0x1807CF960")]
	public void bik()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E7")]
	[Address(RVA = "0x7CFBB0", Offset = "0x7CEBB0", VA = "0x1807CFBB0")]
	private void bil()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E8")]
	[Address(RVA = "0x7D0180", Offset = "0x7CF180", VA = "0x1807D0180")]
	private void bim(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002E9")]
	[Address(RVA = "0x7D0680", Offset = "0x7CF680", VA = "0x1807D0680")]
	public bool bin(jr item, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002EA")]
	[Address(RVA = "0x7D0AA0", Offset = "0x7CFAA0", VA = "0x1807D0AA0")]
	private void bio()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002EB")]
	[Address(RVA = "0x7D13C0", Offset = "0x7D03C0", VA = "0x1807D13C0")]
	private void bip()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002EC")]
	[Address(RVA = "0x7D1FA0", Offset = "0x7D0FA0", VA = "0x1807D1FA0")]
	private void biq(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002ED")]
	[Address(RVA = "0x7CD3A0", Offset = "0x7CC3A0", VA = "0x1807CD3A0", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		//IL_0006: Invalid comparison between VT and I4
		//IL_01d7: Expected Obj, but got I4
		//IL_0011: Invalid comparison between VT and I4
		//IL_001c: Invalid comparison between VT and I4
		//IL_0198: Expected Obj, but got I4
		//IL_0029: Invalid comparison between VT and I8
		//IL_0034: Invalid comparison between VT and I4
		//IL_00ca: Invalid comparison between VT and I4
		//IL_003c: Invalid comparison between VT and I4
		//IL_00e0: Expected Obj, but got I4
		//IL_0105: Invalid comparison between VT and I4
		//IL_0044: Invalid comparison between VT and I4
		//IL_011b: Expected Obj, but got I4
		//IL_004e: Invalid comparison between VT and I8
		uint action = default;
		uint action2 = default;
		GameObject gameObject3;
		int num11;
		do
		{
			IL_0000:
			if (typeof(mo).TypeHandle != (RuntimeTypeHandle)(object)0)
			{
				if (typeof(mo).TypeHandle != (RuntimeTypeHandle)(object)0)
				{
					if (typeof(mo).TypeHandle != (RuntimeTypeHandle)(object)0)
					{
						if (typeof(mo).TypeHandle != (RuntimeTypeHandle)(object)1)
						{
							if (typeof(mo).TypeHandle != (RuntimeTypeHandle)(object)0)
							{
								if (typeof(mo).TypeHandle != (RuntimeTypeHandle)(object)0)
								{
									if (typeof(mo).TypeHandle != (RuntimeTypeHandle)(object)0)
									{
										if (typeof(mo).TypeHandle == (RuntimeTypeHandle)(object)1)
										{
											int num = 0;
											hw.cdq();
										}
										return;
									}
									bir();
								}
								if (!bic())
								{
									goto IL_0000;
								}
								string jdt = hd.jdt;
								iw cmdYes = new iw(hd.imy, this, (int)action);
								int num2 = 0;
								iw cmdNo = new iw(hd.inj, this, (int)action2);
								hw.cec(jdt, cmdYes, cmdNo);
							}
							int num3 = 0;
							mo.ddt().deq();
							int num4 = 0;
							int num5 = 0;
							jr[] miv = lm.cua().miv;
							jr jr2 = gta;
							int ley = jr2.ley;
							if (typeof(dz).TypeHandle == (RuntimeTypeHandle)(object)0)
							{
								goto IL_0000;
							}
							miv[0] = jr2;
							gta = (jr)num4;
							int num6 = 0;
							jr[] miv2 = lm.cua().miv;
							jr jr3 = gtb;
							int ley2 = jr3.ley;
							if (typeof(dz).TypeHandle == (RuntimeTypeHandle)(object)0)
							{
								goto IL_0000;
							}
							miv2[0] = jr3;
							gtb = (jr)num4;
							if ((nint)gsw != num4)
							{
								int num7 = 0;
								jr[] miv3 = lm.cua().miv;
								if (num4 < miv3.Length)
								{
									int num8 = 0;
									jr[] miv4 = lm.cua().miv;
									if ((long)"{il2cpp array field local35->}" != 0)
									{
										int num9 = 0;
										lm.cua().miv[num4].lfm = false;
									}
									num4++;
								}
							}
							close();
						}
						bio();
					}
					GameObject gameObject = hlj;
					int num10 = 0;
					if (gameObject != (UnityEngine.Object)num10 && hlj.activeSelf)
					{
						GameObject gameObject2 = hlj;
						int active = 0;
						gameObject2.SetActive((byte)active != 0);
					}
				}
				bip();
			}
			gameObject3 = hlj;
			num11 = 0;
		}
		while (gameObject3 != (UnityEngine.Object)num11 && hlj.activeSelf);
		throw new NullReferenceException();
	}

	[Token(Token = "0x60002EE")]
	[Address(RVA = "0x7D22D0", Offset = "0x7D12D0", VA = "0x1807D22D0")]
	private void bir()
	{
		if (gst)
		{
			int[] ndd = mc.ndd;
			int lfe = gtb.lfe;
			int num = ndd[lfe];
			int num2 = 0;
			lm lm2 = lm.cua();
			if (num > lm2.mii)
			{
				uint speed = default;
				InfoMeObj.dav(hd.ixa, (int)speed);
				return;
			}
		}
		int[] ndg = mc.ndg;
		int lfe2 = gtb.lfe;
		int num3 = ndg[lfe2];
		int num4 = 0;
		long mie = lm.cua().mie;
		int num5 = 0;
		long mig = lm.cua().mig;
		mig += mie;
		int num6 = 0;
		lj lj2 = lj.cmy();
		jr jr2 = gta;
		jr jr3 = gtb;
		bool flag = gst;
		List<jr> list = gsw;
		int ley = jr3.ley;
		int ley2 = jr2.ley;
		lj2.ctk(ley2, ley, (List<>)(object)list, flag);
		hw.cdu(hd.imb);
	}

	[Token(Token = "0x60002EF")]
	[Address(RVA = "0x7D28A0", Offset = "0x7D18A0", VA = "0x1807D28A0", Slot = "9")]
	public override void close()
	{
		//IL_001f: Expected Obj, but got I4
		//IL_0025: Expected Obj, but got I4
		//IL_002b: Expected Obj, but got I4
		//IL_0032: Expected Obj, but got I4
		//IL_0039: Expected Obj, but got I4
		//IL_0040: Expected Obj, but got I4
		//IL_0047: Expected Obj, but got I4
		UnityEngine.Object.Destroy(hlf);
		UnityEngine.Object.Destroy(gsu);
		int num = 0;
		hlf = (GameObject)num;
		gta = (jr)num;
		gtb = (jr)num;
		gsw = (List<jr>)num;
		gtn = (List<jr>)num;
		gtj = (hm)num;
		gtf = (hm)num;
		gst = (byte)num != 0;
		int num2 = 0;
		jr[] miv = lm.cua().miv;
		if (num < miv.Length)
		{
			int num3 = 0;
			jr[] miv2 = lm.cua().miv;
			if ((long)"{il2cpp array field local11->}" != 0)
			{
				int num4 = 0;
				lm.cua().miv[num].lfm = true;
			}
			num++;
		}
		base.close();
	}

	[Token(Token = "0x60002F0")]
	[Address(RVA = "0x7CD340", Offset = "0x7CC340", VA = "0x1807CD340")]
	public dz()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
	}
}
