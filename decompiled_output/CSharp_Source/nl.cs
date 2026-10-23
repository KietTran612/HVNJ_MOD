using System;
using System.IO;
using System.Runtime.CompilerServices;
using Cpp2IlInjected;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using UnityEngine.UI;

[Token(Token = "0x2000167")]
public class nl : fi, k, IStoreListener
{
	[Token(Token = "0x2000168")]
	private class nk : i
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x400179D")]
		private int oeo;

		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x400179E")]
		private nl oep;

		[Token(Token = "0x6000C43")]
		[Address(RVA = "0x2782F0", Offset = "0x2772F0", VA = "0x1802782F0")]
		public nk(nl me, int ind)
		{
			oep = me;
			oeo = ind;
		}

		[Token(Token = "0x6000C44")]
		[Address(RVA = "0x27AB90", Offset = "0x279B90", VA = "0x18027AB90", Slot = "4")]
		public void th()
		{
			nl nl2 = oep;
			int index = oeo;
			nl2.doc(index);
		}
	}

	[Token(Token = "0x400178D")]
	private static nl oeq;

	[FieldOffset(Offset = "0x58")]
	[Token(Token = "0x400178E")]
	private IStoreController oer;

	[FieldOffset(Offset = "0x60")]
	[Token(Token = "0x400178F")]
	private GameObject oes;

	[FieldOffset(Offset = "0x68")]
	[Token(Token = "0x4001790")]
	private int oet = 250;

	[FieldOffset(Offset = "0x6C")]
	[Token(Token = "0x4001791")]
	private int oeu = 160;

	[FieldOffset(Offset = "0x70")]
	[Token(Token = "0x4001792")]
	private int oev;

	[FieldOffset(Offset = "0x74")]
	[Token(Token = "0x4001793")]
	private int oew;

	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4001794")]
	private ScrollRect oex;

	[Token(Token = "0x4001795")]
	public static int[] oey;

	[Token(Token = "0x4001796")]
	public static string[] oez;

	[Token(Token = "0x4001797")]
	public static string[] ofa;

	[Token(Token = "0x4001798")]
	public static float[] ofb;

	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4001799")]
	private GameObject ofc;

	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x400179A")]
	private RectTransform ofd;

	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x400179B")]
	private bool ofe;

	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x400179C")]
	private char[] ofg;

	[Token(Token = "0x6000C2E")]
	[Address(RVA = "0x2D5000", Offset = "0x2D4000", VA = "0x1802D5000")]
	public static nl doa()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C2F")]
	[Address(RVA = "0x2D5B90", Offset = "0x2D4B90", VA = "0x1802D5B90")]
	public void init()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C30")]
	[Address(RVA = "0x2D5110", Offset = "0x2D4110", VA = "0x1802D5110")]
	public void dob(bool isLoad)
	{
		//IL_0019: Expected Obj, but got I4
		if (isLoad != ofe)
		{
			GameObject gameObject = ofc;
			int num = 0;
			if (!(gameObject == (UnityEngine.Object)num))
			{
				GameObject gameObject2 = ofc;
				ofe = isLoad;
				gameObject2.SetActive(isLoad);
			}
		}
	}

	[Token(Token = "0x6000C31")]
	[Address(RVA = "0x2D6240", Offset = "0x2D5240", VA = "0x1802D6240")]
	private void refreshList()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C32")]
	[Address(RVA = "0x2D4E50", Offset = "0x2D3E50", VA = "0x1802D4E50", Slot = "6")]
	public override void bcd()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C33")]
	[Address(RVA = "0x2D51C0", Offset = "0x2D41C0", VA = "0x1802D51C0")]
	private void doc(int index)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C34")]
	[Address(RVA = "0x2D52C0", Offset = "0x2D42C0", VA = "0x1802D52C0")]
	public void dod(bc m)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C35")]
	[Address(RVA = "0x2D5400", Offset = "0x2D4400", VA = "0x1802D5400")]
	public void doe(bc msg)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C36")]
	[Address(RVA = "0x2D4DD0", Offset = "0x2D3DD0", VA = "0x1802D4DD0", Slot = "7")]
	public override void bbp(short idAction, short indexAction)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C37")]
	[Address(RVA = "0x2D69E0", Offset = "0x2D59E0", VA = "0x1802D69E0", Slot = "11")]
	public void ti(int idAction, lh p)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C38")]
	[Address(RVA = "0x2D4990", Offset = "0x2D3990", VA = "0x1802D4990")]
	private void InitializePurchasing()
	{
		GC.KeepAlive("InitializePurchasing");
	}

	[Token(Token = "0x6000C39")]
	[Address(RVA = "0x2D4A50", Offset = "0x2D3A50", VA = "0x1802D4A50", Slot = "12")]
	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C3A")]
	[Address(RVA = "0x2D49D0", Offset = "0x2D39D0", VA = "0x1802D49D0", Slot = "13")]
	public void OnInitializeFailed(InitializationFailureReason error)
	{
		string text = string.Format("Purchasing failed to initialize. Reason: {0}.", " More details: ");
	}

	[Token(Token = "0x6000C3B")]
	[Address(RVA = "0x2D5670", Offset = "0x2D4670", VA = "0x1802D5670")]
	public void dof(InitializationFailureReason error, string message)
	{
		string text = string.Format("Purchasing failed to initialize. Reason: {0}.", " More details: ");
		if (message != null)
		{
			string text2 = text + " More details: " + message;
		}
	}

	[Token(Token = "0x6000C3C")]
	[Address(RVA = "0x2D5710", Offset = "0x2D4710", VA = "0x1802D5710")]
	private string dog(string strSource, string strStart, string strEnd)
	{
		if (strSource.Contains(strStart) && strSource.Contains(strEnd))
		{
			int startIndex = 0;
			int num = strSource.IndexOf(strStart, startIndex);
			int stringLength = strStart.m_stringLength;
			stringLength += num;
			int num2 = strSource.IndexOf(strEnd, stringLength);
			num2 -= stringLength;
			stringLength = num2;
			return strSource.Substring(stringLength, stringLength);
		}
		return "";
	}

	[Token(Token = "0x6000C3D")]
	[Address(RVA = "0x2D57E0", Offset = "0x2D47E0", VA = "0x1802D57E0")]
	private static string doh()
	{
		StreamReader streamReader = new StreamReader("Assets/Resources/Dong/reciep.txt");
		string result = streamReader.ReadToEnd();
		streamReader.Close();
		return result;
	}

	[Token(Token = "0x6000C3E")]
	[Address(RVA = "0x2D4B50", Offset = "0x2D3B50", VA = "0x1802D4B50", Slot = "14")]
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C3F")]
	[Address(RVA = "0x2D4AA0", Offset = "0x2D3AA0", VA = "0x1802D4AA0", Slot = "15")]
	public unsafe void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		//IL_0032: Expected Obj, but got I4
		string arg = product.definition__BackingField.id__BackingField;
		int num = 0;
		string text = string.Format("Purchase failed - Product: '{0}', PurchaseFailureReason: {1}", arg, "Purchase failed - Product: '{0}', PurchaseFailureReason: {1}");
		int num2 = 0;
		((object)text).FieldGetter((string)num2, "Purchase failed - Product: '{0}', PurchaseFailureReason: {1}", ref *(object*)num);
		int isLoad = 0;
		dob((byte)isLoad != 0);
	}

	[Token(Token = "0x6000C40")]
	[Address(RVA = "0x2D5880", Offset = "0x2D4880", VA = "0x1802D5880")]
	public void doi(Product product, PurchaseFailureDescription failureDescription)
	{
		//IL_0071: Expected Obj, but got I4
		string[] array;
		string text3;
		while (true)
		{
			array = new string[6];
			if ("Purchase failed - Product: '" != null && "Purchase failed - Product: '" == null)
			{
				continue;
			}
			array[0] = "Purchase failed - Product: '";
			string text = product.definition__BackingField.id__BackingField;
			if (text != null && "Purchase failed - Product: '" == null)
			{
				continue;
			}
			array[1] = text;
			if ("'," != null && "'," == null)
			{
				continue;
			}
			array[2] = "',";
			PurchaseFailureReason purchaseFailureReason = failureDescription.reason__BackingField;
			string text2 = $" Purchase failure reason: {purchaseFailureReason},";
			if (text2 != null && text2 == null)
			{
				continue;
			}
			array[3] = text2;
			if (" Purchase failure details: " == null || " Purchase failure details: " != null)
			{
				array[4] = " Purchase failure details: ";
				text3 = failureDescription.message__BackingField;
				if (text3 == null || " Purchase failure details: " != null)
				{
					break;
				}
			}
		}
		array[5] = text3;
		string text4 = string.Concat(array);
		int isLoad = 0;
		dob((byte)isLoad != 0);
	}

	[Token(Token = "0x6000C41")]
	[Address(RVA = "0x2D4F20", Offset = "0x2D3F20", VA = "0x1802D4F20", Slot = "9")]
	public override void close()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C42")]
	[Address(RVA = "0x2D4D20", Offset = "0x2D3D20", VA = "0x1802D4D20")]
	public nl()
	{
		//IL_000d: Expected I4, but got I8
		//IL_001a: Expected I4, but got I8
		char[] array = new char[4];
		RuntimeHelpers.InitializeArray(array, __ldtoken(_003CPrivateImplementationDetails_003E._2D41E363EEBD433EBE7B70A4290BF5F96F275A051806DB88A2E7CF77DC95003F));
		ofg = array;
		base._002Ector();
	}
}
