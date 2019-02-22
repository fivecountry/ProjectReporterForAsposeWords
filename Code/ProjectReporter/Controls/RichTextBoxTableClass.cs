using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProjectReporter.Controls
{
	public class RichTextBoxTableClass : RichTextBox
	{
		private static IntPtr moduleHandle;

		protected override CreateParams CreateParams
		{
			get
			{
				if (RichTextBoxTableClass.moduleHandle == IntPtr.Zero)
				{
					RichTextBoxTableClass.moduleHandle = RichTextBoxTableClass.LoadLibrary("msftedit.dll");
					if ((long)RichTextBoxTableClass.moduleHandle < 32L)
					{
						throw new Win32Exception(Marshal.GetLastWin32Error(), "Could not load Msftedit.dll");
					}
				}
				CreateParams createParams = base.CreateParams;
				createParams.ClassName = "RichEdit50W";
				if (this.Multiline)
				{
					if ((base.ScrollBars & RichTextBoxScrollBars.Horizontal) != RichTextBoxScrollBars.None && !base.WordWrap)
					{
						createParams.Style |= 1048576;
						if ((base.ScrollBars & (RichTextBoxScrollBars)16) != RichTextBoxScrollBars.None)
						{
							createParams.Style |= 8192;
						}
					}
					if ((base.ScrollBars & RichTextBoxScrollBars.Vertical) != RichTextBoxScrollBars.None)
					{
						createParams.Style |= 2097152;
						if ((base.ScrollBars & (RichTextBoxScrollBars)16) != RichTextBoxScrollBars.None)
						{
							createParams.Style |= 8192;
						}
					}
				}
				if (BorderStyle.FixedSingle == base.BorderStyle && (createParams.Style & 8388608) != 0)
				{
					createParams.Style &= -8388609;
					createParams.ExStyle |= 512;
				}
				return createParams;
			}
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr LoadLibrary(string path);

        public const int WM_USER = 0x0400;
        public const int EM_GETPARAFORMAT = WM_USER + 61;
        public const int EM_SETPARAFORMAT = WM_USER + 71;
        public const long MAX_TAB_STOPS = 32;
        public const uint PFM_LINESPACING = 0x00000100;
        [StructLayout(LayoutKind.Sequential)]
        private struct PARAFORMAT2
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT2 lParam);
        /// <summary>
        /// 设置行距
        /// </summary>
        /// <param name="ctl">控件</param>
        /// <param name="dyLineSpacing">间距</param>
        private static void SetLineSpace(Control ctl, int dyLineSpacing)
        {
            PARAFORMAT2 fmt = new PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.bLineSpacingRule = 4;// bLineSpacingRule;
            fmt.dyLineSpacing = dyLineSpacing;
            fmt.dwMask = PFM_LINESPACING;
            try
            {
                SendMessage(new HandleRef(ctl, ctl.Handle), EM_SETPARAFORMAT, 0, ref fmt);
            }
            catch
            {
            }
        }

        /// <summary>
        /// 行间距
        /// </summary>
        /// <param name="lineSpacing">单位磅</param>
        public void SetLineSpaceWithAll(int lineSpacing)
        {
            SetLineSpace(this, lineSpacing * 20);
        }

        /// <summary>
        /// 设置字体名称，颜色，字号
        /// </summary>
        /// <param name="fontColor"></param>
        /// <param name="fontName"></param>
        /// <param name="fontSize"></param>
        public void SetFontWithAll(Color fontColor, string fontName, float fontSize)
        {
            this.SelectionColor = fontColor;
            this.SelectionFont = new Font(fontName, fontSize);
        }

        /// <summary>
        /// 保存并格式化RTF文档
        /// </summary>
        /// <param name="rtfFile"></param>
        public void SaveDoc(string rtfFile)
        {
            SelectAll();

            SetFontWithAll(Color.Black, "仿宋", 12);
            //SetLineSpaceWithAll(25);

            SaveFile(rtfFile);

            Clear();
            LoadDoc(rtfFile);
        }

        public void LoadDoc(string file)
        {

        }
    }
}