using System.Text.RegularExpressions;

const string SITE_URL_REGEXP = @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
const int MAX_THREADS_COUNT = 20;
const int HTTP_TIMEOUT_IN_SECONDS = 30;

try
{
    var arguments = Environment.GetCommandLineArgs();
    var fileName = string.Empty;
    if (arguments != null && arguments.Count() >= 2)
    {
        fileName = arguments[1];
    }

    if (string.IsNullOrEmpty(fileName))
    {
        throw new Exception("Please specify a file name with URL addresses to parse.");
    }

    if (!File.Exists(fileName))
    {
        throw new Exception($"File is not found: {fileName}");
    }

    Console.WriteLine();
    Console.WriteLine($"Going to parse {fileName} for web site addresses.");
    Console.WriteLine();

    var allUrls = ParseFile(fileName);
    var accessibleUrls = await GetAccessibleUrls(allUrls);

    Console.WriteLine();
    Console.WriteLine("These urls are accessible from your IP (HTTP code indicates success):");
    Console.WriteLine();
    foreach (var url in accessibleUrls)
    {
        Console.WriteLine(url);
    }

    Console.WriteLine();
    Console.WriteLine("These urls are NOT accessible from your IP (HTTP code indicates failure or connection is refused):");
    Console.WriteLine();
    foreach (var url in allUrls.Except(accessibleUrls))
    {
        Console.WriteLine(url);
    }

}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}

IEnumerable<string> ParseFile(string fileName)
{  
    var result = new List<string>();
    foreach (string line in File.ReadLines(fileName))
    {
        result.AddRange(ParseLine(line));
    }

    return result
        .Select(s => s.ToLower())
        .Distinct();
}

IEnumerable<string> ParseLine(string line)
{
    if (string.IsNullOrEmpty(line))
    {
        return Enumerable.Empty<string>();
    }

    var result = new List<string>();

    foreach (Match item in Regex.Matches(line, SITE_URL_REGEXP))
    {
        result.Add(EnsureTrailingBackslash(item.Value));
    }

    return result;
}

string EnsureTrailingBackslash(string url)
{
    return url.TrimEnd('/') + "/";
}

async Task<IEnumerable<string>> GetAccessibleUrls(IEnumerable<string> urls)
{
    var result = new List<string>();
    var client = new HttpClient
    {
        Timeout = TimeSpan.FromSeconds(HTTP_TIMEOUT_IN_SECONDS)
    };

    var throttler = new SemaphoreSlim(initialCount: MAX_THREADS_COUNT);
    var tasks = urls.Select(async url =>
    {
        await throttler.WaitAsync();
        try
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            result.Add(url);
        }
        catch (Exception e)
        {
            Console.WriteLine("{0,-50} {1}", url, e.Message);            
        }
        finally
        {
            throttler.Release();
        }
    });
    await Task.WhenAll(tasks);

    return result;
}
