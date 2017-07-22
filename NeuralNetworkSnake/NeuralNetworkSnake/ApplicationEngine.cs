using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkSnake
{
    public class ApplicationEngine
    {
        private static ApplicationEngine _applicationEngineInstance;

        private ApplicationEngine()
        {

        }

        public static ApplicationEngine GetInstance()
        {
            return _applicationEngineInstance = (_applicationEngineInstance ?? new ApplicationEngine());
        }
    }
}
