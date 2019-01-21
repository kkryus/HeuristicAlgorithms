using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HeuristicAlgorithms.Utilities
{
    public class ViewErrorController
    {
        public ErrorProvider ErrorProvider { get; private set; }
        public ViewErrorController(ErrorProvider errorProvider)
        {
            ErrorProvider = errorProvider;
        }

        public bool SetError(Control control, string message)
        {
            ErrorProvider.SetError(control, message);
            return true;
        }

        public bool ClearError(Control control)
        {
            ErrorProvider.SetError(control, "");
            return true;
        }

        public bool SetErrors(List<Control> controls, string message)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                ErrorProvider.SetError(controls[i], message);
            }
            return true;
        }

        public bool SetErrors(List<Control> controls, List<string> messages)
        {
            if (controls.Count != messages.Count)
            {
                return false;
            }
            for (int i = 0; i < controls.Count; i++)
            {
                ErrorProvider.SetError(controls[i], messages[i]);
            }
            return true;
        }

        public bool ClearErrors()
        {
            ErrorProvider.Clear();
            return true;
        }

        public bool IsValid()
        {
            foreach (Control c in ErrorProvider.ContainerControl.Controls)
            {
                if (ErrorProvider.GetError(c) != "")
                    return false;
            }
            return true;
        }
    }
}
