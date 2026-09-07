# CatFactTask
Aplikacja pobiera fakty z [Cat Fact API](https://catfact.ninja/fact), wyświetla je na konsoli i zapisuje każdą odpowiedź w osobnym wierszu pliku tekstowego.
## Wymagania
- .NET 10
## Uruchomienie
```powershell
dotnet run --project CatFactTask/CatFactTask.csproj
```
Opcjonalnie można podać liczbę faktów (domyślnie jest 5):
```powershell
dotnet run --project CatFactTask/CatFactTask.csproj -- 3
```
## Testowanie
```powershell
dotnet test CatFactTask/CatFactTask.sln
```