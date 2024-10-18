using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedBreed.Data.Models;
public interface IQuery
{
   static string GetQuery { get; }
   string DeleteQuery { get; }
}
