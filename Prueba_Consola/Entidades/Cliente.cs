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

        public string Telefono { get => telefono; 
            
            set {
                if (string.IsNullOrWhiteSpace(value) == false
                 && value.EsNumerica() == true
                 && value.Length <= 11)
                {
                    telefono = value;
                }  
            } 

            
        
        }
    }

   
    
}