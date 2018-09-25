using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK2DZ2
{
    class WorkersArray : IEnumerator, IEnumerable
    {
        public Workers[] workers;

        private int _index = -1;


        public WorkersArray(int lenght)
        {
            workers = new Workers[lenght];
        }

        public Workers this[int indexer]
        {
            get { return workers[indexer]; }
            set { workers[indexer] = value; }
        }


        public float Payment(int indexer)
        {
            return workers[indexer].Payment();
        }

        public int Length
        {
            get { return workers.Length; }
        }
        /// <summary>
        /// Для INumerable
        /// </summary>
        /// <returns>this</returns>
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        /// <summary>
        /// IEnumerator, возвращает текущий объект (элемент массива)
        /// </summary>
        public object Current
        {
            get { return workers[_index]; }
        }


        /// <summary>
        /// IEnumerator, делает _index++ если это возможно. Если нет - сбрасывает _index на предыдущее значение.
        /// </summary>
        /// <returns>True если всё хорошо, false если нет</returns>
        public bool MoveNext()
        {
            if (_index == workers.Length - 1)
            {
                Reset();
                return false;
            }
            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }






    }
}
