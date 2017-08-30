using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCaseUI.Models
{
    public class Case
    {
        public int ID { get; set; }

        public String caseNumber { get; set; }

        public String kind { get; set; }

        public String customerNumber { get; set; }

        public String attachment { get; set; }

        public override string ToString()
        {
            return String.Format("Case Number: {0}, Kind:{1}", caseNumber, kind);
        }


        // public String status { get; set; }

        //  public String resolution { get; set; }

        //   public String importance { get; set; }

        //   public String title { get; set; }

        //   public String details { get; set; }

        //   public String arrangementNumber { get; set; }
    }
}