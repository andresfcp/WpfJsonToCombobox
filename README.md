# WpfJsonToCombobox

A small WPF sample application that demonstrates loading a list of objects from a JSON file and populating a `ComboBox` with them. Selecting an item in the `ComboBox` updates UI fields to show the selected item's properties. The project targets .NET 10.

## Features

- Load languages (or arbitrary items) from a JSON file at startup.
- Bind a `ComboBox` to the deserialized list of `Language` objects.
- Display selected item's `Name` and `Value` in `TextBlock`s.
- A button to show/act on the current selection (example action handled in code-behind).

## Prerequisites

- .NET 10 SDK
- Visual Studio (or other IDE) with WPF support on Windows

## Project structure

- `WpfJsonToCombobox/` - solution and project folder
  - `Assets/languages.json` - JSON file with the items loaded into the `ComboBox`.
  - `Models/Language.cs` - model that maps the JSON structure.
  - `MainWindow.xaml` - WPF window UI definition.
  - `MainWindow.xaml.cs` - code-behind: loads JSON, binds the `ComboBox`, handles selection and button click.
  - `App.xaml` - application entry point.

## JSON format

The app expects an array of objects with at least `name` and `value` properties (case-insensitive mapping depends on the serializer). Example in `Assets/languages.json`:

```json
[
  { "name": "English", "value": "en" },
  { "name": "Spanish", "value": "es" }
]
```

`Language` model typically looks like:

- `Name` (string)
- `Value` (string)

If you add extra properties to JSON you may extend `Language.cs` accordingly.

## How it works (high level)

1. On startup the application reads `Assets/languages.json`.
2. The JSON is deserialized into a `List<Language>` using the built-in JSON serializer.
3. The `ComboBox`'s `ItemsSource` is set to the deserialized list; `DisplayMemberPath` or a data template is used to show the `Name`.
4. When the user changes the selected item (`SelectionChanged`), the code-behind updates `NameTextBlock` and `ValueTextBlock` to display the selected `Language` properties.
5. The `ShowSelectionButton` demonstrates how to read and act on the current selection (for example showing a message or using the selected `Value`).

## Running the project

1. Open the solution in Visual Studio.
2. Restore NuGet packages (if any) and build the solution targeting .NET 10.
3. Run the project (F5) — the window should open and the `ComboBox` should show entries from `Assets/languages.json`.

## Customizing

- To add or remove items, edit `Assets/languages.json` and follow the same object shape.
- To change which property is shown in the `ComboBox`, update `DisplayMemberPath` in `MainWindow.xaml` or adjust the data template.
- To react differently to selection or button clicks, modify `MainWindow.xaml.cs` event handlers:
  - `LanguageComboBox_SelectionChanged`
  - `ShowSelectionButton_Click`

## Troubleshooting

- If the `ComboBox` is empty: verify `languages.json` is included in the project and its `Build Action` is correct (typically `Content`) and `Copy to Output Directory` is set to `Copy if newer` or `Always` so the file is available at runtime.
- If deserialization fails: check JSON syntax and property names.

## Notes

- The sample uses a simple code-behind approach for clarity. For larger apps prefer MVVM patterns, data binding with `INotifyPropertyChanged`, and command-based interactions.

## License

This is a sample/demonstration project; adapt and reuse as needed.
