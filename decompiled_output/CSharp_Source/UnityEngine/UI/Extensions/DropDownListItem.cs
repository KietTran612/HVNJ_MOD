using System;
using System.Runtime.InteropServices;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Serializable]
[Token(Token = "0x2000199")]
public class DropDownListItem
{
	[Cpp2IlInjected.FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001951")]
	[SerializeField]
	private string _caption;

	[Cpp2IlInjected.FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001952")]
	[SerializeField]
	private Sprite _image;

	[Cpp2IlInjected.FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001953")]
	[SerializeField]
	private bool _isDisabled;

	[Cpp2IlInjected.FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001954")]
	[SerializeField]
	private string _id;

	[Cpp2IlInjected.FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001955")]
	public Action OnSelect;

	[Cpp2IlInjected.FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001956")]
	internal Action osr;

	[Token(Token = "0x17000038")]
	public string pqb
	{
		[Token(Token = "0x6000DFA")]
		[Address(RVA = "0x349AA0", Offset = "0x348AA0", VA = "0x180349AA0")]
		get
		{
			return _caption;
		}
		[Token(Token = "0x6000DFB")]
		[Address(RVA = "0x69D9B0", Offset = "0x69C9B0", VA = "0x18069D9B0")]
		set
		{
			_caption = value;
			osr?.Invoke();
		}
	}

	[Token(Token = "0x17000039")]
	public Sprite pqc
	{
		[Token(Token = "0x6000DFC")]
		[Address(RVA = "0x276080", Offset = "0x275080", VA = "0x180276080")]
		get
		{
			return _image;
		}
		[Token(Token = "0x6000DFD")]
		[Address(RVA = "0x69D9D0", Offset = "0x69C9D0", VA = "0x18069D9D0")]
		set
		{
			_image = value;
			osr?.Invoke();
		}
	}

	[Token(Token = "0x1700003A")]
	public bool pqd
	{
		[Token(Token = "0x6000DFE")]
		[Address(RVA = "0x428EE0", Offset = "0x427EE0", VA = "0x180428EE0")]
		get
		{
			return _isDisabled;
		}
		[Token(Token = "0x6000DFF")]
		[Address(RVA = "0x69D9F0", Offset = "0x69C9F0", VA = "0x18069D9F0")]
		set
		{
			_isDisabled = value;
			osr?.Invoke();
		}
	}

	[Token(Token = "0x1700003B")]
	public string pqe
	{
		[Token(Token = "0x6000E00")]
		[Address(RVA = "0x283C00", Offset = "0x282C00", VA = "0x180283C00")]
		get
		{
			return _id;
		}
		[Token(Token = "0x6000E01")]
		[Address(RVA = "0x3E9E40", Offset = "0x3E8E40", VA = "0x1803E9E40")]
		set
		{
			_id = value;
		}
	}

	[Token(Token = "0x6000E02")]
	[Address(RVA = "0x69D950", Offset = "0x69C950", VA = "0x18069D950")]
	public unsafe DropDownListItem([Optional][DefaultParameterValue("")] string caption, [Optional][DefaultParameterValue("")] string inId, [Optional] Sprite image, [Optional][DefaultParameterValue(false)] bool disabled, [Optional] Action onSelect)
	{
		//IL_000b: Expected Obj, but got I4
		//IL_0027: Expected Obj, but got I4
		int num = 0;
		FieldGetter((string)num, inId, ref *(object*)image);
		_isDisabled = false;
		_caption = caption;
		_id = inId;
		OnSelect = (Action)0;
		_image = image;
	}
}
