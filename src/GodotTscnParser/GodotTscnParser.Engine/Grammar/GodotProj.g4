grammar GodotProj;

file: (COMMENT | EOL)* 'config_version' '=' NUMBER (COMMENT | EOL)* section*;

section:
	START_BRACKET sectionName END_BRACKET EOL+ sectionLine*
	;

sectionName: 
    KEY
    ;

sectionLine:
    EOL
    | COMMENT
    | complexPair (COMMENT | EOL)
    ;

object: 
    '{' objectProperty (COMMA objectProperty)* '}'
	| '{' (COMMENT | EOL)* '}'
	;

objectProperty:
    (COMMENT | EOL)* property (COMMENT | EOL)*
    ;

property: 
	propertyName ':' propertyValue
	;

propertyValue:
    object
    | propertyValueArray
    | propertyObjectArray
	| numericStructure
	| value
    ;

propertyValueArray:
	START_BRACKET propertyValue (COMMA propertyValue)* END_BRACKET
	| START_BRACKET END_BRACKET
	;


propertyObjectArray:
    START_BRACKET EOL* propertyObject (EOL* COMMA EOL* propertyObject)* EOL* END_BRACKET
    ;

propertyObject:
    propertyObjectTypeName '(' propertyObjectName (COMMA property)* ')'  // assumes object has at least one property
    ;

simpleObject:
	propertyObjectTypeName '(' propertyValue (COMMA propertyValue)* ')'
	| propertyObjectTypeName '(' ')'
	;

propertyObjectName:
    KEY
    | STRING
    ;

propertyObjectTypeName:
    KEY
    ;

propertyName:
	STRING
	;

numericStructure:
	KEY '(' NUMBER (',' NUMBER)+ ')'
	;

complexValue: 
    object                  // { ... }
	| simpleObject			// PackedStringArray("4.0")
    | propertyObject        // Object(InputEventKey,"resource_local_to_scene":false...
	| numericStructure
	| value
    ;

pair: 
	pairName '=' value 
	;

pairName:
	KEY
	;

complexPairName:
	KEY ('/' KEY)+	// i.e. surfaces/0 or bones/0/parent
	| KEY
	;

complexPair: 
	complexPairName '=' complexValue
	;

value:
	NUMBER 
	| STRING 
	| 'true' 
	| 'false'
	| 'null'
	;
KEY: 
	[a-zA-Z_][a-zA-Z_0-9]*
	;

// for testing
number: 
	NUMBER ;

NUMBER: 
	'-'? INT
	| '-'? FLOAT 
	;

fragment FLOAT: 	INT+ '.' INT* // match 1. 39. 3.14159 etc...
	|  	'.' INT+ // match .1 .14159
	;

fragment INT : '0' | [1-9] [0-9]* ;

COMMA: ',' ;
START_BRACKET: '[' ;
END_BRACKET: ']' ;
STRING: '"' ( ~["\\] | '\\' . )* '"' ;
// comments are not supported
COMMENT: ';' .*? EOL ; // Match ";" stuff '\n'
EOL: '\r\n' | '\r' | '\n' ;
WS : [ \t]+ -> skip ; // skip spaces, tabs, newlines