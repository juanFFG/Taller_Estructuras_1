using Taller_Estructuras_1;

class Program
{
    static void Main(string[] args)
    {
        // Pruebas Carta
        Carta c1 = new Carta(Carta.Pinta.CORAZON, Carta.Valor.AS);
        Carta c2 = new Carta(Carta.Pinta.CORAZON, Carta.Valor.AS);
        Console.WriteLine(c1); // Imprime: AS de CORAZON
        Console.WriteLine(c1.Equals(c2)); // Imprime: True

        // Pruebas Mano
        Mano m1 = new Mano();
        m1.Agregar(new Carta(Carta.Pinta.CORAZON, Carta.Valor.AS));
        m1.Agregar(new Carta(Carta.Pinta.TREBOL, Carta.Valor.J));
        Console.WriteLine(m1); // Imprime: AS de CORAZON JOTA de TREBOL
        Console.WriteLine(m1.Valor()); // Imprime: 21

        Mano m2 = new Mano();
        m2.Agregar(new Carta(Carta.Pinta.CORAZON, Carta.Valor.AS));
        m2.Agregar(new Carta(Carta.Pinta.TREBOL, Carta.Valor.J));
        Console.WriteLine(m1.Equals(m2)); // Imprime: True

        // Pruebas Baraja
        Baraja b = new Baraja();
        b.Barajar();
        Carta c = b.SacarCarta();
        Console.WriteLine(c); // Imprime una carta aleatoria

        // Juego
        int numJugadores;
        do
        {
            Console.Write("Cuantos jugadores? ");
            if (!int.TryParse(Console.ReadLine(), out numJugadores))
            {
                Console.WriteLine("Por favor, ingresa un número válido.");
                continue;
            }

            if (numJugadores < 4 || numJugadores > 7)
            {
                Console.WriteLine("El número de jugadores debe estar entre 4 y 7.");
            }
        } while (numJugadores < 4 || numJugadores > 7);

        List<string> accionesValidas = new List<string> { "p", "P" };

        Baraja baraja = new Baraja();
        baraja.Barajar();

        List<Mano> manos = new List<Mano>();
        for (int i = 0; i < numJugadores; i++)
        {
            manos.Add(new Mano());
        }

        // Entrega de las 2 cartas a cada jugador en la primera ronda
        for (int i = 0; i < numJugadores; i++)
        {
            Carta carta1 = baraja.SacarCarta();
            Carta carta2 = baraja.SacarCarta();

            manos[i].Agregar(carta1);
            manos[i].Agregar(carta2);

            Console.WriteLine("Cartas del jugador " + (i + 1) + ": " + carta1 + ", " + carta2);
        }

        int numJugador;
        bool finRonda = false;

        List<Mano> manosAEliminar = new List<Mano>(); // lista para marcar manos que se pasan de 21

        while (!finRonda)
        {
            for (int i = 0; i < manos.Count; i++)
            {
                Mano mano = manos[i];
                numJugador = i + 1;

                if (!manos[i].activo) continue;

                Console.Write("\n" + $"Jugador {numJugador}, pide o pasa? (p/P): ");
                string accion;
                do
                {
                    accion = Console.ReadLine();

                    if (!accionesValidas.Contains(accion))
                    {
                        Console.WriteLine("Acción inválida. Ingrese p o P");
                    }

                } while (!accionesValidas.Contains(accion)); // Repetir mientras la acción sea inválida

                if (accion == "p")
                {
                    Carta card = baraja.SacarCarta();
                    mano.Agregar(card);
                    Console.WriteLine($"Saco {card}");
                    if (mano.Valor() > 21)
                    {
                        Console.WriteLine("Lo siento, perdiste!");
                        manosAEliminar.Add(mano);
                        mano.activo = false;
                    }
                    else if (mano.Valor() == 21)
                    {
                        Console.WriteLine("Blackjack, ganaste!");
                        finRonda = true;
                        break;
                    }

                }
                else if (accion == "P")
                {
                    Console.WriteLine("No tomo carta");
                    manosAEliminar.Add(mano);
                    mano.activo = false;
                }
            }

            if (manosAEliminar.Count == manos.Count)
            {
                finRonda = true;
            }
        }



        Mano ganador = manos.Where(m => m.Valor() <= 21).OrderByDescending(x => x.Valor()).FirstOrDefault();

        if (ganador != null)
        {
            int jugadorGanador = manos.IndexOf(ganador) + 1;
            Console.WriteLine($"El ganador es el jugador {jugadorGanador} con valor {ganador.Valor()}");
        }
        else
        {
            Console.WriteLine("Gana la casa");
        }

        // Eliminar las manos marcadas para eliminar
        foreach (Mano manoEliminar in manosAEliminar)
        {
            manos.Remove(manoEliminar);
        }

    }

}