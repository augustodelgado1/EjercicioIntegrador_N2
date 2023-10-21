using System.Reflection;

namespace WinFormsApp1
{
    public partial class Form1<T> : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Agregar()
        {
            Type clase = typeof(T);

            PropertyInfo[] propiedades = clase.GetProperties();

        }
    }
}