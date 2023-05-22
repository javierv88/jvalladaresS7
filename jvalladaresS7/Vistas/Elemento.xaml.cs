﻿using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jvalladaresS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<Estudiante> RActualizar;
        IEnumerable<Estudiante> REliminar;
        public Elemento(int id, string nombre, string usuario, string contrasena)
        {
            InitializeComponent();
            txtID.Text = id.ToString();
            txtNombre.Text = nombre;
            txtUsuario.Text = usuario;
            txtContrasena.Text = contrasena;
            conexion = DependencyService.Get<DataBase>().GetConnection();
            idSeleccionado = id;
        }
        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante WHERE id = ?", id);
        }
        public static IEnumerable<Estudiante> Actualizar(SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante set Nombre = ?, Usuario = ?, Contrasena = ? WHERE id = ?", nombre, usuario, contrasena, id);

        }
        private void btnEditar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                RActualizar = Actualizar(db, txtNombre.Text, txtUsuario.Text, txtContrasena.Text, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                REliminar = Eliminar(db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());
            }
            catch (Exception ex)
            {
                DisplayAlert("ALERTA", ex.Message, "Cerrar");
            }

        }
    }
}