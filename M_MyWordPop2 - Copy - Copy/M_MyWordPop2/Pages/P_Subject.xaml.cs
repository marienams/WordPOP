namespace M_MyWordPop2;

public partial class P_Subject : ContentPage
{
	public P_Subject()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        CV_Subject.ItemsSource = App._scienceTerms;
    }
}