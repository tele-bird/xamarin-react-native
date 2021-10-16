using System;

namespace SampleApp.Common
{
    public delegate void NavigateAwayHandler(string result);

    public interface IReactNavigationService
    {
        void NavigateTo(string context);

        event NavigateAwayHandler NavigateAway;
    }
}
