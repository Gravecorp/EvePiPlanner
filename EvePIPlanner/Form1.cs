using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvePIPlanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<P4Object> l4 = DBHandler.GetInstance().GetAllP4Objects();
            foreach (P4Object p4 in l4)
            {
                TreeNode p4Node = p4Nodes(p4);
                treeView1.Nodes.Add(p4Node);
            }
            treeView1.ExpandAll();
        }

        private TreeNode p4Nodes(P4Object p4)
        {
            string p4Name = string.Format("{0}: {1}", p4.Type.Value, p4.Name);
            TreeNode ret = new TreeNode(p4Name);
            List<PIObject> l = p4.GetComponents();
            
            foreach (PIObject p in l)
            {
                if (p.Type.Value == PIObject.ObjectType.P3.Value)
                {
                    P3Object pi = (P3Object)p;
                    TreeNode t = p3Nodes(pi);
                    ret.Nodes.Add(t);
                }
                if (p.Type.Value == PIObject.ObjectType.P1.Value)
                {
                    P1Object pi = (P1Object)p;
                    TreeNode t = p1Nodes(pi);
                    ret.Nodes.Add(t);
                }
            }
            return (ret);
        }

        private TreeNode p3Nodes(P3Object p3)
        {
            string p3Name = string.Format("{0}: {1}", p3.Type.Value, p3.Name);
            TreeNode ret = new TreeNode(p3Name);
            List<PIObject> l = p3.GetComponents();

            foreach (PIObject p in l)
            {
                P2Object pi = (P2Object)p;
                TreeNode t = p2Nodes(pi);
                ret.Nodes.Add(t);
            }

            return (ret);
        }

        private TreeNode p2Nodes(P2Object p2)
        {
            string p2Name = string.Format("{0}: {1}", p2.Type.Value, p2.Name);
            TreeNode ret = new TreeNode(p2Name);
            List<PIObject> l = p2.GetComponents();

            foreach (PIObject p in l)
            {
                P1Object pi = (P1Object)p;
                TreeNode t = p1Nodes(pi);
                ret.Nodes.Add(t);
            }

            return (ret);
        }

        private TreeNode p1Nodes(P1Object p1)
        {
            string p1Name = string.Format("{0}: {1}", p1.Type.Value, p1.Name);
            TreeNode ret = new TreeNode(p1Name);
            List<PIObject> l = p1.GetComponents();

            foreach (PIObject p in l)
            {
                RawPIObject pi = (RawPIObject)p;
                TreeNode t = rawNodes(pi);
                ret.Nodes.Add(t);
            }

            return (ret);
        }

        private TreeNode rawNodes(RawPIObject raw)
        {
            string rawName = string.Format("{0}: {1}", raw.Type.Value, raw.Name);
            TreeNode ret = new TreeNode(rawName);
            List<PIObject> l = raw.GetComponents();

            foreach (PIObject p in l)
            {
                //TreeNode t = planetNodes((Planet)p);
                //ret.Nodes.Add(t);
                string planetName = string.Format("{0}: {1}", p.Type.Value, p.Name);
                TreeNode t = new TreeNode(planetName);
                ret.Nodes.Add(t);
            }

            return (ret);
        }

        private TreeNode planetNodes(Planet planet)
        {
            string planetName = string.Format("{0}: {1}", planet.Type.Value, planet.Name);
            TreeNode ret = new TreeNode(planetName);
            return (ret);
        }
    }
}
