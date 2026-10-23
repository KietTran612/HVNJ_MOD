using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001F9")]
[AddComponentMenu("Layout/Extensions/Radial Layout")]
public class RadialLayout : LayoutGroup
{
	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001B18")]
	public float fDistance;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001B19")]
	[Range(0f, 360f)]
	public float MinAngle;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001B1A")]
	[Range(0f, 360f)]
	public float MaxAngle;

	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4001B1B")]
	[Range(0f, 360f)]
	public float StartAngle;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001B1C")]
	public bool OnlyLayoutVisible;

	[Token(Token = "0x600106E")]
	[Address(RVA = "0x44A660", Offset = "0x449660", VA = "0x18044A660", Slot = "5")]
	protected override void OnEnable()
	{
		base.OnEnable();
		eol();
	}

	[Token(Token = "0x600106F")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "37")]
	public override void SetLayoutHorizontal()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001070")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10", Slot = "38")]
	public override void SetLayoutVertical()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001071")]
	[Address(RVA = "0x44A650", Offset = "0x449650", VA = "0x18044A650", Slot = "29")]
	public override void CalculateLayoutInputVertical()
	{
		eol();
	}

	[Token(Token = "0x6001072")]
	[Address(RVA = "0x44A650", Offset = "0x449650", VA = "0x18044A650", Slot = "28")]
	public override void CalculateLayoutInputHorizontal()
	{
		eol();
	}

	[Token(Token = "0x6001073")]
	[Address(RVA = "0x44A690", Offset = "0x449690", VA = "0x18044A690")]
	private void eol()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001074")]
	[Address(RVA = "0x44A680", Offset = "0x449680", VA = "0x18044A680")]
	public RadialLayout()
	{
	}
}
