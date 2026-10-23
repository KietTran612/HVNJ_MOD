using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000183")]
[RequireComponent(typeof(VerticalLayoutGroup), typeof(ContentSizeFitter), typeof(ToggleGroup))]
[AddComponentMenu("UI/Extensions/Accordion/Accordion Group")]
public class Accordion : MonoBehaviour
{
	[Token(Token = "0x2000184")]
	public enum nw
	{
		[Token(Token = "0x40018D2")]
		Instant,
		[Token(Token = "0x40018D3")]
		Tween
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40018CF")]
	[SerializeField]
	private nw m_Transition;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x40018D0")]
	[SerializeField]
	private float m_TransitionDuration = 0.3f;

	[Token(Token = "0x17000020")]
	public nw ppi
	{
		[Token(Token = "0x6000D7E")]
		[Address(RVA = "0x274B10", Offset = "0x273B10", VA = "0x180274B10")]
		get
		{
			return m_Transition;
		}
		[Token(Token = "0x6000D7F")]
		[Address(RVA = "0x56E3F0", Offset = "0x56D3F0", VA = "0x18056E3F0")]
		set
		{
			m_Transition = value;
		}
	}

	[Token(Token = "0x17000021")]
	public float ppj
	{
		[Token(Token = "0x6000D80")]
		[Address(RVA = "0x428ED0", Offset = "0x427ED0", VA = "0x180428ED0")]
		get
		{
			return m_TransitionDuration;
		}
		[Token(Token = "0x6000D81")]
		[Address(RVA = "0x5FD310", Offset = "0x5FC310", VA = "0x1805FD310")]
		set
		{
			m_TransitionDuration = value;
		}
	}

	[Token(Token = "0x6000D82")]
	[Address(RVA = "0x5FD300", Offset = "0x5FC300", VA = "0x1805FD300")]
	public Accordion()
	{
	}
}
