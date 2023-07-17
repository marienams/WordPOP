using System.Collections.ObjectModel;
using System.Text.Json;

namespace M_MyWordPop2;

public partial class App : Application
{

	public static ObservableCollection<ScienceTerm> _scienceTerms;
    public static ObservableCollection<ScienceTerm> temp;
    public static string _dataPath = FileSystem.AppDataDirectory;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override async void OnStart()
    {
        base.OnStart();
        _scienceTerms = await MyStorage.GetEmbeddedXML<ObservableCollection<ScienceTerm>>("ScienceTerms.xml");
        if (_scienceTerms == null)
            _scienceTerms = new ObservableCollection<ScienceTerm>();

        var file = Path.Combine(App._dataPath, "ScienceTerm.jsn");
        string dataString = "";

            try
            {
                dataString = File.ReadAllText(file);
                temp = JsonSerializer.Deserialize<ObservableCollection<ScienceTerm>>(dataString);
            }
            catch (Exception)
            {

            }

        if (temp == null)
            temp = new ObservableCollection<ScienceTerm>();

        foreach (var item in temp)
        {
            App._scienceTerms.Add(item);
        }

        
        //await Shell.Current.DisplayAlert("hint", $"the data is... ", "OK");
    }

    //protected override void OnSleep()
    //{
    //    var file = Path.Combine(App._dataPath, "temp_ScienceTerm.jsn");
    //    string datastring;
    //    List<string> n_term = new List<string>();
    //    List<string> n_definition = new List<string>();
    //    base.OnSleep();

    //    foreach (var item in App._scienceTerms)
    //        if (item.isEditable)
    //        {
    //            n_term.Add(item.term);
    //            n_definition.Add(item.definition);
    //        }
    //    datastring = JsonSerializer.Serialize(n_term);
    //    File.WriteAllText(file, dataString);

    //}
}
