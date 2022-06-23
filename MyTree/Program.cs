using System;
using System.Collections.Generic;

namespace MyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(50);
            Node leftOne = new Node(25);
            Node rightOne = new Node(75);
            
            Node leftTwo = new Node(15);
            Node rightTwo = new Node(30);
            Node rightThree = new Node(85);

            //Node leftThree = new Node(2);
            //Node rightFour = new Node(18);

            root.left = leftOne;
            root.right = rightOne;

            rightOne.right = rightThree;

            leftOne.left = leftTwo;
            leftOne.right = rightTwo;

            //leftTwo.left = leftThree;
            //leftTwo.right = rightFour;

            MyTree tree = new MyTree(root);
            int sum = tree.FindSum(root);
            //tree.InOrderTraverseTree(root);
            //tree.PreOrderTraverseTree(root);
            //tree.PostOrderTraverseTree(root);

            IList<int> preorder = tree.PreOrderTraverseTreeV2(root);
            IList<int> inorder = tree.InOrderTraverseTreeV2(root);
            Node n = tree.FindNode(777);
            tree.Delete(75);
        }
    }
}
