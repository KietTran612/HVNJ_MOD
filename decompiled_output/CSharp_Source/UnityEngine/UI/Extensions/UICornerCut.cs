using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000215")]
[AddComponentMenu("UI/Extensions/Primitives/Cut Corners")]
public class UICornerCut : UIPrimitiveBase
{
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001BC9")]
	public Vector2 cornerSize = (Vector2)1098907648;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4001BCA")]
	[SerializeField]
	[Header("Corners to cut")]
	private bool m_cutUL;

	[FieldOffset(Offset = "0x109")]
	[Token(Token = "0x4001BCB")]
	[SerializeField]
	private bool m_cutUR;

	[FieldOffset(Offset = "0x10A")]
	[Token(Token = "0x4001BCC")]
	[SerializeField]
	private bool m_cutLL;

	[FieldOffset(Offset = "0x10B")]
	[Token(Token = "0x4001BCD")]
	[SerializeField]
	private bool m_cutLR;

	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4001BCE")]
	[SerializeField]
	[Tooltip("Up-Down colors become Left-Right colors")]
	private bool m_makeColumns;

	[FieldOffset(Offset = "0x10D")]
	[Token(Token = "0x4001BCF")]
	[SerializeField]
	[Header("Color the cut bars differently")]
	private bool m_useColorUp;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4001BD0")]
	[SerializeField]
	private Color32 m_colorUp;

	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x4001BD1")]
	[SerializeField]
	private bool m_useColorDown;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001BD2")]
	[SerializeField]
	private Color32 m_colorDown;

	[Token(Token = "0x170000C8")]
	public bool pvf
	{
		[Token(Token = "0x600114D")]
		[Address(RVA = "0x3765D0", Offset = "0x3755D0", VA = "0x1803765D0")]
		get
		{
			return m_cutUL;
		}
		[Token(Token = "0x600114E")]
		[Address(RVA = "0x87B420", Offset = "0x87A420", VA = "0x18087B420")]
		set
		{
			m_cutUL = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000C9")]
	public bool pvg
	{
		[Token(Token = "0x600114F")]
		[Address(RVA = "0x87B440", Offset = "0x87A440", VA = "0x18087B440")]
		get
		{
			return m_cutUR;
		}
		[Token(Token = "0x6001150")]
		[Address(RVA = "0x87B450", Offset = "0x87A450", VA = "0x18087B450")]
		set
		{
			m_cutUR = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000CA")]
	public bool pvh
	{
		[Token(Token = "0x6001151")]
		[Address(RVA = "0x87B470", Offset = "0x87A470", VA = "0x18087B470")]
		get
		{
			return m_cutLL;
		}
		[Token(Token = "0x6001152")]
		[Address(RVA = "0x87B480", Offset = "0x87A480", VA = "0x18087B480")]
		set
		{
			m_cutLL = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000CB")]
	public bool pvi
	{
		[Token(Token = "0x6001153")]
		[Address(RVA = "0x87B4A0", Offset = "0x87A4A0", VA = "0x18087B4A0")]
		get
		{
			return m_cutLR;
		}
		[Token(Token = "0x6001154")]
		[Address(RVA = "0x87B4B0", Offset = "0x87A4B0", VA = "0x18087B4B0")]
		set
		{
			m_cutLR = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000CC")]
	public bool pvj
	{
		[Token(Token = "0x6001155")]
		[Address(RVA = "0x87B4D0", Offset = "0x87A4D0", VA = "0x18087B4D0")]
		get
		{
			return m_makeColumns;
		}
		[Token(Token = "0x6001156")]
		[Address(RVA = "0x87B4E0", Offset = "0x87A4E0", VA = "0x18087B4E0")]
		set
		{
			m_makeColumns = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000CD")]
	public bool pvk
	{
		[Token(Token = "0x6001157")]
		[Address(RVA = "0x87B500", Offset = "0x87A500", VA = "0x18087B500")]
		get
		{
			return m_useColorUp;
		}
		[Token(Token = "0x6001158")]
		[Address(RVA = "0x87B510", Offset = "0x87A510", VA = "0x18087B510")]
		set
		{
			m_useColorUp = value;
		}
	}

	[Token(Token = "0x170000CE")]
	public Color32 pvl
	{
		[Token(Token = "0x6001159")]
		[Address(RVA = "0x52BB90", Offset = "0x52AB90", VA = "0x18052BB90")]
		get
		{
			return m_colorUp;
		}
		[Token(Token = "0x600115A")]
		[Address(RVA = "0x52BDE0", Offset = "0x52ADE0", VA = "0x18052BDE0")]
		set
		{
			m_colorUp = value;
		}
	}

	[Token(Token = "0x170000CF")]
	public bool pvm
	{
		[Token(Token = "0x600115B")]
		[Address(RVA = "0x87B520", Offset = "0x87A520", VA = "0x18087B520")]
		get
		{
			return m_useColorDown;
		}
		[Token(Token = "0x600115C")]
		[Address(RVA = "0x87B530", Offset = "0x87A530", VA = "0x18087B530")]
		set
		{
			m_useColorDown = value;
		}
	}

	[Token(Token = "0x170000D0")]
	public Color32 pvn
	{
		[Token(Token = "0x600115D")]
		[Address(RVA = "0x87B540", Offset = "0x87A540", VA = "0x18087B540")]
		get
		{
			return m_colorDown;
		}
		[Token(Token = "0x600115E")]
		[Address(RVA = "0x87B550", Offset = "0x87A550", VA = "0x18087B550")]
		set
		{
			m_colorDown = value;
		}
	}

	[Token(Token = "0x600115F")]
	[Address(RVA = "0x87AC10", Offset = "0x879C10", VA = "0x18087AC10", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001160")]
	[Address(RVA = "0x87B560", Offset = "0x87A560", VA = "0x18087B560")]
	private static void eup(Rect rect, Rect rectUV, Color32 color32, VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001161")]
	[Address(RVA = "0x87B6F0", Offset = "0x87A6F0", VA = "0x18087B6F0")]
	private static void euq(Vector2 a, Vector2 b, Vector2 c, Vector2 d, Rect rectUV, Color32 color32, VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001162")]
	[Address(RVA = "0x87B830", Offset = "0x87A830", VA = "0x18087B830")]
	private static int eur(float x, float y, Rect area, Color32 color32, VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001163")]
	[Address(RVA = "0x87B3B0", Offset = "0x87A3B0", VA = "0x18087B3B0")]
	public unsafe UICornerCut()
	{
		//IL_000d: Expected VT, but got I8
		//IL_0018: Expected native int or pointer, but got VT
		((Vector2*)(nint)cornerSize)->y = 16f;
		m_cutUL = true;
		base._002Ector();
	}
}
