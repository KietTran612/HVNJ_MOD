using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001DC")]
[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform), typeof(Graphic))]
[AddComponentMenu("UI/Effects/Extensions/Flippable")]
public class UIFlippable : BaseMeshEffect
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A81")]
	[SerializeField]
	private bool m_Horizontal;

	[FieldOffset(Offset = "0x21")]
	[Token(Token = "0x4001A82")]
	[SerializeField]
	private bool m_Veritical;

	[Token(Token = "0x17000094")]
	public bool ptm
	{
		[Token(Token = "0x6000FC0")]
		[Address(RVA = "0x428EE0", Offset = "0x427EE0", VA = "0x180428EE0")]
		get
		{
			return m_Horizontal;
		}
		[Token(Token = "0x6000FC1")]
		[Address(RVA = "0x652880", Offset = "0x651880", VA = "0x180652880")]
		set
		{
			m_Horizontal = value;
		}
	}

	[Token(Token = "0x17000095")]
	public bool ptn
	{
		[Token(Token = "0x6000FC2")]
		[Address(RVA = "0x602910", Offset = "0x601910", VA = "0x180602910")]
		get
		{
			return m_Veritical;
		}
		[Token(Token = "0x6000FC3")]
		[Address(RVA = "0x74DDB0", Offset = "0x74CDB0", VA = "0x18074DDB0")]
		set
		{
			m_Veritical = value;
		}
	}

	[Token(Token = "0x6000FC4")]
	[Address(RVA = "0x87B950", Offset = "0x87A950", VA = "0x18087B950", Slot = "20")]
	public override void ModifyMesh(VertexHelper verts)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FC5")]
	[Address(RVA = "0x4429E0", Offset = "0x4419E0", VA = "0x1804429E0")]
	public UIFlippable()
	{
	}
}
