using Cpp2IlInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200018A")]
public class TiltWindow : MonoBehaviour, IDragHandler, IEventSystemHandler
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x40018EC")]
	public Vector2 range = (Vector2)1084227584;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x40018ED")]
	private Transform opx;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x40018EE")]
	private Quaternion opy;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x40018EF")]
	private Vector2 opz;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x40018F0")]
	private Vector2 oqa;

	[Token(Token = "0x6000DB2")]
	[Address(RVA = "0x8775B0", Offset = "0x8765B0", VA = "0x1808775B0")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DB3")]
	[Address(RVA = "0x8775F0", Offset = "0x8765F0", VA = "0x1808775F0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000DB4")]
	[Address(RVA = "0x877580", Offset = "0x876580", VA = "0x180877580", Slot = "4")]
	public unsafe void OnDrag(PointerEventData eventData)
	{
		//IL_0021: Expected native int or pointer, but got VT
		Vector2 vector = eventData.position__BackingField;
		float y = eventData.position__BackingField.y;
		oqa = vector;
		((Vector2*)(nint)oqa)->y = y;
	}

	[Token(Token = "0x6000DB5")]
	[Address(RVA = "0x8777A0", Offset = "0x8767A0", VA = "0x1808777A0")]
	public unsafe TiltWindow()
	{
		//IL_000d: Expected VT, but got I8
		//IL_0018: Expected native int or pointer, but got VT
		//IL_0038: Expected F4, but got I4
		//IL_0033: Expected native int or pointer, but got VT
		((Vector2*)(nint)range)->y = 3f;
		int num = 0;
		opz = Vector2.zero;
		((Vector2*)(nint)opz)->y = 0f;
		((Behaviour)this)._002Ector();
	}
}
