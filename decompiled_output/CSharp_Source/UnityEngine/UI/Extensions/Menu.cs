using Cpp2IlInjected;
using Facebook.Unity.Canvas;

namespace UnityEngine.UI.Extensions;

[Token(Token = "0x200020E")]
public abstract class Menu<T> : Menu where T : Menu<T>
{
	[Token(Token = "0x170000C0")]
	[field: Token(Token = "0x4001BB1")]
	public static T pdt
	{
		[Token(Token = "0x6001118")]
		[Address(RVA = "0x7AFFC0", Offset = "0x7AEFC0", VA = "0x1807AFFC0")]
		get;
		[Token(Token = "0x6001119")]
		[Address(RVA = "0x7B0010", Offset = "0x7AF010", VA = "0x1807B0010")]
		private set;
	}

	[Token(Token = "0x600111A")]
	[Address(RVA = "0x7AFC70", Offset = "0x7AEC70", VA = "0x1807AFC70", Slot = "5")]
	protected virtual void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600111B")]
	[Address(RVA = "0x7AFF80", Offset = "0x7AEF80", VA = "0x1807AFF80", Slot = "6")]
	protected virtual void OnDestroy()
	{
		//IL_0006: Expected Obj, but got I4
		((Facebook.Unity.Canvas.ICanvasJSWrapper)0).InitScreenPosition();
	}

	[Token(Token = "0x600111C")]
	[Address(RVA = "0x7B0070", Offset = "0x7AF070", VA = "0x1807B0070")]
	protected static void esp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600111D")]
	[Address(RVA = "0x7AFD00", Offset = "0x7AED00", VA = "0x1807AFD00")]
	protected static void Close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600111E")]
	[Address(RVA = "0x7AFF60", Offset = "0x7AEF60", VA = "0x1807AFF60", Slot = "4")]
	public override void OnBackPressed()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x600111F")]
	[Address(RVA = "0x7AFFA0", Offset = "0x7AEFA0", VA = "0x1807AFFA0")]
	protected Menu()
	{
	}
}
[Token(Token = "0x200020F")]
public abstract class Menu : MonoBehaviour
{
	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001BB2")]
	[Tooltip("Destroy the Game Object when menu is closed (reduces memory usage)")]
	public bool DestroyWhenClosed = true;

	[FieldOffset(Offset = "0x19")]
	[Token(Token = "0x4001BB3")]
	[Tooltip("Disable menus that are under this one in the stack")]
	public bool DisableMenusUnderneath;

	[Token(Token = "0x6001120")]
	[Address(Slot = "4")]
	public abstract void OnBackPressed();

	[Token(Token = "0x6001121")]
	[Address(RVA = "0x446140", Offset = "0x445140", VA = "0x180446140")]
	protected Menu()
	{
	}
}
