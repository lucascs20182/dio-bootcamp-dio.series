namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        // toda classe que herdar dela por default terá o id
        public int id { get; protected set; }
    }
}
