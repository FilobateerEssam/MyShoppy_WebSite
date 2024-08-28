using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myshop.Entities.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		public string Description { get; set; }

		[DisplayName("Image")]
		[ValidateNever]
		public string Img { get; set; }

		[Required]
		public decimal Price { get; set; }

		[Required]
		[DisplayName("Category")]
		public int CategoryId { get; set; }
		[ValidateNever]
		public Category Category { get; set; }

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
