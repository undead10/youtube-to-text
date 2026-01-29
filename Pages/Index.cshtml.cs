using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YoutubeToText.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public string? InputUrl { get; set; }

    public string? ResultText { get; set; }
    public string? Error { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrWhiteSpace(InputUrl))
        {
            Error = "Please provide a YouTube URL.";
            return Page();
        }

        var url = InputUrl.Trim();
        if (!url.StartsWith("1313"))
        {
            Error = "Invalid URL.";
            return Page();
        }

        url = url[4..].Trim();
        if (!IsValidYoutubeUrl(url))
        {
            Error = "Please provide a valid YouTube URL.";
            return Page();
        }

        var workDir = Path.Combine(Path.GetTempPath(), "yt-text", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(workDir);
        var outputTemplate = Path.Combine(workDir, "sub");

        try
        {
            var args = new[]
            {
                "--write-auto-subs",
                "--sub-lang", "de",
                "--sub-format", "vtt",
                "--skip-download",
                "-o", outputTemplate,
                url
            };

            var ytDlpPath = "/usr/local/bin/yt-dlp";
            if (!System.IO.File.Exists(ytDlpPath))
            {
                ytDlpPath = "yt-dlp";
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ytDlpPath,
                    Arguments = string.Join(' ', args.Select(QuoteArg)),
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            var stdOut = await proc.StandardOutput.ReadToEndAsync();
            var stdErr = await proc.StandardError.ReadToEndAsync();
            await proc.WaitForExitAsync();

            if (proc.ExitCode != 0)
            {
                Error = "Failed to fetch subtitles.";
                _logger.LogWarning("yt-dlp failed: {Error}", stdErr);
                return Page();
            }

            var vttFile = Directory.GetFiles(workDir, "*.vtt").FirstOrDefault();
            if (vttFile == null)
            {
                Error = "No subtitles found (German auto-subs missing).";
                return Page();
            }

            ResultText = ExtractTextFromVtt(await System.IO.File.ReadAllTextAsync(vttFile));
            if (string.IsNullOrWhiteSpace(ResultText))
            {
                Error = "Subtitles were empty.";
                return Page();
            }

            return Page();
        }
        finally
        {
            try { Directory.Delete(workDir, true); } catch { }
        }
    }

    private static bool IsValidYoutubeUrl(string url)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var uri)) return false;
        return uri.Host.Contains("youtube.com", StringComparison.OrdinalIgnoreCase) ||
               uri.Host.Contains("youtu.be", StringComparison.OrdinalIgnoreCase);
    }

    private static string ExtractTextFromVtt(string vtt)
    {
        var output = new List<string>();
        string? last = null;

        var lines = vtt.Split('\n');
        foreach (var raw in lines)
        {
            var line = raw.Trim();
            if (line.Length == 0) continue;
            if (line.StartsWith("WEBVTT")) continue;
            if (line.StartsWith("Kind:", StringComparison.OrdinalIgnoreCase)) continue;
            if (line.StartsWith("Language:", StringComparison.OrdinalIgnoreCase)) continue;
            if (Regex.IsMatch(line, "^\\d+$")) continue;
            if (Regex.IsMatch(line, "\\d{2}:\\d{2}:\\d{2}\\.\\d{3} -->")) continue;
            if (line.StartsWith("NOTE")) continue;

            line = Regex.Replace(line, "<[^>]+>", string.Empty).Trim();
            if (line.Length == 0) continue;
            if (string.Equals(line, last, StringComparison.Ordinal)) continue;

            output.Add(line);
            last = line;
        }

        var joined = string.Join(" ", output);
        joined = Regex.Replace(joined, "\\s+", " ").Trim();
        return joined;
    }

    private static string QuoteArg(string arg)
        => arg.Contains(' ') ? $"\"{arg}\"" : arg;
}
