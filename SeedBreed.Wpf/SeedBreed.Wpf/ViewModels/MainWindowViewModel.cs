using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SeedBreed.Core;
using SeedBreed.Wpf.Mvvm;
using SeedBreed.Wpf.Views;
using System;

namespace SeedBreed.Wpf.ViewModels;
public class MainWindowViewModel : RegionViewModelBase
{

    private int _index;
    private Api _api;
    public MainWindowViewModel(IRegionManager regionManager, Api api) : base(regionManager)
    {
        _api = api;
        regionManager.RegisterViewWithRegion("ContentRegion", typeof(HomeView));
        regionManager.RegisterViewWithRegion("ContentRegion", typeof(SourceView));
        regionManager.RegisterViewWithRegion("ContentRegion", typeof(SeedView));
        regionManager.RegisterViewWithRegion("ContentRegion", typeof(BatchView));
        regionManager.RegisterViewWithRegion("ContentRegion", typeof(YounglingsView));
        regionManager.RegisterViewWithRegion("ContentRegion", typeof(PlantView));
        regionManager.RegisterViewWithRegion("ContentRegion", typeof(InfusionCalculatorView));
        Index = 0;
    }
    public DelegateCommand ClearMessageCommand => new(() => Api.Message = string.Empty);
    public Api Api
    {
        get => _api;
        set => SetProperty(ref _api, value);
    }
    public int Index
    {
        get => _index;
        set
        {
            SetProperty(ref _index, value);
            UpdateRegion();
        }
    }

    private void UpdateRegion()
    {
        switch (Index)
        {
            case 0:
                RegionManager.RequestNavigate("ContentRegion", "HomeView");
                break;
            case 1:
                RegionManager.RequestNavigate("ContentRegion", "SourceView");
                break;
            case 2:
                RegionManager.RequestNavigate("ContentRegion", "SeedView");
                break;
            case 3:
                RegionManager.RequestNavigate("ContentRegion", "BatchView");
                break;
            case 4:
                RegionManager.RequestNavigate("ContentRegion", "YounglingsView");
                break;
            case 5:
                RegionManager.RequestNavigate("ContentRegion", "PlantView");
                break;
            case 6:
                RegionManager.RequestNavigate("ContentRegion", "InfusionCalculatorView");
                break;
            default:
                break;
        }
    }
}
