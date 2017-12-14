using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Performances.Model
{
    public class File
    {
        public string Path { get; set; }
        public int OwnerId { get; set; }
        public string FileExtension { get; set; }
    }
}
