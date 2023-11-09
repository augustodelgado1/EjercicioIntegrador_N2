﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerMecanico;

namespace FrmPreueba
{
    public partial class FrmAltaDePersona : Form
    {
        Persona unaPersona;
        Usuario.Roles unRol;
        public event Action<Persona> seRealizoUnAlta;
        bool result;

        public FrmAltaDePersona(Usuario.Roles unRol)
        {
            InitializeComponent();
            this.unRol = unRol;
        }
        public FrmAltaDePersona(Usuario.Roles unRol, Persona unaPersona) : this(unRol)
        {
            this.unaPersona = unaPersona;
            SetPersona();
        }
        private void FrmAltaDeCliente_Load(object sender, EventArgs e)
        {
            this.lb_Fallas.Visible = false;
        }

        private void SetPersona()
        {
            this.txtEmail.Text = this.unaPersona.Email;
            this.txtNombre.Text = this.unaPersona.Nombre;
            this.txtDni.Text = this.unaPersona.Dni;
            this.DateFechaDeNacimiento.Value = this.unaPersona.FechaDeNacimiento;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            result = ActivarControlError<string>(lb_Fallas, "el Nombre Debe Contener solo letras", Persona.ValidarNombre, this.txtNombre.Text);
        }

        private static bool ActivarControlError<T>(Control unControl, string msgError, Predicate<T> predicate, T element)
        {
            bool estado;
            estado = false;

            if (unControl is not null && predicate is not null)
            {
                unControl.Visible = true;
                unControl.Text = msgError;
                if ((estado = predicate.Invoke(element)) == true)
                {
                    unControl.Visible = false;
                }
            }

            return estado;
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            result = ActivarControlError<string>(lb_Fallas, "el Dni Debe tener como minimo 6 numeros y maximo 8 numeros", Persona.ValidarDni, this.txtDni.Text);
        }

        private void DateFechaDeNacimiento_ValueChanged(object sender, EventArgs e)
        {
            result = ActivarControlError<DateTime>(lb_Fallas, "La fecha no es valida", Persona.ValidarFechaDeNacimiento, this.DateFechaDeNacimiento.Value);
        }
        private Usuario CrearUsuario()
        {
            Usuario unUsuario;

            if (this.unRol == Usuario.Roles.Cliente)
            {
                unUsuario = new Cliente(this.txtNombre.Text, this.txtDni.Text, this.DateFechaDeNacimiento.Value, this.txtEmail.Text, this.txtClave.Text);
            }
            else
            {
                unUsuario = new Mecanico(this.txtNombre.Text, this.txtDni.Text, this.DateFechaDeNacimiento.Value, this.txtEmail.Text, this.txtClave.Text);
            }

            return unUsuario;
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (result == false)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            result = ActivarControlError<string>(lb_Fallas, "el Clave Debe tener como minimo 8 caracteres", Persona.ValidarContracenia, this.txtClave.Text);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            result = ActivarControlError<string>(lb_Fallas, "el Email Debe tener como minimo 8 caracteres", Persona.ValidarEmail, this.txtEmail.Text);
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            /*  FrmListar<Cliente>.AbrirArchivo("Imagen de perfil", "Archivos de imagen|*.jpg;*.jpeg;*.png|Todos los archivos|*.*", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));*/
        }
    }
}
