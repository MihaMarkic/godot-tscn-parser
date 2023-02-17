grammar Tscn;

fileDescriptor: '[' 'gd_scene' ']' ;
keyValue: KEY '=' VALUE ;

VALUE: [a-zA-Z0-9]+ ;
KEY: [a-zA-Z]+ ;

COMMENT: ';' .*? EOL ; // Match ";" stuff '\n'
EOL: '\r\n' | '\r' | '\n' ;
WS : [ \t]+ -> skip ; // skip spaces, tabs, newlines