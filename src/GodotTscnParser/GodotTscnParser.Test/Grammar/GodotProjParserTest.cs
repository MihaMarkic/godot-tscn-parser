using System.Collections.Immutable;
using Antlr4.Runtime;
using GodotTscnParser.Test.Grammar.Samples;
using NUnit.Framework;
using Righthand.GodotTscnParser.Engine.Grammar;

namespace GodotTscnParser.Test.Grammar
{
    internal class GodotProjParserTest : Bootstrap<GodotProjParser, GodotProjLexer, GodotProjBaseListener>
    {
        protected override GodotProjLexer CreateLexer(AntlrInputStream? stream) => new GodotProjLexer(stream);
        protected override GodotProjParser CreateParser(CommonTokenStream? stream) => new GodotProjParser(stream);
        [TestFixture]
        public class PropertyObject : GodotProjParserTest
        {
            [TestCase("Object(InputEventKey,\"resource_local_to_scene\":false)")]
            [TestCase("Object(InputEventKey,\"resource_local_to_scene\":false,\"resource_name\":\"\",\"device\":0,\"window_id\":0,\"alt_pressed\":false,\"shift_pressed\":false,\"ctrl_pressed\":false,\"meta_pressed\":false,\"pressed\":false,\"keycode\":0,\"physical_keycode\":4194319,\"key_label\":0,\"unicode\":0,\"echo\":false,\"script\":null)")]
            public void GivenSample_DoesNotThrow(string input)
            {
                Run(input, p => p.propertyObject());
            }
        }
        [TestFixture]
        public class SimpleObject: GodotProjParserTest
        {
            [TestCase("PackedStringArray(\"4.0\", \"C#\", \"Mobile\")")]
            public void GivenSample_DoesNotThrow(string input)
            {
                Run(input, p => p.simpleObject());
            }
        }
        [TestFixture]
        public class SectionLine: GodotProjParserTest
        {
            [TestCase(GrammarGodotProjSamples.Test)]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.section()));
            }
        }
        [TestFixture]
        public class Object: GodotProjParserTest
        {
            [TestCase("{ }")]
            [TestCase("{ \r\n }")]
            [TestCase("{ ; test comment \r\n }")]
            [TestCase("{ \"value\": 5 }")]
            [TestCase("{ ; test comment \r\n \"value\": 5 }")]
            [TestCase("{ \"value\": 5, \"other\": \"alpha\" }")]
            [TestCase("{ \"events\": [] }")]
            public void GivenSample_DoesNotThrow(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.@object()));
            }
            [Test]
            public void GivenMoreComplexInput_DoesNotThrow()
            {
                const string input = """
                    {
                    "deadzone": 0.5,
                    "events": [Object(InputEventKey,"resource_local_to_scene":false,"resource_name":"","device":0,"window_id":0,"alt_pressed":false,"shift_pressed":false,"ctrl_pressed":false,"meta_pressed":false,"pressed":false,"keycode":0,"physical_keycode":65,"key_label":0,"unicode":0,"echo":false,"script":null)
                    , Object(InputEventKey,"resource_local_to_scene":false,"resource_name":"","device":0,"window_id":0,"alt_pressed":false,"shift_pressed":false,"ctrl_pressed":false,"meta_pressed":false,"pressed":false,"keycode":0,"physical_keycode":4194319,"key_label":0,"unicode":0,"echo":false,"script":null)
                    , Object(InputEventJoypadButton,"resource_local_to_scene":false,"resource_name":"","device":0,"button_index":14,"pressure":0.0,"pressed":false,"script":null)
                    , Object(InputEventJoypadMotion,"resource_local_to_scene":false,"resource_name":"","device":0,"axis":0,"axis_value":-1.0,"script":null)
                    ]
                    }
                    """;
                Assert.DoesNotThrow(() => Run(input, p => p.@object()));
            }

        }
        [TestFixture]
        public class File : GodotProjParserTest
        {
            [TestCase(GrammarGodotProjSamples.First)]
            [TestCase(GrammarGodotProjSamples.DodgeTheCreeps)]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.file()));
            }
        }
        [TestFixture]
        public class Section : GodotProjParserTest
        {
            [Test]
            public void GivenSimpleSection_ParsesCorrectly()
            {
                const string input = """
                    [input]
    
                    move_left={
                    }
    
                    """;

                var actual = Return(input, p => p.section());
            }
            [Test]
            public void WhenInputSection_ExtractsPropertyNames()
            {
                var actual = Return(GrammarGodotProjSamples.Input, p => p.section());

                Assert.That(actual.sectionName().GetText(), Is.EqualTo("input"));
                var lines = actual.sectionLine();
                var query = from l in lines
                            let cp = l.complexPair()
                            where cp is not null
                            select cp.complexPairName().GetText();
                var pairNames = query.ToImmutableArray();
                Assert.That(pairNames, Is.EquivalentTo(new string[] { "move_left", "move_right", "move_up", "move_down", "start_game" }));
            }
        }
    }
}
