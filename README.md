# Lab 1b using C# dotnet version: 9.0.x

Here is the Screenshot of the result:
![alt text](image.png)

![alt text](image-1.png)

## Note:

The code implements different Design Patterns to make it modular:

- Singleton.
- Layering with different modules like `Models` & `Services`.
- Lazy initialization of Instance.

`Json Library`

- Newtonsoft.Json

### Using simple github pipeline for it:

```yml
name: Build

on: [push, pull_request]

jobs:
  build:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v2
      - name: Setup .NET
        uses: actions/setup-dotnet@v1
        with:
          dotnet-version: "9.0.x"
      - name: Restore dependencies
        run: dotnet restore
      - name: Build
        run: dotnet build --no-restore
```
