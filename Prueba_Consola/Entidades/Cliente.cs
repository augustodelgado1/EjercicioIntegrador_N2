namespace Entidades
{
    public class Cliente:Usuario
    {
        string telefono;
        List<Compra> compras;
       
        public Cliente(string nombre, string email, string clave, string telefono, string path = null) : base(nombre, email, clave ,Roles.Cliente, path)
        {
            this.Telefono = telefono;
            this.compras = new List<Compra>();
        }


        public static bool ValidarTelefono(string telefono)
        {
            return string.IsNullOrWhiteSpace(telefono) == false
                 && telefono.EsNumerica() == true
                 && telefono.Length  >= 8 && telefono.Length <= 12;
        }
        public static bool operator +(Cliente unCliente, Compra unaCompra)
        {
            bool result = false;

            if(unCliente  is not null && unaCompra is not null 
              && unCliente.compras.Contains(unaCompra) == false)
            {
                unCliente.compras.Add(unaCompra);
                result = true;
            }


            return result;
        }
        
        public static bool operator -(Cliente unCliente, Compra unaCompra)
        {
            bool result = false;

            if(unCliente.compras.Contains(unaCompra) == true)
            {
                unCliente.compras.Remove(unaCompra);
                result = true;
            }


            return result;
        }
        public string Telefono { get => telefono; 
            
            set {
                if (ValidarTelefono(value))
                {
                    telefono = value;
                }  
            } 
        }
    }

   
    
}