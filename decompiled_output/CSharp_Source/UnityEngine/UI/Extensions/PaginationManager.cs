using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000237")]
[AddComponentMenu("UI/Extensions/Pagination Manager")]
public class PaginationManager : ToggleGroup
{
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001C9F")]
	private List<Toggle> php;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001CA0")]
	[SerializeField]
	private ScrollSnapBase scrollSnap;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001CA1")]
	private bool phq;

	[Token(Token = "0x17000105")]
	public int pxf
	{
		[Token(Token = "0x6001249")]
		[Address(RVA = "0x448B80", Offset = "0x447B80", VA = "0x180448B80")]
		get
		{
			return scrollSnap.pda;
		}
	}

	[Token(Token = "0x600124A")]
	[Address(RVA = "0x448B70", Offset = "0x447B70", VA = "0x180448B70")]
	protected PaginationManager()
	{
	}

	[Token(Token = "0x600124B")]
	[Address(RVA = "0x4486C0", Offset = "0x4476C0", VA = "0x1804486C0", Slot = "6")]
	protected override void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600124C")]
	[Address(RVA = "0x448BA0", Offset = "0x447BA0", VA = "0x180448BA0")]
	public void fag(int pageNo)
	{
		scrollSnap.eqf(pageNo);
	}

	[Token(Token = "0x600124D")]
	[Address(RVA = "0x448BC0", Offset = "0x447BC0", VA = "0x180448BC0")]
	private void fah(Toggle target)
	{
		//IL_001e: Expected VT, but got Obj
		if (!target.m_IsOn)
		{
			List<Toggle> list = php;
			phq = true;
			int screenIndex = ((List<T>)(object)list).IndexOf((T)target);
			scrollSnap.eqf(screenIndex);
		}
	}

	[Token(Token = "0x600124E")]
	[Address(RVA = "0x448C40", Offset = "0x447C40", VA = "0x180448C40")]
	private void fai(bool toggle)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600124F")]
	[Address(RVA = "0x448D10", Offset = "0x447D10", VA = "0x180448D10")]
	private void faj(int target)
	{
		phq = true;
		scrollSnap.eqf(target);
	}

	[Token(Token = "0x6001250")]
	[Address(RVA = "0x448D40", Offset = "0x447D40", VA = "0x180448D40")]
	private void fak(int pageNo)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001251")]
	[Address(RVA = "0x448DB0", Offset = "0x447DB0", VA = "0x180448DB0")]
	private void fal(int pageNo)
	{
		phq = false;
	}
}
