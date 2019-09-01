using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace MOJ.Intranet.Classes.Common
{
    public class SiteUI : UserControl
    {
        #region RefreshChecking

        public bool _refreshState;
        public bool _isRefresh;
        public bool IsRefresh
        {
            get { return _isRefresh; }
        }
        protected override void LoadViewState(object savedState)
        {
            object[] allStates = (object[])savedState;
            base.LoadViewState(allStates[0]);
            _refreshState = (bool)allStates[1];
            //if (HttpContext.Current.Session["__ISREFRESH"] != null)
            //    _isRefresh = _refreshState == (bool)HttpContext.Current.Session["__ISREFRESH"];
            //else
            //    _isRefresh = _refreshState;

            if (HttpContext.Current.Session["__ISREFRESH"] != null)
                _isRefresh = _refreshState == (bool)HttpContext.Current.Session["__ISREFRESH"];
            else
                _isRefresh = _refreshState;
        }
        protected override object SaveViewState()
        {
            HttpContext.Current.Session["__ISREFRESH"] = _refreshState;
            object[] allStates = new object[2];
            allStates[0] = base.SaveViewState();
            allStates[1] = !_refreshState;
            return allStates;
        }
        #endregion RefreshChecking
    }
}
