using System;
using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001C2")]
[DisallowMultipleComponent]
[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(Graphic))]
[AddComponentMenu("UI/Effects/Extensions/Curly UI Graphic")]
public class CUIGraphic : BaseMeshEffect
{
	[Token(Token = "0x4001A22")]
	public static readonly int bottomCurveIdx;

	[Token(Token = "0x4001A23")]
	public static readonly int topCurveIdx;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A24")]
	[SerializeField]
	[Tooltip("Set true to make the curve/morph to work. Set false to quickly see the original UI.")]
	protected bool isCurved = true;

	[FieldOffset(Offset = "0x21")]
	[Token(Token = "0x4001A25")]
	[SerializeField]
	[Tooltip("Set true to dynamically change the curve according to the dynamic change of the UI layout")]
	protected bool isLockWithRatio;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001A26")]
	[SerializeField]
	[Tooltip("Pick a higher resolution to improve the quality of the curved graphic.")]
	[Range(0.01f, 30f)]
	protected float resolution = 5f;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001A27")]
	protected RectTransform oxb;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001A28")]
	[SerializeField]
	[Tooltip("Put in the Graphic you want to curve/morph here.")]
	protected Graphic uiGraphic;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001A29")]
	[SerializeField]
	[Tooltip("Put in the reference Graphic that will be used to tune the bezier curves. Think button image and text.")]
	protected CUIGraphic refCUIGraphic;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001A2A")]
	[SerializeField]
	[Tooltip("Do not touch this unless you are sure what you are doing. The curves are (re)generated automatically.")]
	protected CUIBezierCurve[] refCurves;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001A2B")]
	[HideInInspector]
	[SerializeField]
	protected Vector3_Array2D[] refCurvesControlRatioPoints;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001A2C")]
	protected List<UIVertex> oxc = (List<UIVertex>)(object)new List<T>();

	[Token(Token = "0x17000075")]
	public bool psi
	{
		[Token(Token = "0x6000F24")]
		[Address(RVA = "0x428EE0", Offset = "0x427EE0", VA = "0x180428EE0")]
		get
		{
			return isCurved;
		}
	}

	[Token(Token = "0x17000076")]
	public bool psj
	{
		[Token(Token = "0x6000F25")]
		[Address(RVA = "0x602910", Offset = "0x601910", VA = "0x180602910")]
		get
		{
			return isLockWithRatio;
		}
	}

	[Token(Token = "0x17000077")]
	public RectTransform psk
	{
		[Token(Token = "0x6000F26")]
		[Address(RVA = "0x283C00", Offset = "0x282C00", VA = "0x180283C00")]
		get
		{
			return oxb;
		}
	}

	[Token(Token = "0x17000078")]
	public Graphic psl
	{
		[Token(Token = "0x6000F27")]
		[Address(RVA = "0x374880", Offset = "0x373880", VA = "0x180374880")]
		get
		{
			return uiGraphic;
		}
	}

	[Token(Token = "0x17000079")]
	public CUIGraphic psm
	{
		[Token(Token = "0x6000F28")]
		[Address(RVA = "0x375280", Offset = "0x374280", VA = "0x180375280")]
		get
		{
			return refCUIGraphic;
		}
	}

	[Token(Token = "0x1700007A")]
	public CUIBezierCurve[] psn
	{
		[Token(Token = "0x6000F29")]
		[Address(RVA = "0x3746A0", Offset = "0x3736A0", VA = "0x1803746A0")]
		get
		{
			return refCurves;
		}
	}

	[Token(Token = "0x1700007B")]
	public Vector3_Array2D[] pso
	{
		[Token(Token = "0x6000F2A")]
		[Address(RVA = "0x40D8C0", Offset = "0x40C8C0", VA = "0x18040D8C0")]
		get
		{
			return refCurvesControlRatioPoints;
		}
	}

	[Token(Token = "0x6000F2B")]
	[Address(RVA = "0x602920", Offset = "0x601920", VA = "0x180602920")]
	protected void ehh(float _x_1, float _y_1, float _x_2, float _y_2, Vector3 _constant_1, Vector3 _contant_2, out Vector3 _x, out Vector3 _y)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F2C")]
	[Address(RVA = "0x602C70", Offset = "0x601C70", VA = "0x180602C70")]
	protected UIVertex ehi(UIVertex _a, UIVertex _b, float _time)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F2D")]
	[Address(RVA = "0x603160", Offset = "0x602160", VA = "0x180603160")]
	protected UIVertex ehj(UIVertex v_bottomLeft, UIVertex v_topLeft, UIVertex v_topRight, UIVertex v_bottomRight, float _xTime, float _yTime)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F2E")]
	[Address(RVA = "0x603470", Offset = "0x602470", VA = "0x180603470")]
	protected void ehk(List<UIVertex> _quads, int _thisQuadIdx)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F2F")]
	[Address(RVA = "0x604240", Offset = "0x603240", VA = "0x180604240")]
	protected void ehl(List<UIVertex> _verts)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F30")]
	[Address(RVA = "0x602830", Offset = "0x601830", VA = "0x180602830", Slot = "10")]
	protected override void OnRectTransformDimensionsChange()
	{
		if (isLockWithRatio)
		{
			ehr();
		}
	}

	[Token(Token = "0x6000F31")]
	[Address(RVA = "0x604990", Offset = "0x603990", VA = "0x180604990")]
	public void ehm()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F32")]
	[Address(RVA = "0x602610", Offset = "0x601610", VA = "0x180602610", Slot = "4")]
	protected override void Awake()
	{
		((object)this)._002Ector();
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6000F33")]
	[Address(RVA = "0x602800", Offset = "0x601800", VA = "0x180602800", Slot = "5")]
	protected override void OnEnable()
	{
		base.OnEnable();
		TypeCode typeCode = ((IConvertible)this).GetTypeCode();
	}

	[Token(Token = "0x6000F34")]
	[Address(RVA = "0x604D30", Offset = "0x603D30", VA = "0x180604D30", Slot = "21")]
	public virtual void ehn()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F35")]
	[Address(RVA = "0x6052C0", Offset = "0x6042C0", VA = "0x1806052C0")]
	public void eho()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F36")]
	[Address(RVA = "0x6056C0", Offset = "0x6046C0", VA = "0x1806056C0")]
	public void ehp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F37")]
	[Address(RVA = "0x602710", Offset = "0x601710", VA = "0x180602710", Slot = "19")]
	public override void ModifyMesh(Mesh _mesh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F38")]
	[Address(RVA = "0x602640", Offset = "0x601640", VA = "0x180602640", Slot = "20")]
	public override void ModifyMesh(VertexHelper _vh)
	{
		if (IsActive())
		{
			List<UIVertex> list = (List<UIVertex>)(object)new List<T>();
			_vh.GetUIVertexStream((List<>)(object)list);
			this.ehq((List<>)(object)list);
			_vh.Clear();
			_vh.AddUIVertexTriangleStream((List<>)(object)list);
		}
	}

	[Token(Token = "0x6000F39")]
	[Address(RVA = "0x6062A0", Offset = "0x6052A0", VA = "0x1806062A0", Slot = "22")]
	protected virtual void ehq(List<UIVertex> _verts)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F3A")]
	[Address(RVA = "0x606690", Offset = "0x605690", VA = "0x180606690")]
	public void ehr()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F3B")]
	[Address(RVA = "0x606970", Offset = "0x605970", VA = "0x180606970")]
	public Vector3 ehs(float _xTime, float _yTime)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F3C")]
	[Address(RVA = "0x606AE0", Offset = "0x605AE0", VA = "0x180606AE0")]
	public Vector3 eht(float _xTime, float _yTime)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F3D")]
	[Address(RVA = "0x602890", Offset = "0x601890", VA = "0x180602890")]
	public CUIGraphic()
	{
	}

	[Token(Token = "0x6000F3E")]
	[Address(RVA = "0x602840", Offset = "0x601840", VA = "0x180602840")]
	static CUIGraphic()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
