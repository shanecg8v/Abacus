using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abacus
{
    static class Calculate
    {
        static private double Add(double currNum, double preNum)
        {
            return currNum + preNum;
        }
        static private double Cut(double currNum, double preNum)
        {
            return preNum - currNum;
        }

        static public double Calc(double currNum, double preNum, OperatorEnum opEnum)
        {
            switch (opEnum)
            {
                case OperatorEnum.a:
                    return Add(currNum, preNum);
                case OperatorEnum.b:
                    return Cut(currNum, preNum);
                default:
                    return 0;
            }
        }
    }
}
