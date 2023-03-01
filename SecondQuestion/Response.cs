using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondQuestion
{
   public class Response
    {
        public string Locale { get; set; }
        public string Description { get; set; }
        public BoundingPoly BoundingPoly { get; set; }
        
    }
    public class BoundingPoly
    {
        public List<Vertices> Vertices { get; set; }
    }
    public class Vertices
    {
        public int X { get; set; }
        public int Y { get; set; }

    }
}
