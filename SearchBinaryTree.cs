using System;
using System.Collections.Generic;
using System.Text;

namespace PrintTree
{
   public class SearchBinaryTree
    {
        public static bool IsSearchBinaryTree(Node root)
        {
            if (root == null)
            {
                return true;
            }

            return (Min(root.Right) > root.Data) && (Max(root.Left) < root.Data);
        }

        private static int Min(Node root)
        {
            //todo write algorithm
            return 0;
        }
        private static int Max(Node root)
        {
            //todo write algorithm
            return 0;
        }
    }
}
