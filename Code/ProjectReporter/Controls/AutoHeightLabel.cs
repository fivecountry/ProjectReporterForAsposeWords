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
                processLabelHeight(value);
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
                    //文本大小
                    System.Drawing.SizeF size = g.MeasureString(value, Font);

                    //文字高度
                    int wordHeight = (int)size.Height;

                    //文本宽度份数
                    int widthCuts = (int)size.Width / Width;
                    if ((int)size.Width % Width > 0)
                    {
                        widthCuts++;
                    }

                    //判断是否我多行文本
                    if (widthCuts > 1)
                    {
                        Height = widthCuts * wordHeight;
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
            else
            {
                //设置初始高度
                Height = 60;
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