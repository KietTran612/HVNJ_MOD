using System;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200016E")]
public class YesNoSDKDlg : lu
{
	[Token(Token = "0x200016F")]
	private class nr : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400182A")]
		private YesNoSDKDlg ojq;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400182B")]
		private int ojr;

		[Token(Token = "0x6000C9F")]
		[Address(RVA = "0x277DC0", Offset = "0x276DC0", VA = "0x180277DC0")]
		public nr(YesNoSDKDlg m, int t)
		{
			ojq = m;
			ojr = t;
		}

		[Token(Token = "0x6000CA0")]
		[Address(RVA = "0x27ABF0", Offset = "0x279BF0", VA = "0x18027ABF0", Slot = "4")]
		public void th()
		{
			YesNoSDKDlg yesNoSDKDlg = ojq;
			int type = ojr;
			yesNoSDKDlg.dqs(type);
		}
	}

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001810")]
	public string[] ojs;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001811")]
	private string ojt;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001812")]
	public bool oju;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001813")]
	public int ojv;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001814")]
	public int ojw;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001815")]
	public long ojx;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001816")]
	private int ojy;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001817")]
	private int ojz;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001818")]
	private int oka;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001819")]
	private int okb;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400181A")]
	private int okc;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400181B")]
	private GameObject okd;

	[Token(Token = "0x400181C")]
	private static YesNoSDKDlg oke;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400181D")]
	private int okf;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x400181E")]
	private int okg;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400181F")]
	private int okh;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4001820")]
	private int oki;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001821")]
	private int okj;

	[FieldOffset(Offset = "0x84")]
	[Token(Token = "0x4001822")]
	private int okk;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001823")]
	private hm okl;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001824")]
	private hm okm;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001825")]
	private hm okn;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4001826")]
	private hm oko;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4001827")]
	private RectTransform okp;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001828")]
	private RectTransform okq;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4001829")]
	private RectTransform okr;

	[Token(Token = "0x6000C96")]
	[Address(RVA = "0x437FE0", Offset = "0x436FE0", VA = "0x180437FE0")]
	public static YesNoSDKDlg dqq()
	{
		//IL_001d: Expected I4, but got I8
		//IL_0027: Expected I4, but got I8
		//IL_0031: Expected I4, but got I8
		//IL_003b: Expected I4, but got I8
		YesNoSDKDlg yesNoSDKDlg = oke;
		if (yesNoSDKDlg == null)
		{
			YesNoSDKDlg yesNoSDKDlg2 = new YesNoSDKDlg();
			yesNoSDKDlg2.ojy = 220;
			yesNoSDKDlg2.oka = 120;
			yesNoSDKDlg2.okb = 60;
			yesNoSDKDlg2.okc = 22;
			oke = yesNoSDKDlg2;
		}
		return yesNoSDKDlg;
	}

	[Token(Token = "0x6000C97")]
	[Address(RVA = "0x436830", Offset = "0x435830", VA = "0x180436830")]
	public YesNoSDKDlg()
	{
		//IL_0013: Expected I4, but got I8
		//IL_001d: Expected I4, but got I8
		//IL_0027: Expected I4, but got I8
		//IL_0031: Expected I4, but got I8
		ojy = 220;
		oka = 120;
		okb = 60;
		okc = 22;
	}

	[Token(Token = "0x6000C98")]
	[Address(RVA = "0x437EA0", Offset = "0x436EA0", VA = "0x180437EA0", Slot = "7")]
	public override void bnk()
	{
		hw.juk = this;
	}

	[Token(Token = "0x6000C99")]
	[Address(RVA = "0x438070", Offset = "0x437070", VA = "0x180438070")]
	public void dqr(string info, iw left, iw center, iw right)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C9A")]
	[Address(RVA = "0x438530", Offset = "0x437530", VA = "0x180438530")]
	private void initUI()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C9B")]
	[Address(RVA = "0x438330", Offset = "0x437330", VA = "0x180438330")]
	private void dqs(int type)
	{
		close();
		if (type != 0)
		{
			switch (type)
			{
			case 1:
				mvt.cgd();
				return;
			default:
				return;
			case 0:
				break;
			}
		}
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000C9C")]
	[Address(RVA = "0x437D00", Offset = "0x436D00", VA = "0x180437D00", Slot = "6")]
	public override void bnj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C9D")]
	[Address(RVA = "0x438390", Offset = "0x437390", VA = "0x180438390")]
	public static void dqt(string info)
	{
		//IL_005b: Expected Obj, but got I4
		//IL_0070: Expected Obj, but got I4
		//IL_0070: Expected Obj, but got I4
		//IL_001d: Expected I4, but got I8
		//IL_0027: Expected I4, but got I8
		//IL_0031: Expected I4, but got I8
		//IL_003b: Expected I4, but got I8
		YesNoSDKDlg yesNoSDKDlg = oke;
		if (yesNoSDKDlg == null)
		{
			YesNoSDKDlg yesNoSDKDlg2 = new YesNoSDKDlg();
			yesNoSDKDlg2.ojy = 220;
			yesNoSDKDlg2.oka = 120;
			yesNoSDKDlg2.okb = 60;
			yesNoSDKDlg2.okc = 22;
			oke = yesNoSDKDlg2;
		}
		string ofj = nm.ofj;
		hw jsu = hw.jsu;
		int num = default;
		iw center = new iw(ofj, jsu, 8882, (lh)num);
		num = 0;
		int num2 = 0;
		yesNoSDKDlg.dqr(info, (iw)num2, center, (iw)num);
	}

	[Token(Token = "0x6000C9E")]
	[Address(RVA = "0x437F10", Offset = "0x436F10", VA = "0x180437F10", Slot = "9")]
	public override void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
