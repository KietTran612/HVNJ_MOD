using System;
using Cpp2IlInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200019A")]
[AddComponentMenu("UI/Extensions/Cooldown Button")]
public class CooldownButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	[Serializable]
	[Token(Token = "0x200019B")]
	public class CooldownButtonEvent : UnityEvent<PointerEventData.InputButton>
	{
		[Token(Token = "0x6000E17")]
		[Address(RVA = "0x273BE0", Offset = "0x272BE0", VA = "0x180273BE0")]
		public CooldownButtonEvent()
		{
			((UnityEvent<T0>)(object)this)._002Ector();
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001957")]
	[SerializeField]
	private float cooldownTimeout;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001958")]
	[SerializeField]
	private float cooldownSpeed = 1f;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001959")]
	[SerializeField]
	[ReadOnly]
	private bool cooldownActive;

	[FieldOffset(Offset = "0x21")]
	[Token(Token = "0x400195A")]
	[SerializeField]
	[ReadOnly]
	private bool cooldownInEffect;

	[FieldOffset(Offset = "0x24")]
	[Token(Token = "0x400195B")]
	[SerializeField]
	[ReadOnly]
	private float cooldownTimeElapsed;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400195C")]
	[SerializeField]
	[ReadOnly]
	private float cooldownTimeRemaining;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x400195D")]
	[SerializeField]
	[ReadOnly]
	private int cooldownPercentRemaining;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x400195E")]
	[SerializeField]
	[ReadOnly]
	private int cooldownPercentComplete;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x400195F")]
	private PointerEventData oss;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001960")]
	[Tooltip("Event that fires when a button is initially pressed down")]
	public CooldownButtonEvent OnCooldownStart;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001961")]
	[Tooltip("Event that fires when a button is released")]
	public CooldownButtonEvent OnButtonClickDuringCooldown;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001962")]
	[Tooltip("Event that continually fires while a button is held down")]
	public CooldownButtonEvent OnCoolDownFinish;

	[Token(Token = "0x1700003C")]
	public float pqf
	{
		[Token(Token = "0x6000E03")]
		[Address(RVA = "0x60ECB0", Offset = "0x60DCB0", VA = "0x18060ECB0")]
		get
		{
			return cooldownTimeout;
		}
		[Token(Token = "0x6000E04")]
		[Address(RVA = "0x698BD0", Offset = "0x697BD0", VA = "0x180698BD0")]
		set
		{
			cooldownTimeout = value;
		}
	}

	[Token(Token = "0x1700003D")]
	public float pqg
	{
		[Token(Token = "0x6000E05")]
		[Address(RVA = "0x428ED0", Offset = "0x427ED0", VA = "0x180428ED0")]
		get
		{
			return cooldownSpeed;
		}
		[Token(Token = "0x6000E06")]
		[Address(RVA = "0x5FD310", Offset = "0x5FC310", VA = "0x1805FD310")]
		set
		{
			cooldownSpeed = value;
		}
	}

	[Token(Token = "0x1700003E")]
	public bool pqh
	{
		[Token(Token = "0x6000E07")]
		[Address(RVA = "0x602910", Offset = "0x601910", VA = "0x180602910")]
		get
		{
			return cooldownInEffect;
		}
	}

	[Token(Token = "0x1700003F")]
	public bool pqi
	{
		[Token(Token = "0x6000E08")]
		[Address(RVA = "0x428EE0", Offset = "0x427EE0", VA = "0x180428EE0")]
		get
		{
			return cooldownActive;
		}
		[Token(Token = "0x6000E09")]
		[Address(RVA = "0x652880", Offset = "0x651880", VA = "0x180652880")]
		set
		{
			cooldownActive = value;
		}
	}

	[Token(Token = "0x17000040")]
	public float pqj
	{
		[Token(Token = "0x6000E0A")]
		[Address(RVA = "0x60EE70", Offset = "0x60DE70", VA = "0x18060EE70")]
		get
		{
			return cooldownTimeElapsed;
		}
		[Token(Token = "0x6000E0B")]
		[Address(RVA = "0x698BE0", Offset = "0x697BE0", VA = "0x180698BE0")]
		set
		{
			cooldownTimeElapsed = value;
		}
	}

	[Token(Token = "0x17000041")]
	public float pqk
	{
		[Token(Token = "0x6000E0C")]
		[Address(RVA = "0x48B430", Offset = "0x48A430", VA = "0x18048B430")]
		get
		{
			return cooldownTimeRemaining;
		}
	}

	[Token(Token = "0x17000042")]
	public int pql
	{
		[Token(Token = "0x6000E0D")]
		[Address(RVA = "0x48CDB0", Offset = "0x48BDB0", VA = "0x18048CDB0")]
		get
		{
			return cooldownPercentRemaining;
		}
	}

	[Token(Token = "0x17000043")]
	public int pqm
	{
		[Token(Token = "0x6000E0E")]
		[Address(RVA = "0x62EFB0", Offset = "0x62DFB0", VA = "0x18062EFB0")]
		get
		{
			return cooldownPercentComplete;
		}
	}

	[Token(Token = "0x6000E0F")]
	[Address(RVA = "0x698AD0", Offset = "0x697AD0", VA = "0x180698AD0")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000E10")]
	[Address(RVA = "0x698BF0", Offset = "0x697BF0", VA = "0x180698BF0")]
	public void eay()
	{
		if (cooldownInEffect)
		{
			cooldownActive = false;
		}
	}

	[Token(Token = "0x6000E11")]
	[Address(RVA = "0x698C00", Offset = "0x697C00", VA = "0x180698C00")]
	public void eaz()
	{
		if (cooldownInEffect)
		{
			cooldownActive = true;
		}
	}

	[Token(Token = "0x6000E12")]
	[Address(RVA = "0x698C10", Offset = "0x697C10", VA = "0x180698C10")]
	public void eba()
	{
		//IL_0029: Expected VT, but got I4
		int num = 0;
		PointerEventData pointerEventData = (oss = new PointerEventData(EventSystem.current));
		CooldownButtonEvent onCooldownStart = OnCooldownStart;
		PointerEventData.InputButton inputButton = pointerEventData.button__BackingField;
		((UnityEvent<T0>)(object)onCooldownStart).Invoke((T0)inputButton);
		float num2 = cooldownTimeout;
		cooldownTimeRemaining = num2;
		cooldownActive = true;
	}

	[Token(Token = "0x6000E13")]
	[Address(RVA = "0x698CF0", Offset = "0x697CF0", VA = "0x180698CF0")]
	public void ebb()
	{
		//IL_001e: Expected F4, but got I4
		//IL_0028: Expected I4, but got I8
		//IL_0046: Expected VT, but got I4
		float num = cooldownTimeout;
		CooldownButtonEvent onCoolDownFinish = OnCoolDownFinish;
		cooldownTimeElapsed = num;
		int num2 = 0;
		cooldownTimeRemaining = num2;
		cooldownPercentComplete = 100;
		cooldownActive = (byte)num2 != 0;
		if (onCoolDownFinish != null)
		{
			PointerEventData.InputButton inputButton = oss.button__BackingField;
			((UnityEvent<T0>)(object)onCoolDownFinish).Invoke((T0)inputButton);
		}
	}

	[Token(Token = "0x6000E14")]
	[Address(RVA = "0x698D70", Offset = "0x697D70", VA = "0x180698D70")]
	public void ebc()
	{
		cooldownActive = false;
	}

	[Token(Token = "0x6000E15")]
	[Address(RVA = "0x698D80", Offset = "0x697D80", VA = "0x180698D80", Slot = "4")]
	private void ebd(PointerEventData eventData)
	{
		//IL_004b: Expected VT, but got I4
		//IL_0029: Expected VT, but got I4
		oss = eventData;
		if (cooldownInEffect)
		{
			CooldownButtonEvent onButtonClickDuringCooldown = OnButtonClickDuringCooldown;
			if (onButtonClickDuringCooldown != null)
			{
				PointerEventData.InputButton inputButton = eventData.button__BackingField;
				((UnityEvent<T0>)(object)onButtonClickDuringCooldown).Invoke((T0)inputButton);
			}
			if (cooldownInEffect)
			{
				return;
			}
		}
		CooldownButtonEvent onCooldownStart = OnCooldownStart;
		if (onCooldownStart != null)
		{
			PointerEventData.InputButton inputButton2 = eventData.button__BackingField;
			((UnityEvent<T0>)(object)onCooldownStart).Invoke((T0)inputButton2);
		}
		float num = cooldownTimeout;
		cooldownTimeRemaining = num;
		cooldownActive = true;
	}

	[Token(Token = "0x6000E16")]
	[Address(RVA = "0x698BC0", Offset = "0x697BC0", VA = "0x180698BC0")]
	public CooldownButton()
	{
	}
}
