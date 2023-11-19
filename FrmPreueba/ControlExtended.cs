using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico
{
    public static class ControlExtended
    {
        /// <summary>
        /// Muestra un error provider informando que condiciones debe cumplir el Control pasado por parametro
        /// </summary>
        /// <param name="unControl">el control</param>
        /// <param name="mensaje">Mensaje informando que condiciones debe cumplir el control</param>
        /// <param name="predicate">el metodo que va a derminar si se cumplieron las condiciones , que debe
        /// retornar (True) en caso que se cumpla o (false) de caso contrario</param>
        /// <returns>(false) en caso de que el control no se cumpla con la condiciones de el metodo pasado por parametro
        /// de lo contrario devueve (true)</returns>
        public static bool ActivarControlError<T>(this Control unControl, string msgError, Predicate<T> predicate, T element)
        {
            bool estado;
            estado = false;
            if (unControl is not null && predicate is not null)
            {
                unControl.Visible = true;
                unControl.Text = msgError;
                if ((estado = predicate.Invoke(element)) == true)
                {
                    estado = true;
                    unControl.Visible = false;
                }
            }

            return estado;
        }
        
        public static bool DetectarTextBoxVacio(Control.ControlCollection listaDeControles)
        {
            bool result = false;
            if (listaDeControles is not null)
            {
                result = true;
                foreach (Control unControlDeLaLista in listaDeControles)
                {
                    if (unControlDeLaLista is TextBox unTexbox 
                     && string.IsNullOrWhiteSpace(unTexbox.Text))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }

    }
}
