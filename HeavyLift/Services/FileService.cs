using System.Text.Json;
using HeavyLift.Models;

namespace HeavyLift.Services
{
    public class FileService
    {
        private const string BaseEcercisesFileName = "BaseExercises.json";
        private const string CustomExercisesFileName = "CustomExercises.json";

        private string GetExerciseFilePath(bool isBase)
        {
            var filename = isBase ? BaseEcercisesFileName : CustomExercisesFileName;
            return Path.Combine(FileSystem.AppDataDirectory, filename);
        }

        public async Task SaveExerciseToFileAsync(List<ExerciseModel> exercises)
        {
            var path = GetExerciseFilePath(false);  // User can save only custom exercises base exercise cannot be modfied
            using var stream = File.Create(path);
            await JsonSerializer.SerializeAsync(stream, exercises);
        }

        public async Task<List<ExerciseModel>> LoadExerciseFromFileAsync(bool isBase)
        {
            var path = GetExerciseFilePath(isBase);

            if (!File.Exists(path))
                return new List<ExerciseModel>();

            using var stream = File.OpenRead(path);
            return await JsonSerializer.DeserializeAsync<List<ExerciseModel>>(stream)
                   ?? new List<ExerciseModel>();
        }
    }
}
