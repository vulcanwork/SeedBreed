using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedBreed.Data.Models;
internal class SpawnModel : IEditableObject
{
    public int SpawnId { get; set; }
    public int PlantId { get; set; }
    public int PollenId { get; set; }
    public bool Hybrid { get; set; }
    public bool Direct { get; set; }
    public bool Inbreed { get; set; }

    public bool Edited { get; set; }
    public void BeginEdit() { }
    public void CancelEdit() { }
    public void EndEdit() => Edited = true;
}
