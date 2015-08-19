using System.Collections.Generic;

namespace kcura_cities_common.Models
{
    public class TreeNode
    {
        public string Name { get; set; }
        public List<TreeNode> Kin { get; set; }
        public int Distance { get; set; }
    }
}