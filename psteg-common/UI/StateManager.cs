using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psteg.UI {
    public class StateManager {
        public ProgressBar ProgressBar { get; set; }
        public Label Status { get; set; }
        public int StateChangeDenominator { get; set; } = 1;
        public bool Suppress { get; set; } = true;

        public int Progress { get; private set; }
        public int ProgressMaximum { get; private set; }
        public string State { get; set; }

        public bool Indefinite { get; set; }

        private int prog_remainder = 0;

        protected virtual void HandleError(string error) {
            if (!Suppress) throw new Exception(error);
        }

        public void UpdateDisplay() {
            if (ProgressBar != null) {
                if (!Indefinite) {
                    ProgressBar.Maximum = ProgressMaximum;
                    ProgressBar.Value = Progress;

                    ProgressBar.Style = ProgressBarStyle.Continuous;
                } else
                    ProgressBar.Style = ProgressBarStyle.Marquee;
            }

            if (Status != null)
                Status.Text = State;
        }

        public void IncrementProgress(int ammt) {
            if (Indefinite) return;
            prog_remainder += ammt;
            if (Math.Abs(prog_remainder) >= StateChangeDenominator)
                _ = ProgressBar.Invoke(new Action(() => { UpdateState(Progress + (prog_remainder / StateChangeDenominator), ProgressMaximum, State); }));
            prog_remainder %= StateChangeDenominator;
        }

        public void UpdateState(int curr, int max, string state) {
            Indefinite = false;
            if (ProgressBar != null) { 
                if (curr > max) {
                    HandleError("Attempted to set state larger then maximum");
                    return;
                } else if (curr < 0) {
                    HandleError("Attempted to set state smaller than 0");
                    return;
                }
                Progress = curr;
                ProgressMaximum = max;
            }

            if (Status != null)
                State = state;
            UpdateDisplay();
        }

        public void UpdateState(string state) {
            Indefinite = true;
            if (ProgressBar != null) 
                ProgressBar.Style = ProgressBarStyle.Marquee;

            if (Status != null) 
                State = Status.Text = state;
            
        }

        public void UpdateState(ProgressState state) {
            if (state.IndefProgress)
                UpdateState(state.State);
            else
                UpdateState(state.Current, state.Maximum, state.State);
        }

        public StateManager(ProgressBar ProgressBar, Label Status) {
            this.ProgressBar = ProgressBar;
            this.Status = Status;

            if (ProgressBar != null) {
                Progress = ProgressBar.Value;
                ProgressMaximum = ProgressBar.Maximum;
                Indefinite = (ProgressBar.Style == ProgressBarStyle.Marquee);
            }

            if (Status != null)
                State = Status.Text;

        }
    }
}
