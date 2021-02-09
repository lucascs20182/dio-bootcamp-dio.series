using System;

namespace DIO.Series
{
    public class Serie: EntidadeBase
    {
        private Genero genero { get; set; }
        private string titulo { get; set; }
        private string descricao { get; set; }
        private int ano { get; set; }

        private bool excluido { get; set; }

        public Serie(int id, Genero genero, string titulo,
            string descricao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }

        public override string ToString()
        {
            return String.Format(
                "Gênero: {0}\nTítulo: {1}\nDescrição: {2}\nAno de início: {3}\nExcluído: {4}",
                this.genero, this.titulo, this.descricao, this.ano, this.excluido
            );
        }

        public string retornaTitulo()
        {
            return this.titulo;
        }

        public int retornaId()
        {
            return this.id;
        }

        public bool retornaExcluido()
        {
            return this.excluido;
        }

        public void Excluir()
        {
            this.excluido = true;
        }
    }
}
