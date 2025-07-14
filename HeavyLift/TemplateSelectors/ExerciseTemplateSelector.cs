using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.TemplateSelectors
{
    internal class ExerciseTemplateSelector: DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) //function to select the template based on the exercise type
        {
            var exercise = item as HeavyLift.Models.ExerciseModel; // cast the item to ExderciseModel
            var collectionView = container as CollectionView; // cast the container to CollectionView
            if (container is Element element) // check if the parent of the element is bound to an ExerciseModel
            {
                switch (exercise?.type) // switch based on the type of exercise
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
