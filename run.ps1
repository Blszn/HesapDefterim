$files = Get-ChildItem -Path "c:\Users\karal\Desktop\HesapDefterim-master" -Recurse -Filter *.cs
$stringLiteralRegex = '(?s)\$?@?"(?:[^"\\]|\\.)*"'
$turkishPattern = '[\u0130\u0131\u015E\u015F\u011E\u011F\u00C7\u00E7\u00D6\u00F6\u00DC\u00FC]'
$evaluator = [System.Text.RegularExpressions.MatchEvaluator] {
    param($match)
    if ([regex]::IsMatch($match.Value, $turkishPattern)) {
        return '""'
    }
    return $match.Value
}
foreach ($f in $files) {
    $content = Get-Content $f.FullName -Encoding UTF8 -Raw
    $newContent = [regex]::Replace($content, $stringLiteralRegex, $evaluator)
    if ($content -ne $newContent) {
        Set-Content -Path $f.FullName -Value $newContent -Encoding UTF8
    }
}
Write-Host "Done"
