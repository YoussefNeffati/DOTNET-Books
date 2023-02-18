using CommunityToolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {
        private string _bookContent;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ReadCommand { get; private set; }

        public Book CurrentBook { get; set; }
        public string BookContent
        {
            get { return _bookContent; }
            set
            {
                if (_bookContent != value)
                {
                    _bookContent = value;
                    OnPropertyChanged(nameof(BookContent));
                }
            }
        }

        public ReadBook(Book book)
        {
            CurrentBook = book;
            ReadCommand = new RelayCommand(x =>
            {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(CurrentBook);
            });
        }

        

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /* Cette classe sert juste a afficher des donnée de test dans le designer */
    class InDesignReadBook : ReadBook
    {
        public InDesignReadBook() : base(new Book() /*{ Title = "Test Book" }*/) { }
    }
}
