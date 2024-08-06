using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks.Sources;

namespace TreeViewMAUI
{
    public class TreeViewViewModel : INotifyPropertyChanged
    {
        private bool isDownloaded;
        private IList<TaskDetails> jsonCollection;

        public event PropertyChangedEventHandler? PropertyChanged;
        #region Fields

        public IList<TaskDetails> JSONCollection 
        {
            get
            {
                return jsonCollection;
            }
            set
            {
                jsonCollection = value;
                OnPropertyChanged(nameof(JSONCollection));
            }
        }

        public DataServices DataService { get; set; }

        #endregion
        #region Constructor
        public TreeViewViewModel()
        {
            JSONCollection = new ObservableCollection<TaskDetails>();
            DataService = new DataServices();
            GenerateSource();
        }
        #endregion

        #region Generate Source
        private async void GenerateSource()
        {
            isDownloaded = await DataService.DownloadJsonAsync();
            if (isDownloaded)
            {
                var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var fileText = File.ReadAllText(Path.Combine(localFolder, "Data.json"));

                //Read data from the local path and set it to the collection bound to the ListView.
                JSONCollection = JsonConvert.DeserializeObject<IList<TaskDetails>>(fileText);                
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
