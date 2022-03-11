# Solution run instruction

How to add migrations

```
dotnet ef --startup-project ./Oponeo.Start migrations add ExampleObjects --project ./Oponeo.Migrations --context OponeoContext
```

migration
```
dotnet ef --startup-project ./Oponeo.Start database update --project ./Oponeo.Migrations --context OponeoContext
```