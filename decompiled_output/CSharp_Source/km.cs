using Cpp2IlInjected;
using Spine.Unity;
using UnityEngine;

[Token(Token = "0x2000112")]
public class km
{
	[FieldOffset(Offset = "0x10")]
	[Token(Token = "0x4001132")]
	public GameObject luf;

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001133")]
	public int lug;

	[FieldOffset(Offset = "0x1C")]
	[Token(Token = "0x4001134")]
	public bool luh;

	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4001135")]
	public Transform lui;

	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4001136")]
	public SkeletonAnimation luj;

	[Token(Token = "0x60007F1")]
	[Address(RVA = "0x1F50C0", Offset = "0x1F40C0", VA = "0x1801F50C0")]
	public km(GameObject gameobject, int id)
	{
		//IL_0016: Expected Obj, but got I4
		luf = gameobject;
		int num = 0;
		if (gameobject != (Object)num)
		{
			Transform transform = gameobject.transform;
			lui = transform;
		}
		lug = id;
	}

	[Token(Token = "0x60007F2")]
	[Address(RVA = "0x1F5160", Offset = "0x1F4160", VA = "0x1801F5160")]
	public void cky(bool isS)
	{
		//IL_0017: Expected Obj, but got I4
		GameObject gameObject = luf;
		luh = isS;
		int num = 0;
		if (gameObject != (Object)num)
		{
			luf.SetActive(isS);
		}
	}
}
