using System.IO;
using System.Threading.Tasks;

namespace Liuww.Ssf.IO
{
    public static class FileHelper
    {
        public static void DeleteIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        public static string GetExtension(string fileNameWithExtension)
        {
            var lastDotIndex = fileNameWithExtension.LastIndexOf('.');
            if (lastDotIndex < 0)
            {
                return null;
            }

            return fileNameWithExtension.Substring(lastDotIndex + 1);
        }
        public static async Task<string> ReadAllTextAsync(string path)
        {
            using (var reader = File.OpenText(path))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task<byte[]> ReadAllBytesAsync(string path)
        {
            using (var stream = File.Open(path, FileMode.Open))
            {
                var result = new byte[stream.Length];
                await stream.ReadAsync(result, 0, (int)stream.Length);
                return result;
            }
        }
    }
}