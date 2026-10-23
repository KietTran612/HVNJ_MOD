using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000273")]
public class Example01ScrollView : FancyScrollView<qs>
{
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001D85")]
	[SerializeField]
	private ScrollPositionController scrollPositionController;

	[Token(Token = "0x6001397")]
	[Address(RVA = "0x69F350", Offset = "0x69E350", VA = "0x18069F350")]
	private void Awake()
	{
		ScrollPositionController scrollPositionController = this.scrollPositionController;
		Action<float> pbg = (Action<float>)(object)(Action<T>)([Token(Token = "0x600139A")] [Address(RVA = "0x69F4A0", Offset = "0x69E4A0", VA = "0x18069F4A0")] (float p) =>
		{
			int forceUpdateContents = 0;
			emw(p, (byte)forceUpdateContents != 0);
		});
		scrollPositionController.pbg = pbg;
	}

	[Token(Token = "0x6001398")]
	[Address(RVA = "0x69F430", Offset = "0x69E430", VA = "0x18069F430")]
	public void fho(List<qs> data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001399")]
	[Address(RVA = "0x69F3F0", Offset = "0x69E3F0", VA = "0x18069F3F0")]
	public Example01ScrollView()
	{
		((FancyScrollView<TData>)(object)this)._002Ector();
	}

	[Token(Token = "0x600139A")]
	[Address(RVA = "0x69F4A0", Offset = "0x69E4A0", VA = "0x18069F4A0")]
	[CompilerGenerated]
	private void fhp(float p)
	{
		int forceUpdateContents = 0;
		emw(p, (byte)forceUpdateContents != 0);
	}
}
