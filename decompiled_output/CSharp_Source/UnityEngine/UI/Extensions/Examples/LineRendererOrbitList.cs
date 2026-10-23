using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.Examples;

[Token(Token = "0x2000292")]
[RequireComponent(typeof(UILineRendererList))]
public class LineRendererOrbitList : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001DDE")]
	private UILineRendererList poc;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001DDF")]
	private Circle pod;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001DE0")]
	public GameObject OrbitGO;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001DE1")]
	private RectTransform poe;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001DE2")]
	private float pof;

	[FieldOffset(Offset = "0x3C")]
	[Token(Token = "0x4001DE3")]
	[SerializeField]
	private float _xAxis = 3f;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001DE4")]
	[SerializeField]
	private float _yAxis = 3f;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001DE5")]
	[SerializeField]
	private int _steps = 10;

	[Token(Token = "0x17000137")]
	public float pyy
	{
		[Token(Token = "0x6001411")]
		[Address(RVA = "0x442C90", Offset = "0x441C90", VA = "0x180442C90")]
		get
		{
			return _xAxis;
		}
		[Token(Token = "0x6001412")]
		[Address(RVA = "0x442CA0", Offset = "0x441CA0", VA = "0x180442CA0")]
		set
		{
			_xAxis = value;
			fjn();
		}
	}

	[Token(Token = "0x17000138")]
	public float pyz
	{
		[Token(Token = "0x6001413")]
		[Address(RVA = "0x442CB0", Offset = "0x441CB0", VA = "0x180442CB0")]
		get
		{
			return _yAxis;
		}
		[Token(Token = "0x6001414")]
		[Address(RVA = "0x442CC0", Offset = "0x441CC0", VA = "0x180442CC0")]
		set
		{
			_yAxis = value;
			fjn();
		}
	}

	[Token(Token = "0x17000139")]
	public int pza
	{
		[Token(Token = "0x6001415")]
		[Address(RVA = "0x442CD0", Offset = "0x441CD0", VA = "0x180442CD0")]
		get
		{
			return _steps;
		}
		[Token(Token = "0x6001416")]
		[Address(RVA = "0x442CE0", Offset = "0x441CE0", VA = "0x180442CE0")]
		set
		{
			_steps = value;
			fjn();
		}
	}

	[Token(Token = "0x6001417")]
	[Address(RVA = "0x442AC0", Offset = "0x441AC0", VA = "0x180442AC0")]
	private void Awake()
	{
		UILineRendererList component = GetComponent<UILineRendererList>();
		GameObject orbitGO = OrbitGO;
		poc = component;
		RectTransform component2 = orbitGO.GetComponent<RectTransform>();
		poe = component2;
		fjn();
	}

	[Token(Token = "0x6001418")]
	[Address(RVA = "0x442BC0", Offset = "0x441BC0", VA = "0x180442BC0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001419")]
	[Address(RVA = "0x442CF0", Offset = "0x441CF0", VA = "0x180442CF0")]
	private void fjn()
	{
		//IL_0077: Expected F4, but got I4
		float xAxis = _xAxis;
		float yAxis = _yAxis;
		int steps = _steps;
		Circle circle = new Circle(xAxis, yAxis, steps);
		int num = 0;
		pod = circle;
		if (_steps > num)
		{
			Circle circle2 = pod;
			UILineRendererList uILineRendererList = poc;
			Vector2 pointToAdd = circle2.fac(xAxis);
			uILineRendererList.ewb(pointToAdd);
			num++;
		}
		Circle circle3 = pod;
		UILineRendererList uILineRendererList2 = poc;
		int num2 = 0;
		Vector2 pointToAdd2 = circle3.fac(num2);
		uILineRendererList2.ewb(pointToAdd2);
	}

	[Token(Token = "0x600141A")]
	[Address(RVA = "0x442B40", Offset = "0x441B40", VA = "0x180442B40")]
	private void OnValidate()
	{
		//IL_0010: Expected Obj, but got I4
		UILineRendererList uILineRendererList = poc;
		int num = 0;
		if (uILineRendererList != (Object)num)
		{
			fjn();
		}
	}

	[Token(Token = "0x600141B")]
	[Address(RVA = "0x442C70", Offset = "0x441C70", VA = "0x180442C70")]
	public LineRendererOrbitList()
	{
		//IL_0020: Expected I4, but got I8
	}
}
