using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PersistenciaDeObjetos
{
    public partial class PersistForm : Form
    {
        public PersistForm()
        {
            InitializeComponent();
        }      

        private void Form1_Load(object sender, EventArgs e)
        {

        }  
        
        private void bt_persist_Click(object sender, EventArgs e)
        {
            List <User > lista = new List<User>();
            decimal  counter = 0;
            while (counter < 10 )
            {
            //Create e new User using textbox values
            User m_user = new User(group1.Text,
                tx_apellidos.Text ,
                tx_telefono.Text ,
                tx_email.Text );
            lista.Add(m_user);
            counter++;
            }


            System.Xml.Serialization.XmlSerializer x =
                new System.Xml.Serialization.XmlSerializer(lista.GetType());

            x.Serialize(Console.Out, lista);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
