using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTES_Mesh
{
    public class Node
    {
        private Canvas ParentCanvas;

        public List<Broadcast> InwardBroadcasts = new List<Broadcast>();
        public List<Broadcast> OutwardBroadcasts = new List<Broadcast>();

        public List<int> ProcessedSendCommandIds = new List<int>();
        public List<int> ProcessedReturnCommandIds = new List<int>();

        public int X;
        public int Y;

        public Node(Canvas _parentCanvas, int _x, int _y)
        {
            this.ParentCanvas = _parentCanvas;
            this.X = _x;
            this.Y = _y;
        }

        public void Tick()
        {
            // Outward Broadcasts
            for (int broadcastIndex = 0; broadcastIndex < this.OutwardBroadcasts.Count;)
            {
                Broadcast broadcast = this.OutwardBroadcasts[broadcastIndex];
                TimeSpan timeSinceBroadcast = DateTime.UtcNow - broadcast.TimeOfInitiation;
                broadcast.BroadcastDistance = Canvas.TransmissionSpeed * timeSinceBroadcast.TotalMilliseconds;

                List<Node> nodesWithinBroadcast;

                if (broadcast.BroadcastDistance <= Canvas.NodeRange)
                {

                    nodesWithinBroadcast = ParentCanvas.GetNotesWithinDistanceFromNode(this, broadcast.BroadcastDistance);

                    broadcastIndex++;
                }
                else
                {

                    nodesWithinBroadcast = ParentCanvas.GetNotesWithinDistanceFromNode(this, Canvas.NodeRange);

                    this.OutwardBroadcasts.RemoveAt(broadcastIndex);
                }

                foreach (Node nodeAlreadyReceived in broadcast.NodesAlreadyReached)
                {
                    nodesWithinBroadcast.Remove(nodeAlreadyReceived);
                }
                foreach (Node newNode in nodesWithinBroadcast)
                {
                    newNode.InwardBroadcasts.Add(broadcast);
                }
                broadcast.NodesAlreadyReached.AddRange(nodesWithinBroadcast);
            }

            // Inward Broadcasts
            for (int broadcastIndex = 0; broadcastIndex < this.InwardBroadcasts.Count;)
            {
                Broadcast broadcast = this.InwardBroadcasts[broadcastIndex];
                this.InwardBroadcasts.RemoveAt(broadcastIndex);

                if (ParentCanvas.Nodes.IndexOf(this) == broadcast.TargetId)
                {
                    if (broadcast.Direction == BroadcastDirection.Send)
                    {
                        this.ProcessedReturnCommandIds.Add(broadcast.CommandId);

                        Broadcast bc = new Broadcast(DateTime.UtcNow);
                        bc.CommandId = broadcast.CommandId;
                        bc.Direction = BroadcastDirection.Return;
                        bc.TargetId = broadcast.SenderId;
                        bc.SenderId = ParentCanvas.Nodes.IndexOf(this);
                        this.OutwardBroadcasts.Add(bc);
                    }
                    else
                    {
                        //
                    }
                }
                else
                {
                    if (broadcast.Direction == BroadcastDirection.Send)
                    {
                        if (!this.ProcessedSendCommandIds.Contains(broadcast.CommandId))
                        {
                            this.ProcessedSendCommandIds.Add(broadcast.CommandId);

                            Broadcast bc = new Broadcast(DateTime.UtcNow);
                            bc.CommandId = broadcast.CommandId;
                            bc.Direction = BroadcastDirection.Send;
                            bc.TargetId = broadcast.TargetId;
                            bc.SenderId = broadcast.SenderId;
                            this.OutwardBroadcasts.Add(bc);
                        }
                    }
                    else if (broadcast.Direction == BroadcastDirection.Return)
                    {
                        if (!this.ProcessedReturnCommandIds.Contains(broadcast.CommandId))
                        {
                            this.ProcessedReturnCommandIds.Add(broadcast.CommandId);

                            Broadcast bc = new Broadcast(DateTime.UtcNow);
                            bc.CommandId = broadcast.CommandId;
                            bc.Direction = BroadcastDirection.Return;
                            bc.TargetId = broadcast.TargetId;
                            bc.SenderId = broadcast.SenderId;
                            this.OutwardBroadcasts.Add(bc);
                        }
                    }
                }
            }
        }
    }
}
