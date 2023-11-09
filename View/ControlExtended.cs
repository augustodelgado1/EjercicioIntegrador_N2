using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico
{
    public static class ControlExtended
    {
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
                    unControl.Visible = false;
                }
            }

            return estado;
        }

    }
}
