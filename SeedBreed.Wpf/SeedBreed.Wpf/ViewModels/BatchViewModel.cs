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
public class BatchViewModel : ViewModelBase
{
    public BatchViewModel(Api api, Seedlings seedlings) : base(api, seedlings) => _ = GetData();

    private BatchModel _selectedBatch = new();
    public override async Task GetData() => Seedlings.Batches = await _api.GetBatches();
    public override async Task Save()
    {
        try
        {
            await _api.SaveBatch(Seedlings.Batches);

        }
        catch (Exception e)
        {

            _api.Message = $"Error saving Batch: {e.Message}";
        }
        await GetData();
    }
    public override async Task Delete()
    {
        if (SelectedBatch == null || SelectedBatch.BatchId == 0)
        {
            _api.Message = "No Batch selected";
            return;
        }
        try
        {
          await  _api.DeleteItem(SelectedBatch);
        }
        catch (Exception e)
        {
            _api.Message = $"Error deleting Batch: {e.Message}";
        }
        await GetData();
    }

    private List<string> _seedList = new();
    private List<string> _sourceList = new();
    public List<string> SourceList
    {
        get => _sourceList;
        set => SetProperty(ref _sourceList, value);
    }
    public List<string> SeedList
    {
        get => _seedList;
        set => SetProperty(ref _seedList, value);
    }
    public BatchModel SelectedBatch
    {
        get => _selectedBatch;
        set => SetProperty(ref _selectedBatch, value);
    }
    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
        PopulateDropDown();
    }

    private void PopulateDropDown()
    {
        if (Seedlings.Seeds.Count + 1 != SeedList.Count)
        {
            SeedList = new();
            SeedList.Add("");
            Seedlings.Seeds.Sort();
            foreach (var seed in Seedlings.Seeds)
            {
                SeedList.Add(seed.Strain);
            }
        }
        if (Seedlings.Source.Count + 1 != SourceList.Count)
        {
            SourceList = new();
            SourceList.Add("");
            Seedlings.Source.Sort();
            foreach (var source in Seedlings.Source)
            {
                SourceList.Add(source.Source);
            }
        }
    }
}
