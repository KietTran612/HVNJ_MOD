using System;
using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001DA")]
[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
[AddComponentMenu("UI/Effects/Extensions/Shining Effect")]
public class ShineEffector : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001A6F")]
	public ShineEffect effector;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001A70")]
	[SerializeField]
	[HideInInspector]
	private GameObject effectRoot;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001A71")]
	[Range(-1f, 1f)]
	public float yOffset = -1f;

	[FieldOffset(Offset = "0x2C")]
	[Token(Token = "0x4001A72")]
	[Range(0.1f, 1f)]
	public float width = 0.5f;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001A73")]
	private RectTransform oxt;

	[Token(Token = "0x17000093")]
	public float ptl
	{
		[Token(Token = "0x6000FB4")]
		[Address(RVA = "0x48B430", Offset = "0x48A430", VA = "0x18048B430")]
		get
		{
			return yOffset;
		}
		[Token(Token = "0x6000FB5")]
		[Address(RVA = "0x48B440", Offset = "0x48A440", VA = "0x18048B440")]
		set
		{
			ShineEffect shineEffect = effector;
			shineEffect.SetVerticesDirty();
			shineEffect.yoffset = value;
			if (!(value >= 1f))
			{
				if (effectRoot.activeSelf)
				{
					goto IL_0041;
				}
				GameObject gameObject = effectRoot;
			}
			GameObject gameObject2 = effectRoot;
			int active = 0;
			gameObject2.SetActive((byte)active != 0);
			goto IL_0041;
			IL_0041:
			yOffset = value;
		}
	}

	[Token(Token = "0x6000FB6")]
	[Address(RVA = "0x48ACB0", Offset = "0x489CB0", VA = "0x18048ACB0")]
	private void OnEnable()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FB7")]
	[Address(RVA = "0x48B340", Offset = "0x48A340", VA = "0x18048B340")]
	private void OnValidate()
	{
		ShineEffect shineEffect = effector;
		float yoffset = yOffset;
		shineEffect.SetVerticesDirty();
		shineEffect.yoffset = yoffset;
		ShineEffect shineEffect2 = effector;
		float num = width;
		shineEffect2.SetAllDirty();
		shineEffect2.width = num;
		if (!(yOffset >= 1f))
		{
			if (!effectRoot.activeSelf)
			{
				effectRoot.SetActive(value: true);
			}
			return;
		}
		GameObject gameObject = effectRoot;
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000FB8")]
	[Address(RVA = "0x48B4E0", Offset = "0x48A4E0", VA = "0x18048B4E0")]
	private void ekh(float value)
	{
		ShineEffect shineEffect = effector;
		shineEffect.SetVerticesDirty();
		shineEffect.yoffset = value;
		if (!(value >= 1f))
		{
			if (!effectRoot.activeSelf)
			{
				effectRoot.SetActive(value: true);
			}
			return;
		}
		GameObject gameObject = effectRoot;
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000FB9")]
	[Address(RVA = "0x48AC20", Offset = "0x489C20", VA = "0x18048AC20")]
	private void OnDestroy()
	{
		int num = 0;
		bool isPlaying = Application.isPlaying;
		GameObject obj = effectRoot;
		if (isPlaying)
		{
			Object.Destroy(obj);
		}
		else
		{
			Object.DestroyImmediate(obj);
		}
	}

	[Token(Token = "0x6000FBA")]
	[Address(RVA = "0x48B410", Offset = "0x48A410", VA = "0x18048B410")]
	public ShineEffector()
	{
	}
}
