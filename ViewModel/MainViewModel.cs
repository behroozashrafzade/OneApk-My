using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel :ObservableObject
    {

        
        public MainViewModel()
        {
            items = new ObservableCollection<string>();
        }
        [ObservableProperty]
        string text;

        [ObservableProperty] 
        ObservableCollection<string> items;

        [RelayCommand]
        void Add()
        {
            if(string.IsNullOrEmpty(text))
                return;

            items.Add(text);

            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string text)

        {
            if (items.Contains(text))

                items.Remove(text);
        }

        [RelayCommand]

        async Task Tap(string s)
        {

            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        }

    }
}
