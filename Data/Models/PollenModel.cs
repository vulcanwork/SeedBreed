using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedBreed.Data.Models;
public class PollenModel : IEditableObject
{
    public int PollenId { get; set; }
    public int PlantId { get; set; }
    public bool Edited { get; set; }
    public void BeginEdit() { }
    public void CancelEdit() { }
    public void EndEdit() => Edited = true;
}
