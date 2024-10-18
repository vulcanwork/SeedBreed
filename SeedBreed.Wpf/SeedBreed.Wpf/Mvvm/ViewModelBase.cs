using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SeedBreed.Core;
using SeedBreed.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeedBreed.Wpf.Mvvm;
public class ViewModelBase : BindableBase, INavigationAware
{

    protected Api _api;

    public ViewModelBase(Api api, Seedlings seedlings)
    {
        SaveNewCommand = new DelegateCommand(async () => await SaveNew());
        SaveCommand = new DelegateCommand(async () => await Save());
        DeleteCommand = new DelegateCommand(async () => await Delete());
        _api = api;
        Seedlings = seedlings;
    }

    public virtual async Task Delete()
    {
       
    }

    public Seedlings Seedlings { get; set; }
    public DelegateCommand SaveCommand { get; set; }
    public DelegateCommand SaveNewCommand { get; set; }
    public DelegateCommand DeleteCommand { get; set; }
    public virtual async Task SaveNew()
    {
    }

    public virtual async Task GetData()
    {
    }

    public virtual async Task Save()
    {

    }
    public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;

    public virtual void OnNavigatedFrom(NavigationContext navigationContext)
    {

    }
    public virtual void OnNavigatedTo(NavigationContext navigationContext) => _ = GetData();

}
