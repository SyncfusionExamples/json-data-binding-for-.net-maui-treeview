# -json-data-binding-for-.net-maui-treeview
This repository demonstrates how to bind JSON data to the .NET MAUI TreeView (SfTreeView) control. It provides a sample implementation that downloads and deserializes hierarchical JSON data, maps it to data models, and binds it to the TreeView using the ItemsSource property for dynamic and structured data display.

## Sample
The Syncfusion® .NET MAUI TreeView enables you to bind data from a JSON file using the ItemsSource property. This demonstration will guide you through the process of binding JSON Collection to the TreeView.

### XAML
```xaml
<ContentPage.BindingContext>
    <local:TreeViewViewModel x:Name="viewModel"/>
</ContentPage.BindingContext>
<syncfusion:SfTreeView x:Name="treeView" Margin="10"
                        ItemTemplateContextType="Node"                          
                        ItemsSource="{Binding JSONCollection}"                           
                        ChildPropertyName="SubTaskDetails">
    <syncfusion:SfTreeView.Behaviors>
        <local:TreeViewBehavior/>
    </syncfusion:SfTreeView.Behaviors>
</syncfusion:SfTreeView>
```

### View Model
```csharp
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

    #endregion
}
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements).

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.