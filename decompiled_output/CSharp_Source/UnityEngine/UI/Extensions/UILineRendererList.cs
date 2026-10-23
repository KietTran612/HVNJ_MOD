using System;
using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200021B")]
[AddComponentMenu("UI/Extensions/Primitives/UILineRendererList")]
[RequireComponent(typeof(RectTransform))]
public class UILineRendererList : UIPrimitiveBase
{
	[Token(Token = "0x200021C")]
	private enum pl
	{
		[Token(Token = "0x4001C13")]
		Start,
		[Token(Token = "0x4001C14")]
		Middle,
		[Token(Token = "0x4001C15")]
		End,
		[Token(Token = "0x4001C16")]
		Full
	}

	[Token(Token = "0x200021D")]
	public enum pm
	{
		[Token(Token = "0x4001C18")]
		Bevel,
		[Token(Token = "0x4001C19")]
		Miter
	}

	[Token(Token = "0x200021E")]
	public enum pn
	{
		[Token(Token = "0x4001C1B")]
		None,
		[Token(Token = "0x4001C1C")]
		Quick,
		[Token(Token = "0x4001C1D")]
		Basic,
		[Token(Token = "0x4001C1E")]
		Improved,
		[Token(Token = "0x4001C1F")]
		Catenary
	}

	[Token(Token = "0x4001BFB")]
	private const float peo = (float)Math.PI / 12f;

	[Token(Token = "0x4001BFC")]
	private const float pep = (float)Math.PI / 6f;

	[Token(Token = "0x4001BFD")]
	private static Vector2 peq;

	[Token(Token = "0x4001BFE")]
	private static Vector2 pes;

	[Token(Token = "0x4001BFF")]
	private static Vector2 pet;

	[Token(Token = "0x4001C00")]
	private static Vector2 peu;

	[Token(Token = "0x4001C01")]
	private static Vector2 pev;

	[Token(Token = "0x4001C02")]
	private static Vector2 pew;

	[Token(Token = "0x4001C03")]
	private static Vector2 pex;

	[Token(Token = "0x4001C04")]
	private static Vector2 pey;

	[Token(Token = "0x4001C05")]
	private static Vector2[] pez;

	[Token(Token = "0x4001C06")]
	private static Vector2[] pfa;

	[Token(Token = "0x4001C07")]
	private static Vector2[] pfb;

	[Token(Token = "0x4001C08")]
	private static Vector2[] pfc;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001C09")]
	[SerializeField]
	[Tooltip("Points to draw lines between\n Can be improved using the Resolution Option")]
	internal List<Vector2> m_points;

	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4001C0A")]
	[SerializeField]
	[Tooltip("Thickness of the line")]
	internal float lineThickness = 2f;

	[FieldOffset(Offset = "0x10C")]
	[Token(Token = "0x4001C0B")]
	[SerializeField]
	[Tooltip("Use the relative bounds of the Rect Transform (0,0 -> 0,1) or screen space coordinates")]
	internal bool relativeSize;

	[FieldOffset(Offset = "0x10D")]
	[Token(Token = "0x4001C0C")]
	[SerializeField]
	[Tooltip("Do the points identify a single line or split pairs of lines")]
	internal bool lineList;

	[FieldOffset(Offset = "0x10E")]
	[Token(Token = "0x4001C0D")]
	[SerializeField]
	[Tooltip("Add end caps to each line\nMultiple caps when used with Line List")]
	internal bool lineCaps;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4001C0E")]
	[SerializeField]
	[Tooltip("Resolution of the Bezier curve, different to line Resolution")]
	internal int bezierSegmentsPerCurve = 10;

	[FieldOffset(Offset = "0x114")]
	[Token(Token = "0x4001C0F")]
	[Tooltip("The type of Join used between lines, Square/Mitre or Curved/Bevel")]
	public pm LineJoins;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001C10")]
	[Tooltip("Bezier method to apply to line, see docs for options\nCan't be used in conjunction with Resolution as Bezier already changes the resolution")]
	public pn BezierMode;

	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4001C11")]
	[HideInInspector]
	public bool drivenExternally;

	[Token(Token = "0x170000DA")]
	public float pvx
	{
		[Token(Token = "0x600117F")]
		[Address(RVA = "0x69D860", Offset = "0x69C860", VA = "0x18069D860")]
		get
		{
			return lineThickness;
		}
		[Token(Token = "0x6001180")]
		[Address(RVA = "0x87D990", Offset = "0x87C990", VA = "0x18087D990")]
		set
		{
			lineThickness = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000DB")]
	public bool pvy
	{
		[Token(Token = "0x6001181")]
		[Address(RVA = "0x87B4D0", Offset = "0x87A4D0", VA = "0x18087B4D0")]
		get
		{
			return relativeSize;
		}
		[Token(Token = "0x6001182")]
		[Address(RVA = "0x87B4E0", Offset = "0x87A4E0", VA = "0x18087B4E0")]
		set
		{
			relativeSize = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000DC")]
	public bool pvz
	{
		[Token(Token = "0x6001183")]
		[Address(RVA = "0x87B500", Offset = "0x87A500", VA = "0x18087B500")]
		get
		{
			return lineList;
		}
		[Token(Token = "0x6001184")]
		[Address(RVA = "0x87D9B0", Offset = "0x87C9B0", VA = "0x18087D9B0")]
		set
		{
			lineList = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000DD")]
	public bool pwa
	{
		[Token(Token = "0x6001185")]
		[Address(RVA = "0x87D9D0", Offset = "0x87C9D0", VA = "0x18087D9D0")]
		get
		{
			return lineCaps;
		}
		[Token(Token = "0x6001186")]
		[Address(RVA = "0x87D9E0", Offset = "0x87C9E0", VA = "0x18087D9E0")]
		set
		{
			lineCaps = value;
			TypeCode typeCode = ((IConvertible)this).GetTypeCode();
		}
	}

	[Token(Token = "0x170000DE")]
	public int pwb
	{
		[Token(Token = "0x6001187")]
		[Address(RVA = "0x52BB90", Offset = "0x52AB90", VA = "0x18052BB90")]
		get
		{
			return bezierSegmentsPerCurve;
		}
		[Token(Token = "0x6001188")]
		[Address(RVA = "0x52BDE0", Offset = "0x52ADE0", VA = "0x18052BDE0")]
		set
		{
			bezierSegmentsPerCurve = value;
		}
	}

	[Token(Token = "0x170000DF")]
	public List<Vector2> pwc
	{
		[Token(Token = "0x6001189")]
		[Address(RVA = "0x3765B0", Offset = "0x3755B0", VA = "0x1803765B0")]
		get
		{
			return m_points;
		}
		[Token(Token = "0x600118A")]
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

	[Token(Token = "0x600118B")]
	[Address(RVA = "0x87DA30", Offset = "0x87CA30", VA = "0x18087DA30")]
	public void ewb(Vector2 pointToAdd)
	{
		((List<T>)(object)m_points).Add((T)pointToAdd);
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x600118C")]
	[Address(RVA = "0x87DAA0", Offset = "0x87CAA0", VA = "0x18087DAA0")]
	public void ewc(Vector2 pointToRemove)
	{
		bool flag = ((List<T>)(object)m_points).Remove((T)pointToRemove);
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x600118D")]
	[Address(RVA = "0x87DB10", Offset = "0x87CB10", VA = "0x18087DB10")]
	public void ewd()
	{
		((List<T>)(object)m_points).Clear();
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x600118E")]
	[Address(RVA = "0x87DB70", Offset = "0x87CB70", VA = "0x18087DB70")]
	private void ewe(VertexHelper vh, List<Vector2> pointsToDraw)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600118F")]
	[Address(RVA = "0x87D060", Offset = "0x87C060", VA = "0x18087D060", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001190")]
	[Address(RVA = "0x87ECF0", Offset = "0x87DCF0", VA = "0x18087ECF0")]
	private UIVertex[] ewf(Vector2 start, Vector2 end, pl type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001191")]
	[Address(RVA = "0x87EEE0", Offset = "0x87DEE0", VA = "0x18087EEE0")]
	private UIVertex[] ewg(Vector2 start, Vector2 end, pl type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001192")]
	[Address(RVA = "0x87D160", Offset = "0x87C160", VA = "0x18087D160", Slot = "75")]
	protected override void evn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001193")]
	[Address(RVA = "0x87D8B0", Offset = "0x87C8B0", VA = "0x18087D8B0", Slot = "76")]
	protected override void evo(float distance)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001194")]
	[Address(RVA = "0x87D0F0", Offset = "0x87C0F0", VA = "0x18087D0F0")]
	public UILineRendererList()
	{
		//IL_0015: Expected I4, but got I8
	}
}
