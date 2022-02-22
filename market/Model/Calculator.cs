using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Algorithm.Data;
using Algorithm.Model;
using Database.Persistance.Readers;
using Database.Persistance.Readers.Implemented;

namespace market.Model
{
    public class Calculator
    {

        private AlbionData data;
        public Calculator(IItemIdReader itemReader)
        {
            data = new AlbionData(itemReader);
            Thread newThread = new Thread(new ThreadStart(data.BiggestDifference));
            newThread.Start();
        }
        

        
        
        
    }
}