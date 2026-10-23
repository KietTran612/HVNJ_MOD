using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200015F")]
public class DeleteObj : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001770")]
	public int time;

	[Token(Token = "0x6000C04")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C05")]
	[Address(RVA = "0x69AEB0", Offset = "0x699EB0", VA = "0x18069AEB0")]
	private void Update()
	{
		int num = time;
		if (num > 0)
		{
			time = num;
			if (num == 0)
			{
				Object.Destroy(gameObject);
			}
		}
	}

	[Token(Token = "0x6000C06")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public DeleteObj()
	{
	}
}
