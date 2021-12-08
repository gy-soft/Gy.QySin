using System.Collections.Generic;

namespace Gy.QySin.GtkSharp.Models
{
    interface IComboBoxTextModel
    {
        IDictionary<string, string> Items { get; set; }
    }
}