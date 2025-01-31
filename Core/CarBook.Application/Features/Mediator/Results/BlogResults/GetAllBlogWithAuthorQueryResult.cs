﻿
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Results.BlogResults
{
  public class GetAllBlogWithAuthorQueryResult
  {
    public int BlogID { get; set; }
    public int AuthorID { get; set; }
    public string AuthorName { get; set; }
    public string AuthorDescripton { get; set; }
    public string AuthorImageUrl { get; set; }
    public string Description { get; set; }
    public string CoverImageUrl { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CategoryID { get; set; }
    

  }
}
