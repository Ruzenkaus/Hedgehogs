using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezh
{
    public class ColorTransformer: IColorTransformer
    {
        private static readonly ColorTransformer _instance = new ColorTransformer();

        private ColorTransformer() { }

        public static ColorTransformer Instance => _instance;

        public int Transform(int[] population, int targetColor)
        {
            if (population[targetColor] == population.Sum())
                return 0; // Всі їжачки вже потрібного кольору.

            if (population.Count(x => x > 0) == 1)
                return -1; // Всі їжачки одного кольору, трансформація неможлива.

            int meetings = 0;

            while (population[targetColor] < population.Sum())
            {
                int color1 = -1, color2 = -1;

                for (int i = 0; i < 3; i++)
                {
                    if (i != targetColor && population[i] > 0)
                    {
                        if (color1 == -1) color1 = i;
                        else
                        {
                            color2 = i;
                            break;
                        }
                    }
                }

                if (color1 == -1 || color2 == -1)
                    return -1; // Немає достатньо їжачків різних кольорів для продовження.

                int possibleMeetings = Math.Min(population[color1], population[color2]);
                population[color1] -= possibleMeetings;
                population[color2] -= possibleMeetings;
                population[targetColor] += possibleMeetings;
                meetings += possibleMeetings;
            }

            return meetings;
        }

    }
}
