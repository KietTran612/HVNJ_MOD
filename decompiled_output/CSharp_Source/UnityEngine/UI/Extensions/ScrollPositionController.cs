using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001FA")]
public class ScrollPositionController : UIBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
{
	[Token(Token = "0x20001FB")]
	private enum pa
	{
		[Token(Token = "0x4001B30")]
		Vertical,
		[Token(Token = "0x4001B31")]
		Horizontal
	}

	[Token(Token = "0x20001FC")]
	private enum pb
	{
		[Token(Token = "0x4001B33")]
		Unrestricted,
		[Token(Token = "0x4001B34")]
		Elastic,
		[Token(Token = "0x4001B35")]
		Clamped
	}

	[Serializable]
	[Token(Token = "0x20001FD")]
	private struct Snap
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4001B36")]
		public bool Enable;

		[FieldOffset(Offset = "0x4")]
		[Token(Token = "0x4001B37")]
		public float VelocityThreshold;

		[FieldOffset(Offset = "0x8")]
		[Token(Token = "0x4001B38")]
		public float Duration;
	}

	[Token(Token = "0x20001FE")]
	private class pc
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4001B39")]
		public bool pba;

		[FieldOffset(Offset = "0x11")]
		[Token(Token = "0x4001B3A")]
		public bool pbb;

		[FieldOffset(Offset = "0x14")]
		[Token(Token = "0x4001B3B")]
		public float pbc;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4001B3C")]
		public float pbd;

		[FieldOffset(Offset = "0x1C")]
		[Token(Token = "0x4001B3D")]
		public float pbe;

		[Token(Token = "0x6001088")]
		[Address(RVA = "0x27C7D0", Offset = "0x27B7D0", VA = "0x18027C7D0")]
		public void eom()
		{
			//IL_0010: Expected F4, but got I4
			//IL_0017: Expected F4, but got I4
			int num = 0;
			pba = false;
			pbc = num;
			pbe = num;
		}

		[Token(Token = "0x6001089")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public pc()
		{
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001B1D")]
	[SerializeField]
	private RectTransform viewport;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001B1E")]
	[SerializeField]
	private pa directionOfRecognize;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x4001B1F")]
	[SerializeField]
	private pb movementType;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001B20")]
	[SerializeField]
	private float elasticity;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4001B21")]
	[SerializeField]
	private float scrollSensitivity;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001B22")]
	[SerializeField]
	private bool inertia;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4001B23")]
	[SerializeField]
	[Tooltip("Only used when inertia is enabled")]
	private float decelerationRate;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001B24")]
	[SerializeField]
	[Tooltip("Only used when inertia is enabled")]
	private Snap snap;

	[FieldOffset(Offset = "0x44")]
	[Token(Token = "0x4001B25")]
	[SerializeField]
	private int dataCount;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001B26")]
	private readonly pc pbf;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001B27")]
	private Action<float> pbg;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001B28")]
	private Action<int> pbh;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001B29")]
	private Vector2 pbi;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001B2A")]
	private float pbj;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4001B2B")]
	private float pbk;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001B2C")]
	private float pbl;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001B2D")]
	private bool pbm;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001B2E")]
	private float pbn;

	[Token(Token = "0x6001075")]
	[Address(RVA = "0x3E96F0", Offset = "0x3E86F0", VA = "0x1803E96F0")]
	public void eon(Action<float> onUpdatePosition)
	{
		pbg = onUpdatePosition;
	}

	[Token(Token = "0x6001076")]
	[Address(RVA = "0x3EFA60", Offset = "0x3EEA60", VA = "0x1803EFA60")]
	public void eoo(Action<int> onItemSelected)
	{
		pbh = onItemSelected;
	}

	[Token(Token = "0x6001077")]
	[Address(RVA = "0x47EDA0", Offset = "0x47DDA0", VA = "0x18047EDA0")]
	public void eop(int dataCount)
	{
		this.dataCount = dataCount;
	}

	[Token(Token = "0x6001078")]
	[Address(RVA = "0x47EDB0", Offset = "0x47DDB0", VA = "0x18047EDB0")]
	public void eoq(int index, float duration)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001079")]
	[Address(RVA = "0x47EF00", Offset = "0x47DF00", VA = "0x18047EF00")]
	public void eor(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600107A")]
	[Address(RVA = "0x47EFC0", Offset = "0x47DFC0", VA = "0x18047EFC0", Slot = "17")]
	private void eos(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600107B")]
	[Address(RVA = "0x47F0E0", Offset = "0x47E0E0", VA = "0x18047F0E0", Slot = "19")]
	private void eot(PointerEventData eventData)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600107C")]
	[Address(RVA = "0x47F360", Offset = "0x47E360", VA = "0x18047F360", Slot = "18")]
	private void eou(PointerEventData eventData)
	{
		if (eventData.button__BackingField == PointerEventData.InputButton.Left)
		{
			pbm = false;
		}
	}

	[Token(Token = "0x600107D")]
	[Address(RVA = "0x47F390", Offset = "0x47E390", VA = "0x18047F390")]
	private float eov()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600107E")]
	[Address(RVA = "0x47F420", Offset = "0x47E420", VA = "0x18047F420")]
	private float eow(float position)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600107F")]
	[Address(RVA = "0x47F460", Offset = "0x47E460", VA = "0x18047F460")]
	private void eox(float position)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001080")]
	[Address(RVA = "0x47F4C0", Offset = "0x47E4C0", VA = "0x18047F4C0")]
	private void eoy(int index)
	{
		//IL_0012: Expected VT, but got I4
		((Action<T>)(object)pbh)?.Invoke((T)index);
	}

	[Token(Token = "0x6001081")]
	[Address(RVA = "0x47F510", Offset = "0x47E510", VA = "0x18047F510")]
	private float eoz(float overStretching, float viewSize)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001082")]
	[Address(RVA = "0x47E6A0", Offset = "0x47D6A0", VA = "0x18047E6A0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001083")]
	[Address(RVA = "0x47F570", Offset = "0x47E570", VA = "0x18047F570")]
	private int epa(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001084")]
	[Address(RVA = "0x47F6A0", Offset = "0x47E6A0", VA = "0x18047F6A0")]
	private int epb(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001085")]
	[Address(RVA = "0x47F7A0", Offset = "0x47E7A0", VA = "0x18047F7A0")]
	private float epc(float position, int length)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001086")]
	[Address(RVA = "0x47F7F0", Offset = "0x47E7F0", VA = "0x18047F7F0")]
	private float epd(float start, float end, float value)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001087")]
	[Address(RVA = "0x47ECF0", Offset = "0x47DCF0", VA = "0x18047ECF0")]
	public ScrollPositionController()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
