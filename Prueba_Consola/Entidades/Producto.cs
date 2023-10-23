using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Entidades
{
    public class Producto
    {
        int id;
        string nombre;
        float cotizacion;
        CategoriaDelProduto categoria;
        int stock;
        string path;

        public Producto(string nombre, float cotizacion, 
            CategoriaDelProduto categoria,int stock, string path)
        {
            this.id = this.GetHashCode();
            this.Nombre = nombre;
            this.Costo = cotizacion;
            this.categoria = categoria;
            this.Stock = stock;
            this.path = path;
        }

        private bool ValidarNombre(string nombre)
        {
            return string.IsNullOrWhiteSpace(nombre) == false
                 && nombre.EsAlphaNumerica() == true;
        }
        
        /*

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listadoDeProducto"></param>
        /// <returns></returns>
        /// <exception cref="SerializarException"></exception>
        public bool LeerJson(string path, List<Producto> listadoDeProducto)
        {
            bool estado;
            string partidaJson;
            estado = false;

            try
            {
                if (listadoDeProducto.Count > 0 && path is not null)
                {
                    using (StreamReader sw = new StreamReader(path))
                    {
                        partidaJson = sw.ReadLine();
                        partidaJson = JsonSerializer.Deserialize(partidaJson);
                        JsonCo
                        estado = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SerializarException("Se Produjo un prolema al intentar Serializar en Json la lista", e);
            }



            return estado;
        }*/


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listadoDeProducto"></param>
        /// <returns></returns>
        /// <exception cref="SerializarException"></exception>
        public bool GuardarJson(string path, List<Producto> listadoDeProducto)
        {
            bool estado;
            string partidaJson;
            estado = false;

            try
            {
                if (listadoDeProducto.Count > 0 && path is not null)
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        partidaJson = JsonSerializer.Serialize(listadoDeProducto);
                        sw.Write(partidaJson);
                        estado = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SerializarException("Se Produjo un prolema al intentar Serializar en Json la lista", e);
            }



            return estado;
        }

        /// <summary>
        /// G
        /// </summary>
        /// <param name="path"></param>
        /// <param name="listadoDeProducto"></param>
        /// <returns></returns>
        /// <exception cref="SerializarException"></exception>
        public bool GuardarArchivoXml(string path, List<Producto> listadoDeProducto)
        {
            bool estado;
            estado = false;

            try
            {
                if (listadoDeProducto.Count > 0 && path is not null)
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(List<Producto>));
                        ser.Serialize(sw, listadoDeProducto);
                        estado = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SerializarException("Se Produjo un prolema al intentar Serializar en Xml la lista", e);
            }

            return estado;
        }

        public override bool Equals(object obj)
        {
            return obj is Producto producto &&
                   id == producto.id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public EstadoDelProducto Estado
        {

            get
            {

                EstadoDelProducto estado;
                estado = EstadoDelProducto.NoDisponible;
                if (this.stock > 0)
                {
                    estado = EstadoDelProducto.Disponible;
                }

                return estado;

            }
        }
        public float Costo
        {
            get { return this.cotizacion; }
            set
            {
                this.cotizacion = 0;
                if (value >= 0)
                {
                    this.cotizacion = value;
                }
            }
        }
        public string Nombre
        {
            get => nombre;

            set
            {
                this.nombre = "nombre invalido";
                if (ValidarNombre(value))
                {
                    this.nombre = value;
                }
            }
        }
        public string Path { get => path; set => path = value; }
        public CategoriaDelProduto Categoria { get => categoria; }
        public int Stock
        {
            get => stock;

            set
            {
                stock = 0;
                if (value >= 0)
                {
                    stock = value;
                }
            }
        }
        public enum CategoriaDelProduto { Herramientas, Moda ,Tecnologia,Vehiculo};
        public enum EstadoDelProducto { Disponible,NoDisponible};
    }
}