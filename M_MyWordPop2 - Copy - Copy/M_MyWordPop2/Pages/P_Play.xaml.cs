

using System.Security.Cryptography.X509Certificates;

namespace M_MyWordPop2;

public partial class P_Play : ContentPage
{
    Random rnd = new Random();
    public string answer;
    

    public P_Play()
    {
        InitializeComponent();
        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        levelQuestion();
    }

    private void levelQuestion()
    {
        Entry_answer.Text = "";
        int index = rnd.Next(2);
         int no = rnd.Next(App._scienceTerms.Count);
         string qDefinition = App._scienceTerms[no].definition;
        string qTerm = App._scienceTerms[no].term;

    Game_Questions question = new Game_Questions
        {
            questionText=$"{qDefinition}",
            answerText =qTerm
            

        };

        answer = qTerm.ToLower();

        BindingContext = question;
    }

    private async void Btn_CheckAnswer_Clicked(object sender, EventArgs e)
    {
        var ans = Entry_answer.Text.ToLower();
        
            if(ans == answer)
            {
                await DisplayAlert("Good", "Correct answer\nYour player moves a step up!", "OK");
                PlayerMove();
                levelQuestion();
                
            }
            else
            {
                var response = await DisplayAlert("Sorry", $"The correct answer is: {answer}\nReview terms and definitions?","Yes","no");
            if (response)
            {
                await Navigation.PushAsync(new P_TermDefinition());
            }
            else
                levelQuestion();

        }
        
    }
    private void PlayerMove()
    {
        var curr_row = Grid.GetRow(Player);
        var curr_col = Grid.GetColumn(Player);
        if (curr_row != 0 )
        {
            Grid.SetRow(Player, curr_row - 1);
            Grid.SetColumn(Player, curr_col + 1);
        }
        else
        {
            Grid.SetRow(Player, 5);
            Grid.SetColumn(Player, 0);
        }
        
    }

    private void game_help_Clicked(object sender, EventArgs e)
    {
        
        var len = answer.Length;
        DisplayAlert("Hint", $"The answer starts with letter: {answer[0]}", "Ok");
        
        
    }
}