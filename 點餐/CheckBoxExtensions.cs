using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 點餐
{
    public static class CheckBoxExtensions
    {
        public static int GetPrice(this CheckBox checkBox)
        {
            string text = checkBox.Text;
            string number = Regex.Match(text, @"\d+").Value;
            if (!string.IsNullOrEmpty(number))
            {
                return int.Parse(number);
            }
            return 0;
        }
    }
}
