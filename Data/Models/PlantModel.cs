using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedBreed.Data.Models;
public class PlantModel : CloneModel, IComparable<PlantModel>, IEditableObject, IQuery,INotifyPropertyChanged
{
    internal static string GetQuery => "SELECT * FROM Padawans.vw_Plants";
    public int PlantId { get; set; }
    public DateTime PlantDate { get; set; } = DateTime.Now;
    public DateTime HarvestDate { get; set; } = DateTime.Now;
    public int HarvestInGrams { get; set; }
    public bool Gifted { get; set; }
    public bool Edited { get; set; }
    public void BeginEdit() { }
    public void CancelEdit() { }
    public void EndEdit() => Edited = true;
    public string DeleteQuery => $"DELETE Padawans.Plant WHERE PlantId = {PlantId}";
    public int CompareTo(PlantModel? other) => PlantId.CompareTo(other?.PlantId);
}