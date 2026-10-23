using Cpp2IlInjected;

namespace UnityEngine.UI;

[Token(Token = "0x200017A")]
public class CustomOutlineText : Shadow
{
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40018B4")]
	[Range(0f, 15f)]
	public float m_size = 3f;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x40018B5")]
	public bool glintEffect;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x40018B6")]
	[Range(0f, 5f)]
	public int glintVertex;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x40018B7")]
	[Range(0f, 3f)]
	public int glintWidth;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x40018B8")]
	public Color glintColor;

	[Token(Token = "0x6000D4E")]
	[Address(RVA = "0x699B90", Offset = "0x698B90", VA = "0x180699B90", Slot = "20")]
	public override void ModifyMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000D4F")]
	[Address(RVA = "0x69A120", Offset = "0x699120", VA = "0x18069A120")]
	public CustomOutlineText()
	{
	}
}
