using Entidades;
using Microsoft.VisualBasic;
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

namespace TallerMecanico
{
    public partial class FrmMostrar<T> : Form
    {
        Type unTipo;
        T element;
        List<PropertyInfo> propertiesGets;
        Predicate<PropertyInfo> predicate;
        /// <summary>
        /// Inicializa los valores de la clase
        /// </summary>
        /// <param name="element">El elemnto que quiere mostrar</param>
        /// <param name="path">el path donde se que encuntra Foto del elemento</param>
        /// <param name="titulo">Titulo del form </param>
        public FrmMostrar(T element,string path = null, string titulo = "Perfil")
        {
            InitializeComponent();
            this.unTipo = typeof(T);
            this.element = element;
            this.path = path;
            this.Titulo = titulo;
        }
        /// <summary>
        /// Inicializa los valores de la clase
        /// </summary>
        /// <param name="element">El elemnto que quiere mostrar</param>
        /// <param name="path">el path donde se que encuntra Foto del elemento</param>
        /// <param name="titulo">Titulo del form </param>
        /// <param name="predicate">metodo que indica que los datos de que propiedades quiere mostrar</param>
        public FrmMostrar(T element, Predicate<PropertyInfo> predicate, string path = null, string titulo = "Perfil") : this(element, path, titulo)
        {
            this.predicate = predicate;
        }
        private void FrmMostrar_Load(object? sender, EventArgs e)
        {
            if (this.element is not null)
            {
                this.propertiesGets = ObtenerPropiedades(unTipo.GetProperties(), unaPropiedad => unaPropiedad is not null && unaPropiedad.CanRead == true);
                if (predicate is not null)
                {
                    this.propertiesGets = ObtenerPropiedades(this.propertiesGets.ToArray(), predicate);
                }
                CrearControles(this.flowLayoutPanel1.Controls, this.propertiesGets);
            }
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Crea un Label y gueada los datos de la propiedad
        /// </summary>
        /// <param name="unaPropiedad">datos a guardar</param>
        /// <returns></returns>
        private Control CrearUnControl(PropertyInfo unaPropiedad)
        {
            Label unControl = default;
            if (unaPropiedad is not null)
            {
                unControl = new Label();
                unControl.AutoSize = true;
                unControl.Font = new Font("Arial", 12.5F, FontStyle.Regular, GraphicsUnit.Point);
                unControl.Name = $"lbl{unaPropiedad.Name}";
                unControl.Text = $"{unaPropiedad.Name}: {unaPropiedad.GetValue(element)}";
            }

            return unControl;
        }

        /// <summary>
        /// Recorre la lista de PropertyInfo y la llma una funcion que crea controles y ese control creado lo guarda dentro de una lista de controles
        /// </summary>
        /// <param name="listaDeControles">la lista donde se va guardar los controles creados</param>
        /// <param name="unaLista">la lista que contiene las propiedades que se quiren guardar</param>
        /// <returns>(true) si se pudo agragar los controles , (false) si no se pudo</returns>
        private bool CrearControles(Control.ControlCollection listaDeControles, List<PropertyInfo> unaLista)
        {
            bool result = default;

            if (unaLista is not null && listaDeControles is not null &&
             unaLista.Count > 0)
            {
                result = true;
                foreach (PropertyInfo unProperty in unaLista)
                {
                    listaDeControles.Add(CrearUnControl(unProperty));
                }
            }

            return result;
        }

        /// <summary>
        /// crea una la lista de propiedades guardando los elementos que cumplen con el criterio pasado por parametro 
        /// </summary>
        /// <param name="propertyInfos">ela lista de propiedades</param>
        /// <param name="predicate">el Criterio a cumplir</param>
        /// <returns>la lista de propiedades con los elementos que cumplen con el criterio pasado por parametro </returns>
        private static List<PropertyInfo> ObtenerPropiedades(PropertyInfo[] propertyInfos, Predicate<PropertyInfo> predicate)
        {
            List<PropertyInfo> result = new List<PropertyInfo>();

            if (predicate is not null && propertyInfos is not null)
            {
                foreach (PropertyInfo unProperty in propertyInfos)
                {
                    if (predicate.Invoke(unProperty) == true)
                    {
                        result.Add(unProperty);
                    }
                }
            }

            return result;
        }

        private string path
        {
            set

            {
                try
                {
                    string path;
                    path = Path.Combine(Environment.CurrentDirectory, "imagenes\\3177440.png");
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        path = value;
                    }
                    this.pBxImagen.Image = Image.FromFile(path);
                }
                catch (Exception)
                {
                }

            }
        }
        
        private string Titulo
        {
            set
            {
                lblTitulo.Text = "Perfil";
                if (!string.IsNullOrWhiteSpace(value))
                {
                    lblTitulo.Text = value;
                }
            }
        }
    }
}
