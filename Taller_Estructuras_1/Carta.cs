using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Estructuras_1
{
    public class Carta
    {
        public enum Pinta { TREBOL, DIAMANTE, CORAZON, PICAS }
        public enum Valor { AS, DOS, TRES, CUATRO, CINCO, SEIS, SIETE, OCHO, NUEVE, DIEZ, J, Q, K }

        public Pinta pinta;
        public Valor valor;

        public Carta(Pinta pinta, Valor valor)
        {
            this.pinta = pinta;
            this.valor = valor;
        }

        public override string ToString()
        {
            return $"{valor} de {pinta}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Carta))
                return false;

            Carta c = (Carta)obj;
            return c.pinta == pinta && c.valor == valor;
        }
    }
}
