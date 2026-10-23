using System;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
[Token(Token = "0x2000175")]
public class ColorChangedEvent : UnityEvent<Color>
{
	[Token(Token = "0x6000D2E")]
	[Address(RVA = "0x60DF80", Offset = "0x60CF80", VA = "0x18060DF80")]
	public ColorChangedEvent()
	{
		((UnityEvent<T0>)(object)this)._002Ector();
	}
}
