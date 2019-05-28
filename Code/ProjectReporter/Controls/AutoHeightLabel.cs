using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectReporter.Controls
{
    /// <summary>
    /// 自适应高度标签
    /// </summary>
    public class AutoHeightLabel : Label
    {
        private bool autoHeight = false;
        /// <summary>
        /// 是否需要自适应高度
        /// </summary>
        public bool AutoHeight
        {
            get { return autoHeight; }
            set { autoHeight = value; }
        }

        /// <summary>
        /// 当前文本
        /// </summary>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                //设置文本
                base.Text = value;

                //处理标签框高度
                processLabelHeight(base.Text);
            }
        }

        /// <summary>
        /// 处理标签框高度
        /// </summary>
        /// <param name="value">文本</param>
        private void processLabelHeight(string value)
        {
            //判断是否需要处适应高度
            if (AutoHeight)
            {
                //检测文本的宽度和高度
                System.Drawing.Graphics g = CreateGraphics();
                try
                {
                    //设置单位为像素
                    g.PageUnit = System.Drawing.GraphicsUnit.Pixel;

                    //文本大小
                    System.Drawing.SizeF totalSize = g.MeasureString(value, Font);

                    //单字大小
                    System.Drawing.SizeF wordSize = g.MeasureString("王", Font);

                    //单字高度
                    int wordHeight = (int)wordSize.Height;
                    //单字宽度
                    int wordWidth = (int)wordSize.Width;
                    
                    //文本行数
                    int widthRowCount = 0;

                    //判断是否一行能显示完
                    if (Width > totalSize.Width)
                    {
                        //可以显示在一行
                        widthRowCount = 1;
                    }
                    else
                    {
                        //不能显示在一行
                        widthRowCount = (int)totalSize.Width / Width;
                        int widthElse = (int)totalSize.Width % Width;
                        if (widthElse > wordWidth)
                        {
                            widthRowCount++;
                        }
                    }

                    //判断是否我多行文本
                    if (widthRowCount > 1)
                    {
                        Height = widthRowCount * wordHeight;
                    }
                    else
                    {
                        Height = wordHeight;
                    }
                }
                finally
                {
                    //结束绘图板
                    g.Dispose();
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //处理标签框高度
            processLabelHeight(Text);
        }
    }
}