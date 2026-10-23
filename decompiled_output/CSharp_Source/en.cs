using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000071")]
public class en : fi
{
	[Token(Token = "0x2000072")]
	private class el : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000472")]
		private en gys;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000473")]
		private int gyt;

		[Token(Token = "0x600035F")]
		[Address(RVA = "0x277DC0", Offset = "0x276DC0", VA = "0x180277DC0")]
		public el(en me, int index)
		{
			gys = me;
			gyt = index;
		}

		[Token(Token = "0x6000360")]
		[Address(RVA = "0x278700", Offset = "0x277700", VA = "0x180278700", Slot = "4")]
		public void th()
		{
			en en2 = gys;
			int index = gyt;
			en2.bkf(index);
		}
	}

	[Token(Token = "0x2000073")]
	private class em : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000474")]
		private en gyu;

		[Token(Token = "0x6000361")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public em(en me)
		{
			gyu = me;
		}

		[Token(Token = "0x6000362")]
		[Address(RVA = "0x278730", Offset = "0x277730", VA = "0x180278730", Slot = "4")]
		public void th()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x400044E")]
	private static en gyv;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400044F")]
	private int gyw;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000450")]
	private int gyx = 240;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000451")]
	private int gyy;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000452")]
	private int gyz;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000453")]
	private GameObject gza;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000454")]
	private int gzb;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000455")]
	private int gzc;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000456")]
	private int gzd;

	[FieldOffset(Offset = "0x7C")]
	[Token(Token = "0x4000457")]
	private int gze;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000458")]
	private GameObject gzf;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000459")]
	private GameObject gzg;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400045A")]
	private GameObject gzh;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x400045B")]
	private GameObject gzi;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x400045C")]
	private GameObject gzj;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x400045D")]
	public List<jr> gzk;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x400045E")]
	private GameObject[] gzl;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400045F")]
	private hm gzm;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000460")]
	private hm gzn;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000461")]
	private ScrollRect gzo;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000462")]
	private ScrollRect gzp;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000463")]
	private int gzq;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000464")]
	public jr gzr;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000465")]
	private Sprite[] gzs;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000466")]
	private bool gzt;

	[FieldOffset(Offset = "0xF1")]
	[Token(Token = "0x4000467")]
	private bool gzu;

	[FieldOffset(Offset = "0xF2")]
	[Token(Token = "0x4000468")]
	private bool gzv;

	[FieldOffset(Offset = "0xF3")]
	[Token(Token = "0x4000469")]
	private sbyte gzw;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x400046A")]
	private GameObject gzx;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x400046B")]
	private List<jr> gzy;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x400046C")]
	private GameObject gzz;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x400046D")]
	private GameObject haa;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x400046E")]
	private hm hab;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x400046F")]
	private Image hac;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4000470")]
	private hm had;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x4000471")]
	public sbyte hae;

	[Token(Token = "0x600034A")]
	[Address(RVA = "0x465030", Offset = "0x464030", VA = "0x180465030")]
	public static en bkb()
	{
		//IL_001d: Expected I4, but got I8
		en en2 = gyv;
		if (en2 == null)
		{
			en en3 = new en();
			en3.gyx = 240;
			gyv = en3;
		}
		return en2;
	}

	[Token(Token = "0x600034B")]
	[Address(RVA = "0x468150", Offset = "0x467150", VA = "0x180468150")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600034C")]
	[Address(RVA = "0x469410", Offset = "0x468410", VA = "0x180469410")]
	public void updateList()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600034D")]
	[Address(RVA = "0x464C10", Offset = "0x463C10", VA = "0x180464C10", Slot = "7")]
	public override void bbp(short idAction, short indexAc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600034E")]
	[Address(RVA = "0x4650E0", Offset = "0x4640E0", VA = "0x1804650E0")]
	private void bkc(sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600034F")]
	[Address(RVA = "0x4657F0", Offset = "0x4647F0", VA = "0x1804657F0")]
	private void bkd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000350")]
	[Address(RVA = "0x4662C0", Offset = "0x4652C0", VA = "0x1804662C0")]
	private void bke(GameObject objCell, jr item, int dUpgrade, sbyte type, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000351")]
	[Address(RVA = "0x4665C0", Offset = "0x4655C0", VA = "0x1804665C0")]
	private void bkf(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000352")]
	[Address(RVA = "0x466720", Offset = "0x465720", VA = "0x180466720")]
	private void bkg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000353")]
	[Address(RVA = "0x466CF0", Offset = "0x465CF0", VA = "0x180466CF0")]
	private void bkh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000354")]
	[Address(RVA = "0x467160", Offset = "0x466160", VA = "0x180467160")]
	private void bki()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000355")]
	[Address(RVA = "0x469330", Offset = "0x468330", VA = "0x180469330")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000356")]
	[Address(RVA = "0x467770", Offset = "0x466770", VA = "0x180467770")]
	public void bkj()
	{
		GameObject gameObject = hlj;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
		GameObject gameObject2 = gzg;
		int active2 = 0;
		gameObject2.SetActive((byte)active2 != 0);
		gzi.SetActive(value: true);
		updateList();
		bkg();
	}

	[Token(Token = "0x6000357")]
	[Address(RVA = "0x4677E0", Offset = "0x4667E0", VA = "0x1804677E0")]
	private void bkk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000358")]
	[Address(RVA = "0x467DB0", Offset = "0x466DB0", VA = "0x180467DB0")]
	private bool bkl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000359")]
	[Address(RVA = "0x467E80", Offset = "0x466E80", VA = "0x180467E80")]
	public void bkm()
	{
		gzu = false;
		bkh();
		updateList();
		bkk();
	}

	[Token(Token = "0x600035A")]
	[Address(RVA = "0x467EC0", Offset = "0x466EC0", VA = "0x180467EC0")]
	public void bkn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600035B")]
	[Address(RVA = "0x464FA0", Offset = "0x463FA0", VA = "0x180464FA0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600035C")]
	[Address(RVA = "0x468070", Offset = "0x467070", VA = "0x180468070")]
	public void bko()
	{
		bkn();
	}

	[Token(Token = "0x600035D")]
	[Address(RVA = "0x468080", Offset = "0x467080", VA = "0x180468080", Slot = "9")]
	public override void close()
	{
		//IL_000f: Expected Obj, but got I4
		//IL_0016: Expected Obj, but got I4
		//IL_001d: Expected Obj, but got I4
		base.close();
		int num = 0;
		gzr = (jr)num;
		hac = (Image)num;
		hab = (hm)num;
		bkn();
		((List<T>)(object)gzk).Clear();
		Object.Destroy(gzj);
		Object.Destroy(hlf);
	}

	[Token(Token = "0x600035E")]
	[Address(RVA = "0x464BB0", Offset = "0x463BB0", VA = "0x180464BB0")]
	public en()
	{
		//IL_000d: Expected I4, but got I8
	}
}
