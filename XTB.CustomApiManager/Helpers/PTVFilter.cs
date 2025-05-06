using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTB.CustomApiManager.Helpers
{
    public class PTVFilter
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool FilterPlugin { get; set; }
        public string Plugin { get; set; }
        public bool FilterMessage { get; set; }
        public string Message { get; set; }
        public bool FilterEntity { get; set; }
        public string Entity { get; set; }
        public bool FilterCorr { get; set; }
        public string CorrelationId { get; set; }
        public bool FilterReq { get; set; }
        public string RequestId { get; set; }
        public bool FilterFreeMsg { get; set; }
        public bool FilterFreeExc { get; set; }
        public string FreeText { get; set; }
        public bool Exceptions { get; set; }
        public bool OperationPlugin { get; set; } = true;
        public bool OperationWF { get; set; } = true;
        public bool ModeSync { get; set; } = true;
        public bool ModeAsync { get; set; } = true;
        public bool StagePreVal { get; set; } = true;
        public bool StagePreOp { get; set; } = true;
        public bool StageMain { get; set; } = true;
        public bool StagePostOp { get; set; } = true;
        public int MinDuration { get; set; } = -1;
        public int MaxDuration { get; set; } = -1;
        public int Records { get; set; } = 100;
        public bool SuppressSettingWarning { get; set; }
    }
}
