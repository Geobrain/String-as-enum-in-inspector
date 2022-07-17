# String-as-enum-in-inspector
advantage over enum is that a partial class is used for string keys.
new string keys are added to it as needed

## How to use
Add new string field 
```csharp
public partial class Keys
{
  [FieldKey(categoryName = "Levels")] public const string Main = "Main";
}
```

Use it in your project!
```csharp
[KeyFilter(typeof(Keys))] public string key;
```
https://user-images.githubusercontent.com/43826167/179422943-84213e51-a3a1-4e91-9412-ee8d8bca9691.mp4

