using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerMecanico
{
    public static class ControlExtended
    {
       /* internal static void AgregarElementosAlDataGried<T>(this DataGridView dataGridView, List<T> list)
        {
            dataGridView.Rows.Clear();
            if (listaDePartidas is not null)
            {
                foreach (Partida unaPartida in listaDePartidas)
                {
                    if (unaPartida is not null
                     && dataGridView.Rows.Add(unaPartida.Nombre, unaPartida.ListaDeJugadoresDeLaPartida
                     , unaPartida.CantidadDeJugadores, unaPartida.EstadoDeLaPartida) < 0)
                    {
                        break;
                    }
                }
            }
        }*/
        public static bool DetectarTextBoxVacio(this Control.ControlCollection controls)
        {
            bool result = false;

            if (controls is not null && controls.Count > 0
             && controls.Find(control => control is TextBox && string.IsNullOrWhiteSpace(((TextBox)control).Text) == true) is not null)
            {
                result = true;
            }

            return result;
        }
        public static Control Find(this Control.ControlCollection listaDeControles, Predicate<Control> predicate)
        {
            Control retorno = null;

            if (predicate is not null && listaDeControles is not null && listaDeControles.Count > 0)
            {
                foreach (Control unControl in listaDeControles)
                {
                    if (predicate.Invoke(unControl) == true)
                    {
                        retorno = unControl;
                        break;
                    }
                }
            }

            return retorno;
        }


        public static bool ConfirmarSalida(string mensaje, string titulo)
        {
            bool estado;
            DialogResult respuesta;
            respuesta = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            estado = false;

            if (respuesta == DialogResult.No)
            {
                estado = true;
            }

            return estado;
        }
    }
}
