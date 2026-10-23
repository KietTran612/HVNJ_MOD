using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x200025A")]
[ExecuteInEditMode]
public class ColorPickerControl : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D2E")]
	private float plf;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001D2F")]
	private float plg;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D30")]
	private float plh;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001D31")]
	private float pli;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D32")]
	private float plj;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4001D33")]
	private float plk;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D34")]
	private float pll = 1f;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001D35")]
	public ColorChangedEvent onValueChanged = new ColorChangedEvent();

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001D36")]
	public HSVChangedEvent onHSVChanged = new HSVChangedEvent();

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001D37")]
	[SerializeField]
	private bool hsvSlidersOn = true;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001D38")]
	[SerializeField]
	private List<GameObject> hsvSliders = (List<GameObject>)(object)new List<T>();

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001D39")]
	[SerializeField]
	private bool rgbSlidersOn = true;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001D3A")]
	[SerializeField]
	private List<GameObject> rgbSliders = (List<GameObject>)(object)new List<T>();

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001D3B")]
	[SerializeField]
	private GameObject alphaSlider;

	[Token(Token = "0x1700011D")]
	public Color pya
	{
		[Token(Token = "0x6001307")]
		[Address(RVA = "0x60EC70", Offset = "0x60DC70", VA = "0x18060EC70")]
		get
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
		[Token(Token = "0x6001308")]
		[Address(RVA = "0x60F440", Offset = "0x60E440", VA = "0x18060F440")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x1700011E")]
	public float pyb
	{
		[Token(Token = "0x600130A")]
		[Address(RVA = "0x60ECB0", Offset = "0x60DCB0", VA = "0x18060ECB0")]
		get
		{
			return plf;
		}
		[Token(Token = "0x600130B")]
		[Address(RVA = "0x60ECC0", Offset = "0x60DCC0", VA = "0x18060ECC0")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x1700011F")]
	public float pyc
	{
		[Token(Token = "0x600130C")]
		[Address(RVA = "0x428ED0", Offset = "0x427ED0", VA = "0x180428ED0")]
		get
		{
			return plg;
		}
		[Token(Token = "0x600130D")]
		[Address(RVA = "0x60ED50", Offset = "0x60DD50", VA = "0x18060ED50")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000120")]
	public float pyd
	{
		[Token(Token = "0x600130E")]
		[Address(RVA = "0x4429F0", Offset = "0x4419F0", VA = "0x1804429F0")]
		get
		{
			return plh;
		}
		[Token(Token = "0x600130F")]
		[Address(RVA = "0x60EDE0", Offset = "0x60DDE0", VA = "0x18060EDE0")]
		set
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}
	}

	[Token(Token = "0x17000121")]
	public float pye
	{
		[Token(Token = "0x6001310")]
		[Address(RVA = "0x60EE70", Offset = "0x60DE70", VA = "0x18060EE70")]
		get
		{
			return pli;
		}
		[Token(Token = "0x6001311")]
		[Address(RVA = "0x60EE80", Offset = "0x60DE80", VA = "0x18060EE80")]
		set
		{
			pli = value;
			fey();
			ffa();
		}
	}

	[Token(Token = "0x17000122")]
	public float pyf
	{
		[Token(Token = "0x6001312")]
		[Address(RVA = "0x48B430", Offset = "0x48A430", VA = "0x18048B430")]
		get
		{
			return plj;
		}
		[Token(Token = "0x6001313")]
		[Address(RVA = "0x60EEC0", Offset = "0x60DEC0", VA = "0x18060EEC0")]
		set
		{
			plj = value;
			fey();
			ffa();
		}
	}

	[Token(Token = "0x17000123")]
	public float pyg
	{
		[Token(Token = "0x6001314")]
		[Address(RVA = "0x516140", Offset = "0x515140", VA = "0x180516140")]
		get
		{
			return plk;
		}
		[Token(Token = "0x6001315")]
		[Address(RVA = "0x60EF00", Offset = "0x60DF00", VA = "0x18060EF00")]
		set
		{
			plk = value;
			fey();
			ffa();
		}
	}

	[Token(Token = "0x17000124")]
	private float pyh
	{
		[Token(Token = "0x6001316")]
		[Address(RVA = "0x60EF40", Offset = "0x60DF40", VA = "0x18060EF40")]
		get
		{
			return pll;
		}
		[Token(Token = "0x6001317")]
		[Address(RVA = "0x60EF50", Offset = "0x60DF50", VA = "0x18060EF50")]
		set
		{
			pll = value;
			ffa();
		}
	}

	[Token(Token = "0x6001304")]
	[Address(RVA = "0x60E930", Offset = "0x60D930", VA = "0x18060E930")]
	public void feh(bool value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001305")]
	[Address(RVA = "0x60EAD0", Offset = "0x60DAD0", VA = "0x18060EAD0")]
	public void fei(bool value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001306")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001309")]
	[Address(RVA = "0x60E810", Offset = "0x60D810", VA = "0x18060E810")]
	private void Start()
	{
		ffa();
	}

	[Token(Token = "0x6001318")]
	[Address(RVA = "0x60EF70", Offset = "0x60DF70", VA = "0x18060EF70")]
	private void fey()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001319")]
	[Address(RVA = "0x60F020", Offset = "0x60E020", VA = "0x18060F020")]
	private void fez()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600131A")]
	[Address(RVA = "0x60F090", Offset = "0x60E090", VA = "0x18060F090")]
	private void ffa()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600131B")]
	[Address(RVA = "0x60F160", Offset = "0x60E160", VA = "0x18060F160")]
	public void ffb(qn type, float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600131C")]
	[Address(RVA = "0x60F360", Offset = "0x60E360", VA = "0x18060F360")]
	public float ffc(qn type)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600131D")]
	[Address(RVA = "0x60E820", Offset = "0x60D820", VA = "0x18060E820")]
	public ColorPickerControl()
	{
	}
}
