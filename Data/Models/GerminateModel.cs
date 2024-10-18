using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeedBreed.Data.Models;
public class GerminateModel : IComparable<GerminateModel>, IEditableObject, IQuery, INotifyPropertyChanged
{
    private int _germinateId;

    public static string GetQuery => "SELECT * FROM Younglings.vw_Germinate";
    public string DeleteQuery => $"DELETE Younglings.Germinate WHERE GerminateId = {GerminateId}";
    public int CompareTo(GerminateModel other) => GerminateId.CompareTo(other.GerminateId);
    public int SelectedIndex { get; set; }
    public int GerminateId
    {
        get => _germinateId;
        set
        {
            _germinateId = value;
            NotifyPropertyChanged();
        }
    }
    public DateTime GerminationDate { get; set; } = DateTime.Now;
    public bool DidNotGerminate { get; set; }
    public int BatchId { get; set; }
    public int SourceId { get; set; }
    public string Source { get; set; } = string.Empty;
    public int SeedId { get; set; }
    public string Strain { get; set; } = string.Empty;
    public int OriginalQuantity { get; set; }
    public int QuantityRemaining { get; set; }
    public int SpawnId { get; set; }
    public bool Edited { get; set; }
    public void BeginEdit() { }
    public void CancelEdit() { }
    public void EndEdit() => Edited = true;
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
