using GooglePlacesApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Places.Helpers.Collections
{
    public class MultiSelectCollection<T> : GooglePlacesApi.NotifyPropertyBase
            where T : BaseMultiSelect
    {
        private ObservableCollection<T> items;

        private T selected;

        public MultiSelectCollection()
        {
            this.items = new ObservableCollection<T>();
        }

        public MultiSelectCollection(List<T> items)
        {
            this.items = new ObservableCollection<T>(items);
        }


        public ObservableCollection<T> Items
        {
            get
            {
                return items;
            }
            set
            {
                SetProperty<ObservableCollection<T>>(ref items, value);
            }
        }

        public T Selected
        {
            get
            {
                return selected;
            }
            set
            {
                SetProperty<T>(ref selected, value);
            }
        }

        public ObservableCollection<T> SelectedItem()
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Select == true)
                {
                    collection.Add(items[i]);
                }
            }

            return collection;
        }


    }
}
