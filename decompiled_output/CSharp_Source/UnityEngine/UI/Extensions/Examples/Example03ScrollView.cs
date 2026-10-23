using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x200027E")]
public class Example03ScrollView : FancyScrollView<qv, qw>
{
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001D9B")]
	[SerializeField]
	private ScrollPositionController scrollPositionController;

	[Token(Token = "0x60013B9")]
	[Address(RVA = "0x6A02B0", Offset = "0x69F2B0", VA = "0x1806A02B0")]
	private void Awake()
	{
		ScrollPositionController scrollPositionController = this.scrollPositionController;
		Action<float> pbg = (Action<float>)(object)(Action<T>)([Token(Token = "0x60013BD")] [Address(RVA = "0x6A0530", Offset = "0x69F530", VA = "0x1806A0530")] (float p) =>
		{
			int forceUpdateContents = 0;
			emw(p, (byte)forceUpdateContents != 0);
		});
		scrollPositionController.pbg = pbg;
		qw qw2 = new qw();
		Action<Example03ScrollViewCell> pnb = (Action<Example03ScrollViewCell>)(object)new Action<T>(fhx);
		qw2.pnb = pnb;
		emu((TContext)(object)qw2);
	}

	[Token(Token = "0x60013BA")]
	[Address(RVA = "0x6A0420", Offset = "0x69F420", VA = "0x1806A0420")]
	public void fhw(List<qv> data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013BB")]
	[Address(RVA = "0x6A0490", Offset = "0x69F490", VA = "0x1806A0490")]
	private void fhx(Example03ScrollViewCell cell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013BC")]
	[Address(RVA = "0x6A03E0", Offset = "0x69F3E0", VA = "0x1806A03E0")]
	public Example03ScrollView()
	{
		((FancyScrollView<TData, TContext>)(object)this)._002Ector();
	}

	[Token(Token = "0x60013BD")]
	[Address(RVA = "0x6A0530", Offset = "0x69F530", VA = "0x1806A0530")]
	[CompilerGenerated]
	private void fhy(float p)
	{
		int forceUpdateContents = 0;
		emw(p, (byte)forceUpdateContents != 0);
	}
}
