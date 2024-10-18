using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedBreed.Data.Models;
public class SourceModel : IComparable<SourceModel>,IEditableObject, IQuery
{
    internal static string GetQuery => "SELECT * FROM Seedlings.Source";
    public int SourceId { get; set; }
    public string Source { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public int Rating { get; set; }
    public bool Edited { get; set; }
    public void BeginEdit() { }
    public void CancelEdit() { }
    public void EndEdit() => Edited = true;
    public string DeleteQuery => $"DELETE Seedlings.Source WHERE SourceId = {SourceId}";
    public int CompareTo(SourceModel other) => SourceId.CompareTo(other.SourceId);
}
//{
//    public int SourceId { get; set; }
//    public string Source { get; set; } = string.Empty;
//    public string Website { get; set; } = string.Empty;
//    public int Rating { get; set; }
//}
