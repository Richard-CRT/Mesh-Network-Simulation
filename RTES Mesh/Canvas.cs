using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTES_Mesh
{
    public partial class Canvas : UserControl
    {
        public const int NodeSize = 10;
        public const int NodeRange = 70;
        public const double TransmissionSpeed = 0.15; // Pixels per Millisecond

        public List<Node> Nodes = new List<Node>();

        public Canvas()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            InitializeComponent();

            for (int y = 100; y <= 300; y += 50)
            {
                for (int x = 100; x <= 300; x += 50)
                {
                    Nodes.Add(new Node(this, x, y));
                }
            }
        }

        public void Broadcast()
        {
            Broadcast bc = new Broadcast(DateTime.UtcNow);
            bc.CommandId = Utilities.GenerateCommandId();
            bc.TargetId = 24;
            Nodes[0].ProcessedSendCommandIds.Add(bc.CommandId);
            Nodes[0].OutwardBroadcasts.Add(bc);
        }

        public List<Node> GetNotesWithinDistanceFromNode(Node node, double distance)
        {
            List<Node> nodesWithinDistance = new List<Node>();
            foreach (Node otherNode in Nodes)
            {
                if (node != otherNode)
                {
                    double distanceToOtherNode = Math.Sqrt(
                        ((otherNode.X - node.X) * (otherNode.X - node.X))
                        +
                        ((otherNode.Y - node.Y) * (otherNode.Y - node.Y))
                        );
                    if (distanceToOtherNode <= distance)
                    {
                        nodesWithinDistance.Add(otherNode);
                    }
                }
            }
            return nodesWithinDistance;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen nodeOutlinePen = new Pen(Color.Black, 2))
            using (SolidBrush nodeFillPen = new SolidBrush(Color.White))
            using (Pen broadcastSendOutlinePen = new Pen(Color.Blue, 2))
            using (Pen broadcastReturnOutlinePen = new Pen(Color.Red, 2))
            using (SolidBrush nodeRangeFillBrush = new SolidBrush(Color.FromArgb(60, 255, 255, 0)))
            {
                // Range
                for (int nodeIndex = 0; nodeIndex < Nodes.Count; nodeIndex++)
                {
                    Node node = Nodes[nodeIndex];

                    RectangleF nodeRangeRect = new RectangleF(node.X - NodeRange, node.Y - NodeRange, NodeRange * 2, NodeRange * 2);
                    e.Graphics.FillEllipse(nodeRangeFillBrush, nodeRangeRect);
                }

                // Nodes
                for (int nodeIndex = 0; nodeIndex < Nodes.Count; nodeIndex++)
                {
                    Node node = Nodes[nodeIndex];

                    RectangleF nodeRect = new RectangleF(node.X - (NodeSize / 2f), node.Y - (NodeSize / 2f), NodeSize, NodeSize);
                    e.Graphics.FillEllipse(nodeFillPen, nodeRect);
                    e.Graphics.DrawEllipse(nodeOutlinePen, nodeRect);

                    // Broadcasts
                    for (int broadcastIndex = 0; broadcastIndex < node.OutwardBroadcasts.Count; broadcastIndex++)
                    {
                        Broadcast broadcast = node.OutwardBroadcasts[broadcastIndex];

                        RectangleF broadcastRect = new RectangleF(node.X - (float)broadcast.BroadcastDistance, node.Y - (float)broadcast.BroadcastDistance, (float)broadcast.BroadcastDistance * 2, (float)broadcast.BroadcastDistance * 2);
                        if (broadcast.Direction == BroadcastDirection.Send)
                        {
                            e.Graphics.DrawEllipse(broadcastSendOutlinePen, broadcastRect);
                        }
                        else if (broadcast.Direction == BroadcastDirection.Return)
                        {
                            e.Graphics.DrawEllipse(broadcastReturnOutlinePen, broadcastRect);
                        }
                    }
                }
            }
        }

        private void TimerTick_Tick(object sender, EventArgs e)
        {
            for (int nodeIndex = 0; nodeIndex < Nodes.Count; nodeIndex++)
            {
                Node node = Nodes[nodeIndex];

                node.Tick();
            }

            this.Refresh();
        }

        private Node draggingNode = null;

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Node node in Nodes)
            {
                if (e.X >= node.X - (NodeSize / 2f)
                    && e.X < node.X + (NodeSize / 2f)
                    && e.Y >= node.Y - (NodeSize / 2f)
                    && e.Y < node.Y + (NodeSize / 2f)
                    )
                {
                    draggingNode = node;
                }
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            draggingNode = null;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggingNode != null)
            {
                draggingNode.X = e.X;
                draggingNode.Y = e.Y;
            }
        }
    }
}
