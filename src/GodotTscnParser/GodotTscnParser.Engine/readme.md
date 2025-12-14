# ANTLR C# code generation

1. Follow ANTLR v4 installation instructions at [Getting Started with ANTLR v4](https://github.com/antlr/antlr4/blob/master/doc/getting-started.md#getting-started-with-antlr-v4)
1. Run generator with `java org.antlr.v4.Tool -Dlanguage=CSharp -package Righthand.GodotTscnParser.Engine.Grammar Tscn.g4` from within `GodotTscnParser.Engine\Grammar`. Similar for other supported compilers.
1. Or alternatively install antlr4 through python (pip thing) and just runt `antlr4` or `antlr4-parser` (Ctlr+Z + Return to end input))