using UIKit;

namespace BankApp {
    static class ApiAbstractions {
        public static void ShowMessage(string title, string message) {
            UIAlertView alert = new UIAlertView {
                Title = title,
                Message = message
            };
            alert.AddButton("Ok");
            alert.Show();
        }
    }
}
