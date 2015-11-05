using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_2
{
    class MultiCellBuffer
    {
        private String order;

        private Semaphore _pool = new Semaphore(0, 3);


        public void setBuffer(String orderString)
        {

            if (order == null)
            {

                order = orderString;
               
                _pool.WaitOne();

            }
        }

        public String getBuffer(String name)
        {
            String tempVariable = null;
            if (order != null)
            {
               
                if (name.Equals(new Decoder().decode(order).ReceiverId))
                {
                    tempVariable = order;
                    order = null;
                    _pool.Release();
                }


                
            }

            return tempVariable;
        }
    }
}
