using System.Collections.Generic;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions.ColorPicker;

[Token(Token = "0x200025B")]
public class ColorPickerPresets : MonoBehaviour
{
	[Token(Token = "0x200025C")]
	public enum ql
	{
		[Token(Token = "0x4001D46")]
		None,
		[Token(Token = "0x4001D47")]
		PlayerPrefs,
		[Token(Token = "0x4001D48")]
		JsonFile
	}

	[Token(Token = "0x200025D")]
	protected class qm
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001D49")]
		public Color32[] plm;

		[Token(Token = "0x600132A")]
		[Address(RVA = "0x2810F0", Offset = "0x2800F0", VA = "0x1802810F0")]
		public void ffd(Color[] colorsIn)
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x600132B")]
		[Address(RVA = "0x2811E0", Offset = "0x2801E0", VA = "0x1802811E0")]
		public Color[] ffe()
		{
			throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
		}

		[Token(Token = "0x600132C")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public qm()
		{
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001D3C")]
	public ColorPickerControl picker;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001D3D")]
	[SerializeField]
	protected GameObject presetPrefab;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001D3E")]
	[SerializeField]
	protected int maxPresets = 16;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001D3F")]
	[SerializeField]
	protected Color[] predefinedPresets;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001D40")]
	protected List<Color> pln = (List<Color>)(object)new List<T>();

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001D41")]
	public Image createPresetImage;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001D42")]
	public Transform createButton;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001D43")]
	[SerializeField]
	public ql saveMode;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001D44")]
	[SerializeField]
	protected string playerPrefsKey;

	[Token(Token = "0x17000125")]
	public virtual string pyi
	{
		[Token(Token = "0x600131E")]
		[Address(RVA = "0x60F850", Offset = "0x60E850", VA = "0x18060F850", Slot = "4")]
		get
		{
			int num = 0;
			string persistentDataPath = Application.persistentDataPath;
			string text = playerPrefsKey;
			return persistentDataPath + "/" + text + ".json";
		}
	}

	[Token(Token = "0x600131F")]
	[Address(RVA = "0x60F770", Offset = "0x60E770", VA = "0x18060F770", Slot = "5")]
	protected virtual void Reset()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001320")]
	[Address(RVA = "0x60F4F0", Offset = "0x60E4F0", VA = "0x18060F4F0", Slot = "6")]
	protected virtual void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001321")]
	[Address(RVA = "0x60F6A0", Offset = "0x60E6A0", VA = "0x18060F6A0", Slot = "7")]
	public virtual void CreatePresetButton()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001322")]
	[Address(RVA = "0x60F8C0", Offset = "0x60E8C0", VA = "0x18060F8C0", Slot = "8")]
	public virtual void ffg(ql saveType)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001323")]
	[Address(RVA = "0x60FBD0", Offset = "0x60EBD0", VA = "0x18060FBD0", Slot = "9")]
	public virtual void ffh(ql saveType)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001324")]
	[Address(RVA = "0x60FE30", Offset = "0x60EE30", VA = "0x18060FE30", Slot = "10")]
	public virtual void ffi(Color color, bool loading)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001325")]
	[Address(RVA = "0x610040", Offset = "0x60F040", VA = "0x180610040", Slot = "11")]
	public virtual void ffj(Color color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001326")]
	[Address(RVA = "0x60F720", Offset = "0x60E720", VA = "0x18060F720", Slot = "12")]
	public virtual void PresetSelect(Image sender)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001327")]
	[Address(RVA = "0x610070", Offset = "0x60F070", VA = "0x180610070", Slot = "13")]
	protected virtual void ffk(float h, float s, float v)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001328")]
	[Address(RVA = "0x6100F0", Offset = "0x60F0F0", VA = "0x1806100F0", Slot = "14")]
	protected virtual void ffl(Color color)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001329")]
	[Address(RVA = "0x60F7D0", Offset = "0x60E7D0", VA = "0x18060F7D0")]
	public ColorPickerPresets()
	{
		//IL_000a: Expected I4, but got I8
	}
}
