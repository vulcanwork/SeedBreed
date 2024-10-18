using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SeedBreed.Core;
using SeedBreed.Data.Models;
using SeedBreed.Wpf.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SeedBreed.Wpf.ViewModels;

public class YounglingsViewModel : ViewModelBase
{
    //private int _selectedBatchId;
    //private int _selectedSeedId;
    private bool _createNew;
    private int _batchIndex;
    private ObservableCollection<ComboSelector> _batchList = new();
    private CloneModel _selectedClone = new();
    private List<string> _seedList = new();
    //private int _seedIndex;
    public YounglingsViewModel(Api api, Seedlings seedlings) : base(api, seedlings) => _ = GetData();

    private GerminateModel _selectedBatch = new();
    public override async Task GetData() => Seedlings.Germinates = await _api.GetGerminates();
    public override async Task Save()
    {

        try
        {
            await _api.SaveGerminate(Seedlings.Germinates);
        }
        catch (Exception e)
        {

            _api.Message = $"Error saving Batch: {e.Message}";
        }
        await GetData();

    }
    public override async Task Delete()
    {
        if (SelectedGerminate == null || SelectedGerminate.GerminateId == 0)
        {
            _api.Message = "No germinate selected";
            return;
        }
        try
        {
            await _api.DeleteItem(SelectedGerminate);

        }
        catch (Exception)
        {

            _api.Message = "Error deleting germinate";
        }
        await GetData();
    }
    //public int BatchIndex
    //{
    //    get => _batchIndex;
    //    set
    //    {
    //        SetProperty(ref _batchIndex, value);
    //        if (value > 0)
    //        {
    //            _selectedBatchId = int.Parse(BatchList[value][..BatchList[value].IndexOf(" ")]);
    //        }
    //    }
    //}
    //public int SeedIndex
    //{
    //    get => _seedIndex;
    //    set
    //    {
    //        SetProperty(ref _seedIndex, value);
    //        if (value > 0)
    //        {
    //            _selectedSeedId = int.Parse(SeedList[value][..SeedList[value].IndexOf(" ")]);
    //        }
    //    }
    //}
    public bool CreateNew
    {
        get => _createNew;
        set => SetProperty(ref _createNew, value);
    }
    public ObservableCollection<ComboSelector> BatchList
    {
        get => _batchList;
        set => SetProperty(ref _batchList, value);
    }
    public List<string> SeedList
    {
        get => _seedList;
        set => SetProperty(ref _seedList, value);
    }
    public CloneModel SelectedClone
    {
        get => _selectedClone;
        set => SetProperty(ref _selectedClone, value);
    }
    public GerminateModel SelectedGerminate
    {
        get => _selectedBatch;
        set
        {
            if (_selectedBatch is not null && value != _selectedBatch)
            {
                _selectedBatch.BatchId = BatchList.First(x => x.Index == _selectedBatch.SelectedIndex).Id;
            }
            SetProperty(ref _selectedBatch, value);//if (value is null) return;//BatchIndex = BatchList.IndexOf($"{SelectedGerminate.BatchId} {SelectedGerminate.Strain} Qty:{SelectedGerminate.QuantityRemaining}");
        }
    }
    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
        PopulateDropDown();
    }

    private void PopulateDropDown()
    {

        if (Seedlings.Batches.Count + 1 != BatchList.Count)
        {
            BatchList = new();
            BatchList.Add(new ComboSelector { });
            Seedlings.Batches.Sort();
            var i = 1;
            foreach (var batch in Seedlings.Batches)
            {
                if (batch.QuantityRemaining == 0) continue;
                BatchList.Add(new ComboSelector { Name = $"{batch.Strain} Qty:{batch.QuantityRemaining}", Id = batch.BatchId, Index = i });
                i++;
            }
        }
        if (Seedlings.Seeds.Count + 1 != SeedList.Count)
        {
            SeedList = new();
            SeedList.Add("");
            Seedlings.Seeds.Sort();
            foreach (var seed in Seedlings.Seeds)
            {

                SeedList.Add($"{seed.SeedId} {seed.Strain}");
            }
        }
    }
}