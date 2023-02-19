using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Righthand.GodotTscnParser.Engine.Grammar;

namespace GodotTscnParser.Test.Grammar;

public abstract class Bootstrap
{
    public void Run<TContext>(string text, Func<TscnParser, TContext> run)
        where TContext : ParserRuleContext
    {
        Run<TscnBaseListener, TContext>(text, run);
    }
    public TListener Run<TListener, TContext>(string text, Func<TscnParser, TContext> run)
        where TListener : TscnBaseListener, new()
        where TContext : ParserRuleContext
    {
        var input = new AntlrInputStream(text);
        var lexer = new TscnLexer(input);
        lexer.AddErrorListener(new SyntaxErrorListener());
        var tokens = new CommonTokenStream(lexer);
        var parser = new TscnParser(tokens)
        {
            BuildParseTree = true
        };
        parser.AddErrorListener(new ErrorListener());
        var tree = run(parser);
        var listener = new TListener();
        ParseTreeWalker.Default.Walk(listener, tree);
        return listener;
    }
    public void Run<TContext>(ITscnListener listener, string text, Func<TscnParser, TContext> run)
        where TContext : ParserRuleContext
    {
        var input = new AntlrInputStream(text);
        var lexer = new TscnLexer(input);
        lexer.AddErrorListener(new SyntaxErrorListener());
        var tokens = new CommonTokenStream(lexer);
        var parser = new TscnParser(tokens)
        {
            BuildParseTree = true
        };
        parser.AddErrorListener(new ErrorListener());
        var tree = run(parser);
        ParseTreeWalker.Default.Walk(listener, tree);
    }

    public TContext Return<TContext>(string text, Func<TscnParser, TContext> run)
        where TContext : ParserRuleContext
    {
        var input = new AntlrInputStream(text);
        var lexer = new TscnLexer(input);
        lexer.AddErrorListener(new SyntaxErrorListener());
        var tokens = new CommonTokenStream(lexer);
        var parser = new TscnParser(tokens)
        {
            BuildParseTree = true
        };
        parser.AddErrorListener(new ErrorListener());
        var tree = run(parser);
        //var listener = new TListener();
        //ParseTreeWalker.Default.Walk(listener, tree);
        //return listener;
        return tree;
    }
}

public class ErrorListener : BaseErrorListener
{
    public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
    {
        throw new Exception(msg, e);
    }
}

public class SyntaxErrorListener : IAntlrErrorListener<int>
{
    public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
    {
        throw new Exception(msg, e);
    }
}
