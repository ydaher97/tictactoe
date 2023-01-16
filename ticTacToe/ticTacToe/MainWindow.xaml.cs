using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Media;
using System.Windows.Media;

namespace ticTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EType[] results;
        private bool player1;
        private bool endGame;
        public MainWindow()
        {
            InitializeComponent();
            newGAME();
            
        }
        public void newGAME()
        {
            results = new EType[9];
            for (var i = 0; i < results.Length; i++)
                results[i] = EType.free;

            player1 = true;

            contaner.Children.Cast<Button>().ToList().ForEach(Button =>
            {
                Button.Content = string.Empty;
                Button.Foreground = Brushes.Blue;
            });
            endGame = false;
            
        }
        private void Winner()
        {
            //row0
            if(results[0] != EType.free && (results[0] & results[1] & results[2]) == results[0])
            {
                endGame = true;

                btn00.Background = btn1_0.Background = btn2_0.Background = Brushes.Green;
            }
            //row1
            if (results[3] != EType.free && (results[3] & results[4] & results[5]) == results[3])
            {
                endGame = true;

                btn01.Background = btn1_1.Background = btn2_1.Background = Brushes.Green;
            }
            //row2
            if (results[6] != EType.free && (results[6] & results[7] & results[8]) == results[6])
            {
                endGame = true;

               btn0_2.Background = btn1_2.Background = btn2_2.Background = Brushes.Green;
            }
            //diagonal
            if (results[0] != EType.free && (results[0] & results[4] & results[8]) == results[0])
            {
                endGame = true;

                btn00.Background = btn1_1.Background = btn2_2.Background = Brushes.Green;
            }
            //diagonal
            if (results[2] != EType.free && (results[2] & results[4] & results[6]) == results[2])
            {
                endGame = true;

                btn2_0.Background = btn1_1.Background = btn0_2.Background = Brushes.Green;
            }
            //col0
            if (results[0] != EType.free && (results[0] & results[3] & results[6]) == results[0])
            {
                endGame = true;

                btn00.Background = btn01.Background = btn0_2.Background = Brushes.Green;
            }
            //col1
            if (results[1] != EType.free && (results[1] & results[4] & results[7]) == results[1])
            {
                endGame = true;

                btn1_0.Background = btn1_1.Background = btn1_2.Background = Brushes.Green;
            }
            //col2
            if (results[2] != EType.free && (results[2] & results[5] & results[8]) == results[2])
            {
                

                btn2_0.Background = btn2_1.Background = btn2_2.Background = Brushes.Green;
                endGame = true;
            }
           
            if (!results.Any(T => T == EType.free))
            {
                endGame = false;

                contaner.Children.Cast<Button>().ToList().ForEach(Button =>
                {
                    
                    Button.Foreground = Brushes.Orange;
                   
                });
                
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if(endGame)
            {
                newGAME();

                
                return;
            }
            

            //find the nuttons position 
            var Col = Grid.GetColumn(button);
            var Row = Grid.GetRow(button);

            var i = Col + (Row * 3);

            if (results[i] != EType.free)
                return;
            //set the cell value based on which players turn it is
            results[i] = player1 ? EType.cross : EType.nought;
            //set txst to the result
            button.Content = player1 ? "X" : "O";

            if (!player1)
                button.Foreground = Brushes.Red;

            //player turn
            player1 ^= true;

            Winner();
        }

    }
}
