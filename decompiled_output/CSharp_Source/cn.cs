using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x2000041")]
public class cn : fi
{
	[Token(Token = "0x2000042")]
	private class ck : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000250")]
		private cn gdu;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000251")]
		private int gdv;

		[Token(Token = "0x600020D")]
		[Address(RVA = "0x277DC0", Offset = "0x276DC0", VA = "0x180277DC0")]
		public ck(cn me, int index)
		{
			gdu = me;
			gdv = index;
		}

		[Token(Token = "0x600020E")]
		[Address(RVA = "0x277E00", Offset = "0x276E00", VA = "0x180277E00", Slot = "4")]
		public void th()
		{
			cn cn2 = gdu;
			int index = gdv;
			cn2.beg(index);
		}
	}

	[Token(Token = "0x2000043")]
	private class cl : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000252")]
		private cn gdw;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000253")]
		private sbyte gdx;

		[Token(Token = "0x600020F")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public cl(cn me, sbyte t)
		{
			gdw = me;
			gdx = t;
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0x277E30", Offset = "0x276E30", VA = "0x180277E30", Slot = "4")]
		public void th()
		{
			cn cn2 = gdw;
			sbyte b = gdx;
			cn2.bej(b);
		}
	}

	[Token(Token = "0x400022E")]
	private static cn gdy;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400022F")]
	private int gdz;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000230")]
	private int gea = 245;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4000231")]
	private int geb = 160;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000232")]
	private int gec;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000233")]
	private int ged;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4000234")]
	private int gee;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000235")]
	private int gef;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4000236")]
	private int geg;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000237")]
	private int geh;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000238")]
	private ScrollRect gei;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000239")]
	private GameObject gej;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400023A")]
	private GameObject gek;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x400023B")]
	private hm gel;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x400023C")]
	public u gem;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x400023D")]
	private bool gen = true;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x400023E")]
	private hm geo;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400023F")]
	private GameObject gep;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000240")]
	private GameObject geq;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000241")]
	private RectTransform ger;

	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000242")]
	private RectTransform ges;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000243")]
	private float get;

	[FieldOffset(Offset = "0xDC")]
	[Token(Token = "0x4000244")]
	private float geu;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000245")]
	private float gev;

	[FieldOffset(Offset = "0xE4")]
	[Token(Token = "0x4000246")]
	private float gew;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000247")]
	private int gex = 5;

	[FieldOffset(Offset = "0xEC")]
	[Token(Token = "0x4000248")]
	private int gey;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000249")]
	private int gez;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x400024A")]
	private GameObject gfa;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x400024B")]
	private List<jp> gfb = (List<jp>)(object)new List<T>();

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x400024C")]
	private jp gfc;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x400024D")]
	private List<jr> gfd;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x400024E")]
	private GameObject gfe;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x400024F")]
	private hm gff;

	[Token(Token = "0x60001FE")]
	[Address(RVA = "0x57CDB0", Offset = "0x57BDB0", VA = "0x18057CDB0")]
	public static cn bec()
	{
		//IL_001d: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		//IL_003a: Expected I4, but got I8
		cn cn2 = gdy;
		if (cn2 == null)
		{
			cn cn3 = new cn();
			cn3.gea = 245;
			cn3.geb = 160;
			cn3.gen = true;
			cn3.gex = 5;
			List<jp> list = (List<jp>)(object)new List<T>();
			cn3.gfb = list;
			gdy = cn3;
		}
		return cn2;
	}

	[Token(Token = "0x60001FF")]
	[Address(RVA = "0x57F2F0", Offset = "0x57E2F0", VA = "0x18057F2F0")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000200")]
	[Address(RVA = "0x57CEC0", Offset = "0x57BEC0", VA = "0x18057CEC0")]
	public void bed()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000201")]
	[Address(RVA = "0x57DA40", Offset = "0x57CA40", VA = "0x18057DA40")]
	private void bee(GameObject objCell, jr item, int dUpgrade, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000202")]
	[Address(RVA = "0x57DEC0", Offset = "0x57CEC0", VA = "0x18057DEC0")]
	public void bef(RectTransform rect, Sprite spr, float wCell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000203")]
	[Address(RVA = "0x57DFA0", Offset = "0x57CFA0", VA = "0x18057DFA0")]
	private void beg(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000204")]
	[Address(RVA = "0x580380", Offset = "0x57F380", VA = "0x180580380")]
	public void updateItemInfo(jr item)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000205")]
	[Address(RVA = "0x57E250", Offset = "0x57D250", VA = "0x18057E250")]
	private void beh()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000206")]
	[Address(RVA = "0x57E8C0", Offset = "0x57D8C0", VA = "0x18057E8C0")]
	public void bei()
	{
		//IL_0010: Expected Obj, but got I4
		//IL_0080: Expected Obj, but got I8
		//IL_00a7: Expected Obj, but got I8
		GameObject gameObject = hlf;
		int num = 0;
		if (gameObject != (Object)num)
		{
			Object.Destroy(gfe);
			geo?.joo.gameObject.SetActive(value: true);
			Image component = gej.GetComponent<Image>();
			Sprite sprite = ka.lmc[1];
			component.sprite = sprite;
			jp jp2 = gfc;
			if (jp2 != null)
			{
				Object.Destroy(jp2.lat);
				gfc = (jp)0;
			}
			hm hm2 = gff;
			if (hm2 != null)
			{
				Object.Destroy(hm2.joo.gameObject);
				gff = (hm)0;
			}
			bed();
			gem.yd("");
		}
	}

	[Token(Token = "0x6000207")]
	[Address(RVA = "0x57EB10", Offset = "0x57DB10", VA = "0x18057EB10")]
	private void bej(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000208")]
	[Address(RVA = "0x57CBA0", Offset = "0x57BBA0", VA = "0x18057CBA0", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000209")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
	public override void bcj(int keyCode)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600020A")]
	[Address(RVA = "0x28F7A0", Offset = "0x28E7A0", VA = "0x18028F7A0", Slot = "8")]
	public override void bcf()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600020B")]
	[Address(RVA = "0x57F1E0", Offset = "0x57E1E0", VA = "0x18057F1E0", Slot = "9")]
	public override void close()
	{
		//IL_001b: Expected Obj, but got I8
		//IL_0041: Expected Obj, but got I8
		int num = 0;
		mo.ddt().deq();
		int num2 = 0;
		mo.ddt().odd = (iw)0;
		Object.Destroy(hlf);
		Object.Destroy(geq);
		List<jp> list = gfb;
		gff = (hm)0;
		((List<T>)(object)list).Clear();
		base.close();
	}

	[Token(Token = "0x600020C")]
	[Address(RVA = "0x57CAE0", Offset = "0x57BAE0", VA = "0x18057CAE0")]
	public cn()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
	}
}
