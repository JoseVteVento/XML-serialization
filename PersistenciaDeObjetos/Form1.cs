using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersistenciaDeObjetos
{
    /// <summary>
    /// La siguiente clase, es un ejemplo de persistencia de objetos a formato xml
    /// Para la persistencia, se crea una lista de objetos de tipo User, el cual se almacena 
    /// en un fichero. 
    /// Luego, recupera los objetos desde el fichero, y los representa en pantalla    
    /// </summary>
    public partial class PersistForm : Form
    {        
        private Persist persist;

        public PersistForm()
        {
            persist = new Persist();            
            InitializeComponent();
        }      

        private void Form1_Load(object sender, EventArgs e) { }

        private void bt_persist_Click(object sender, EventArgs e)
        {
            persist.Serializar(tx_nombre.Text, tx_apellidos.Text, tx_telefono.Text, tx_email.Text);
        }       

        private void bt_toUser_Click(object sender, EventArgs e)
        {
            List<User> lista = persist.Deserializar();
            foreach (User item in lista)
            {
                //add the items to the listbox control
                lsb_listadoUsers.Items.Add(item.nombre + " " + item.apellidos + "  Tlf:" +
                    item.telefono + "  e-mail:" + item.email);
            }
        }        
    }
}