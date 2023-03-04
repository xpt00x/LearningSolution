using Practice.Core.Interfaces;
using Practice.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculatorRepository _calculatorRepository;

        public CalculatorService(ICalculatorRepository calculatorRepository) {
            _calculatorRepository = calculatorRepository;
        }

        /// <summary>
        /// Calculates the result of an operation with a couple of numbers. If result is null, something went wrong.
        /// </summary>
        /// <param name="a">First number (int)</param>
        /// <param name="b">Second number (int)</param>
        /// <param name="operation">The operation to do ("+","-","/","*")</param>
        /// <returns>The result (int), or null if something wrong.</returns>
        /// <exception cref="InvalidOperationException">For invalid operation.</exception>
        public int? Calculate(int a, int b, string operation)
        {

            int? result = null;
            switch (operation)
            {
                case "+":
                    result = a + b; 
                    break;
                case "-":
                    result = a - b; 
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b; 
                    break;
                default:
                    throw new InvalidOperationException();
            }
            if(result is not null)
            {
                _calculatorRepository.InsertLogInDb(a, b, operation, (int)result);
            }
            //TODO: ADD A LOG TO THE DB ON EACH SUCCESFULL OPERATION

            return result;
        }
    }
}
