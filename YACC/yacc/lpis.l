%{
#include <stdio.h>
#include "lpis.tab.h"
int line_no = 1;

%}

%%


[_a-zA-Z]([a-zA-Z0-9\-])*          {printf("Identifier\n");return(ID);}
["].*["]			   {printf("Const string\n");return(CONST);}
['].[']			   	   {printf("Character\n");return(CHAR);}
"="                                {printf("Assigment\n");return(ASSIGN);}
"+"                                {printf("Concatenation\n");return(PLUS);}
";"                                {printf("Semicolon\n");return(SEMICOLON);}


\n                                line_no++;

%%
yywrap ()
{
  return (1);
}