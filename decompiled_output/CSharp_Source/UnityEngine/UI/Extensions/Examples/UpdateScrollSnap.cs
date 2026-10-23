using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000288")]
public class UpdateScrollSnap : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DB8")]
	public HorizontalScrollSnap HSS;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DB9")]
	public VerticalScrollSnap VSS;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DBA")]
	public GameObject HorizontalPagePrefab;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001DBB")]
	public GameObject VerticalPagePrefab;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001DBC")]
	public InputField JumpPage;

	[Token(Token = "0x60013E4")]
	[Address(RVA = "0x42E5F0", Offset = "0x42D5F0", VA = "0x18042E5F0")]
	public void fio()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013E5")]
	[Address(RVA = "0x42E830", Offset = "0x42D830", VA = "0x18042E830")]
	public void fip()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013E6")]
	[Address(RVA = "0x42E950", Offset = "0x42D950", VA = "0x18042E950")]
	public void fiq()
	{
		int screenIndex = int.Parse(JumpPage.m_Text);
		if ((bool)HSS)
		{
			HSS.eqf(screenIndex);
		}
		if ((bool)VSS)
		{
			VSS.eqf(screenIndex);
		}
	}

	[Token(Token = "0x60013E7")]
	[Address(RVA = "0x42EA40", Offset = "0x42DA40", VA = "0x18042EA40")]
	public void fir()
	{
		Debug.Log("Scroll Snap change started");
	}

	[Token(Token = "0x60013E8")]
	[Address(RVA = "0x42EAA0", Offset = "0x42DAA0", VA = "0x18042EAA0")]
	public void fis()
	{
		Debug.Log("Scroll Snap change finished");
	}

	[Token(Token = "0x60013E9")]
	[Address(RVA = "0x42EB00", Offset = "0x42DB00", VA = "0x18042EB00")]
	public void fit(int page)
	{
		Debug.Log(string.Format("Scroll Snap page changed to {0}", "Scroll Snap page changed to {0}"));
	}

	[Token(Token = "0x60013EA")]
	[Address(RVA = "0x42EBA0", Offset = "0x42DBA0", VA = "0x18042EBA0")]
	public void fiu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60013EB")]
	[Address(RVA = "0x42EBF0", Offset = "0x42DBF0", VA = "0x18042EBF0")]
	public void fiv(int page)
	{
		HSS.eqf(page);
	}

	[Token(Token = "0x60013EC")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public UpdateScrollSnap()
	{
	}
}
