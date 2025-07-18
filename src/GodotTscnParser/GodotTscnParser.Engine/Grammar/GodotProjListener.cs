//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from GodotProj.g4 by ANTLR 4.13.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Righthand.GodotTscnParser.Engine.Grammar {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="GodotProjParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.2")]
[System.CLSCompliant(false)]
public interface IGodotProjListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFile([NotNull] GodotProjParser.FileContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFile([NotNull] GodotProjParser.FileContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.section"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSection([NotNull] GodotProjParser.SectionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.section"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSection([NotNull] GodotProjParser.SectionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.sectionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSectionName([NotNull] GodotProjParser.SectionNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.sectionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSectionName([NotNull] GodotProjParser.SectionNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.sectionLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSectionLine([NotNull] GodotProjParser.SectionLineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.sectionLine"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSectionLine([NotNull] GodotProjParser.SectionLineContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.object"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterObject([NotNull] GodotProjParser.ObjectContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.object"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitObject([NotNull] GodotProjParser.ObjectContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.objectProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterObjectProperty([NotNull] GodotProjParser.ObjectPropertyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.objectProperty"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitObjectProperty([NotNull] GodotProjParser.ObjectPropertyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.property"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProperty([NotNull] GodotProjParser.PropertyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.property"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProperty([NotNull] GodotProjParser.PropertyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.propertyValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyValue([NotNull] GodotProjParser.PropertyValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.propertyValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyValue([NotNull] GodotProjParser.PropertyValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.propertyValueArray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyValueArray([NotNull] GodotProjParser.PropertyValueArrayContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.propertyValueArray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyValueArray([NotNull] GodotProjParser.PropertyValueArrayContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.propertyObjectArray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyObjectArray([NotNull] GodotProjParser.PropertyObjectArrayContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.propertyObjectArray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyObjectArray([NotNull] GodotProjParser.PropertyObjectArrayContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.propertyObject"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyObject([NotNull] GodotProjParser.PropertyObjectContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.propertyObject"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyObject([NotNull] GodotProjParser.PropertyObjectContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.simpleObject"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleObject([NotNull] GodotProjParser.SimpleObjectContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.simpleObject"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleObject([NotNull] GodotProjParser.SimpleObjectContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.propertyObjectName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyObjectName([NotNull] GodotProjParser.PropertyObjectNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.propertyObjectName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyObjectName([NotNull] GodotProjParser.PropertyObjectNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.propertyObjectTypeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyObjectTypeName([NotNull] GodotProjParser.PropertyObjectTypeNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.propertyObjectTypeName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyObjectTypeName([NotNull] GodotProjParser.PropertyObjectTypeNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.propertyName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPropertyName([NotNull] GodotProjParser.PropertyNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.propertyName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPropertyName([NotNull] GodotProjParser.PropertyNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.numericStructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumericStructure([NotNull] GodotProjParser.NumericStructureContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.numericStructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumericStructure([NotNull] GodotProjParser.NumericStructureContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.complexValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComplexValue([NotNull] GodotProjParser.ComplexValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.complexValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComplexValue([NotNull] GodotProjParser.ComplexValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.pair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPair([NotNull] GodotProjParser.PairContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.pair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPair([NotNull] GodotProjParser.PairContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.pairName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPairName([NotNull] GodotProjParser.PairNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.pairName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPairName([NotNull] GodotProjParser.PairNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.complexPairName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComplexPairName([NotNull] GodotProjParser.ComplexPairNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.complexPairName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComplexPairName([NotNull] GodotProjParser.ComplexPairNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.complexPair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComplexPair([NotNull] GodotProjParser.ComplexPairContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.complexPair"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComplexPair([NotNull] GodotProjParser.ComplexPairContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue([NotNull] GodotProjParser.ValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue([NotNull] GodotProjParser.ValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GodotProjParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumber([NotNull] GodotProjParser.NumberContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GodotProjParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumber([NotNull] GodotProjParser.NumberContext context);
}
} // namespace Righthand.GodotTscnParser.Engine.Grammar
