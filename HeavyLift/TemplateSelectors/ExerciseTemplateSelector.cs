using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.TemplateSelectors
{
    internal class ExerciseTemplateSelector: DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var rep = item as HeavyLift.Models.RepModel;
            var collectionView = container as CollectionView;
            if (container is Element element && element.Parent?.BindingContext is HeavyLift.Models.ExerciseModel exercise)
            {
                switch (exercise?.type)
                {
                    case "Weight":
                        return collectionView.Resources["WeightExerciseTemplate"] as DataTemplate;
                    case "Time":
                        return collectionView.Resources["TimeExerciseTemplate"] as DataTemplate;
                    case "Distance":
                        return collectionView.Resources["DistanceExerciseTemplate"] as DataTemplate;
                    default:
                        return collectionView.Resources["WeightExerciseTemplate"] as DataTemplate;
                }
            }
            return collectionView.Resources["WeightExerciseTemplate"] as DataTemplate;
        }
    }
}
