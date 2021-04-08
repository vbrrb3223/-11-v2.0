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
using System.Windows.Threading;

namespace Лабиринт__11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromMinutes(1.0 / 800) };
        DispatcherTimer timer1 = new DispatcherTimer() { Interval = TimeSpan.FromMinutes(1.0 / 4000) };
        DispatcherTimer timer2 = new DispatcherTimer() { Interval = TimeSpan.FromMinutes(1.0 / 10000) };
        public MainWindow()
        {
            InitializeComponent();
            timer.Start();
            timer.Tick += Timer_Tick;
            timer1.Start();
            timer1.Tick += Timer_Tick1;
            timer2.Start();
            timer2.Tick += Timer_Tick2;
        }
        bool error = false;
        int countErr = 0;
        int urNum = 1;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (error)
            {
                errorEl.Visibility = Visibility.Visible;
                if (countErr < 6)
                {
                    if (countErr % 2 == 0)
                        errorEl.Fill = Brushes.Red;
                    else
                        errorEl.Fill = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF8BC5C5");
                    countErr++;
                }
                else
                    error = false;
            }
        }
        int count = 0;

        private void Timer_Tick1(object sender, EventArgs e)
        {
            if (prBarSet)
            {
                if (prBarVal < prBar.Value)
                {
                    if (count < 19)
                    {

                        if (count % 3 == 0)
                        {
                            prBar.Value--;
                            prBarLabel.Content = prBar.Value + " %";
                        }
                    }
                    else
                    {
                        prBar.Value--;
                        prBarLabel.Content = prBar.Value + " %";
                    }
                }
                else if (prBarVal > prBar.Value)
                {
                    if (count < 19)
                    {
                        if (count % 3 == 0)
                        {
                            prBar.Value++;
                            prBarLabel.Content = prBar.Value + " %";
                        }
                    }
                    else
                    {
                        prBar.Value++;
                        prBarLabel.Content = prBar.Value + " %";
                    }
                }
                else
                {
                    prBarSet = false;
                    count = 0;
                }
                count++;
            }

        }
        int k = -108;
        private void Timer_Tick2(object sender, EventArgs e)
        {
            if (winner)
            {
                k += 3;
                WinL.Margin = new Thickness(k, 10, 0, 0);
                if (k == 900)
                {
                    k = -108;
                    WinL.Margin = new Thickness(-208, 10, 0, 0);
                    winner = false;
                }
            }
        }
        Rectangle[,] arr1 = new Rectangle[9, 9];

        int[,] arr = new int[9, 9];
        int[,] arrPress = new int[10, 2];
        int countPress = 2;
        int[,] arrdoor = new int[10, 4];
        bool[,] arrOpen = new bool[10, 2];
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            arr1[0, 0] = _00;
            arr1[0, 1] = _01;
            arr1[0, 2] = _02;
            arr1[0, 3] = _03;
            arr1[0, 4] = _04;
            arr1[0, 5] = _05;
            arr1[0, 6] = _06;
            arr1[0, 7] = _07;
            arr1[0, 8] = _08;
            arr1[1, 0] = _10;
            arr1[1, 1] = _11;
            arr1[1, 2] = _12;
            arr1[1, 3] = _13;
            arr1[1, 4] = _14;
            arr1[1, 5] = _15;
            arr1[1, 6] = _16;
            arr1[1, 7] = _17;
            arr1[1, 8] = _18;
            arr1[2, 0] = _20;
            arr1[2, 1] = _21;
            arr1[2, 2] = _22;
            arr1[2, 3] = _23;
            arr1[2, 4] = _24;
            arr1[2, 5] = _25;
            arr1[2, 6] = _26;
            arr1[2, 7] = _27;
            arr1[2, 8] = _28;
            arr1[3, 0] = _30;
            arr1[3, 1] = _31;
            arr1[3, 2] = _32;
            arr1[3, 3] = _33;
            arr1[3, 4] = _34;
            arr1[3, 5] = _35;
            arr1[3, 6] = _36;
            arr1[3, 7] = _37;
            arr1[3, 8] = _38;
            arr1[4, 0] = _40;
            arr1[4, 1] = _41;
            arr1[4, 2] = _42;
            arr1[4, 3] = _43;
            arr1[4, 4] = _44;
            arr1[4, 5] = _45;
            arr1[4, 6] = _46;
            arr1[4, 7] = _47;
            arr1[4, 8] = _48;
            arr1[5, 0] = _50;
            arr1[5, 1] = _51;
            arr1[5, 2] = _52;
            arr1[5, 3] = _53;
            arr1[5, 4] = _54;
            arr1[5, 5] = _55;
            arr1[5, 6] = _56;
            arr1[5, 7] = _57;
            arr1[5, 8] = _58;
            arr1[6, 0] = _60;
            arr1[6, 1] = _61;
            arr1[6, 2] = _62;
            arr1[6, 3] = _63;
            arr1[6, 4] = _64;
            arr1[6, 5] = _65;
            arr1[6, 6] = _66;
            arr1[6, 7] = _67;
            arr1[6, 8] = _68;
            arr1[7, 0] = _70;
            arr1[7, 1] = _71;
            arr1[7, 2] = _72;
            arr1[7, 3] = _73;
            arr1[7, 4] = _74;
            arr1[7, 5] = _75;
            arr1[7, 6] = _76;
            arr1[7, 7] = _77;
            arr1[7, 8] = _78;
            arr1[8, 0] = _80;
            arr1[8, 1] = _81;
            arr1[8, 2] = _82;
            arr1[8, 3] = _83;
            arr1[8, 4] = _84;
            arr1[8, 5] = _85;
            arr1[8, 6] = _86;
            arr1[8, 7] = _87;
            arr1[8, 8] = _88;

            arr[0, 0] = 1;
            arr[0, 1] = 9;
            arr[0, 2] = 1;
            arr[0, 3] = 1;
            arr[0, 4] = 1;
            arr[0, 5] = 1;
            arr[0, 6] = 1;
            arr[0, 7] = 1;
            arr[0, 8] = 1;
            arr[1, 0] = 1;
            arr[1, 1] = 0;
            arr[1, 2] = 1;
            arr[1, 3] = 1;
            arr[1, 4] = 1;
            arr[1, 5] = 0; // Заполнение поля лабиринта
            arr[1, 6] = 0;
            arr[1, 7] = 0;
            arr[1, 8] = 1;
            arr[2, 0] = 1;
            arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт, 8 - ящик, 10 - кнопка
            arr[2, 2] = 0;
            arr[2, 3] = 0;
            arr[2, 4] = 0;
            arr[2, 5] = 0;
            arr[2, 6] = 1;
            arr[2, 7] = 0;
            arr[2, 8] = 1;
            arr[3, 0] = 1;
            arr[3, 1] = 0;
            arr[3, 2] = 1;
            arr[3, 3] = 1;
            arr[3, 4] = 8;
            arr[3, 5] = 1;
            arr[3, 6] = 1;
            arr[3, 7] = 0;
            arr[3, 8] = 1;
            arr[4, 0] = 1;
            arr[4, 1] = 0;
            arr[4, 2] = 1;
            arr[4, 3] = 0;
            arr[4, 4] = 0;
            arr[4, 5] = 0;
            arr[4, 6] = 1;
            arr[4, 7] = 0;
            arr[4, 8] = 1;
            arr[5, 0] = 1;
            arr[5, 1] = 1;
            arr[5, 2] = 1;
            arr[5, 3] = 0;
            arr[5, 4] = 1;
            arr[5, 5] = 0;
            arr[5, 6] = 1;
            arr[5, 7] = 1;
            arr[5, 8] = 1;
            arr[6, 0] = 1;
            arr[6, 1] = 1;
            arr[6, 2] = 1;
            arr[6, 3] = 1;
            arr[6, 4] = 1;
            arr[6, 5] = 0;
            arr[6, 6] = 1;
            arr[6, 7] = 0;
            arr[6, 8] = 1;
            arr[7, 0] = 1;
            arr[7, 1] = 1;
            arr[7, 2] = 1;
            arr[7, 3] = 1;
            arr[7, 4] = 0;
            arr[7, 5] = 0;
            arr[7, 6] = 0;
            arr[7, 7] = 0;
            arr[7, 8] = 1;
            arr[8, 0] = 1;
            arr[8, 1] = 1;
            arr[8, 2] = 1;
            arr[8, 3] = 1;
            arr[8, 4] = 2;
            arr[8, 5] = 1;
            arr[8, 6] = 1;
            arr[8, 7] = 1;
            arr[8, 8] = 1;

            arrPress[0, 0] = 3;
            arrPress[0, 1] = 4;
            arrPress[1, 0] = 2;
            arrPress[1, 1] = 1;
            countPress = 2;
            arrdoor[0, 0] = 4;
            arrdoor[0, 1] = 6;
            arrdoor[0, 2] = -1;
            arrdoor[0, 3] = -1;
            arrdoor[1, 0] = 1;
            arrdoor[1, 1] = 2;
            arrdoor[1, 2] = -1;
            arrdoor[1, 3] = -1;
            arrOpen[0, 0] = true;
            arrOpen[0, 1] = false;
            arrOpen[1, 0] = false;
            arrOpen[1, 1] = false;
            start1 = 8;
            start2 = 4;
            prBar.Value = 0;
            Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur1.Background = Brushes.Brown;
            Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            SetLab();

            Ur2.IsEnabled = false;
            Ur3.IsEnabled = false;
            Ur4.IsEnabled = false;
        }
        bool prBarSet = false;
        int prBarVal = 0;
        public void SetLab()
        {
            Image ImageContainer = new Image();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    switch (arr[i, j])
                    {
                        case 0:
                            ImageSource image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/grassForLabirint.jpg", UriKind.Absolute));
                            ImageContainer.Source = image;
                            arr1[i, j].Fill = new ImageBrush
                            {
                                ImageSource = image
                            };
                            break;
                        case 1:
                            image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/wallForLabirint.jpg", UriKind.Absolute));
                            ImageContainer.Source = image;
                            arr1[i, j].Fill = new ImageBrush
                            {
                                ImageSource = image
                            };
                            break;
                        case 2:
                            image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/headForLabirint.jpg", UriKind.Absolute));
                            ImageContainer.Source = image;
                            arr1[i, j].Fill = new ImageBrush
                            {
                                ImageSource = image
                            };
                            break;
                        case 9:
                            image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/finishForLabirint.jpg", UriKind.Absolute));
                            ImageContainer.Source = image;
                            arr1[i, j].Fill = new ImageBrush
                            {
                                ImageSource = image
                            };
                            break;
                        case -1:
                            image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/startForLabirint.jpg", UriKind.Absolute));
                            ImageContainer.Source = image;
                            arr1[i, j].Fill = new ImageBrush
                            {
                                ImageSource = image
                            };
                            break;
                        case 8:
                            image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/box.jpg", UriKind.Absolute));
                            ImageContainer.Source = image;
                            arr1[i, j].Fill = new ImageBrush
                            {
                                ImageSource = image
                            };
                            break;
                        case 10:
                            image = new BitmapImage(new Uri(Environment.CurrentDirectory + "/press.png", UriKind.Absolute));
                            ImageContainer.Source = image;
                            arr1[i, j].Fill = new ImageBrush
                            {
                                ImageSource = image
                            };
                            break;
                    }
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x1 = 0, x2 = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    if (arr[i, j] == 2)
                    {
                        x1 = i;
                        x2 = j;
                    }
            }
            if (x2 != 0)
            {
                if (arr[x1, x2 - 1] == 0 || arr[x1, x2 - 1] == 10 || arr[x1, x2 - 1] == 10)
                {
                    arr[x1, x2 - 1] = 2;
                    for (int i = 0; i < countPress; i++)
                    {
                        if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                        {
                            arr[x1, x2] = 10;
                        }
                    }
                    if (arr[x1, x2] != 10)
                    {
                        arr[x1, x2] = 0;
                    }


                    SetLab();
                }
                else if (arr[x1, x2 - 1] == 1)
                {
                    error = true;
                    countErr = 0;
                }
                else if (arr[x1, x2 - 1] == 8)
                {
                    if (arr[x1, x2 - 2] == 0 || arr[x1, x2 - 2] == 10)
                    {
                        arr[x1, x2 - 2] = 8;
                        arr[x1, x2 - 1] = 2;
                        for (int i = 0; i < countPress; i++)
                        {
                            if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                            {
                                arr[x1, x2] = 10;
                            }
                        }
                        if (arr[x1, x2] != 10)
                            arr[x1, x2] = 0;
                        SetLab();
                    }
                    else
                    {
                        error = true;
                        countErr = 0;
                    }
                }
            }
            else
            {
                error = true;
                countErr = 0;
            }
            int c = 0;
            for (int i = 0; i < countPress; i++)
            {
                c = 0;
                if (arr[arrPress[i, 0], arrPress[i, 1]] == 10)
                {
                    for (int j = 0; j < 3; j += 2)
                    {
                        if (arrdoor[i, j] != -1)
                        {
                            if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2 && arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                            {


                                if (arrOpen[i, c])
                                {
                                    arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                }
                                else
                                {
                                    arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                }
                            }
                        }
                        c++;
                    }
                }
                else
                {
                    for (int j = 0; j < 3; j += 2)
                    {
                        if (arrdoor[i, j] != -1)
                        {
                            if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2)
                            {
                                if (arrOpen[i, c])
                                {
                                    arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                }
                                else
                                {
                                    if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                }
                            }
                        }
                        c++;
                    }
                }
            }
            SetLab();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int x1 = 0, x2 = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    if (arr[i, j] == 2)
                    {
                        x1 = i;
                        x2 = j;
                    }
            }
            if (x2 != 8)
            {
                if (arr[x1, x2 + 1] == 0 || arr[x1, x2 + 1] == 10)
                {
                    arr[x1, x2 + 1] = 2;
                    for (int i = 0; i < countPress; i++)
                    {
                        if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                        {
                            arr[x1, x2] = 10;
                        }
                    }
                    if (arr[x1, x2] != 10)
                    {
                        arr[x1, x2] = 0;
                    }
                    SetLab();
                }
                else if (arr[x1, x2 + 1] == 1)
                {
                    error = true;
                    countErr = 0;
                }
                else if (arr[x1, x2 + 1] == 8)
                {
                    if (arr[x1, x2 + 2] == 0 || arr[x1, x2 + 2] == 10)
                    {
                        arr[x1, x2 + 2] = 8;
                        arr[x1, x2 + 1] = 2;
                        for (int i = 0; i < countPress; i++)
                        {
                            if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                            {
                                arr[x1, x2] = 10;
                            }
                        }
                        if (arr[x1, x2] != 10)
                            arr[x1, x2] = 0;
                        SetLab();
                    }
                    else
                    {
                        error = true;
                        countErr = 0;
                    }
                }
            }
            else
            {
                error = true;
                countErr = 0;
            }
            int c = 0;
            for (int i = 0; i < countPress; i++)
            {
                c = 0;
                if (arr[arrPress[i, 0], arrPress[i, 1]] == 10)
                {
                    for (int j = 0; j < 3; j += 2)
                    {
                        if (arrdoor[i, j] != -1)
                        {
                            if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2 && arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                            {


                                if (arrOpen[i, c])
                                {
                                    arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                }
                                else
                                {
                                    arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                }
                            }
                        }
                        c++;
                    }
                }
                else
                {
                    for (int j = 0; j < 3; j += 2)
                    {
                        if (arrdoor[i, j] != -1)
                        {
                            if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2)
                            {
                                if (arrOpen[i, c])
                                {
                                    arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                }
                                else
                                {
                                    if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                }
                            }
                        }
                        c++;
                    }
                }
            }
            SetLab();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int x1 = 0, x2 = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    if (arr[i, j] == 2)
                    {
                        x1 = i;
                        x2 = j;
                    }
            }
            if (x1 != 8)
            {
                if (arr[x1 + 1, x2] == 0 || arr[x1 + 1, x2] == -1 || arr[x1 + 1, x2] == 10)
                {
                    arr[x1 + 1, x2] = 2;
                    for (int i = 0; i < countPress; i++)
                    {
                        if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                        {
                            arr[x1, x2] = 10;
                        }
                    }
                    if (arr[x1, x2] != 10)
                    {
                        arr[x1, x2] = 0;
                    }
                    SetLab();
                }
                else if (arr[x1 + 1, x2] == 1)
                {
                    error = true;
                    countErr = 0;
                }
                else if (arr[x1 + 1, x2] == 8)
                {
                    if (arr[x1 + 2, x2] == 0 || arr[x1 + 2, x2] == 10)
                    {
                        arr[x1 + 2, x2] = 8;
                        arr[x1 + 1, x2] = 2;
                        for (int i = 0; i < countPress; i++)
                        {
                            if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                            {
                                arr[x1, x2] = 10;
                            }
                        }
                        if (arr[x1, x2] != 10)
                            arr[x1, x2] = 0;
                        SetLab();
                    }
                    else
                    {
                        error = true;
                        countErr = 0;
                    }
                }
            }
            else
            {
                error = true;
                countErr = 0;
            }
            int c = 0;
            for (int i = 0; i < countPress; i++)
            {
                c = 0;
                if (arr[arrPress[i, 0], arrPress[i, 1]] == 10)
                {
                    for (int j = 0; j < 3; j += 2)
                    {
                        if (arrdoor[i, j] != -1)
                        {
                            if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2 && arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                            {


                                if (arrOpen[i, c])
                                {
                                    arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                }
                                else
                                {
                                    arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                }
                            }
                        }
                        c++;
                    }
                }
                else
                {
                    for (int j = 0; j < 3; j += 2)
                    {
                        if (arrdoor[i, j] != -1)
                        {
                            if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2)
                            {
                                if (arrOpen[i, c])
                                {
                                    arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                }
                                else
                                {
                                    if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                }
                            }
                        }
                        c++;
                    }
                }
            }
            SetLab();
        }
        bool finish = false;
        int start1 = 0;
        int start2 = 0;
        bool winner = false;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int x1 = 0, x2 = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                    if (arr[i, j] == 2)
                    {
                        x1 = i;
                        x2 = j;
                    }
            }
            if (x1 != 0)
            {
                if (arr[x1 - 1, x2] == 0 || arr[x1 - 1, x2] == 9 || arr[x1 - 1, x2] == 10)
                {
                    if (arr[x1 - 1, x2] == 9)
                        finish = true;
                    arr[x1 - 1, x2] = 2;
                    if (x1 == start1 && x2 == start2)
                        arr[x1, x2] = -1;
                    else
                    {
                        for (int i = 0; i < countPress; i++)
                        {
                            if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                            {
                                arr[x1, x2] = 10;
                            }
                        }
                        if (arr[x1, x2] != 10)
                        {
                            arr[x1, x2] = 0;
                        }
                    }
                    SetLab();
                    if (finish == true)
                    {
                        block = true;
                        finish = false;
                        if (urNum == 4)
                        {
                            RefreshB.Content = "К первому уровню";

                            prBar.BorderBrush = Brushes.Green;
                            prBarVal = 100;
                            prBarSet = true;
                            winner = true;
                        }
                        else
                            RefreshB.Content = "Следующий уровень";
                        Finish();
                    }
                }
                else if (arr[x1 - 1, x2] == 1)
                {
                    error = true;
                    countErr = 0;
                }
                else if (arr[x1 - 1, x2] == 8)
                {
                    if (arr[x1 - 2, x2] == 0 || arr[x1 - 2, x2] == 10)
                    {
                        arr[x1 - 2, x2] = 8;
                        arr[x1 - 1, x2] = 2;
                        for (int i = 0; i < countPress; i++)
                        {
                            if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                            {
                                arr[x1, x2] = 10;
                            }
                        }
                        if (arr[x1, x2] != 10)
                            arr[x1, x2] = 0;
                        SetLab();
                    }
                    else
                    {
                        error = true;
                        countErr = 0;
                    }
                }
                int c = 0;
                for (int i = 0; i < countPress; i++)
                {
                    c = 0;
                    if (arr[arrPress[i, 0], arrPress[i, 1]] == 10)
                    {
                        for (int j = 0; j < 3; j += 2)
                        {
                            if (arrdoor[i, j] != -1)
                            {
                                if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2 && arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                {


                                    if (arrOpen[i, c])
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                    }
                                    else
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                    }
                                }
                            }
                            c++;
                        }
                    }
                    else
                    {

                        for (int j = 0; j < 3; j += 2)
                        {
                            if (arrdoor[i, j] != -1)
                            {
                                if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2)
                                {
                                    if (arrOpen[i, c])
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                    }
                                    else
                                    {
                                        if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                            arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                    }
                                }
                            }
                            c++;
                        }
                    }
                }
                SetLab();
            }
            else
            {
                error = true;
                countErr = 0;
            }
        }
        bool win = false;
        bool block = false;
        public void Finish()
        {
            Up.IsEnabled = false;
            Down.IsEnabled = false;
            Left.IsEnabled = false;
            Right.IsEnabled = false;
            RefreshB.Visibility = Visibility.Visible;
            win = true;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            RefreshB.Visibility = Visibility.Hidden;
            win = false;
            Up.IsEnabled = true;
            Down.IsEnabled = true;
            Left.IsEnabled = true;
            Right.IsEnabled = true;
            Ur1.IsEnabled = true;
            Ur2.IsEnabled = true;
            Ur3.IsEnabled = true;
            Ur4.IsEnabled = true;
            block = false;

            if (urNum == 1)
            {
                arr[0, 0] = 1;
                arr[0, 1] = 1;
                arr[0, 2] = 1;
                arr[0, 3] = 1;
                arr[0, 4] = 1;
                arr[0, 5] = 1;
                arr[0, 6] = 1;
                arr[0, 7] = 9;
                arr[0, 8] = 1;
                arr[1, 0] = 1;
                arr[1, 1] = 10;
                arr[1, 2] = 0;
                arr[1, 3] = 0;
                arr[1, 4] = 10;
                arr[1, 5] = 1; // Заполнение поля лабиринта
                arr[1, 6] = 1;
                arr[1, 7] = 0;
                arr[1, 8] = 1;
                arr[2, 0] = 1;
                arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                arr[2, 2] = 1;
                arr[2, 3] = 1;
                arr[2, 4] = 8;
                arr[2, 5] = 0;
                arr[2, 6] = 1;
                arr[2, 7] = 0;
                arr[2, 8] = 1;
                arr[3, 0] = 1;
                arr[3, 1] = 0;
                arr[3, 2] = 1;
                arr[3, 3] = 0;
                arr[3, 4] = 0;
                arr[3, 5] = 1;
                arr[3, 6] = 1;
                arr[3, 7] = 0;
                arr[3, 8] = 1;
                arr[4, 0] = 1;
                arr[4, 1] = 1;
                arr[4, 2] = 1;
                arr[4, 3] = 0;
                arr[4, 4] = 1;
                arr[4, 5] = 1;
                arr[4, 6] = 1;
                arr[4, 7] = 1;
                arr[4, 8] = 1;
                arr[5, 0] = 1;
                arr[5, 1] = 1;
                arr[5, 2] = 0;
                arr[5, 3] = 0;
                arr[5, 4] = 10;
                arr[5, 5] = 0;
                arr[5, 6] = 1;
                arr[5, 7] = 0;
                arr[5, 8] = 1;
                arr[6, 0] = 1;
                arr[6, 1] = 0;
                arr[6, 2] = 0;
                arr[6, 3] = 1;
                arr[6, 4] = 8;
                arr[6, 5] = 1;
                arr[6, 6] = 1;
                arr[6, 7] = 0;
                arr[6, 8] = 1;
                arr[7, 0] = 1;
                arr[7, 1] = 1;
                arr[7, 2] = 0;
                arr[7, 3] = 1;
                arr[7, 4] = 0;
                arr[7, 5] = 0;
                arr[7, 6] = 0;
                arr[7, 7] = 0;
                arr[7, 8] = 1;
                arr[8, 0] = 1;
                arr[8, 1] = 1;
                arr[8, 2] = 1;
                arr[8, 3] = 1;
                arr[8, 4] = 1;
                arr[8, 5] = 2;
                arr[8, 6] = 1;
                arr[8, 7] = 1;
                arr[8, 8] = 1;

                start1 = 8;
                start2 = 5;
                arrPress[0, 0] = 5;
                arrPress[0, 1] = 4;
                arrPress[1, 0] = 1;
                arrPress[1, 1] = 4;
                arrPress[2, 0] = 1;
                arrPress[2, 1] = 1;
                countPress = 3;
                arrdoor[0, 0] = 7;
                arrdoor[0, 1] = 3;
                arrdoor[0, 2] = -1;
                arrdoor[0, 3] = -1;
                arrOpen[0, 0] = false;
                arrOpen[0, 1] = false;
                arrdoor[1, 0] = 1;
                arrdoor[1, 1] = 5;
                arrdoor[1, 2] = -1;
                arrdoor[1, 3] = -1;
                arrOpen[1, 0] = false;
                arrOpen[1, 1] = false;
                arrdoor[2, 0] = 4;
                arrdoor[2, 1] = 7;
                arrdoor[2, 2] = -1;
                arrdoor[2, 3] = -1;
                arrOpen[2, 0] = false;
                arrOpen[2, 1] = false;
                win = false;
                urNum = 2;
                prBar.BorderBrush = Brushes.Green;
                prBarVal = 25;
                prBarSet = true;
                Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                Ur2.Background = Brushes.Brown;
                Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");

                Ur1.IsEnabled = true;
                Ur2.IsEnabled = true;
                Ur3.IsEnabled = false;
                Ur4.IsEnabled = false;

                ur1 = true;
                ur2 = true;
                ur3 = false;
                ur4 = false;
            }
            else if (urNum == 2)
            {
                arr[0, 0] = 1;
                arr[0, 1] = 9;
                arr[0, 2] = 1;
                arr[0, 3] = 1;
                arr[0, 4] = 1;
                arr[0, 5] = 1;
                arr[0, 6] = 1;
                arr[0, 7] = 1;
                arr[0, 8] = 1;
                arr[1, 0] = 1;
                arr[1, 1] = 0;
                arr[1, 2] = 1;
                arr[1, 3] = 0;
                arr[1, 4] = 0;
                arr[1, 5] = 0; // Заполнение поля лабиринта
                arr[1, 6] = 1;
                arr[1, 7] = 1;
                arr[1, 8] = 1;
                arr[2, 0] = 1;
                arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                arr[2, 2] = 1;
                arr[2, 3] = 1;
                arr[2, 4] = 1;
                arr[2, 5] = 0;
                arr[2, 6] = 0;
                arr[2, 7] = 0;
                arr[2, 8] = 1;
                arr[3, 0] = 1;
                arr[3, 1] = 0;
                arr[3, 2] = 1;
                arr[3, 3] = 0;
                arr[3, 4] = 1;
                arr[3, 5] = 0;
                arr[3, 6] = 8;
                arr[3, 7] = 0;
                arr[3, 8] = 1;
                arr[4, 0] = 1;
                arr[4, 1] = 1;
                arr[4, 2] = 1;
                arr[4, 3] = 0;
                arr[4, 4] = 1;
                arr[4, 5] = 1;
                arr[4, 6] = 10;
                arr[4, 7] = 1;
                arr[4, 8] = 1;
                arr[5, 0] = 1;
                arr[5, 1] = 10;
                arr[5, 2] = 8;
                arr[5, 3] = 0;
                arr[5, 4] = 1;
                arr[5, 5] = 1;
                arr[5, 6] = 1;
                arr[5, 7] = 1;
                arr[5, 8] = 1;
                arr[6, 0] = 1;
                arr[6, 1] = 0;
                arr[6, 2] = 1;
                arr[6, 3] = 0;
                arr[6, 4] = 0;
                arr[6, 5] = 0;
                arr[6, 6] = 1;
                arr[6, 7] = 0;
                arr[6, 8] = 1;
                arr[7, 0] = 1;
                arr[7, 1] = 10;
                arr[7, 2] = 1;
                arr[7, 3] = 0;
                arr[7, 4] = 0;
                arr[7, 5] = 0;
                arr[7, 6] = 8;
                arr[7, 7] = 0;
                arr[7, 8] = 1;
                arr[8, 0] = 1;
                arr[8, 1] = 1;
                arr[8, 2] = 1;
                arr[8, 3] = 1;
                arr[8, 4] = 1;
                arr[8, 5] = 1;
                arr[8, 6] = 1;
                arr[8, 7] = 2;
                arr[8, 8] = 1;
                arrPress[0, 0] = 5;
                arrPress[0, 1] = 1;
                arrdoor[0, 0] = 7;
                arrdoor[0, 1] = 2;
                arrdoor[0, 2] = -1;
                arrdoor[0, 3] = -1;
                arrOpen[0, 1] = false;
                arrPress[1, 0] = 7;
                arrPress[1, 1] = 1;
                arrdoor[1, 0] = 2;
                arrdoor[1, 1] = 3;
                arrdoor[1, 2] = -1;
                arrdoor[1, 3] = -1;
                arrOpen[1, 0] = false;
                arrPress[2, 0] = 4;
                arrPress[2, 1] = 6;
                arrdoor[2, 0] = 3;
                arrdoor[2, 1] = 2;
                arrdoor[2, 2] = -1;
                arrdoor[2, 3] = -1;
                arrOpen[2, 0] = false;
                countPress = 3;


                start1 = 8;
                start2 = 7;
                urNum = 3;
                prBar.BorderBrush = Brushes.Green;
                prBarVal = 50;
                prBarSet = true;
                win = false;
                Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                Ur3.Background = Brushes.Brown;
                Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");

                Ur1.IsEnabled = true;
                Ur2.IsEnabled = true;
                Ur3.IsEnabled = true;
                Ur4.IsEnabled = false;

                ur1 = true;
                ur2 = true;
                ur3 = true;
                ur4 = false;
            }
            else if (urNum == 3)
            {
                arr[0, 0] = 1;
                arr[0, 1] = 1;
                arr[0, 2] = 1;
                arr[0, 3] = 1;
                arr[0, 4] = 9;
                arr[0, 5] = 1;
                arr[0, 6] = 1;
                arr[0, 7] = 1;
                arr[0, 8] = 1;
                arr[1, 0] = 1;
                arr[1, 1] = 1;
                arr[1, 2] = 1;
                arr[1, 3] = 0;
                arr[1, 4] = 1;
                arr[1, 5] = 1; // Заполнение поля лабиринта
                arr[1, 6] = 0;
                arr[1, 7] = 1;
                arr[1, 8] = 1;
                arr[2, 0] = 1;
                arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                arr[2, 2] = 1;
                arr[2, 3] = 1;
                arr[2, 4] = 1;
                arr[2, 5] = 1;
                arr[2, 6] = 0;
                arr[2, 7] = 1;
                arr[2, 8] = 1;
                arr[3, 0] = 1;
                arr[3, 1] = 0;
                arr[3, 2] = 0;
                arr[3, 3] = 0;
                arr[3, 4] = 0;
                arr[3, 5] = 0;
                arr[3, 6] = 8;
                arr[3, 7] = 10;
                arr[3, 8] = 1;
                arr[4, 0] = 1;
                arr[4, 1] = 8;
                arr[4, 2] = 1;
                arr[4, 3] = 1;
                arr[4, 4] = 1;
                arr[4, 5] = 1;
                arr[4, 6] = 0;
                arr[4, 7] = 1;
                arr[4, 8] = 1;
                arr[5, 0] = 1;
                arr[5, 1] = 0;
                arr[5, 2] = 0;
                arr[5, 3] = 0;
                arr[5, 4] = 1;
                arr[5, 5] = 1;
                arr[5, 6] = 1;
                arr[5, 7] = 1;
                arr[5, 8] = 1;
                arr[6, 0] = 1;
                arr[6, 1] = 0;
                arr[6, 2] = 1;
                arr[6, 3] = 0;
                arr[6, 4] = 0;
                arr[6, 5] = 0;
                arr[6, 6] = 1;
                arr[6, 7] = 0;
                arr[6, 8] = 1;
                arr[7, 0] = 1;
                arr[7, 1] = 10;
                arr[7, 2] = 1;
                arr[7, 3] = 0;
                arr[7, 4] = 1;
                arr[7, 5] = 0;
                arr[7, 6] = 0;
                arr[7, 7] = 0;
                arr[7, 8] = 1;
                arr[8, 0] = 1;
                arr[8, 1] = 1;
                arr[8, 2] = 1;
                arr[8, 3] = 1;
                arr[8, 4] = 1;
                arr[8, 5] = 1;
                arr[8, 6] = 2;
                arr[8, 7] = 1;
                arr[8, 8] = 1;
                arrPress[0, 0] = 2;
                arrPress[0, 1] = 1;
                arrdoor[0, 0] = 1;
                arrdoor[0, 1] = 1;
                arrdoor[0, 2] = -1;
                arrdoor[0, 3] = -1;
                arrOpen[0, 0] = false;
                arrPress[1, 0] = 3;
                arrPress[1, 1] = 7;
                arrdoor[1, 0] = 1;
                arrdoor[1, 1] = 2;
                arrdoor[1, 2] = 2;
                arrdoor[1, 3] = 3;
                arrOpen[1, 0] = false;
                arrOpen[1, 1] = false;
                arrPress[2, 0] = 7;
                arrPress[2, 1] = 1;
                arrdoor[2, 0] = 1;
                arrdoor[2, 1] = 4;
                arrdoor[2, 2] = -1;
                arrdoor[2, 3] = -1;
                arrOpen[2, 0] = false;
                arrOpen[2, 1] = false;
                start1 = 8;
                start2 = 6;
                urNum = 4;
                prBar.BorderBrush = Brushes.Green;
                prBarVal = 75;
                prBarSet = true;
                Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                Ur4.Background = Brushes.Brown;
                Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");

                Ur1.IsEnabled = true;
                Ur2.IsEnabled = true;
                Ur3.IsEnabled = true;
                Ur4.IsEnabled = true;

                ur1 = true;
                ur2 = true;
                ur3 = true;
                ur4 = true;
            }
            else if (urNum == 4)
            {
                arr[0, 0] = 1;
                arr[0, 1] = 9;
                arr[0, 2] = 1;
                arr[0, 3] = 1;
                arr[0, 4] = 1;
                arr[0, 5] = 1;
                arr[0, 6] = 1;
                arr[0, 7] = 1;
                arr[0, 8] = 1;
                arr[1, 0] = 1;
                arr[1, 1] = 0;
                arr[1, 2] = 1;
                arr[1, 3] = 1;
                arr[1, 4] = 1;
                arr[1, 5] = 0; // Заполнение поля лабиринта
                arr[1, 6] = 0;
                arr[1, 7] = 0;
                arr[1, 8] = 1;
                arr[2, 0] = 1;
                arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт, 8 - ящик, 10 - кнопка, 3 - рубин
                arr[2, 2] = 0;
                arr[2, 3] = 0;
                arr[2, 4] = 0;
                arr[2, 5] = 0;
                arr[2, 6] = 1;
                arr[2, 7] = 0;
                arr[2, 8] = 1;
                arr[3, 0] = 1;
                arr[3, 1] = 0;
                arr[3, 2] = 1;
                arr[3, 3] = 1;
                arr[3, 4] = 8;
                arr[3, 5] = 1;
                arr[3, 6] = 1;
                arr[3, 7] = 0;
                arr[3, 8] = 1;
                arr[4, 0] = 1;
                arr[4, 1] = 0;
                arr[4, 2] = 1;
                arr[4, 3] = 0;
                arr[4, 4] = 0;
                arr[4, 5] = 0;
                arr[4, 6] = 1;
                arr[4, 7] = 0;
                arr[4, 8] = 1;
                arr[5, 0] = 1;
                arr[5, 1] = 1;
                arr[5, 2] = 1;
                arr[5, 3] = 0;
                arr[5, 4] = 1;
                arr[5, 5] = 0;
                arr[5, 6] = 1;
                arr[5, 7] = 1;
                arr[5, 8] = 1;
                arr[6, 0] = 1;
                arr[6, 1] = 1;
                arr[6, 2] = 1;
                arr[6, 3] = 1;
                arr[6, 4] = 1;
                arr[6, 5] = 0;
                arr[6, 6] = 1;
                arr[6, 7] = 0;
                arr[6, 8] = 1;
                arr[7, 0] = 1;
                arr[7, 1] = 1;
                arr[7, 2] = 1;
                arr[7, 3] = 1;
                arr[7, 4] = 0;
                arr[7, 5] = 0;
                arr[7, 6] = 0;
                arr[7, 7] = 0;
                arr[7, 8] = 1;
                arr[8, 0] = 1;
                arr[8, 1] = 1;
                arr[8, 2] = 1;
                arr[8, 3] = 1;
                arr[8, 4] = 2;
                arr[8, 5] = 1;
                arr[8, 6] = 1;
                arr[8, 7] = 1;
                arr[8, 8] = 1;

                arrPress[0, 0] = 3;
                arrPress[0, 1] = 4;
                arrPress[1, 0] = 2;
                arrPress[1, 1] = 1;
                countPress = 2;
                arrdoor[0, 0] = 4;
                arrdoor[0, 1] = 6;
                arrdoor[0, 2] = -1;
                arrdoor[0, 3] = -1;
                arrdoor[1, 0] = 1;
                arrdoor[1, 1] = 2;
                arrdoor[1, 2] = -1;
                arrdoor[1, 3] = -1;
                arrOpen[0, 0] = true;
                arrOpen[0, 1] = false;
                arrOpen[1, 0] = false;
                arrOpen[1, 1] = false;
                start1 = 8;
                start2 = 4;
                win = false;
                urNum = 1;
                prBar.BorderBrush = Brushes.Green;
                prBarVal = 0;
                prBarSet = true;
                Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                Ur1.Background = Brushes.Brown;
                Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");

                Ur1.IsEnabled = true;
                Ur2.IsEnabled = false;
                Ur3.IsEnabled = false;
                Ur4.IsEnabled = false;

                ur1 = true;
                ur2 = false;
                ur3 = false;
                ur4 = false;
            }
            SetLab();
        }
        bool ur1 = true;
        bool ur2 = false;
        bool ur3 = false;
        bool ur4 = false;
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((e.Key == Key.Up || e.Key == Key.W) && block == false)
            {
                int x1 = 0, x2 = 0;

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                        if (arr[i, j] == 2)
                        {
                            x1 = i;
                            x2 = j;
                        }
                }
                if (x1 != 0)
                {
                    if (arr[x1 - 1, x2] == 0 || arr[x1 - 1, x2] == 9 || arr[x1 - 1, x2] == 10)
                    {
                        if (arr[x1 - 1, x2] == 9)
                            finish = true;
                        arr[x1 - 1, x2] = 2;
                        if (x1 == start1 && x2 == start2)
                            arr[x1, x2] = -1;
                        else
                        {
                            for (int i = 0; i < countPress; i++)
                            {
                                if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                                {
                                    arr[x1, x2] = 10;
                                }
                            }
                            if (arr[x1, x2] != 10)
                            {
                                arr[x1, x2] = 0;
                            }
                        }
                        SetLab();
                        if (finish == true)
                        {
                            block = true;
                            finish = false;
                            if (urNum == 4)
                            {
                                RefreshB.Content = "К первому уровню";

                                prBar.BorderBrush = Brushes.Green;
                                prBarVal = 100;
                                prBarSet = true;
                                winner = true;
                            }
                            else
                                RefreshB.Content = "Следующий уровень";
                            Finish();
                        }
                    }
                    else if (arr[x1 - 1, x2] == 1)
                    {
                        error = true;
                        countErr = 0;
                    }
                    else if (arr[x1 - 1, x2] == 8)
                    {
                        if (arr[x1 - 2, x2] == 0 || arr[x1 - 2, x2] == 10)
                        {
                            arr[x1 - 2, x2] = 8;
                            arr[x1 - 1, x2] = 2;
                            for (int i = 0; i < countPress; i++)
                            {
                                if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                                {
                                    arr[x1, x2] = 10;
                                }
                            }
                            if (arr[x1, x2] != 10)
                                arr[x1, x2] = 0;
                            SetLab();
                        }
                        else
                        {
                            error = true;
                            countErr = 0;
                        }
                    }
                    int c = 0;
                    for (int i = 0; i < countPress; i++)
                    {
                        c = 0;
                        if (arr[arrPress[i, 0], arrPress[i, 1]] == 10)
                        {
                            for (int j = 0; j < 3; j += 2)
                            {
                                if (arrdoor[i, j] != -1)
                                {
                                    if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2 && arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                    {


                                        if (arrOpen[i, c])
                                        {
                                            arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                        }
                                        else
                                        {
                                            arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                        }
                                    }
                                }
                                c++;
                            }
                        }
                        else
                        {

                            for (int j = 0; j < 3; j += 2)
                            {
                                if (arrdoor[i, j] != -1)
                                {
                                    if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2)
                                    {
                                        if (arrOpen[i, c])
                                        {
                                            arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                        }
                                        else
                                        {
                                            if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                                arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                        }
                                    }
                                }
                                c++;
                            }
                        }
                    }
                    SetLab();
                }
                else
                {
                    error = true;
                    countErr = 0;
                }
            }
            else if ((e.Key == Key.Left || e.Key == Key.A) && block == false)
            {
                int x1 = 0, x2 = 0;

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                        if (arr[i, j] == 2)
                        {
                            x1 = i;
                            x2 = j;
                        }
                }
                if (x2 != 0)
                {
                    if (arr[x1, x2 - 1] == 0 || arr[x1, x2 - 1] == 10 || arr[x1, x2 - 1] == 10)
                    {
                        arr[x1, x2 - 1] = 2;
                        for (int i = 0; i < countPress; i++)
                        {
                            if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                            {
                                arr[x1, x2] = 10;
                            }
                        }
                        if (arr[x1, x2] != 10)
                        {
                            arr[x1, x2] = 0;
                        }


                        SetLab();
                    }
                    else if (arr[x1, x2 - 1] == 1)
                    {
                        error = true;
                        countErr = 0;
                    }
                    else if (arr[x1, x2 - 1] == 8)
                    {
                        if (arr[x1, x2 - 2] == 0 || arr[x1, x2 - 2] == 10)
                        {
                            arr[x1, x2 - 2] = 8;
                            arr[x1, x2 - 1] = 2;
                            for (int i = 0; i < countPress; i++)
                            {
                                if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                                {
                                    arr[x1, x2] = 10;
                                }
                            }
                            if (arr[x1, x2] != 10)
                                arr[x1, x2] = 0;
                            SetLab();
                        }
                        else
                        {
                            error = true;
                            countErr = 0;
                        }
                    }
                }
                else
                {
                    error = true;
                    countErr = 0;
                }
                int c = 0;
                for (int i = 0; i < countPress; i++)
                {
                    c = 0;
                    if (arr[arrPress[i, 0], arrPress[i, 1]] == 10)
                    {
                        for (int j = 0; j < 3; j += 2)
                        {
                            if (arrdoor[i, j] != -1)
                            {
                                if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2 && arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                {


                                    if (arrOpen[i, c])
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                    }
                                    else
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                    }
                                }
                            }
                            c++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 3; j += 2)
                        {
                            if (arrdoor[i, j] != -1)
                            {
                                if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2)
                                {
                                    if (arrOpen[i, c])
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                    }
                                    else
                                    {
                                        if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                            arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                    }
                                }
                            }
                            c++;
                        }
                    }
                }
                SetLab();
            }
            else if ((e.Key == Key.Down || e.Key == Key.S) && block == false)
            {
                int x1 = 0, x2 = 0;

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                        if (arr[i, j] == 2)
                        {
                            x1 = i;
                            x2 = j;
                        }
                }
                if (x1 != 8)
                {
                    if (arr[x1 + 1, x2] == 0 || arr[x1 + 1, x2] == -1 || arr[x1 + 1, x2] == 10)
                    {
                        arr[x1 + 1, x2] = 2;
                        for (int i = 0; i < countPress; i++)
                        {
                            if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                            {
                                arr[x1, x2] = 10;
                            }
                        }
                        if (arr[x1, x2] != 10)
                        {
                            arr[x1, x2] = 0;
                        }
                        SetLab();
                    }
                    else if (arr[x1 + 1, x2] == 1)
                    {
                        error = true;
                        countErr = 0;
                    }
                    else if (arr[x1 + 1, x2] == 8)
                    {
                        if (arr[x1 + 2, x2] == 0 || arr[x1 + 2, x2] == 10)
                        {
                            arr[x1 + 2, x2] = 8;
                            arr[x1 + 1, x2] = 2;
                            for (int i = 0; i < countPress; i++)
                            {
                                if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                                {
                                    arr[x1, x2] = 10;
                                }
                            }
                            if (arr[x1, x2] != 10)
                                arr[x1, x2] = 0;
                            SetLab();
                        }
                        else
                        {
                            error = true;
                            countErr = 0;
                        }
                    }
                }
                else
                {
                    error = true;
                    countErr = 0;
                }
                int c = 0;
                for (int i = 0; i < countPress; i++)
                {
                    c = 0;
                    if (arr[arrPress[i, 0], arrPress[i, 1]] == 10)
                    {
                        for (int j = 0; j < 3; j += 2)
                        {
                            if (arrdoor[i, j] != -1)
                            {
                                if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2 && arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                {


                                    if (arrOpen[i, c])
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                    }
                                    else
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                    }
                                }
                            }
                            c++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 3; j += 2)
                        {
                            if (arrdoor[i, j] != -1)
                            {
                                if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2)
                                {
                                    if (arrOpen[i, c])
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                    }
                                    else
                                    {
                                        if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                            arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                    }
                                }
                            }
                            c++;
                        }
                    }
                }
                SetLab();
            }
            else if ((e.Key == Key.Right || e.Key == Key.D) && block == false)
            {
                int x1 = 0, x2 = 0;

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                        if (arr[i, j] == 2)
                        {
                            x1 = i;
                            x2 = j;
                        }
                }
                if (x2 != 8)
                {
                    if (arr[x1, x2 + 1] == 0 || arr[x1, x2 + 1] == 10)
                    {
                        arr[x1, x2 + 1] = 2;
                        for (int i = 0; i < countPress; i++)
                        {
                            if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                            {
                                arr[x1, x2] = 10;
                            }
                        }
                        if (arr[x1, x2] != 10)
                        {
                            arr[x1, x2] = 0;
                        }
                        SetLab();
                    }
                    else if (arr[x1, x2 + 1] == 1)
                    {
                        error = true;
                        countErr = 0;
                    }
                    else if (arr[x1, x2 + 1] == 8)
                    {
                        if (arr[x1, x2 + 2] == 0 || arr[x1, x2 + 2] == 10)
                        {
                            arr[x1, x2 + 2] = 8;
                            arr[x1, x2 + 1] = 2;
                            for (int i = 0; i < countPress; i++)
                            {
                                if (x1 == arrPress[i, 0] && x2 == arrPress[i, 1])
                                {
                                    arr[x1, x2] = 10;
                                }
                            }
                            if (arr[x1, x2] != 10)
                                arr[x1, x2] = 0;
                            SetLab();
                        }
                        else
                        {
                            error = true;
                            countErr = 0;
                        }
                    }
                }
                else
                {
                    error = true;
                    countErr = 0;
                }
                int c = 0;
                for (int i = 0; i < countPress; i++)
                {
                    c = 0;
                    if (arr[arrPress[i, 0], arrPress[i, 1]] == 10)
                    {
                        for (int j = 0; j < 3; j += 2)
                        {
                            if (arrdoor[i, j] != -1)
                            {
                                if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2 && arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                {


                                    if (arrOpen[i, c])
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                    }
                                    else
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                    }
                                }
                            }
                            c++;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 3; j += 2)
                        {
                            if (arrdoor[i, j] != -1)
                            {
                                if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 2)
                                {
                                    if (arrOpen[i, c])
                                    {
                                        arr[arrdoor[i, j], arrdoor[i, j + 1]] = 1;
                                    }
                                    else
                                    {
                                        if (arr[arrdoor[i, j], arrdoor[i, j + 1]] != 8)
                                            arr[arrdoor[i, j], arrdoor[i, j + 1]] = 0;
                                    }
                                }
                            }
                            c++;
                        }
                    }
                }
                SetLab();
            }
            else if (e.Key == Key.Enter && win == true)
            {
                RefreshB.Visibility = Visibility.Hidden;
                win = false;
                Up.IsEnabled = true;
                Down.IsEnabled = true;
                Left.IsEnabled = true;
                Right.IsEnabled = true;
                Ur1.IsEnabled = true;
                Ur2.IsEnabled = true;
                Ur3.IsEnabled = true;
                Ur4.IsEnabled = true;
                block = false;

                if (urNum == 1)
                {
                    arr[0, 0] = 1;
                    arr[0, 1] = 1;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 1;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 9;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 10;
                    arr[1, 2] = 0;
                    arr[1, 3] = 0;
                    arr[1, 4] = 10;
                    arr[1, 5] = 1; // Заполнение поля лабиринта
                    arr[1, 6] = 1;
                    arr[1, 7] = 0;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[2, 4] = 8;
                    arr[2, 5] = 0;
                    arr[2, 6] = 1;
                    arr[2, 7] = 0;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 1;
                    arr[3, 3] = 0;
                    arr[3, 4] = 0;
                    arr[3, 5] = 1;
                    arr[3, 6] = 1;
                    arr[3, 7] = 0;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 1;
                    arr[4, 2] = 1;
                    arr[4, 3] = 0;
                    arr[4, 4] = 1;
                    arr[4, 5] = 1;
                    arr[4, 6] = 1;
                    arr[4, 7] = 1;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 1;
                    arr[5, 2] = 0;
                    arr[5, 3] = 0;
                    arr[5, 4] = 10;
                    arr[5, 5] = 0;
                    arr[5, 6] = 1;
                    arr[5, 7] = 0;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 0;
                    arr[6, 2] = 0;
                    arr[6, 3] = 1;
                    arr[6, 4] = 8;
                    arr[6, 5] = 1;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 1;
                    arr[7, 2] = 0;
                    arr[7, 3] = 1;
                    arr[7, 4] = 0;
                    arr[7, 5] = 0;
                    arr[7, 6] = 0;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 1;
                    arr[8, 5] = 2;
                    arr[8, 6] = 1;
                    arr[8, 7] = 1;
                    arr[8, 8] = 1;

                    start1 = 8;
                    start2 = 5;
                    arrPress[0, 0] = 5;
                    arrPress[0, 1] = 4;
                    arrPress[1, 0] = 1;
                    arrPress[1, 1] = 4;
                    arrPress[2, 0] = 1;
                    arrPress[2, 1] = 1;
                    countPress = 3;
                    arrdoor[0, 0] = 7;
                    arrdoor[0, 1] = 3;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrOpen[0, 0] = false;
                    arrOpen[0, 1] = false;
                    arrdoor[1, 0] = 1;
                    arrdoor[1, 1] = 5;
                    arrdoor[1, 2] = -1;
                    arrdoor[1, 3] = -1;
                    arrOpen[1, 0] = false;
                    arrOpen[1, 1] = false;
                    arrdoor[2, 0] = 4;
                    arrdoor[2, 1] = 7;
                    arrdoor[2, 2] = -1;
                    arrdoor[2, 3] = -1;
                    arrOpen[2, 0] = false;
                    arrOpen[2, 1] = false;
                    win = false;
                    urNum = 2;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 25;
                    prBarSet = true;
                    Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur2.Background = Brushes.Brown;
                    Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");

                    Ur1.IsEnabled = true;
                    Ur2.IsEnabled = true;
                    Ur3.IsEnabled = false;
                    Ur4.IsEnabled = false;

                    ur1 = true;
                    ur2 = true;
                    ur3 = false;
                    ur4 = false;
                }
                else if (urNum == 2)
                {
                    arr[0, 0] = 1;
                    arr[0, 1] = 9;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 1;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 1;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 0;
                    arr[1, 2] = 1;
                    arr[1, 3] = 0;
                    arr[1, 4] = 0;
                    arr[1, 5] = 0; // Заполнение поля лабиринта
                    arr[1, 6] = 1;
                    arr[1, 7] = 1;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[2, 4] = 1;
                    arr[2, 5] = 0;
                    arr[2, 6] = 0;
                    arr[2, 7] = 0;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 1;
                    arr[3, 3] = 0;
                    arr[3, 4] = 1;
                    arr[3, 5] = 0;
                    arr[3, 6] = 8;
                    arr[3, 7] = 0;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 1;
                    arr[4, 2] = 1;
                    arr[4, 3] = 0;
                    arr[4, 4] = 1;
                    arr[4, 5] = 1;
                    arr[4, 6] = 10;
                    arr[4, 7] = 1;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 10;
                    arr[5, 2] = 8;
                    arr[5, 3] = 0;
                    arr[5, 4] = 1;
                    arr[5, 5] = 1;
                    arr[5, 6] = 1;
                    arr[5, 7] = 1;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 0;
                    arr[6, 2] = 1;
                    arr[6, 3] = 0;
                    arr[6, 4] = 0;
                    arr[6, 5] = 0;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 10;
                    arr[7, 2] = 1;
                    arr[7, 3] = 0;
                    arr[7, 4] = 0;
                    arr[7, 5] = 0;
                    arr[7, 6] = 8;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 1;
                    arr[8, 5] = 1;
                    arr[8, 6] = 1;
                    arr[8, 7] = 2;
                    arr[8, 8] = 1;
                    arrPress[0, 0] = 5;
                    arrPress[0, 1] = 1;
                    arrdoor[0, 0] = 7;
                    arrdoor[0, 1] = 2;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrOpen[0, 1] = false;
                    arrPress[1, 0] = 7;
                    arrPress[1, 1] = 1;
                    arrdoor[1, 0] = 2;
                    arrdoor[1, 1] = 3;
                    arrdoor[1, 2] = -1;
                    arrdoor[1, 3] = -1;
                    arrOpen[1, 0] = false;
                    arrPress[2, 0] = 4;
                    arrPress[2, 1] = 6;
                    arrdoor[2, 0] = 3;
                    arrdoor[2, 1] = 2;
                    arrdoor[2, 2] = -1;
                    arrdoor[2, 3] = -1;
                    arrOpen[2, 0] = false;
                    countPress = 3;


                    start1 = 8;
                    start2 = 7;
                    urNum = 3;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 50;
                    prBarSet = true;
                    win = false;
                    Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur3.Background = Brushes.Brown;
                    Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");

                    Ur1.IsEnabled = true;
                    Ur2.IsEnabled = true;
                    Ur3.IsEnabled = true;
                    Ur4.IsEnabled = false;

                    ur1 = true;
                    ur2 = true;
                    ur3 = true;
                    ur4 = false;
                }
                else if (urNum == 3)
                {
                    arr[0, 0] = 1;
                    arr[0, 1] = 1;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 9;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 1;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 1;
                    arr[1, 2] = 1;
                    arr[1, 3] = 0;
                    arr[1, 4] = 1;
                    arr[1, 5] = 1; // Заполнение поля лабиринта
                    arr[1, 6] = 0;
                    arr[1, 7] = 1;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[2, 4] = 1;
                    arr[2, 5] = 1;
                    arr[2, 6] = 0;
                    arr[2, 7] = 1;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 0;
                    arr[3, 3] = 0;
                    arr[3, 4] = 0;
                    arr[3, 5] = 0;
                    arr[3, 6] = 8;
                    arr[3, 7] = 10;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 8;
                    arr[4, 2] = 1;
                    arr[4, 3] = 1;
                    arr[4, 4] = 1;
                    arr[4, 5] = 1;
                    arr[4, 6] = 0;
                    arr[4, 7] = 1;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 0;
                    arr[5, 2] = 0;
                    arr[5, 3] = 0;
                    arr[5, 4] = 1;
                    arr[5, 5] = 1;
                    arr[5, 6] = 1;
                    arr[5, 7] = 1;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 0;
                    arr[6, 2] = 1;
                    arr[6, 3] = 0;
                    arr[6, 4] = 0;
                    arr[6, 5] = 0;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 10;
                    arr[7, 2] = 1;
                    arr[7, 3] = 0;
                    arr[7, 4] = 1;
                    arr[7, 5] = 0;
                    arr[7, 6] = 0;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 1;
                    arr[8, 5] = 1;
                    arr[8, 6] = 2;
                    arr[8, 7] = 1;
                    arr[8, 8] = 1;
                    arrPress[0, 0] = 2;
                    arrPress[0, 1] = 1;
                    arrdoor[0, 0] = 1;
                    arrdoor[0, 1] = 1;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrOpen[0, 0] = false;
                    arrPress[1, 0] = 3;
                    arrPress[1, 1] = 7;
                    arrdoor[1, 0] = 1;
                    arrdoor[1, 1] = 2;
                    arrdoor[1, 2] = 2;
                    arrdoor[1, 3] = 3;
                    arrOpen[1, 0] = false;
                    arrOpen[1, 1] = false;
                    arrPress[2, 0] = 7;
                    arrPress[2, 1] = 1;
                    arrdoor[2, 0] = 1;
                    arrdoor[2, 1] = 4;
                    arrdoor[2, 2] = -1;
                    arrdoor[2, 3] = -1;
                    arrOpen[2, 0] = false;
                    arrOpen[2, 1] = false;
                    start1 = 8;
                    start2 = 6;
                    urNum = 4;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 75;
                    prBarSet = true;
                    Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = Brushes.Brown;
                    Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");

                    Ur1.IsEnabled = true;
                    Ur2.IsEnabled = true;
                    Ur3.IsEnabled = true;
                    Ur4.IsEnabled = true;

                    ur1 = true;
                    ur2 = true;
                    ur3 = true;
                    ur4 = true;
                }
                else if (urNum == 4)
                {
                    arr[0, 0] = 1;
                    arr[0, 1] = 9;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 1;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 1;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 0;
                    arr[1, 2] = 1;
                    arr[1, 3] = 1;
                    arr[1, 4] = 1;
                    arr[1, 5] = 0; // Заполнение поля лабиринта
                    arr[1, 6] = 0;
                    arr[1, 7] = 0;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт, 8 - ящик, 10 - кнопка, 3 - рубин
                    arr[2, 2] = 0;
                    arr[2, 3] = 0;
                    arr[2, 4] = 0;
                    arr[2, 5] = 0;
                    arr[2, 6] = 1;
                    arr[2, 7] = 0;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 1;
                    arr[3, 3] = 1;
                    arr[3, 4] = 8;
                    arr[3, 5] = 1;
                    arr[3, 6] = 1;
                    arr[3, 7] = 0;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 0;
                    arr[4, 2] = 1;
                    arr[4, 3] = 0;
                    arr[4, 4] = 0;
                    arr[4, 5] = 0;
                    arr[4, 6] = 1;
                    arr[4, 7] = 0;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 1;
                    arr[5, 2] = 1;
                    arr[5, 3] = 0;
                    arr[5, 4] = 1;
                    arr[5, 5] = 0;
                    arr[5, 6] = 1;
                    arr[5, 7] = 1;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 1;
                    arr[6, 2] = 1;
                    arr[6, 3] = 1;
                    arr[6, 4] = 1;
                    arr[6, 5] = 0;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 1;
                    arr[7, 2] = 1;
                    arr[7, 3] = 1;
                    arr[7, 4] = 0;
                    arr[7, 5] = 0;
                    arr[7, 6] = 0;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 2;
                    arr[8, 5] = 1;
                    arr[8, 6] = 1;
                    arr[8, 7] = 1;
                    arr[8, 8] = 1;

                    arrPress[0, 0] = 3;
                    arrPress[0, 1] = 4;
                    arrPress[1, 0] = 2;
                    arrPress[1, 1] = 1;
                    countPress = 2;
                    arrdoor[0, 0] = 4;
                    arrdoor[0, 1] = 6;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrdoor[1, 0] = 1;
                    arrdoor[1, 1] = 2;
                    arrdoor[1, 2] = -1;
                    arrdoor[1, 3] = -1;
                    arrOpen[0, 0] = true;
                    arrOpen[0, 1] = false;
                    arrOpen[1, 0] = false;
                    arrOpen[1, 1] = false;
                    start1 = 8;
                    start2 = 4;
                    win = false;
                    urNum = 1;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 0;
                    prBarSet = true;
                    Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur1.Background = Brushes.Brown;
                    Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");

                    Ur1.IsEnabled = true;
                    Ur2.IsEnabled = false;
                    Ur3.IsEnabled = false;
                    Ur4.IsEnabled = false;

                    ur1 = true;
                    ur2 = false;
                    ur3 = false;
                    ur4 = false;
                }
                SetLab();
            }
        
            else if (e.Key == Key.D1)
            {
                if (ur1)
                {
                    RefreshB.Visibility = Visibility.Hidden;

                    Up.IsEnabled = true;
                    Down.IsEnabled = true;
                    Left.IsEnabled = true;
                    Right.IsEnabled = true;
                    block = false;
                    urNum = 1;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 0;
                    prBarSet = true;
                    arr[0, 0] = 1;
                    arr[0, 1] = 9;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 1;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 1;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 0;
                    arr[1, 2] = 1;
                    arr[1, 3] = 1;
                    arr[1, 4] = 1;
                    arr[1, 5] = 0; // Заполнение поля лабиринта
                    arr[1, 6] = 0;
                    arr[1, 7] = 0;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт, 8 - ящик, 10 - кнопка, 3 - рубин
                    arr[2, 2] = 0;
                    arr[2, 3] = 0;
                    arr[2, 4] = 0;
                    arr[2, 5] = 0;
                    arr[2, 6] = 1;
                    arr[2, 7] = 0;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 1;
                    arr[3, 3] = 1;
                    arr[3, 4] = 8;
                    arr[3, 5] = 1;
                    arr[3, 6] = 1;
                    arr[3, 7] = 0;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 0;
                    arr[4, 2] = 1;
                    arr[4, 3] = 0;
                    arr[4, 4] = 0;
                    arr[4, 5] = 0;
                    arr[4, 6] = 1;
                    arr[4, 7] = 0;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 1;
                    arr[5, 2] = 1;
                    arr[5, 3] = 0;
                    arr[5, 4] = 1;
                    arr[5, 5] = 0;
                    arr[5, 6] = 1;
                    arr[5, 7] = 1;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 1;
                    arr[6, 2] = 1;
                    arr[6, 3] = 1;
                    arr[6, 4] = 1;
                    arr[6, 5] = 0;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 1;
                    arr[7, 2] = 1;
                    arr[7, 3] = 1;
                    arr[7, 4] = 0;
                    arr[7, 5] = 0;
                    arr[7, 6] = 0;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 2;
                    arr[8, 5] = 1;
                    arr[8, 6] = 1;
                    arr[8, 7] = 1;
                    arr[8, 8] = 1;

                    arrPress[0, 0] = 3;
                    arrPress[0, 1] = 4;
                    arrPress[1, 0] = 2;
                    arrPress[1, 1] = 1;
                    countPress = 2;
                    arrdoor[0, 0] = 4;
                    arrdoor[0, 1] = 6;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrdoor[1, 0] = 1;
                    arrdoor[1, 1] = 2;
                    arrdoor[1, 2] = -1;
                    arrdoor[1, 3] = -1;
                    arrOpen[0, 0] = true;
                    arrOpen[0, 1] = false;
                    arrOpen[1, 0] = false;
                    arrOpen[1, 1] = false;
                    start1 = 8;
                    start2 = 4;
                    win = false;
                    Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur1.Background = Brushes.Brown;
                    Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    SetLab();
                }
            }
            else if (e.Key == Key.D2)
            {
                if (ur2)
                {
                    RefreshB.Visibility = Visibility.Hidden;

                    Up.IsEnabled = true;
                    Down.IsEnabled = true;
                    Left.IsEnabled = true;
                    Right.IsEnabled = true;
                    block = false;
                    urNum = 2;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 25;
                    prBarSet = true;
                    arr[0, 0] = 1;
                    arr[0, 1] = 1;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 1;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 9;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 10;
                    arr[1, 2] = 0;
                    arr[1, 3] = 0;
                    arr[1, 4] = 10;
                    arr[1, 5] = 1; // Заполнение поля лабиринта
                    arr[1, 6] = 1;
                    arr[1, 7] = 0;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[2, 4] = 8;
                    arr[2, 5] = 0;
                    arr[2, 6] = 1;
                    arr[2, 7] = 0;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 1;
                    arr[3, 3] = 0;
                    arr[3, 4] = 0;
                    arr[3, 5] = 1;
                    arr[3, 6] = 1;
                    arr[3, 7] = 0;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 1;
                    arr[4, 2] = 1;
                    arr[4, 3] = 0;
                    arr[4, 4] = 1;
                    arr[4, 5] = 1;
                    arr[4, 6] = 1;
                    arr[4, 7] = 1;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 1;
                    arr[5, 2] = 0;
                    arr[5, 3] = 0;
                    arr[5, 4] = 10;
                    arr[5, 5] = 0;
                    arr[5, 6] = 1;
                    arr[5, 7] = 0;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 0;
                    arr[6, 2] = 0;
                    arr[6, 3] = 1;
                    arr[6, 4] = 8;
                    arr[6, 5] = 1;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 1;
                    arr[7, 2] = 0;
                    arr[7, 3] = 1;
                    arr[7, 4] = 0;
                    arr[7, 5] = 0;
                    arr[7, 6] = 0;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 1;
                    arr[8, 5] = 2;
                    arr[8, 6] = 1;
                    arr[8, 7] = 1;
                    arr[8, 8] = 1;

                    start1 = 8;
                    start2 = 5;
                    arrPress[0, 0] = 5;
                    arrPress[0, 1] = 4;
                    arrPress[1, 0] = 1;
                    arrPress[1, 1] = 4;
                    arrPress[2, 0] = 1;
                    arrPress[2, 1] = 1;
                    countPress = 3;
                    arrdoor[0, 0] = 7;
                    arrdoor[0, 1] = 3;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrOpen[0, 0] = false;
                    arrOpen[0, 1] = false;
                    arrdoor[1, 0] = 1;
                    arrdoor[1, 1] = 5;
                    arrdoor[1, 2] = -1;
                    arrdoor[1, 3] = -1;
                    arrOpen[1, 0] = false;
                    arrOpen[1, 1] = false;
                    arrdoor[2, 0] = 4;
                    arrdoor[2, 1] = 7;
                    arrdoor[2, 2] = -1;
                    arrdoor[2, 3] = -1;
                    arrOpen[2, 0] = false;
                    arrOpen[2, 1] = false;
                    win = false;
                    Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur2.Background = Brushes.Brown;
                    Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    SetLab();
                }
            }
            else if (e.Key == Key.D3)
            {
                if (ur3)
                {
                    RefreshB.Visibility = Visibility.Hidden;

                    Up.IsEnabled = true;
                    Down.IsEnabled = true;
                    Left.IsEnabled = true;
                    Right.IsEnabled = true;
                    block = false;
                    urNum = 3;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 50;
                    prBarSet = true;
                    arr[0, 0] = 1;
                    arr[0, 1] = 9;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 1;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 1;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 0;
                    arr[1, 2] = 1;
                    arr[1, 3] = 0;
                    arr[1, 4] = 0;
                    arr[1, 5] = 0; // Заполнение поля лабиринта
                    arr[1, 6] = 1;
                    arr[1, 7] = 1;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[2, 4] = 1;
                    arr[2, 5] = 0;
                    arr[2, 6] = 0;
                    arr[2, 7] = 0;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 1;
                    arr[3, 3] = 0;
                    arr[3, 4] = 1;
                    arr[3, 5] = 0;
                    arr[3, 6] = 8;
                    arr[3, 7] = 0;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 1;
                    arr[4, 2] = 1;
                    arr[4, 3] = 0;
                    arr[4, 4] = 1;
                    arr[4, 5] = 1;
                    arr[4, 6] = 10;
                    arr[4, 7] = 1;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 10;
                    arr[5, 2] = 8;
                    arr[5, 3] = 0;
                    arr[5, 4] = 1;
                    arr[5, 5] = 1;
                    arr[5, 6] = 1;
                    arr[5, 7] = 1;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 0;
                    arr[6, 2] = 1;
                    arr[6, 3] = 0;
                    arr[6, 4] = 0;
                    arr[6, 5] = 0;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 10;
                    arr[7, 2] = 1;
                    arr[7, 3] = 0;
                    arr[7, 4] = 0;
                    arr[7, 5] = 0;
                    arr[7, 6] = 8;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 1;
                    arr[8, 5] = 1;
                    arr[8, 6] = 1;
                    arr[8, 7] = 2;
                    arr[8, 8] = 1;
                    arrPress[0, 0] = 5;
                    arrPress[0, 1] = 1;
                    arrdoor[0, 0] = 7;
                    arrdoor[0, 1] = 2;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrOpen[0, 1] = false;
                    arrPress[1, 0] = 7;
                    arrPress[1, 1] = 1;
                    arrdoor[1, 0] = 2;
                    arrdoor[1, 1] = 3;
                    arrdoor[1, 2] = -1;
                    arrdoor[1, 3] = -1;
                    arrOpen[1, 0] = false;
                    arrPress[2, 0] = 4;
                    arrPress[2, 1] = 6;
                    arrdoor[2, 0] = 3;
                    arrdoor[2, 1] = 2;
                    arrdoor[2, 2] = -1;
                    arrdoor[2, 3] = -1;
                    arrOpen[2, 0] = false;
                    countPress = 3;


                    start1 = 8;
                    start2 = 7;
                    win = false;
                    Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur3.Background = Brushes.Brown;
                    Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    SetLab();
                }
            }
            else if (e.Key == Key.D4)
            {
                if (ur4)
                {
                    RefreshB.Visibility = Visibility.Hidden;

                    Up.IsEnabled = true;
                    Down.IsEnabled = true;
                    Left.IsEnabled = true;
                    Right.IsEnabled = true;
                    block = false;
                    urNum = 4;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 75;
                    prBarSet = true;
                    arr[0, 0] = 1;
                    arr[0, 1] = 1;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 9;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 1;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 1;
                    arr[1, 2] = 1;
                    arr[1, 3] = 0;
                    arr[1, 4] = 1;
                    arr[1, 5] = 1; // Заполнение поля лабиринта
                    arr[1, 6] = 0;
                    arr[1, 7] = 1;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[2, 4] = 1;
                    arr[2, 5] = 1;
                    arr[2, 6] = 0;
                    arr[2, 7] = 1;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 0;
                    arr[3, 3] = 0;
                    arr[3, 4] = 0;
                    arr[3, 5] = 0;
                    arr[3, 6] = 8;
                    arr[3, 7] = 10;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 8;
                    arr[4, 2] = 1;
                    arr[4, 3] = 1;
                    arr[4, 4] = 1;
                    arr[4, 5] = 1;
                    arr[4, 6] = 0;
                    arr[4, 7] = 1;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 0;
                    arr[5, 2] = 0;
                    arr[5, 3] = 0;
                    arr[5, 4] = 1;
                    arr[5, 5] = 1;
                    arr[5, 6] = 1;
                    arr[5, 7] = 1;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 0;
                    arr[6, 2] = 1;
                    arr[6, 3] = 0;
                    arr[6, 4] = 0;
                    arr[6, 5] = 0;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 10;
                    arr[7, 2] = 1;
                    arr[7, 3] = 0;
                    arr[7, 4] = 1;
                    arr[7, 5] = 0;
                    arr[7, 6] = 0;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 1;
                    arr[8, 5] = 1;
                    arr[8, 6] = 2;
                    arr[8, 7] = 1;
                    arr[8, 8] = 1;
                    arrPress[0, 0] = 2;
                    arrPress[0, 1] = 1;
                    arrdoor[0, 0] = 1;
                    arrdoor[0, 1] = 1;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrOpen[0, 0] = false;
                    arrPress[1, 0] = 3;
                    arrPress[1, 1] = 7;
                    arrdoor[1, 0] = 1;
                    arrdoor[1, 1] = 2;
                    arrdoor[1, 2] = 2;
                    arrdoor[1, 3] = 3;
                    arrOpen[1, 0] = false;
                    arrOpen[1, 1] = false;
                    arrPress[2, 0] = 7;
                    arrPress[2, 1] = 1;
                    arrdoor[2, 0] = 1;
                    arrdoor[2, 1] = 4;
                    arrdoor[2, 2] = -1;
                    arrdoor[2, 3] = -1;
                    arrOpen[2, 0] = false;
                    arrOpen[2, 1] = false;
                    win = false;
                    start1 = 8;
                    start2 = 6;
                    Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = Brushes.Brown;
                    Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    SetLab();
                }
            }
            else if (e.Key == Key.Space)
            {
                if (urNum == 1)
                {
                    if (ur1)
                    {
                        arr[0, 0] = 1;
                        arr[0, 1] = 9;
                        arr[0, 2] = 1;
                        arr[0, 3] = 1;
                        arr[0, 4] = 1;
                        arr[0, 5] = 1;
                        arr[0, 6] = 1;
                        arr[0, 7] = 1;
                        arr[0, 8] = 1;
                        arr[1, 0] = 1;
                        arr[1, 1] = 0;
                        arr[1, 2] = 1;
                        arr[1, 3] = 1;
                        arr[1, 4] = 1;
                        arr[1, 5] = 0; // Заполнение поля лабиринта
                        arr[1, 6] = 0;
                        arr[1, 7] = 0;
                        arr[1, 8] = 1;
                        arr[2, 0] = 1;
                        arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт, 8 - ящик, 10 - кнопка
                        arr[2, 2] = 0;
                        arr[2, 3] = 0;
                        arr[2, 4] = 0;
                        arr[2, 5] = 0;
                        arr[2, 6] = 1;
                        arr[2, 7] = 0;
                        arr[2, 8] = 1;
                        arr[3, 0] = 1;
                        arr[3, 1] = 0;
                        arr[3, 2] = 1;
                        arr[3, 3] = 1;
                        arr[3, 4] = 8;
                        arr[3, 5] = 1;
                        arr[3, 6] = 1;
                        arr[3, 7] = 0;
                        arr[3, 8] = 1;
                        arr[4, 0] = 1;
                        arr[4, 1] = 0;
                        arr[4, 2] = 1;
                        arr[4, 3] = 0;
                        arr[4, 4] = 0;
                        arr[4, 5] = 0;
                        arr[4, 6] = 1;
                        arr[4, 7] = 0;
                        arr[4, 8] = 1;
                        arr[5, 0] = 1;
                        arr[5, 1] = 1;
                        arr[5, 2] = 1;
                        arr[5, 3] = 0;
                        arr[5, 4] = 1;
                        arr[5, 5] = 0;
                        arr[5, 6] = 1;
                        arr[5, 7] = 1;
                        arr[5, 8] = 1;
                        arr[6, 0] = 1;
                        arr[6, 1] = 1;
                        arr[6, 2] = 1;
                        arr[6, 3] = 1;
                        arr[6, 4] = 1;
                        arr[6, 5] = 0;
                        arr[6, 6] = 1;
                        arr[6, 7] = 0;
                        arr[6, 8] = 1;
                        arr[7, 0] = 1;
                        arr[7, 1] = 1;
                        arr[7, 2] = 1;
                        arr[7, 3] = 1;
                        arr[7, 4] = 0;
                        arr[7, 5] = 0;
                        arr[7, 6] = 0;
                        arr[7, 7] = 0;
                        arr[7, 8] = 1;
                        arr[8, 0] = 1;
                        arr[8, 1] = 1;
                        arr[8, 2] = 1;
                        arr[8, 3] = 1;
                        arr[8, 4] = 2;
                        arr[8, 5] = 1;
                        arr[8, 6] = 1;
                        arr[8, 7] = 1;
                        arr[8, 8] = 1;

                        arrPress[0, 0] = 3;
                        arrPress[0, 1] = 4;
                        arrPress[1, 0] = 2;
                        arrPress[1, 1] = 1;
                        countPress = 2;
                        arrdoor[0, 0] = 4;
                        arrdoor[0, 1] = 6;
                        arrdoor[0, 2] = -1;
                        arrdoor[0, 3] = -1;
                        arrdoor[1, 0] = 1;
                        arrdoor[1, 1] = 2;
                        arrdoor[1, 2] = -1;
                        arrdoor[1, 3] = -1;
                        arrOpen[0, 0] = true;
                        arrOpen[0, 1] = false;
                        arrOpen[1, 0] = false;
                        arrOpen[1, 1] = false;
                        start1 = 8;
                        start2 = 4;
                        prBar.Value = 0;
                        Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        Ur1.Background = Brushes.Brown;
                        Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        SetLab();
                    }
                }
                else if (urNum == 2)
                {
                    if (ur2)
                    {
                        RefreshB.Visibility = Visibility.Hidden;

                        Up.IsEnabled = true;
                        Down.IsEnabled = true;
                        Left.IsEnabled = true;
                        Right.IsEnabled = true;
                        block = false;
                        urNum = 2;
                        prBar.BorderBrush = Brushes.Green;
                        prBarVal = 25;
                        prBarSet = true;
                        arr[0, 0] = 1;
                        arr[0, 1] = 1;
                        arr[0, 2] = 1;
                        arr[0, 3] = 1;
                        arr[0, 4] = 1;
                        arr[0, 5] = 1;
                        arr[0, 6] = 1;
                        arr[0, 7] = 9;
                        arr[0, 8] = 1;
                        arr[1, 0] = 1;
                        arr[1, 1] = 10;
                        arr[1, 2] = 0;
                        arr[1, 3] = 0;
                        arr[1, 4] = 10;
                        arr[1, 5] = 1; // Заполнение поля лабиринта
                        arr[1, 6] = 1;
                        arr[1, 7] = 0;
                        arr[1, 8] = 1;
                        arr[2, 0] = 1;
                        arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                        arr[2, 2] = 1;
                        arr[2, 3] = 1;
                        arr[2, 4] = 8;
                        arr[2, 5] = 0;
                        arr[2, 6] = 1;
                        arr[2, 7] = 0;
                        arr[2, 8] = 1;
                        arr[3, 0] = 1;
                        arr[3, 1] = 0;
                        arr[3, 2] = 1;
                        arr[3, 3] = 0;
                        arr[3, 4] = 0;
                        arr[3, 5] = 1;
                        arr[3, 6] = 1;
                        arr[3, 7] = 0;
                        arr[3, 8] = 1;
                        arr[4, 0] = 1;
                        arr[4, 1] = 1;
                        arr[4, 2] = 1;
                        arr[4, 3] = 0;
                        arr[4, 4] = 1;
                        arr[4, 5] = 1;
                        arr[4, 6] = 1;
                        arr[4, 7] = 1;
                        arr[4, 8] = 1;
                        arr[5, 0] = 1;
                        arr[5, 1] = 1;
                        arr[5, 2] = 0;
                        arr[5, 3] = 0;
                        arr[5, 4] = 10;
                        arr[5, 5] = 0;
                        arr[5, 6] = 1;
                        arr[5, 7] = 0;
                        arr[5, 8] = 1;
                        arr[6, 0] = 1;
                        arr[6, 1] = 0;
                        arr[6, 2] = 0;
                        arr[6, 3] = 1;
                        arr[6, 4] = 8;
                        arr[6, 5] = 1;
                        arr[6, 6] = 1;
                        arr[6, 7] = 0;
                        arr[6, 8] = 1;
                        arr[7, 0] = 1;
                        arr[7, 1] = 1;
                        arr[7, 2] = 0;
                        arr[7, 3] = 1;
                        arr[7, 4] = 0;
                        arr[7, 5] = 0;
                        arr[7, 6] = 0;
                        arr[7, 7] = 0;
                        arr[7, 8] = 1;
                        arr[8, 0] = 1;
                        arr[8, 1] = 1;
                        arr[8, 2] = 1;
                        arr[8, 3] = 1;
                        arr[8, 4] = 1;
                        arr[8, 5] = 2;
                        arr[8, 6] = 1;
                        arr[8, 7] = 1;
                        arr[8, 8] = 1;

                        start1 = 8;
                        start2 = 5;
                        arrPress[0, 0] = 5;
                        arrPress[0, 1] = 4;
                        arrPress[1, 0] = 1;
                        arrPress[1, 1] = 4;
                        arrPress[2, 0] = 1;
                        arrPress[2, 1] = 1;
                        countPress = 3;
                        arrdoor[0, 0] = 7;
                        arrdoor[0, 1] = 3;
                        arrdoor[0, 2] = -1;
                        arrdoor[0, 3] = -1;
                        arrOpen[0, 0] = false;
                        arrOpen[0, 1] = false;
                        arrdoor[1, 0] = 1;
                        arrdoor[1, 1] = 5;
                        arrdoor[1, 2] = -1;
                        arrdoor[1, 3] = -1;
                        arrOpen[1, 0] = false;
                        arrOpen[1, 1] = false;
                        arrdoor[2, 0] = 4;
                        arrdoor[2, 1] = 7;
                        arrdoor[2, 2] = -1;
                        arrdoor[2, 3] = -1;
                        arrOpen[2, 0] = false;
                        arrOpen[2, 1] = false;
                        win = false;
                        Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        Ur2.Background = Brushes.Brown;
                        Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        SetLab();
                    }
                }
                else if (urNum == 3)
                {
                    if (ur3)
                    {
                        RefreshB.Visibility = Visibility.Hidden;

                        Up.IsEnabled = true;
                        Down.IsEnabled = true;
                        Left.IsEnabled = true;
                        Right.IsEnabled = true;
                        block = false;
                        urNum = 3;
                        prBar.BorderBrush = Brushes.Green;
                        prBarVal = 50;
                        prBarSet = true;
                        arr[0, 0] = 1;
                        arr[0, 1] = 9;
                        arr[0, 2] = 1;
                        arr[0, 3] = 1;
                        arr[0, 4] = 1;
                        arr[0, 5] = 1;
                        arr[0, 6] = 1;
                        arr[0, 7] = 1;
                        arr[0, 8] = 1;
                        arr[1, 0] = 1;
                        arr[1, 1] = 0;
                        arr[1, 2] = 1;
                        arr[1, 3] = 0;
                        arr[1, 4] = 0;
                        arr[1, 5] = 0; // Заполнение поля лабиринта
                        arr[1, 6] = 1;
                        arr[1, 7] = 1;
                        arr[1, 8] = 1;
                        arr[2, 0] = 1;
                        arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                        arr[2, 2] = 1;
                        arr[2, 3] = 1;
                        arr[2, 4] = 1;
                        arr[2, 5] = 0;
                        arr[2, 6] = 0;
                        arr[2, 7] = 0;
                        arr[2, 8] = 1;
                        arr[3, 0] = 1;
                        arr[3, 1] = 0;
                        arr[3, 2] = 1;
                        arr[3, 3] = 0;
                        arr[3, 4] = 1;
                        arr[3, 5] = 0;
                        arr[3, 6] = 8;
                        arr[3, 7] = 0;
                        arr[3, 8] = 1;
                        arr[4, 0] = 1;
                        arr[4, 1] = 1;
                        arr[4, 2] = 1;
                        arr[4, 3] = 0;
                        arr[4, 4] = 1;
                        arr[4, 5] = 1;
                        arr[4, 6] = 10;
                        arr[4, 7] = 1;
                        arr[4, 8] = 1;
                        arr[5, 0] = 1;
                        arr[5, 1] = 10;
                        arr[5, 2] = 8;
                        arr[5, 3] = 0;
                        arr[5, 4] = 1;
                        arr[5, 5] = 1;
                        arr[5, 6] = 1;
                        arr[5, 7] = 1;
                        arr[5, 8] = 1;
                        arr[6, 0] = 1;
                        arr[6, 1] = 0;
                        arr[6, 2] = 1;
                        arr[6, 3] = 0;
                        arr[6, 4] = 0;
                        arr[6, 5] = 0;
                        arr[6, 6] = 1;
                        arr[6, 7] = 0;
                        arr[6, 8] = 1;
                        arr[7, 0] = 1;
                        arr[7, 1] = 10;
                        arr[7, 2] = 1;
                        arr[7, 3] = 0;
                        arr[7, 4] = 0;
                        arr[7, 5] = 0;
                        arr[7, 6] = 8;
                        arr[7, 7] = 0;
                        arr[7, 8] = 1;
                        arr[8, 0] = 1;
                        arr[8, 1] = 1;
                        arr[8, 2] = 1;
                        arr[8, 3] = 1;
                        arr[8, 4] = 1;
                        arr[8, 5] = 1;
                        arr[8, 6] = 1;
                        arr[8, 7] = 2;
                        arr[8, 8] = 1;
                        arrPress[0, 0] = 5;
                        arrPress[0, 1] = 1;
                        arrdoor[0, 0] = 7;
                        arrdoor[0, 1] = 2;
                        arrdoor[0, 2] = -1;
                        arrdoor[0, 3] = -1;
                        arrOpen[0, 1] = false;
                        arrPress[1, 0] = 7;
                        arrPress[1, 1] = 1;
                        arrdoor[1, 0] = 2;
                        arrdoor[1, 1] = 3;
                        arrdoor[1, 2] = -1;
                        arrdoor[1, 3] = -1;
                        arrOpen[1, 0] = false;
                        arrPress[2, 0] = 4;
                        arrPress[2, 1] = 6;
                        arrdoor[2, 0] = 3;
                        arrdoor[2, 1] = 2;
                        arrdoor[2, 2] = -1;
                        arrdoor[2, 3] = -1;
                        arrOpen[2, 0] = false;
                        countPress = 3;


                        start1 = 8;
                        start2 = 7;
                        win = false;
                        Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        Ur3.Background = Brushes.Brown;
                        Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        SetLab();
                    }
                }
                else if (urNum == 4)
                {
                    if (ur4)
                    {
                        RefreshB.Visibility = Visibility.Hidden;

                        Up.IsEnabled = true;
                        Down.IsEnabled = true;
                        Left.IsEnabled = true;
                        Right.IsEnabled = true;
                        block = false;
                        urNum = 4;
                        prBar.BorderBrush = Brushes.Green;
                        prBarVal = 75;
                        prBarSet = true;
                        arr[0, 0] = 1;
                        arr[0, 1] = 1;
                        arr[0, 2] = 1;
                        arr[0, 3] = 1;
                        arr[0, 4] = 9;
                        arr[0, 5] = 1;
                        arr[0, 6] = 1;
                        arr[0, 7] = 1;
                        arr[0, 8] = 1;
                        arr[1, 0] = 1;
                        arr[1, 1] = 1;
                        arr[1, 2] = 1;
                        arr[1, 3] = 0;
                        arr[1, 4] = 1;
                        arr[1, 5] = 1; // Заполнение поля лабиринта
                        arr[1, 6] = 0;
                        arr[1, 7] = 1;
                        arr[1, 8] = 1;
                        arr[2, 0] = 1;
                        arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                        arr[2, 2] = 1;
                        arr[2, 3] = 1;
                        arr[2, 4] = 1;
                        arr[2, 5] = 1;
                        arr[2, 6] = 0;
                        arr[2, 7] = 1;
                        arr[2, 8] = 1;
                        arr[3, 0] = 1;
                        arr[3, 1] = 0;
                        arr[3, 2] = 0;
                        arr[3, 3] = 0;
                        arr[3, 4] = 0;
                        arr[3, 5] = 0;
                        arr[3, 6] = 8;
                        arr[3, 7] = 10;
                        arr[3, 8] = 1;
                        arr[4, 0] = 1;
                        arr[4, 1] = 8;
                        arr[4, 2] = 1;
                        arr[4, 3] = 1;
                        arr[4, 4] = 1;
                        arr[4, 5] = 1;
                        arr[4, 6] = 0;
                        arr[4, 7] = 1;
                        arr[4, 8] = 1;
                        arr[5, 0] = 1;
                        arr[5, 1] = 0;
                        arr[5, 2] = 0;
                        arr[5, 3] = 0;
                        arr[5, 4] = 1;
                        arr[5, 5] = 1;
                        arr[5, 6] = 1;
                        arr[5, 7] = 1;
                        arr[5, 8] = 1;
                        arr[6, 0] = 1;
                        arr[6, 1] = 0;
                        arr[6, 2] = 1;
                        arr[6, 3] = 0;
                        arr[6, 4] = 0;
                        arr[6, 5] = 0;
                        arr[6, 6] = 1;
                        arr[6, 7] = 0;
                        arr[6, 8] = 1;
                        arr[7, 0] = 1;
                        arr[7, 1] = 10;
                        arr[7, 2] = 1;
                        arr[7, 3] = 0;
                        arr[7, 4] = 1;
                        arr[7, 5] = 0;
                        arr[7, 6] = 0;
                        arr[7, 7] = 0;
                        arr[7, 8] = 1;
                        arr[8, 0] = 1;
                        arr[8, 1] = 1;
                        arr[8, 2] = 1;
                        arr[8, 3] = 1;
                        arr[8, 4] = 1;
                        arr[8, 5] = 1;
                        arr[8, 6] = 2;
                        arr[8, 7] = 1;
                        arr[8, 8] = 1;
                        arrPress[0, 0] = 2;
                        arrPress[0, 1] = 1;
                        arrdoor[0, 0] = 1;
                        arrdoor[0, 1] = 1;
                        arrdoor[0, 2] = -1;
                        arrdoor[0, 3] = -1;
                        arrOpen[0, 0] = false;
                        arrPress[1, 0] = 3;
                        arrPress[1, 1] = 7;
                        arrdoor[1, 0] = 1;
                        arrdoor[1, 1] = 2;
                        arrdoor[1, 2] = 2;
                        arrdoor[1, 3] = 3;
                        arrOpen[1, 0] = false;
                        arrOpen[1, 1] = false;
                        arrPress[2, 0] = 7;
                        arrPress[2, 1] = 1;
                        arrdoor[2, 0] = 1;
                        arrdoor[2, 1] = 4;
                        arrdoor[2, 2] = -1;
                        arrdoor[2, 3] = -1;
                        arrOpen[2, 0] = false;
                        arrOpen[2, 1] = false;
                        win = false;
                        start1 = 8;
                        start2 = 6;
                        Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        Ur4.Background = Brushes.Brown;
                        Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                        SetLab();
                    }
                }
                SetLab();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            RefreshB.Visibility = Visibility.Hidden;

            Up.IsEnabled = true;
            Down.IsEnabled = true;
            Left.IsEnabled = true;
            Right.IsEnabled = true;
            block = false;
            urNum = 1;
            prBar.BorderBrush = Brushes.Green;
            prBarVal = 0;
            prBarSet = true;
            arr[0, 0] = 1;
            arr[0, 1] = 9;
            arr[0, 2] = 1;
            arr[0, 3] = 1;
            arr[0, 4] = 1;
            arr[0, 5] = 1;
            arr[0, 6] = 1;
            arr[0, 7] = 1;
            arr[0, 8] = 1;
            arr[1, 0] = 1;
            arr[1, 1] = 0;
            arr[1, 2] = 1;
            arr[1, 3] = 1;
            arr[1, 4] = 1;
            arr[1, 5] = 0; // Заполнение поля лабиринта
            arr[1, 6] = 0;
            arr[1, 7] = 0;
            arr[1, 8] = 1;
            arr[2, 0] = 1;
            arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт, 8 - ящик, 10 - кнопка, 3 - рубин
            arr[2, 2] = 0;
            arr[2, 3] = 0;
            arr[2, 4] = 0;
            arr[2, 5] = 0;
            arr[2, 6] = 1;
            arr[2, 7] = 0;
            arr[2, 8] = 1;
            arr[3, 0] = 1;
            arr[3, 1] = 0;
            arr[3, 2] = 1;
            arr[3, 3] = 1;
            arr[3, 4] = 8;
            arr[3, 5] = 1;
            arr[3, 6] = 1;
            arr[3, 7] = 0;
            arr[3, 8] = 1;
            arr[4, 0] = 1;
            arr[4, 1] = 0;
            arr[4, 2] = 1;
            arr[4, 3] = 0;
            arr[4, 4] = 0;
            arr[4, 5] = 0;
            arr[4, 6] = 1;
            arr[4, 7] = 0;
            arr[4, 8] = 1;
            arr[5, 0] = 1;
            arr[5, 1] = 1;
            arr[5, 2] = 1;
            arr[5, 3] = 0;
            arr[5, 4] = 1;
            arr[5, 5] = 0;
            arr[5, 6] = 1;
            arr[5, 7] = 1;
            arr[5, 8] = 1;
            arr[6, 0] = 1;
            arr[6, 1] = 1;
            arr[6, 2] = 1;
            arr[6, 3] = 1;
            arr[6, 4] = 1;
            arr[6, 5] = 0;
            arr[6, 6] = 1;
            arr[6, 7] = 0;
            arr[6, 8] = 1;
            arr[7, 0] = 1;
            arr[7, 1] = 1;
            arr[7, 2] = 1;
            arr[7, 3] = 1;
            arr[7, 4] = 0;
            arr[7, 5] = 0;
            arr[7, 6] = 0;
            arr[7, 7] = 0;
            arr[7, 8] = 1;
            arr[8, 0] = 1;
            arr[8, 1] = 1;
            arr[8, 2] = 1;
            arr[8, 3] = 1;
            arr[8, 4] = 2;
            arr[8, 5] = 1;
            arr[8, 6] = 1;
            arr[8, 7] = 1;
            arr[8, 8] = 1;

            arrPress[0, 0] = 3;
            arrPress[0, 1] = 4;
            arrPress[1, 0] = 2;
            arrPress[1, 1] = 1;
            countPress = 2;
            arrdoor[0, 0] = 4;
            arrdoor[0, 1] = 6;
            arrdoor[0, 2] = -1;
            arrdoor[0, 3] = -1;
            arrdoor[1, 0] = 1;
            arrdoor[1, 1] = 2;
            arrdoor[1, 2] = -1;
            arrdoor[1, 3] = -1;
            arrOpen[0, 0] = true;
            arrOpen[0, 1] = false;
            arrOpen[1, 0] = false;
            arrOpen[1, 1] = false;
            start1 = 8;
            start2 = 4;
            win = false;
            Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur1.Background = Brushes.Brown;
            Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            SetLab();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            RefreshB.Visibility = Visibility.Hidden;

            Up.IsEnabled = true;
            Down.IsEnabled = true;
            Left.IsEnabled = true;
            Right.IsEnabled = true;
            block = false;
            urNum = 2;
            prBar.BorderBrush = Brushes.Green;
            prBarVal = 25;
            prBarSet = true;
            arr[0, 0] = 1;
            arr[0, 1] = 1;
            arr[0, 2] = 1;
            arr[0, 3] = 1;
            arr[0, 4] = 1;
            arr[0, 5] = 1;
            arr[0, 6] = 1;
            arr[0, 7] = 9;
            arr[0, 8] = 1;
            arr[1, 0] = 1;
            arr[1, 1] = 10;
            arr[1, 2] = 0;
            arr[1, 3] = 0;
            arr[1, 4] = 10;
            arr[1, 5] = 1; // Заполнение поля лабиринта
            arr[1, 6] = 1;
            arr[1, 7] = 0;
            arr[1, 8] = 1;
            arr[2, 0] = 1;
            arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
            arr[2, 2] = 1;
            arr[2, 3] = 1;
            arr[2, 4] = 8;
            arr[2, 5] = 0;
            arr[2, 6] = 1;
            arr[2, 7] = 0;
            arr[2, 8] = 1;
            arr[3, 0] = 1;
            arr[3, 1] = 0;
            arr[3, 2] = 1;
            arr[3, 3] = 0;
            arr[3, 4] = 0;
            arr[3, 5] = 1;
            arr[3, 6] = 1;
            arr[3, 7] = 0;
            arr[3, 8] = 1;
            arr[4, 0] = 1;
            arr[4, 1] = 1;
            arr[4, 2] = 1;
            arr[4, 3] = 0;
            arr[4, 4] = 1;
            arr[4, 5] = 1;
            arr[4, 6] = 1;
            arr[4, 7] = 1;
            arr[4, 8] = 1;
            arr[5, 0] = 1;
            arr[5, 1] = 1;
            arr[5, 2] = 0;
            arr[5, 3] = 0;
            arr[5, 4] = 10;
            arr[5, 5] = 0;
            arr[5, 6] = 1;
            arr[5, 7] = 0;
            arr[5, 8] = 1;
            arr[6, 0] = 1;
            arr[6, 1] = 0;
            arr[6, 2] = 0;
            arr[6, 3] = 1;
            arr[6, 4] = 8;
            arr[6, 5] = 1;
            arr[6, 6] = 1;
            arr[6, 7] = 0;
            arr[6, 8] = 1;
            arr[7, 0] = 1;
            arr[7, 1] = 1;
            arr[7, 2] = 0;
            arr[7, 3] = 1;
            arr[7, 4] = 0;
            arr[7, 5] = 0;
            arr[7, 6] = 0;
            arr[7, 7] = 0;
            arr[7, 8] = 1;
            arr[8, 0] = 1;
            arr[8, 1] = 1;
            arr[8, 2] = 1;
            arr[8, 3] = 1;
            arr[8, 4] = 1;
            arr[8, 5] = 2;
            arr[8, 6] = 1;
            arr[8, 7] = 1;
            arr[8, 8] = 1;

            start1 = 8;
            start2 = 5;
            arrPress[0, 0] = 5;
            arrPress[0, 1] = 4;
            arrPress[1, 0] = 1;
            arrPress[1, 1] = 4;
            arrPress[2, 0] = 1;
            arrPress[2, 1] = 1;
            countPress = 3;
            arrdoor[0, 0] = 7;
            arrdoor[0, 1] = 3;
            arrdoor[0, 2] = -1;
            arrdoor[0, 3] = -1;
            arrOpen[0, 0] = false;
            arrOpen[0, 1] = false;
            arrdoor[1, 0] = 1;
            arrdoor[1, 1] = 5;
            arrdoor[1, 2] = -1;
            arrdoor[1, 3] = -1;
            arrOpen[1, 0] = false;
            arrOpen[1, 1] = false;
            arrdoor[2, 0] = 4;
            arrdoor[2, 1] = 7;
            arrdoor[2, 2] = -1;
            arrdoor[2, 3] = -1;
            arrOpen[2, 0] = false;
            arrOpen[2, 1] = false;

            win = false;
            Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur2.Background = Brushes.Brown;
            Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            SetLab();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            RefreshB.Visibility = Visibility.Hidden;

            Up.IsEnabled = true;
            Down.IsEnabled = true;
            Left.IsEnabled = true;
            Right.IsEnabled = true;
            block = false;
            urNum = 3;
            prBar.BorderBrush = Brushes.Green;
            prBarVal = 50;
            prBarSet = true;

            arr[0, 0] = 1;
            arr[0, 1] = 9;
            arr[0, 2] = 1;
            arr[0, 3] = 1;
            arr[0, 4] = 1;
            arr[0, 5] = 1;
            arr[0, 6] = 1;
            arr[0, 7] = 1;
            arr[0, 8] = 1;
            arr[1, 0] = 1;
            arr[1, 1] = 0;
            arr[1, 2] = 1;
            arr[1, 3] = 0;
            arr[1, 4] = 0;
            arr[1, 5] = 0; // Заполнение поля лабиринта
            arr[1, 6] = 1;
            arr[1, 7] = 1;
            arr[1, 8] = 1;
            arr[2, 0] = 1;
            arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
            arr[2, 2] = 1;
            arr[2, 3] = 1;
            arr[2, 4] = 1;
            arr[2, 5] = 0;
            arr[2, 6] = 0;
            arr[2, 7] = 0;
            arr[2, 8] = 1;
            arr[3, 0] = 1;
            arr[3, 1] = 0;
            arr[3, 2] = 1;
            arr[3, 3] = 0;
            arr[3, 4] = 1;
            arr[3, 5] = 0;
            arr[3, 6] = 8;
            arr[3, 7] = 0;
            arr[3, 8] = 1;
            arr[4, 0] = 1;
            arr[4, 1] = 1;
            arr[4, 2] = 1;
            arr[4, 3] = 0;
            arr[4, 4] = 1;
            arr[4, 5] = 1;
            arr[4, 6] = 10;
            arr[4, 7] = 1;
            arr[4, 8] = 1;
            arr[5, 0] = 1;
            arr[5, 1] = 10;
            arr[5, 2] = 8;
            arr[5, 3] = 0;
            arr[5, 4] = 1;
            arr[5, 5] = 1;
            arr[5, 6] = 1;
            arr[5, 7] = 1;
            arr[5, 8] = 1;
            arr[6, 0] = 1;
            arr[6, 1] = 0;
            arr[6, 2] = 1;
            arr[6, 3] = 0;
            arr[6, 4] = 0;
            arr[6, 5] = 0;
            arr[6, 6] = 1;
            arr[6, 7] = 0;
            arr[6, 8] = 1;
            arr[7, 0] = 1;
            arr[7, 1] = 10;
            arr[7, 2] = 1;
            arr[7, 3] = 0;
            arr[7, 4] = 0;
            arr[7, 5] = 0;
            arr[7, 6] = 8;
            arr[7, 7] = 0;
            arr[7, 8] = 1;
            arr[8, 0] = 1;
            arr[8, 1] = 1;
            arr[8, 2] = 1;
            arr[8, 3] = 1;
            arr[8, 4] = 1;
            arr[8, 5] = 1;
            arr[8, 6] = 1;
            arr[8, 7] = 2;
            arr[8, 8] = 1;
            arrPress[0, 0] = 5;
            arrPress[0, 1] = 1;
            arrdoor[0, 0] = 7;
            arrdoor[0, 1] = 2;
            arrdoor[0, 2] = -1;
            arrdoor[0, 3] = -1;
            arrOpen[0, 1] = false;
            arrPress[1, 0] = 7;
            arrPress[1, 1] = 1;
            arrdoor[1, 0] = 2;
            arrdoor[1, 1] = 3;
            arrdoor[1, 2] = -1;
            arrdoor[1, 3] = -1;
            arrOpen[1, 0] = false;
            arrPress[2, 0] = 4;
            arrPress[2, 1] = 6;
            arrdoor[2, 0] = 3;
            arrdoor[2, 1] = 2;
            arrdoor[2, 2] = -1;
            arrdoor[2, 3] = -1;
            arrOpen[2, 0] = false;
            countPress = 3;


            start1 = 8;
            start2 = 7;
            win = false;
            Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur3.Background = Brushes.Brown;
            Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            SetLab();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            RefreshB.Visibility = Visibility.Hidden;

            Up.IsEnabled = true;
            Down.IsEnabled = true;
            Left.IsEnabled = true;
            Right.IsEnabled = true;
            block = false;
            urNum = 4;
            prBar.BorderBrush = Brushes.Green;
            prBarVal = 75;
            prBarSet = true;
            arr[0, 0] = 1;
            arr[0, 1] = 1;
            arr[0, 2] = 1;
            arr[0, 3] = 1;
            arr[0, 4] = 9;
            arr[0, 5] = 1;
            arr[0, 6] = 1;
            arr[0, 7] = 1;
            arr[0, 8] = 1;
            arr[1, 0] = 1;
            arr[1, 1] = 1;
            arr[1, 2] = 1;
            arr[1, 3] = 0;
            arr[1, 4] = 1;
            arr[1, 5] = 1; // Заполнение поля лабиринта
            arr[1, 6] = 0;
            arr[1, 7] = 1;
            arr[1, 8] = 1;
            arr[2, 0] = 1;
            arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
            arr[2, 2] = 1;
            arr[2, 3] = 1;
            arr[2, 4] = 1;
            arr[2, 5] = 1;
            arr[2, 6] = 0;
            arr[2, 7] = 1;
            arr[2, 8] = 1;
            arr[3, 0] = 1;
            arr[3, 1] = 0;
            arr[3, 2] = 0;
            arr[3, 3] = 0;
            arr[3, 4] = 0;
            arr[3, 5] = 0;
            arr[3, 6] = 8;
            arr[3, 7] = 10;
            arr[3, 8] = 1;
            arr[4, 0] = 1;
            arr[4, 1] = 8;
            arr[4, 2] = 1;
            arr[4, 3] = 1;
            arr[4, 4] = 1;
            arr[4, 5] = 1;
            arr[4, 6] = 0;
            arr[4, 7] = 1;
            arr[4, 8] = 1;
            arr[5, 0] = 1;
            arr[5, 1] = 0;
            arr[5, 2] = 0;
            arr[5, 3] = 0;
            arr[5, 4] = 1;
            arr[5, 5] = 1;
            arr[5, 6] = 1;
            arr[5, 7] = 1;
            arr[5, 8] = 1;
            arr[6, 0] = 1;
            arr[6, 1] = 0;
            arr[6, 2] = 1;
            arr[6, 3] = 0;
            arr[6, 4] = 0;
            arr[6, 5] = 0;
            arr[6, 6] = 1;
            arr[6, 7] = 0;
            arr[6, 8] = 1;
            arr[7, 0] = 1;
            arr[7, 1] = 10;
            arr[7, 2] = 1;
            arr[7, 3] = 0;
            arr[7, 4] = 1;
            arr[7, 5] = 0;
            arr[7, 6] = 0;
            arr[7, 7] = 0;
            arr[7, 8] = 1;
            arr[8, 0] = 1;
            arr[8, 1] = 1;
            arr[8, 2] = 1;
            arr[8, 3] = 1;
            arr[8, 4] = 1;
            arr[8, 5] = 1;
            arr[8, 6] = 2;
            arr[8, 7] = 1;
            arr[8, 8] = 1;
            arrPress[0, 0] = 2;
            arrPress[0, 1] = 1;
            arrdoor[0, 0] = 1;
            arrdoor[0, 1] = 1;
            arrdoor[0, 2] = -1;
            arrdoor[0, 3] = -1;
            arrOpen[0, 0] = false;
            arrPress[1, 0] = 3;
            arrPress[1, 1] = 7;
            arrdoor[1, 0] = 1;
            arrdoor[1, 1] = 2;
            arrdoor[1, 2] = 2;
            arrdoor[1, 3] = 3;
            arrOpen[1, 0] = false;
            arrOpen[1, 1] = false;
            arrPress[2, 0] = 7;
            arrPress[2, 1] = 1;
            arrdoor[2, 0] = 1;
            arrdoor[2, 1] = 4;
            arrdoor[2, 2] = -1;
            arrdoor[2, 3] = -1;
            arrOpen[2, 0] = false;
            arrOpen[2, 1] = false;
            win = false;
            start1 = 8;
            start2 = 6;
            Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur4.Background = Brushes.Brown;
            Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
            SetLab();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (urNum == 1)
            {
                if (ur1)
                {
                    arr[0, 0] = 1;
                    arr[0, 1] = 9;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 1;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 1;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 0;
                    arr[1, 2] = 1;
                    arr[1, 3] = 1;
                    arr[1, 4] = 1;
                    arr[1, 5] = 0; // Заполнение поля лабиринта
                    arr[1, 6] = 0;
                    arr[1, 7] = 0;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт, 8 - ящик, 10 - кнопка
                    arr[2, 2] = 0;
                    arr[2, 3] = 0;
                    arr[2, 4] = 0;
                    arr[2, 5] = 0;
                    arr[2, 6] = 1;
                    arr[2, 7] = 0;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 1;
                    arr[3, 3] = 1;
                    arr[3, 4] = 8;
                    arr[3, 5] = 1;
                    arr[3, 6] = 1;
                    arr[3, 7] = 0;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 0;
                    arr[4, 2] = 1;
                    arr[4, 3] = 0;
                    arr[4, 4] = 0;
                    arr[4, 5] = 0;
                    arr[4, 6] = 1;
                    arr[4, 7] = 0;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 1;
                    arr[5, 2] = 1;
                    arr[5, 3] = 0;
                    arr[5, 4] = 1;
                    arr[5, 5] = 0;
                    arr[5, 6] = 1;
                    arr[5, 7] = 1;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 1;
                    arr[6, 2] = 1;
                    arr[6, 3] = 1;
                    arr[6, 4] = 1;
                    arr[6, 5] = 0;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 1;
                    arr[7, 2] = 1;
                    arr[7, 3] = 1;
                    arr[7, 4] = 0;
                    arr[7, 5] = 0;
                    arr[7, 6] = 0;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 2;
                    arr[8, 5] = 1;
                    arr[8, 6] = 1;
                    arr[8, 7] = 1;
                    arr[8, 8] = 1;

                    arrPress[0, 0] = 3;
                    arrPress[0, 1] = 4;
                    arrPress[1, 0] = 2;
                    arrPress[1, 1] = 1;
                    countPress = 2;
                    arrdoor[0, 0] = 4;
                    arrdoor[0, 1] = 6;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrdoor[1, 0] = 1;
                    arrdoor[1, 1] = 2;
                    arrdoor[1, 2] = -1;
                    arrdoor[1, 3] = -1;
                    arrOpen[0, 0] = true;
                    arrOpen[0, 1] = false;
                    arrOpen[1, 0] = false;
                    arrOpen[1, 1] = false;
                    start1 = 8;
                    start2 = 4;
                    prBar.Value = 0;
                    Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur1.Background = Brushes.Brown;
                    Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    SetLab();
                }
            }
            else if (urNum == 2)
            {
                if (ur2)
                {
                    RefreshB.Visibility = Visibility.Hidden;

                    Up.IsEnabled = true;
                    Down.IsEnabled = true;
                    Left.IsEnabled = true;
                    Right.IsEnabled = true;
                    block = false;
                    urNum = 2;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 25;
                    prBarSet = true;
                    arr[0, 0] = 1;
                    arr[0, 1] = 1;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 1;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 9;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 10;
                    arr[1, 2] = 0;
                    arr[1, 3] = 0;
                    arr[1, 4] = 10;
                    arr[1, 5] = 1; // Заполнение поля лабиринта
                    arr[1, 6] = 1;
                    arr[1, 7] = 0;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[2, 4] = 8;
                    arr[2, 5] = 0;
                    arr[2, 6] = 1;
                    arr[2, 7] = 0;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 1;
                    arr[3, 3] = 0;
                    arr[3, 4] = 0;
                    arr[3, 5] = 1;
                    arr[3, 6] = 1;
                    arr[3, 7] = 0;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 1;
                    arr[4, 2] = 1;
                    arr[4, 3] = 0;
                    arr[4, 4] = 1;
                    arr[4, 5] = 1;
                    arr[4, 6] = 1;
                    arr[4, 7] = 1;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 1;
                    arr[5, 2] = 0;
                    arr[5, 3] = 0;
                    arr[5, 4] = 10;
                    arr[5, 5] = 0;
                    arr[5, 6] = 1;
                    arr[5, 7] = 0;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 0;
                    arr[6, 2] = 0;
                    arr[6, 3] = 1;
                    arr[6, 4] = 8;
                    arr[6, 5] = 1;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 1;
                    arr[7, 2] = 0;
                    arr[7, 3] = 1;
                    arr[7, 4] = 0;
                    arr[7, 5] = 0;
                    arr[7, 6] = 0;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 1;
                    arr[8, 5] = 2;
                    arr[8, 6] = 1;
                    arr[8, 7] = 1;
                    arr[8, 8] = 1;

                    start1 = 8;
                    start2 = 5;
                    arrPress[0, 0] = 5;
                    arrPress[0, 1] = 4;
                    arrPress[1, 0] = 1;
                    arrPress[1, 1] = 4;
                    arrPress[2, 0] = 1;
                    arrPress[2, 1] = 1;
                    countPress = 3;
                    arrdoor[0, 0] = 7;
                    arrdoor[0, 1] = 3;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrOpen[0, 0] = false;
                    arrOpen[0, 1] = false;
                    arrdoor[1, 0] = 1;
                    arrdoor[1, 1] = 5;
                    arrdoor[1, 2] = -1;
                    arrdoor[1, 3] = -1;
                    arrOpen[1, 0] = false;
                    arrOpen[1, 1] = false;
                    arrdoor[2, 0] = 4;
                    arrdoor[2, 1] = 7;
                    arrdoor[2, 2] = -1;
                    arrdoor[2, 3] = -1;
                    arrOpen[2, 0] = false;
                    arrOpen[2, 1] = false;
                    win = false;
                    Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur2.Background = Brushes.Brown;
                    Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    SetLab();
                }
            }
            else if (urNum == 3)
            {
                if (ur3)
                {
                    RefreshB.Visibility = Visibility.Hidden;

                    Up.IsEnabled = true;
                    Down.IsEnabled = true;
                    Left.IsEnabled = true;
                    Right.IsEnabled = true;
                    block = false;
                    urNum = 3;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 50;
                    prBarSet = true;
                    arr[0, 0] = 1;
                    arr[0, 1] = 9;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 1;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 1;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 0;
                    arr[1, 2] = 1;
                    arr[1, 3] = 0;
                    arr[1, 4] = 0;
                    arr[1, 5] = 0; // Заполнение поля лабиринта
                    arr[1, 6] = 1;
                    arr[1, 7] = 1;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 0; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[2, 4] = 1;
                    arr[2, 5] = 0;
                    arr[2, 6] = 0;
                    arr[2, 7] = 0;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 1;
                    arr[3, 3] = 0;
                    arr[3, 4] = 1;
                    arr[3, 5] = 0;
                    arr[3, 6] = 8;
                    arr[3, 7] = 0;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 1;
                    arr[4, 2] = 1;
                    arr[4, 3] = 0;
                    arr[4, 4] = 1;
                    arr[4, 5] = 1;
                    arr[4, 6] = 10;
                    arr[4, 7] = 1;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 10;
                    arr[5, 2] = 8;
                    arr[5, 3] = 0;
                    arr[5, 4] = 1;
                    arr[5, 5] = 1;
                    arr[5, 6] = 1;
                    arr[5, 7] = 1;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 0;
                    arr[6, 2] = 1;
                    arr[6, 3] = 0;
                    arr[6, 4] = 0;
                    arr[6, 5] = 0;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 10;
                    arr[7, 2] = 1;
                    arr[7, 3] = 0;
                    arr[7, 4] = 0;
                    arr[7, 5] = 0;
                    arr[7, 6] = 8;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 1;
                    arr[8, 5] = 1;
                    arr[8, 6] = 1;
                    arr[8, 7] = 2;
                    arr[8, 8] = 1;
                    arrPress[0, 0] = 5;
                    arrPress[0, 1] = 1;
                    arrdoor[0, 0] = 7;
                    arrdoor[0, 1] = 2;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrOpen[0, 1] = false;
                    arrPress[1, 0] = 7;
                    arrPress[1, 1] = 1;
                    arrdoor[1, 0] = 2;
                    arrdoor[1, 1] = 3;
                    arrdoor[1, 2] = -1;
                    arrdoor[1, 3] = -1;
                    arrOpen[1, 0] = false;
                    arrPress[2, 0] = 4;
                    arrPress[2, 1] = 6;
                    arrdoor[2, 0] = 3;
                    arrdoor[2, 1] = 2;
                    arrdoor[2, 2] = -1;
                    arrdoor[2, 3] = -1;
                    arrOpen[2, 0] = false;
                    countPress = 3;


                    start1 = 8;
                    start2 = 7;
                    win = false;
                    Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur3.Background = Brushes.Brown;
                    Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    SetLab();
                }
            }
            else if (urNum == 4)
            {
                if (ur4)
                {
                    RefreshB.Visibility = Visibility.Hidden;

                    Up.IsEnabled = true;
                    Down.IsEnabled = true;
                    Left.IsEnabled = true;
                    Right.IsEnabled = true;
                    block = false;
                    urNum = 4;
                    prBar.BorderBrush = Brushes.Green;
                    prBarVal = 75;
                    prBarSet = true;
                    arr[0, 0] = 1;
                    arr[0, 1] = 1;
                    arr[0, 2] = 1;
                    arr[0, 3] = 1;
                    arr[0, 4] = 9;
                    arr[0, 5] = 1;
                    arr[0, 6] = 1;
                    arr[0, 7] = 1;
                    arr[0, 8] = 1;
                    arr[1, 0] = 1;
                    arr[1, 1] = 1;
                    arr[1, 2] = 1;
                    arr[1, 3] = 0;
                    arr[1, 4] = 1;
                    arr[1, 5] = 1; // Заполнение поля лабиринта
                    arr[1, 6] = 0;
                    arr[1, 7] = 1;
                    arr[1, 8] = 1;
                    arr[2, 0] = 1;
                    arr[2, 1] = 10; // 1 - стена, 0 - свободная ячейка, 2 - игрок, 9 - финиш, -1 - старт
                    arr[2, 2] = 1;
                    arr[2, 3] = 1;
                    arr[2, 4] = 1;
                    arr[2, 5] = 1;
                    arr[2, 6] = 0;
                    arr[2, 7] = 1;
                    arr[2, 8] = 1;
                    arr[3, 0] = 1;
                    arr[3, 1] = 0;
                    arr[3, 2] = 0;
                    arr[3, 3] = 0;
                    arr[3, 4] = 0;
                    arr[3, 5] = 0;
                    arr[3, 6] = 8;
                    arr[3, 7] = 10;
                    arr[3, 8] = 1;
                    arr[4, 0] = 1;
                    arr[4, 1] = 8;
                    arr[4, 2] = 1;
                    arr[4, 3] = 1;
                    arr[4, 4] = 1;
                    arr[4, 5] = 1;
                    arr[4, 6] = 0;
                    arr[4, 7] = 1;
                    arr[4, 8] = 1;
                    arr[5, 0] = 1;
                    arr[5, 1] = 0;
                    arr[5, 2] = 0;
                    arr[5, 3] = 0;
                    arr[5, 4] = 1;
                    arr[5, 5] = 1;
                    arr[5, 6] = 1;
                    arr[5, 7] = 1;
                    arr[5, 8] = 1;
                    arr[6, 0] = 1;
                    arr[6, 1] = 0;
                    arr[6, 2] = 1;
                    arr[6, 3] = 0;
                    arr[6, 4] = 0;
                    arr[6, 5] = 0;
                    arr[6, 6] = 1;
                    arr[6, 7] = 0;
                    arr[6, 8] = 1;
                    arr[7, 0] = 1;
                    arr[7, 1] = 10;
                    arr[7, 2] = 1;
                    arr[7, 3] = 0;
                    arr[7, 4] = 1;
                    arr[7, 5] = 0;
                    arr[7, 6] = 0;
                    arr[7, 7] = 0;
                    arr[7, 8] = 1;
                    arr[8, 0] = 1;
                    arr[8, 1] = 1;
                    arr[8, 2] = 1;
                    arr[8, 3] = 1;
                    arr[8, 4] = 1;
                    arr[8, 5] = 1;
                    arr[8, 6] = 2;
                    arr[8, 7] = 1;
                    arr[8, 8] = 1;
                    arrPress[0, 0] = 2;
                    arrPress[0, 1] = 1;
                    arrdoor[0, 0] = 1;
                    arrdoor[0, 1] = 1;
                    arrdoor[0, 2] = -1;
                    arrdoor[0, 3] = -1;
                    arrOpen[0, 0] = false;
                    arrPress[1, 0] = 3;
                    arrPress[1, 1] = 7;
                    arrdoor[1, 0] = 1;
                    arrdoor[1, 1] = 2;
                    arrdoor[1, 2] = 2;
                    arrdoor[1, 3] = 3;
                    arrOpen[1, 0] = false;
                    arrOpen[1, 1] = false;
                    arrPress[2, 0] = 7;
                    arrPress[2, 1] = 1;
                    arrdoor[2, 0] = 1;
                    arrdoor[2, 1] = 4;
                    arrdoor[2, 2] = -1;
                    arrdoor[2, 3] = -1;
                    arrOpen[2, 0] = false;
                    arrOpen[2, 1] = false;
                    win = false;
                    start1 = 8;
                    start2 = 6;
                    Ur2.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur4.Background = Brushes.Brown;
                    Ur3.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    Ur1.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFF16A6A");
                    SetLab();
                }
            }
            SetLab();
        }

        
    }
}
