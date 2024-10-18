using Prism.Commands;
using Prism.Regions;
using SeedBreed.Core;
using SeedBreed.Data.Models;
using SeedBreed.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeedBreed.Wpf.ViewModels;
public class SourceViewModel : ViewModelBase
{
    private SourceModel _selectedSource = new();
    public SourceViewModel(Api api, Seedlings seedlings) : base(api, seedlings) => _ = GetData();


    public override async Task GetData() => Seedlings.Source = await _api.GetSource();
    public override async Task Save()
    {
        try
        {
            await _api.SaveSource(SelectedSource);

        }
        catch (Exception e)
        {

            _api.Message = $"Error saving Source: {e.Message}";
        }
        await GetData();
    }
    public override async Task Delete()
    {
        if (SelectedSource == null || SelectedSource.SourceId == 0)
        {
            _api.Message = "No Batch selected";
            return;
        }
        try
        {
            await _api.DeleteItem(SelectedSource);
        }
        catch (Exception e)
        {
            _api.Message = $"Error deleting Batch: {e.Message}";
        }
        await GetData();
    }


    public SourceModel SelectedSource
    {
        get => _selectedSource;
        set => SetProperty(ref _selectedSource, value);
    }
}

