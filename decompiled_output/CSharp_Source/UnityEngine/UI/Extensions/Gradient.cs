using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001C8")]
[AddComponentMenu("UI/Effects/Extensions/Gradient")]
public class Gradient : BaseMeshEffect
{
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A36")]
	[SerializeField]
	private oo _gradientMode;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001A37")]
	[SerializeField]
	private op _gradientDir;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001A38")]
	[SerializeField]
	private bool _overwriteAllColor;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4001A39")]
	[SerializeField]
	private Color _vertex1;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001A3A")]
	[SerializeField]
	private Color _vertex2;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001A3B")]
	private Graphic oxe;

	[Token(Token = "0x17000081")]
	public oo pst
	{
		[Token(Token = "0x6000F57")]
		[Address(RVA = "0x335BE0", Offset = "0x334BE0", VA = "0x180335BE0")]
		get
		{
			return _gradientMode;
		}
		[Token(Token = "0x6000F58")]
		[Address(RVA = "0x6A6880", Offset = "0x6A5880", VA = "0x1806A6880")]
		set
		{
			_gradientMode = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x17000082")]
	public op psu
	{
		[Token(Token = "0x6000F59")]
		[Address(RVA = "0x335C20", Offset = "0x334C20", VA = "0x180335C20")]
		get
		{
			return _gradientDir;
		}
		[Token(Token = "0x6000F5A")]
		[Address(RVA = "0x6A6800", Offset = "0x6A5800", VA = "0x1806A6800")]
		set
		{
			_gradientDir = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x17000083")]
	public bool psv
	{
		[Token(Token = "0x6000F5B")]
		[Address(RVA = "0x3EF600", Offset = "0x3EE600", VA = "0x1803EF600")]
		get
		{
			return _overwriteAllColor;
		}
		[Token(Token = "0x6000F5C")]
		[Address(RVA = "0x6A68C0", Offset = "0x6A58C0", VA = "0x1806A68C0")]
		set
		{
			_overwriteAllColor = value;
			TypeCode typeCode = ((IConvertible)graphic).GetTypeCode();
		}
	}

	[Token(Token = "0x17000084")]
	public Color psw
	{
		[Token(Token = "0x6000F5D")]
		[Address(RVA = "0x6A95F0", Offset = "0x6A85F0", VA = "0x1806A95F0")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000F5E")]
		[Address(RVA = "0x6A9600", Offset = "0x6A8600", VA = "0x1806A9600")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000085")]
	public Color psx
	{
		[Token(Token = "0x6000F5F")]
		[Address(RVA = "0x6A9640", Offset = "0x6A8640", VA = "0x1806A9640")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6000F60")]
		[Address(RVA = "0x6A9650", Offset = "0x6A8650", VA = "0x1806A9650")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x6000F61")]
	[Address(RVA = "0x6A8DA0", Offset = "0x6A7DA0", VA = "0x1806A8DA0", Slot = "4")]
	protected override void Awake()
	{
		Graphic component = GetComponent<Graphic>();
		oxe = component;
	}

	[Token(Token = "0x6000F62")]
	[Address(RVA = "0x6A8DE0", Offset = "0x6A7DE0", VA = "0x1806A8DE0", Slot = "20")]
	public override void ModifyMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F63")]
	[Address(RVA = "0x6A9690", Offset = "0x6A8690", VA = "0x1806A9690")]
	private bool eil(Color col1, Color col2)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000F64")]
	[Address(RVA = "0x6A95B0", Offset = "0x6A85B0", VA = "0x1806A95B0")]
	public Gradient()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
