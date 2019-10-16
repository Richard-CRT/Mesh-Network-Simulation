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
        const int NodeSize = 20;

        List<Node> Nodes = new List<Node>();

        public Canvas()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Nodes.Add(new Node(50, 50));
            Nodes.Add(new Node(150, 60));
            Nodes.Add(new Node(100, 80));
            Nodes.Add(new Node(60, 100));
            Nodes.Add(new Node(70, 140));
            Nodes.Add(new Node(120, 120));
            Nodes.Add(new Node(130, 160));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (Pen nodeOutlinePen = new Pen(Color.Black, 2))
            {
                for (int nodeIndex = 0; nodeIndex < Nodes.Count; nodeIndex++)
                {
                    Node node = Nodes[nodeIndex];
                    RectangleF nodeRect = new RectangleF(node.X - (NodeSize / 2f), node.Y - (NodeSize / 2f), NodeSize, NodeSize);
                    e.Graphics.DrawEllipse(nodeOutlinePen, nodeRect);
                }
            }
        }
    }
}
