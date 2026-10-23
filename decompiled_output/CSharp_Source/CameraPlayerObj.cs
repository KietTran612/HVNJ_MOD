using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x200015E")]
public class CameraPlayerObj : MonoBehaviour
{
	[Token(Token = "0x400175C")]
	public static float smooth;

	[Token(Token = "0x400175D")]
	public const int Type_MiniMap = 0;

	[Token(Token = "0x400175E")]
	public const int Type_Map = 1;

	[Token(Token = "0x400175F")]
	public const int Type_WaitRom = 2;

	[Token(Token = "0x4001760")]
	public const int Type_Dance = 3;

	[Token(Token = "0x4001761")]
	public const int Type_Shop = 4;

	[Token(Token = "0x4001762")]
	public const int Type_Inventory = 5;

	[Token(Token = "0x4001763")]
	public const int Type_FindRom = 6;

	[Token(Token = "0x4001764")]
	private static Transform odh;

	[Token(Token = "0x4001765")]
	private static Vector3 odi;

	[Token(Token = "0x4001766")]
	private static float odj;

	[Token(Token = "0x4001767")]
	private static Vector3 odk;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001768")]
	private bool odl;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001769")]
	private Vector3 odm;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x400176A")]
	private Vector3 odn;

	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x400176B")]
	private Vector3 odo;

	[Token(Token = "0x400176C")]
	public static float offsetHigh;

	[Token(Token = "0x400176D")]
	public static float offsetFOV;

	[Token(Token = "0x400176E")]
	public static float curFOV;

	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x400176F")]
	public bool lockCamera;

	[Token(Token = "0x6000BF8")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	private void Awake()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BF9")]
	[Address(RVA = "0x608A70", Offset = "0x607A70", VA = "0x180608A70")]
	public void dnp()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BFA")]
	[Address(RVA = "0x6094F0", Offset = "0x6084F0", VA = "0x1806094F0")]
	public void initCamera(Transform tran)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BFB")]
	[Address(RVA = "0x608960", Offset = "0x607960", VA = "0x180608960")]
	public unsafe void changeCameraView(Vector3 position, Vector3 eulerAngles)
	{
		//IL_001a: Expected native int or pointer, but got VT
		//IL_002d: Expected native int or pointer, but got VT
		Debug.Log("changeCameraView");
		int num = 0;
		float z = eulerAngles.z;
		((Vector3*)(nint)odn)->z = z;
		float z2 = position.z;
		((Vector3*)(nint)odm)->z = z2;
		odl = true;
		curFOV = Camera.main.fieldOfView;
	}

	[Token(Token = "0x6000BFC")]
	[Address(RVA = "0x608BF0", Offset = "0x607BF0", VA = "0x180608BF0")]
	public unsafe void dnq(Vector3 eulerAngles)
	{
		//IL_000e: Expected native int or pointer, but got VT
		float z = eulerAngles.z;
		((Vector3*)(nint)odn)->z = z;
	}

	[Token(Token = "0x6000BFD")]
	[Address(RVA = "0x608C00", Offset = "0x607C00", VA = "0x180608C00")]
	public void dnr(float newHigh)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BFE")]
	[Address(RVA = "0x609040", Offset = "0x608040", VA = "0x180609040")]
	public void dns(float newFOV)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000BFF")]
	[Address(RVA = "0x608460", Offset = "0x607460", VA = "0x180608460")]
	private void FixedUpdate()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C00")]
	[Address(RVA = "0x6091B0", Offset = "0x6081B0", VA = "0x1806091B0")]
	private bool dnt(Vector3 checkPos)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C01")]
	[Address(RVA = "0x609220", Offset = "0x608220", VA = "0x180609220")]
	private void dnu()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C02")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public CameraPlayerObj()
	{
	}

	[Token(Token = "0x6000C03")]
	[Address(RVA = "0x6088E0", Offset = "0x6078E0", VA = "0x1806088E0")]
	static CameraPlayerObj()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}
}
