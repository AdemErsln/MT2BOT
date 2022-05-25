using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MT2BOT
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        int defaulProcessId, currentProcessId;
        int processId = 0;
        DispatcherTimer timer;
        
        public MainWindow()
        {
            InitializeComponent();
            
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
            defaulProcessId = User.GetForegroundWindow();
        }
        EButton.Button btn = new EButton.Button();
        short f4= (short)EButton.Button.BT7.F4;
        short space = (short)EButton.Button.BT7.SPACE;
        short z= (short)EButton.Button.BT7.KEY_Z;

        void AttractAndAttackMobs()
        {
            currentProcessId = User.GetForegroundWindow();
            User.ShowWindow(processId,1);
            User.SetForegroundWindow(processId);
            Thread.Sleep(200);
            btn.PressKey(space);
            Thread.Sleep(30);
            btn.PressKey(f4);
            Thread.Sleep(30);
            btn.PressKey(z);

            if(currentProcessId != currentProcessId)
            {
                User.SetForegroundWindow(currentProcessId);
            }
            else
            {
                User.SetForegroundWindow(defaulProcessId);
            }
        }
        
        private void Timer_Tick(object sender ,EventArgs e)
        {
            AttractAndAttackMobs();
        }

       


       

        private void List_KeyDown(object sender, RoutedEventArgs e)
        {
            process_list.Items.Clear();

            for (int window = User.GetWindow(User.GetDesktopWindow(), 5); window != 0; window = User.GetWindow(window, 2))
            {

                if (window == hndl().ToInt32())
                {
                    window = User.GetWindow(window, 2);
                }
                if (User.IsWindowVisible(window) != 0)
                {
                    StringBuilder _stringBuilder = new StringBuilder(50);
                    User.GetWindowText(window, _stringBuilder, _stringBuilder.Capacity);
                    string text = _stringBuilder.ToString();
                    if (text.Length > 0)
                    {
                        process_list.Items.Add(new MyProcess(text, window));
                    }
                }
         
            }

            process_list.DisplayMemberPath = "ProcessName";
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
           
            }

        private void process_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void process_list_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            processId = (((ListBox)sender).SelectedItem as MyProcess).ProcessId;
            var processNamee = (((ListBox)sender).SelectedItem as MyProcess).ProcessName;

            
            //this.ShowMessageAsync("This is the title", processNamee);
        server_name.Content = processNamee;




        }

        private void start_Click_1(object sender, RoutedEventArgs e)
        {
            if (processId == 0)
            {
                return;
            }
            timer.Start();
        }

        private void stop_Click(object sender, KeyEventArgs e)
        {
        }

        private void stop_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();

        }

        IntPtr hndl()
        {
            return new WindowInteropHelper(this).Handle;
        }
    }
}
