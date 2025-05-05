using HeavyLift.Views;

namespace HeavyLift
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Pobierz LoginView przez DI (razem z jego ViewModel)
            var loginView = _serviceProvider.GetRequiredService<LoginView>();
            return new Window(loginView);
        }
    }
}