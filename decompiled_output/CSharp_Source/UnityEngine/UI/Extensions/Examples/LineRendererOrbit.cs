using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000291")]
[RequireComponent(typeof(UILineRenderer))]
public class LineRendererOrbit : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DD6")]
	private UILineRenderer pny;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DD7")]
	private Circle pnz;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DD8")]
	public GameObject OrbitGO;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001DD9")]
	private RectTransform poa;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001DDA")]
	private float pob;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001DDB")]
	[SerializeField]
	private float _xAxis = 3f;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001DDC")]
	[SerializeField]
	private float _yAxis = 3f;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001DDD")]
	[SerializeField]
	private int _steps = 10;

	[Token(Token = "0x17000134")]
	public float pyv
	{
		[Token(Token = "0x6001406")]
		[Address(RVA = "0x442C90", Offset = "0x441C90", VA = "0x180442C90")]
		get
		{
			return _xAxis;
		}
		[Token(Token = "0x6001407")]
		[Address(RVA = "0x442F00", Offset = "0x441F00", VA = "0x180442F00")]
		set
		{
			_xAxis = value;
			fjg();
		}
	}

	[Token(Token = "0x17000135")]
	public float pyw
	{
		[Token(Token = "0x6001408")]
		[Address(RVA = "0x442CB0", Offset = "0x441CB0", VA = "0x180442CB0")]
		get
		{
			return _yAxis;
		}
		[Token(Token = "0x6001409")]
		[Address(RVA = "0x442F10", Offset = "0x441F10", VA = "0x180442F10")]
		set
		{
			_yAxis = value;
			fjg();
		}
	}

	[Token(Token = "0x17000136")]
	public int pyx
	{
		[Token(Token = "0x600140A")]
		[Address(RVA = "0x442CD0", Offset = "0x441CD0", VA = "0x180442CD0")]
		get
		{
			return _steps;
		}
		[Token(Token = "0x600140B")]
		[Address(RVA = "0x442F20", Offset = "0x441F20", VA = "0x180442F20")]
		set
		{
			_steps = value;
			fjg();
		}
	}

	[Token(Token = "0x600140C")]
	[Address(RVA = "0x442E00", Offset = "0x441E00", VA = "0x180442E00")]
	private void Awake()
	{
		UILineRenderer component = GetComponent<UILineRenderer>();
		GameObject orbitGO = OrbitGO;
		pny = component;
		RectTransform component2 = orbitGO.GetComponent<RectTransform>();
		poa = component2;
		fjg();
	}

	[Token(Token = "0x600140D")]
	[Address(RVA = "0x442BC0", Offset = "0x441BC0", VA = "0x180442BC0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600140E")]
	[Address(RVA = "0x442F30", Offset = "0x441F30", VA = "0x180442F30")]
	private void fjg()
	{
		//IL_006a: Expected F4, but got I4
		float xAxis = _xAxis;
		float yAxis = _yAxis;
		int steps = _steps;
		Circle circle = new Circle(xAxis, yAxis, steps);
		int num = 0;
		pnz = circle;
		List<Vector2> list = (List<Vector2>)(object)new List<T>();
		if (_steps > num)
		{
			Vector2 item = pnz.fac(xAxis);
			((List<T>)(object)list).Add((T)item);
			num++;
		}
		Circle circle2 = pnz;
		int num2 = 0;
		Vector2 item2 = circle2.fac(num2);
		((List<T>)(object)list).Add((T)item2);
		UILineRenderer uILineRenderer = pny;
		Vector2[] value = (Vector2[])(object)((List<T>)(object)list).ToArray();
		uILineRenderer.pvv = value;
	}

	[Token(Token = "0x600140F")]
	[Address(RVA = "0x442E80", Offset = "0x441E80", VA = "0x180442E80")]
	private void OnValidate()
	{
		//IL_0010: Expected Obj, but got I4
		UILineRenderer uILineRenderer = pny;
		int num = 0;
		if (uILineRenderer != (Object)num)
		{
			fjg();
		}
	}

	[Token(Token = "0x6001410")]
	[Address(RVA = "0x442C70", Offset = "0x441C70", VA = "0x180442C70")]
	public LineRendererOrbit()
	{
		//IL_0020: Expected I4, but got I8
	}
}
