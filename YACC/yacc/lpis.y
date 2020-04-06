%{

#include<stdio.h>

%}

%token ID
%token CONST
%token CHAR
%token SEMICOLON
%token ASSIGN PLUS

%%

declaration: line
		| declaration line

line : identifier ASSIGN work SEMICOLON
        ;

work : type
	| type PLUS type

type : identifier
	| CONST
	| CHAR

identifier : ID
        ;


%%

extern int line_no;
extern char *yytext;

int yyerror(s)
char *s;
{
        fprintf(stderr, "%s: at or before '%s', line %d\n", 
                        s, yytext, line_no);
}


main (void) {
    if(yyparse()){
     printf("error"); 
    }
    else {
        printf("good"); 
    }
    getchar();
    }