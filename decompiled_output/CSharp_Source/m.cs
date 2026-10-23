using System;
using System.IO;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200000F")]
public class m
{
	[Token(Token = "0x2000010")]
	private readonly struct PcmData
	{
		[Token(Token = "0x2000011")]
		private readonly struct PcmHeader
		{
			[Token(Token = "0x4000084")]
			private const int fla = 16;

			[FieldOffset(Offset = "0x20")]
			[Token(Token = "0x4000085")]
			private readonly float flb;

			[FieldOffset(Offset = "0x24")]
			[Token(Token = "0x4000086")]
			private readonly float flc;

			[Token(Token = "0x1700000A")]
			public int fks
			{
				[Token(Token = "0x6000084")]
				[Address(RVA = "0x273B90", Offset = "0x272B90", VA = "0x180273B90")]
				[CompilerGenerated]
				get
				{
					return default;
				}
			}

			[Token(Token = "0x1700000B")]
			public int fkt
			{
				[Token(Token = "0x6000085")]
				[Address(RVA = "0x274AE0", Offset = "0x273AE0", VA = "0x180274AE0")]
				[CompilerGenerated]
				get
				{
					return default;
				}
			}

			[Token(Token = "0x1700000C")]
			public int fku
			{
				[Token(Token = "0x6000086")]
				[Address(RVA = "0x2745E0", Offset = "0x2735E0", VA = "0x1802745E0")]
				[CompilerGenerated]
				get
				{
					return default;
				}
			}

			[Token(Token = "0x1700000D")]
			public ushort fkv
			{
				[Token(Token = "0x6000087")]
				[Address(RVA = "0x274AF0", Offset = "0x273AF0", VA = "0x180274AF0")]
				[CompilerGenerated]
				get
				{
					return default;
				}
			}

			[Token(Token = "0x1700000E")]
			public int fkw
			{
				[Token(Token = "0x6000088")]
				[Address(RVA = "0x18F000", Offset = "0x18E000", VA = "0x18018F000")]
				[CompilerGenerated]
				get
				{
					return default;
				}
			}

			[Token(Token = "0x1700000F")]
			public int fkx
			{
				[Token(Token = "0x6000089")]
				[Address(RVA = "0x274B00", Offset = "0x273B00", VA = "0x180274B00")]
				[CompilerGenerated]
				get
				{
					return default;
				}
			}

			[Token(Token = "0x17000010")]
			public int fky
			{
				[Token(Token = "0x600008A")]
				[Address(RVA = "0x274B10", Offset = "0x273B10", VA = "0x180274B10")]
				[CompilerGenerated]
				get
				{
					return default;
				}
			}

			[Token(Token = "0x17000011")]
			public ushort fkz
			{
				[Token(Token = "0x600008B")]
				[Address(RVA = "0x274B20", Offset = "0x273B20", VA = "0x180274B20")]
				[CompilerGenerated]
				get
				{
					return default;
				}
			}

			[Token(Token = "0x600008C")]
			[Address(RVA = "0x274A20", Offset = "0x273A20", VA = "0x180274A20")]
			private PcmHeader(int bitDepth, int audioSize, int audioStartIndex, ushort channels, int sampleRate, int byteRate, ushort blockAlign)
			{
			}

			[Token(Token = "0x600008D")]
			[Address(RVA = "0x274B30", Offset = "0x273B30", VA = "0x180274B30")]
			public static PcmHeader ts(byte[] pcmBytes)
			{
				return default;
			}

			[Token(Token = "0x600008E")]
			[Address(RVA = "0x274C20", Offset = "0x273C20", VA = "0x180274C20")]
			public static PcmHeader tt(Stream pcmStream)
			{
				return default;
			}

			[Token(Token = "0x600008F")]
			[Address(RVA = "0x2750E0", Offset = "0x2740E0", VA = "0x1802750E0")]
			public float tu(float rawSample)
			{
				return default;
			}

			[Token(Token = "0x6000090")]
			[Address(RVA = "0x275110", Offset = "0x274110", VA = "0x180275110")]
			private static string tv(ushort code)
			{
				return null;
			}
		}

		[Token(Token = "0x17000006")]
		[field: FieldOffset(Offset = "0x0")]
		[field: Token(Token = "0x4000078")]
		public float[] fld
		{
			[Token(Token = "0x600007E")]
			[Address(RVA = "0x2745D0", Offset = "0x2735D0", VA = "0x1802745D0")]
			[CompilerGenerated]
			get
			{
				throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
			}
		}

		[Token(Token = "0x17000007")]
		[field: FieldOffset(Offset = "0x8")]
		[field: Token(Token = "0x4000079")]
		public int fle
		{
			[Token(Token = "0x600007F")]
			[Address(RVA = "0x2745E0", Offset = "0x2735E0", VA = "0x1802745E0")]
			get;
		}

		[Token(Token = "0x17000008")]
		[field: FieldOffset(Offset = "0xC")]
		[field: Token(Token = "0x400007A")]
		public int flf
		{
			[Token(Token = "0x6000080")]
			[Address(RVA = "0x2745F0", Offset = "0x2735F0", VA = "0x1802745F0")]
			get;
		}

		[Token(Token = "0x17000009")]
		[field: FieldOffset(Offset = "0x10")]
		[field: Token(Token = "0x400007B")]
		public int flg
		{
			[Token(Token = "0x6000081")]
			[Address(RVA = "0x18F000", Offset = "0x18E000", VA = "0x18018F000")]
			get;
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x2745A0", Offset = "0x2735A0", VA = "0x1802745A0")]
		private PcmData(float[] value, int channels, int sampleRate)
		{
			fld = value;
			int length = value.Length;
			fle = length;
			flf = channels;
			flg = sampleRate;
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x274600", Offset = "0x273600", VA = "0x180274600")]
		public static PcmData ua(byte[] bytes)
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x400002D")]
	private const int flh = 5;

	[Token(Token = "0x400002E")]
	private const int fli = 100;

	[Token(Token = "0x400002F")]
	public static int flj;

	[Token(Token = "0x4000030")]
	public static int flk;

	[Token(Token = "0x4000031")]
	public static int fll;

	[Token(Token = "0x4000032")]
	private static string flm;

	[Token(Token = "0x4000033")]
	private static float fln;

	[Token(Token = "0x4000034")]
	public static bool flo;

	[Token(Token = "0x4000035")]
	public static bool flp;

	[Token(Token = "0x4000036")]
	public static bool flq;

	[Token(Token = "0x4000037")]
	public static bool flr;

	[Token(Token = "0x4000038")]
	public static float fls;

	[Token(Token = "0x4000039")]
	public static float flt;

	[Token(Token = "0x400003A")]
	public static sbyte flu;

	[Token(Token = "0x400003B")]
	public static sbyte flv;

	[Token(Token = "0x400003C")]
	public static sbyte flw;

	[Token(Token = "0x400003D")]
	public static sbyte flx;

	[Token(Token = "0x400003E")]
	public static sbyte fly;

	[Token(Token = "0x400003F")]
	public static sbyte flz;

	[Token(Token = "0x4000040")]
	public static sbyte fma;

	[Token(Token = "0x4000041")]
	public static sbyte fmb;

	[Token(Token = "0x4000042")]
	public static sbyte fmc;

	[Token(Token = "0x4000043")]
	public static sbyte fmd;

	[Token(Token = "0x4000044")]
	public static sbyte fme;

	[Token(Token = "0x4000045")]
	public static sbyte fmf;

	[Token(Token = "0x4000046")]
	public static sbyte fmg;

	[Token(Token = "0x4000047")]
	public static sbyte fmh;

	[Token(Token = "0x4000048")]
	public static sbyte fmi;

	[Token(Token = "0x4000049")]
	public static sbyte fmj;

	[Token(Token = "0x400004A")]
	public static sbyte fmk;

	[Token(Token = "0x400004B")]
	public static sbyte fml;

	[Token(Token = "0x400004C")]
	public static sbyte fmm;

	[Token(Token = "0x400004D")]
	public static sbyte fmn;

	[Token(Token = "0x400004E")]
	public static sbyte fmo;

	[Token(Token = "0x400004F")]
	public static sbyte fmp;

	[Token(Token = "0x4000050")]
	public static sbyte fmq;

	[Token(Token = "0x4000051")]
	public static sbyte fmr;

	[Token(Token = "0x4000052")]
	public static sbyte fms;

	[Token(Token = "0x4000053")]
	public static sbyte fmt;

	[Token(Token = "0x4000054")]
	public static sbyte fmu;

	[Token(Token = "0x4000055")]
	public static sbyte fmv;

	[Token(Token = "0x4000056")]
	public static sbyte fmw;

	[Token(Token = "0x4000057")]
	public static sbyte fmx;

	[Token(Token = "0x4000058")]
	public static sbyte fmy;

	[Token(Token = "0x4000059")]
	public static sbyte fmz;

	[Token(Token = "0x400005A")]
	public static sbyte fna;

	[Token(Token = "0x400005B")]
	public static sbyte fnb;

	[Token(Token = "0x400005C")]
	public static sbyte fnc;

	[Token(Token = "0x400005D")]
	public static sbyte fnd;

	[Token(Token = "0x400005E")]
	public static sbyte fne;

	[Token(Token = "0x400005F")]
	public static sbyte fnf;

	[Token(Token = "0x4000060")]
	public static sbyte fng;

	[Token(Token = "0x4000061")]
	public static sbyte fnh;

	[Token(Token = "0x4000062")]
	public static sbyte fni;

	[Token(Token = "0x4000063")]
	public static sbyte fnj;

	[Token(Token = "0x4000064")]
	public static sbyte fnk;

	[Token(Token = "0x4000065")]
	public static sbyte fnl;

	[Token(Token = "0x4000066")]
	public static sbyte fnm;

	[Token(Token = "0x4000067")]
	public static sbyte fnn;

	[Token(Token = "0x4000068")]
	public static sbyte fno;

	[Token(Token = "0x4000069")]
	public static sbyte fnp;

	[Token(Token = "0x400006A")]
	public static sbyte fnq;

	[Token(Token = "0x400006B")]
	public static sbyte fnr;

	[Token(Token = "0x400006C")]
	public static AudioClip[] fns;

	[Token(Token = "0x400006D")]
	public static GameObject[] fnt;

	[Token(Token = "0x400006E")]
	public static AudioSource[] fnu;

	[Token(Token = "0x400006F")]
	public static AudioClip[][] fnv;

	[Token(Token = "0x4000070")]
	public static GameObject[][] fnw;

	[Token(Token = "0x4000071")]
	public static AudioSource[][] fnx;

	[Token(Token = "0x4000072")]
	public static bool[] fny;

	[Token(Token = "0x4000073")]
	public static bool[] fnz;

	[Token(Token = "0x4000074")]
	private static string[] foa;

	[Token(Token = "0x4000075")]
	private static string[][] fob;

	[Token(Token = "0x4000076")]
	public static int foc;

	[Token(Token = "0x4000077")]
	public static int fod;

	[Token(Token = "0x6000059")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public static void ub()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600005A")]
	[Address(RVA = "0x2E0AE0", Offset = "0x2DFAE0", VA = "0x1802E0AE0")]
	public static bool uc()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600005B")]
	[Address(RVA = "0x3D5EB0", Offset = "0x3D4EB0", VA = "0x1803D5EB0")]
	public static bool ud(int id)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600005C")]
	[Address(RVA = "0x3D5DE0", Offset = "0x3D4DE0", VA = "0x1803D5DE0")]
	public static void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600005D")]
	[Address(RVA = "0x3D5590", Offset = "0x3D4590", VA = "0x1803D5590")]
	public static void init(int sizeM)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600005E")]
	[Address(RVA = "0x3D5F00", Offset = "0x3D4F00", VA = "0x1803D5F00")]
	public static void ue(int id, float volume)
	{
		int isLoop = 0;
		uo(id, volume, (byte)isLoop != 0);
	}

	[Token(Token = "0x600005F")]
	[Address(RVA = "0x3D5F70", Offset = "0x3D4F70", VA = "0x1803D5F70")]
	public static void uf(int id, float volume, float x, float y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000060")]
	[Address(RVA = "0x3D6170", Offset = "0x3D5170", VA = "0x1803D6170")]
	public static void ug(int id, float volume, bool isLoop)
	{
		uo(id, volume, isLoop);
	}

	[Token(Token = "0x6000061")]
	[Address(RVA = "0x3D61F0", Offset = "0x3D51F0", VA = "0x1803D61F0")]
	public static void uh(int id, float volume)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000062")]
	[Address(RVA = "0x3D6280", Offset = "0x3D5280", VA = "0x1803D6280")]
	public static void ui(string fileName, int pos)
	{
		vf(pos);
		uu(fileName, pos);
	}

	[Token(Token = "0x6000063")]
	[Address(RVA = "0x3D6370", Offset = "0x3D5370", VA = "0x1803D6370")]
	public static void uj(string fileName, int pos)
	{
		vg(pos);
		us(pos);
	}

	[Token(Token = "0x6000064")]
	[Address(RVA = "0x3D6410", Offset = "0x3D5410", VA = "0x1803D6410")]
	public static void uk()
	{
		int num = 0;
		AudioClip[] array = fns;
		if (num < array.Length)
		{
			vc(num);
			num++;
		}
		AudioClip[][] array2 = fnv;
		if (num < array2.Length)
		{
			vd(num);
			num++;
		}
	}

	[Token(Token = "0x6000065")]
	[Address(RVA = "0x3D6510", Offset = "0x3D5510", VA = "0x1803D6510")]
	public static void ul()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000066")]
	[Address(RVA = "0x3D6760", Offset = "0x3D5760", VA = "0x1803D6760")]
	public static void um()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000067")]
	[Address(RVA = "0x3D68B0", Offset = "0x3D58B0", VA = "0x1803D68B0")]
	public static void un()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000068")]
	[Address(RVA = "0x3D6E00", Offset = "0x3D5E00", VA = "0x1803D6E00")]
	public static void uo(int id, float volume, bool isLoop)
	{
		uy(volume, id, isLoop);
	}

	[Token(Token = "0x6000069")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public static void up(int id, float volume)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600006A")]
	[Address(RVA = "0x3D6ED0", Offset = "0x3D5ED0", VA = "0x1803D6ED0")]
	public static void uq(int type, float vl, bool loop)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600006B")]
	[Address(RVA = "0x3D6FF0", Offset = "0x3D5FF0", VA = "0x1803D6FF0")]
	public static void ur(string filename, int pos)
	{
		uu(filename, pos);
	}

	[Token(Token = "0x600006C")]
	[Address(RVA = "0x3D7050", Offset = "0x3D6050", VA = "0x1803D7050")]
	public static void us(int pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600006D")]
	[Address(RVA = "0x3D7470", Offset = "0x3D6470", VA = "0x1803D7470")]
	private static void ut(string filename, int pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600006E")]
	[Address(RVA = "0x3D7850", Offset = "0x3D6850", VA = "0x1803D7850")]
	private static void uu(string filename, int pos)
	{
		//IL_0033: Expected Obj, but got I4
		while (true)
		{
			AudioClip[] array = fns;
			Type typeFromHandle = typeof(AudioClip);
			UnityEngine.Object obj = Resources.Load(filename, typeFromHandle);
			int num = 0;
			if ((object)obj != null && ((object)obj == null || (object)obj == null || (object)obj == null))
			{
				break;
			}
			array[0] = (AudioClip)num;
			AudioSource[] array2 = fnu;
			AudioSource audioSource = GameObject.Find("Main Camera").AddComponent<AudioSource>();
			if ((object)audioSource == null || (object)audioSource != null)
			{
				array2[0] = audioSource;
				GameObject[] array3 = fnt;
				GameObject gameObject = GameObject.Find("Main Camera");
				if ((object)gameObject == null || (object)gameObject != null)
				{
					array3[0] = gameObject;
					return;
				}
			}
		}
		throw new InvalidCastException();
	}

	[Token(Token = "0x600006F")]
	[Address(RVA = "0x3D7B00", Offset = "0x3D6B00", VA = "0x1803D7B00")]
	public static AudioClip uv(byte[] bytes, string clipName = "pcm")
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000070")]
	[Address(RVA = "0x3D7B90", Offset = "0x3D6B90", VA = "0x1803D7B90")]
	public static byte[] uw(AudioClip clip)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000071")]
	[Address(RVA = "0x3D7D20", Offset = "0x3D6D20", VA = "0x1803D7D20")]
	public static void ux(float volume, int pos, bool isLoop)
	{
		vb(volume, pos, isLoop);
	}

	[Token(Token = "0x6000072")]
	[Address(RVA = "0x3D7DA0", Offset = "0x3D6DA0", VA = "0x1803D7DA0")]
	public static void uy(float volume, int pos, bool isLoop)
	{
		//IL_004a: Expected Obj, but got I4
		GameObject[][] array = fnw;
		if ((long)"{il2cpp array field local3->}" == 0)
		{
			return;
		}
		int num = 0;
		AudioSource[] array2 = fnx[pos];
		if (num < array2.Length)
		{
			AudioSource audioSource = fnx[pos][num];
			int num2 = 0;
			if (audioSource == (UnityEngine.Object)num2 || fnx[pos][num].isPlaying)
			{
				num++;
			}
			AudioSource[] array3 = fnx[pos];
			AudioClip[][] array4 = fnv;
			AudioSource audioSource2 = array3[num];
			AudioClip clip = array4[pos][num];
			audioSource2.clip = clip;
			fnx[pos][num].volume = volume;
			fnx[pos][num].Play();
			fnx[pos][num].loop = isLoop;
		}
	}

	[Token(Token = "0x6000073")]
	[Address(RVA = "0x3D8270", Offset = "0x3D7270", VA = "0x1803D8270")]
	public static void uz(float volume, int pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000074")]
	[Address(RVA = "0x3D8480", Offset = "0x3D7480", VA = "0x1803D8480")]
	public static void vb(float volume, int pos, bool isLoop)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000075")]
	[Address(RVA = "0x3D8920", Offset = "0x3D7920", VA = "0x1803D8920")]
	public static void vc(int pos)
	{
		vf(pos);
	}

	[Token(Token = "0x6000076")]
	[Address(RVA = "0x3D8970", Offset = "0x3D7970", VA = "0x1803D8970")]
	public static void vd(int pos)
	{
		vg(pos);
	}

	[Token(Token = "0x6000077")]
	[Address(RVA = "0x3D89C0", Offset = "0x3D79C0", VA = "0x1803D89C0")]
	public static void ve(int pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000078")]
	[Address(RVA = "0x3D8BA0", Offset = "0x3D7BA0", VA = "0x1803D8BA0")]
	public static void vf(int pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000079")]
	[Address(RVA = "0x3D8D80", Offset = "0x3D7D80", VA = "0x1803D8D80")]
	public static void vg(int pos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600007A")]
	[Address(RVA = "0x3D9030", Offset = "0x3D8030", VA = "0x1803D9030")]
	public static void vh()
	{
		GameObject gameObject = GameObject.Find("Audio Player").GetComponent<AudioListener>().gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
	}

	[Token(Token = "0x600007B")]
	[Address(RVA = "0x3D90B0", Offset = "0x3D80B0", VA = "0x1803D90B0")]
	public static void vi()
	{
		GameObject.Find("Audio Player").GetComponent<AudioListener>().gameObject.SetActive(value: true);
	}

	[Token(Token = "0x600007C")]
	[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
	public m()
	{
	}

	[Token(Token = "0x600007D")]
	[Address(RVA = "0x3D2AF0", Offset = "0x3D1AF0", VA = "0x1803D2AF0")]
	static m()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
