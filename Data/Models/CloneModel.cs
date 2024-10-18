using System.ComponentModel;

namespace SeedBreed.Data.Models;
public class CloneModel : GerminateModel, IEditableObject,INotifyPropertyChanged
{
    public int CloneId { get; set; }
    public DateTime CloneDate { get; set; }
    public decimal CloneRate { get; set; }
    public int Quantity { get; set; }
    public bool Edited { get; set; }
    public void BeginEdit() { }
    public void CancelEdit() { }
    public void EndEdit() => Edited = true;
}
