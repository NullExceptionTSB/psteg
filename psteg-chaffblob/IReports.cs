using System.ComponentModel;

namespace psteg.Chaffblob {
    public interface IReports {
        BackgroundWorker ReportsTo { get; set; }
        void ReportProgress(long curr, long max, string state);
    }
}
