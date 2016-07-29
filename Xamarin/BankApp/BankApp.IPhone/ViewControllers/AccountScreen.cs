using System;

using UIKit;

using BankApp.Nucleus;

namespace BankApp.ViewControllers {
    public partial class AccountScreen : UIViewController {
        private AppLogic.AccountOptions state { get; }
        public AccountScreen(AppLogic.AccountOptions state) : base("AccountScreen", null) {
            this.state = state;
        }

        private void lbl_AccountBalance_Update(int balance) {
            lbl_AccountBalance.Text = $"{balance}:- SEK";
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();
            lbl_AccountUser.Text = state.UserAccount.User.Username;
            lbl_AccountBalance_Update(state.UserAccount.Data.Balance);

            btn_Logout.TouchUpInside += (o, e) => {
                var loginScreen = new LoginScreen(state.Logout());
                NavigationController.PushViewController(loginScreen, true);
            };

            btn_Deposit.TouchUpInside += (o, e) => {
                try {
                    var accountOption = state.Deposit(int.Parse(tbx_DepositionAmount.Text));
                    Helper.MatchOption(accountOption, account => {
                        lbl_AccountBalance_Update(account.Balance);
                        ApiAbstractions.ShowMessage("Deposit successful!", $"Deposited {tbx_DepositionAmount.Text}:- SEK!");
                    }, () => {
                        ApiAbstractions.ShowMessage("Deposit error!", "Could not perform transaction!");
                    });
                } catch (Exception) {
                    ApiAbstractions.ShowMessage("Deposit error!", "Could not perform transaction!");
                }
                tbx_DepositionAmount.Text = string.Empty;
            };

            btn_Withdraw.TouchUpInside += (o, e) => {
                try {
                    var accountOption = state.Withdraw(int.Parse(tbx_WithdrawalAmount.Text));
                    Helper.MatchOption(accountOption, account => {
                        lbl_AccountBalance_Update(account.Balance);
                        ApiAbstractions.ShowMessage("Withdraw successful!", $"Withdrew {tbx_WithdrawalAmount.Text}:- SEK!");
                    }, () => {
                        ApiAbstractions.ShowMessage("Withdraw error!", "Could not perform transaction!");
                    });
                } catch (Exception) {
                    ApiAbstractions.ShowMessage("Withdraw error!", "Could not perform transaction!");
                }
                tbx_WithdrawalAmount.Text = string.Empty;
            };
        }
    }
}