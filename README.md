# YouTube to Text

Small Razor Pages app that takes a YouTube URL (prefixed with `1313`), downloads **German auto-subs**, strips timestamps, and shows only the text.

## Requirements
- .NET 8 SDK
- `yt-dlp` available on PATH

## Run
```bash
dotnet run
```
Open `http://localhost:5000`.

## Usage
1. Paste URL starting with `1313` (e.g. `1313https://www.youtube.com/watch?v=...`).
2. Click **Get Text**.
3. The transcript appears on the page.

## Notes
- Only auto-subs in German (`--write-auto-subs --sub-lang de`).
- The `1313` prefix is stripped server-side.
