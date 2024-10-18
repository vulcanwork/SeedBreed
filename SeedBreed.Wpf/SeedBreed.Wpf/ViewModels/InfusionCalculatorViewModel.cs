using Prism.Commands;
using Prism.Mvvm;
using SeedBreed.Core;
using SeedBreed.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeedBreed.Wpf.ViewModels;

public class InfusionCalculatorViewModel : ViewModelBase
{

    public InfusionCalculatorViewModel(Api api, Seedlings seedlings) : base(api, seedlings)
    {
        Calculator = new();
        VesicleString = new();
        foreach (var vesicle in Calculator.Vesicles)
        {
            VesicleString.Add(vesicle.Key);
        }
    }
    private ObservableCollection<string> _vesicleString;
    private string _selectedVesicle;
    private decimal _tempDecimal;
    private InfusionCalculator _calculator;
    public string SelectedVesicle
    {
        get => _selectedVesicle;
        set
        {
            SetProperty(ref _selectedVesicle, value);
            var t = Calculator.Vesicles[_selectedVesicle];
            Calculator.VesicleYield = t;
        }
    }
    public InfusionCalculator Calculator
    {
        get => _calculator;
        set => SetProperty(ref _calculator, value);
    }
    public ObservableCollection<string> VesicleString
    {
        get => _vesicleString;
        set => SetProperty(ref _vesicleString, value);
    }
}
