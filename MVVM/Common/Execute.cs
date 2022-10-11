using System;
using System.Text;
using System.Windows.Threading;

namespace MVVM.Common
{
    public static class Execute
    {
        private static Action<Action> executor = action => action();
        /// <summary>
        /// 初始化UI调度器
        /// </summary>
        public static void InitializeWithDispatcher()
        {
            var dispatcher = Dispatcher.CurrentDispatcher;
            executor = action =>
            {
                if (dispatcher.CheckAccess()) action();
                else dispatcher.BeginInvoke(action);
            };
        }
        /// <summary>
        /// UI线程中执行方法
        /// </summary>
        public static void OnUIThread(this Action action)
        {
            executor(action);
        }
    }



    /// <summary>
    /// Helper class for dispatcher operations on the UI thread.
    /// </summary>
    // Token: 0x02000002 RID: 2
    public static class DispatcherHelper
    {
        /// <summary>
        /// Gets a reference to the UI thread's dispatcher, after the
        /// <see cref="M:GalaSoft.MvvmLight.Threading.DispatcherHelper.Initialize" /> method has been called on the UI thread.
        /// </summary>
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
        // (set) Token: 0x06000002 RID: 2 RVA: 0x00002057 File Offset: 0x00000257
        public static Dispatcher UIDispatcher { get; private set; }

        /// <summary>
        /// Executes an action on the UI thread. If this method is called
        /// from the UI thread, the action is executed immendiately. If the
        /// method is called from another thread, the action will be enqueued
        /// on the UI thread's dispatcher and executed asynchronously.
        /// <para>For additional operations on the UI thread, you can get a
        /// reference to the UI thread's dispatcher thanks to the property
        /// <see cref="P:GalaSoft.MvvmLight.Threading.DispatcherHelper.UIDispatcher" /></para>.
        /// </summary>
        /// <param name="action">The action that will be executed on the UI
        /// thread.</param>
        // Token: 0x06000003 RID: 3 RVA: 0x0000205F File Offset: 0x0000025F
        public static void CheckBeginInvokeOnUI(Action action)
        {
            if (action == null)
            {
                return;
            }
            DispatcherHelper.CheckDispatcher();
            if (DispatcherHelper.UIDispatcher.CheckAccess())
            {
                action();
                return;
            }
            DispatcherHelper.UIDispatcher.BeginInvoke(action, new object[0]);
        }

        // Token: 0x06000004 RID: 4 RVA: 0x0000208F File Offset: 0x0000028F
        private static void CheckDispatcher()
        {
            if (DispatcherHelper.UIDispatcher == null)
            {
                StringBuilder stringBuilder = new StringBuilder("The DispatcherHelper is not initialized.");
                stringBuilder.AppendLine();
                stringBuilder.Append("Call DispatcherHelper.Initialize() in the static App constructor.");
                throw new InvalidOperationException(stringBuilder.ToString());
            }
        }

        /// <summary>
        /// Invokes an action asynchronously on the UI thread.
        /// </summary>
        /// <param name="action">The action that must be executed.</param>
        /// <returns>An object, which is returned immediately after BeginInvoke is called, that can be used to interact
        ///  with the delegate as it is pending execution in the event queue.</returns>
        // Token: 0x06000005 RID: 5 RVA: 0x000020C0 File Offset: 0x000002C0
        public static DispatcherOperation RunAsync(Action action)
        {
            DispatcherHelper.CheckDispatcher();
            return DispatcherHelper.UIDispatcher.BeginInvoke(action, new object[0]);
        }

        /// <summary>
        /// This method should be called once on the UI thread to ensure that
        /// the <see cref="P:GalaSoft.MvvmLight.Threading.DispatcherHelper.UIDispatcher" /> property is initialized.
        /// <para>In a Silverlight application, call this method in the
        /// Application_Startup event handler, after the MainPage is constructed.</para>
        /// <para>In WPF, call this method on the static App() constructor.</para>
        /// </summary>
        // Token: 0x06000006 RID: 6 RVA: 0x000020D8 File Offset: 0x000002D8
        public static void Initialize()
        {
            if (DispatcherHelper.UIDispatcher != null && DispatcherHelper.UIDispatcher.Thread.IsAlive)
            {
                return;
            }
            DispatcherHelper.UIDispatcher = Dispatcher.CurrentDispatcher;
        }

        /// <summary>
        /// Resets the class by deleting the <see cref="P:GalaSoft.MvvmLight.Threading.DispatcherHelper.UIDispatcher" />
        /// </summary>
        // Token: 0x06000007 RID: 7 RVA: 0x000020FD File Offset: 0x000002FD
        public static void Reset()
        {
            DispatcherHelper.UIDispatcher = null;
        }
    }

}