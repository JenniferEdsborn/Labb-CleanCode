using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Utilities
{
    public class MenuIterator : IEnumerable<string>
    {
        private readonly string[] menu;

        public MenuIterator(string[] menu)
        {
            this.menu = menu;
        }
        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < menu.Length; i++)
            {
                yield return $"{i + 1}. {menu[i]}";
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
