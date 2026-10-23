using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200013A")]
public class ly : lu
{
	[Token(Token = "0x200013B")]
	private class lx : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001431")]
		private ly mww;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001432")]
		private sbyte mwx;

		[Token(Token = "0x6000A3C")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public lx(ly me, sbyte t)
		{
			mww = me;
			mwx = t;
		}

		[Token(Token = "0x6000A3D")]
		[Address(RVA = "0x27A0E0", Offset = "0x2790E0", VA = "0x18027A0E0", Slot = "4")]
		public void th()
		{
			ly ly2 = mww;
			sbyte b = mwx;
			ly2.dbf(b);
		}
	}

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001415")]
	protected string[] mwy;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001416")]
	public u mwz;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001417")]
	public u mxa;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001418")]
	public u mxb;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001419")]
	private int mxc = 200;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x400141A")]
	private int mxd = 120;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400141B")]
	public fi mxe;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400141C")]
	public i mxf;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400141D")]
	public lu mxg;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400141E")]
	private short mxh;

	[FieldOffset(Offset = "0x6A")]
	[Token(Token = "0x400141F")]
	private short mxi;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001420")]
	private string mxj;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001421")]
	private sbyte mxk;

	[Token(Token = "0x4001422")]
	private const sbyte mxl = 0;

	[Token(Token = "0x4001423")]
	private const sbyte mxm = 1;

	[Token(Token = "0x4001424")]
	private const sbyte mxn = 2;

	[FieldOffset(Offset = "0x79")]
	[Token(Token = "0x4001425")]
	private bool mxo;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001426")]
	private GameObject mxp;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4001427")]
	private GameObject mxq;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4001428")]
	private hm mxr;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001429")]
	private hm mxs;

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x400142A")]
	private string mxt;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x400142B")]
	private sbyte mxu = 60;

	[FieldOffset(Offset = "0xA9")]
	[Token(Token = "0x400142C")]
	private sbyte mxv;

	[FieldOffset(Offset = "0xAC")]
	[Token(Token = "0x400142D")]
	private int mxw;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x400142E")]
	private RectTransform mxx;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400142F")]
	private RectTransform mxy;

	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4001430")]
	private RectTransform mxz;

	[Token(Token = "0x6000A2A")]
	[Address(RVA = "0x3CFD00", Offset = "0x3CED00", VA = "0x1803CFD00")]
	public ly()
	{
		//IL_000d: Expected I4, but got I8
		//IL_0017: Expected I4, but got I8
		//IL_0024: Expected I4, but got I8
		//IL_0041: Expected I4, but got I8
		//IL_007b: Expected I4, but got I8
		//IL_00a1: Expected I4, but got I8
		//IL_00e1: Expected I4, but got I8
		//IL_0107: Expected I4, but got I8
		//IL_0147: Expected I4, but got I8
		(mwz = new u()).fou = 50;
		u u2 = mwz;
		int jtj = hw.jtj;
		u2.fov = jtj;
		u u3 = mwz;
		int fow = mxc;
		u3.fow = fow;
		mwz.fox = 28;
		mwz.fot = true;
		(mxa = new u()).fou = 50;
		u u4 = mxa;
		int jtj2 = hw.jtj;
		u4.fov = jtj2;
		u u5 = mxa;
		int fow2 = mxc;
		u5.fow = fow2;
		mxa.fox = 28;
		mxa.fot = true;
		(mxb = new u()).fou = 50;
		u u6 = mxb;
		int jtj3 = hw.jtj;
		u6.fov = jtj3;
		u u7 = mxb;
		int fow3 = mxc;
		u7.fow = fow3;
		mxb.fox = 28;
		mxb.fot = true;
	}

	[Token(Token = "0x6000A2B")]
	[Address(RVA = "0x3D0650", Offset = "0x3CF650", VA = "0x1803D0650")]
	public void daw(string info, fi action, short idAc, string textAc, int type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A2C")]
	[Address(RVA = "0x3D0840", Offset = "0x3CF840", VA = "0x1803D0840")]
	public void dax(string info, fi action, short idAc, string textAc, int type, bool isFrame)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A2D")]
	[Address(RVA = "0x3D0A30", Offset = "0x3CFA30", VA = "0x1803D0A30")]
	public void day(i action, string info, string textAc, int type, bool isFrame)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A2E")]
	[Address(RVA = "0x3D0C10", Offset = "0x3CFC10", VA = "0x1803D0C10")]
	public void daz(string info, lu action, short idAc, short indexAc, string textAc, int type, int type2, string title1, string title2)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A2F")]
	[Address(RVA = "0x3D0E60", Offset = "0x3CFE60", VA = "0x1803D0E60")]
	public void dba(string info, fi action, short idAc, string textAc, int type, int type2, int type3, string title1, string title2, string title3)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A30")]
	[Address(RVA = "0x3D1100", Offset = "0x3D0100", VA = "0x1803D1100")]
	public void dbb(string info, lu action, short idAc, short indexAc, string textAc, int type, string title1)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A31")]
	[Address(RVA = "0x3D1350", Offset = "0x3D0350", VA = "0x1803D1350")]
	public void dbc(string info, iw ok, int type, string title)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A32")]
	[Address(RVA = "0x3D1570", Offset = "0x3D0570", VA = "0x1803D1570")]
	public void dbd(string info, iw ok, int type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A33")]
	[Address(RVA = "0x3D1770", Offset = "0x3D0770", VA = "0x1803D1770")]
	private void dbe(int number)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A34")]
	[Address(RVA = "0x3D27E0", Offset = "0x3D17E0", VA = "0x1803D27E0")]
	private void dbf(sbyte t)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A35")]
	[Address(RVA = "0x3D01F0", Offset = "0x3CF1F0", VA = "0x1803D01F0", Slot = "4")]
	public override void dac(int keyCode)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A36")]
	[Address(RVA = "0x3CFF20", Offset = "0x3CEF20", VA = "0x1803CFF20", Slot = "6")]
	public override void bnj()
	{
		//IL_0031: Expected Obj, but got I4
		mwz.xy();
		mxa.xy();
		u u2 = mxb;
		if (u2 != null)
		{
			InputField fql = u2.fql;
			int num = 0;
			if (fql != (Object)num)
			{
				mxb.xy();
			}
		}
	}

	[Token(Token = "0x6000A37")]
	[Address(RVA = "0x3D0430", Offset = "0x3CF430", VA = "0x1803D0430", Slot = "5")]
	public override void dad(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A38")]
	[Address(RVA = "0x3CFFD0", Offset = "0x3CEFD0", VA = "0x1803CFFD0", Slot = "7")]
	public override void bnk()
	{
		hw.juk = this;
	}

	[Token(Token = "0x6000A39")]
	[Address(RVA = "0x3D05E0", Offset = "0x3CF5E0", VA = "0x1803D05E0", Slot = "8")]
	public override void dae()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000A3A")]
	[Address(RVA = "0x3D0040", Offset = "0x3CF040", VA = "0x1803D0040", Slot = "9")]
	public override void close()
	{
		//IL_0026: Expected Obj, but got I4
		//IL_004f: Expected Obj, but got I4
		u u2 = mwz;
		if (u2 != null)
		{
			u2.fpt = "";
		}
		GameObject gameObject = mxp;
		int num = 0;
		if (gameObject != (Object)num)
		{
			GameObject gameObject2 = mxp;
			int active = 0;
			gameObject2.SetActive((byte)active != 0);
		}
		GameObject gameObject3 = mxq;
		int num2 = 0;
		if (gameObject3 != (Object)num2)
		{
			GameObject gameObject4 = mxq;
			int active2 = 0;
			gameObject4.SetActive((byte)active2 != 0);
		}
		int num3 = 0;
		SDKPopup sDKPopup = SDKPopup.dol();
		int num4 = 0;
		SDKPopup sDKPopup2 = SDKPopup.dol();
		int isLoad = 0;
		sDKPopup2.dou((byte)isLoad != 0);
	}

	[Token(Token = "0x6000A3B")]
	[Address(RVA = "0x3D2920", Offset = "0x3D1920", VA = "0x1803D2920")]
	public void dbg()
	{
		if (mxo)
		{
			GameObject gameObject = mxq;
			int active = 0;
			gameObject.SetActive((byte)active != 0);
			mxo = false;
		}
		int num = 0;
		hw.cdq();
	}
}
