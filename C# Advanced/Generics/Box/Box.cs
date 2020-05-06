using System;
using System.Collections.Generic;
using System.Text;

namespace Box
{
    public class Box<TItem>
        where TItem: IComparable<TItem>
    {
        private List<TItem> boxCollection;
        public Box()
        {
            this.boxCollection = new List<TItem>();
        }
        public void Add(TItem item)
        {
            this.boxCollection.Add(item);
        }
        public int CountGreater { get; private set; }
        public void Compare(TItem item)
        {
            
            foreach (var currentItem in boxCollection)
            {
                if(currentItem.CompareTo(item)>0)
                {
                    this.CountGreater++;
                }
            }
        }
        public void Swap(int x, int y)
        {
            TItem tempValue = this.boxCollection[x];
            this.boxCollection[x] = this.boxCollection[y];
            this.boxCollection[y] = tempValue;

        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var text in this.boxCollection)
            {
                sb.AppendLine($"{text.GetType().FullName}: {text}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
