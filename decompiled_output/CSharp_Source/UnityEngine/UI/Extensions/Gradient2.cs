using System;
using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001CB")]
[AddComponentMenu("UI/Effects/Extensions/Gradient2")]
public class Gradient2 : BaseMeshEffect
{
	[Token(Token = "0x20001CC")]
	public enum oq
	{
		[Token(Token = "0x4001A4B")]
		Horizontal,
		[Token(Token = "0x4001A4C")]
		Vertical,
		[Token(Token = "0x4001A4D")]
		Radial,
		[Token(Token = "0x4001A4E")]
		Diamond
	}

	[Token(Token = "0x20001CD")]
	public enum or
	{
		[Token(Token = "0x4001A50")]
		Override,
		[Token(Token = "0x4001A51")]
		Add,
		[Token(Token = "0x4001A52")]
		Multiply
	}

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A44")]
	[SerializeField]
	private oq _gradientType;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001A45")]
	[SerializeField]
	private or _blendMode;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001A46")]
	[SerializeField]
	[Tooltip("Add vertices to display complex gradients. Turn off if your shape is already very complex, like text.")]
	private bool _modifyVertices;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4001A47")]
	[SerializeField]
	[Range(-1f, 1f)]
	private float _offset;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001A48")]
	[SerializeField]
	[Range(0.1f, 10f)]
	private float _zoom;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001A49")]
	[SerializeField]
	private UnityEngine.Gradient _effectGradient;

	[Token(Token = "0x17000086")]
	public or psy
	{
		[Token(Token = "0x6000F65")]
		[Address(RVA = "0x335C20", Offset = "0x334C20", VA = "0x180335C20")]
		get
		{
			return _blendMode;
		}
		[Token(Token = "0x6000F66")]
		[Address(RVA = "0x6A6800", Offset = "0x6A5800", VA = "0x1806A6800")]
		set
		{
			_blendMode = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x17000087")]
	public UnityEngine.Gradient psz
	{
		[Token(Token = "0x6000F67")]
		[Address(RVA = "0x375280", Offset = "0x374280", VA = "0x180375280")]
		get
		{
			return _effectGradient;
		}
		[Token(Token = "0x6000F68")]
		[Address(RVA = "0x6A6840", Offset = "0x6A5840", VA = "0x1806A6840")]
		set
		{
			_effectGradient = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x17000088")]
	public oq pta
	{
		[Token(Token = "0x6000F69")]
		[Address(RVA = "0x335BE0", Offset = "0x334BE0", VA = "0x180335BE0")]
		get
		{
			return _gradientType;
		}
		[Token(Token = "0x6000F6A")]
		[Address(RVA = "0x6A6880", Offset = "0x6A5880", VA = "0x1806A6880")]
		set
		{
			_gradientType = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x17000089")]
	public bool ptb
	{
		[Token(Token = "0x6000F6B")]
		[Address(RVA = "0x3EF600", Offset = "0x3EE600", VA = "0x1803EF600")]
		get
		{
			return _modifyVertices;
		}
		[Token(Token = "0x6000F6C")]
		[Address(RVA = "0x6A68C0", Offset = "0x6A58C0", VA = "0x1806A68C0")]
		set
		{
			_modifyVertices = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x1700008A")]
	public float ptc
	{
		[Token(Token = "0x6000F6D")]
		[Address(RVA = "0x516140", Offset = "0x515140", VA = "0x180516140")]
		get
		{
			return _offset;
		}
		[Token(Token = "0x6000F6E")]
		[Address(RVA = "0x6A6900", Offset = "0x6A5900", VA = "0x1806A6900")]
		set
		{
			_offset = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x1700008B")]
	public float ptd
	{
		[Token(Token = "0x6000F6F")]
		[Address(RVA = "0x60EF40", Offset = "0x60DF40", VA = "0x18060EF40")]
		get
		{
			return _zoom;
		}
		[Token(Token = "0x6000F70")]
		[Address(RVA = "0x6A6940", Offset = "0x6A5940", VA = "0x1806A6940")]
		set
		{
			_zoom = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x6000F71")]
	[Address(RVA = "0x6A51E0", Offset = "0x6A41E0", VA = "0x1806A51E0", Slot = "20")]
	public override void ModifyMesh(VertexHelper helper)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F72")]
	[Address(RVA = "0x6A6980", Offset = "0x6A5980", VA = "0x1806A6980")]
	private Rect eja(List<UIVertex> vertices)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F73")]
	[Address(RVA = "0x6A6B50", Offset = "0x6A5B50", VA = "0x1806A6B50")]
	private void ejb(List<UIVertex> _vertexList, Rect bounds, float zoomOffset, VertexHelper helper)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F74")]
	[Address(RVA = "0x6A8420", Offset = "0x6A7420", VA = "0x1806A8420")]
	private float[] ejc(List<UIVertex> _vertexList, int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F75")]
	[Address(RVA = "0x6A8640", Offset = "0x6A7640", VA = "0x1806A8640")]
	private List<float> ejd(float zoomOffset, Rect bounds)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F76")]
	[Address(RVA = "0x6A89D0", Offset = "0x6A79D0", VA = "0x1806A89D0")]
	private UIVertex eje(UIVertex vertex1, UIVertex vertex2, float stop)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F77")]
	[Address(RVA = "0x6A8D10", Offset = "0x6A7D10", VA = "0x1806A8D10")]
	private Color ejf(Color colorA, Color colorB)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F78")]
	[Address(RVA = "0x6A6680", Offset = "0x6A5680", VA = "0x1806A6680")]
	public Gradient2()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
