using System.ComponentModel;
namespace Responsible.Handler.Winforms.Extensions
{
    /// <summary>
    /// Extensions methods for Windows Forms Controls
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// A delegate to pass in an action to be executed in Thread Safe Mode using Extension Method <see cref="ControlExtensions.InvokeIfRequired{T}"/>
        /// </summary>
        /// <param name="control">The control to be used for Invoking Method</param>
        /// <typeparam name="T"></typeparam>
        public delegate void InvokeIfRequiredDelegate<in T>(T control)
            where T : ISynchronizeInvoke;

        /// <summary>
        /// An Extension method to execute the given action in Thread Safe Mode
        /// </summary>
        /// <param name="control">The control to be used for Invoking Method</param>
        /// <param name="action">The action to execute</param>
        /// <typeparam name="T"></typeparam>
        public static void InvokeIfRequired<T>(this T control, InvokeIfRequiredDelegate<T> action)
            where T : ISynchronizeInvoke
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action, new object[] {control});
            }
            else
            {
                action(control);
            }
        }
    }
}