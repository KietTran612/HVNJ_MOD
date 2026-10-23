using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000284")]
public class Example04ScrollView : FancyScrollView<qx, qy>
{
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001DAB")]
	[SerializeField]
	private ScrollPositionController scrollPositionController;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001DAC")]
	private Action<int> pne;

	[Token(Token = "0x60013CD")]
	[Address(RVA = "0x6A0CF0", Offset = "0x69FCF0", VA = "0x1806A0CF0")]
	private void Awake()
	{
		ScrollPositionController scrollPositionController = this.scrollPositionController;
		Action<float> pbg = (Action<float>)(object)(Action<T>)([Token(Token = "0x60013D6")] [Address(RVA = "0x6A1180", Offset = "0x6A0180", VA = "0x1806A1180")] (float p) =>
		{
			int forceUpdateContents = 0;
			emw(p, (byte)forceUpdateContents != 0);
		});
		scrollPositionController.pbg = pbg;
		ScrollPositionController scrollPositionController2 = this.scrollPositionController;
		Action<int> pbh = (Action<int>)(object)new Action<T>(fih);
		scrollPositionController2.pbh = pbh;
		qy qy2 = new qy();
		Action<Example04ScrollViewCell> pni = (Action<Example04ScrollViewCell>)(object)new Action<T>(fii);
		qy2.pni = pni;
		Action<int> pnj = (Action<int>)(object)(Action<T>)([Token(Token = "0x60013D7")] [Address(RVA = "0x6A11D0", Offset = "0x6A01D0", VA = "0x1806A11D0")] (int index) =>
		{
			//IL_0012: Expected VT, but got I4
			((Action<T>)(object)pne)?.Invoke((T)index);
		});
		qy2.pnj = pnj;
		emu((TContext)(object)qy2);
	}

	[Token(Token = "0x60013CE")]
	[Address(RVA = "0x6A0F00", Offset = "0x69FF00", VA = "0x1806A0F00")]
	public void fic(List<qx> data)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013CF")]
	[Address(RVA = "0x6A0F70", Offset = "0x69FF70", VA = "0x1806A0F70")]
	public void fid(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013D0")]
	[Address(RVA = "0x378310", Offset = "0x377310", VA = "0x180378310")]
	public void fie(Action<int> onSelectedIndexChanged)
	{
		pne = onSelectedIndexChanged;
	}

	[Token(Token = "0x60013D1")]
	[Address(RVA = "0x6A1020", Offset = "0x6A0020", VA = "0x1806A1020")]
	public void fif()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013D2")]
	[Address(RVA = "0x6A1070", Offset = "0x6A0070", VA = "0x1806A1070")]
	public void fig()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013D3")]
	[Address(RVA = "0x6A10C0", Offset = "0x6A00C0", VA = "0x1806A10C0")]
	private void fih(int selectedItemIndex)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013D4")]
	[Address(RVA = "0x6A1130", Offset = "0x6A0130", VA = "0x1806A1130")]
	private void fii(Example04ScrollViewCell cell)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013D5")]
	[Address(RVA = "0x6A0EC0", Offset = "0x69FEC0", VA = "0x1806A0EC0")]
	public Example04ScrollView()
	{
		((FancyScrollView<TData, TContext>)(object)this)._002Ector();
	}

	[Token(Token = "0x60013D6")]
	[Address(RVA = "0x6A1180", Offset = "0x6A0180", VA = "0x1806A1180")]
	[CompilerGenerated]
	private void fij(float p)
	{
		int forceUpdateContents = 0;
		emw(p, (byte)forceUpdateContents != 0);
	}

	[Token(Token = "0x60013D7")]
	[Address(RVA = "0x6A11D0", Offset = "0x6A01D0", VA = "0x1806A11D0")]
	[CompilerGenerated]
	private void fik(int index)
	{
		//IL_0012: Expected VT, but got I4
		((Action<T>)(object)pne)?.Invoke((T)index);
	}
}
