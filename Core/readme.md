# Instructions

In an empty folder add the following file:

`global.json`
```json
{
    "projects": [
        "src",
        "test"
    ]
}
```

Create the file structure by running the following commands:
```bash
$ mkdir src
$ cd src
$ mkdir Lib
$ cd Lib
$ dotnet new -t Lib # Create a class library
$ cd ..
$ mkdir App
$ cd App
$ dotnet new # Create a console application
$ cd ..
$ cd ..

$ mkdir test
$ cd test
$ mkdir Tests
$ cd Tests
$ dotnet new -t xunittest # Create a test library
$ cd ..
$ cd ..

$ code . # Open Visual Studio Code
```

Add the following under `"dependencies":` in `test/Tests/project.json`:
```json
    "Lib": {
      "target": "project"
    }
```

Go to View->Integrated Terminal and type:
```bash
$ dotnet restore
``` 