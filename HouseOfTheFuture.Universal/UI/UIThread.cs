using System;
using Windows.Foundation;
using Windows.UI.Core;

namespace InfoSupport.TickTack.App
{
    public static class UIThread
    {
        private static CoreDispatcher _dispatcher;

        public static void Set(CoreDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public static IAsyncAction ExecuteAsync(Action action)
        {
            return _dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
        }
    }
}