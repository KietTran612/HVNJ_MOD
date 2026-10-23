using System;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Serializable]
[Token(Token = "0x20001BF")]
public class KnobFloatValueEvent : UnityEvent<float>
{
	[Token(Token = "0x6000F1A")]
	[Address(RVA = "0x441DD0", Offset = "0x440DD0", VA = "0x180441DD0")]
	public KnobFloatValueEvent()
	{
		((UnityEvent<T0>)(object)this)._002Ector();
	}
}
