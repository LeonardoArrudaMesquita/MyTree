using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTree
{
    public class MyTree
    {
        public MyTree(Node root)
        {
            this.root = root;
        }

        public Node root { get; set; }

        public void Add(int val)
        {
            Node newNode = new Node(val);

            if (this.root == null)
            {
                this.root = newNode;
            }
            else
            {
                Node currentRoot = root;

                while (true)
                {
                    Node parent = currentRoot;

                    if (val < currentRoot.val)
                    {
                        currentRoot = currentRoot.left;

                        if (currentRoot == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        currentRoot = currentRoot.right;

                        if (currentRoot == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }
            }
        }

        public void InOrderTraverseTree(Node root)
        {
            if (root != null)
            {
                InOrderTraverseTree(root.left);
                Console.Write(root.val + " ");
                InOrderTraverseTree(root.right);
            }
        }

        public IList<int> InOrderTraverseTreeV2(Node root)
        {
            IList<int> result = new List<int>();
            Stack<Node> stack = new Stack<Node>();
            Node currentNode = root;

            while (currentNode != null || stack.Count != 0)
            {
                while (currentNode != null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                }

                currentNode = stack.Pop();
                result.Add(currentNode.val);
                currentNode = currentNode.right;
            }

            return result;
        }

        public void PreOrderTraverseTree(Node root)
        {
            if (root != null)
            {
                Console.Write(root.val + " ");
                PreOrderTraverseTree(root.left);
                PreOrderTraverseTree(root.right);
            }
        }

        public IList<int> PreOrderTraverseTreeV2(Node root)
        {
            List<int> result = new List<int>();
            Stack<Node> stack = new Stack<Node>();

            while (stack.Count != 0)
            {
                Node currentNode = stack.Pop();
                result.Add(currentNode.val);

                if (currentNode.right != null)
                {
                    stack.Push(currentNode.right);
                }

                if (currentNode.left != null)
                {
                    stack.Push(currentNode.left);
                }
            }

            return result;
        }

        public void PostOrderTraverseTree(Node root)
        {
            if (root != null)
            {
                PostOrderTraverseTree(root.left);
                PostOrderTraverseTree(root.right);
                Console.Write(root.val + " ");
            }
        }

        public Boolean Delete(int val)
        {
            Node currentNode = this.root;
            Node parent = currentNode;
            Boolean isItALeftChild = true;

            // Percorre até chegar o node com o val
            while (currentNode.val != val)
            {
                parent = currentNode;

                if (val < currentNode.val)
                {
                    isItALeftChild = true;
                    currentNode = currentNode.left;
                }
                else
                {
                    isItALeftChild = false;
                    currentNode = currentNode.right;
                }

                if (currentNode == null)
                {
                    return false;
                }
            }

            // Verifica se o node possui algum filho
            // Delete a Leaf
            if (currentNode.left == null && currentNode.right == null)
            {
                if (currentNode == root)
                {
                    this.root = null;
                }
                else if (isItALeftChild)
                {
                    parent.left = null;
                }
                else
                {
                    parent.right = null;
                }
            }
            // Quando temos um filho á esquerda no Node procurado.
            else if (currentNode.right == null)
            {
                if (currentNode == root)
                {
                    this.root = currentNode.left;
                }
                else if (isItALeftChild)
                {
                    parent.left = currentNode.left;
                }
                // Está na direita, não tem filho a direita, pega o pai a direita e seta o filho da esquerda.
                else
                {
                    parent.right = currentNode.left;
                }
            }
            // Quando temos um filho a direita no Node procurado.
            else if (currentNode.left == null)
            {
                if (currentNode == root)
                {
                    this.root = currentNode.right;
                }
                else if (isItALeftChild)
                {
                    parent.left = currentNode.right;
                }
                else
                {
                    // Fix
                    parent.right = currentNode.right;
                }
            }
            // Quando temos dois filhos no Node procurado.
            else
            {
                Node replacement = GetReplacementNode(currentNode);

                if (currentNode == this.root)
                {
                    this.root = replacement;
                }
                else if (isItALeftChild)
                {
                    parent.left = replacement;
                }
                else
                {
                    parent.right = replacement;
                }

                replacement.left = currentNode.left;
            }

            return true;
        }

        private Node GetReplacementNode(Node replacedNode)
        {
            Node replacementParent = replacedNode;
            Node replacement = replacedNode;

            Node currentNode = replacement.right;

            while (currentNode != null)
            {
                replacementParent = replacement;
                replacement = currentNode;
                currentNode = currentNode.left;
            }

            if (replacementParent.left != replacement.right)
            {
                replacementParent.left = replacement.right;
                replacement.right = replacedNode.right;
            }

            return replacement;
        }

        public Node FindNode(int val)
        {
            Node currentNode = this.root;

            while (currentNode.val != val)
            {
                if (val < this.root.val)
                {
                    currentNode = currentNode.left;
                }

                if (val > this.root.val)
                {
                    currentNode = currentNode.right;
                }

                if (currentNode == null)
                {
                    return null;
                }
            }

            return currentNode;
        }

        public int FindSum(Node root)
        {
            if (root == null)
                return 0;

            return root.val + FindSum(root.left) + FindSum(root.right);
        }
    }
}
