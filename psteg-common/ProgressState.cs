namespace psteg {
    public struct ProgressState {
        public int Current;
        public int Maximum;
        
        public string State;
        public bool IndefProgress;

        public ProgressState (int current, int maximum, string state = null, bool indef = false) {
            Current = current;
            Maximum = maximum;
            State = state;
            IndefProgress = indef;
        }
    }
}
