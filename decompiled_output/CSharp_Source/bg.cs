using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Cpp2IlInjected;

[Token(Token = "0x2000022")]
public class bg : hs
{
	[Token(Token = "0x2000023")]
	public class be
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000103")]
		public List<bc> frh;

		[Token(Token = "0x6000140")]
		[Address(RVA = "0x2760D0", Offset = "0x2750D0", VA = "0x1802760D0")]
		public be()
		{
			List<bc> list = (List<bc>)(object)new List<T>();
			frh = list;
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0x276400", Offset = "0x275400", VA = "0x180276400")]
		public void zj(bc message)
		{
			//IL_000c: Expected VT, but got Obj
			((List<T>)(object)frh).Add((T)message);
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0x276140", Offset = "0x275140", VA = "0x180276140")]
		public void run()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x2000024")]
	private class bf
	{
		[Token(Token = "0x6000143")]
		[Address(RVA = "0x276460", Offset = "0x275460", VA = "0x180276460")]
		public void run()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0x2767A0", Offset = "0x2757A0", VA = "0x1802767A0")]
		private bc zk()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public bf()
		{
		}
	}

	[Token(Token = "0x40000EA")]
	protected static bg fri;

	[Token(Token = "0x40000EB")]
	private static NetworkStream frj;

	[Token(Token = "0x40000EC")]
	private static BinaryReader frk;

	[Token(Token = "0x40000ED")]
	private static BinaryWriter frl;

	[Token(Token = "0x40000EE")]
	public static hr frm;

	[Token(Token = "0x40000EF")]
	private static TcpClient frn;

	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x40000F0")]
	public bool fro;

	[FieldOffset(Offset = "0x11")]
	[Token(Token = "0x40000F1")]
	public bool frp;

	[FieldOffset(Offset = "0x12")]
	[Token(Token = "0x40000F2")]
	public bool frq;

	[Token(Token = "0x40000F3")]
	private static be frr;

	[Token(Token = "0x40000F4")]
	public static Thread frs;

	[Token(Token = "0x40000F5")]
	public static Thread frt;

	[Token(Token = "0x40000F6")]
	public static Thread fru;

	[Token(Token = "0x40000F7")]
	public static int frv;

	[Token(Token = "0x40000F8")]
	public static int frw;

	[Token(Token = "0x40000F9")]
	private static sbyte frx;

	[Token(Token = "0x40000FA")]
	private static sbyte fry;

	[Token(Token = "0x40000FB")]
	private static int frz;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40000FC")]
	public string fsa = "";

	[Token(Token = "0x40000FD")]
	public static bool fsb;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40000FE")]
	private string fsc;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40000FF")]
	private int fsd;

	[Token(Token = "0x4000100")]
	public static long fse;

	[Token(Token = "0x4000101")]
	private static string fsf;

	[Token(Token = "0x4000102")]
	public static List<bc> fsg;

	[Token(Token = "0x600012B")]
	[Address(RVA = "0x4395E0", Offset = "0x4385E0", VA = "0x1804395E0")]
	public bg()
	{
	}

	[Token(Token = "0x600012C")]
	[Address(RVA = "0x439850", Offset = "0x438850", VA = "0x180439850")]
	public static void zl()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600012D")]
	[Address(RVA = "0x439990", Offset = "0x438990", VA = "0x180439990")]
	public void zm()
	{
		((List<T>)(object)frr.frh).Clear();
	}

	[Token(Token = "0x600012E")]
	[Address(RVA = "0x439A20", Offset = "0x438A20", VA = "0x180439A20")]
	public static bg zn()
	{
		bg bg2 = new bg();
		bg2.fsa = "";
		fri = bg2;
		return fri;
	}

	[Token(Token = "0x600012F")]
	[Address(RVA = "0x439B30", Offset = "0x438B30", VA = "0x180439B30", Slot = "4")]
	public bool zo()
	{
		return fro;
	}

	[Token(Token = "0x6000130")]
	[Address(RVA = "0x439B40", Offset = "0x438B40", VA = "0x180439B40", Slot = "5")]
	public void zp(hr msgHandler)
	{
		frm = msgHandler;
	}

	[Token(Token = "0x6000131")]
	[Address(RVA = "0x439BA0", Offset = "0x438BA0", VA = "0x180439BA0", Slot = "6")]
	public void zq(string host, int port)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000132")]
	[Address(RVA = "0x439260", Offset = "0x438260", VA = "0x180439260")]
	private void NetworkInit()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000133")]
	[Address(RVA = "0x43A070", Offset = "0x439070", VA = "0x18043A070")]
	public bool zr(string host, int port)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000134")]
	[Address(RVA = "0x43A640", Offset = "0x439640", VA = "0x18043A640", Slot = "7")]
	public void zs(bc message)
	{
		frr.zj(message);
	}

	[Token(Token = "0x6000135")]
	[Address(RVA = "0x43A6C0", Offset = "0x4396C0", VA = "0x18043A6C0")]
	private static void zt(bc m)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000136")]
	[Address(RVA = "0x27FBF0", Offset = "0x27EBF0", VA = "0x18027FBF0")]
	public static sbyte zu(sbyte b)
	{
		return b;
	}

	[Token(Token = "0x6000137")]
	[Address(RVA = "0x27FBF0", Offset = "0x27EBF0", VA = "0x18027FBF0")]
	public static sbyte zv(sbyte b)
	{
		return b;
	}

	[Token(Token = "0x6000138")]
	[Address(RVA = "0x43AAA0", Offset = "0x439AA0", VA = "0x18043AAA0")]
	public static void zw(bc msg)
	{
		//IL_0028: Expected VT, but got Obj
		int num = 0;
		string name = Thread.CurrentThread.Name;
		string mainThreadName = Main.mainThreadName;
		if (!string.Equals(name, mainThreadName))
		{
			((List<T>)(object)fsg).Add((T)msg);
			return;
		}
		hr hr2 = frm;
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000139")]
	[Address(RVA = "0x43ABF0", Offset = "0x439BF0", VA = "0x18043ABF0")]
	public static void zx()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600013A")]
	[Address(RVA = "0x4396D0", Offset = "0x4386D0", VA = "0x1804396D0", Slot = "8")]
	public void close()
	{
		((List<T>)(object)fsg).Clear();
		int num = 0;
		zy();
		int num2 = 0;
		zn().frq = false;
		((List<T>)(object)frr.frh).Clear();
		fro = false;
		frr = new be();
		((List<T>)(object)frr.frh).Clear();
	}

	[Token(Token = "0x600013B")]
	[Address(RVA = "0x43AE30", Offset = "0x439E30", VA = "0x18043AE30")]
	private static void zy()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600013C")]
	[Address(RVA = "0x43B160", Offset = "0x43A160", VA = "0x18043B160")]
	public static int zz()
	{
		int num = 0;
		return Environment.TickCount;
	}

	[Token(Token = "0x600013D")]
	[Address(RVA = "0x27FBF0", Offset = "0x27EBF0", VA = "0x18027FBF0")]
	public static byte baa(sbyte var)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600013E")]
	[Address(RVA = "0x439620", Offset = "0x438620", VA = "0x180439620")]
	public static byte[] bab(sbyte[] var)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600013F")]
	[Address(RVA = "0x4394A0", Offset = "0x4384A0", VA = "0x1804394A0")]
	static bg()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
