using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000058")]
public class dp : fi
{
	[Token(Token = "0x2000059")]
	private class dk : i
	{
		[Token(Token = "0x60002BA")]
		[Address(RVA = "0x278360", Offset = "0x277360", VA = "0x180278360", Slot = "4")]
		public void th()
		{
			int num = 0;
			bhi().bhj();
		}

		[Token(Token = "0x60002BB")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public dk()
		{
		}
	}

	[Token(Token = "0x200005A")]
	private class dl : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000372")]
		private dp gon;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000373")]
		private sbyte goo;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4000374")]
		private int gop;

		[Token(Token = "0x60002BC")]
		[Address(RVA = "0x278390", Offset = "0x277390", VA = "0x180278390")]
		public dl(dp me, sbyte type, int index)
		{
			gon = me;
			goo = type;
			gop = index;
		}

		[Token(Token = "0x60002BD")]
		[Address(RVA = "0x2783E0", Offset = "0x2773E0", VA = "0x1802783E0", Slot = "4")]
		public void th()
		{
			dp dp2 = gon;
			int index = gop;
			sbyte type = goo;
			dp2.bhl(type, index);
		}
	}

	[Token(Token = "0x200005B")]
	private class dm : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000375")]
		private dp goq;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000376")]
		private sbyte gor;

		[Token(Token = "0x60002BE")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public dm(dp me, sbyte index)
		{
			goq = me;
			gor = index;
		}

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0x278410", Offset = "0x277410", VA = "0x180278410", Slot = "4")]
		public void th()
		{
			dp dp2 = goq;
			sbyte index = gor;
			dp2.clickTab(index);
		}
	}

	[Token(Token = "0x200005C")]
	private class dn : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000377")]
		private int gos;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000378")]
		private dp got;

		[Token(Token = "0x60002C0")]
		[Address(RVA = "0x2782F0", Offset = "0x2772F0", VA = "0x1802782F0")]
		public dn(dp me, int ind)
		{
			got = me;
			gos = ind;
		}

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0x278440", Offset = "0x277440", VA = "0x180278440", Slot = "4")]
		public void th()
		{
			dp dp2 = got;
			int index = gos;
			dp2.bhp(index);
		}
	}

	[Token(Token = "0x200005D")]
	private class @do : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000379")]
		private dp gou;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400037A")]
		private sbyte gov;

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public @do(dp me, sbyte t)
		{
			gou = me;
			gov = t;
		}

		[Token(Token = "0x60002C3")]
		[Address(RVA = "0x278470", Offset = "0x277470", VA = "0x180278470", Slot = "4")]
		public void th()
		{
			dp dp2 = gou;
			sbyte b = gov;
			dp2.bhq(b);
		}
	}

	[Token(Token = "0x4000345")]
	private static dp gow;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4000346")]
	private int gox = 370;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000347")]
	private int goy = 245;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000348")]
	private int goz;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000349")]
	private int gpa;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400034A")]
	private int gpb;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400034B")]
	private hm gpc;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400034C")]
	private ScrollRect gpd;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x400034D")]
	private sbyte gpe;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400034E")]
	public List<string> gpf;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400034F")]
	public List<string> gpg;

	[Token(Token = "0x4000350")]
	private static Sprite gph;

	[Token(Token = "0x4000351")]
	private static Sprite gpi;

	[Token(Token = "0x4000352")]
	private static Sprite gpj;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000353")]
	private RectTransform gpk;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000354")]
	public int gpl;

	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4000355")]
	public int gpm;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000356")]
	private float gpn;

	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x4000357")]
	private float gpo;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000358")]
	private float gpp;

	[FieldOffset(Offset = "0xB4")]
	[Token(Token = "0x4000359")]
	private float gpq;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400035A")]
	private GameObject gpr;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x400035B")]
	private hm gps;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x400035C")]
	public string gpt = "";

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x400035D")]
	private GameObject gpu;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x400035E")]
	private RectTransform gpv;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x400035F")]
	private hm gpw;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000360")]
	private Image gpx;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000361")]
	private sbyte gpy;

	[FieldOffset(Offset = "0xF1")]
	[Token(Token = "0x4000362")]
	private sbyte gpz;

	[FieldOffset(Offset = "0xF2")]
	[Token(Token = "0x4000363")]
	private sbyte gqa;

	[FieldOffset(Offset = "0xF3")]
	[Token(Token = "0x4000364")]
	private sbyte gqb;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000365")]
	private RectTransform gqc;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4000366")]
	private float gqd;

	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4000367")]
	private float gqe;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4000368")]
	private int gqf = 5;

	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4000369")]
	private int gqg;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x400036A")]
	private GameObject gqh;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x400036B")]
	private List<jp> gqi = (List<jp>)(object)new List<T>();

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x400036C")]
	public int gqj;

	[FieldOffset(Offset = "0x124")]
	[Token(Token = "0x400036D")]
	public int gqk = -1;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x400036E")]
	public lc gql;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x400036F")]
	public lc gqm;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x4000370")]
	public int gqn;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x4000371")]
	private jy gqo;

	[Token(Token = "0x60002A8")]
	[Address(RVA = "0x7C4C30", Offset = "0x7C3C30", VA = "0x1807C4C30")]
	public static dp bhi()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		//IL_003e: Expected I4, but got I8
		//IL_005b: Expected I4, but got I8
		dp dp2 = gow;
		if (dp2 == null)
		{
			dp dp3 = new dp();
			dp3.gox = 370;
			dp3.goy = 245;
			dp3.gpt = "";
			dp3.gqf = 5;
			List<jp> list = (List<jp>)(object)new List<T>();
			dp3.gqi = list;
			dp3.gqk = -1;
			gow = dp3;
		}
		return dp2;
	}

	[Token(Token = "0x60002A9")]
	[Address(RVA = "0x7C7FF0", Offset = "0x7C6FF0", VA = "0x1807C7FF0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002AA")]
	[Address(RVA = "0x7C4D60", Offset = "0x7C3D60", VA = "0x1807C4D60")]
	private void bhj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002AB")]
	[Address(RVA = "0x7C4E40", Offset = "0x7C3E40", VA = "0x1807C4E40")]
	private void bhk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002AC")]
	[Address(RVA = "0x7C5DA0", Offset = "0x7C4DA0", VA = "0x1807C5DA0")]
	private void bhl(sbyte type, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002AD")]
	[Address(RVA = "0x7C7B90", Offset = "0x7C6B90", VA = "0x1807C7B90")]
	public void clickTab(sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002AE")]
	[Address(RVA = "0x7C5FD0", Offset = "0x7C4FD0", VA = "0x1807C5FD0")]
	public void bhm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002AF")]
	[Address(RVA = "0x7C6A10", Offset = "0x7C5A10", VA = "0x1807C6A10")]
	private void bhn(GameObject objCell, jr item, int dUpgrade, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002B0")]
	[Address(RVA = "0x7C6E90", Offset = "0x7C5E90", VA = "0x1807C6E90")]
	public void bho(RectTransform rect, Sprite spr, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002B1")]
	[Address(RVA = "0x7C6F70", Offset = "0x7C5F70", VA = "0x1807C6F70")]
	private void bhp(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002B2")]
	[Address(RVA = "0x7C7350", Offset = "0x7C6350", VA = "0x1807C7350")]
	private void bhq(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002B3")]
	[Address(RVA = "0x7C47C0", Offset = "0x7C37C0", VA = "0x1807C47C0", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002B4")]
	[Address(RVA = "0x7C7A70", Offset = "0x7C6A70", VA = "0x1807C7A70")]
	public void bhr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002B5")]
	[Address(RVA = "0x7C4A90", Offset = "0x7C3A90", VA = "0x1807C4A90", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002B6")]
	[Address(RVA = "0x7C92D0", Offset = "0x7C82D0", VA = "0x1807C92D0")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002B7")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60002B8")]
	[Address(RVA = "0x7C7EE0", Offset = "0x7C6EE0", VA = "0x1807C7EE0", Slot = "9")]
	public override void close()
	{
		//IL_001d: Expected Obj, but got I4
		//IL_003a: Expected Obj, but got I4
		//IL_0041: Expected Obj, but got I4
		//IL_0048: Expected Obj, but got I4
		//IL_004f: Expected Obj, but got I4
		//IL_005f: Expected I4, but got I8
		int num = 0;
		mo.ddt().deq();
		int num2 = 0;
		mo mo2 = mo.ddt();
		int num3 = 0;
		mo2.odd = (iw)num3;
		Object.Destroy(hlf);
		Object.Destroy(gpu);
		gqm = (lc)num3;
		gql = (lc)num3;
		gpg = (List<string>)num3;
		gpf = (List<string>)num3;
		gqk = -1;
		base.close();
	}

	[Token(Token = "0x60002B9")]
	[Address(RVA = "0x7C46E0", Offset = "0x7C36E0", VA = "0x1807C46E0")]
	public dp()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
		//IL_002e: Expected I4, but got I8
		//IL_004b: Expected I4, but got I8
	}
}
