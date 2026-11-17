namespace Simulador
{
    // INICIO C04 - PERSONA 2: cálculos independientes de la página.
    public static class Calculadora
    {
        // Obtiene la TNA media del banco con los tres porcentajes ingresados.
        public static decimal Promediar(decimal primero, decimal segundo, decimal tercero)
        {
            return (primero + segundo + tercero) / 3m;
        }

        // Capitaliza los intereses en 1, 4 o 12 períodos y devuelve la ganancia en pesos.
        public static decimal CalcularGanancia(decimal capital, decimal tna, int periodos)
        {
            decimal tasaPorPeriodo = tna / 100m / periodos;
            decimal saldo = capital;
            for (int periodo = 1; periodo <= periodos; periodo++)
            {
                decimal interes = saldo * tasaPorPeriodo;
                saldo += interes;
            }
            return decimal.Round(saldo - capital, 2, System.MidpointRounding.AwayFromZero);
        }
    }
}
// FIN C04
