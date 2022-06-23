using System;
namespace MyTree
{
    public class Node
    {
        public Node(int val)
        {
            this.val = val;
        }

        public int val { get; set; }
        public Node right { get; set; }
        public Node left { get; set; }
    }
}
