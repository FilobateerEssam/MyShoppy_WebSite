using System.ComponentModel.DataAnnotations;

namespace myshop.Entities.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;


        public static string StripHtmlTags(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            var array = new char[input.Length];
            var arrayIndex = 0;
            var inside = false;

            foreach (var @let in input)
            {
                switch (@let)
                {
                    case '<':
                        inside = true;
                        continue;
                    case '>':
                        inside = false;
                        continue;
                    default:
                        if (!inside)
                        {
                            array[arrayIndex] = @let;
                            arrayIndex++;
                        }
                        break;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}
