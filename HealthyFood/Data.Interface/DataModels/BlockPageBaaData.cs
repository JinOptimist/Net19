namespace Data.Interface.DataModels
{
    public class BlockPageBaaData
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public List<CommentAndAuthorData> CommentAndAuthor { get; set; }
    }
}
