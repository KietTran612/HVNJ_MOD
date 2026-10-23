using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x20001DD")]
[ExecuteInEditMode]
[RequireComponent(typeof(CanvasRenderer), typeof(ParticleSystem))]
[AddComponentMenu("UI/Effects/Extensions/UIParticleSystem")]
public class UIParticleSystem : MaskableGraphic
{
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4001A83")]
	[Tooltip("Having this enabled run the system in LateUpdate rather than in Update making it faster but less precise (more clunky)")]
	public bool fixedTime;

	[FieldOffset(Offset = "0xD9")]
	[Token(Token = "0x4001A84")]
	[Tooltip("Enables 3d rotation for the particles")]
	public bool use3dRotation;

	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4001A85")]
	private Transform oyb;

	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4001A86")]
	private ParticleSystem oyc;

	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4001A87")]
	private ParticleSystem.Particle[] oyd;

	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4001A88")]
	private UIVertex[] oye;

	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4001A89")]
	private Vector4 oyf;

	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4001A8A")]
	private ParticleSystem.TextureSheetAnimationModule oyg;

	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4001A8B")]
	private int oyh;

	[FieldOffset(Offset = "0x11C")]
	[Token(Token = "0x4001A8C")]
	private Vector2 oyi;

	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4001A8D")]
	private ParticleSystemRenderer oyj;

	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x4001A8E")]
	private Material oyk;

	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x4001A8F")]
	private Texture oyl;

	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x4001A90")]
	private ParticleSystem.MainModule oym;

	[Token(Token = "0x17000096")]
	public override Texture mainTexture
	{
		[Token(Token = "0x6000FC6")]
		[Address(RVA = "0x521FA0", Offset = "0x520FA0", VA = "0x180521FA0", Slot = "35")]
		get
		{
			return oyl;
		}
	}

	[Token(Token = "0x6000FC7")]
	[Address(RVA = "0x8844B0", Offset = "0x8834B0", VA = "0x1808844B0")]
	protected bool eko()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FC8")]
	[Address(RVA = "0x882C00", Offset = "0x881C00", VA = "0x180882C00", Slot = "4")]
	protected override void Awake()
	{
		((object)this)._002Ector();
		if (!eko())
		{
			int num = 0;
			enabled = (byte)num != 0;
		}
	}

	[Token(Token = "0x6000FC9")]
	[Address(RVA = "0x882F20", Offset = "0x881F20", VA = "0x180882F20", Slot = "44")]
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000FCA")]
	[Address(RVA = "0x884200", Offset = "0x883200", VA = "0x180884200")]
	private void Update()
	{
		//IL_003b: Expected I4, but got I8
		//IL_0055: Expected Obj, but got I4
		//IL_0091: Expected Obj, but got I4
		//IL_00a8: Expected Obj, but got I4
		//IL_00da: Expected Obj, but got I8
		if (fixedTime)
		{
			return;
		}
		int num = 0;
		if (!Application.isPlaying)
		{
			return;
		}
		int num2 = 0;
		ParticleSystem particleSystem = oyc;
		float unscaledDeltaTime = Time.unscaledDeltaTime;
		int restart = 0;
		int withChildren = 0;
		ulong num3 = default;
		particleSystem.Simulate(unscaledDeltaTime, (byte)withChildren != 0, (byte)restart != 0, (byte)num3 != 0);
		SetAllDirty();
		Material material = oyk;
		int num4 = 0;
		if (material != (Object)num4)
		{
			Material material2 = oyk;
			Texture texture = oyl;
			Texture texture2 = material2.mainTexture;
			if (texture != texture2)
			{
				goto IL_00d1;
			}
		}
		Material material3 = this.material;
		int num5 = 0;
		if (material3 != (Object)num5)
		{
			Material material4 = oyk;
			int num6 = 0;
			if (material4 != (Object)num6)
			{
				Shader shader = this.material.shader;
				Shader shader2 = oyk.shader;
				if (!(shader != shader2))
				{
					return;
				}
				goto IL_00d1;
			}
			return;
		}
		return;
		IL_00d1:
		oyc = (ParticleSystem)0;
		bool flag = eko();
	}

	[Token(Token = "0x6000FCB")]
	[Address(RVA = "0x882C40", Offset = "0x881C40", VA = "0x180882C40")]
	private void LateUpdate()
	{
		//IL_003b: Expected I4, but got I8
		//IL_0055: Expected Obj, but got I4
		//IL_010d: Expected Obj, but got I8
		//IL_0091: Expected Obj, but got I4
		//IL_00a8: Expected Obj, but got I4
		//IL_00da: Expected Obj, but got I8
		int num = 0;
		if (!Application.isPlaying)
		{
			goto IL_00e2;
		}
		if (fixedTime)
		{
			ParticleSystem particleSystem = oyc;
			int num2 = 0;
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			int restart = 0;
			int withChildren = 0;
			ulong num3 = default;
			particleSystem.Simulate(unscaledDeltaTime, (byte)withChildren != 0, (byte)restart != 0, (byte)num3 != 0);
			SetAllDirty();
			Material material = oyk;
			int num4 = 0;
			if (material != (Object)num4)
			{
				Material material2 = oyk;
				Texture texture = oyl;
				Texture texture2 = material2.mainTexture;
				if (texture != texture2)
				{
					goto IL_00d1;
				}
			}
			Material material3 = this.material;
			int num5 = 0;
			if (material3 != (Object)num5)
			{
				Material material4 = oyk;
				int num6 = 0;
				if (material4 != (Object)num6)
				{
					Shader shader = this.material.shader;
					Shader shader2 = oyk.shader;
					if (shader != shader2)
					{
						goto IL_00d1;
					}
				}
			}
		}
		goto IL_00e8;
		IL_00e8:
		Material material5 = this.material;
		Material material6 = oyk;
		if (!(material5 == material6))
		{
			oyc = (ParticleSystem)0;
			bool flag = eko();
		}
		return;
		IL_00e2:
		SetAllDirty();
		goto IL_00e8;
		IL_00d1:
		oyc = (ParticleSystem)0;
		bool flag2 = eko();
		goto IL_00e2;
	}

	[Token(Token = "0x6000FCC")]
	[Address(RVA = "0x882F00", Offset = "0x881F00", VA = "0x180882F00", Slot = "8")]
	protected override void OnDestroy()
	{
		//IL_0009: Expected Obj, but got I4
		//IL_0010: Expected Obj, but got I4
		int num = 0;
		oyk = (Material)num;
		oyl = (Texture)num;
	}

	[Token(Token = "0x6000FCD")]
	[Address(RVA = "0x884440", Offset = "0x883440", VA = "0x180884440")]
	public UIParticleSystem()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
