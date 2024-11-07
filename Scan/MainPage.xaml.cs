using Plugin.NFC;
using System;
using Xamarin.Forms;

namespace Scan
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            meuEntry = (Entry)FindByName("meuEntry");

            CrossNFC.Current.OnMessageReceived += NfcMessageReceived;
        }
        private void NfcMessageReceived(ITagInfo tagInfo)
        {
            var idBytes = tagInfo.Identifier;
            var message = BitConverter.ToString(idBytes);

            // Atualiza o Entry com o valor da tag NFC
            Device.BeginInvokeOnMainThread(() =>
            {
                meuEntry.Text = $"{message}";
                // Exibe um alerta opcional
                DisplayAlert("Tag NFC Lida", $"ID: {message}", "OK");
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            System.Diagnostics.Debug.WriteLine("MainPage OnAppearing");

            CrossNFC.Current.StartListening();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            System.Diagnostics.Debug.WriteLine("MainPage OnDisappearing");

            CrossNFC.Current.StopListening();
        }
        private async void btnScannerQR_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                scanner.TopText = "Aponte para o QR Code";
                scanner.BottomText = "Teste Scanner - Eduardo Elias";
                var result = await scanner.Scan();
                if (result != null)
                {
                    txtResultado.Text = result.Text;
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Erro",ex.Message.ToString(), "Ok");
            }
        }

        /*private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new PopupTag());
        }*/
    }
}
