using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001F5")]
[AddComponentMenu("Layout/Extensions/Flow Layout Group")]
public class FlowLayoutGroup : LayoutGroup
{
	[Token(Token = "0x20001F6")]
	public enum oy
	{
		[Token(Token = "0x4001B16")]
		Horizontal,
		[Token(Token = "0x4001B17")]
		Vertical
	}

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001B0B")]
	public float SpacingX;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001B0C")]
	public float SpacingY;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001B0D")]
	public bool ExpandHorizontalSpacing;

	[FieldOffset(Offset = "0x61")]
	[Token(Token = "0x4001B0E")]
	public bool ChildForceExpandWidth;

	[FieldOffset(Offset = "0x62")]
	[Token(Token = "0x4001B0F")]
	public bool ChildForceExpandHeight;

	[FieldOffset(Offset = "0x63")]
	[Token(Token = "0x4001B10")]
	public bool invertOrder;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4001B11")]
	private float pax;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001B12")]
	private float pay;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4001B13")]
	[SerializeField]
	protected oy m_StartAxis;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001B14")]
	private readonly IList<RectTransform> paz = (IList<RectTransform>)new List<T>();

	[Token(Token = "0x170000AB")]
	public oy pug
	{
		[Token(Token = "0x6001048")]
		[Address(RVA = "0x6A3030", Offset = "0x6A2030", VA = "0x1806A3030")]
		get
		{
			return m_StartAxis;
		}
		[Token(Token = "0x6001049")]
		[Address(RVA = "0x6A3040", Offset = "0x6A2040", VA = "0x1806A3040")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000AC")]
	protected bool puh
	{
		[Token(Token = "0x600104E")]
		[Address(RVA = "0x6A3090", Offset = "0x6A2090", VA = "0x1806A3090")]
		get
		{
			TextAnchor textAnchor = m_ChildAlignment;
			if (textAnchor != TextAnchor.LowerCenter && textAnchor != TextAnchor.MiddleCenter)
			{
				return textAnchor == TextAnchor.UpperCenter;
			}
			return true;
		}
	}

	[Token(Token = "0x170000AD")]
	protected bool pui
	{
		[Token(Token = "0x600104F")]
		[Address(RVA = "0x6A30B0", Offset = "0x6A20B0", VA = "0x1806A30B0")]
		get
		{
			TextAnchor textAnchor = m_ChildAlignment;
			if (textAnchor != TextAnchor.LowerRight && textAnchor != TextAnchor.MiddleRight)
			{
				return textAnchor == TextAnchor.UpperRight;
			}
			return true;
		}
	}

	[Token(Token = "0x170000AE")]
	protected bool puj
	{
		[Token(Token = "0x6001050")]
		[Address(RVA = "0x6A30D0", Offset = "0x6A20D0", VA = "0x1806A30D0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000AF")]
	protected bool puk
	{
		[Token(Token = "0x6001051")]
		[Address(RVA = "0x6A30F0", Offset = "0x6A20F0", VA = "0x1806A30F0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x600104A")]
	[Address(RVA = "0x6A2CF0", Offset = "0x6A1CF0", VA = "0x1806A2CF0", Slot = "28")]
	public override void CalculateLayoutInputHorizontal()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600104B")]
	[Address(RVA = "0x6A2FA0", Offset = "0x6A1FA0", VA = "0x1806A2FA0", Slot = "37")]
	public override void SetLayoutHorizontal()
	{
		int layoutInput = 0;
		int axis = 0;
		float num = enq(axis, (byte)layoutInput != 0);
	}

	[Token(Token = "0x600104C")]
	[Address(RVA = "0x6A2FB0", Offset = "0x6A1FB0", VA = "0x1806A2FB0", Slot = "38")]
	public override void SetLayoutVertical()
	{
		int layoutInput = 0;
		float num = enq(1, (byte)layoutInput != 0);
	}

	[Token(Token = "0x600104D")]
	[Address(RVA = "0x6A2E40", Offset = "0x6A1E40", VA = "0x1806A2E40", Slot = "29")]
	public override void CalculateLayoutInputVertical()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001052")]
	[Address(RVA = "0x6A3110", Offset = "0x6A2110", VA = "0x1806A3110")]
	public float enq(int axis, bool layoutInput)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001053")]
	[Address(RVA = "0x6A3A20", Offset = "0x6A2A20", VA = "0x1806A3A20")]
	private float enr(float groupHeight, float yOffset, float currentRowHeight)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001054")]
	[Address(RVA = "0x6A3A80", Offset = "0x6A2A80", VA = "0x1806A3A80")]
	private float ens(float groupWidth, float xOffset, float currentColWidth)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001055")]
	[Address(RVA = "0x6A3AE0", Offset = "0x6A2AE0", VA = "0x1806A3AE0")]
	protected void ent(IList<RectTransform> contents, float rowWidth, float rowHeight, float maxWidth, float xOffset, float yOffset, int axis)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001056")]
	[Address(RVA = "0x6A3F80", Offset = "0x6A2F80", VA = "0x1806A3F80")]
	protected void enu(IList<RectTransform> contents, float colWidth, float colHeight, float maxHeight, float xOffset, float yOffset, int axis)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001057")]
	[Address(RVA = "0x6A4410", Offset = "0x6A3410", VA = "0x1806A4410")]
	public float env()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001058")]
	[Address(RVA = "0x6A44E0", Offset = "0x6A34E0", VA = "0x1806A44E0")]
	public float enw()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001059")]
	[Address(RVA = "0x6A2FC0", Offset = "0x6A1FC0", VA = "0x1806A2FC0")]
	public FlowLayoutGroup()
	{
	}
}
