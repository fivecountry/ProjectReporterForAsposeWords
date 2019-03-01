using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectReporter.Controls
{
    public delegate void SaveOrLastOrNextEventDelegate(object sender,EventArgs args);

	public partial class BaseEditor: UserControl
	{
        private bool _enabledAutoNextPage = true;
        public bool EnabledAutoNextPage
        {
            get
            {
                return _enabledAutoNextPage;
            }

            set
            {
                _enabledAutoNextPage = value;
            }
        }

        public new MainForm ParentForm { get; set; }
        
        public event SaveOrLastOrNextEventDelegate SaveEvent;

        public event SaveOrLastOrNextEventDelegate LastEvent;

        public event SaveOrLastOrNextEventDelegate NextEvent;

		public BaseEditor()
		{
			InitializeComponent();
		}

        public virtual void OnSaveEvent()
        {
            if (SaveEvent != null)
            {
                SaveEvent(this, new EventArgs());
           }
        }

        public virtual void OnLastEvent()
        {
            if (LastEvent != null)
            {
                LastEvent(this, new EventArgs());
            }
        }

        public virtual void OnNextEvent()
        {
            if (NextEvent != null)
            {
                NextEvent(this, new EventArgs());
            }
        }

        /// <summary>
        /// 清理视图
        /// </summary>
        public virtual void ClearView() { }

        /// <summary>
        /// 刷新视图
        /// </summary>
        public virtual void RefreshView() { }

        /// <summary>
        /// 下一页（自定义）
        /// </summary>
        public virtual void NextPage() { }

        /// <summary>
        /// 是否输入完成
        /// </summary>
        /// <returns></returns>
        public virtual bool IsInputCompleted() { return false; }
	}
}