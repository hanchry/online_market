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
        private Diference _diference;
        public Calculator(IItemIdReader itemReader, ICityReader cityReader)
        {
            data = new AlbionData(itemReader);
            _diference = new Diference(data, cityReader);
            Thread newThread = new Thread(data.BiggestDifference);
            newThread.Start();
        }

        public Result getBestOf(int tier, bool isSafe)
        {
            return _diference.HighestDiferenceOf(tier, isSafe);
        }

        
        
        
    }
}