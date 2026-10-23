using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001C6")]
[RequireComponent(typeof(Text), typeof(RectTransform))]
[AddComponentMenu("UI/Effects/Extensions/Curved Text")]
public class CurvedText : BaseMeshEffect
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A32")]
	[SerializeField]
	private AnimationCurve _curveForText = AnimationCurve.Linear(0f, 0f, 1f, 10f);

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001A33")]
	[SerializeField]
	private float _curveMultiplier = 1f;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001A34")]
	private RectTransform oxd;

	[Token(Token = "0x1700007F")]
	public AnimationCurve psr
	{
		[Token(Token = "0x6000F4A")]
		[Address(RVA = "0x27CB90", Offset = "0x27BB90", VA = "0x18027CB90")]
		get
		{
			return _curveForText;
		}
		[Token(Token = "0x6000F4B")]
		[Address(RVA = "0x699B10", Offset = "0x698B10", VA = "0x180699B10")]
		set
		{
			_curveForText = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x17000080")]
	public float pss
	{
		[Token(Token = "0x6000F4C")]
		[Address(RVA = "0x48B430", Offset = "0x48A430", VA = "0x18048B430")]
		get
		{
			return _curveMultiplier;
		}
		[Token(Token = "0x6000F4D")]
		[Address(RVA = "0x699B50", Offset = "0x698B50", VA = "0x180699B50")]
		set
		{
			_curveMultiplier = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x6000F4E")]
	[Address(RVA = "0x6996B0", Offset = "0x6986B0", VA = "0x1806996B0", Slot = "4")]
	protected override void Awake()
	{
		((object)this)._002Ector();
		RectTransform component = GetComponent<RectTransform>();
		oxd = component;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6000F4F")]
	[Address(RVA = "0x699910", Offset = "0x698910", VA = "0x180699910", Slot = "5")]
	protected override void OnEnable()
	{
		base.OnEnable();
		RectTransform component = GetComponent<RectTransform>();
		oxd = component;
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6000F50")]
	[Address(RVA = "0x699710", Offset = "0x698710", VA = "0x180699710", Slot = "20")]
	public override void ModifyMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F51")]
	[Address(RVA = "0x699970", Offset = "0x698970", VA = "0x180699970", Slot = "10")]
	protected override void OnRectTransformDimensionsChange()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F52")]
	[Address(RVA = "0x699AC0", Offset = "0x698AC0", VA = "0x180699AC0")]
	public CurvedText()
	{
		//IL_0013: Expected F4, but got I4
		//IL_0013: Expected F4, but got I4
	}
}
