namespace Chopwella.Core
{
    public interface IDay
    {
         int Id { get; set; }
         bool Monday { get; set; }
         bool Tuesday { get; set; }
         bool Wednesday { get; set; }
         bool Thursday { get; set; }
         bool Friday { get; set; }
    }
}
