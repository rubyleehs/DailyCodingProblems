# Given an iterator with methods next() and hasNext(), create a wrapper iterator, PeekableInterface, which also implements peek(). peek shows the next element that would be returned on next().
# Here is the interface:
#   class PeekableInterface(object):
#    def __init__(self, iterator):
#        pass
#
#    def peek(self):
#        pass
#
#    def next(self):
#        pass
#
#    def hasNext(self):
#        pass

class PeekableInterface(object):
    def __init__(self, iterator):
        self.iterator = iterator
        self.next_val = next(iterator)
        self.has_next_val = True

    def peek(self):
        return self.next_val

    def next(self):
        next_val = self.next_val #storage
        try:
            self.next_val = next(iterator) #try set to next (calling iterator next not class next)
        except StopIteration:
            self.has_next_val = False
            self.next_val = None
        return next_val


     def has_next(self):
        return self.has_next_val

