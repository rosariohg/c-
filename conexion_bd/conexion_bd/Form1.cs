﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace conexion_bd
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            String servidor = txtServidor.Text;
            String bd = txtBaseDatos.Text;
            String user = txtUsuario.Text;
            String pwd = txtContrasena.Text;

            String str = "Server=" + servidor + ";DataBase=" + bd + ";";

            if (chkAutenticacion.Checked)
            {
                str += "Integrated Security=true";
            }
            else {
                str += "User Id=" + user + "; Password=" + pwd + ";";
            }
            try
            {
                conn = new SqlConnection(str);
                conn.Open();
                MessageBox.Show("Conectando Satisfactoriamente");
                btnDesconectar.Enabled = true;
            }
            catch(Exception ex) {
                MessageBox.Show("Error al conectar el servidor: \n" + ex.ToString());
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("Estado del Servidor: " + conn.State + "\nVersión del Servidor" + conn.ServerVersion + "\nBase de datos: " + conn.Database);
                }
                else
                    MessageBox.Show("Estado del servidor: " + conn.State);
            }
            catch(Exception ex) {
                MessageBox.Show("Imposible determinar el estado del servidor: \n " + ex.ToString());
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    MessageBox.Show("Conexión cerrada satisfactoriamente");
                }
                else
                {
                    MessageBox.Show("La conexión ya está cerrada");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Ocurrió un error al cerrar la conexión: \n " + ex.ToString());
            }
        }

        private void chkAutenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutenticacion.Checked)
            {
                txtUsuario.Enabled = false;
                txtContrasena.Enabled = false;
            }
            else {
                txtUsuario.Enabled = true;
                txtContrasena.Enabled = true;
            }
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(conn);
            persona.Show();
        }
    }
}
