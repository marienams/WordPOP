using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace M_MyWordPop2;

public partial class P_Quiz : ContentPage
{

    Random rnd = new Random();
    public string quesDefinition;
    public string quesTerm;
	public P_Quiz()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        GenerateQuestion();
    }


    private void GenerateQuestion()
    {
        var no = rnd.Next(App._scienceTerms.Count);

        string qDefinition = App._scienceTerms[no].definition;
        string qTerm = App._scienceTerms[no].term;


        Question question = new Question
        {
            questionText = $"Mark the correct term for the definition: {qDefinition}",
            answers = new List<Answer> { new Answer { text = $"{qTerm}", isCorrect=true},
                                        new Answer { text = $"{App._scienceTerms[rnd.Next(App._scienceTerms.Count)].term}", isCorrect=false},
                                         new Answer { text = $"{App._scienceTerms[rnd.Next(App._scienceTerms.Count)].term}", isCorrect=false},
                                         new Answer { text = $"{App._scienceTerms[rnd.Next(App._scienceTerms.Count)].term}", isCorrect=false},}

        };
        quesTerm = qTerm;
        BindingContext = question;
    }

    private async void CV_answers_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var ans = CV_answers.SelectedItem as Answer;
        string response;
        string title;
        

        if (ans.isCorrect)
        {
            title = "Well Done";
            response = $"The answer is {ans.text}.\n Would you like to continue?";
            var userResponse = await DisplayAlert(title, response, "Yes", "No");

            if (userResponse)
            {
                GenerateQuestion();
            }
            else
                Shell.Current.FlyoutIsPresented = true;
        }
        else
        {
            title = "Try Again";
            response = $"The right answer is: {quesTerm}\n Would you like to continue?";
            var userResponse = await DisplayAlert(title, response, "Yes", "No");

            if (userResponse)
            {
                GenerateQuestion();
            }
            else
                Shell.Current.FlyoutIsPresented = true;
        }

        
    }

    
}