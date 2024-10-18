using SeedBreed.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SeedBreed.ViewModels;


internal class SourceViewModel : INotifyPropertyChanged
{



    private List<SourceModel> _sources = new();
    public List<SourceModel> Sources
    {
        get => _sources;
        set
        {
            _sources = value;
            OnPropertyChanged();

        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}