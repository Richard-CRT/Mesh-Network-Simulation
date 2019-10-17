using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTES_Mesh
{
    public enum BroadcastDirection { Send, Return };

    public class Broadcast
    {
        public DateTime TimeOfInitiation;
        public List<Node> NodesAlreadyReached = new List<Node>();
        public int CommandId;
        public double BroadcastDistance;
        public BroadcastDirection Direction;
        public int TargetId;
        public int SenderId;

        public Broadcast(DateTime _timeOfInitiation)
        {
            this.TimeOfInitiation = _timeOfInitiation;
        }
    }
}
