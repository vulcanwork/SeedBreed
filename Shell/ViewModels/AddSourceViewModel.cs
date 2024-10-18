using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using SeedBreed.Data.Models;

namespace SeedBreed.ViewModels;
public class AddSourceViewModel
{
    public SourceModel Source { get; set; } = new SourceModel();
    public DelegateCommand SaveCommand => new DelegateCommand(ExecuteSaveCommand);
    private void ExecuteSaveCommand()
    {
        // Save the source
    }
}
