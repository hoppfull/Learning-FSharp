using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BankApp.Nucleus;

namespace BankApp {
    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            NavigateToLogin(new AppLogic.LoginOptions());
        }

        private void ShowMessage(string title, string msg) {
            new AlertDialog.Builder(this)
                .SetNeutralButton("ok", (o, e) => { })
                .SetTitle(title)
                .SetMessage(msg)
                .Show();
        }

        private void NavigateToLogin(AppLogic.LoginOptions state) {
            SetContentView(Resource.Layout.Login);

            Button btn_LoginApply       = FindViewById<Button>(Resource.Id.btn_LoginApply);
            Button btn_LoginNavRegister = FindViewById<Button>(Resource.Id.btn_LoginNavRegister);
            
            TextView tbx_LoginUsernameInput = FindViewById<TextView>(Resource.Id.tbx_LoginUsernameInput);
            TextView tbx_LoginPasswordInput = FindViewById<TextView>(Resource.Id.tbx_LoginPasswordInput);
            
            btn_LoginNavRegister.Click += (o, e) => NavigateToRegister(state.NavRegister());
            
            btn_LoginApply.Click += (o, e) => {
                var accountOption = state.Login(new Models.Credentials(tbx_LoginUsernameInput.Text, tbx_LoginPasswordInput.Text));
                Helper.MatchOption(accountOption, NavigateToAccount, () => {
                    tbx_LoginPasswordInput.Text = string.Empty;
                    ShowMessage("LoginError!", "Could not login!");
                });
            };
        }

        private void NavigateToRegister(AppLogic.RegisterOptions state) {
            SetContentView(Resource.Layout.Register);
            
            Button btn_RegisterApply    = FindViewById<Button>(Resource.Id.btn_RegisterApply);
            Button btn_RegisterCancel   = FindViewById<Button>(Resource.Id.btn_RegisterCancel);
            
            TextView tbx_RegisterUsernameInput = FindViewById<TextView>(Resource.Id.tbx_RegisterUsernameInput);
            TextView tbx_RegisterPasswordInput = FindViewById<TextView>(Resource.Id.tbx_RegisterPasswordInput);

            btn_RegisterCancel.Click += (o, e) => NavigateToLogin(state.Cancel());

            btn_RegisterApply.Click += (o, e) => {
                var loginOption = state.Register(new Models.Credentials(tbx_RegisterUsernameInput.Text, tbx_RegisterPasswordInput.Text));
                Helper.MatchOption(loginOption, loginState => {
                    NavigateToLogin(loginState);
                    ShowMessage("Congratulations!", "You are registered!");
                }, () => {
                    ShowMessage("Registration error!", "Could not register!");
                });
            };
        }

        private void NavigateToAccount(AppLogic.AccountOptions state) {
            SetContentView(Resource.Layout.Account);

            Button btn_AccountLogout = FindViewById<Button>(Resource.Id.btn_AccountLogout);
            Button btn_AccountDeposit = FindViewById<Button>(Resource.Id.btn_AccountDeposit);
            Button btn_AccountWithdraw = FindViewById<Button>(Resource.Id.btn_AccountWithdraw);

            TextView lbl_AccountBalance = FindViewById<TextView>(Resource.Id.lbl_AccountBalance);
            TextView lbl_AccountUser = FindViewById<TextView>(Resource.Id.lbl_AccountUser);

            lbl_AccountUser.Text = state.UserAccount.User.Username;
            lbl_AccountBalance.Text = $"{state.UserAccount.Data.Balance}:- SEK";

            TextView tbx_AccountDepositInput    = FindViewById<TextView>(Resource.Id.tbx_AccountDepositInput);
            TextView tbx_AccountWithdrawInput   = FindViewById<TextView>(Resource.Id.tbx_AccountWithdrawInput);

            btn_AccountLogout.Click += (o, e) => NavigateToLogin(state.Logout());

            btn_AccountDeposit.Click += (o, e) => {
                try {
                    var accountOption = state.Deposit(int.Parse(tbx_AccountDepositInput.Text));
                    Helper.MatchOption(accountOption, account => {
                        lbl_AccountBalance.Text = $"{account.Balance}:- SEK";
                        ShowMessage("Deposit successful!", $"Deposited {tbx_AccountDepositInput.Text}:- SEK!");
                    }, () => {
                        ShowMessage("Deposit error!", "Could not perform transaction!");
                    });
                } catch (Exception) {
                    ShowMessage("Deposit error!", "Could not perform transaction!");
                }
                tbx_AccountDepositInput.Text = string.Empty;
            };

            btn_AccountWithdraw.Click += (o, e) => {
                try {
                    var accountOption = state.Withdraw(int.Parse(tbx_AccountWithdrawInput.Text));
                    Helper.MatchOption(accountOption, account => {
                        lbl_AccountBalance.Text = $"{account.Balance}:- SEK";
                        ShowMessage("Withdraw successful!", $"Withdrew {tbx_AccountWithdrawInput.Text}:- SEK!");
                    }, () => {
                        ShowMessage("Withdraw error!", "Could not perform transaction!");
                    });
                } catch (Exception) {
                    ShowMessage("Withdraw error!", "Could not perform transaction!");
                }
                tbx_AccountWithdrawInput.Text = string.Empty;
            };
        }
    }
}
