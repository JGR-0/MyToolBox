namespace CalculosPlusvalias.Services.Services.GainCalculators
{
    internal abstract class GainCalculator
    {
        internal abstract float GetCalculatedGain(Transaction sale, Transaction buy);
    }
}
