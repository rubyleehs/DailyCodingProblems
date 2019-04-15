using System;

namespace DCP_24
{
    /*
    Implement locking in a binary tree. A binary tree node can be locked or unlocked only if all of its descendants or ancestors are not locked.
    Design a binary tree node class with the following methods:
    •	is_locked, which returns whether the node is locked
    •	lock, which attempts to lock the node. If it cannot be locked, then it should return false. Otherwise, it should lock it and return true.
    •	unlock, which unlocks the node. If it cannot be unlocked, then it should return false. Otherwise, it should unlock it and return true.

    You may augment the node to add parent pointers or any other property you would like. 
    You may assume the class is used in a single-threaded program, so there is no need for actual locks or mutexes. Each method should run in O(h), where h is the height of the tree.
    */

    //Havent tested but theoretically should work - coding this during my hour long lunch break and ran out of time. ^^;
    //TODO: Test this - assuming I remember and want to do it >.< 

    public class LockableBinTreeNode
    {
        public string value;
        public bool isLocked = false;
        public int lockedDescendants = 0;

        public BinTreeNode parent;
        public BinTreeNode left;
        public BinTreeNode right;

        public LockableBinTreeNode(string value, LockableBinTreeNode parent)
        {
            this.value = value;
            this.parent = parent;
        }

        public bool Lock()
        {
            if (isLocked) return false; //cannot lock if it's already locked!
            if (lockedDescendants <= 0 && !IsParentsLocked()) //Lock if no descendants or parent are locked
            {
                isLocked = true;
                UpdateParentsDescendants(1);
            }
            else return false;
        }

        public bool Unlock()
        {
            if (!isLocked) return false; //cannot unlock if it's already unlocked!
            if (lockedDescendants > 0 || IsParentsLocked()) return false; //Do not unlock if there is a locked descendant or parent
            else
            {
                isLocked = false;
                UpdateParentsLockedDescendants(-1);
                return true;
            }
        }

        public void UpdateParentsLockedDescendants(int delta)
        {
            if (parent == null) return;

            parent.lockedDescendants += delta;
            parent.UpdateParentsLockedDescendants(delta);
        }

        public bool IsParentsLocked()
        {
            if (parent == null) return false;
            else if (parent.isLocked) return true;
            else return parent.IsParentsLocked();
        }
    }

    public class DCP_22
    {
    }
}
