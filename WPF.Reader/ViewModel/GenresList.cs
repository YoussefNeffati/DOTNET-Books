using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.DependencyInjection;
using WPF.Reader.Api;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class GenresList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<Genre> Genres => Ioc.Default.GetRequiredService<LibraryService>().Genres;



        public GenresList()
        {
            Ioc.Default.GetRequiredService<LibraryService>().LoadAllGenres();
        }



    }
}
