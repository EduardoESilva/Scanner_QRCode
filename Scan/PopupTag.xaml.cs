using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Scan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupTag : Popup
    {
        public PopupTag()
        {
            InitializeComponent();
        }

        private void BtnCsharp_Click(object sender, EventArgs e)
        {
            /*Clipboard.SetTextAsync(.Text)*/
        }
    }
}