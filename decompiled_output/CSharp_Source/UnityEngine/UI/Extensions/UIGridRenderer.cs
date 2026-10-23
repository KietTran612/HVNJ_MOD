using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000216")]
[AddComponentMenu("UI/Extensions/Primitives/UIGridRenderer")]
public class UIGridRenderer : UILineRenderer
{
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4001BD3")]
	[SerializeField]
	private int m_GridColumns = 10;

	[FieldOffset(Offset = "0x12C")]
	[Token(Token = "0x4001BD4")]
	[SerializeField]
	private int m_GridRows = 10;

	[Token(Token = "0x170000D1")]
	public int pvo
	{
		[Token(Token = "0x6001164")]
		[Address(RVA = "0x24DC40", Offset = "0x24CC40", VA = "0x18024DC40")]
		get
		{
			return m_GridColumns;
		}
		[Token(Token = "0x6001165")]
		[Address(RVA = "0x87C2E0", Offset = "0x87B2E0", VA = "0x18087C2E0")]
		set
		{
			if (m_GridColumns != value)
			{
				m_GridColumns = value;
				TypeCode typeCode = ((IConvertible)this).GetTypeCode();
			}
		}
	}

	[Token(Token = "0x170000D2")]
	public int pvp
	{
		[Token(Token = "0x6001166")]
		[Address(RVA = "0x87C300", Offset = "0x87B300", VA = "0x18087C300")]
		get
		{
			return m_GridRows;
		}
		[Token(Token = "0x6001167")]
		[Address(RVA = "0x87C310", Offset = "0x87B310", VA = "0x18087C310")]
		set
		{
			if (m_GridRows != value)
			{
				m_GridRows = value;
				TypeCode typeCode = ((IConvertible)this).GetTypeCode();
			}
		}
	}

	[Token(Token = "0x6001168")]
	[Address(RVA = "0x87BC00", Offset = "0x87AC00", VA = "0x18087BC00", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001169")]
	[Address(RVA = "0x87C260", Offset = "0x87B260", VA = "0x18087C260")]
	public UIGridRenderer()
	{
		//IL_000a: Expected I4, but got I8
		//IL_0014: Expected I4, but got I8
		//IL_0029: Expected I4, but got I8
		lineThickness = 2f;
		bezierSegmentsPerCurve = 10;
		((UIPrimitiveBase)this)._002Ector();
	}
}
