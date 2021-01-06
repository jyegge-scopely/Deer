grammar Deer;

module
: statement*
;

statement
: assignment
;

assignment
: IDENTIFIER EQUALS (IDENTIFIER | NUMBER)
;

EQUALS : '=';

NUMBER : [0-9]+;
IDENTIFIER : [_a-zA-Z][_a-zA-Z0-9]*;

NEWLINE   : '\n' -> skip;

WS         : [ \r\t\u000C\n]+ -> skip;