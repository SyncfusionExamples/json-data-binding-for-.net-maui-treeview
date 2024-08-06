using System.Collections.ObjectModel;

namespace TreeViewMAUI
{
    public class TaskDetails
    {        
        public int TaskID { get; set; }
        public string TaskName { get; set; }        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Duration { get; set; }
        public string Progress { get; set; }
        public string Pirority { get; set; }        
        public bool IsParent { get; set; }

        public ObservableCollection<TaskDetails> SubTaskDetails { get; set; }

        internal int ParentItem { get; set; }
        public TaskDetails()
        {
            SubTaskDetails = new ObservableCollection<TaskDetails>();
        }
    }
}
