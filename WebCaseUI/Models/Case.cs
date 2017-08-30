using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebCaseUI.Models
{
    public class Case
    {
        public int ID { get; set; }

        [DisplayName("Case number")]
        public String caseNumber { get; set; }

        [DisplayName("Kind")]
        public String kind { get; set; }

        [DisplayName("Customer number")]
        public String customerNumber { get; set; }

        [DisplayName("Attachment")]
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