using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT2BOT
{
    public class MyProcess
    {

        public string ProcessName { get; set; }
        public int ProcessId { get; set; }

        public MyProcess(string name , int id){
            ProcessName = name;
            ProcessId = id;
}
    }
}
