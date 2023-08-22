using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotasEstudiante
{
    public class Note
    {
        public decimal note { get; set; }
        public int maximumNote { get; set; }
        public string type { get; set; }
        public string typeNote { get; set; }

        public Note(decimal note, int maximumNote, string type, string typeNote)
        {
            this.note = note;
            this.maximumNote = maximumNote;
            this.type = type;
            this.typeNote = typeNote;
        }

    }
}