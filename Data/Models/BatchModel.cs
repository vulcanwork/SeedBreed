using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedBreed.Data.Models;
public class BatchModel : IComparable<BatchModel>, IEditableObject, IQuery
{
    public bool Edited { get; set; }

    public void BeginEdit()
    {
    }

    public void CancelEdit()
    {
    }

    public void EndEdit() => Edited = true;
    public static string GetQuery => "Select * From Seedlings.vw_Batches";
    public  string  DeleteQuery => $"Delete Seedlings.Batch WHERE BatchId = {BatchId}";
    public string Batch { get; set; } = string.Empty;
    private DateTime _purchaseDate;
    public int BatchId { get; set; }
    public int SourceId { get; set; }
    public string Source { get; set; } = string.Empty;
    public int SeedId { get; set; }
    public string Strain { get; set; } = string.Empty;
    public bool IsPurchased { get; set; } = true;
    public DateTime PurchaseDate { get => _purchaseDate.Date; set => _purchaseDate = value; }
    public int OriginalQuantity { get; set; }
    public int QuantityRemaining { get; set; }
    public int SpawnId { get; set; }


    public int CompareTo(BatchModel other) => BatchId.CompareTo(other.BatchId);
}
