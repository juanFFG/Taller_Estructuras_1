using System;
using System.Collections.Generic;
using System.Linq;

namespace Taller_Estructuras_1
{
    public class Baraja
    {
        private List<Carta> cartas;

        public Baraja()
        {
            cartas = new List<Carta>();
            foreach (Carta.Pinta p in Enum.GetValues(typeof(Carta.Pinta)))
            {
                foreach (Carta.Valor v in Enum.GetValues(typeof(Carta.Valor)))
                {
                    cartas.Add(new Carta(p, v));
                }
            }
        }

        public void Barajar()
        {
            Random r = new Random();
            int n = cartas.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = r.Next(i + 1);
                Carta temp = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = temp;
            }
        }

        public Carta SacarCarta()
        {
            if (cartas.Count == 0)
            {
                throw new InvalidOperationException("No hay cartas en la baraja.");
            }

            Carta carta = cartas[cartas.Count - 1];
            cartas.RemoveAt(cartas.Count - 1);
            return carta;
        }
    }
}
