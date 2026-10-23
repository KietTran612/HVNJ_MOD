using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000278")]
public class Example02ScrollView : FancyScrollView<qt, qu>
{
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001D8E")]
	[SerializeField]
	private ScrollPositionController scrollPositionController;

	[Token(Token = "0x60013A6")]
	[Address(RVA = "0x69FA30", Offset = "0x69EA30", VA = "0x18069FA30")]
	private void Awake()
	{
		ScrollPositionController scrollPositionController = this.scrollPositionController;
		Action<float> pbg = (Action<float>)(object)(Action<T>)([Token(Token = "0x60013AA")] [Address(RVA = "0x69FCB0", Offset = "0x69ECB0", VA = "0x18069FCB0")] (float p) =>
		{
			int forceUpdateContents = 0;
			emw(p, (byte)forceUpdateContents != 0);
		});
		scrollPositionController.pbg = pbg;
		qu qu2 = new qu();
		Action<Example02ScrollViewCell> pmw = (Action<Example02ScrollViewCell>)(object)new Action<T>(fhs);
		qu2.pmw = pmw;
		emu((TContext)(object)qu2);
	}

	[Token(Token = "0x60013A7")]
	[Address(RVA = "0x69FBA0", Offset = "0x69EBA0", VA = "0x18069FBA0")]
	public void fhr(List<qt> data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013A8")]
	[Address(RVA = "0x69FC10", Offset = "0x69EC10", VA = "0x18069FC10")]
	private void fhs(Example02ScrollViewCell cell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013A9")]
	[Address(RVA = "0x69FB60", Offset = "0x69EB60", VA = "0x18069FB60")]
	public Example02ScrollView()
	{
		((FancyScrollView<TData, TContext>)(object)this)._002Ector();
	}

	[Token(Token = "0x60013AA")]
	[Address(RVA = "0x69FCB0", Offset = "0x69ECB0", VA = "0x18069FCB0")]
	[CompilerGenerated]
	private void fht(float p)
	{
		int forceUpdateContents = 0;
		emw(p, (byte)forceUpdateContents != 0);
	}
}
