using System;

namespace DCP_91
{
    /*
        What does the below code snippet print out? How can we fix the anonymous functions to behave as we'd expect?

        functions = []
        for i in range(10):
            functions.append(lambda : i)

        for f in functions:
            print(f())

    */

    //That is not a question i expected.

    /*
    Declare an array called functions
    > functions = []

    Fill functions array with functions
    > for i in range(10):
    >     functions.append(lambda : i)

    Call functions stored in functions array
    > for f in functions:
    >   print(f())
    */

    //No clue what the original intention is.
    //"lambda : i" should store 0 - 9 in functions. but it's instead creating a function that returns i, so it would return 9, 10 times.
   
    
}