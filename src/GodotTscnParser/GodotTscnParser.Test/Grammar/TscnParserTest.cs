﻿using System.Collections.Immutable;
using System.Globalization;
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
            [TestCase(".5", 0.5)]
            [TestCase("1.5", 1.5)]
            [TestCase("0", 0.0)]
            [TestCase("1", 1.0)]
            [TestCase("1e5", 1e5d)]
            [TestCase("-0.0358698", -0.0358698)]
            [TestCase("8.74228e-08", 8.74228e-08)]
            [TestCase("-8.74228e-08", -8.74228e-08)]
            public void TestValid(string input, double expected)
            {
                var actual = Return(input, p => p.number());
                Assert.That(double.Parse(actual.NUMBER().GetText(), CultureInfo.InvariantCulture), Is.EqualTo(expected));
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
            [TestCase("bind=[0]")]
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
                var complexValue = actual.complexValue();
                Assert.That(complexValue.GetText(), Is.EqualTo("8"));
                Assert.That(complexValue.ChildCount, Is.EqualTo(1));
                var terminal = (TerminalNodeImpl)complexValue.value().GetChild(0);
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
            [Test]
            public void GivenSampleWithSurfaces_TestsValidity()
            {
                const string input = """
                    [sub_resource type="ArrayMesh" id="ArrayMesh_k3huk"]
                    _surfaces = [{
                    "aabb": AABB(-0.0073892, -0.0178603, -1.98041e-06, 0.0147784, 0.0333918, 0.00987402),
                    "format": 34359742465,
                    "index_count": 1890,
                    "texture": ExtResource("1_d8csi"),
                    "index_data": PackedByteArray("AAABAAIAAwACAAEAAQAEAAM"),
                    "name": &"Material",
                    "primitive": 3,
                    "uv_scale": Vector4(0, 0, 0, 0.0),
                    "vertex_count": 466,
                    "vertex_data": PackedByteArray("FAavO9/33Ls20Mo7y+qE")
                    }]
                    _data = {
                    &"Animation_FadeIn": SubResource("Animation_xbkcy"),
                    &"Animation_FadeOut": SubResource("Animation_e5sew"),
                    &"RESET": SubResource("Animation_51kib")
                    }
                    blend_shape_mode = 0
                    """;

                var actual = Return(input, p => p.subResource());

                Assert.That(actual.pair().Length, Is.EqualTo(2));
            }
            
            [Test]
            public void GivenSampleWithNode_TestsValidity()
            {
                const string input =
                    """
                    [node name="road_tile_1x1_012" type="MeshInstance3D" parent="."]
                    transform = Transform3D(100, 0, 0, 0, -1.19209e-05, 100, 0, -100, -1.19209e-05, 0, 0, 0)
                    mesh = SubResource("ArrayMesh_hc558")
                    skeleton = NodePath("")
                    surface_material_override/0 = ExtResource("3_e2ilv")
                    """;

                var actual = Return(input, p => p.node());

                Assert.That(actual.complexPair().Length, Is.EqualTo(7));
            }

            [Test]
            public void GivenSampleWithEscapedQuotes_TestsValidity()
            {
                const string input =
                    """
                    [node name="Foo" type="Node"]
                    foo = "Foo \"Bar\" Baz"
                    bar = "This is a
                    multiline string with \"escaped quotes\"
                    on multiple lines"
                    """;

                var actual = Return(input, p => p.node());

                Assert.That(actual.complexPair().Length, Is.EqualTo(4));
            }

            [Test]
            public void GivenSampleWithConnection_TestsValidity()
            {
                const string input =
                    """
                    [connection signal="pressed" from="CenterContainer/PanelContainer/MarginContainer/VBoxContainer/Settings" to="SettingsPannelContainer" method="set_mouse_filter" binds= [0]]
                    """;

                var actual = Return(input, p => p.connection());

                Assert.That(actual.pair().Length, Is.EqualTo(5));
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
        public class ComplexValueArray : TscnParserTest
        {
            [TestCase("[ ]")]
            [TestCase("[{ }]")]
            [TestCase("[{ \"duration\": 1.0 }]")]
            [TestCase("[{ \"duration\": 1.0 }, { \"duration\": 2.0 }]")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.complexValueArray()));
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
        public class Predicate : TscnParserTest
        {
            [TestCase("Vector2(0.5, 0.5)")]
            [TestCase("Transform3D(-1, 0, 8.74228e-08, 0, 1, 0, -8.74228e-08, 0, -1, 76.122, 0, -170)")]
            [TestCase("PoolRealArray( 0, 1, -0.0358698, -0.829927, 0.444204, 0, 0, 0, 1, 0.815074, 0.815074, 0.815074, 4.95833, 1, -0.0358698, -0.829927, 0.444204, 0, 0, 0, 1, 0.815074, 0.815074, 0.815074 )")]
            public void TestValid(string input)
            {
                Assert.DoesNotThrow(() => Run(input, p => p.predicate()));
            }
        }
        [TestFixture]
        public class File: TscnParserTest
        {
            [TestCase(GrammarTscnSamples.First)]
            [TestCase(GrammarTscnSamples.Second)]
            [TestCase(GrammarTscnSamples.Third)]
            [TestCase(GrammarTscnSamples.Fourth)]
            [TestCase(GrammarTscnSamples.AdventureScene)]
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

        [TestFixture]
        public class ComplexValue : TscnParserTest
        {
            [Test]
            public void GivenNumericArrayWithSingleNumber_ExtractsValueProperly()
            {
                var actual = Return("[14]", p => p.complexValue());

                var complexValueArray = actual.complexValueArray();
                Assert.That(complexValueArray, Is.Not.Null);
                Assert.That(complexValueArray.ChildCount, Is.EqualTo(3));
                var complexValue = complexValueArray.complexValue();
                Assert.That(complexValue.Length, Is.EqualTo(1));
                var number = complexValue[0].value().NUMBER();
                Assert.That(number.GetText(), Is.EqualTo("14"));
            }

            [Test]
            public void GivenStrongTypedDictionary_ExtractsValueProperly()
            {
                var source = """
                             Dictionary[String, int]({
                             "hello": 0
                             })
                             """;

                var actual = Return(source, p => p.complexValue());

                var predicate = actual.predicate();
                Assert.That(predicate, Is.Not.Null);
                var genericType = predicate.genericType();
                Assert.That(genericType, Is.Not.Null);
                var key = genericType.KEY();
                Assert.That(key.GetText(), Is.EqualTo("Dictionary"));
                var types = genericType.genericType();
                Assert.That(types.Length, Is.EqualTo(2));
                var typeNames = types.Select(t => t.KEY().GetText()).ToImmutableArray();
                ImmutableArray<string> expectedTypeNames = ["String", "int"];
                Assert.That(typeNames, Is.EquivalentTo(expectedTypeNames));
            }
            
            [Test]
            public void GivenStrongTypedDictionaryWithAKeyedIntValue_DoesNotThrow()
            {
                var source = """
                             Dictionary[int, Texture2D]({
                                0: ExtResource("2_3qjaq")
                             })
                             """;

                Assert.DoesNotThrow(() => Return(source, p => p.complexValue()));
            }
            
            [Test]
            public void GivenStrongTypedDictionaryWithKeyedIntValues_DoesNotThrow()
            {
                var source = """
                             Dictionary[int, Texture2D]({
                                0: ExtResource("2_3qjaq"),
                                 1: ExtResource("3_ay11t"),
                                 2: ExtResource("4_q12rb")
                             })
                             """;

                Assert.DoesNotThrow(() => Return(source, p => p.complexValue()));
            }
            
            [Test]
            public void GivenStrongTypedArray_ExtractsValueProperly()
            {
                var source = """Array[ExtResource("6_tabqk")]([])""";

                var actual = Return(source, p => p.complexValue());

                var predicate = actual.predicate();
                Assert.That(predicate, Is.Not.Null);
                var genericType = predicate.genericType();
                Assert.That(genericType, Is.Not.Null);
                var key = genericType.KEY();
                Assert.That(key.GetText(), Is.EqualTo("Array"));
                var types = genericType.genericType();
                Assert.That(types.Length, Is.EqualTo(1));
                var type = types[0];
                Assert.That(type.extResourceRef(), Is.Not.Null);
            }
        }

        [TestFixture]
        public class Editable : TscnParserTest
        {
            [Test]
            public void GivenSimpleEditableLine_ParsesCorrectly()
            {
                const string input = """
                    [editable path="UiRoot/Menu2/MarginContainer/VBoxContainer/BreakItem"]
                    """;

                var actual = Return(input, p => p.editable());

                var pair = actual.pair().Single();

                Assert.That(pair.pairName().GetText(), Is.EqualTo("path"));
                Assert.That(pair.complexValue().GetText(), Is.EqualTo("\"UiRoot/Menu2/MarginContainer/VBoxContainer/BreakItem\""));
            }
        }
    }
}
