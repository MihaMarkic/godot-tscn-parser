# Godot TSCN parser

[![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Righthand.GodotTscnParser)](https://www.nuget.org/packages/Righthand.GodotTscnParser/)

The project is an [ANTLR](https://www.antlr.org/) based parser for Godot's [TSCN files](https://docs.godotengine.org/en/latest/contributing/development/file_formats/tscn.html).
Since alpha7, parser for project.godot file is added.

The short term goal is to provide support for source code generators and not for full fledged parsing as TSCN files are not very well documented.

However, it can eventually provide strong typed configuration as there is motivation and long as somebody with enough knowledge about TSCN files is willing to help.

## How to use

See [godot-tscn-source-generator](https://github.com/MihaMarkic/godot-tscn-source-generator),
specifically classes `TscnTypesGenerator`, `GodotProjListener` and unit tests for them.