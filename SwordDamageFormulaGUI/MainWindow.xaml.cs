using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SwordDamageFormulaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        SwordDamage swordDamage = new SwordDamage();

        public MainWindow()
        {
            InitializeComponent();
            swordDamage.SetMagic(false);
            swordDamage.SetFlaming(false);
            RollDice();
        }
        public void RollDice()
        {
            swordDamage.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            swordDamage.SetFlaming(flaming.IsChecked.Value);
            swordDamage.SetMagic(magic.IsChecked.Value);
            DisplayDamage();
        }
        public void DisplayDamage()
        {
            damage.Text = "Rolled " + swordDamage.Roll + " for " + swordDamage.Damage + " HP";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }
        private void Flaming_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetFlaming(true);
            DisplayDamage();
        }
        private void Flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetFlaming(false);
            DisplayDamage();
        }
        private void Magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetMagic(true); 
            DisplayDamage();
        }
        private void Magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamage.SetMagic(false);
            DisplayDamage();
        }
    }// The bug here is that DisplayDamage method is used with every box checked/unchecked method, this may undo previous damage calculations made.
     // Or maybe everytime swordDamage.SetFlaming or SetMagic checks are done this method in the swordDamage class keeps resetting or wiping previous calcualtions mad because they always calculate damage.   
}
