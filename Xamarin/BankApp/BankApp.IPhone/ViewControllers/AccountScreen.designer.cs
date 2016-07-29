// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BankApp.ViewControllers
{
    [Register ("AccountScreen")]
    partial class AccountScreen
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_Deposit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_Logout { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_Withdraw { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_AccountBalance { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_AccountTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_AccountUser { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbx_DepositionAmount { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbx_WithdrawalAmount { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btn_Deposit != null) {
                btn_Deposit.Dispose ();
                btn_Deposit = null;
            }

            if (btn_Logout != null) {
                btn_Logout.Dispose ();
                btn_Logout = null;
            }

            if (btn_Withdraw != null) {
                btn_Withdraw.Dispose ();
                btn_Withdraw = null;
            }

            if (lbl_AccountBalance != null) {
                lbl_AccountBalance.Dispose ();
                lbl_AccountBalance = null;
            }

            if (lbl_AccountTitle != null) {
                lbl_AccountTitle.Dispose ();
                lbl_AccountTitle = null;
            }

            if (lbl_AccountUser != null) {
                lbl_AccountUser.Dispose ();
                lbl_AccountUser = null;
            }

            if (tbx_DepositionAmount != null) {
                tbx_DepositionAmount.Dispose ();
                tbx_DepositionAmount = null;
            }

            if (tbx_WithdrawalAmount != null) {
                tbx_WithdrawalAmount.Dispose ();
                tbx_WithdrawalAmount = null;
            }
        }
    }
}