using Cpp2IlInjected;
using UnityEngine.Events;

[Token(Token = "0x2000176")]
public class HSVChangedEvent : UnityEvent<float, float, float>
{
	[Token(Token = "0x6000D2F")]
	[Address(RVA = "0x43C340", Offset = "0x43B340", VA = "0x18043C340")]
	public HSVChangedEvent()
	{
		((UnityEvent<T0, T1, T2>)(object)this)._002Ector();
	}
}
