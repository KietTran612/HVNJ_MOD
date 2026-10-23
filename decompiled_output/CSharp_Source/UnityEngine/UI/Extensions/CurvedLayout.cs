using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001EF")]
[AddComponentMenu("Layout/Extensions/Curved Layout")]
public class CurvedLayout : LayoutGroup
{
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001AFC")]
	public Vector3 CurveOffset;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4001AFD")]
	[Tooltip("axis along which to place the items, Normalized before use")]
	public Vector3 itemAxis;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001AFE")]
	[Tooltip("size of each item along the Normalized axis")]
	public float itemSize;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001AFF")]
	public float centerpoint = 0.5f;

	[Token(Token = "0x600102B")]
	[Address(RVA = "0x699260", Offset = "0x698260", VA = "0x180699260", Slot = "5")]
	protected override void OnEnable()
	{
		base.OnEnable();
		emr();
	}

	[Token(Token = "0x600102C")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "37")]
	public override void SetLayoutHorizontal()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600102D")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "38")]
	public override void SetLayoutVertical()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600102E")]
	[Address(RVA = "0x699250", Offset = "0x698250", VA = "0x180699250", Slot = "29")]
	public override void CalculateLayoutInputVertical()
	{
		emr();
	}

	[Token(Token = "0x600102F")]
	[Address(RVA = "0x699250", Offset = "0x698250", VA = "0x180699250", Slot = "28")]
	public override void CalculateLayoutInputHorizontal()
	{
		emr();
	}

	[Token(Token = "0x6001030")]
	[Address(RVA = "0x699290", Offset = "0x698290", VA = "0x180699290")]
	private void emr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001031")]
	[Address(RVA = "0x699280", Offset = "0x698280", VA = "0x180699280")]
	public CurvedLayout()
	{
	}
}
