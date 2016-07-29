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
    [Register ("RegisterScreen")]
    partial class RegisterScreen
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_NavLogin { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_Register { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbx_Password { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbx_Username { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btn_NavLogin != null) {
                btn_NavLogin.Dispose ();
                btn_NavLogin = null;
            }

            if (btn_Register != null) {
                btn_Register.Dispose ();
                btn_Register = null;
            }

            if (tbx_Password != null) {
                tbx_Password.Dispose ();
                tbx_Password = null;
            }

            if (tbx_Username != null) {
                tbx_Username.Dispose ();
                tbx_Username = null;
            }
        }
    }
}