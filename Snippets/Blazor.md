# Seleccionar un string de una lista de strings usando RadzenCheckBoxList
Como se puede observar, se tiene que agregar los **RadzenCheckBoxListItem** manualmente.

## Variables necesarias
```cs
List<string> items = new List<string>();
IEnumerable<string> selected = [];
```

## GUI Razor
```html
<RadzenCheckBoxList @bind-Value="@selected" TValue="string">
    <Items>
        @foreach (var item in items)
        {
            <RadzenCheckBoxListItem Text="@item" Value="@item" />
        }
    </Items>
</RadzenCheckBoxList>
```
