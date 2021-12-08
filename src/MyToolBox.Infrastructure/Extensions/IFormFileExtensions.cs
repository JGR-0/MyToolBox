using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CalculosPlusvalias.Infrastructure
{
    public static class IFormFileExtensions
    {
        public static async Task<IList<string>> ReadLinesAsListAsync(this IFormFile file)
        {
            var result = new List<string>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.Add(await reader.ReadLineAsync().ConfigureAwait(false));
            }
            return result;
        }
    }
}
