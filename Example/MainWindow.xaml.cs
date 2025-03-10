using Microsoft.Win32;
using System.Windows;

namespace Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NumericValue = 7;
            TestNullableObject = true;
            Value = "Test";
            FilePathValue = System.Reflection.Assembly.GetExecutingAssembly().Location;
            ImagePath = "pack://application:,,,/Example;component/Resources/rjicon2.png";
            DataContext = this;
        }
        public static readonly DependencyProperty TestBooleanProperty =
           DependencyProperty.Register(
               nameof(TestBoolean),
               typeof(bool),
               typeof(MainWindow));

        public bool TestBoolean
        {
            get
            {
                return (bool)this.GetValue(TestBooleanProperty);
            }
            set
            {
                this.SetValue(TestBooleanProperty, value);
            }
        }


        public static readonly DependencyProperty TheNullableObjectProperty =
           DependencyProperty.Register(
               nameof(TheNullableObject),
               typeof(object),
               typeof(MainWindow));

        public object? TheNullableObject
        {
            get
            {
                return this.GetValue(TheNullableObjectProperty);
            }
            set
            {
                this.SetValue(TheNullableObjectProperty, value);
            }
        }


        public static readonly DependencyProperty TestNullableObjectProperty =
          DependencyProperty.Register(
              nameof(TestNullableObject),
              typeof(bool),
              typeof(MainWindow), new PropertyMetadata(OnSetTestNullableObject));

        private static void OnSetTestNullableObject(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MainWindow me)
            {
                me.TheNullableObject = me.TestNullableObject ? null : new object();
            }
        }

        public bool TestNullableObject
        {
            get
            {
                return (bool)this.GetValue(TestNullableObjectProperty);
            }
            set
            {
                this.SetValue(TestNullableObjectProperty, value);
            }
        }



        public static readonly DependencyProperty NumericValueProperty =
           DependencyProperty.Register(
               nameof(NumericValue),
               typeof(decimal),
               typeof(MainWindow));

        public decimal NumericValue
        {
            get
            {
                return (decimal)this.GetValue(NumericValueProperty);
            }
            set
            {
                this.SetValue(NumericValueProperty, value);
            }
        }


        public static readonly DependencyProperty ValueProperty =
           DependencyProperty.Register(
               nameof(Value),
               typeof(string),
               typeof(MainWindow));

        public string Value
        {
            get
            {
                return (string)this.GetValue(ValueProperty);
            }
            set
            {
                this.SetValue(ValueProperty, value);
            }
        }

        public static readonly DependencyProperty ImagePathProperty =
           DependencyProperty.Register(
               nameof(ImagePath),
               typeof(string),
               typeof(MainWindow));

        public string ImagePath
        {
            get
            {
                return (string)this.GetValue(ImagePathProperty);
            }
            set
            {
                this.SetValue(ImagePathProperty, value);
            }
        }

        public static readonly DependencyProperty ByteValueProperty =
           DependencyProperty.Register(
               nameof(ByteValue),
               typeof(long),
               typeof(MainWindow));

        public long ByteValue
        {
            get
            {
                return (long)this.GetValue(ByteValueProperty);
            }
            set
            {
                this.SetValue(ByteValueProperty, value);
            }
        }


        public static readonly DependencyProperty CurrencyValueProperty =
           DependencyProperty.Register(
               nameof(CurrencyValue),
               typeof(decimal),
               typeof(MainWindow));

        public decimal CurrencyValue
        {
            get
            {
                return (decimal)this.GetValue(CurrencyValueProperty);
            }
            set
            {
                this.SetValue(CurrencyValueProperty, value);
            }
        }




        public static readonly DependencyProperty DateValueProperty =
           DependencyProperty.Register(
               nameof(DateValue),
               typeof(DateTime),
               typeof(MainWindow));

        public DateTime DateValue
        {
            get
            {
                return (DateTime)this.GetValue(DateValueProperty);
            }
            set
            {
                this.SetValue(DateValueProperty, value);
            }
        }



        public static readonly DependencyProperty FilePathValueProperty =
           DependencyProperty.Register(
               nameof(FilePathValue),
               typeof(string),
               typeof(MainWindow));

        public string FilePathValue
        {
            get
            {
                return (string)this.GetValue(FilePathValueProperty);
            }
            set
            {
                this.SetValue(FilePathValueProperty, value);
            }
        }

        private void OnBrowseForImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog diag = new();
            diag.Title = "Select Image file";
            diag.Filter = "Image Files|*.jpg;*.gif;*.png|All Files|*.*";
            if (diag.ShowDialog().GetValueOrDefault())
            {
                ImagePath = diag.FileName;
            }
        }

        private void OnBrowseForFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog diag = new();
            diag.Title = "Select file";
            diag.Filter = "All Files|*.*";
            if (diag.ShowDialog().GetValueOrDefault())
            {
                FilePathValue = diag.FileName;
            }
        }
    }
}