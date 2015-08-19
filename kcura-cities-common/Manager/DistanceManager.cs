using System.Collections.Generic;
using System.Linq;
using kcura_cities_common.Models;

namespace kcura_cities_common.Manager
{
    public class DistanceManager
    {
        public List<City> Cities { get; set; }


        public List<CityInterstate> GetCityInterstateList()
        {
            var list = new List<CityInterstate>();
            foreach (var city in Cities)
            {
                list.AddRange(city.Interstates.Select(s => new CityInterstate{City = city.Name, Interstate = s}));
            }
            return list;
        }

        public List<CityDistance> GetDistanceFromCity(string city)
        {
            var list = GetCityInterstateList();
            var tree = BuildTree(city, list, 0);
            var nodes = BuildNodeList(tree).OrderBy(o => o.Distance);
            var uniq = new Dictionary<string, CityDistance>();

            foreach (var treeNode in nodes)
            {
                if (!uniq.ContainsKey(treeNode.Name))
                {
                    uniq.Add(treeNode.Name, new CityDistance{Distance = treeNode.Distance, Name = treeNode.Name});
                }
            }

            return uniq.ToList().Select(s => s.Value).OrderBy(o => o.Name).OrderBy(o => o.Distance).ToList();
        }

        private List<TreeNode> BuildNodeList(TreeNode tree)
        {
            var list = new List<TreeNode>();
            list.Add(tree);

            foreach (var treeNode in tree.Kin)
            {
                list.AddRange(BuildNodeList(treeNode));
            }
            
            return list;
        }

        public TreeNode BuildTree(string city, List<CityInterstate> list, int distance)
        {
            var newList = list.Where(w => !w.City.Equals(city)).ToList();
            var interstates = list.Where(w => w.City.Equals(city)).Select(s => s.Interstate);
            var cities = newList.Where(w => interstates.Contains(w.Interstate)).Select(s => s.City).Distinct();
            var r = new TreeNode{Name = city, Kin = new List<TreeNode>(), Distance = distance};

            foreach (var city1 in cities)
            {
                r.Kin.Add(BuildTree(city1, newList, distance + 1));
            }

            return r;
        }
    }
}