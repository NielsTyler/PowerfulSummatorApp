﻿using SumCalculator.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumCalculator.Application.SumAlgorighms
{
    public class EvenNumbersSumCalculator : IIntSumCalculator
    {
        public int Sum(int[] array)
        {
            return array.Where(a => (a % 2) == 0).Sum();
        }
    }
}
