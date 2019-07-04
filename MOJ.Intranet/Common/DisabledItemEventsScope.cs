using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace SP.Common
{
    public class DisabledItemEventsScope : SPItemEventReceiver, IDisposable
    {
        bool oldValue;

        public DisabledItemEventsScope()
        {
            this.oldValue = base.EventFiringEnabled;
            base.EventFiringEnabled = false;
        }

        #region IDisposable Members

        public void Dispose()
        {
            base.EventFiringEnabled = oldValue;
        }

        #endregion
    }
}
