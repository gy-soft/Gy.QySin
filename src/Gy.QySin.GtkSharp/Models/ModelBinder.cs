using Gtk;

namespace Gy.QySin.GtkSharp.Models
{
    static class ModelBinder
    {
        public static void BindComboBoxTextModel(ComboBoxText combo, IComboBoxTextModel model)
        {
            combo.RemoveAll();
            foreach (var item in model.Items)
            {
                combo.Prepend(item.Key, item.Value);
            }
        }
    }
}