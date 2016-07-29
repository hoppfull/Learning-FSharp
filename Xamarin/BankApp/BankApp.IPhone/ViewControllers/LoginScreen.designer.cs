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
    [Register ("LoginScreen")]
    partial class LoginScreen
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_Login { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_NavRegister { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbx_Password { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField tbx_Username { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btn_Login != null) {
                btn_Login.Dispose ();
                btn_Login = null;
            }

            if (btn_NavRegister != null) {
                btn_NavRegister.Dispose ();
                btn_NavRegister = null;
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