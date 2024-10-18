using ImTools;
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
public class PlantViewModel : ViewModelBase
{
    private List<string> _cloneList = new();
    private List<ComboSelector> _germinateList = new();
    public PlantViewModel(Api api, Seedlings seedlings) : base(api, seedlings) => _ = GetData();

    private PlantModel _selectedPlant = new();
    public override async Task GetData() => Seedlings.Plants = await _api.GetPlants();
    public override async Task Save()
    {
        ReverseComboIndex();
        //if (SelectedPlant is null) return;
        //SelectedPlant.HarvestDate = SelectedPlant.PlantId < 1 ? DateTime.Parse("1-1-1800") : SelectedPlant.HarvestDate;
        try
        {
            await _api.SavePlant(Seedlings.Plants);
        }
        catch (Exception e)
        {
            _api.Message = $"Error saving Plant: {e.Message}";
        }
        await GetData();
        PopulateDropDown();
        SetComboIndex();
    }
    public override async Task Delete()
    {
        if (SelectedPlant == null || SelectedPlant.PlantId == 0)
        {
            _api.Message = "No Plant selected";
            return;
        }
        try
        {
            await _api.DeleteItem(SelectedPlant);
        }
        catch (Exception e)
        {
            _api.Message = $"Error deleting Plant: {e.Message}";
        }
        await GetData();
    }
    public List<ComboSelector> GerminateList
    {
        get => _germinateList;
        set => SetProperty(ref _germinateList, value);
    }
    public List<string> CloneList
    {
        get => _cloneList;
        set => SetProperty(ref _cloneList, value);
    }
    public PlantModel SelectedPlant
    {
        get => _selectedPlant;
        set => SetProperty(ref _selectedPlant, value);
    }
    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
        PopulateDropDown();
        SetComboIndex();
    }
    private void ReverseComboIndex()
    {
        foreach (var plant in Seedlings.Plants)
        {
            if(plant is null)
                continue;
            plant.GerminateId = GerminateList[plant.GerminateId].Id;
        }
    }
    private void SetComboIndex()
    {
        foreach (var plant in Seedlings.Plants)
        {
            plant.GerminateId = GerminateList.FindIndex(x => x.Id == plant.GerminateId);
        }
    }

    private void PopulateDropDown()
    {
        if (Seedlings.Germinates.Count + 1 != GerminateList.Count)
        {
            GerminateList = new();
            GerminateList.Add(new ComboSelector { Index = 0 });
            Seedlings.Germinates.Sort();
            var i = 1;
            foreach (var germinate in Seedlings.Germinates)
            {
                GerminateList.Add(new ComboSelector { Id = germinate.GerminateId, Name = germinate.Strain, Index = i });
                i++;
            }
        }
        if (Seedlings.Clones.Count + 1 != CloneList.Count)
        {
            CloneList = new();
            CloneList.Add("");
            Seedlings.Source.Sort();
            foreach (var clone in Seedlings.Clones)
            {
                CloneList.Add(clone.Strain);
            }
        }
    }
}
