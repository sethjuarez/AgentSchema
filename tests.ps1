# set output to verbose
$VerbosePreference = "Continue"
# format csharp code
#print out every action
Write-Host "Testing dotnet code..."
#set error action preference to stop on errors
Write-Host "Set-Location ./runtime/csharp"
Set-Location ./runtime/csharp

Write-Host "Running dotnet test..."
dotnet test
Set-Location ../..

# format python code
Write-Host "Testing Python code..."
Set-Location ./runtime/python/agentschema
# activate venv
Write-Host "Activating virtual environment..."
./.venv/Scripts/activate
# run ruff and black
Write-Host "Running tests..."
uv run pytest -v
Set-Location ../../..