using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000235")]
[AddComponentMenu("Layout/Extensions/NonDrawingGraphic")]
public class NonDrawingGraphic : MaskableGraphic
{
	[Token(Token = "0x6001242")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "29")]
	public override void SetMaterialDirty()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001243")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "28")]
	public override void SetVerticesDirty()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001244")]
	[Address(RVA = "0x448520", Offset = "0x447520", VA = "0x180448520", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
	}

	[Token(Token = "0x6001245")]
	[Address(RVA = "0x3715C0", Offset = "0x3705C0", VA = "0x1803715C0")]
	public NonDrawingGraphic()
	{
	}
}
