using System;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Platform;

using System.Text;

using Avalonia.Controls.Platform;


namespace NativeControlHostDemo;

public interface INativeDemoControl
{
    /// <param name="isSecond">Used to specify which control should be displayed as a demo</param>
    /// <param name="parent"></param>
    /// <param name="createDefault"></param>
    IPlatformHandle CreateControl(bool isSecond, IPlatformHandle parent, Func<IPlatformHandle> createDefault);
}

public class EmbedSample :  NativeControlHost
{
    public static INativeDemoControl? Implementation { get; set; } = new EmbedSampleWin();

    static EmbedSample()
    {

    }

    public bool IsSecond { get; set; }

    protected override IPlatformHandle CreateNativeControlCore(IPlatformHandle parent)
    {
        return Implementation?.CreateControl(IsSecond, parent, () => base.CreateNativeControlCore(parent))
               ?? base.CreateNativeControlCore(parent);
    }

    protected override void DestroyNativeControlCore(IPlatformHandle control)
    {
        base.DestroyNativeControlCore(control);
    }
}



public class EmbedSampleWin : INativeDemoControl
{
    private const string RichText =
        @"{\rtf1\ansi\ansicpg1251\deff0\nouicompat\deflang1049{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
{\colortbl ;\red255\green0\blue0;\red0\green77\blue187;\red0\green176\blue80;\red155\green0\blue211;\red247\green150\blue70;\red75\green172\blue198;}
{\*\generator Riched20 6.3.9600}\viewkind4\uc1 
\pard\sa200\sl276\slmult1\f0\fs22\lang9 <PREFIX>I \i am\i0  a \cf1\b Rich Text \cf0\b0\fs24 control\cf2\fs28 !\cf3\fs32 !\cf4\fs36 !\cf1\fs40 !\cf5\fs44 !\cf6\fs48 !\cf0\fs44\par
}";

    public IPlatformHandle CreateControl(bool isSecond, IPlatformHandle parent, Func<IPlatformHandle> createDefault)
    {
        WinApi.LoadLibrary("Msftedit.dll");
        var handle = WinApi.CreateWindowEx(0, "RICHEDIT50W",
            @"Rich Edit",
            0x800000 | 0x10000000 | 0x40000000 | 0x800000 | 0x10000 | 0x0004, 0, 0, 1, 1, parent.Handle,
            IntPtr.Zero, WinApi.GetModuleHandle(null), IntPtr.Zero);
        var st = new WinApi.SETTEXTEX { Codepage = 65001, Flags = 0x00000008 };
        var text = RichText.Replace("<PREFIX>", isSecond ? "\\qr " : "");
        var bytes = Encoding.UTF8.GetBytes(text);
        WinApi.SendMessage(handle, 0x0400 + 97, ref st, bytes);
        return new Win32WindowControlHandle(handle, "HWND");
    }
}

internal class Win32WindowControlHandle : PlatformHandle, INativeControlHostDestroyableControlHandle
{
    public Win32WindowControlHandle(IntPtr handle, string descriptor) : base(handle, descriptor)
    {
    }

    public void Destroy()
    {
        _ = WinApi.DestroyWindow(Handle);
    }
}

internal  class WinApi
{
    public enum CommonControls : uint
    {
        ICC_LISTVIEW_CLASSES = 0x00000001, // listview, header
        ICC_TREEVIEW_CLASSES = 0x00000002, // treeview, tooltips
        ICC_BAR_CLASSES = 0x00000004, // toolbar, statusbar, trackbar, tooltips
        ICC_TAB_CLASSES = 0x00000008, // tab, tooltips
        ICC_UPDOWN_CLASS = 0x00000010, // updown
        ICC_PROGRESS_CLASS = 0x00000020, // progress
        ICC_HOTKEY_CLASS = 0x00000040, // hotkey
        ICC_ANIMATE_CLASS = 0x00000080, // animate
        ICC_WIN95_CLASSES = 0x000000FF,
        ICC_DATE_CLASSES = 0x00000100, // month picker, date picker, time picker, updown
        ICC_USEREX_CLASSES = 0x00000200, // comboex
        ICC_COOL_CLASSES = 0x00000400, // rebar (coolbar) control
        ICC_INTERNET_CLASSES = 0x00000800,
        ICC_PAGESCROLLER_CLASS = 0x00001000, // page scroller
        ICC_NATIVEFNTCTL_CLASS = 0x00002000, // native font control
        ICC_STANDARD_CLASSES = 0x00004000,
        ICC_LINK_CLASS = 0x00008000
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INITCOMMONCONTROLSEX
    {
        public int dwSize;
        public uint dwICC;
    }

    [DllImport("Comctl32.dll")]
    public static extern void InitCommonControlsEx(ref INITCOMMONCONTROLSEX init);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool DestroyWindow(IntPtr hwnd);

    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string lib);


    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr CreateWindowEx(
        int dwExStyle,
        string lpClassName,
        string lpWindowName,
        uint dwStyle,
        int x,
        int y,
        int nWidth,
        int nHeight,
        IntPtr hWndParent,
        IntPtr hMenu,
        IntPtr hInstance,
        IntPtr lpParam);

    [StructLayout(LayoutKind.Sequential)]
    public struct SETTEXTEX
    {
        public uint Flags;
        public uint Codepage;
    }

    [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendMessageW")]
    public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, ref SETTEXTEX wParam, byte[] lParam);
}