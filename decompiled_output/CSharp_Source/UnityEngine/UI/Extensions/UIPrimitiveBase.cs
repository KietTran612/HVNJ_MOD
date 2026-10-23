using System;
using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000222")]
public class UIPrimitiveBase : MaskableGraphic, ILayoutElement, ICanvasRaycastFilter
{
	[Token(Token = "0x4001C30")]
	protected static Material pfe;

	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4001C31")]
	private List<Vector2> pff = (List<Vector2>)(object)new List<T>();

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4001C32")]
	[SerializeField]
	private Sprite m_Sprite;

	[NonSerialized]
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4001C33")]
	private Sprite pfg;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4001C34")]
	internal float pfh = 1f;

	[FieldOffset(Offset = "0xF4")]
	[Token(Token = "0x4001C35")]
	[SerializeField]
	private po m_improveResolution;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4001C36")]
	[SerializeField]
	protected float m_Resolution;

	[FieldOffset(Offset = "0xFC")]
	[Token(Token = "0x4001C37")]
	[SerializeField]
	private bool m_useNativeSize;

	[Token(Token = "0x170000E2")]
	public Sprite pwf
	{
		[Token(Token = "0x60011A2")]
		[Address(RVA = "0x3769A0", Offset = "0x3759A0", VA = "0x1803769A0")]
		get
		{
			return m_Sprite;
		}
		[Token(Token = "0x60011A3")]
		[Address(RVA = "0x885800", Offset = "0x884800", VA = "0x180885800")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000E3")]
	public Sprite pwg
	{
		[Token(Token = "0x60011A4")]
		[Address(RVA = "0x885880", Offset = "0x884880", VA = "0x180885880")]
		get
		{
			return pwh;
		}
		[Token(Token = "0x60011A5")]
		[Address(RVA = "0x885890", Offset = "0x884890", VA = "0x180885890")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000E4")]
	protected Sprite pwh
	{
		[Token(Token = "0x60011A6")]
		[Address(RVA = "0x885910", Offset = "0x884910", VA = "0x180885910")]
		get
		{
			//IL_0010: Expected Obj, but got I4
			Sprite sprite = pfg;
			int num = 0;
			if (sprite != (Object)num)
			{
				return pfg;
			}
			return m_Sprite;
		}
	}

	[Token(Token = "0x170000E5")]
	public float pwi
	{
		[Token(Token = "0x60011A7")]
		[Address(RVA = "0x8859A0", Offset = "0x8849A0", VA = "0x1808859A0")]
		get
		{
			return pfh;
		}
		[Token(Token = "0x60011A8")]
		[Address(RVA = "0x8859B0", Offset = "0x8849B0", VA = "0x1808859B0")]
		set
		{
			pfh = value;
		}
	}

	[Token(Token = "0x170000E6")]
	public po pwj
	{
		[Token(Token = "0x60011A9")]
		[Address(RVA = "0x8859C0", Offset = "0x8849C0", VA = "0x1808859C0")]
		get
		{
			return m_improveResolution;
		}
		[Token(Token = "0x60011AA")]
		[Address(RVA = "0x8859D0", Offset = "0x8849D0", VA = "0x1808859D0")]
		set
		{
			m_improveResolution = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000E7")]
	public float pwk
	{
		[Token(Token = "0x60011AB")]
		[Address(RVA = "0x8859F0", Offset = "0x8849F0", VA = "0x1808859F0")]
		get
		{
			return m_Resolution;
		}
		[Token(Token = "0x60011AC")]
		[Address(RVA = "0x885A00", Offset = "0x884A00", VA = "0x180885A00")]
		set
		{
			m_Resolution = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000E8")]
	public bool pwl
	{
		[Token(Token = "0x60011AD")]
		[Address(RVA = "0x885A20", Offset = "0x884A20", VA = "0x180885A20")]
		get
		{
			return m_useNativeSize;
		}
		[Token(Token = "0x60011AE")]
		[Address(RVA = "0x885A30", Offset = "0x884A30", VA = "0x180885A30")]
		set
		{
			m_useNativeSize = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000E9")]
	public static Material pwm
	{
		[Token(Token = "0x60011B0")]
		[Address(RVA = "0x885A50", Offset = "0x884A50", VA = "0x180885A50")]
		get
		{
			//IL_000f: Expected Obj, but got I4
			Material material = pfe;
			int num = 0;
			if (material == (Object)num)
			{
				int num2 = 0;
				pfe = Canvas.GetETC1SupportedCanvasMaterial();
			}
			return pfe;
		}
	}

	[Token(Token = "0x170000EA")]
	public override Texture mainTexture
	{
		[Token(Token = "0x60011B1")]
		[Address(RVA = "0x886710", Offset = "0x885710", VA = "0x180886710", Slot = "35")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000EB")]
	public bool pwn
	{
		[Token(Token = "0x60011B2")]
		[Address(RVA = "0x885B50", Offset = "0x884B50", VA = "0x180885B50")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000EC")]
	public float pwo
	{
		[Token(Token = "0x60011B3")]
		[Address(RVA = "0x885C20", Offset = "0x884C20", VA = "0x180885C20")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000ED")]
	public override Material material
	{
		[Token(Token = "0x60011B4")]
		[Address(RVA = "0x8868C0", Offset = "0x8858C0", VA = "0x1808868C0", Slot = "32")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x60011B5")]
		[Address(RVA = "0x886CE0", Offset = "0x885CE0", VA = "0x180886CE0", Slot = "33")]
		set
		{
			base.material = value;
		}
	}

	[Token(Token = "0x170000EE")]
	public virtual float minWidth
	{
		[Token(Token = "0x60011BD")]
		[Address(RVA = "0x200230", Offset = "0x1FF230", VA = "0x180200230", Slot = "79")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000EF")]
	public virtual float preferredWidth
	{
		[Token(Token = "0x60011BE")]
		[Address(RVA = "0x886C00", Offset = "0x885C00", VA = "0x180886C00", Slot = "80")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000F0")]
	public virtual float flexibleWidth
	{
		[Token(Token = "0x60011BF")]
		[Address(RVA = "0x6D77B0", Offset = "0x6D67B0", VA = "0x1806D77B0", Slot = "81")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000F1")]
	public virtual float minHeight
	{
		[Token(Token = "0x60011C0")]
		[Address(RVA = "0x200230", Offset = "0x1FF230", VA = "0x180200230", Slot = "82")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000F2")]
	public virtual float preferredHeight
	{
		[Token(Token = "0x60011C1")]
		[Address(RVA = "0x886B20", Offset = "0x885B20", VA = "0x180886B20", Slot = "83")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000F3")]
	public virtual float flexibleHeight
	{
		[Token(Token = "0x60011C2")]
		[Address(RVA = "0x6D77B0", Offset = "0x6D67B0", VA = "0x1806D77B0", Slot = "84")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000F4")]
	public virtual int layoutPriority
	{
		[Token(Token = "0x60011C3")]
		[Address(RVA = "0x1ED9A0", Offset = "0x1EC9A0", VA = "0x1801ED9A0", Slot = "85")]
		get
		{
			return 0;
		}
	}

	[Token(Token = "0x60011AF")]
	[Address(RVA = "0x885780", Offset = "0x884780", VA = "0x180885780")]
	protected UIPrimitiveBase()
	{
		((Graphic)this).useLegacyMeshGeneration__BackingField = false;
	}

	[Token(Token = "0x60011B6")]
	[Address(RVA = "0x885D30", Offset = "0x884D30", VA = "0x180885D30")]
	protected UIVertex[] exf(Vector2[] vertices, Vector2[] uvs)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011B7")]
	[Address(RVA = "0x885FA0", Offset = "0x884FA0", VA = "0x180885FA0")]
	protected Vector2[] exg(Vector2[] input)
	{
		//IL_0006: Expected I4, but got Obj
		List<Vector2> list = (List<Vector2>)(object)new List<T>((int)input);
		return (Vector2[])(object)((List<T>)(object)this.exh((List<>)(object)list)).ToArray();
	}

	[Token(Token = "0x60011B8")]
	[Address(RVA = "0x886050", Offset = "0x885050", VA = "0x180886050")]
	protected List<Vector2> exh(List<Vector2> input)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011B9")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "75")]
	protected virtual void evn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011BA")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "76")]
	protected virtual void evo(float distance)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011BB")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "77")]
	public virtual void CalculateLayoutInputHorizontal()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011BC")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "78")]
	public virtual void CalculateLayoutInputVertical()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011C4")]
	[Address(RVA = "0x8852D0", Offset = "0x8842D0", VA = "0x1808852D0", Slot = "86")]
	public virtual bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011C5")]
	[Address(RVA = "0x886560", Offset = "0x885560", VA = "0x180886560")]
	private Vector2 exi(Vector2 local, Rect rect)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011C6")]
	[Address(RVA = "0x8865D0", Offset = "0x8855D0", VA = "0x1808865D0")]
	private Vector4 exj(Vector4 border, Rect rect)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011C7")]
	[Address(RVA = "0x885750", Offset = "0x884750", VA = "0x180885750", Slot = "5")]
	protected override void OnEnable()
	{
		base.OnEnable();
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x60011C8")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	static UIPrimitiveBase()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
