using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SeedBreed.Core;

using SeedBreed.Data.Models;
using SeedBreed.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedBreed.Wpf.ViewModels;

public class SeedViewModel : ViewModelBase
{
    public SeedViewModel(Api api, Seedlings seedlings) : base(api, seedlings) => _ = GetData();

    private SeedModel _selectedSeed = new();
    public override async Task GetData() => Seedlings.Seeds = await _api.GetSeeds();
    public override async Task Save()
    {
        try
        {
            await _api.SaveSeed(Seedlings.Seeds);

        }
        catch (Exception e)
        {

            _api.Message = $"Error saving Batch: {e.Message}";
        }
        await GetData();
    }
    public override async Task Delete()
    {
        if (SelectedSeed == null || SelectedSeed.SeedId == 0)
        {
            _api.Message = "No Batch selected";
            return;
        }
        try
        {
            await _api.DeleteItem(SelectedSeed);
        }
        catch (Exception e)
        {
            _api.Message = $"Error deleting Batch: {e.Message}";
        }
        await GetData();
    }

    public SeedModel SelectedSeed
    {
        get => _selectedSeed;
        set => SetProperty(ref _selectedSeed, value);
    }
}
