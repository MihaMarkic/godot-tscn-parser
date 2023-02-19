namespace Righthand.GodotTscnParser.Engine
{
    public class Parser
    {
        //readonly ImmutableDictionary<int, SyntaxElementType> tokenTypeMap = ImmutableDictionary<int, SyntaxElementType>.Empty
        //    .Add(AcmeLexer.STRING, SyntaxElementType.String)
        //    .Add(AcmeLexer.COMMENT, SyntaxElementType.Comment);
        public TscnParser.FileDescriptorContext GetSyntaxElements(string code)
        {
            var input = new AntlrInputStream(code);
            var lexer = new TscnLexer(input);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new TscnParser(tokenStream)
            {
                BuildParseTree = true
            };
            var tree = parser.fileDescriptor();
            //var listener = new TscnBaseListener();
            //ParseTreeWalker.Default.Walk(listener, tree);

            //var tokens = tokenStream.GetTokens().ToImmutableArray();
            //var result = new Dictionary<int, ImmutableArray<SyntaxElement>>();
            //foreach (var token in tokens)
            //{
            //    if (tokenTypeMap.TryGetValue(token.Type, out var syntaxElementType))
            //    {
            //        if (!result.TryGetValue(token.Line, out var elements))
            //        {
            //            elements = ImmutableArray<SyntaxElement>.Empty;
            //        }
            //        elements = elements.Add(new SyntaxElement(code, syntaxElementType, token.Line, token.StartIndex, token.StopIndex));
            //        result[token.Line] = elements;
            //    }
            //}
            return tree;
        }
    }
}
