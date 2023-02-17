using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<Book> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;

        private Book _selectedBook;
        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
                ShowBookDetails();
            }
        }

        public ListBook()
        {
            Ioc.Default.GetRequiredService<LibraryService>().LoadAllBooks();

            ItemSelectedCommand = new RelayCommand(book => SelectedBook = (Book)book);
        }
        private void OnItemSelected(Book book)
        {
            SelectedBook = book;
        }
        private void ShowBookDetails()
        {
            if (_selectedBook != null)
            {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(_selectedBook);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
