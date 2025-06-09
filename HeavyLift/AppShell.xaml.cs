using HeavyLift.Views.WorkoutViews;

namespace HeavyLift
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register routes for navigation
            Routing.RegisterRoute(nameof(TrainingPlanCreatorView), typeof(TrainingPlanCreatorView));

        }
    }
}
