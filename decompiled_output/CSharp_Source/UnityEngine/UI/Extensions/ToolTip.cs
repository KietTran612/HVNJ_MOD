using Cpp2IlInjected;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x2000228")]
[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("UI/Extensions/Tooltip/Tooltip")]
public class ToolTip : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001C59")]
	private Text pfz;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001C5A")]
	private RectTransform pga;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001C5B")]
	private RectTransform pgb;

	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4001C5C")]
	[Tooltip("The canvas used by the tooltip as positioning and scaling reference. Should usually be the root Canvas of the hierarchy this component is in")]
	public Canvas canvas;

	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4001C5D")]
	[Tooltip("Sets if tooltip triggers will run ForceUpdateCanvases and refresh the tooltip's layout group (if any) when hovered, in order to prevent momentaneous misplacement sometimes caused by ContentSizeFitters")]
	public bool tooltipTriggersCanForceCanvasUpdate;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4001C5E")]
	private LayoutGroup pgc;

	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4001C5F")]
	private bool pgd;

	[FieldOffset(Offset = "0x4C")]
	[Token(Token = "0x4001C60")]
	private float pge;

	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4001C61")]
	private float pgf;

	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4001C62")]
	public float YShift;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x4001C63")]
	public float xShift;

	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4001C64")]
	[HideInInspector]
	public RenderMode guiMode;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x4001C65")]
	private Camera pgg;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001C66")]
	private Vector3 pgh;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001C67")]
	private Vector3 pgi;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001C68")]
	private Vector3 pgj;

	[FieldOffset(Offset = "0x8C")]
	[Token(Token = "0x4001C69")]
	private Vector3 pgk;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4001C6A")]
	private Vector3 pgl;

	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4001C6B")]
	private Vector3 pgm;

	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4001C6C")]
	private Vector3 pgn;

	[FieldOffset(Offset = "0xBC")]
	[Token(Token = "0x4001C6D")]
	private Vector3 pgo;

	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4001C6E")]
	private float pgp;

	[Token(Token = "0x4001C6F")]
	private static ToolTip pgq;

	[Token(Token = "0x170000F7")]
	public Camera pwr
	{
		[Token(Token = "0x60011E7")]
		[Address(RVA = "0x877A20", Offset = "0x876A20", VA = "0x180877A20")]
		get
		{
			if (!pgg)
			{
				int num = 0;
				Camera main = Camera.main;
				pgg = main;
			}
			return pgg;
		}
	}

	[Token(Token = "0x170000F8")]
	public static ToolTip pws
	{
		[Token(Token = "0x60011E8")]
		[Address(RVA = "0x877AA0", Offset = "0x876AA0", VA = "0x180877AA0")]
		get
		{
			//IL_000f: Expected Obj, but got I4
			ToolTip toolTip = pgq;
			int num = 0;
			if (toolTip == (Object)num)
			{
				pgq = Object.FindObjectOfType<ToolTip>();
			}
			return pgq;
		}
	}

	[Token(Token = "0x60011E9")]
	[Address(RVA = "0x877980", Offset = "0x876980", VA = "0x180877980")]
	private void Reset()
	{
		Canvas rootCanvas = (canvas = GetComponentInParent<Canvas>()).rootCanvas;
		canvas = rootCanvas;
	}

	[Token(Token = "0x60011EA")]
	[Address(RVA = "0x8777F0", Offset = "0x8767F0", VA = "0x1808777F0")]
	public void Awake()
	{
		pgq = this;
		if (!this.canvas)
		{
			Canvas rootCanvas = (this.canvas = GetComponentInParent<Canvas>()).rootCanvas;
			this.canvas = rootCanvas;
		}
		Canvas canvas = this.canvas;
		Camera worldCamera = canvas.worldCamera;
		pgg = worldCamera;
		RenderMode renderMode = canvas.renderMode;
		guiMode = renderMode;
		RectTransform component = GetComponent<RectTransform>();
		pga = component;
		RectTransform component2 = GetComponent<RectTransform>();
		pgb = component2;
		LayoutGroup componentInChildren = GetComponentInChildren<LayoutGroup>();
		pgc = componentInChildren;
		Text componentInChildren2 = GetComponentInChildren<Text>();
		pfz = componentInChildren2;
		pgd = false;
		GameObject gameObject = base.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
	}

	[Token(Token = "0x60011EB")]
	[Address(RVA = "0x877B70", Offset = "0x876B70", VA = "0x180877B70")]
	public void eye(string ttext, Vector3 basePos, bool refreshCanvasesBeforeGetSize = false)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011EC")]
	[Address(RVA = "0x877CA0", Offset = "0x876CA0", VA = "0x180877CA0")]
	public void eyf()
	{
		GameObject gameObject = base.gameObject;
		int active = 0;
		gameObject.SetActive((byte)active != 0);
		pgd = false;
	}

	[Token(Token = "0x60011ED")]
	[Address(RVA = "0x8779E0", Offset = "0x8769E0", VA = "0x1808779E0")]
	private void Update()
	{
		if (pgd)
		{
			switch (guiMode)
			{
			case RenderMode.ScreenSpaceOverlay:
			{
				int refreshCanvasesBeforeGettingSize2 = 0;
				eyj((byte)refreshCanvasesBeforeGettingSize2 != 0);
				break;
			}
			case RenderMode.ScreenSpaceCamera:
			{
				int refreshCanvasesBeforeGettingSize = 0;
				eyi((byte)refreshCanvasesBeforeGettingSize != 0);
				break;
			}
			}
		}
	}

	[Token(Token = "0x60011EE")]
	[Address(RVA = "0x877CE0", Offset = "0x876CE0", VA = "0x180877CE0")]
	public void eyg()
	{
		if (tooltipTriggersCanForceCanvasUpdate)
		{
			int num = 0;
			Canvas.ForceUpdateCanvases();
			if ((bool)pgc)
			{
				LayoutGroup layoutGroup = pgc;
				int num2 = 0;
				layoutGroup.enabled = (byte)num2 != 0;
				pgc.enabled = true;
			}
		}
	}

	[Token(Token = "0x60011EF")]
	[Address(RVA = "0x877D90", Offset = "0x876D90", VA = "0x180877D90")]
	public void eyh(bool refreshCanvasesBeforeGettingSize = false)
	{
		switch (guiMode)
		{
		case RenderMode.ScreenSpaceOverlay:
			eyj(refreshCanvasesBeforeGettingSize);
			break;
		case RenderMode.ScreenSpaceCamera:
			eyi(refreshCanvasesBeforeGettingSize);
			break;
		}
	}

	[Token(Token = "0x60011F0")]
	[Address(RVA = "0x877DB0", Offset = "0x876DB0", VA = "0x180877DB0")]
	public void eyi(bool refreshCanvasesBeforeGettingSize = false)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011F1")]
	[Address(RVA = "0x878330", Offset = "0x877330", VA = "0x180878330")]
	public void eyj(bool refreshCanvasesBeforeGettingSize = false)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x60011F2")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ToolTip()
	{
	}
}
