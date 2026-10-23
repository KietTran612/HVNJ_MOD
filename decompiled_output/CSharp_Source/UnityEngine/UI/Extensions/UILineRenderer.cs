using System;
using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000217")]
[AddComponentMenu("UI/Extensions/Primitives/UILineRenderer")]
[RequireComponent(typeof(RectTransform))]
public class UILineRenderer : UIPrimitiveBase
{
	[Token(Token = "0x2000218")]
	private enum ph
	{
		[Token(Token = "0x4001BEE")]
		Start,
		[Token(Token = "0x4001BEF")]
		Middle,
		[Token(Token = "0x4001BF0")]
		End,
		[Token(Token = "0x4001BF1")]
		Full
	}

	[Token(Token = "0x2000219")]
	public enum pi
	{
		[Token(Token = "0x4001BF3")]
		Bevel,
		[Token(Token = "0x4001BF4")]
		Miter
	}

	[Token(Token = "0x200021A")]
	public enum pj
	{
		[Token(Token = "0x4001BF6")]
		None,
		[Token(Token = "0x4001BF7")]
		Quick,
		[Token(Token = "0x4001BF8")]
		Basic,
		[Token(Token = "0x4001BF9")]
		Improved,
		[Token(Token = "0x4001BFA")]
		Catenary
	}

	[Token(Token = "0x4001BD5")]
	private const float pea = (float)Math.PI / 12f;

	[Token(Token = "0x4001BD6")]
	private const float peb = (float)Math.PI / 6f;

	[Token(Token = "0x4001BD7")]
	private static Vector2 pec;

	[Token(Token = "0x4001BD8")]
	private static Vector2 ped;

	[Token(Token = "0x4001BD9")]
	private static Vector2 pee;

	[Token(Token = "0x4001BDA")]
	private static Vector2 pef;

	[Token(Token = "0x4001BDB")]
	private static Vector2 peg;

	[Token(Token = "0x4001BDC")]
	private static Vector2 peh;

	[Token(Token = "0x4001BDD")]
	private static Vector2 pei;

	[Token(Token = "0x4001BDE")]
	private static Vector2 pej;

	[Token(Token = "0x4001BDF")]
	private static Vector2[] pek;

	[Token(Token = "0x4001BE0")]
	private static Vector2[] pel;

	[Token(Token = "0x4001BE1")]
	private static Vector2[] pem;

	[Token(Token = "0x4001BE2")]
	private static Vector2[] pen;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001BE3")]
	[SerializeField]
	[Tooltip("Points to draw lines between\n Can be improved using the Resolution Option")]
	internal Vector2[] m_points;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4001BE4")]
	[SerializeField]
	[Tooltip("Segments to be drawn\n This is a list of arrays of points")]
	internal List<Vector2[]> m_segments;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4001BE5")]
	[SerializeField]
	[Tooltip("Thickness of the line")]
	internal float lineThickness = 2f;

	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x4001BE6")]
	[SerializeField]
	[Tooltip("Use the relative bounds of the Rect Transform (0,0 -> 0,1) or screen space coordinates")]
	internal bool relativeSize;

	[FieldOffset(Offset = "0x115")]
	[Token(Token = "0x4001BE7")]
	[SerializeField]
	[Tooltip("Do the points identify a single line or split pairs of lines")]
	internal bool lineList;

	[FieldOffset(Offset = "0x116")]
	[Token(Token = "0x4001BE8")]
	[SerializeField]
	[Tooltip("Add end caps to each line\nMultiple caps when used with Line List")]
	internal bool lineCaps;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001BE9")]
	[SerializeField]
	[Tooltip("Resolution of the Bezier curve, different to line Resolution")]
	internal int bezierSegmentsPerCurve = 10;

	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4001BEA")]
	[Tooltip("The type of Join used between lines, Square/Mitre or Curved/Bevel")]
	public pi LineJoins;

	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4001BEB")]
	[Tooltip("Bezier method to apply to line, see docs for options\nCan't be used in conjunction with Resolution as Bezier already changes the resolution")]
	public pj BezierMode;

	[FieldOffset(Offset = "0x124")]
	[Token(Token = "0x4001BEC")]
	[HideInInspector]
	public bool drivenExternally;

	[Token(Token = "0x170000D3")]
	public float pvq
	{
		[Token(Token = "0x600116A")]
		[Address(RVA = "0x87F560", Offset = "0x87E560", VA = "0x18087F560")]
		get
		{
			return lineThickness;
		}
		[Token(Token = "0x600116B")]
		[Address(RVA = "0x87F570", Offset = "0x87E570", VA = "0x18087F570")]
		set
		{
			lineThickness = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000D4")]
	public bool pvr
	{
		[Token(Token = "0x600116C")]
		[Address(RVA = "0x87B520", Offset = "0x87A520", VA = "0x18087B520")]
		get
		{
			return relativeSize;
		}
		[Token(Token = "0x600116D")]
		[Address(RVA = "0x87F590", Offset = "0x87E590", VA = "0x18087F590")]
		set
		{
			relativeSize = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000D5")]
	public bool pvs
	{
		[Token(Token = "0x600116E")]
		[Address(RVA = "0x87F5B0", Offset = "0x87E5B0", VA = "0x18087F5B0")]
		get
		{
			return lineList;
		}
		[Token(Token = "0x600116F")]
		[Address(RVA = "0x87F5C0", Offset = "0x87E5C0", VA = "0x18087F5C0")]
		set
		{
			lineList = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000D6")]
	public bool pvt
	{
		[Token(Token = "0x6001170")]
		[Address(RVA = "0x87F5E0", Offset = "0x87E5E0", VA = "0x18087F5E0")]
		get
		{
			return lineCaps;
		}
		[Token(Token = "0x6001171")]
		[Address(RVA = "0x87F5F0", Offset = "0x87E5F0", VA = "0x18087F5F0")]
		set
		{
			lineCaps = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000D7")]
	public int pvu
	{
		[Token(Token = "0x6001172")]
		[Address(RVA = "0x87B540", Offset = "0x87A540", VA = "0x18087B540")]
		get
		{
			return bezierSegmentsPerCurve;
		}
		[Token(Token = "0x6001173")]
		[Address(RVA = "0x87B550", Offset = "0x87A550", VA = "0x18087B550")]
		set
		{
			bezierSegmentsPerCurve = value;
		}
	}

	[Token(Token = "0x170000D8")]
	public Vector2[] pvv
	{
		[Token(Token = "0x6001174")]
		[Address(RVA = "0x3765B0", Offset = "0x3755B0", VA = "0x1803765B0")]
		get
		{
			return m_points;
		}
		[Token(Token = "0x6001175")]
		[Address(RVA = "0x87DA00", Offset = "0x87CA00", VA = "0x18087DA00")]
		set
		{
			if (m_points != value)
			{
				m_points = value;
				TypeCode typeCode = ((IConvertible)this).GetTypeCode();
			}
		}
	}

	[Token(Token = "0x170000D9")]
	public List<Vector2[]> pvw
	{
		[Token(Token = "0x6001176")]
		[Address(RVA = "0x3962D0", Offset = "0x3952D0", VA = "0x1803962D0")]
		get
		{
			return m_segments;
		}
		[Token(Token = "0x6001177")]
		[Address(RVA = "0x87F610", Offset = "0x87E610", VA = "0x18087F610")]
		set
		{
			m_segments = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x6001178")]
	[Address(RVA = "0x87F630", Offset = "0x87E630", VA = "0x18087F630")]
	private void evk(VertexHelper vh, Vector2[] pointsToDraw)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001179")]
	[Address(RVA = "0x87F3A0", Offset = "0x87E3A0", VA = "0x18087F3A0", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600117A")]
	[Address(RVA = "0x880810", Offset = "0x87F810", VA = "0x180880810")]
	private UIVertex[] evl(Vector2 start, Vector2 end, ph type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600117B")]
	[Address(RVA = "0x880A00", Offset = "0x87FA00", VA = "0x180880A00")]
	private UIVertex[] evm(Vector2 start, Vector2 end, ph type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600117C")]
	[Address(RVA = "0x880EC0", Offset = "0x87FEC0", VA = "0x180880EC0", Slot = "75")]
	protected override void evn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600117D")]
	[Address(RVA = "0x881610", Offset = "0x880610", VA = "0x180881610", Slot = "76")]
	protected override void evo(float distance)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600117E")]
	[Address(RVA = "0x87F4F0", Offset = "0x87E4F0", VA = "0x18087F4F0")]
	public UILineRenderer()
	{
		//IL_0015: Expected I4, but got I8
	}
}
