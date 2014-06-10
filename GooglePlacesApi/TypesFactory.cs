using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GooglePlacesApi
{
    public class TypesFactory
    {
        private string formatedTypes = String.Empty;

        public TypesFactory(params string[] types)
        {
            for (int i = 0; i < types.Count(); i++)
            {
                if(i < types.Count() - 1)
                {
                    formatedTypes += types[i] + "|";
                }
                else
                {
                    formatedTypes += types[i];
                }
            }
        }

        public string CreateType()
        {
            return formatedTypes;
        }
    }
}
