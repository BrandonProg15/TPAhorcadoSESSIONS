public static class Juego
{
   public static string palabra = "QUESO";
        public static List<char> letrasUsadas = new List<char>();
        public static int intentos = 0;
        public static bool terminado = false;

        public static string VerPalabra()
        {
            return new string(palabra.Select(letra => letrasUsadas.Contains(letra) ? letra : '_').ToArray());
        }

        public static void Reiniciar()
        {
            palabra = "ALFAJOR";
            letrasUsadas.Clear();
            intentos = 0;
            terminado = false;
        }

        public static void ProbarLetra(char letra)
        {
            if (!letrasUsadas.Contains(letra) && !terminado)
            {
                letrasUsadas.Add(letra);
                intentos++;
                if (!VerPalabra().Contains('_'))
                    terminado = true;
            }
        }

        public static string ArriesgarPalabra(string intento)
        {
            intentos++;
            terminado = true;
            return intento.ToUpper() == palabra ? "¡Ganaste!" : $"Perdiste. La palabra era: {palabra}";
        }
    }
    
