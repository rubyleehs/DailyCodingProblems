//cons(a, b) constructs a pair, and car(pair) and cdr(pair) returns the first and last element of that pair. For example, car(cons(3, 4)) returns 3, and cdr(cons(3, 4)) returns 4.
//Given this implementation of cons:
/*
def cons(a, b):
    def pair(f):
        return f(a, b)
    return pair
}
*/
//Implement car and cdr.

const cons = (a, b) => 
{
    const pair = (f) =>
    {
        return f(a, b);
    }
    return pair;
}

//Not too sure if this is possible in C# so using this as a refresher to JS. Should do a similar thing.

/*
so car/cdr takes in a pair

and pair takes in a function and calls function(a,b)

so car/cdr simply need to give it a function thats takes in 2 inputs and outputs the correct info
*/

const car = (pair) =>
{
    return pair((a, b) => a);
}

const cdr = (pair) =>
{
    return pair((a, b) => b);
}

//print(cons(3,4));
print(car(cons(3, 4)));
print(cdr(cons(3, 4)));