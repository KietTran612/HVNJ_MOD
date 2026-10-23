using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000130")]
public class lo : k
{
	[Token(Token = "0x2000131")]
	private class ln : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x40013C2")]
		private lo mth;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x40013C3")]
		private sbyte mti;

		[Token(Token = "0x60009F4")]
		[Address(RVA = "0x277500", Offset = "0x276500", VA = "0x180277500")]
		public ln(lo m, sbyte t)
		{
			mth = m;
			mti = t;
		}

		[Token(Token = "0x60009F5")]
		[Address(RVA = "0x27A020", Offset = "0x279020", VA = "0x18027A020", Slot = "4")]
		public void th()
		{
			lo lo2 = mth;
			sbyte type = mti;
			lo2.czo(type);
		}
	}

	[Token(Token = "0x40013B9")]
	private static lo mtj;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40013BA")]
	public u mtk;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40013BB")]
	public bool mtl;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40013BC")]
	public hq mtm;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40013BD")]
	private long mtn;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x40013BE")]
	private int mto = 220;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x40013BF")]
	private int mtp = 85;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40013C0")]
	private string mtq;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40013C1")]
	private GameObject mtr;

	[Token(Token = "0x60009EB")]
	[Address(RVA = "0x3C8A60", Offset = "0x3C7A60", VA = "0x1803C8A60")]
	public void czk(int keyCode)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60009EC")]
	[Address(RVA = "0x3C8C80", Offset = "0x3C7C80", VA = "0x1803C8C80")]
	public static lo czl()
	{
		//IL_0020: Expected I4, but got I8
		//IL_002a: Expected I4, but got I8
		//IL_0051: Expected I4, but got I8
		//IL_0077: Expected I4, but got I8
		//IL_0092: Expected I4, but got I8
		lo lo2 = mtj;
		if (lo2 == null)
		{
			lo lo3 = new lo();
			lo3.mto = 220;
			lo3.mtp = 85;
			(lo3.mtk = new u()).fqd = "chat";
			lo3.mtk.fou = 16;
			u u2 = lo3.mtk;
			int fow = lo3.mto;
			u2.fow = fow;
			lo3.mtk.fox = 20;
			lo3.mtk.fot = true;
			lo3.mtk.fpw = 40;
			mtj = lo3;
		}
		return lo2;
	}

	[Token(Token = "0x60009ED")]
	[Address(RVA = "0x3C88D0", Offset = "0x3C78D0", VA = "0x1803C88D0")]
	protected lo()
	{
		//IL_000d: Expected I4, but got I8
		//IL_0017: Expected I4, but got I8
		//IL_0044: Expected I4, but got I8
		//IL_0068: Expected I4, but got I8
		//IL_0083: Expected I4, but got I8
		(mtk = new u()).fqd = "chat";
		mtk.fou = 16;
		u u2 = mtk;
		int fow = mto;
		u2.fow = fow;
		mtk.fox = 20;
		mtk.fot = true;
		mtk.fpw = 40;
	}

	[Token(Token = "0x60009EE")]
	[Address(RVA = "0x3C8DC0", Offset = "0x3C7DC0", VA = "0x1803C8DC0")]
	public void czm(hq parentScreen, string to)
	{
		mtq = to;
		mtl = true;
		czn();
	}

	[Token(Token = "0x60009EF")]
	[Address(RVA = "0x3C8E50", Offset = "0x3C7E50", VA = "0x1803C8E50")]
	private void czn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60009F0")]
	[Address(RVA = "0x3C9370", Offset = "0x3C8370", VA = "0x1803C9370")]
	private void czo(sbyte type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60009F1")]
	[Address(RVA = "0x3C95F0", Offset = "0x3C85F0", VA = "0x1803C95F0")]
	public void czp()
	{
		if (mtl)
		{
			mtk.xy();
			u u2 = mtk;
			if (u2.foz)
			{
				u2.foz = false;
				u u3 = mtk;
				hq hq2 = mtm;
				string text = mtq;
				mtk.yd("");
			}
		}
	}

	[Token(Token = "0x60009F2")]
	[Address(RVA = "0x3C89B0", Offset = "0x3C79B0", VA = "0x1803C89B0")]
	public void close()
	{
		//IL_0027: Expected Obj, but got I4
		mtk.yd("");
		GameObject gameObject = mtr;
		mtl = false;
		int num = 0;
		if (gameObject != (Object)num)
		{
			GameObject gameObject2 = mtr;
			int active = 0;
			gameObject2.SetActive((byte)active != 0);
		}
	}

	[Token(Token = "0x60009F3")]
	[Address(RVA = "0x3C96A0", Offset = "0x3C86A0", VA = "0x1803C96A0", Slot = "4")]
	public void ti(int idAction, lh p)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
