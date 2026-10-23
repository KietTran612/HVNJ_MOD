using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000160")]
public class waterFrameObj : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001771")]
	private SpriteRenderer odp;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001772")]
	public sbyte index;

	[FieldOffset(Offset = "0x21")]
	[Token(Token = "0x4001773")]
	public sbyte count;

	[Token(Token = "0x4001774")]
	private static sbyte odq;

	[Token(Token = "0x6000C07")]
	[Address(RVA = "0x284020", Offset = "0x283020", VA = "0x180284020")]
	private void Start()
	{
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		odp = component;
		sbyte b = odq;
		index = b;
		int length = ka.lls.Length;
	}

	[Token(Token = "0x6000C08")]
	[Address(RVA = "0x283F00", Offset = "0x282F00", VA = "0x180283F00")]
	private void FixedUpdate()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C09")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public waterFrameObj()
	{
	}
}
