using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK2DZ2
{
    abstract class Workers : IComparable<Workers>/*, IEnumerator*/
    {
        public string Name { get; set; }
        protected float fixpayment;
        protected float timepayment;

        public Workers(string name, float fixpayment, float timepayment)
        {
            Name = name;
            this.fixpayment = fixpayment;
            this.timepayment = timepayment;
        }

        public abstract float Payment();

        public int CompareTo(Workers other)
        {
            if (this.Payment() > other.Payment())
                return 1;
            if (this.Payment() < other.Payment())
                return -1;
            else return 0;
        }
    }


    class FixWorkers : Workers
    {
        public FixWorkers(string name, float fixpayment, float timepayment) : base(name, fixpayment, 0) { }

        public override float Payment()
        {
            float payment = fixpayment;
            return payment;
        }
    }

    class TimeWorkers : Workers
    {
        public TimeWorkers(string name, float fixpayment, float timepayment) : base(name, 0, timepayment) { }

        public override float Payment()
        {
            float payment = 20.8f * 8 * timepayment;
            return payment;
        }
    }

}

//    class WorkersArray : IEnumerable<WorkersArray>, IEnumerator<WorkersArray>
//    {
//        //public WorkersArray Current => throw new NotImplementedException();

//        //object IEnumerator.Current => throw new NotImplementedException();
//        int index = -1;
//        //public static Workers[] workers = new Workers[20];



//        public IEnumerator<WorkersArray> GetEnumerator()
//        {
//            return this;
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }

//        public bool MoveNext()
//        {
//            if (index == ints.Length - 1)
//            {
//                Reset();
//                return false;
//            }

//            index++;
//            return true;
//        }

//        public void Reset()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
