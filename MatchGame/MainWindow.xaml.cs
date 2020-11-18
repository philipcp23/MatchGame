using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            // Create a list of eight pairs of emojis
            List<string> emoji = new List<string>()
            {

                "👀","👀",
                "❤", "❤",
                "😎", "😎",
                "🙌", "🙌",
                "🎉", "🎉",
                "✔", "✔",
                "✌", "✌",
                "🎂", "🎂",
            };

            // Create a new random number generator
            Random random = new Random();

            // Find every TextBlock in the main grid and repeat the following statements for each of them
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                // Pick a random number between 0 and the number of emoji left in the list
                int index = random.Next(emoji.Count);
                // Use the random number called "index" to get a random emoji from the list
                string nextEmoji = emoji[index];
                // Update the TextBlock with the random emoji from the list                
                textBlock.Text = nextEmoji;
                //Remove the random emoji from the list
                emoji.RemoveAt(index);
            }
        }


        TextBlock lastTextBlockClicked;
        bool findMatching = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;

            // Initial click
            if (findMatching == false)
            {
                // Initial emoji selected make hidden
                textBlock.Visibility = Visibility.Hidden;
                // Set the state of lastTextBlockClicked
                lastTextBlockClicked = textBlock;
                // Set findMatching to true
                findMatching = true;
            }
            // Second click if same emoji
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                // Set the textBlock to be hidden
                textBlock.Visibility = Visibility.Hidden;
                // Set findMatching back to false-true match
                findMatching = false;
            }
            // Second click does not match emoji
            else
            {
                // Make the first emoji visible
                lastTextBlockClicked.Visibility = Visibility.Visible;
                // Set findMatching back to false-false match
                findMatching = false;
            }
        }
    }
}
