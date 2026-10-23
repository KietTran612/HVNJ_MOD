using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x20000C6")]
public class TextOutline : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000B24")]
	public float pixelSize;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4000B25")]
	public Color outlineColor;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4000B26")]
	public bool resolutionDependant;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000B27")]
	public int doubleResolution;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000B28")]
	private TextMesh jmp;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000B29")]
	private MeshRenderer jmq;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000B2A")]
	private MeshRenderer[] jmr;

	[Token(Token = "0x60005B4")]
	[Address(RVA = "0x4921B0", Offset = "0x4911B0", VA = "0x1804921B0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005B5")]
	[Address(RVA = "0x491CC0", Offset = "0x490CC0", VA = "0x180491CC0")]
	private void LateUpdate()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005B6")]
	[Address(RVA = "0x492620", Offset = "0x491620", VA = "0x180492620")]
	private Vector3 bvz(int i)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60005B7")]
	[Address(RVA = "0x4925E0", Offset = "0x4915E0", VA = "0x1804925E0")]
	public TextOutline()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
