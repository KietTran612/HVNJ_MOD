using System.Reflection;
using Cpp2IlInjected;
using UnityEngine;

[Token(Token = "0x2000161")]
[Obfuscation]
public class ClassAndroid : MonoBehaviour
{
	[Token(Token = "0x2000162")]
	private class IActionIP : hi
	{
		[Token(Token = "0x6000C1B")]
		[Address(RVA = "0x1EC290", Offset = "0x1EB290", VA = "0x1801EC290")]
		public IActionIP()
		{
		}

		[Token(Token = "0x6000C1C")]
		[Address(RVA = "0x274190", Offset = "0x273190", VA = "0x180274190", Slot = "4")]
		public void perform(string text)
		{
			string text2 = "ppppppppppppppppppppppp: " + text;
		}
	}

	[FieldOffset(Offset = "0x18")]
	[Token(Token = "0x4001775")]
	private int a0;

	[Token(Token = "0x6000C0A")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	private void Start()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C0B")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void doLoginFB()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C0C")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void doLogin()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C0D")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void doLoginApple()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C0E")]
	[Address(RVA = "0x60DB90", Offset = "0x60CB90", VA = "0x18060DB90")]
	[Obfuscation]
	public void loginGGError(string error)
	{
		int num = 0;
		SDKPopup.dol().dph(error);
	}

	[Token(Token = "0x6000C0F")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void doLogout()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C10")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void doPayment()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C11")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	public void openNew()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C12")]
	[Address(RVA = "0x60DF00", Offset = "0x60CF00", VA = "0x18060DF00")]
	public void testClass(string test)
	{
		hw.ccc("testClass: " + test);
	}

	[Token(Token = "0x6000C13")]
	[Address(RVA = "0x60DA90", Offset = "0x60CA90", VA = "0x18060DA90")]
	public string isLogin(int a0)
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C14")]
	[Address(RVA = "0x1A7F10", Offset = "0x1A6F10", VA = "0x1801A7F10")]
	private void Update()
	{
		throw new AnalysisFailedException("CPP2IL failed to recover any usable IL for this method.");
	}

	[Token(Token = "0x6000C15")]
	[Address(RVA = "0x60DD50", Offset = "0x60CD50", VA = "0x18060DD50")]
	[Obfuscation]
	public void logoutSuccess(string token)
	{
		string text = "logoutSuccess: " + token;
		hw.ccc("logoutSuccess: " + token);
	}

	[Token(Token = "0x6000C16")]
	[Address(RVA = "0x60DC00", Offset = "0x60CC00", VA = "0x18060DC00")]
	[Obfuscation]
	public void loginSuccess(string token)
	{
		int num = 0;
		SDKPopup.dol().dpl(token);
	}

	[Token(Token = "0x6000C17")]
	[Address(RVA = "0x60DB20", Offset = "0x60CB20", VA = "0x18060DB20")]
	[Obfuscation]
	public void loginAppleSuccess(string token)
	{
		int num = 0;
		SDKPopup.dol().dpm(token);
	}

	[Token(Token = "0x6000C18")]
	[Address(RVA = "0x60DDE0", Offset = "0x60CDE0", VA = "0x18060DDE0")]
	public void onRegisterSuccess(string token)
	{
		string text = "onRegisterSuccess: " + token;
		int num = 0;
		if ((long)bg.frk == 0)
		{
			int num2 = 0;
			hw.ccn();
		}
	}

	[Token(Token = "0x6000C19")]
	[Address(RVA = "0x60DC70", Offset = "0x60CC70", VA = "0x18060DC70")]
	public void loginToServer(string token)
	{
		int num = 0;
		if ((long)bg.frk == 0)
		{
			int num2 = 0;
			hw.ccn();
		}
	}

	[Token(Token = "0x6000C1A")]
	[Address(RVA = "0x282A90", Offset = "0x281A90", VA = "0x180282A90")]
	public ClassAndroid()
	{
	}
}
