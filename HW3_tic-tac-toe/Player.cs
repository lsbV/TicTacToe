using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HW3_tic_tac_toe
{
    internal class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IPEndPoint EndPoint { get; set; }
    }
}
