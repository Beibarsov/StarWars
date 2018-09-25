using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GK2DZ2
{
    class Program
    {
        public static Workers[] workers = new Workers[2];
        public static WorkersArray _fixworkers = new WorkersArray(3);
        public static WorkersArray _timeworkers = new WorkersArray(3);
        public static WorkersArray _workersall = new WorkersArray(10);





        static void Main(string[] args)
        {
            #region test
            workers[0] = new TimeWorkers("Петя", 0, 5f);
            workers[1] = new FixWorkers("Саша", 500f, 0);
            Console.WriteLine(workers[0].Payment());
            Console.WriteLine(workers[1].Payment());
            Array.Sort(workers);
            Console.WriteLine(workers[0].Payment());
            Console.WriteLine(workers[1].Payment());
            #endregion




            for (int i = 0; i < _fixworkers.Length; i++)
            {
                _fixworkers[i] = new FixWorkers("РаботникФикс" + i, 225 * (i + 1), 0);
            }
            for (int i = 0; i < _timeworkers.Length; i++)
            {
                _timeworkers[i] = new FixWorkers("РаботникПочасово" + i, 0, 10 * i);
            }
            for (int i = 0; i < _workersall.Length / 2; i++)
            {
                _workersall[i] = new FixWorkers("РаботникФикс" + i, 2250 * (i + 1), 0);
            }
            for (int i = _workersall.Length / 2; i < _workersall.Length; i++)
            {
                _workersall[i] = new TimeWorkers("РаботникПочасово" + i, 0, 5 * i);
            }

            //Как заставить это работать?
            //Array.Sort(_fixworkers);

            foreach (Workers el in _workersall)
            {
                Console.Write(el.Name + " " + el.Payment() + "\n");

            }




        }
    }
}





