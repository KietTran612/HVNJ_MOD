using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001CF")]
[AddComponentMenu("UI/Effects/Extensions/Letter Spacing")]
public class LetterSpacing : BaseMeshEffect
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A56")]
	[SerializeField]
	private float m_spacing;

	[Token(Token = "0x1700008C")]
	public float pte
	{
		[Token(Token = "0x6000F7E")]
		[Address(RVA = "0x4429F0", Offset = "0x4419F0", VA = "0x1804429F0")]
		get
		{
			return m_spacing;
		}
		[Token(Token = "0x6000F7F")]
		[Address(RVA = "0x442A00", Offset = "0x441A00", VA = "0x180442A00")]
		set
		{
			//IL_0017: Expected Obj, but got I4
			m_spacing = value;
			Graphic graphic = base.graphic;
			int num = 0;
			if (graphic != (Object)num)
			{
				base.graphic.SetVerticesDirty();
			}
		}
	}

	[Token(Token = "0x6000F7D")]
	[Address(RVA = "0x4429E0", Offset = "0x4419E0", VA = "0x1804429E0")]
	protected LetterSpacing()
	{
	}

	[Token(Token = "0x6000F80")]
	[Address(RVA = "0x441E10", Offset = "0x440E10", VA = "0x180441E10", Slot = "20")]
	public override void ModifyMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
