using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class GoogleApiKeyTable
    {
        private Dictionary<int, string> keys = new Dictionary<int, string>();
        private int maxLength;
        private string currentKey;

        public GoogleApiKeyTable(params string[] yourKeys)
        {
            for (int i = 0; i < yourKeys.Count(); i++)
            {
                var indexItem = i + 1;
                keys.Add(indexItem, yourKeys[i]);
            }
            maxLength = yourKeys.Count();
        }

        public string GetKey()
        {
            var keyGenerator = new Random();
            int index = keyGenerator.Next(1, maxLength+1);
            currentKey = keys[index];
            return currentKey;
        }

        public void RemoveKey()
        {
           var item = keys.FirstOrDefault(predicate => predicate.Value == currentKey);
           keys.Remove(item.Key);
        }
    }
}
