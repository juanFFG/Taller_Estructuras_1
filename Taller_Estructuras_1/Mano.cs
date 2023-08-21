using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Estructuras_1
{
    public class Mano
    {
        private List<Carta> cartas;
        public bool activo = true;

        public Mano()
        {
            cartas = new List<Carta>();
        }

        public void Agregar(Carta carta)
        {
            cartas.Add(carta);
        }

        public int Valor()
        {
            int valor = 0;
            foreach (Carta c in cartas)
            {
                if (c.valor == Carta.Valor.AS)
                    valor += 1;
                else if (c.valor >= Carta.Valor.J)
                    valor += 10;
                else
                    valor += (int)c.valor + 1;
            }
            return valor;
        }

        public override string ToString()
        {
            string s = "";
            foreach (Carta c in cartas)
            {
                s += c + " ";
            }
            return s;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Mano))
                return false;

            Mano m = (Mano)obj;
            return m.Valor() == Valor();
        }
    }

}
