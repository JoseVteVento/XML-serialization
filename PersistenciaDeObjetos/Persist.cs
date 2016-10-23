using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace PersistenciaDeObjetos
{
    class Persist
    {
        private String path;

        public Persist()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
        }

        public void Serializar(string nombre, string apellidos, string telefono, string email)
        {
            List<User> lista = new List<User>();
            decimal counter = 0;
            while (counter < 10)
            {
                //Create e new User using textbox values
                User m_user = new User(
                    nombre,
                    apellidos,
                    telefono,
                    email);
                lista.Add(m_user);
                counter++;
            }

            //Create an object to seaialize the list
            System.Xml.Serialization.XmlSerializer x =
                new System.Xml.Serialization.XmlSerializer(lista.GetType());

            x.Serialize(Console.Out, lista);
            Console.WriteLine();
            Console.ReadLine();

            writeFile(x, lista);
        }

        public List<User> Deserializar()
        {
            List<User> lista = new List<User>();
            //MySerializableClass List<User >;
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer =
            new XmlSerializer(typeof(List<User>));
            // To read the file, create a FileStream.
            FileStream myFileStream =
            new FileStream(path, FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            lista = (List<User>)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();

            return lista;           
        } 

        private void writeFile(System.Xml.Serialization.XmlSerializer writer, List<User> list)
        {
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, list);
            file.Close();
        }        
    }
}
