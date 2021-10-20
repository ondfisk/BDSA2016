Get-ChildItem *.xproj -Recurse | ForEach-Object {
    $in = $PSItem.FullName
    $out = "$($PSItem.DirectoryName)\project.json"
    $dir = $PSItem.DirectoryName
    dotnet migrate --skip-backup -s -x "$in" "$out" -r "C:\Users\rasmusl\AppData\Local\Temp\bwf1k2lz.wsy" --format-report-file-json
    dotnet sln add "$dir\$($PSItem.BaseName).csproj"
}

# Remove
# Get-ChildItem global.json -Recurse | Remove-Item
# Get-ChildItem project.json -Recurse | Remove-Item
# Get-ChildItem *.xproj -Recurse | Remove-Item
# Get-ChildItem *.migration_in_place_backup -Recurse | Remove-Item
