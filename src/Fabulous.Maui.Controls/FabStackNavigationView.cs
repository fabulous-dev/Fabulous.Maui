using Microsoft.Maui;

namespace Fabulous.Maui
{
    public class NavigationStackController
    {
        public void Push(object path, bool animated)
        {
        }

        public void Pop(bool animated)
        {
        }
    }
    
    public class NavigationStackController<T>
    {
        public NavigationStackController Controller { get; }= new();
        
        public void Push(T path, bool animated = true)
        {
            Controller.Push(path, animated);
        }
        
        public void Pop(bool animated = true) 
        {
            Controller.Pop(animated);
        }
    }
    
    public interface IFabNavigationStack : IStackNavigationView, IFabView, IFabStackNavigation
    {
        NavigationStackController? Controller { get; }
        IList<IView> Stack { get; }
        void NotifyStackChanged();
        void SetController(NavigationStackController? value);
        void SetOnNavigated(Action<object[]>? value);
    }

    public static class NavigationStackDefaults
    {
        public const NavigationStackController? Controller = null;
    }
}

namespace Fabulous.Maui.Controls
{
    public class FabNavigationStack: FabView, IFabNavigationStack
    {
        private Action<object[]>? _onNavigated;
        
        public NavigationStackController? Controller { get; private set; } = NavigationStackDefaults.Controller;
        public IList<IView> Stack { get; } = new List<IView>();

        protected override void OnHandlerChanged()
        {
            base.OnHandlerChanged();
            
            // When setting a new handler, we need to trigger a navigation to the latest stack
            NotifyStackChanged();
        }

        public void NotifyStackChanged()
        {
            RequestNavigation(new NavigationRequest(Stack.AsReadOnly(), true));
        }

        public void RequestNavigation(NavigationRequest eventArgs) => Handler?.Invoke(nameof(RequestNavigation), eventArgs);

        public void NavigationFinished(IReadOnlyList<IView> newStack)
        {
            _onNavigated?.Invoke(newStack as object[]);
        }

        public void SetController(NavigationStackController? value) => Controller = value;

        public void SetOnNavigated(Action<object[]>? value) => _onNavigated = value;
    }
}