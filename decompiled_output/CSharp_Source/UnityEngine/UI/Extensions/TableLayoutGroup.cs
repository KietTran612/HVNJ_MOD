using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000207")]
[AddComponentMenu("Layout/Extensions/Table Layout Group")]
public class TableLayoutGroup : LayoutGroup
{
	[Token(Token = "0x2000208")]
	public enum pe
	{
		[Token(Token = "0x4001B96")]
		UpperLeft,
		[Token(Token = "0x4001B97")]
		UpperRight,
		[Token(Token = "0x4001B98")]
		LowerLeft,
		[Token(Token = "0x4001B99")]
		LowerRight
	}

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001B8E")]
	[SerializeField]
	protected pe startCorner;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001B8F")]
	[SerializeField]
	protected float[] columnWidths = new float[1] { 1.1198792E+09f };

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001B90")]
	[SerializeField]
	protected float minimumRowHeight = 32f;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4001B91")]
	[SerializeField]
	protected bool flexibleRowHeight = true;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001B92")]
	[SerializeField]
	protected float columnSpacing;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001B93")]
	[SerializeField]
	protected float rowSpacing;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001B94")]
	private float[] pdk;

	[Token(Token = "0x170000B4")]
	public pe pup
	{
		[Token(Token = "0x60010D5")]
		[Address(RVA = "0x48F380", Offset = "0x48E380", VA = "0x18048F380")]
		get
		{
			return startCorner;
		}
		[Token(Token = "0x60010D6")]
		[Address(RVA = "0x48F390", Offset = "0x48E390", VA = "0x18048F390")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000B5")]
	public float[] puq
	{
		[Token(Token = "0x60010D7")]
		[Address(RVA = "0x3EFA30", Offset = "0x3EEA30", VA = "0x1803EFA30")]
		get
		{
			return columnWidths;
		}
		[Token(Token = "0x60010D8")]
		[Address(RVA = "0x48F3E0", Offset = "0x48E3E0", VA = "0x18048F3E0")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000B6")]
	public float pur
	{
		[Token(Token = "0x60010D9")]
		[Address(RVA = "0x48F430", Offset = "0x48E430", VA = "0x18048F430")]
		get
		{
			return minimumRowHeight;
		}
		[Token(Token = "0x60010DA")]
		[Address(RVA = "0x48F440", Offset = "0x48E440", VA = "0x18048F440")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000B7")]
	public bool pus
	{
		[Token(Token = "0x60010DB")]
		[Address(RVA = "0x48F490", Offset = "0x48E490", VA = "0x18048F490")]
		get
		{
			return flexibleRowHeight;
		}
		[Token(Token = "0x60010DC")]
		[Address(RVA = "0x48F4A0", Offset = "0x48E4A0", VA = "0x18048F4A0")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000B8")]
	public float put
	{
		[Token(Token = "0x60010DD")]
		[Address(RVA = "0x48F4F0", Offset = "0x48E4F0", VA = "0x18048F4F0")]
		get
		{
			return columnSpacing;
		}
		[Token(Token = "0x60010DE")]
		[Address(RVA = "0x48F500", Offset = "0x48E500", VA = "0x18048F500")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x170000B9")]
	public float puu
	{
		[Token(Token = "0x60010DF")]
		[Address(RVA = "0x48F550", Offset = "0x48E550", VA = "0x18048F550")]
		get
		{
			return rowSpacing;
		}
		[Token(Token = "0x60010E0")]
		[Address(RVA = "0x48F560", Offset = "0x48E560", VA = "0x18048F560")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x60010E1")]
	[Address(RVA = "0x48E9E0", Offset = "0x48D9E0", VA = "0x18048E9E0", Slot = "28")]
	public override void CalculateLayoutInputHorizontal()
	{
		//IL_0057: Expected F4, but got I4
		//IL_0057: Expected F4, but got I4
		//IL_0057: Expected F4, but got Obj
		base.CalculateLayoutInputHorizontal();
		int horizontal = m_Padding.horizontal;
		List<RectTransform> list = base.m_RectChildren;
		int length = columnWidths.Length;
		int num = Mathf.Min(((List<>)(object)list)._size, length);
		int num2 = 0;
		float[] array = default;
		if (num > 0)
		{
			array = columnWidths;
			num2++;
		}
		int num3 = 0;
		SetLayoutInputForAxis((float)array, num, num3, num2);
	}

	[Token(Token = "0x60010E2")]
	[Address(RVA = "0x48EAD0", Offset = "0x48DAD0", VA = "0x18048EAD0", Slot = "29")]
	public override void CalculateLayoutInputVertical()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010E3")]
	[Address(RVA = "0x48EDB0", Offset = "0x48DDB0", VA = "0x18048EDB0", Slot = "37")]
	public override void SetLayoutHorizontal()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010E4")]
	[Address(RVA = "0x48F040", Offset = "0x48E040", VA = "0x18048F040", Slot = "38")]
	public override void SetLayoutVertical()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60010E5")]
	[Address(RVA = "0x48F300", Offset = "0x48E300", VA = "0x18048F300")]
	public TableLayoutGroup()
	{
		//IL_0015: Expected F4, but got I8
	}
}
