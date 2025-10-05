using HeavyLift.Models;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace HeavyLift.Services
{
    public class FileService
    {
        private readonly string _customExercisesPath;

        public FileService()
        {
            _customExercisesPath = Path.Combine(FileSystem.AppDataDirectory, "custom_exercises.json");
        }

        public async Task<List<ExerciseModel>> LoadBaseExercisesAsync()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "HeavyLift.Resources.Data.BaseExercises.json";

                using var stream = assembly.GetManifestResourceStream(resourceName);

                if (stream == null)
                    return new List<ExerciseModel>();

                using var reader = new StreamReader(stream);
                var json = await reader.ReadToEndAsync();

                return JsonSerializer.Deserialize<List<ExerciseModel>>(json)
                       ?? new List<ExerciseModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading base exercises: {ex.Message}");
                return new List<ExerciseModel>();
            }
        }

        public async Task<List<ExerciseModel>> LoadCustomExercisesAsync()
        {
            if (!File.Exists(_customExercisesPath))
                return new List<ExerciseModel>();

            try
            {
                var json = await File.ReadAllTextAsync(_customExercisesPath);
                return JsonSerializer.Deserialize<List<ExerciseModel>>(json)
                       ?? new List<ExerciseModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading custom exercises: {ex.Message}");
                return new List<ExerciseModel>();
            }
        }
    }
}
