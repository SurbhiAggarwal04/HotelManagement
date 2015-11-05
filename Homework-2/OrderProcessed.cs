using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class OrderProcessed
    {
        private String order;

        public void setBuffer(String orderString)
        {
            if (order == null)
            {

                order = orderString;
                
            }
        }

        public String getBuffer(String name)
        {

            String tempVariable = null;
            
            if (order != null)
            {
                
                if (name.Equals(order))
                {
                    tempVariable = order;
                    order = null;
                }
            }
            return tempVariable;
        }
    }
}
