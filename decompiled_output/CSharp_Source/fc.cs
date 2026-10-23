using System.Collections.Generic;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000081")]
public class fc : fi
{
	[Token(Token = "0x2000082")]
	private class fb : i
	{
		[Token(Token = "0x4000510")]
		public static sbyte hfx;

		[Token(Token = "0x4000511")]
		public static sbyte hfy;

		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000512")]
		private fc hfz;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000513")]
		private sbyte hga;

		[FieldOffset(Offset = "0x19")]
		[Token(Token = "0x4000514")]
		private sbyte hgb;

		[Token(Token = "0x60003BB")]
		[Address(RVA = "0x277EB0", Offset = "0x276EB0", VA = "0x180277EB0")]
		public fb(fc me, sbyte t, sbyte index)
		{
			hfz = me;
			hga = index;
			hgb = t;
		}

		[Token(Token = "0x60003BC")]
		[Address(RVA = "0x278940", Offset = "0x277940", VA = "0x180278940", Slot = "4")]
		public void th()
		{
			fc fc2 = hfz;
			sbyte index = hga;
			sbyte type = hgb;
			fc2.bma(type, index);
		}

		[Token(Token = "0x60003BD")]
		[Address(RVA = "0x2788F0", Offset = "0x2778F0", VA = "0x1802788F0")]
		static fb()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x4000509")]
	public static fc hgc;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400050A")]
	private float hgd;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x400050B")]
	private float hge;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400050C")]
	private List<iw> hgf;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x400050D")]
	private kk hgg;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x400050E")]
	private string hgh;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x400050F")]
	public string hgi;

	[Token(Token = "0x60003B6")]
	[Address(RVA = "0x618480", Offset = "0x617480", VA = "0x180618480")]
	public static fc blz()
	{
		fc fc2 = hgc;
		if (fc2 == null)
		{
			hgc = new fc();
		}
		return fc2;
	}

	[Token(Token = "0x60003B7")]
	[Address(RVA = "0x6187E0", Offset = "0x6177E0", VA = "0x1806187E0")]
	public void start(string info, List<iw> vmenu, kk npc)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003B8")]
	[Address(RVA = "0x618530", Offset = "0x617530", VA = "0x180618530")]
	private void bma(sbyte type, sbyte index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60003B9")]
	[Address(RVA = "0x618720", Offset = "0x617720", VA = "0x180618720", Slot = "9")]
	public override void close()
	{
		//IL_001b: Expected Obj, but got I4
		GameObject gameObject = hlf;
		hgi = "";
		int num = 0;
		if (gameObject != (Object)num)
		{
			Object.Destroy(hlf);
		}
		base.close();
	}

	[Token(Token = "0x60003BA")]
	[Address(RVA = "0x618420", Offset = "0x617420", VA = "0x180618420")]
	public fc()
	{
	}
}
