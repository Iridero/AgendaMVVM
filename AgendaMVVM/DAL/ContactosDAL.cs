using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaMVVM.Models;
using MySql.Data.MySqlClient;
namespace AgendaMVVM.DAL
{
    public class ContactosDAL
    {
        private static readonly string cadena =
            "Server=localhost;Database=Agenda;Uid=root;Pwd=root";
        private static MySqlConnection connection;
        static ContactosDAL()
        {
            connection=
                new MySqlConnection(cadena);
            connection.Open();
        }
        public static ObservableCollection<Contacto> Get()
        {
            string query =
                "SELECT * FROM contacto order by nombre";
            MySqlCommand cmd =
                new MySqlCommand(query, connection);
            MySqlDataReader reader=cmd.ExecuteReader();
            ObservableCollection<Contacto> contactos = new ObservableCollection<Contacto>();
            while (reader.Read())
            {
                Contacto contacto = new Contacto();
                contacto.Id=reader.GetInt32(0);
                contacto.Nombre=reader.GetString(1);
                contacto.Correo=reader.GetString(2);
                contacto.Telefono=reader.GetString(3);
                contactos.Add(contacto);
            }
               reader.Close();
            return contactos;
        }

    }
}
