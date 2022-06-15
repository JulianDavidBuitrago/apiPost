namespace apiPost.Models{

    public class Post{

        public int Id {get; set;}
        public DateTime fechaCreacion {get; set;}
        public string? titulo {get; set;}
        public string? texto {get; set;}
    }
}