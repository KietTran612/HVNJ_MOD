using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001D0")]
[AddComponentMenu("UI/Effects/Extensions/Mono Spacing")]
[RequireComponent(typeof(Text))]
[RequireComponent(typeof(RectTransform))]
public class MonoSpacing : BaseMeshEffect
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A57")]
	[SerializeField]
	private float m_spacing;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001A58")]
	public float HalfCharWidth = 1f;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001A59")]
	public bool UseHalfCharWidth;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001A5A")]
	private RectTransform oxf;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001A5B")]
	private Text oxg;

	[Token(Token = "0x1700008D")]
	public float ptf
	{
		[Token(Token = "0x6000F83")]
		[Address(RVA = "0x4429F0", Offset = "0x4419F0", VA = "0x1804429F0")]
		get
		{
			return m_spacing;
		}
		[Token(Token = "0x6000F84")]
		[Address(RVA = "0x446FE0", Offset = "0x445FE0", VA = "0x180446FE0")]
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

	[Token(Token = "0x6000F81")]
	[Address(RVA = "0x446FD0", Offset = "0x445FD0", VA = "0x180446FD0")]
	protected MonoSpacing()
	{
	}

	[Token(Token = "0x6000F82")]
	[Address(RVA = "0x446320", Offset = "0x445320", VA = "0x180446320", Slot = "4")]
	protected override void Awake()
	{
		//IL_0017: Expected Obj, but got I4
		Text text = (oxg = GetComponent<Text>());
		int num = 0;
		if (!(text == (Object)num))
		{
			RectTransform component = oxg.GetComponent<RectTransform>();
			oxf = component;
		}
		else
		{
			Debug.LogWarning("MonoSpacing: Missing Text component");
		}
	}

	[Token(Token = "0x6000F85")]
	[Address(RVA = "0x446420", Offset = "0x445420", VA = "0x180446420", Slot = "20")]
	public override void ModifyMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
