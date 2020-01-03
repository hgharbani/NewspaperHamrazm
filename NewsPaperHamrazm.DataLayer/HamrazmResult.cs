using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPaperHamrazm.DataLayer
{
  public  class HamrazmResult
    {
        public HamrazmResult()
        {
            IsChange = true;
        }
        public bool IsChange { get; set; }
        public string Message { get; set; }
        public object ReturnValue { get; set; }
    }
}
