using MOJ.DataManager;
using MOJ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOJ.Business
{
    public class StickyNote
    {
        public List<StickyNotesEntities> GetStickyNotes()
        {
            return new StickyNotesDataManager().GetStickyNotesDataHome();
        }
    }
}
