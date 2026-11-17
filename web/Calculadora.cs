namespace Simulador
{
   
    public static class Calculadora
    {
        
        public static decimal Promediar(decimal primero, decimal segundo, decimal tercero)
        {
            return (primero + segundo + tercero) / 3m;
        }

        
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

