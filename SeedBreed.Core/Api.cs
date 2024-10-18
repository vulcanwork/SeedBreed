using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SeedBreed.Data.Models;
using SeedBreed.Data.Transactions;

namespace SeedBreed.Core;
public class Api : INotifyPropertyChanged
{
    private string _message;

    public IDataAccess DataAccess { get; set; }
    public Api()
    {
        var connection = "Data Source=192.168.69.101;Initial Catalog=SeedBreed;User ID=johnv;Password=Hyder1951;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        DataAccess = new SqlAccess(connection);
    }
    public Api(string connectionString) => DataAccess = new SqlAccess(connectionString);

    public string Message
    {
        get => _message; set
        {
            _message = value;
            NotifyPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    public async Task DeleteItem<T>(T item) where T : IQuery => await DataAccess.DeleteItem(item);
    public async Task<List<BatchModel>> GetBatches()
    {

        var batches = await DataAccess.GetBatch();
        foreach (var batch in batches)
        {
            if (batch.PurchaseDate < DateTime.Parse("1/1/2022"))
            {
                batch.PurchaseDate = DateTime.Parse("1/1/2022");
            }
        }
        return batches;
    }
    public async Task<List<GerminateModel>> GetGerminates()
    {
        try
        {
            return await DataAccess.GetGerminates();

        }
        catch (Exception e)
        {

            Message = $"Error GetGerminates: {e.Message}";
            return new List<GerminateModel>();
        }
    }
    public async Task<List<PlantModel>> GetPlants()
    {
        try
        {
            return await DataAccess.GetPlants();

        }
        catch (Exception e)
        {

            Message = $"Error GetPlants: {e.Message}";
            return new List<PlantModel>();
        }
    }
    public async Task<List<SourceModel>> GetSource()
    {
        try
        {
            return await DataAccess.GetSource();

        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<List<SeedModel>> GetSeeds() => await DataAccess.GetSeeds();
    public async Task SaveBatch(List<BatchModel> batches)
    {
        foreach (var batch in batches)
        {
            if (batch.Edited)
                await DataAccess.SaveBatch(batch);

        }
    }

    public async Task SaveGerminate(List<GerminateModel> germinates)
    {
        foreach (var germinate in germinates)
        {
            if (germinate.Edited)
            {
                await DataAccess.SaveGerminate(germinate);
            }
        }
    }

    public async Task SavePlant(List<PlantModel> plants)
    {
        foreach (var plant in plants)
        {
            plant.HarvestDate = plant.PlantId < 1 ? DateTime.Parse("1-1-1800") : plant.HarvestDate;
            await DataAccess.SavePlant(plant);

        }
    }

    public async Task SaveSeed(List<SeedModel> seeds)
    {
        foreach (var seed in seeds)
        {
            if (seed.Edited)
                await DataAccess.SaveSeed(seed);
        }
    }

    public async Task SaveSource(SourceModel source) => await DataAccess.SaveSource(source);
    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
