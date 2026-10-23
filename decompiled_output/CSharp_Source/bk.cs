using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000025")]
public class bk : hs, k
{
	[Token(Token = "0x2000026")]
	public class bh : hi
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000120")]
		private bk fsh;

		[Token(Token = "0x600015A")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public bh(bk me)
		{
			fsh = me;
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0x276CB0", Offset = "0x275CB0", VA = "0x180276CB0", Slot = "4")]
		public void perform(string text)
		{
			fsh.bag(text);
		}
	}

	[Token(Token = "0x2000027")]
	public class bi
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000121")]
		public List<bc> fsi;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000122")]
		private bk fsj;

		[Token(Token = "0x600015C")]
		[Address(RVA = "0x276CD0", Offset = "0x275CD0", VA = "0x180276CD0")]
		public bi(bk session)
		{
			fsj = session;
			List<bc> list = (List<bc>)(object)new List<T>();
			fsi = list;
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x276D50", Offset = "0x275D50", VA = "0x180276D50")]
		public void bad(bc message)
		{
			//IL_000c: Expected VT, but got Obj
			((List<T>)(object)fsi).Add((T)message);
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0x276DB0", Offset = "0x275DB0", VA = "0x180276DB0")]
		public void run()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x2000028")]
	private class bj
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000123")]
		private bk fsk;

		[Token(Token = "0x600015F")]
		[Address(RVA = "0x276C80", Offset = "0x275C80", VA = "0x180276C80")]
		public bj(bk session)
		{
			fsk = session;
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0x2772B0", Offset = "0x2762B0", VA = "0x1802772B0")]
		public void run()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000161")]
		[Address(RVA = "0x276FC0", Offset = "0x275FC0", VA = "0x180276FC0")]
		private bc bae()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4000104")]
	public bool fsl;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000105")]
	public string fsm;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000106")]
	public int fsn;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000107")]
	public WWW fso;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000108")]
	public hi fsp;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000109")]
	private NetworkStream fsq;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400010A")]
	private BinaryReader fsr;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x400010B")]
	private BinaryWriter fss;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x400010C")]
	public nt fst;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400010D")]
	private TcpClient fsu;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400010E")]
	public bool fsv;

	[FieldOffset(Offset = "0x61")]
	[Token(Token = "0x400010F")]
	public bool fsw;

	[FieldOffset(Offset = "0x62")]
	[Token(Token = "0x4000110")]
	public bool fsx;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4000111")]
	private bi fsy;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4000112")]
	public Thread fsz;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000113")]
	public Thread fta;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000114")]
	public Thread ftb;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000115")]
	public int ftc;

	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4000116")]
	public int ftd;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000117")]
	private sbyte fte;

	[FieldOffset(Offset = "0x91")]
	[Token(Token = "0x4000118")]
	private sbyte ftf;

	[FieldOffset(Offset = "0x94")]
	[Token(Token = "0x4000119")]
	private int ftg;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x400011A")]
	public string fth = "";

	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x400011B")]
	public bool fti;

	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x400011C")]
	private string ftj;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x400011D")]
	private int ftk;

	[Token(Token = "0x400011E")]
	public static long ftl;

	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x400011F")]
	public List<bc> ftm;

	[Token(Token = "0x6000146")]
	[Address(RVA = "0x43B2E0", Offset = "0x43A2E0", VA = "0x18043B2E0")]
	public void baf(string link, hi h)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000147")]
	[Address(RVA = "0x43B220", Offset = "0x43A220", VA = "0x18043B220")]
	public bk()
	{
		//IL_0021: Expected Obj, but got I4
		List<bc> list = (List<bc>)(object)new List<T>();
		int num = 0;
		ftm = list;
		zp((hr)num);
		bi bi2 = new bi(this);
		fsy = bi2;
	}

	[Token(Token = "0x6000148")]
	[Address(RVA = "0x43B380", Offset = "0x43A380", VA = "0x18043B380")]
	public void bag(string text)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000149")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "9")]
	public void ti(int idAction, lh p)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600014A")]
	[Address(RVA = "0x43B6D0", Offset = "0x43A6D0", VA = "0x18043B6D0")]
	public void bah()
	{
		((List<T>)(object)fsy.fsi).Clear();
	}

	[Token(Token = "0x600014B")]
	[Address(RVA = "0x407B20", Offset = "0x406B20", VA = "0x180407B20", Slot = "4")]
	public bool zo()
	{
		return fsv;
	}

	[Token(Token = "0x600014C")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "5")]
	public void zp(hr msgHandler)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600014D")]
	[Address(RVA = "0x43C240", Offset = "0x43B240", VA = "0x18043C240", Slot = "6")]
	public void zq(string host, int port)
	{
		//IL_0029: Expected Obj, but got I8
		if (!fsv && !fsw)
		{
			ftj = host;
			ftk = port;
			fsu = (TcpClient)0;
			(fsz = new Thread(NetworkInit)).Start();
		}
	}

	[Token(Token = "0x600014E")]
	[Address(RVA = "0x43B170", Offset = "0x43A170", VA = "0x18043B170")]
	private void NetworkInit()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600014F")]
	[Address(RVA = "0x43B720", Offset = "0x43A720", VA = "0x18043B720")]
	public bool bai(string host, int port)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000150")]
	[Address(RVA = "0x43C320", Offset = "0x43B320", VA = "0x18043C320", Slot = "7")]
	public void zs(bc message)
	{
		fsy.bad(message);
	}

	[Token(Token = "0x6000151")]
	[Address(RVA = "0x43BA80", Offset = "0x43AA80", VA = "0x18043BA80")]
	private void baj(bc m)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000152")]
	[Address(RVA = "0x43BCE0", Offset = "0x43ACE0", VA = "0x18043BCE0")]
	public void bak(bc msg)
	{
		//IL_0029: Expected VT, but got Obj
		int num = 0;
		string name = Thread.CurrentThread.Name;
		string mainThreadName = Main.mainThreadName;
		if (!string.Equals(name, mainThreadName))
		{
			((List<T>)(object)ftm).Add((T)msg);
		}
		else
		{
			fst.caj(msg);
		}
	}

	[Token(Token = "0x6000153")]
	[Address(RVA = "0x43BDD0", Offset = "0x43ADD0", VA = "0x18043BDD0")]
	public void bal()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000154")]
	[Address(RVA = "0x43C160", Offset = "0x43B160", VA = "0x18043C160", Slot = "8")]
	public void close()
	{
		((List<T>)(object)ftm).Clear();
		bam();
		fsx = false;
		((List<T>)(object)fsy.fsi).Clear();
		fsv = false;
		bi bi2 = new bi(this);
		fsy = bi2;
	}

	[Token(Token = "0x6000155")]
	[Address(RVA = "0x43BFF0", Offset = "0x43AFF0", VA = "0x18043BFF0")]
	private void bam()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000156")]
	[Address(RVA = "0x43B160", Offset = "0x43A160", VA = "0x18043B160")]
	public static int ban()
	{
		int num = 0;
		return Environment.TickCount;
	}

	[Token(Token = "0x6000157")]
	[Address(RVA = "0x27FBF0", Offset = "0x27EBF0", VA = "0x18027FBF0")]
	public static byte bao(sbyte var)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000158")]
	[Address(RVA = "0x43C0B0", Offset = "0x43B0B0", VA = "0x18043C0B0")]
	public static byte[] bap(sbyte[] var)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000159")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static bk()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
