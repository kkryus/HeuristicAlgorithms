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

        /// <summary>
        /// Sets message as error for given control
        /// </summary>
        /// <param name="control">Control to set error</param>
        /// <param name="message">Message to set as error</param>
        /// <returns>If that was successful</returns>
        public bool SetError(Control control, string message)
        {
            ErrorProvider.SetError(control, message);
            return true;
        }

        /// <summary>
        /// Clears error for given control
        /// </summary>
        /// <param name="control">Control to clear error</param>
        /// <returns>If that was successful</returns>
        public bool ClearError(Control control)
        {
            ErrorProvider.SetError(control, "");
            return true;
        }

        /// <summary>
        /// Sets every control a error with given message
        /// </summary>
        /// <param name="controls">List of controls to set errors</param>
        /// <param name="message">Message to set as error</param>
        /// <returns>If that was successful</returns>
        public bool SetErrors(List<Control> controls, string message)
        {
            for (int i = 0; i < controls.Count; i++)
            {
                ErrorProvider.SetError(controls[i], message);
            }
            return true;
        }

        /// <summary>
        /// Sets every error to each control respectively
        /// </summary>
        /// <param name="controls">List of controls to set errors</param>
        /// <param name="messages">List of messages to set as errors</param>
        /// <returns>If that was successful</returns>
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

        /// <summary>
        /// Clears all errors
        /// </summary>
        /// <returns></returns>
        public void ClearErrors()
        {
            ErrorProvider.Clear();
        }

        /// <summary>
        /// Checks if there are any error remaining.
        /// </summary>
        /// <returns>Existence of the errors</returns>
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
