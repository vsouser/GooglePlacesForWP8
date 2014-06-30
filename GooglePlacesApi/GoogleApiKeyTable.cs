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
            int index = keyGenerator.Next(1, maxLength);
            currentKey = keys[index];
            return currentKey;
        }


        public string GetOtherKey()
        {
            var keyGenerator = new Random();
            int index = keyGenerator.Next(0, maxLength);
            if (currentKey.Equals(keys[index]) == true)
            {
                return GetOtherKey();
            }
            else
            {
                currentKey = keys[index];
                return currentKey;
            }
        }
    }
}
