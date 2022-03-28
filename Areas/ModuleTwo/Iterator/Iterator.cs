using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Iterator
{
    /// <summary>
    /// The 'Aggregate' abstract class
    /// </summary>
    public interface AbstractIterator
    {
        object First();
        object Next();
        bool IsCompleted { get; }
    }
    class Iterator : AbstractIterator
    {
        public List<object> myList;
        public int current = 0;
        public int step = 1;
        // Constructor
        public Iterator(List<object> myList)
        {
            this.myList = myList;
        }
        // Gets first item
        public object First()
        {
            current = 0;
            return myList[current];
        }
        // Gets next item
        public object Next()
        {
            current += step;
            if (!IsCompleted)
            {
                return myList[current];
            }
            else
            {
                return null;
            }
        }
        // Check whether iteration is complete
        public bool IsCompleted
        {
            get { return current >= myList.Count; }
        }
    }

}

