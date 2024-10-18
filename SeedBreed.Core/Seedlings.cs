using SeedBreed.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeedBreed.Core;
public class Seedlings : SchemaBase
{
    private List<BatchModel> _batches = new();
    private List<CloneModel> _clones = new();
    private List<GerminateModel> _germinates = new();
    private List<PlantModel> _plants = new();
    private List<SeedModel> _seeds = new();
    private List<SourceModel> _source = new();

    public List<BatchModel> Batches
    {
        get => _batches;
        set
        {
            _batches = value;
            NotifyPropertyChanged();
        }
    }
    public List<CloneModel> Clones
    {
        get => _clones;
        set
        {
            _clones = value;
            NotifyPropertyChanged();
        }
    }
    public List<GerminateModel> Germinates
    {
        get => _germinates;
        set
        {
            _germinates = value;
            NotifyPropertyChanged();
        }
    }
    public List<PlantModel> Plants
    {
        get => _plants;
        set
        {
            _plants = value;
            NotifyPropertyChanged();
        }
    }
    public List<SeedModel> Seeds
    {
        get => _seeds;
        set
        {
            _seeds = value;
            NotifyPropertyChanged();
        }
    }
    public List<SourceModel> Source
    {
        get => _source;
        set
        {
            _source = value;
            NotifyPropertyChanged();
        }
    }
}
