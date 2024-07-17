using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static 點餐.MenuModel;

namespace 點餐
{
    internal class KeyValueModel
    {
        public String Key { get; set; }
        public Strategy Value { get; set; }
        public string V { get; }

        public KeyValueModel(String Key, Strategy Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        public KeyValueModel(string v)
        {
            V = v;
        }
    }
}
