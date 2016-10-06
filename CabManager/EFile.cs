using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CabManager
{
    class EFile
    {
        public Icon FileIcon { get; set; }
        public string FileName { get; set; }
        public DateTime LastUpDate { get; set; }
        public long Lenght { get; set; }
        public string Source { get; set; }
    }
}
