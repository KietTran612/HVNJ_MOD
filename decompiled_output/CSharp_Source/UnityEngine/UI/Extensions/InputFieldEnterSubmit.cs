using System;
using Cpp2IlInjected;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000233")]
[RequireComponent(typeof(InputField))]
[AddComponentMenu("UI/Extensions/Input Field Submit")]
public class InputFieldEnterSubmit : MonoBehaviour
{
	[Serializable]
	[Token(Token = "0x2000234")]
	public class EnterSubmitEvent : UnityEvent<string>
	{
		[Token(Token = "0x6001241")]
		[Address(RVA = "0x274080", Offset = "0x273080", VA = "0x180274080")]
		public EnterSubmitEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C9B")]
	public EnterSubmitEvent EnterSubmit;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C9C")]
	public bool defocusInput = true;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001C9D")]
	private InputField phn;

	[Token(Token = "0x600123E")]
	[Address(RVA = "0x441A30", Offset = "0x440A30", VA = "0x180441A30")]
	private void Awake()
	{
		InputField.SubmitEvent onEndEdit = (phn = GetComponent<InputField>()).m_OnEndEdit;
		UnityAction<string> unityAction = (UnityAction<string>)(object)new UnityAction<T0>(OnEndEdit);
		((UnityEvent<T0>)(object)onEndEdit).AddListener((UnityAction<>)(object)unityAction);
	}

	[Token(Token = "0x600123F")]
	[Address(RVA = "0x441B10", Offset = "0x440B10", VA = "0x180441B10")]
	public void OnEndEdit(string txt)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6001240")]
	[Address(RVA = "0x441BD0", Offset = "0x440BD0", VA = "0x180441BD0")]
	public InputFieldEnterSubmit()
	{
	}
}
