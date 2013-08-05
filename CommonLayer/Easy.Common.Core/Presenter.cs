using System;

namespace Easy.Common.Core
{
    public abstract class Presenter<TView> where TView : IView
    {
        public TView View { get; set; }

        /// <summary>
        /// 视图初始化
        /// </summary>
        public virtual void OnViewInitialized()
        {
        }

        /// <summary>
        /// 视图加载
        /// </summary>
        public virtual void OnViewLoaded()
        {
        }
    }
}
