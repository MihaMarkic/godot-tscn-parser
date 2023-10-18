using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using GodotTscnParser.Test.Grammar.Samples;
using NUnit.Framework;
using Righthand.GodotTscnParser.Engine.Grammar;

namespace GodotTscnParser.Test.Grammar
{
    internal class TscnParserTest : Bootstrap<TscnParser, TscnLexer, TscnBaseListener>
    {
        protected override TscnLexer CreateLexer(AntlrInputStream? stream) => new TscnLexer(stream);
        protected override TscnParser CreateParser(CommonTokenStream? stream) => new TscnParser(stream);
        [TestFixture]
        public class Number: TscnParserTest
        {
            [TestCase(".5")]
            [TestCase("1.5")]
            [TestCase("0")]
            [TestCase("1")]
            [TestCase("-0.0358698")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.number()));
            }
            [TestCase("t")]
            public void TestInvalid(string input)
            {
                Assert.Throws<Exception>(() => Run(input, p => p.number()));
            }
        }

        [TestFixture]
        public class Pair : TscnParserTest
        {
            [TestCase("load_steps=8")]
            [TestCase("load_steps = 8")]
            [TestCase("\tload_steps = 8")]
            [TestCase("format=3")]
            [TestCase("uxid=\"uid://d3doqyggcpkeb\"")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.pair()));
            }
            [TestCase("load_steps=")]
            [TestCase(" = 8")]
            [TestCase("uid=\"uid://d3d")]
            public void TestInvalid(string input)
            {
                Assert.Throws<Exception>(() => Run(input, p => p.pair()));
            }
            [TestCase("load_steps = 8")]
            public void GivenSample_ParsesCorrectly(string input)
            {
                var actual = Return(input, p => p.pair());

                Assert.That(actual.pairName().GetText(), Is.EqualTo("load_steps"));
                var value = actual.value();
                Assert.That(value.GetText(), Is.EqualTo("8"));
                Assert.That(value.ChildCount, Is.EqualTo(1));
                var terminal = (TerminalNodeImpl)value.GetChild(0);
                Assert.That(terminal.Symbol.Type, Is.EqualTo(TscnParser.NUMBER));
            }
        }

        [TestFixture]
        public class FileDescriptor : TscnParserTest
        {
            [Test]
            public void WhenSampleInput_ParsesCorrectly()
            {
                const string input = "[gd_scene load_steps=8 format=3 uid=\"uid://d3doqyggcpkeb\"]";

                var actual = Return(input, p => p.fileDescriptor());

                Assert.That(actual.pair().Length, Is.EqualTo(3));
            }
        }
        [TestFixture]
        public class ExtResource : TscnParserTest
        {
            [Test]
            public void WhenSampleInput_ParsesCorrectly()
            {
                const string input = "[ext_resource type=\"Texture2D\" uid=\"uid://da45skrrq48dj\" path=\"res://art/playerGrey_walk2.png\" id=\"4_jrmwk\"]";

                var actual = Return(input, p => p.extResource());

                Assert.That(actual.pair().Length, Is.EqualTo(4));
            }
        }
        [TestFixture]
        public class SubResource : TscnParserTest
        {
            [Test]
            public void GivenHeaderOnly_ParsesCorrectly()
            {
                const string input = "[sub_resource type=\"SpriteFrames\" id=\"SpriteFrames_707dc\"]";

                var actual = Return(input, p => p.subResource());

                Assert.That(actual.pair().Length, Is.EqualTo(2));
            }
            [Test]
            public void GivenSampleWithEmptyAnimation_TestsValidity()
            {
                const string input = """
                    [sub_resource type="SpriteFrames" id="SpriteFrames_707dc"]
                    animations = []
                    """;

                var actual = Return(input, p => p.subResource());

                Assert.That(actual.pair().Length, Is.EqualTo(2));
            }
            [Test]
            public void GivenSampleWithAnimations_TestsValidity()
            {
                const string input = """
                    [sub_resource type="SpriteFrames" id="SpriteFrames_707dc"]
                    animations = [{
                    	"frames": [
                    		{
                    		"duration": 1.0,
                    		"texture": ExtResource("1_d8csi")
                    		}, 
                    		{
                    		"duration": 1.0,
                    		"texture": ExtResource("2_ljnug")
                    		}
                    	],
                    "loop": true,
                    "name": &"up",
                    "speed": 5.0
                    }, {
                    "frames": [{
                    "duration": 1.0,
                    "texture": ExtResource("3_krmrv")
                    }, {
                    "duration": 1.0,
                    "texture": ExtResource("4_jrmwk")
                    }],
                    "loop": true,
                    "name": &"walk",
                    "speed": 5.0
                    }]
                    """;

                var actual = Return(input, p => p.subResource());

                Assert.That(actual.pair().Length, Is.EqualTo(2));
            }
        }
        [TestFixture]
        public class ExtResourceRef : TscnParserTest
        {
            [TestCase("ExtResource(\"3_krmrv\")")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.extResourceRef()));
            }
        }
        [TestFixture]
        public class Object : TscnParserTest
        {
            [TestCase("{ }")]
            [TestCase("{ \"duration\": 1.0 }")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.@object()));
            }
        }
        [TestFixture]
        public class ObjectArray : TscnParserTest
        {
            [TestCase("[ ]")]
            [TestCase("[{ }]")]
            [TestCase("[{ \"duration\": 1.0 }]")]
            [TestCase("[{ \"duration\": 1.0 }, { \"duration\": 2.0 }]")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.objectArray()));
            }
        }
        [TestFixture]
        public class ComplexPair : TscnParserTest
        {
            [TestCase("key = [ ]")]
            [TestCase("key = [{ }]")]
            [TestCase("key = [{ \"duration\": 1.0 }]")]
            [TestCase("key = [{ \"duration\": 1.0 }, { \"duration\": 2.0 }]")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.complexPair()));
            }
        }
        [TestFixture]
        public class Property : TscnParserTest
        {
            [TestCase("\"key\": 4")]
            [TestCase("\"key\": true")]
            [TestCase("\"key\": [ ]")]
            [TestCase("\"key\": [{ }]")]
            [TestCase("\"key\": [{ \"duration\": 1.0 }]")]
            [TestCase("\"key\": [{ \"duration\": 1.0 }, { \"duration\": 2.0 }]")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.property()));
            }
        }
        [TestFixture]
        public class NumericStructure : TscnParserTest
        {
            [TestCase("Vector2(0.5, 0.5)")]
            [TestCase("PoolRealArray( 0, 1, -0.0358698, -0.829927, 0.444204, 0, 0, 0, 1, 0.815074, 0.815074, 0.815074, 4.95833, 1, -0.0358698, -0.829927, 0.444204, 0, 0, 0, 1, 0.815074, 0.815074, 0.815074 )")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.numericStructure()));
            }
        }
        [TestFixture]
        public class File: TscnParserTest
        {
            [TestCase(GrammarTscnSamples.First)]
            [TestCase(GrammarTscnSamples.Second)]
            [TestCase(GrammarTscnSamples.Third)]
            [TestCase(GrammarTscnSamples.Fourth)]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.file()));
            }
        }
        [TestFixture]
        public class Value: TscnParserTest
        {
            [Test]
            public void GivenRefProperty_ExtractsPropertyName()
            {
                var actual = Return("&\"up\"", p => p.value());

                Assert.That(actual.@ref().propertyName().GetText(), Is.EqualTo("\"up\""));
            }
        }
    }
}
