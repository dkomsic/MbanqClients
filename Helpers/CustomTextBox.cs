using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace MbanqClients.Helpers
{
    public class CustomTextBox : TextBox
    {
        public string regExpr { get; set; }

        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            Regex regex = new Regex(regExpr);
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
            base.OnPreviewTextInput(e);
        }
    }
}
