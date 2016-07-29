using System;
using Microsoft.FSharp.Core;

using UIKit;

using BankApp.Nucleus;

namespace BankApp.ViewControllers {
    public partial class RegisterScreen : UIViewController {
        private AppLogic.RegisterOptions state { get; }
        public RegisterScreen(AppLogic.RegisterOptions state) : base("RegisterScreen", null) {
            this.state = state;
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            btn_Register.TouchUpInside += (o, e) => {
                var loginOption = state.Register(new Models.Credentials(tbx_Username.Text, tbx_Password.Text));
                Helper.MatchOption(loginOption, loginState => {
                    var loginScreen = new LoginScreen(loginState);
                    NavigationController.PushViewController(loginScreen, true);
                    ApiAbstractions.ShowMessage("Congratulations!", "You are registered!");
                }, () => {
                    ApiAbstractions.ShowMessage("Registration error!", "Could not register!");
                });
            };

            btn_NavLogin.TouchUpInside += (o, e) => {
                var loginScreen = new LoginScreen(state.Cancel());
                NavigationController.PushViewController(loginScreen, true);
            };
        }
    }
}