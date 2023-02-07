using System.ComponentModel;

namespace psteg_chaffblob {
    public interface IReports {
        BackgroundWorker ReportsTo { get; set; }
        void ReportProgress(long curr, long max, string state);
    }
}
