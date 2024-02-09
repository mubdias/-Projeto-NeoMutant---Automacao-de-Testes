
namespace NotionTableData
{
    public class NotionTableData
    {
        public class User
        {
            public string Object { get; set; }
            public string Id { get; set; }
        }

        public class Parent
        {
            public string Type { get; set; }
            public string Database_id { get; set; }
        }

        public class Text
        {
            public string Content { get; set; }
            public object Link { get; set; }
        }

        public class Annotations
        {
            public bool Bold { get; set; }
            public bool Italic { get; set; }
            public bool Strikethrough { get; set; }
            public bool Underline { get; set; }
            public bool Code { get; set; }
            public string Color { get; set; }
        }

        public class RichText
        {
            public string Type { get; set; }
            public Text Text { get; set; }
            public Annotations Annotations { get; set; }
            public string Plain_text { get; set; }
            public object Href { get; set; }
        }

        public class CNPJ
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public List<RichText> Rich_text { get; set; }
        }

        public class Telefone
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public List<RichText> Rich_text { get; set; }
        }

        public class Canal
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public List<RichText> Rich_text { get; set; }
        }

        public class Email
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public List<RichText> Rich_text { get; set; }
        }

        public class Nome
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public List<RichText> Title { get; set; }
        }

        public class Properties
        {
            public CNPJ CNPJ { get; set; }
            public Telefone Telefone { get; set; }
            public Canal Canal { get; set; }
            public Email Email { get; set; }
            public Nome Nome { get; set; }
        }

        public class Result
        {
            public string Object { get; set; }
            public string Id { get; set; }
            public DateTime Created_time { get; set; }
            public DateTime Last_edited_time { get; set; }
            public User Created_by { get; set; }
            public User Last_edited_by { get; set; }
            public object Cover { get; set; }
            public object Icon { get; set; }
            public Parent Parent { get; set; }
            public bool Archived { get; set; }
            public Properties Properties { get; set; }
            public string Url { get; set; }
            public object Public_url { get; set; }
        }

        public class Root
        {
            public string Object { get; set; }
            public List<Result> Results { get; set; }
        }

    }

}