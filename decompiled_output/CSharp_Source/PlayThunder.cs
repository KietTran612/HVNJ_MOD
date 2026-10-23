using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000009")]
public class PlayThunder : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4000022")]
	private AudioSource fki;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000023")]
	public AudioClip source;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000024")]
	private ParticleSystem fkj;

	[Token(Token = "0x6000033")]
	[Address(RVA = "0x448F20", Offset = "0x447F20", VA = "0x180448F20")]
	private void Start()
	{
		AudioSource component = gameObject.GetComponent<AudioSource>();
		fki = component;
		ParticleSystem component2 = gameObject.GetComponent<ParticleSystem>();
		fkj = component2;
	}

	[Token(Token = "0x6000034")]
	[Address(RVA = "0x448FB0", Offset = "0x447FB0", VA = "0x180448FB0")]
	private void Update()
	{
		float time = fkj.time;
		if (!fki.isPlaying)
		{
			AudioSource audioSource = fki;
			AudioClip clip = source;
			audioSource.clip = clip;
			fki.volume = 0.025f;
			fki.Play();
			AudioSource audioSource2 = fki;
			int loop = 0;
			audioSource2.loop = (byte)loop != 0;
		}
	}

	[Token(Token = "0x6000035")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public PlayThunder()
	{
	}
}
