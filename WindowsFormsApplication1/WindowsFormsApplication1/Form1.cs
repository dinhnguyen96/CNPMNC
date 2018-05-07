using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Model1Container db;
        BindingSource bs;

        public Form1()
        {
            InitializeComponent();

            db = new Model1Container();
            bs = new BindingSource();

            bs.DataSource = db.Classes.ToList();

            dataGridView1.DataSource = bs;
            textBox1.DataBindings.Add("Text",bs,"Id");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class c1 = db.Classes.CreateObject();
            c1.Name = "TH1503";

            db.Classes.AddObject(c1);
            db.SaveChanges();
            bs.DataSource = db.Classes.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentCell.Value.ToString());
                Class c1 = db.Classes.SingleOrDefault(c => c.Id == id);
                c1.Name = "TH1504";
                db.SaveChanges();
                bs.DataSource = db.Classes.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Sai roi");
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentCell.Value.ToString());
                Class c1 = db.Classes.SingleOrDefault(c => c.Id == id);
                db.DeleteObject(c1);
                db.SaveChanges();
                bs.DataSource = db.Classes.ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Sai roi");
            }
        }
    }
}
