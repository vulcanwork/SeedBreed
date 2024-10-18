using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeedBreed.Core;
public class InfusionCalculator : INotifyPropertyChanged
{
    public InfusionCalculator() => GramsCannabis = 5;
    public int GramsCannabis
    {
        get => _gramsCannabis;
        set
        {
            _gramsCannabis = value;
            NotifyPropertyChanged();
            MgThcInfused = CalculateInfusedThc();
            MgPerMlThc = CalculateMgMlThc();
        }
    }
    public int PercentThc
    {
        get => _percentThc;
        set
        {
            _percentThc = value;
            NotifyPropertyChanged();
            MgThcInfused = CalculateInfusedThc();
        }
    }
    public int PercentCbd
    {
        get => _percentCbd;
        set
        {
            _percentCbd = value;
            NotifyPropertyChanged();
            MgCbdInfused = CalculateInfusedCbd();
        }
    }
    public int MlVesicle
    {
        get => _mlVesicle;
        set
        {
            _mlVesicle = value;
            NotifyPropertyChanged();
            MgPerMlThc = CalculateMgMlThc();
            MgPerMlCbd = CalculateMgMlCbd();

        }
    }
    public decimal VesicleYield
    {
        get => _vesicleYield;
        set
        {
            _vesicleYield = value;
            NotifyPropertyChanged();
          MgThcInfused =  CalculateInfusedThc();
          MgCbdInfused =  CalculateInfusedCbd();
        }
    }
    private decimal _postDecarboxylationYield = 0.877m;
    private decimal _vesicleYield;
    private decimal _mgThcInfused;
    private int _gramsCannabis;
    private int _percentThc;
    private int _percentCbd;
    private int _mlVesicle;
    private int _mlInfusedOilUsed;
    private int _totalServings;
    private decimal _mgCbdInfused;
    private decimal _mgCbdTotal;
    private decimal _mgThcTotal;
    private decimal _mgCbdPerServing;
    private decimal _mgThcPerServing;
    private decimal _mgPerMlCbd;
    private decimal _mgCbdInfused1;
    private decimal _mgPerMlThc;

    public event PropertyChangedEventHandler? PropertyChanged;
    public Dictionary<string, decimal> Vesicles => new Dictionary<string, decimal>
        {
            { "Avocado", .787m },
            { "Coconut", .858m },
            { "Olive", .823m },
            { "Butter", .889m },
            { "190 Proof", .950m },
            { "Bacon Fat", .667m },
            {"Grapeseed",.810m },
            {"MTC",.900m },
            {"Walnut",.830m }
        };
    public decimal MgThcInfused
    {
        get => _mgThcInfused;
        set
        {
            _mgThcInfused = value;
            NotifyPropertyChanged();
            MgPerMlThc = CalculateMgMlThc();
        }
    }

    public decimal MgPerMlThc
    {
        get => _mgPerMlThc;
        set
        {
            _mgPerMlThc = value;
            NotifyPropertyChanged();
        }
    }

    public decimal MgCbdInfused
    {
        get => _mgCbdInfused1;
        set
        {
            _mgCbdInfused1 = value;
            NotifyPropertyChanged();
            MgPerMlCbd = CalculateMgMlCbd();
        }
    }

    public decimal MgPerMlCbd
    {
        get => _mgPerMlCbd;
        set
        {
            _mgPerMlCbd = value;
            NotifyPropertyChanged();
        }
    }

    public decimal MgThcPerServing
    {
        get => _mgThcPerServing;
        set
        {
            _mgThcPerServing = value;
            NotifyPropertyChanged();
        }
    }

    public decimal MgCbdPerServing
    {
        get => _mgCbdPerServing; 
        set
        {
            _mgCbdPerServing = value;
            NotifyPropertyChanged();
        }
    }

    public decimal MgThcTotal
    {
        get => _mgThcTotal; 
        set
        {
            _mgThcTotal = value;
            NotifyPropertyChanged();
        }
    }

    public decimal MgCbdTotal
    {
        get => _mgCbdTotal; 
        set
        {
            _mgCbdTotal = value;
            NotifyPropertyChanged();
        }
    }
    public int MlInfusedOilUsed
    {
        get => _mlInfusedOilUsed;
        set
        {
            _mlInfusedOilUsed = value;
            NotifyPropertyChanged();
        }
    }
    public int TotalServings
    {
        get => _totalServings; set
        {
            _totalServings = value;
            NotifyPropertyChanged();
        }
    }

    private decimal CalculateInfusedThc() => (GramsCannabis * PercentThc * _postDecarboxylationYield * VesicleYield);

    private decimal CalculateMgMlThc() => MgThcInfused == 0 || MlVesicle == 0 ? 0 : MgThcInfused / MlVesicle;

    private decimal CalculateInfusedCbd() => (GramsCannabis * PercentCbd * _postDecarboxylationYield * VesicleYield);

    private decimal CalculateMgMlCbd() => MgCbdInfused == 0 || MlVesicle == 0 ? 0 : MgCbdInfused / MlVesicle;

    private decimal CalculateThcServing() => MgPerMlThc * MlInfusedOilUsed;

    private decimal CalculateCbdServing() => MgPerMlCbd * MlInfusedOilUsed;

    private decimal CalculateThcTotal() => MgThcPerServing * TotalServings;

    private decimal CalculateCbdTotal() => MgCbdPerServing * TotalServings;
    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

}
