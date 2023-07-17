using System.Collections.ObjectModel;
using System.Text.Json;

namespace M_MyWordPop2;

public partial class P_TermDefinition : ContentPage
{
	public P_TermDefinition()
	{
		InitializeComponent();
        
        
	}



    protected override void OnAppearing()
    {
        base.OnAppearing();


        CV_TermDefinition.ItemsSource = App._scienceTerms;


    }

    private void SBar_FilterTerm_TextChanged(object sender, TextChangedEventArgs e)
    {
        var filter = SBar_FilterTerm.Text.ToLower();
        var lst = (from p in App._scienceTerms
                   where p.term.ToLower().Contains(filter)
                   select p).ToList();

        CV_TermDefinition.ItemsSource = lst;
    }

    private void Btn_AddTerm_Clicked(object sender, EventArgs e)
    {
        var n_term = Entry_newTerm.Text;
        var n_definition = Entry_newDefinition.Text;

        App._scienceTerms.Add(new ScienceTerm { term = n_term, definition = n_definition, isEditable=true });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        var file = Path.Combine(App._dataPath, "ScienceTerm.jsn");
        var temp = new List<ScienceTerm>();

        foreach (var item in App._scienceTerms)
            if (item.isEditable)
                temp.Add(item);
                
        var dataString = JsonSerializer.Serialize(temp);
        File.WriteAllText(file, dataString);
        
    }

    private void Btn_DelTerm_Clicked(object sender, EventArgs e)
    {
        var item = CV_TermDefinition.SelectedItem as ScienceTerm;
        if (item != null && item.isEditable)
        {
            App._scienceTerms.Remove(item);
        }
        else
            DisplayAlert("Dear User", "Please select a term added by you", "OK");
    }
}