using System;

using UIKit;

using BankApp.Nucleus;

namespace BankApp.ViewControllers {
    public partial class LoginScreen : UIViewController {
        private AppLogic.LoginOptions state { get; }
        public LoginScreen(AppLogic.LoginOptions state) : base("LoginScreen", null) {
            this.state = state;
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            btn_Login.TouchUpInside += (o, e) => {
                var accountOption = state.Login(new Models.Credentials(tbx_Username.Text, tbx_Password.Text));
                Helper.MatchOption(accountOption, accountstate => {
                    var accountScreen = new AccountScreen(accountstate);
                    NavigationController.PushViewController(accountScreen, true);
                }, () => {
                    tbx_Password.Text = string.Empty;
                    ApiAbstractions.ShowMessage("LoginError!", "Could not login!");
                });
            };

            btn_NavRegister.TouchUpInside += (o, e) => {
                var registerScreen = new RegisterScreen(state.NavRegister());
                NavigationController.PushViewController(registerScreen, true);
            };
        }
    }
}