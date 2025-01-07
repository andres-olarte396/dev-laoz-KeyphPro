namespace KeyphPro.Domain.Entities.Database
{
    public class StoredScript
    {
        public int Id { get; set; }
        public string Name { get; set; } // Nombre único del script
        public string SqlScript { get; set; } // Contenido del script SQL
    }
}
