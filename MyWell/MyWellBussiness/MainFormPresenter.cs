using System;
using Easy.Common.Core;
using MyWellAppEntity;

namespace MyWellBussiness
{
    public class MainFormPresenter : Presenter<IMainForm>
    {
        public MainFormPresenter(IMainForm view)
        {
            this.View = view;
        }

        public override void OnViewInitialized()
        {
            base.OnViewInitialized();
        }

        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
        }
    }
}
