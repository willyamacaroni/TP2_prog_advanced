using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tp2_A20
{
    public class NodeSorter : System.Collections.IComparer
    {
        public NodeSorter() {}
        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            string s1 = tx.Text.Substring(tx.Text.Length - 2).Trim();
            int n1 = Convert.ToInt32(s1);

            string s2 = ty.Text.Substring(ty.Text.Length - 2).Trim();
            int n2 = Convert.ToInt32(s2);

            return n2.CompareTo(n1);
        }
    }
}
