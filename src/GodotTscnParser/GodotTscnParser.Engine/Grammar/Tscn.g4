grammar Tscn;

file: fileDescriptor extResource* subResource* node* connection* editable*; // assumes order of nodes

fileDescriptor: 
	START_BRACKET 'gd_scene' pair+ END_BRACKET
	;
extResource:
	START_BRACKET 'ext_resource' pair+ END_BRACKET
	;
subResource:
	START_BRACKET 'sub_resource' pair+ END_BRACKET complexPair*
	;

node: 
	START_BRACKET 'node' complexPair+ END_BRACKET complexPair*
	;

connection: 
	START_BRACKET 'connection' pair+ END_BRACKET
	;

editable:
	START_BRACKET 'editable' pair+ END_BRACKET
	;

object: 
	'{' property (COMMA property)* '}'
	| '{' '}'
	;

property: 
	(propertyName | ref | key) ':' complexValue
	;

propertyName:
	STRING
	;

extResourceRef: 
	'ExtResource' '(' resourceRef ')'
	;
subResourceRef: 
	'SubResource' '(' resourceRef ')'
	;
nodePath:
	'NodePath' '(' resourceRef ')'
	;
ref: 
	'&' propertyName
	;

key
    : NUMBER
    ;

resourceRef:
	STRING
	| NUMBER // here it is actually an INT, but it's not important
	;

complexValue: 
    object
    | complexValueArray
	| extResourceRef
	| subResourceRef
	| nodePath
	| predicate
	| value
    ;

emptyArray: 
    START_BRACKET END_BRACKET
    ;

complexValueArray:
	START_BRACKET complexValue (COMMA complexValue)* END_BRACKET
	| START_BRACKET END_BRACKET
	;

pair: 
	pairName '=' complexValue 
	;

pairName:
	KEY
	;

complexPairName:
	KEY
	;

complexPair: 
	complexPairName '=' complexValue
	;

predicate
	: KEY '(' complexValue (COMMA complexValue)* ')'
	| genericType '(' complexValue (COMMA complexValue)* ')'
	| KEY '(' ')'
	;

value:
	NUMBER 
	| STRING 
	| ref
	| 'true' 
	| 'false'
	| 'null'
	;
	
genericType
    : KEY
    | KEY START_BRACKET genericType (COMMA genericType)* END_BRACKET
    | extResourceRef
    ;

KEY:
	[a-zA-Z_][a-zA-Z_0-9/]*
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
	| 	INT+ '.'? INT* 'e' '-'? INT+ // match 1. 39. 3.14159e-10 etc...
	;

fragment INT : '0' | [1-9] [0-9]* ;

COMMA: ',' ;
START_BRACKET: '[' ;
END_BRACKET: ']' ;
STRING: '"' ( ~["\\] | '\\' . )* '"' ;
// comments are not supported
//COMMENT: ';' .*? EOL ; // Match ";" stuff '\n'
//EOL: '\r\n' | '\r' | '\n' ;
WS : [ \t\r\n]+ -> skip ; // skip spaces, tabs, newlines
