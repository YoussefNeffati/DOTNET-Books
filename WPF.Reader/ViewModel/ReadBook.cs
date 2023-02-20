using CommunityToolkit.Mvvm.DependencyInjection;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.Model;
using WPF.Reader.Service;
using System;  
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Reader.ViewModel
{
    class ReadBook : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand ReadCommand { get; private set; }
        public ICommand PlayCommand { get; private set; }
        public ICommand StopCommand { get; private set; }
        public ICommand PauseCommand { get; private set; }
        public ICommand ResumeCommand { get; private set; }
        public ICommand ReadSelectedCommand { get; private set; }

        public string SelectedText { get; set; } = "";

        private string _bookContent;
        private SpeechSynthesizer _synthesizer;
        private PromptBuilder _promptBuilder;
        private bool _isPaused;

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
            
            // Initialize the SpeechSynthesizer and PromptBuilder
            _synthesizer = new SpeechSynthesizer();
            _promptBuilder = new PromptBuilder();
            PauseCommand = new RelayCommand(PauseSpeech);
            ResumeCommand = new RelayCommand(ResumeSpeech);
            ReadSelectedCommand = new RelayCommand(ReadSelected);

            // Initialize the commands
            ReadCommand = new RelayCommand(x =>
            {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(CurrentBook);
            });

            PlayCommand = new RelayCommand(x =>
            {
                // Set the voice and rate of the synthesizer
                _synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult);
                _synthesizer.Rate = 0;

                // Build the prompt with the book content
                _promptBuilder.ClearContent();
                _promptBuilder.AppendText(CurrentBook.Contenu);

                // Speak the prompt
                _synthesizer.SpeakAsync(_promptBuilder);
            });

            StopCommand = new RelayCommand(x =>
            {
                // Stop the speech
                _synthesizer.SpeakAsyncCancelAll();
            });
           
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void PauseSpeech(object parameter)
        {
            if (_synthesizer.State == SynthesizerState.Speaking)
            {
                if (!_isPaused)
                {
                    _synthesizer.Pause();
                    _isPaused = true;
                }
                else
                {
                    _synthesizer.Resume();
                    _isPaused = false;
                }
            }
        }
        public void ResumeSpeech(object parameter)
        {
            if (_synthesizer.State == SynthesizerState.Paused)
            {
                _synthesizer.Resume();
                _isPaused = false;
            }

        }
        public void ReadSelected(object parameter)
        {
            // set the voice to use for speech synthesis (optional)
            _synthesizer.SelectVoiceByHints(VoiceGender.Female);

            // speak the selected text
            _synthesizer.Speak(SelectedText);
        }
    }

    /* Cette classe sert juste a afficher des données de test dans le designer */
    class InDesignReadBook : ReadBook
    {
        public InDesignReadBook() : base(new Book() { Contenu = "Test" } /*{ Title = "Test Book" }*/) { }
    }

}
