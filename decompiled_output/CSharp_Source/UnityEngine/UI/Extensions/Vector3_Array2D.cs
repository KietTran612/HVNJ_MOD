using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Serializable]
[Token(Token = "0x20001C4")]
public struct Vector3_Array2D
{
	[FieldOffset(Offset = "0x0")]
	[Token(Token = "0x4001A31")]
	[SerializeField]
	public Vector3[] array;

	[Token(Token = "0x1700007E")]
	public Vector3 this[int _idx]
	{
		[Token(Token = "0x6000F46")]
		[Address(RVA = "0x4354E0", Offset = "0x4344E0", VA = "0x1804354E0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000F47")]
		[Address(RVA = "0x435530", Offset = "0x434530", VA = "0x180435530")]
		set
		{
			float z = value.z;
		}
	}
}
